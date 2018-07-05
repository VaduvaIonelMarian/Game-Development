using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;

public class FBManager : MonoBehaviour
{

    public GameObject DialogLoggedIn;
    public GameObject DialogLoggedOut;
    public GameObject DialogProfilePic;

    public static FBManager Instance;

    public GameObject scoreEntryPanel;
    public GameObject scoreScrollList;
    public GameObject leaderboard;

    Animator leaderboardAnim;
    private AnimationsHandler animationsHandler;
    public bool leaderboardUp;

    List<string> perms = new List<string>() { "public_profile", "email", "user_friends" };

    private void Awake()
    {
        DealWithFBMenus(FB.IsLoggedIn);
        FB.Init(SetInit, OnHideUnity);

        leaderboardAnim = leaderboard.GetComponent<Animator>();
        leaderboardUp = false;
        animationsHandler = GetComponent<AnimationsHandler>();
    }

    void SetInit()
    {
        if (FB.IsLoggedIn)
        {
            Debug.Log("FB is logged in");
        }
        else
        {
            Debug.Log("FB is not logged in");
        }

        DealWithFBMenus(FB.IsLoggedIn);
    }

    void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void FBLogin()
    {
        FB.LogInWithReadPermissions(perms, AuthCallBack);
        FB.LogInWithPublishPermissions(new List<string>() { "publish_actions" }, AuthCallBack);
        GameManager.Instance.LoggedIn();
    }

    void AuthCallBack(IResult result)
    {
        if (result.Error != null)
        {
            Debug.Log(result.Error);
        }
        else
        {
            if (FB.IsLoggedIn)
            {
                Debug.Log("FB is logged in");
            }
            else
            {
                Debug.Log("FB is not logged in");
            }

            DealWithFBMenus(FB.IsLoggedIn);
        }
    }

    public void Share()
    {
        FB.ShareLink(contentTitle: "Share Message",
            contentURL: new System.Uri("http://google.com"), contentDescription: "Here's a link", callback: OnShare);
    }

    public void OnShare(IShareResult result)
    {
        if (result.Cancelled || !string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("ShareLink error: " + result.Error);
        }
        else if (!string.IsNullOrEmpty(result.PostId))
        {
            Debug.Log(result.PostId);

        }
        else
            Debug.Log("Share succeeded");
    }

    public void FacebookLogout()
    {
        FB.LogOut();
        DealWithFBMenus(false);
    }

    void DealWithFBMenus(bool isLoggedIn)
    {
        if (isLoggedIn)
        {
            DialogLoggedIn.SetActive(true);
            DialogLoggedOut.SetActive(false);

            //FB.API("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
            FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfilePic);
        }
        else
        {
            DialogLoggedIn.SetActive(false);
            DialogLoggedOut.SetActive(true);
        }
    }

    //void DisplayUsername(IResult result)
    //{
    //    Text UserName = DialogUsername.GetComponent<Text>();

    //    if(result.Error == null)
    //    {
    //        UserName.text = "Hi there, " + result.ResultDictionary["first_name"];
    //    }
    //    else
    //    {
    //        Debug.Log(result.Error);
    //    }
    //}

    void DisplayProfilePic(IGraphResult result)
    {
        if (result.Texture != null)
        {
            Image profilePic = DialogProfilePic.GetComponent<Image>();

            profilePic.sprite = Sprite.Create(result.Texture, new Rect(0, 0, 130, 130), new Vector2());
        }
    }

    public void QueryScores()
    {
        if (FB.IsLoggedIn)
        {
            FB.API("/app/scores?field=score", HttpMethod.GET, ScoresCallback);
            if (!leaderboardUp)
            {
                if (animationsHandler.settingsDown)
                {
                    animationsHandler.Settings();
                }
                leaderboardAnim.SetBool("leaderboardShow", true);
                leaderboardUp = true;

            }
            else if (leaderboardUp)
            {
                leaderboardAnim.SetBool("leaderboardShow", false);
                leaderboardUp = false;
            }
        }
        else
        {
            if (animationsHandler.settingsDown)
            {
                animationsHandler.Settings();
            }
            GameManager.Instance.errorText.text = "You are not logged in on Facebook";
            StartCoroutine(GameManager.Instance.ShowErrorPanel());
        }
    }


    public void LeaderboardDown()
    {
        leaderboardAnim.SetBool("leaderboardShow", false);
        leaderboardUp = false;
    }

    private void ScoresCallback(IGraphResult result)
    {
        Debug.Log("Scores callback: " + result.RawResult);

        IDictionary<string, object> data = result.ResultDictionary;
        List<object> scoreList = (List<object>)data["data"];

        foreach (Transform child in scoreScrollList.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (object obj in scoreList)
        {
            var entry = (Dictionary<string, object>)obj;
            var User = (Dictionary<string, object>)entry["user"];
            //Debug.Log(User["name"].ToString() + " , " + entry["score"].ToString());

            GameObject scorePanel;
            scorePanel = Instantiate(scoreEntryPanel) as GameObject;
            scorePanel.transform.SetParent(scoreScrollList.transform);
            scorePanel.transform.localPosition = new Vector3(scorePanel.transform.position.x, scorePanel.transform.position.y, 1.0f);
            scorePanel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            Transform thisScoreName = scorePanel.transform.Find("FriendName");
            Transform thisScoreScore = scorePanel.transform.Find("FriendScore");
            Transform thisScoreAvatar = scorePanel.transform.Find("FriendAvatar");

            Text scoreNameText = thisScoreName.GetComponent<Text>();
            Text scoreScoreText = thisScoreScore.GetComponent<Text>();
            Image scoreAvatarImage = thisScoreAvatar.GetComponent<Image>();

            FB.API(User["id"] + "/picture?type=square&height=128&width=128", HttpMethod.GET, delegate (IGraphResult pictureResult)
            {
                if (pictureResult.Error != null)
                {
                    Debug.Log(pictureResult.Error);
                }
                else
                {
                    scoreAvatarImage.sprite = Sprite.Create(pictureResult.Texture, new Rect(0, 0, 128, 128), new Vector2(0, 0));
                }
            });

            scoreNameText.text = User["name"].ToString();
            scoreScoreText.text = entry["score"].ToString();
        }
    }

    public void SetScore()
    {
        if (FB.IsLoggedIn)
        {
            var scoreData = new Dictionary<string, string>();
            scoreData["score"] = GameManager.Instance.score.ToString();
            FB.API("me/scores", HttpMethod.POST, delegate (IGraphResult result)
            {
                Debug.Log("Score submit result: " + result.RawResult);
            }, scoreData);
        }
    }

}
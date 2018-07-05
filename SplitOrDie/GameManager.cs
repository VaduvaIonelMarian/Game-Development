using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public bool gameHasStarted;
    public bool isDead;
    public int score;
    public bool isPaused;

    private int highScore;
    private int lastScore;
    public int coins;
    public float moveSpeed;

    public Text bestScoreText;
    public Text lastScoreText;
    public Text coinsText;

    public bool watchedGiftAd;


    private MenuManager menuManager;
#if UNITY_ADS
    private PUPUnityAds unityAds;
#endif

    private FBManager facebookManager;
    //private Purchaser purchaser;
  

    public bool gameContinue;

    public GameObject destroyEffect;

    public GameObject continueCanvas;

    public int currentCoins;

     public  bool watchedAd;

    int numberOfDeaths;

    public bool isWatchAdActive;

    public Material ballMaterial;

    public GameObject errorPanel;
    public Text errorText;

    public bool showTutorial;
    public GameObject tutorialPanel;

    public GameObject watchAdForAnotherGiftPanel;

    // private Dictionary<string, object> dict = new Dictionary<string, object>();
    float timeInGame;
    int replay;
    int watchedAds;
    int pressedPlay;
    int pressedShop;
    int loggedIn;
    int diedFromSmallObstacle;
    int diedFromBigObstacle;
    int diedFromWall;

    public GameObject coinsPanel;
    public Text revieceCoinsText;
    public Text youRecieveText;
    Animator youRecieveAnim;
    Animator recieveCoinsAnim;

    public Text continueCanvasScoreText;

    public AudioSource audioSource;
   // public AudioClip backGroundMusic;
    public AudioClip ballDestroy;
    public AudioClip coinCollect;
    public GameObject backgroundMusic;
    public AudioSource backgroundMusicAudio;
   
    

    private void Awake()
    {
        

        if(Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        highScore = PlayerPrefs.GetInt("highScore");
        bestScoreText.text = highScore.ToString();

        lastScore = PlayerPrefs.GetInt("lastScore");
        lastScoreText.text = lastScore.ToString();

        currentCoins = PlayerPrefs.GetInt("coins");
        coinsText.text = currentCoins.ToString();
       
        score = 0;
        isDead = true;
        gameHasStarted = false;
        numberOfDeaths = 0;

        isPaused = false;

        showTutorial = true;

        //PlayerPrefs.DeleteAll();
        
    }

    private void Start()
    {

        

        menuManager = GetComponent<MenuManager>();
#if UNITY_ADS
        unityAds = GetComponent<PUPUnityAds>();
#endif
        facebookManager = GetComponent<FBManager>();
        //purchaser = GetComponent<Purchaser>();
        youRecieveAnim = youRecieveText.GetComponent<Animator>();
        recieveCoinsAnim = revieceCoinsText.GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();

        backgroundMusicAudio = backgroundMusic.GetComponent<AudioSource>();

       
    }

    public void ActivateContinueCanvas()
    {
        continueCanvasScoreText.text = score.ToString();
        continueCanvas.SetActive(true);
        isWatchAdActive = true;

    }

    private void Update()
    {
        timeInGame += Time.deltaTime;

      
    }

    public void WatchAdToContinue()
    {
#if UNITY_ADS
        unityAds.ShowRewardedAd();
        continueCanvas.SetActive(false);
#endif

        
    }

    public void DontWatchAdToContinue()
    {
        continueCanvas.SetActive(false);
        Transform playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        GameObject explosion = Instantiate(destroyEffect, playerPosition.position, playerPosition.rotation) as GameObject;
        Destroy(explosion, 2.0f);
        Destroy(playerPosition.root.gameObject);
        PlayerHasDied();
        isWatchAdActive = false;

        if (audioSource.enabled == true)
        {
            audioSource.clip = ballDestroy;
            audioSource.Play();
        }
       
        
    }

   

    public void ContinueAfterSuccesfullyAd()
    {
        watchedAd = true;
        menuManager.ContinueGame();
        isWatchAdActive = false;
        WatchedAd();
        numberOfDeaths=0;
    }

    public void PlayerHasDied()
    {
#if UNITY_ADS
        if (numberOfDeaths >= 9)
        {
            unityAds.ShowAd();
            numberOfDeaths = 0;
        }
        else
        {
            numberOfDeaths++;
        }
#endif

        watchedAd = false;
        menuManager.TurnCanvasOn();
        menuManager.SetScoreAfterDeath();

        PlayerPrefs.SetInt("lastScore", score);
        lastScoreText.text = lastScore.ToString();

        highScore = PlayerPrefs.GetInt("highScore");
        if (score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            bestScoreText.text = PlayerPrefs.GetInt("highScore").ToString();
            facebookManager.SetScore();
        }

        currentCoins = PlayerPrefs.GetInt("coins");
        currentCoins += coins;
        PlayerPrefs.SetInt("coins", currentCoins);
        coins = 0;
        //Debug.Log(currentCoins);
    }

    public void HandlePauseMenu()
    {
        if (isPaused)
        {
            isPaused = false;
        }
        else
        {
            isPaused = true;
        }

        menuManager.PauseMenu(isPaused);
    }

    public void IncrementScore()
    {
        score++;
    }


    public void IncrementCoins()
    {
        coins++;

        if (audioSource.enabled == true)
        {
            audioSource.clip = coinCollect;
            audioSource.Play();
        }
       
      //  Debug.Log("Coins: " + coins);
    }

    public void Quit()
    {
        if (!menuManager.saveTimeBool)
        {
            menuManager.saveTime = System.DateTime.Now;
        }
        OnQuit();
        // Debug.Log(timeInGame);
        Application.Quit();
    }

    public void OnQuit()
    {

        //dict["timePlayed"] = timeInGame;
        //Analytics.CustomEvent("ExitGame", dict);
        Analytics.CustomEvent("ExitGame", new Dictionary<string, object>
        {
            {"TimePlayed", timeInGame},
            {"WatchedAds", watchedAds },
            {"ReplayGame", replay },
            {"PressedShop", pressedShop },
            {"LoggedIn", loggedIn },
            {"PlayGame", pressedPlay }
            
        });
    }

    public void ReplayPress()
    {

        //dict["replayCount"] = replay;
        //Analytics.CustomEvent("ReplayGame", dict);
        replay++;
        Analytics.CustomEvent("ReplayGame", new Dictionary<string, object>
        {
           
            {"ReplayGame", replay }
        });
    }

    public void WatchedAd()
    {

        //dict["adsWatched"] = watchedAds;
        //Analytics.CustomEvent("WatchedAds", dict);
        watchedAds++;
        Analytics.CustomEvent("WatchedAds", new Dictionary<string, object>
        {
            {"WatchedAds", watchedAds },
        });
    }

    public void PlayPress()
    {

        //dict["pressPlay"] = pressedPlay;
        //Analytics.CustomEvent("PressedPlay", dict);
        pressedPlay++;
        Analytics.CustomEvent("PlayGame", new Dictionary<string, object>
        {
            {"PlayGame", pressedPlay }
        });

    }

    public void PressedShop()
    {
        pressedShop++;
        Analytics.CustomEvent("PressedShop", new Dictionary<string, object>
        {
            {"PressedShop", pressedShop }
        });
    }

    public void LoggedIn()
    {
        loggedIn++;
        Analytics.CustomEvent("LoggedIn", new Dictionary<string, object>
        {
            {"LoggedIn", loggedIn }
        });
    }

    public void DiedFromBigObstacle()
    {

        diedFromBigObstacle++;
        Analytics.CustomEvent("DiedFromBigObstacle", new Dictionary<string, object>
        {
            {"DiedFromBigObstacle", diedFromBigObstacle }
        });
    }

    public void DiedFromSmallObstacle()
    {

        diedFromSmallObstacle++;
        Analytics.CustomEvent("DiedFromSmallObstacle", new Dictionary<string, object>
        {
            {"DiedFromSmallObstacle", diedFromSmallObstacle }
        });
    }

    public void DiedFromWall()
    {
        diedFromWall++;
        Analytics.CustomEvent("DiedFromWall", new Dictionary<string, object>
        {
            {"DiedFromWall", diedFromWall }
        });
    }

    public void SetBallMaterial(Material _material)
    {
        ballMaterial = _material;
    }
    public Material GetBallMaterial()
    {
        return ballMaterial;
    }

    public IEnumerator ShowErrorPanel()
    {
        errorPanel.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        errorPanel.SetActive(false);
    }

    public IEnumerator ShowRecieveCoinsPanel()
    {
        coinsPanel.SetActive(true);
        recieveCoinsAnim.SetTrigger("recieveTrigger");
        youRecieveAnim.SetTrigger("youRecieve");
        yield return new WaitForSeconds(4.0f);
        coinsPanel.SetActive(false);
        if (!menuManager.watchedAnotherAdForGift)
        {
            watchAdForAnotherGiftPanel.SetActive(true);
        }
        else
        {
            menuManager.watchedAnotherAdForGift = false;
        }
    }

    public void SetInUse(string _key)
    {
        SkinPurchaser.Instance.SetUse(_key);
    }
    
    public void WatchGiftAd()
    {

#if UNITY_ADS
        watchedGiftAd = true;
        unityAds.ShowRewardedAd();
        
#endif
    }

    public void ReduceCoins(int amount)
    {
        currentCoins -= amount;
        PlayerPrefs.SetInt("coins", currentCoins);
        menuManager.currentCoins.text = currentCoins.ToString();
    }

    public bool RequestCoins(int amount)
    {
        if (amount <= currentCoins)
        {
            return true;
        }
        return false;
    }

    public void TutorialShow()
    {
        if(gameHasStarted && showTutorial)
        {
            tutorialPanel.SetActive(true);
        }
    }
    public void EndTutorial()
    {
        isDead = false;
        showTutorial = false;
        tutorialPanel.SetActive(false);
    }


    public void RecieveGiftCoins()
    {
        int giftCoins = Random.Range(5, 21);
        currentCoins += giftCoins;
        PlayerPrefs.SetInt("coins", currentCoins);
        coinsText.text = currentCoins.ToString();
        revieceCoinsText.text = giftCoins.ToString();
        menuManager.saveTime = System.DateTime.Now;
        menuManager.saveTimeBool = true;
        menuManager.gift.SetActive(false);
        StartCoroutine("ShowRecieveCoinsPanel");
    }

    public void DontWatchAdForAnotherGift()
    {
        watchAdForAnotherGiftPanel.SetActive(false);
    }


}

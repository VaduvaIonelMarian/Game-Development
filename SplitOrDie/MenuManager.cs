using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject menuCanvas;
    public GameObject playButton;
    public GameObject lastScoreText;
    public GameObject retryGamePanel;
    public GameObject playGamePanel;
    public GameObject inGameScoreCanvas;

    

    public Text inGameScoreText;

    public Animator leaderboarAnim;
    public Animator shopAnim;
    public Animator canvasPanelAnim;

    public Text scoreText;
    public Text coinsText;
    public Text currentCoins;

    public GameObject gift;
    public System.DateTime saveTime;
    public bool saveTimeBool;
    public bool watchedAnotherAdForGift;

   // public Text pauseScoreText;

    
    

    public void StartGame()
    {
        if (GameManager.Instance.isPaused)
        {
            GameManager.Instance.isPaused = false;
            PauseMenu(false);
        }
        else
        {
            GameManager.Instance.gameHasStarted = true;
            
            //GameManager.Instance.isDead = false;
            StartCoroutine(WaitLoadingScene());
            SceneManager.LoadScene(1);
            

            shopAnim.SetBool("shopUp", false);
            leaderboarAnim.SetBool("leaderboardShow", false);
            leaderboarAnim.SetTrigger("leaderBoardIdle");
            shopAnim.SetTrigger("idleInstance");

            canvasPanelAnim.SetBool("shopIsUp", false);
            canvasPanelAnim.SetTrigger("canvasPanelIdle");
            GameManager.Instance.PlayPress();
        }
    }

    public void RestartGame()
    {
        GameManager.Instance.isDead = false;
        StartCoroutine(WaitLoadingScene());
        SceneManager.LoadScene(1);
        GameManager.Instance.score = 0;

        shopAnim.SetBool("shopUp", false);
        leaderboarAnim.SetBool("leaderboardShow", false);
        leaderboarAnim.SetTrigger("leaderBoardIdle");
        shopAnim.SetTrigger("idleInstance");

        canvasPanelAnim.SetBool("shopIsUp", false);
        canvasPanelAnim.SetTrigger("canvasPanelIdle");

        GameManager.Instance.watchedAd = false;

        GameManager.Instance.ReplayPress();  
    }

    public void ContinueGame()
    {
        GameManager.Instance.isDead = false;
        StartCoroutine(WaitLoadingScene());
        SceneManager.LoadScene(1);
    }

    IEnumerator WaitLoadingScene()
    {
        yield return new WaitForSeconds(0.1f);
        menuCanvas.SetActive(false);
        GameManager.Instance.TutorialShow();
    }

    public void TurnCanvasOn()
    {
        if (GameManager.Instance.gameHasStarted)
        {
            playButton.SetActive(false);
            lastScoreText.SetActive(false);
            retryGamePanel.SetActive(true);

        }
      
            StartCoroutine(gameOver());
    }

    IEnumerator gameOver()
    {
        yield return new WaitForSeconds(1f);
        menuCanvas.SetActive(true);
        GameManager.Instance.currentCoins = PlayerPrefs.GetInt("coins");
        GameManager.Instance.coinsText.text = GameManager.Instance.currentCoins.ToString();
    }

    public void PauseMenu(bool _isPaused)
    {
        if (_isPaused)
        {
            menuCanvas.SetActive(true);
            playButton.SetActive(true);
            retryGamePanel.SetActive(false);
            playGamePanel.SetActive(false);
            // Time.timeScale = 0f;
            GameManager.Instance.isDead = true;

        }
        else
        {
            playButton.SetActive(false);
            retryGamePanel.SetActive(true);
            menuCanvas.SetActive(false);
            playGamePanel.SetActive(true);
            //  Time.timeScale = 1.0f;
            GameManager.Instance.isDead = false;
        }
    }

    public void SetScoreAfterDeath()
    {
        scoreText.text = GameManager.Instance.score.ToString();
        currentCoins.text = GameManager.Instance.currentCoins.ToString();
    }

    private void Update()
    {
        if (!GameManager.Instance.isDead && !GameManager.Instance.isPaused)
        {
            inGameScoreCanvas.SetActive(true);
            inGameScoreText.text = GameManager.Instance.score.ToString();
            coinsText.text = GameManager.Instance.coins.ToString();
            

        }
        else
        {
            inGameScoreCanvas.SetActive(false);
        }

        if ((System.DateTime.Now - saveTime).Minutes >= 2)
        {
            gift.SetActive(true);
            saveTimeBool = false;
        }

        if(Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance.isDead && !GameManager.Instance.isWatchAdActive)
        {
            GameManager.Instance.Quit();
        }

       



    }

    public void Gift()
    {
        watchedAnotherAdForGift = true;
        GameManager.Instance.WatchGiftAd();

        //GameManager.Instance.currentCoins += Random.Range(5,20);
        //PlayerPrefs.SetInt("coins", GameManager.Instance.currentCoins);
       // currentCoins.text = GameManager.Instance.currentCoins.ToString();
       
       // Debug.Log(currentCoins);

       // saveTime = System.DateTime.Now;
        // saveTimeBool = true;
       // gift.SetActive(false);

    }

    /*public void Quit()
    {

        if (!saveTimeBool)
        {
            saveTime = System.DateTime.Now;
        }
        Application.Quit();
    }*/

}

using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using System.Collections;

public class AnimationsHandler : MonoBehaviour
{

    public GameObject canvasPanel;
    public GameObject settings;
    public GameObject shopMenu;
    public Text audioText;
    public Sprite audioOnImg;
    public Sprite audioOffImg;
    public Button soundButton;

    Animator settingsAnim;
    Animator canvasPanelAnim;
    Animator shopAnim;

    private FBManager facebookManager;

    bool shopUp;
    bool audioOn = true;
    public bool settingsDown;

    public GameObject errorPanel;

    public GameObject shopContainer;
    float shopContainerY;
    Vector3 shopContainerPositon;


    void Start()
    {
        settingsDown = false;
        settingsAnim = settings.GetComponent<Animator>();
        shopUp = false;
        shopAnim = shopMenu.GetComponent<Animator>();
        facebookManager = GetComponent<FBManager>();
        canvasPanelAnim = canvasPanel.GetComponent<Animator>();

        shopContainerY = shopContainer.transform.position.y;
        shopContainerPositon = shopContainer.transform.position;
        audioOn = true;


    }

    public void Settings()
    {
        if (!settingsDown)
        {
            if (facebookManager.leaderboardUp)
            {
                facebookManager.QueryScores();
            }
            settingsDown = true;
            settingsAnim.SetBool("settings", true);
        }
        else if (settingsDown)
        {
            settingsDown = false;
            settingsAnim.SetBool("settings", false);
        }

        if (errorPanel.activeInHierarchy)
        {
            errorPanel.SetActive(false);
        }
    }

    public void AudioSetting()
    {
        SpriteState spriteState = new SpriteState();
        spriteState = soundButton.spriteState;

        if (audioOn)
        {
            audioOn = false;
            audioText.text = "Sound OFF";
            soundButton.image.sprite = audioOffImg;
            GameManager.Instance.audioSource.enabled = false;
            GameManager.Instance.backgroundMusicAudio.enabled = false;
          
        }
        else if (!audioOn)
        {
            audioOn = true;
            audioText.text = "Sound ON";
            soundButton.image.sprite = audioOnImg;
            GameManager.Instance.audioSource.enabled = true;
            GameManager.Instance.backgroundMusicAudio.enabled = true;

        }
    }

    public void ShopMenu()
    {
        //if (PlayGamesPlatform.Instance.IsAuthenticated())
        //{
        if (!shopUp)
        {
            shopUp = true;
            shopAnim.SetBool("shopUp", true);
            canvasPanelAnim.SetBool("shopIsUp", true);
            GameManager.Instance.PressedShop();
            if (settingsDown)
            {
                settingsDown = false;
                settingsAnim.SetBool("settings", false);
            }
        }
        else if (shopUp)
        {
            shopUp = false;
            shopAnim.SetBool("shopUp", false);
            canvasPanelAnim.SetBool("shopIsUp", false);

            StartCoroutine("resetShopContainer");
           
           
          
        }
        //}
        //else
        //{
        //    GameManager.Instance.errorText.text = "You are not logged in on Google Play";
        //    StartCoroutine(GameManager.Instance.ShowErrorPanel());
        //}
    }
    
    IEnumerator resetShopContainer()
    {
        yield return new WaitForSeconds(1f);
        shopContainerPositon.y = 0;
        shopContainer.transform.position = shopContainerPositon;
    }

    public void AllAnimations()
    {
        if (shopUp)
        {
            shopUp = false;
            shopAnim.SetBool("shopUp", false);
            canvasPanelAnim.SetBool("shopIsUp", false);
            StartCoroutine("resetShopContainer");
        }

        if (settingsDown)
        {
            settingsDown = false;
            settingsAnim.SetBool("settings", false);
        }
    }
}


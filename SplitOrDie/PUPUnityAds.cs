#if UNITY_ADS
using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.UI;


public class PUPUnityAds : MonoBehaviour

    
{
    private MenuManager menuManager;

    private void Start()
    {
        menuManager = GetComponent<MenuManager>();
    }


    public void ShowAd()
      {
          if ( Advertisement.IsReady() )
          {
              Advertisement.Show();


          }
      }

    public void ShowRewardedAd()
    {
        const string RewardedPlacementId = "rewardedVideo";


        if (!Advertisement.IsReady(RewardedPlacementId))
        {
            Debug.Log(string.Format("Ads not ready for placement '{0}'", RewardedPlacementId));
            GameManager.Instance.watchedGiftAd = false;
            if (GameManager.Instance.gameHasStarted)
            {
                GameManager.Instance.DontWatchAdToContinue();
                
            }
            GameManager.Instance.watchAdForAnotherGiftPanel.SetActive(false);
            menuManager.watchedAnotherAdForGift = false;
            


            return;
        }

        var options = new ShowOptions { resultCallback = HandleShowResult };
        Advertisement.Show(RewardedPlacementId, options);

    }


    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
              //  Debug.Log("The ad was successfully shown.");

              

                if (!GameManager.Instance.watchedGiftAd)
                {
                    GameManager.Instance.ContinueAfterSuccesfullyAd();  
                }

                if (GameManager.Instance.watchedGiftAd)
                {

                    int giftCoins = Random.Range(5, 21);
                    GameManager.Instance.currentCoins += giftCoins;
                    PlayerPrefs.SetInt("coins", GameManager.Instance.currentCoins);
                    GameManager.Instance.coinsText.text = GameManager.Instance.currentCoins.ToString();
                    GameManager.Instance.revieceCoinsText.text = giftCoins.ToString();
                    GameManager.Instance.watchAdForAnotherGiftPanel.SetActive(false);
                    StartCoroutine(GameManager.Instance.ShowRecieveCoinsPanel());
                    GameManager.Instance.watchedGiftAd = false;
                    
                }

               

                





                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");

             //   Debug.LogError("The ad failed to be shown.");
                GameManager.Instance.DontWatchAdToContinue();
                GameManager.Instance.watchedGiftAd = false;
                GameManager.Instance.watchAdForAnotherGiftPanel.SetActive(false);
                menuManager.watchedAnotherAdForGift = false;



                break;
            case ShowResult.Failed:
              //  Debug.LogError("The ad failed to be shown.");
                GameManager.Instance.DontWatchAdToContinue();
                GameManager.Instance.watchedGiftAd = false;
                GameManager.Instance.watchAdForAnotherGiftPanel.SetActive(false);
                menuManager.watchedAnotherAdForGift = false;
                break;

                
        }
    }

}
#endif









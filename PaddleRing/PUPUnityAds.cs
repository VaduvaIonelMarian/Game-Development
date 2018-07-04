#if UNITY_ADS
using UnityEngine.Advertisements;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// This script handles all UnityAds functions, calling an ad after a certain number of level loads, or showing a rewarded ad
/// </summary>
public class PUPUnityAds : MonoBehaviour
{
    public static int deathCounts = 0;

    public void Awake()
    {
    
        if (deathCounts > 0 && deathCounts % 3 == 0 && !Purchaser.Instance.IsNoAdsVersion())
        {
            ShowAd();  
        }       
    }

    

    /// <summary>
    /// Shows the ad if it's ready, and resets the timer for the next ad
    /// </summary>
    public void ShowAd()
    {
        if ( Advertisement.IsReady() )
        {
            Advertisement.Show();

            
        }
    }
}
#endif









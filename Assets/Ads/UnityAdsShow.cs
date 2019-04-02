using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;
using System.Collections.Generic;

public class UnityAdsShow : MonoBehaviour
{

#if !UNITY_ADS

#if UNITY_IPHONE
    private string gameId = "3100551";
#elif UNITY_ANDROID
    private string gameId = "3100550";
#endif

    private bool enableTestMode = true;
#endif

    void Start()
    {
#if !UNITY_ADS
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, enableTestMode);
        }
#endif

        /*while (!Advertisement.isInitialized || !Advertisement.IsReady())
        {
            yield return new WaitForSeconds(0.5f);
        }*/

        // Show the default ad placement.
        // Advertisement.Show();

        // banner
        // StartCoroutine(ShowBannerWhenReady());
    }

    public string bannerPlacement = "banner";

    IEnumerator ShowBannerWhenReady()
    {
        Debug.LogError("show banner before ready");
        while (!Advertisement.IsReady("banner"))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Debug.LogError("show banner when ready");
        Advertisement.Banner.Show(bannerPlacement);
    }

    public void showAd()
    {
        Advertisement.Show();
    }

}
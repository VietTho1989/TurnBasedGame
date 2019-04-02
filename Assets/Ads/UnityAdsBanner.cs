using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;
using System.Collections.Generic;

public class UnityAdsBanner : MonoBehaviour
{

    private string placementId = "banner";
    private bool testMode = true;

#if UNITY_IOS
    public const string gameID = "3100551";
#elif UNITY_ANDROID
    public const string gameID = "3100550";
#elif UNITY_EDITOR
    public const string gameID = "3100550";
#endif

    void Start()
    {
        Advertisement.Initialize(gameID, testMode);
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        Debug.LogError("show banner before ready");
        while (!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Debug.LogError("show banner when ready");
        Advertisement.Banner.Show(placementId);
    }

}
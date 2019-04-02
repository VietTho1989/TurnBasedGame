using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;
using System.Collections.Generic;

namespace Ads
{
    public class UnityAds : MonoBehaviour
    {

        public static UnityAds instance;

        private void Awake()
        {
            instance = this;
        }

#if UNITY_IOS
    public const string gameID = "3100551";
#elif UNITY_ANDROID
    public const string gameID = "3100550";
#elif UNITY_EDITOR
        public const string gameID = "3100550";
#else
        public const string gameID = "3100550";
#endif

        void Update()
        {
            if (Advertisement.isSupported)
            {
                switch (AdsManager.get().bannerVisibility.v)
                {
                    case AdsManager.BannerVisibility.Show:
                        {
                            switch (AdsManager.get().showType.v)
                            {
                                case AdsManager.AdsType.Unity:
                                    showBanner();
                                    break;
                                default:
                                    hideBanner();
                                    break;
                            }
                        }
                        break;
                    case AdsManager.BannerVisibility.Hide:
                        {
                            hideBanner();
                        }
                        break;
                    default:
                        Debug.LogError("unknown visibility: " + AdsManager.get().bannerVisibility.v);
                        break;
                }
            }
        }

        #region banner

        public void hideBanner()
        {
            if (Advertisement.isSupported)
            {
                if (Advertisement.isInitialized)
                {
                    Advertisement.Banner.Hide();
                }
            }
            else
            {
                Debug.LogError("unity ads not supported");
            }
        }

        public void showBanner()
        {
            if (Advertisement.isSupported)
            {
                // init
                intialize();
                // show
                if (Advertisement.IsReady(AdsManager.get().unityAdsBannerPlaceMentIds.v))
                {
                    Advertisement.Banner.Show(AdsManager.get().unityAdsBannerPlaceMentIds.v);
                }
            }
        }

        #endregion

        #region showVideo

        public void showVideo()
        {
            if (Advertisement.isSupported)
            {
                intialize();
                StartCoroutine(ShowVideoWhenReady());
            }
        }

        IEnumerator ShowVideoWhenReady()
        {
            while (!Advertisement.IsReady())
            {
                yield return new WaitForSeconds(0.5f);
            }
            Advertisement.Show();
        }

        #endregion

        #region intialize

        public void intialize()
        {
            if (Advertisement.isSupported)
            {
                if (!Advertisement.isInitialized)
                {
                    Advertisement.Initialize(gameID, AdsManager.testMode);
                }
            }
        }

        #endregion

    }
}
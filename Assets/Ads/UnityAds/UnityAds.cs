using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;
using System.Collections.Generic;

namespace Ads
{
    public class UnityAds : MonoBehaviour
    {

        public static UnityAds instance;

        private BannerOptions bannerOptions;// = new BannerOptions();

        private void Awake()
        {
            instance = this;
            // bannerOptions
            {
                bannerOptions = new BannerOptions { showCallback = OnShowBanner, hideCallback = OnHideBanner };
            }
        }

        public void OnShowBanner()
        {
            // Debug.LogError("onShowBanner");
        }

        public void OnHideBanner()
        {
            // Debug.LogError("onHideBanner");
        }


#if UNITY_IOS
    public const string gameID = "3104337";
#elif UNITY_ANDROID
    public const string gameID = "3104336";
#elif UNITY_EDITOR
        public const string gameID = "3104336";
#else
        public const string gameID = "3104336";
#endif

        void Update()
        {
            bool showBtnUnityAds = false;
            // banner
            if (Advertisement.isSupported)
            {
                switch (AdsManager.get().bannerVisibility.v)
                {
                    case AdsManager.BannerVisibility.Show:
                        {
                            switch (AdsManager.get().bannerType.v)
                            {
                                case AdsManager.AdsType.Unity:
                                    showBtnUnityAds = true;
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
            // btnUnityAds
            if (btnUnityAds != null)
            {
                btnUnityAds.gameObject.SetActive(showBtnUnityAds);
            }
            else
            {
                Debug.LogError("btnUnityAds null");
            }
        }

        #region banner

        public Button btnUnityAds;

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnUnityAds()
        {
            AdsManager.get().lastClickBanner.v = AdsManager.get().time.v;
            if (Setting.get().useShortKey.v)
            {
                Debug.LogError("TODO Can de phong il2cpp");
            }
        }

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
                    Advertisement.Banner.Show(AdsManager.get().unityAdsBannerPlaceMentIds.v, bannerOptions);
                }
            }
        }

        void HandleShowResult(ShowResult result)
        {
            if (result == ShowResult.Finished)
            {
                // Reward the player
            }
            else if (result == ShowResult.Skipped)
            {
                Debug.LogWarning("The player skipped the video - DO NOT REWARD!");
            }
            else if (result == ShowResult.Failed)
            {
                Debug.LogError("Video failed to show");
            }
        }

        public void reloadBanner()
        {
            BannerLoadOptions options = new BannerLoadOptions();

            options.errorCallback += ((string message) =>
            {
                Debug.Log("Error: " + message);
            });

            options.loadCallback += (() =>
            {
                Debug.Log("Ad Loaded");
            });

            Debug.Log("Loading banner ad");
            Advertisement.Banner.Load(AdsManager.get().unityAdsBannerPlaceMentIds.v, options);
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
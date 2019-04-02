using UnityEngine;
using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;

namespace Ads
{
    public class Admob : MonoBehaviour
    {

        #region instance

        public static Admob instance;

        private void Awake()
        {
            instance = this;
        }

        #endregion

        #region Update

        void Update()
        {
            switch (AdsManager.get().bannerVisibility.v)
            {
                case AdsManager.BannerVisibility.Show:
                    {
                        switch (AdsManager.get().showType.v)
                        {
                            case AdsManager.AdsType.Admob:
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

        #endregion

        #region bannerView

        private BannerView bannerView;

        public void hideBanner()
        {
            if (bannerView != null)
            {
                bannerView.Hide();
            }
            else
            {
                // Debug.LogError("bannerView null");
            }
        }

        private string lastAdUnitId = "";

        public void showBanner()
        {
            // init
            intialize();
            // compare last adUnitId
            if (lastAdUnitId != AdsManager.get().admobAdUnitId.v)
            {
                Debug.LogError("different lastAdUnitId");
                destroyBannerView();
            }
            // make banner
            if (bannerView == null)
            {
                bannerView = new BannerView(AdsManager.get().admobAdUnitId.v, AdSize.SmartBanner, AdPosition.Bottom);
                // request
                {
                    AdRequest request = new AdRequest.Builder().Build();
                    bannerView.LoadAd(request);
                }
                lastAdUnitId = AdsManager.get().admobAdUnitId.v;
            }
            // show
            if (bannerView != null)
            {
                bannerView.Show();
            }
        }

        private void destroyBannerView()
        {
            if (bannerView != null)
            {
                Debug.LogError("bannerView not null, destroy");
                bannerView.Destroy();
                bannerView = null;
            }
        }

        #endregion

        #region intialize

        private bool isInitialized = false;
        private string lastInitlizedAppId = "";

        void intialize()
        {
            if(!isInitialized || lastInitlizedAppId != AdsManager.get().admobAppId.v)
            {
                isInitialized = true;
                lastInitlizedAppId = AdsManager.get().admobAppId.v;
                MobileAds.Initialize(AdsManager.get().admobAppId.v);
                // reset bannerView
                destroyBannerView();
            }
        }

        #endregion

    }
}
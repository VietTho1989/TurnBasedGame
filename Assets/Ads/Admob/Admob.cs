using UnityEngine;
using GoogleMobileAds.Api;
using System;
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
                        switch (AdsManager.get().bannerType.v)
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

        private string lastBannerAdUnitId = "";

        public void showBanner()
        {
            // init
            intialize();
            // compare last adUnitId
            if (lastBannerAdUnitId != AdsManager.get().admobAdUnitId.v)
            {
                // Debug.LogError("different lastAdUnitId");
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
                // event
                {
                    // Called when an ad request has successfully loaded.
                    bannerView.OnAdLoaded += HandleOnAdLoaded;
                    // Called when an ad request failed to load.
                    bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
                    // Called when an ad is clicked.
                    bannerView.OnAdOpening += HandleOnAdOpened;
                    // Called when the user returned from the app after an ad click.
                    bannerView.OnAdClosed += HandleOnAdClosed;
                    // Called when the ad click caused the user to leave the application.
                    bannerView.OnAdLeavingApplication += HandleOnAdLeavingApplication;
                }
                lastBannerAdUnitId = AdsManager.get().admobAdUnitId.v;
            }
            // show
            if (bannerView != null)
            {
                bannerView.Show();
            }
        }

        #region handle bannerView event

        public void HandleOnAdLoaded(object sender, EventArgs args)
        {
            // MonoBehaviour.print("HandleAdLoaded event received");
        }

        public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
        {
            // MonoBehaviour.print("HandleFailedToReceiveAd event received with message: " + args.Message);
        }

        public void HandleOnAdOpened(object sender, EventArgs args)
        {
            // MonoBehaviour.print("HandleAdOpened event received");
            AdsManager.get().lastClickBanner.v = AdsManager.get().time.v;
        }

        public void HandleOnAdClosed(object sender, EventArgs args)
        {
            // MonoBehaviour.print("HandleAdClosed event received");
        }

        public void HandleOnAdLeavingApplication(object sender, EventArgs args)
        {
            // MonoBehaviour.print("HandleAdLeavingApplication event received");
        }

        #endregion

        private void destroyBannerView()
        {
            if (bannerView != null)
            {
                Debug.LogError("bannerView not null, destroy");
                bannerView.Destroy();
                bannerView = null;
            }
        }

        public void reloadBanner()
        {
            if (bannerView != null)
            {
                AdRequest request = new AdRequest.Builder().Build();
                bannerView.LoadAd(request);
            }
            else
            {
                Debug.LogError("bannerView null");
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
                this.rewardBasedVideo = RewardBasedVideoAd.Instance;
                // reset bannerView
                destroyBannerView();
                // reset interestialAds
                {
                    if (interstitialAd != null)
                    {
                        interstitialAd.Destroy();
                    }
                }
            }
        }

        #endregion

        public void showFullScreenAds()
        {
            // find index
            int index = 0;
            {
                switch (AdsManager.get().admobVideoType.v)
                {
                    case AdsManager.AdMobVideoType.Video:
                        index = 0;
                        break;
                    case AdsManager.AdMobVideoType.Interestial:
                        index = 1;
                        break;
                    case AdsManager.AdMobVideoType.Random:
                        {
                            System.Random random = new System.Random();
                            index = random.Next(2);
                        }
                        break;
                    default:
                        break;
                }
            }
            // show
            switch (index)
            {
                case 0:
                    this.showVideo();
                    break;
                case 1:
                    this.showInterstialAd();
                    break;
                default:
                    Debug.LogError("unknown index: " + index);
                    this.showVideo();
                    break;
            }
        }

        #region showVideo

        private RewardBasedVideoAd rewardBasedVideo;

        private void showVideo()
        {
            intialize();
            // create request
            if (this.rewardBasedVideo != null)
            {
                AdRequest request = new AdRequest.Builder().Build();
                this.rewardBasedVideo.LoadAd(request, AdsManager.get().admobAdUnitId.v);
            }
            else
            {
                Debug.LogError("rewardBasedVideo null");
            }
        }

        #endregion

        #region showInterestial

        private InterstitialAd interstitialAd;

        private string lastInterstialAdUnitId = "";

        private void showInterstialAd()
        {
            intialize();
            // remove old
            {
                if (AdsManager.get().admobAdUnitId.v != lastInterstialAdUnitId)
                {
                    if (interstitialAd != null)
                    {
                        interstitialAd.Destroy();
                    }
                }
            }
            // make new
            if (interstitialAd == null)
            {
                lastInterstialAdUnitId = AdsManager.get().admobAdUnitId.v;
                interstitialAd = new InterstitialAd(AdsManager.get().admobAdUnitId.v);
            }
            // request
            if (this.interstitialAd != null)
            {
                AdRequest request = new AdRequest.Builder().Build();
                this.interstitialAd.LoadAd(request);
            }
            else
            {
                Debug.LogError("interstialAd null");
            }
        }

        #endregion

    }
}
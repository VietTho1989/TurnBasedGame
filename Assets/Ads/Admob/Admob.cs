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

        #region builder

        public static readonly AdRequest.Builder builder = new AdRequest.Builder();

        static Admob()
        {
            builder.AddTestDevice("1965CBDF93808AD1A4A6D2C32178BAA3");
            builder.AddTestDevice("5989669AAB5442D4DA67C24ADD14196A");
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
            if (lastBannerAdUnitId != AdsManager.get().admobBannerAdUnitId.v)
            {
                // Debug.LogError("different lastAdUnitId");
                destroyBannerView();
            }
            // make banner
            if (bannerView == null)
            {
                bannerView = new BannerView(AdsManager.get().admobBannerAdUnitId.v, AdSize.SmartBanner, AdPosition.Bottom);
                // request
                {
                    AdRequest request = builder.Build();
                    {

                    }
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
                lastBannerAdUnitId = AdsManager.get().admobBannerAdUnitId.v;
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
                AdRequest request = builder.Build();
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
                // rewardBasedVideo
                {
                    this.rewardBasedVideo = RewardBasedVideoAd.Instance;
                    if (this.rewardBasedVideo != null)
                    {
                        this.rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
                        this.rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
                        this.rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
                        this.rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
                        this.rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
                        this.rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
                        this.rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
                    }
                    else
                    {
                        Debug.LogError("rewardBasedVideo null");
                    }
                }
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
            Debug.LogError("showVideoAds");
            intialize();
            // create request
            if (this.rewardBasedVideo != null)
            {
                AdRequest request = builder.Build();
                this.rewardBasedVideo.LoadAd(request, AdsManager.get().admobVideoAdUnitId.v);
            }
            else
            {
                Debug.LogError("rewardBasedVideo null");
            }
        }

        public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
        {
            MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
            if (this.rewardBasedVideo != null)
            {
                this.rewardBasedVideo.Show();
            }
            else
            {
                Debug.LogError("rewardBasedVideo null");
            }
        }

        public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
        {
            MonoBehaviour.print(
                "HandleRewardBasedVideoFailedToLoad event received with message: "
                                 + args.Message);
        }

        public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
        {
            MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
        }

        public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
        {
            MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
        }

        public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
        {
            MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
        }

        public void HandleRewardBasedVideoRewarded(object sender, Reward args)
        {
            string type = args.Type;
            double amount = args.Amount;
            MonoBehaviour.print(
                "HandleRewardBasedVideoRewarded event received for "
                            + amount.ToString() + " " + type);
        }

        public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
        {
            MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
        }

        #endregion

        #region showInterestial

        private InterstitialAd interstitialAd;

        private string lastInterstialAdUnitId = "";

        private void showInterstialAd()
        {
            Debug.LogError("showInterstialAd");
            intialize();
            // remove old
            {
                if (AdsManager.get().admobInterstitialAdUnitId.v != lastInterstialAdUnitId)
                {
                    if (interstitialAd != null)
                    {
                        interstitialAd.Destroy();
                        interstitialAd = null;
                    }
                }
            }
            // make new
            if (interstitialAd == null)
            {
                lastInterstialAdUnitId = AdsManager.get().admobInterstitialAdUnitId.v;
                interstitialAd = new InterstitialAd(AdsManager.get().admobInterstitialAdUnitId.v);
                // event
                {
                    interstitialAd.OnAdLoaded += InterstitialHandleOnAdLoaded;
                    interstitialAd.OnAdFailedToLoad += InterstitialHandleOnAdFailedToLoad;
                    interstitialAd.OnAdOpening += InterstitialHandleOnAdOpened;
                    interstitialAd.OnAdClosed += InterstitialHandleOnAdClosed;
                    interstitialAd.OnAdLeavingApplication += InterstitialHandleOnAdLeavingApplication;
                }
            }
            // request
            if (this.interstitialAd != null)
            {
                AdRequest request = builder.Build();
                this.interstitialAd.LoadAd(request);
            }
            else
            {
                Debug.LogError("interstialAd null");
            }
        }

        public void InterstitialHandleOnAdLoaded(object sender, EventArgs args)
        {
            Debug.LogError("HandleAdLoaded event received");
            if (this.interstitialAd != null)
            {
                this.interstitialAd.Show();
            }
            else
            {
                Debug.LogError("interstialAd null");
            }
        }

        public void InterstitialHandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
        {
            Debug.LogError("HandleFailedToReceiveAd event received with message: "
                                + args.Message);
        }

        public void InterstitialHandleOnAdOpened(object sender, EventArgs args)
        {
            Debug.LogError("HandleAdOpened event received");
        }

        public void InterstitialHandleOnAdClosed(object sender, EventArgs args)
        {
            Debug.LogError("HandleAdClosed event received");
        }

        public void InterstitialHandleOnAdLeavingApplication(object sender, EventArgs args)
        {
            Debug.LogError("HandleAdLeavingApplication event received");
        }

        #endregion

    }
}
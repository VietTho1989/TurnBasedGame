using UnityEngine;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;

namespace Ads
{
    public class AdsManager : Data
    {

        public const bool testMode = true;

        public VP<bool> alreadyBuyAds;

        #region allowEdit

        public enum AllowEdit
        {
            None,
            OnlyBuyer,
            All
        }

        public const AllowEdit DefaultAllowEdit = AllowEdit.None;

        public VP<AllowEdit> allowEdit;

        #endregion

        #region singleInstance

        private static AdsManager adsManager;

        static AdsManager()
        {
            adsManager = new AdsManager();
        }

        public static AdsManager get()
        {
            return adsManager;
        }

        #endregion

        public VP<float> time;

        public VP<long> realTime;

        public enum AdsType
        {
            None,
            Unity,
            Admob
        }

        #region video

        public const AdsType DefaultVideoType = AdsType.Unity;

        public VP<AdsType> videoType;

        public VP<bool> showBtnViewAds;

        #endregion

        #region banner

        public const AdsType DefaultBannerType = AdsType.Admob;

        public VP<AdsType> bannerType;

        #region bannerVisibility

        public enum BannerVisibility
        {
            Show,
            Hide
        }

        public VP<BannerVisibility> bannerVisibility;

        #endregion

        #region prepareBannerVisibility

        public enum PrepareBannerVisibility
        {
            None,
            Show,
            Hide
        }

        public VP<PrepareBannerVisibility> prepareBannerVisibility;

        #endregion

        public VP<float> lastClickBanner;

        public const float DefaultHideBannerDurationAfterClick = 20 * 60;// 20 minutes
        public VP<float> hideBannerDurationAfterClick;

        public VP<bool> hideAdsWhenStartPlay;

        public VP<bool> showAdsWhenGameEnd;

        public VP<bool> hideAdsWhenGameStart;

        public VP<bool> showAdsWhenGamePause;

        public VP<bool> hideAdsWhenGameNotPause;

        #region reloadBanner

        public const float DefaultReloadBannerInterval = 10 * 60;// 10 minutes

        public VP<float> reloadBannerInterval;

        public VP<float> lastReloadBannerTime;

        #endregion

        #endregion

        #region unityAds

        public VP<string> unityAdsBannerPlaceMentIds;

        #endregion

        ////////////////////////////////////////////////////////////////
        ///////////////////////// Admob ////////////////////////
        ////////////////////////////////////////////////////////////////

        #region appId

#if UNITY_ANDROID
        public const string DefaultAdmobAppId = "ca-app-pub-4497963493005970~6788422718";
#elif UNITY_IPHONE
            public const string DefaultAdmobAppId = "ca-app-pub-3940256099942544~1458002511";
#else
        public const string DefaultAdmobAppId = "unexpected_platform";
#endif

        public VP<string> admobAppId;

        #endregion

        #region banner

#if UNITY_ANDROID
        public const string DefaultAdmobBannerAdUnitId = "ca-app-pub-4497963493005970/1152952654";
#elif UNITY_IPHONE
        public const string DefaultAdmobBannerAdUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        public const string DefaultAdmobBannerAdUnitId = "unexpected_platform";
#endif

        public VP<string> admobBannerAdUnitId;

        #endregion

        #region interstitial

#if UNITY_ANDROID
        public const string DefaultAdmobInterstitialAdUnitId = "ca-app-pub-4497963493005970/6760502553";
#elif UNITY_IPHONE
        public const string DefaultAdmobInterstitialAdUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        public const string DefaultAdmobInterstitialAdUnitId = "unexpected_platform";
#endif

        public VP<string> admobInterstitialAdUnitId;

        #endregion

        #region videoAdUnitId

#if UNITY_ANDROID
        public const string DefaultAdmobVideoAdUnitId = "ca-app-pub-4497963493005970/2294165008";
#elif UNITY_IPHONE
        public const string DefaultAdmobVideoAdUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        public const string DefaultAdmobVideoAdUnitId = "unexpected_platform";
#endif

        public VP<string> admobVideoAdUnitId;

        #endregion

        #region admobVideoType

        public enum AdMobVideoType
        {
            Video,
            Interestial,
            Random
        }

        public VP<AdMobVideoType> admobVideoType;

        #endregion

        ////////////////////////////////////////////////////////////////
        ///////////////////////// Constructor ////////////////////////
        ////////////////////////////////////////////////////////////////

        #region Constructor

        public enum Property
        {
            alreadyBuyAds,
            allowEdit,
            time,
            realTime,

            videoType,
            showBtnViewAds,

            bannerType,
            bannerVisibility,
            prepareBannerVisibility,
            lastClickBanner,
            hideBannerDurationAfterClick,
            hideAdsWhenStartPlay,
            showAdsWhenGameEnd,
            hideAdsWhenGameStart,
            showAdsWhenGamePause,
            hideAdsWhenGameNotPause,

            reloadBannerInterval,
            lastReloadBannerTime,

            unityAdsBannerPlaceMentIds,

            admobAppId,
            admobBannerAdUnitId,
            admobInterstitialAdUnitId,
            admobVideoAdUnitId,
            admobVideoType
        }

        public AdsManager() : base()
        {
            this.alreadyBuyAds = new VP<bool>(this, (byte)Property.alreadyBuyAds, false);
            this.allowEdit = new VP<AllowEdit>(this, (byte)Property.allowEdit, DefaultAllowEdit);
            this.time = new VP<float>(this, (byte)Property.time, 0);
            this.realTime = new VP<long>(this, (byte)Property.realTime, Global.getRealTimeInMiliSeconds());
            this.bannerType = new VP<AdsType>(this, (byte)Property.bannerType, DefaultBannerType);
            // video
            {
                this.videoType = new VP<AdsType>(this, (byte)Property.videoType, DefaultVideoType);
                this.showBtnViewAds = new VP<bool>(this, (byte)Property.showBtnViewAds, true);
            }
            // banner
            {
                this.bannerVisibility = new VP<BannerVisibility>(this, (byte)Property.bannerVisibility, BannerVisibility.Show);
                this.prepareBannerVisibility = new VP<PrepareBannerVisibility>(this, (byte)Property.prepareBannerVisibility, PrepareBannerVisibility.None);
                this.lastClickBanner = new VP<float>(this, (byte)Property.lastClickBanner, float.MinValue);
                this.hideBannerDurationAfterClick = new VP<float>(this, (byte)Property.hideBannerDurationAfterClick, DefaultHideBannerDurationAfterClick);
                this.hideAdsWhenStartPlay = new VP<bool>(this, (byte)Property.hideAdsWhenStartPlay, true);
                this.showAdsWhenGameEnd = new VP<bool>(this, (byte)Property.showAdsWhenGameEnd, true);
                this.hideAdsWhenGameStart = new VP<bool>(this, (byte)Property.hideAdsWhenGameStart, true);
                this.showAdsWhenGamePause = new VP<bool>(this, (byte)Property.showAdsWhenGamePause, true);
                this.hideAdsWhenGameNotPause = new VP<bool>(this, (byte)Property.hideAdsWhenGameNotPause, true);
                // reloadBanner
                {
                    this.reloadBannerInterval = new VP<float>(this, (byte)Property.reloadBannerInterval, DefaultReloadBannerInterval);
                    this.lastReloadBannerTime = new VP<float>(this, (byte)Property.lastReloadBannerTime, 0);
                }
            }
            // unityAds
            {
                this.unityAdsBannerPlaceMentIds = new VP<string>(this, (byte)Property.unityAdsBannerPlaceMentIds, "banner");
            }
            // admob
            {
                this.admobAppId = new VP<string>(this, (byte)Property.admobAppId, DefaultAdmobAppId);
                this.admobBannerAdUnitId = new VP<string>(this, (byte)Property.admobBannerAdUnitId, DefaultAdmobBannerAdUnitId);
                this.admobInterstitialAdUnitId = new VP<string>(this, (byte)Property.admobInterstitialAdUnitId, DefaultAdmobInterstitialAdUnitId);
                this.admobVideoAdUnitId = new VP<string>(this, (byte)Property.admobVideoAdUnitId, DefaultAdmobVideoAdUnitId);
                this.admobVideoType = new VP<AdMobVideoType>(this, (byte)Property.admobVideoType, AdMobVideoType.Random);
            }
        }

        #endregion

        public bool IsSupportFullScreenAds()
        {
            bool ret = false;
            {
                switch (this.videoType.v)
                {
                    case AdsType.None:
                        break;
                    case AdsType.Unity:
                        ret = Advertisement.isSupported;
                        break;
                    case AdsType.Admob:
                        {
#if UNITY_ANDROID
            ret = true;
#elif UNITY_IPHONE
            ret = true;
#else
                            ret = false;
#endif
                        }
                        break;
                    default:
                        Debug.LogError("unknown adsType");
                        break;
                }
            }
            return ret;
        }

        public void showFullScreenAds()
        {
            switch (this.videoType.v)
            {
                case AdsType.None:
                    break;
                case AdsType.Unity:
                    {
                        if (UnityAds.instance != null)
                        {
                            UnityAds.instance.showVideo();
                        }
                        else
                        {
                            Debug.LogError("unityAds instance null");
                        }
                    }
                    break;
                case AdsType.Admob:
                    {
                        if (Admob.instance != null)
                        {
                            Admob.instance.showFullScreenAds();
                        }
                        else
                        {
                            Debug.LogError("admob instance null");
                        }
                    }
                    break;
                default:
                    Debug.LogError("unknown videoType: " + this.videoType.v);
                    break;
            }
        }

    }
}
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

        public const AllowEdit DefaultAllowEdit = AllowEdit.All;

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

        public enum AdsType
        {
            None,
            Unity,
            Admob,
            StartApp
        }

        #region video

        public const AdsType DefaultVideoType = AdsType.Unity;

        public VP<AdsType> videoType;

        public VP<bool> showBtnViewAds;

        #endregion

        #region banner

        public const AdsType DefaultBannerType = AdsType.Admob;

        public VP<AdsType> bannerType;

        public enum BannerVisibility
        {
            Show,
            Hide
        }

        public VP<BannerVisibility> bannerVisibility;

        public VP<float> lastClickBanner;

        public const float DefaultHideBannerDurationAfterClick = 30 * 60 * 60;// 30 minutes
        public VP<float> hideBannerDurationAfterClick;

        public VP<bool> hideAdsWhenStartPlay;

        public VP<bool> showAdsWhenGameEnd;

        #region reloadBanner

        public const float DefaultReloadBannerInterval = 15 * 60 * 60;// 15 minutes

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

        #region admob

#if UNITY_ANDROID
            string DefaultAdmobAppId = "ca-app-pub-3940256099942544~3347511713";
#elif UNITY_IPHONE
            string DefaultAdmobAppId = "ca-app-pub-3940256099942544~1458002511";
#else
        string DefaultAdmobAppId = "unexpected_platform";
#endif

        public VP<string> admobAppId;

#if UNITY_ANDROID
            string DefaultAdmobAdUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            string DefaultAdmobAdUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        string DefaultAdmobAdUnitId = "unexpected_platform";
#endif

        public VP<string> admobAdUnitId;

        #region admobVideoType

        public enum AdMobVideoType
        {
            Video,
            Interestial,
            Random
        }

        public VP<AdMobVideoType> admobVideoType;

        #endregion

        #endregion

        #region Constructor

        public enum Property
        {
            alreadyBuyAds,
            allowEdit,
            time,

            videoType,
            showBtnViewAds,

            bannerType,
            bannerVisibility,
            lastClickBanner,
            hideBannerDurationAfterClick,
            hideAdsWhenStartPlay,
            showAdsWhenGameEnd,

            reloadBannerInterval,
            lastReloadBannerTime,

            unityAdsBannerPlaceMentIds,

            admobAppId,
            admobAdUnitId,
            admobVideoType
        }

        public AdsManager() : base()
        {
            this.alreadyBuyAds = new VP<bool>(this, (byte)Property.alreadyBuyAds, false);
            this.allowEdit = new VP<AllowEdit>(this, (byte)Property.allowEdit, DefaultAllowEdit);
            this.time = new VP<float>(this, (byte)Property.time, 0);
            this.bannerType = new VP<AdsType>(this, (byte)Property.bannerType, DefaultBannerType);
            // video
            {
                this.videoType = new VP<AdsType>(this, (byte)Property.videoType, DefaultVideoType);
                this.showBtnViewAds = new VP<bool>(this, (byte)Property.showBtnViewAds, true);
            }
            // banner
            {
                this.bannerVisibility = new VP<BannerVisibility>(this, (byte)Property.bannerVisibility, BannerVisibility.Show);
                this.lastClickBanner = new VP<float>(this, (byte)Property.lastClickBanner, float.MinValue);
                this.hideBannerDurationAfterClick = new VP<float>(this, (byte)Property.hideBannerDurationAfterClick, DefaultHideBannerDurationAfterClick);
                this.hideAdsWhenStartPlay = new VP<bool>(this, (byte)Property.hideAdsWhenStartPlay, true);
                this.showAdsWhenGameEnd = new VP<bool>(this, (byte)Property.showAdsWhenGameEnd, true);
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
                this.admobAdUnitId = new VP<string>(this, (byte)Property.admobAdUnitId, DefaultAdmobAdUnitId);
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
                    case AdsType.StartApp:
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
                case AdsType.StartApp:
                    {
                        // TODO Can hoan thien
                    }
                    break;
                default:
                    Debug.LogError("unknown videoType: " + this.videoType.v);
                    break;
            }
        }

    }
}
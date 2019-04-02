using UnityEngine;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;

namespace Ads
{
    public class AdsManager : Data
    {

        public static bool testMode = true;

        private static AdsManager adsManager;

        static AdsManager()
        {
            adsManager = new AdsManager();
        }

        public static AdsManager get()
        {
            return adsManager;
        }

        #region adsType

        public enum AdsType
        {
            None,
            RemoveAds,
            Unity,
            Admob,
            StartApp
        }

        public VP<AdsType> showType;

        #endregion

        #region banner

        public enum BannerVisibility
        {
            Show,
            Hide
        }

        public VP<BannerVisibility> bannerVisibility;

        public VP<float> lastClickBanner;

        #endregion

        #region unityAds

        public VP<string> unityAdsBannerPlaceMentIds;

        #endregion

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

        #endregion

        #region Constructor

        public enum Property
        {
            showType,
            bannerVisibility,
            lastClickBanner,

            unityAdsBannerPlaceMentIds,

            admobAppId,
            admobAdUnitId
        }

        public AdsManager() : base()
        {
            this.showType = new VP<AdsType>(this, (byte)Property.showType, AdsType.Unity);
            this.bannerVisibility = new VP<BannerVisibility>(this, (byte)Property.bannerVisibility, BannerVisibility.Show);
            this.lastClickBanner = new VP<float>(this, (byte)Property.lastClickBanner, float.MinValue);
            // unityAds
            {
                this.unityAdsBannerPlaceMentIds = new VP<string>(this, (byte)Property.unityAdsBannerPlaceMentIds, "banner");
            }
            // admob
            {
                this.admobAppId = new VP<string>(this, (byte)Property.admobAppId, DefaultAdmobAppId);
                this.admobAdUnitId = new VP<string>(this, (byte)Property.admobAdUnitId, DefaultAdmobAdUnitId);
            }
        }

        #endregion

        /*public bool isSupportAds()
        {
            bool ret = false;
            {
                switch (this.showType.v)
                {
                    case AdsType.None:
                        break;
                    case AdsType.RemoveAds:
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
        }*/

    }
}
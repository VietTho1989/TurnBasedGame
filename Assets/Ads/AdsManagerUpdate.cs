using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Ads
{
    public class AdsManagerUpdate : MonoBehaviour
    {

        public MainUI mainUI;

        private void Update()
        {
            AdsManager adsManager = AdsManager.get();
            if (adsManager != null)
            {
                // buys
                {
                    if (Global.get().removeAds.v)
                    {
                        AdsManager.get().alreadyBuyAds.v = true;
                        // TODO Co nen dat khong nhi
                        // AdsManager.get().removeAds();
                    }
                }
                // prepareBannerVisibility
                {
                    switch (adsManager.prepareBannerVisibility.v)
                    {
                        case AdsManager.PrepareBannerVisibility.None:
                            break;
                        case AdsManager.PrepareBannerVisibility.Show:
                            adsManager.bannerVisibility.v = AdsManager.BannerVisibility.Show;
                            break;
                        case AdsManager.PrepareBannerVisibility.Hide:
                            adsManager.bannerVisibility.v = AdsManager.BannerVisibility.Hide;
                            break;
                        default:
                            Debug.LogError("unknown prepareBannerVisibility: " + adsManager.prepareBannerVisibility.v);
                            break;
                    }
                    adsManager.prepareBannerVisibility.v = AdsManager.PrepareBannerVisibility.None;
                }
                // time
                {
                    // find
                    long currentRealTime = Global.getRealTimeInMiliSeconds();
                    float deltaTime = Mathf.Max(Time.deltaTime, (currentRealTime - adsManager.realTime.v) / 1000.0f);
                    // set
                    {
                        adsManager.time.v += deltaTime;
                        adsManager.realTime.v = currentRealTime;
                    }
                }
                // bannerVisibility
                {
                    // check visibility after click
                    if (adsManager.time.v - adsManager.lastClickBanner.v < adsManager.hideBannerDurationAfterClick.v)
                    {
                        // hide banner after click
                        adsManager.bannerVisibility.v = AdsManager.BannerVisibility.Hide;
                    }
                    else
                    {
                        // find allowShowBanner
                        MainUI.UIData.AllowShowBanner allowShowBanner = MainUI.UIData.AllowShowBanner.ForceShow;
                        {
                            if (mainUI != null)
                            {
                                if (mainUI.data != null)
                                {
                                    allowShowBanner = mainUI.data.getAllowShowBanner();
                                    // Debug.LogError("allowShowBanner: " + allowShowBanner + ", " + adsManager.bannerVisibility.v);
                                }
                                else
                                {
                                    Debug.LogError("mainUIData null");
                                }
                            }
                            else
                            {
                                Debug.LogError("mainUI null");
                            }
                        }
                        // process
                        switch (allowShowBanner)
                        {
                            case MainUI.UIData.AllowShowBanner.ForceShow:
                                {
                                    adsManager.bannerVisibility.v = AdsManager.BannerVisibility.Show;
                                }
                                break;
                            case MainUI.UIData.AllowShowBanner.ForceHide:
                                {
                                    adsManager.bannerVisibility.v = AdsManager.BannerVisibility.Hide;
                                }
                                break;
                            case MainUI.UIData.AllowShowBanner.StatusQuo:
                                break;
                            default:
                                Debug.LogError("unknown allowShowBanner: " + allowShowBanner);
                                break;
                        }
                    }
                }
                // reloadBanner
                {
                    if(adsManager.bannerVisibility.v== AdsManager.BannerVisibility.Show)
                    {
                        // find need reload banner
                        bool needReloadBanner = false;
                        {
                            if (adsManager.reloadBannerInterval.v > 0)
                            {
                                if (adsManager.time.v - adsManager.lastReloadBannerTime.v >= adsManager.reloadBannerInterval.v)
                                {
                                    needReloadBanner = true;
                                    adsManager.lastReloadBannerTime.v = adsManager.time.v;
                                }
                            }
                            else
                            {
                                // Ko can reload banner
                            }
                        }
                        // process
                        if (needReloadBanner)
                        {
                            Debug.LogError("needReloadBanner");
                            switch (adsManager.bannerType.v)
                            {
                                case AdsManager.AdsType.None:
                                    break;
                                case AdsManager.AdsType.Unity:
                                    {
                                        if (UnityAds.instance != null)
                                        {
                                            UnityAds.instance.reloadBanner();
                                        }
                                        else
                                        {
                                            Debug.LogError("unityAds instance null");
                                        }
                                    }
                                    break;
                                case AdsManager.AdsType.Admob:
                                    {
                                        if (Admob.instance != null)
                                        {
                                            Admob.instance.reloadBanner();
                                        }
                                        else
                                        {
                                            Debug.LogError("admob instance null");
                                        }
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown showType: " + adsManager.bannerType.v);
                                    break;
                            }
                        }
                    }
                }
            }
            else
            {
                Debug.LogError("adsManager null");
            }
        }

    }
}
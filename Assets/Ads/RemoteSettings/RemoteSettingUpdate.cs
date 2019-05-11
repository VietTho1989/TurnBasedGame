using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Ads;

public class RemoteSettingUpdate : MonoBehaviour
{

    private void Start()
    {
        RemoteSettings.Completed += RemoteSettingsUpdateCompleted;
        /*RemoteSettings.Updated += new RemoteSettings.UpdatedEventHandler(HandleRemoteSettingsUpdate);
        HandleRemoteSettingsUpdate();*/
    }

    private void RemoteSettingsUpdateCompleted(bool wasUpdatedFromServer, bool settingsChanged, int serverResponse)
    {
        Debug.LogError("RemoteSettingsUpdateCompleted: " + wasUpdatedFromServer + ", " + settingsChanged + ", " + serverResponse);
        HandleRemoteSettingsUpdate();
    }

    private void HandleRemoteSettingsUpdate()
    {
        Debug.LogError("Handle remote setting update");
        System.Random random = new System.Random();
        // adsManager
        {
            // allowEdit
            {
                AdsManager.AllowEdit allowEdit = AdsManager.DefaultAllowEdit;
                {
                    int adsAllowEdit = RemoteSettings.GetInt("AdsAllowEdit", (int)AdsManager.DefaultAllowEdit);
                    switch (adsAllowEdit)
                    {
                        case (int)AdsManager.AllowEdit.None:
                            allowEdit = AdsManager.AllowEdit.None;
                            break;
                        case (int)AdsManager.AllowEdit.OnlyBuyer:
                            allowEdit = AdsManager.AllowEdit.OnlyBuyer;
                            break;
                        case (int)AdsManager.AllowEdit.All:
                            allowEdit = AdsManager.AllowEdit.All;
                            break;
                        default:
                            Debug.LogError("unknown adsAllowEdit");
                            break;
                    }
                }
                AdsManager.get().allowEdit.v = allowEdit;
            }
            // videoType
            {
                AdsManager.AdsType videoType = AdsManager.DefaultVideoType;
                {
                    if (!Global.get().removeAds.v)
                    {
                        // get dictionary
                        Dictionary<AdsManager.AdsType, int> adsValueDict = new Dictionary<AdsManager.AdsType, int>();
                        int sum = 0;
                        {
                            // unity
                            {
                                int adsValue = RemoteSettings.GetInt("AdsVideoTypeUnity", 1);
                                if (adsValue > 0)
                                {
                                    adsValueDict.Add(AdsManager.AdsType.Unity, adsValue);
                                    sum += adsValue;
                                }
                            }
                            // admob
                            {
                                int adsValue = RemoteSettings.GetInt("AdsVideoTypeAdmob", 0);
                                if (adsValue > 0)
                                {
                                    adsValueDict.Add(AdsManager.AdsType.Admob, adsValue);
                                    sum += adsValue;
                                }
                            }
                        }
                        // process
                        if (adsValueDict.Keys.Count > 0)
                        {
                            int index = random.Next(sum);
                            foreach (AdsManager.AdsType adsType in adsValueDict.Keys)
                            {
                                int adsValue = adsValueDict[adsType];
                                if (index < adsValue)
                                {
                                    videoType = adsType;
                                    break;
                                }
                                else
                                {
                                    index -= adsValue;
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("Don't show any videoType");
                            videoType = AdsManager.AdsType.None;
                        }
                    }
                    else
                    {
                        Debug.LogError("removeAds, so not show");
                        videoType = AdsManager.AdsType.None;
                    }
                }
                AdsManager.get().videoType.v = videoType;
            }
            // showBtnViewAds
            {
                // Debug.LogError("showBtnViewAds: hasKey: " + RemoteSettings.HasKey("AdsShowBtnViewAds"));
                bool showBtnViewAds = RemoteSettings.GetBool("AdsShowBtnViewAds", true);
                AdsManager.get().showBtnViewAds.v = showBtnViewAds;
            }
            // bannerType
            {
                AdsManager.AdsType bannerType = AdsManager.DefaultBannerType;
                {
                    if (!Global.get().removeAds.v)
                    {
                        // get dictionary
                        Dictionary<AdsManager.AdsType, int> adsValueDict = new Dictionary<AdsManager.AdsType, int>();
                        int sum = 0;
                        {
                            // unity
                            {
                                int adsValue = RemoteSettings.GetInt("AdsBannerTypeUnity", 0);
                                if (adsValue > 0)
                                {
                                    adsValueDict.Add(AdsManager.AdsType.Unity, adsValue);
                                    sum += adsValue;
                                }
                            }
                            // admob
                            {
                                int adsValue = RemoteSettings.GetInt("AdsBannerTypeAdmob", 1);
                                if (adsValue > 0)
                                {
                                    adsValueDict.Add(AdsManager.AdsType.Admob, adsValue);
                                    sum += adsValue;
                                }
                            }
                        }
                        // process
                        if (adsValueDict.Keys.Count > 0)
                        {
                            int index = random.Next(sum);
                            foreach (AdsManager.AdsType adsType in adsValueDict.Keys)
                            {
                                int adsValue = adsValueDict[adsType];
                                if (index < adsValue)
                                {
                                    bannerType = adsType;
                                    break;
                                }
                                else
                                {
                                    index -= adsValue;
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("Don't show any bannerType");
                            bannerType = AdsManager.AdsType.None;
                        }
                    }
                    else
                    {
                        Debug.LogError("removeAds, so not show banner");
                        bannerType = AdsManager.AdsType.None;
                    }
                }
                AdsManager.get().bannerType.v = bannerType;
            }
            // hideBannerDurationAfterClick
            {
                float hideBannerDurationAfterClick = RemoteSettings.GetFloat("AdsHideBannerDurationAfterClick", AdsManager.DefaultHideBannerDurationAfterClick);
                AdsManager.get().hideBannerDurationAfterClick.v = hideBannerDurationAfterClick;
            }
            // hideAdsWhenStartPlay
            {
                bool hideAdsWhenStartPlay = RemoteSettings.GetBool("AdsHideAdsWhenStartPlay", true);
                AdsManager.get().hideAdsWhenStartPlay.v = hideAdsWhenStartPlay;
            }
            // showAdsWhenGameEnd
            {
                bool showAdsWhenGameEnd = RemoteSettings.GetBool("AdsShowAdsWhenGameEnd", true);
                AdsManager.get().showAdsWhenGameEnd.v = showAdsWhenGameEnd;
            }
            // hideAdsWhenGameStart
            {
                bool hideAdsWhenGameStart = RemoteSettings.GetBool("AdsHideAdsWhenGameStart", true);
                AdsManager.get().hideAdsWhenGameStart.v = hideAdsWhenGameStart;
            }
            // showAdsWhenGamePause
            {
                bool showAdsWhenGamePause = RemoteSettings.GetBool("AdsShowAdsWhenGamePause", true);
                AdsManager.get().showAdsWhenGamePause.v = showAdsWhenGamePause;
            }
            // hideAdsWhenGameNotPause
            {
                bool hideAdsWhenGameNotPause = RemoteSettings.GetBool("AdsHideAdsWhenGameNotPause", true);
                AdsManager.get().hideAdsWhenGameNotPause.v = hideAdsWhenGameNotPause;
            }
            // reloadBannerInterval
            {
                float reloadBannerInterval = RemoteSettings.GetFloat("AdsReloadBannerInterval", AdsManager.DefaultReloadBannerInterval);
                AdsManager.get().reloadBannerInterval.v = reloadBannerInterval;
            }

            // unityAdsBannerPlaceMentIds
            {
                string unityAdsBannerPlaceMentIds = RemoteSettings.GetString("AdsUnityAdsBannerPlaceMentIds", "banner");
                AdsManager.get().unityAdsBannerPlaceMentIds.v = unityAdsBannerPlaceMentIds;
            }

            // admobAppId
            {
                string admobAppId = AdsManager.DefaultAdmobAppId;
                {
#if UNITY_ANDROID
                    admobAppId = RemoteSettings.GetString("AdsAdmobAppIdAndroid", AdsManager.DefaultAdmobAppId);
#elif UNITY_IPHONE
                    admobAppId = RemoteSettings.GetString("AdsAdmobAppIdIOS", AdsManager.DefaultAdmobAppId);
#endif
                }
                AdsManager.get().admobAppId.v = admobAppId;
            }
            // admobBannerAdUnitId
            {
                string admobBannerAdUnitId = AdsManager.DefaultAdmobBannerAdUnitId;
                {
#if UNITY_ANDROID
                    admobBannerAdUnitId = RemoteSettings.GetString("AdsAdmobBannerAdUnitIdAndroid", AdsManager.DefaultAdmobBannerAdUnitId);
#elif UNITY_IPHONE
                    admobBannerAdUnitId = RemoteSettings.GetString("AdsAdmobBannerAdUnitIdIOS", AdsManager.DefaultAdmobBannerAdUnitId);
#endif
                }
                AdsManager.get().admobBannerAdUnitId.v = admobBannerAdUnitId;
            }
            // admobInterstitialAdUnitId
            {
                string admobInterstitialAdUnitId = AdsManager.DefaultAdmobInterstitialAdUnitId;
                {
#if UNITY_ANDROID
                    admobInterstitialAdUnitId = RemoteSettings.GetString("AdsAdmobInterstitialAdUnitIdAndroid", AdsManager.DefaultAdmobInterstitialAdUnitId);
#elif UNITY_IPHONE
                    admobInterstitialAdUnitId = RemoteSettings.GetString("AdsAdmobInterstitialAdUnitIdIOS", AdsManager.DefaultAdmobInterstitialAdUnitId);
#endif
                }
                AdsManager.get().admobInterstitialAdUnitId.v = admobInterstitialAdUnitId;
            }
            // admobVideoAdUnitId
            {
                string admobVideoAdUnitId = AdsManager.DefaultAdmobVideoAdUnitId;
                {
#if UNITY_ANDROID
                    admobVideoAdUnitId = RemoteSettings.GetString("AdsAdmobVideoAdUnitIdAndroid", AdsManager.DefaultAdmobVideoAdUnitId);
#elif UNITY_IPHONE
                    admobVideoAdUnitId = RemoteSettings.GetString("AdsAdmobVideoAdUnitIdIOS", AdsManager.DefaultAdmobVideoAdUnitId);
#endif
                }
                AdsManager.get().admobVideoAdUnitId.v = admobVideoAdUnitId;
            }
            // admobVideoType
            {
                AdsManager.AdMobVideoType adMobVideoType = AdsManager.AdMobVideoType.Random;
                {
                    int adsAdmobVideoType = RemoteSettings.GetInt("AdsAdmobVideoType", (int)AdsManager.AdMobVideoType.Random);
                    switch (adsAdmobVideoType)
                    {
                        case (int)AdsManager.AdMobVideoType.Video:
                            adMobVideoType = AdsManager.AdMobVideoType.Video;
                            break;
                        case (int)AdsManager.AdMobVideoType.Interestial:
                            adMobVideoType = AdsManager.AdMobVideoType.Interestial;
                            break;
                        case (int)AdsManager.AdMobVideoType.Random:
                            adMobVideoType = AdsManager.AdMobVideoType.Random;
                            break;
                        default:
                            Debug.LogError("unknown adsAdmobVideoType: " + adsAdmobVideoType);
                            break;
                    }
                }
                AdsManager.get().admobVideoType.v = adMobVideoType;
            }

            // serverMessage
            {
                string serverMessage = RemoteSettings.GetString("ServerMessage", "");
                Global.get().serverMessage.v = serverMessage;
            }
            // website
            {
                string website = RemoteSettings.GetString("Website", Global.DefaultWebsite);
                Global.get().website.v = website;
            }
            // oldVersions
            {
                string oldVersions = RemoteSettings.GetString("OldVersions", Global.DefaultOldVersions);
                Global.get().oldVersions.v = oldVersions;
            }
            // openSource
            {
                string openSource = RemoteSettings.GetString("OpenSource", Global.DefaultOpenSource);
                Global.get().openSource.v = openSource;
            }

            // canPlayOnline
            {
                bool canPlayOnline = RemoteSettings.GetBool("CanPlayOnline", Global.DefaultCanPlayOnline);
                Global.get().canPlayOnline.v = canPlayOnline;
            }
            // serverAddress
            {
                string serverAddress = RemoteSettings.GetString("ServerAddress", Global.DefaultServerAddress);
                Global.get().serverAddress.v = serverAddress;
            }
            // serverPort
            {
                int serverPort = RemoteSettings.GetInt("ServerPort", Global.DefaultServerPort);
                Global.get().serverPort.v = serverPort;
            }
        }
    }

}
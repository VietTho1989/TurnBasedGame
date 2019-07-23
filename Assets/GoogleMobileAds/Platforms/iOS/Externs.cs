// Copyright (C) 2015 Google, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#if UNITY_IOS

using System;
using System.Runtime.InteropServices;

namespace GoogleMobileAds.iOS
{
    // Externs used by the iOS component.
    internal class Externs
    {
        #region Common externs

        [DllImport("__Internal")]
        internal static extern void GADUInitialize(string key);

        [DllImport("__Internal")]
        internal static extern void GADUInitializeWithCallback(
            IntPtr mobileAdsClient, MobileAdsClient.GADUInitializationCompleteCallback callback);

        [DllImport("__Internal")]
        internal static extern IntPtr GADUGetInitDescription(IntPtr status, string className);

        [DllImport("__Internal")]
        internal static extern int GADUGetInitLatency(IntPtr status, string className);

        [DllImport("__Internal")]
        internal static extern int GADUGetInitState(IntPtr status, string className);

        [DllImport("__Internal")]
        internal static extern IntPtr GADUGetInitAdapterClasses(IntPtr status);

        [DllImport("__Internal")]
        internal static extern int GADUGetInitNumberOfAdapterClasses(IntPtr status);


        [DllImport("__Internal")]
        internal static extern void GADUSetApplicationVolume(float volume);

        [DllImport("__Internal")]
        internal static extern void GADUSetApplicationMuted(bool muted);

        [DllImport("__Internal")]
        internal static extern void GADUSetiOSAppPauseOnBackground(bool pause);

        [DllImport("__Internal")]
        internal static extern float GADUDeviceScale();

        [DllImport("__Internal")]
        internal static extern IntPtr GADUCreateRequest();

        [DllImport("__Internal")]
        internal static extern IntPtr GADUCreateMutableDictionary();

        [DllImport("__Internal")]
        internal static extern void GADUMutableDictionarySetValue(
            IntPtr mutableDictionaryPtr,
            string key,
            string value);

        [DllImport("__Internal")]
        internal static extern void GADUSetMediationExtras(
            IntPtr request,
            IntPtr mutableDictionaryPtr,
            string adNetworkExtrasClassName);

        [DllImport("__Internal")]
        internal static extern void GADUAddTestDevice(IntPtr request, string deviceId);

        [DllImport("__Internal")]
        internal static extern void GADUAddKeyword(IntPtr request, string keyword);

        [DllImport("__Internal")]
        internal static extern void GADUSetBirthday(IntPtr request, int year, int month, int day);

        [DllImport("__Internal")]
        internal static extern void GADUSetGender(IntPtr request, int genderCode);

        [DllImport("__Internal")]
        internal static extern void GADUTagForChildDirectedTreatment(
            IntPtr request, bool childDirectedTreatment);

        [DllImport("__Internal")]
        internal static extern void GADUSetExtra(IntPtr request, string key, string value);

        [DllImport("__Internal")]
        internal static extern void GADUSetRequestAgent(IntPtr request, string requestAgent);

        [DllImport("__Internal")]
        internal static extern void GADURelease(IntPtr obj);

        #endregion

        #region Banner externs

        [DllImport("__Internal")]
        internal static extern IntPtr GADUCreateBannerView(
            IntPtr bannerClient, string adUnitId, int width, int height, int positionAtTop);

        [DllImport("__Internal")]
        internal static extern IntPtr GADUCreateBannerViewWithCustomPosition(
            IntPtr bannerClient,
            string adUnitId,
            int width,
            int height,
            int x,
            int y);

        [DllImport("__Internal")]
        internal static extern IntPtr GADUCreateSmartBannerView(
            IntPtr bannerClient, string adUnitId, int positionAtTop);

        [DllImport("__Internal")]
        internal static extern IntPtr GADUCreateSmartBannerViewWithCustomPosition(
            IntPtr bannerClient, string adUnitId, int x, int y);
        [DllImport("__Internal")]
        internal static extern void GADUSetBannerCallbacks(
            IntPtr bannerView,
            BannerClient.GADUAdViewDidReceiveAdCallback adReceivedCallback,
            BannerClient.GADUAdViewDidFailToReceiveAdWithErrorCallback adFailedCallback,
            BannerClient.GADUAdViewWillPresentScreenCallback willPresentCallback,
            BannerClient.GADUAdViewDidDismissScreenCallback didDismissCallback,
            BannerClient.GADUAdViewWillLeaveApplicationCallback willLeaveCallback);

        [DllImport("__Internal")]
        internal static extern void GADUHideBannerView(IntPtr bannerView);

        [DllImport("__Internal")]
        internal static extern void GADUShowBannerView(IntPtr bannerView);

        [DllImport("__Internal")]
        internal static extern void GADURemoveBannerView(IntPtr bannerView);

        [DllImport("__Internal")]
        internal static extern void GADURequestBannerAd(IntPtr bannerView, IntPtr request);

        [DllImport("__Internal")]
        internal static extern float GADUGetBannerViewHeightInPixels(IntPtr bannerView);

        [DllImport("__Internal")]
        internal static extern float GADUGetBannerViewWidthInPixels(IntPtr bannerView);

        [DllImport("__Internal")]
        internal static extern void GADUSetBannerViewAdPosition(IntPtr bannerView, int position);

        [DllImport("__Internal")]
        internal static extern void GADUSetBannerViewCustomPosition(IntPtr bannerView, int x, int y);

        [DllImport("__Internal")]
        internal static extern IntPtr GADUMediationAdapterClassNameForBannerView(IntPtr bannerView);

        #endregion

        #region Interstitial externs

        [DllImport("__Internal")]
        internal static extern IntPtr GADUCreateInterstitial(
            IntPtr interstitialClient, string adUnitId);

        [DllImport("__Internal")]
        internal static extern void GADUSetInterstitialCallbacks(
            IntPtr interstitial,
            InterstitialClient.GADUInterstitialDidReceiveAdCallback adReceivedCallback,
            InterstitialClient.GADUInterstitialDidFailToReceiveAdWithErrorCallback
                        adFailedCallback,
            InterstitialClient.GADUInterstitialWillPresentScreenCallback willPresentCallback,
            InterstitialClient.GADUInterstitialDidDismissScreenCallback didDismissCallback,
            InterstitialClient.GADUInterstitialWillLeaveApplicationCallback
                        willLeaveCallback);

        [DllImport("__Internal")]
        internal static extern bool GADUInterstitialReady(IntPtr interstitial);

        [DllImport("__Internal")]
        internal static extern void GADUShowInterstitial(IntPtr interstitial);

        [DllImport("__Internal")]
        internal static extern void GADURequestInterstitial(IntPtr interstitial, IntPtr request);

        [DllImport("__Internal")]
        internal static extern IntPtr GADUMediationAdapterClassNameForInterstitial(IntPtr interstitial);

        #endregion

        #region Reward based video externs

        [DllImport("__Internal")]
        internal static extern IntPtr GADUCreateRewardBasedVideoAd(IntPtr rewardBasedVideo);

        [DllImport("__Internal")]
        internal static extern bool GADURewardBasedVideoAdReady(IntPtr rewardBasedVideo);

        [DllImport("__Internal")]
        internal static extern void GADUShowRewardBasedVideoAd(IntPtr rewardBasedVideo);

        [DllImport("__Internal")]
        internal static extern void GADUSetRewardBasedVideoAdUserId(IntPtr rewardBasedVideo, string userId);

        [DllImport("__Internal")]
        internal static extern void GADURequestRewardBasedVideoAd(
            IntPtr bannerView, IntPtr request, string adUnitId);

        [DllImport("__Internal")]
        internal static extern void GADUSetRewardBasedVideoAdCallbacks(
            IntPtr rewardBasedVideo,
            RewardBasedVideoAdClient.GADURewardBasedVideoAdDidReceiveAdCallback
                    adReceivedCallback,
            RewardBasedVideoAdClient.GADURewardBasedVideoAdDidFailToReceiveAdWithErrorCallback
                    adFailedCallback,
            RewardBasedVideoAdClient.GADURewardBasedVideoAdDidOpenCallback didOpenCallback,
            RewardBasedVideoAdClient.GADURewardBasedVideoAdDidStartCallback didStartCallback,
            RewardBasedVideoAdClient.GADURewardBasedVideoAdDidCloseCallback didCloseCallback,
            RewardBasedVideoAdClient.GADURewardBasedVideoAdDidRewardCallback didRewardcallback,
            RewardBasedVideoAdClient.GADURewardBasedVideoAdWillLeaveApplicationCallback
                    willLeaveCallback,
            RewardBasedVideoAdClient.GADURewardBasedVideoAdDidCompleteCallback didCompleteCallback);

        [DllImport("__Internal")]
        internal static extern IntPtr GADUMediationAdapterClassNameForRewardedVideo(IntPtr rewardedVideo);

        #endregion

        #region RewardedAd externs

        [DllImport("__Internal")]
        internal static extern IntPtr GADUCreateRewardedAd(IntPtr rewardedAd, string adUnitId);

        [DllImport("__Internal")]
        internal static extern bool GADURewardedAdReady(IntPtr rewardedAd);

        [DllImport("__Internal")]
        internal static extern void GADUShowRewardedAd(IntPtr rewardedAd);

        [DllImport("__Internal")]
        internal static extern void GADURequestRewardedAd(
            IntPtr rewardedAd, IntPtr request);

        [DllImport("__Internal")]
        internal static extern void GADUSetRewardedAdCallbacks(
            IntPtr rewardedAd,
            RewardedAdClient.GADURewardedAdDidReceiveAdCallback
                    adReceivedCallback,
            RewardedAdClient.GADURewardedAdDidFailToReceiveAdWithErrorCallback
                    adFailedToLoadCallback,
            RewardedAdClient.GADURewardedAdDidFailToShowAdWithErrorCallback
                    adFailedToShowCallback,
            RewardedAdClient.GADURewardedAdDidOpenCallback didOpenCallback,
            RewardedAdClient.GADURewardedAdDidCloseCallback didCloseCallback,
            RewardedAdClient.GADUUserEarnedRewardCallback userEarnedRewardCallback);

        [DllImport("__Internal")]
        internal static extern IntPtr GADUCreateServerSideVerificationOptions();

        [DllImport("__Internal")]
        internal static extern void GADUServerSideVerificationOptionsSetUserId(IntPtr options, string userId);

        [DllImport("__Internal")]
        internal static extern void GADUServerSideVerificationOptionsSetCustomRewardString(IntPtr options, string customRewardString);

        [DllImport("__Internal")]
        internal static extern void GADURewardedAdSetServerSideVerificationOptions(IntPtr rewardedAd, IntPtr options);

        [DllImport("__Internal")]
        internal static extern IntPtr GADUMediationAdapterClassNameForRewardedAd(IntPtr rewardedVideo);

        #endregion

        #region AdLoader externs

        [DllImport("__Internal")]
        internal static extern IntPtr GADUCreateAdLoader(
            IntPtr adLoader,
            string adUnitId,
            string[] templateIds,
            int templateIdsCount,
            ref NativeAdTypes types,
            bool returnUrlsForImageAssets);

        [DllImport("__Internal")]
        internal static extern void GADURequestNativeAd(IntPtr adLoader, IntPtr request);

        [DllImport("__Internal")]
        internal static extern void GADUSetAdLoaderCallbacks(
            IntPtr adLoader,
            AdLoaderClient.GADUAdLoaderDidReceiveNativeCustomTemplateAdCallback adReceivedCallback,
            AdLoaderClient.GADUAdLoaderDidFailToReceiveAdWithErrorCallback adFailedCallback);

        #endregion

        #region NativeCustomTemplateAd externs

        [DllImport("__Internal")]
        internal static extern string GADUNativeCustomTemplateAdTemplateID(
            IntPtr nativeCustomTemplateAd);

        [DllImport("__Internal")]
        internal static extern string GADUNativeCustomTemplateAdImageAsBytesForKey(
            IntPtr nativeCustomTemplateAd, string key);

        [DllImport("__Internal")]
        internal static extern string GADUNativeCustomTemplateAdStringForKey(
            IntPtr nativeCustomTemplateAd, string key);

        [DllImport("__Internal")]
        internal static extern void GADUNativeCustomTemplateAdRecordImpression(
            IntPtr nativeCustomTemplateAd);

        [DllImport("__Internal")]
        internal static extern void GADUNativeCustomTemplateAdPerformClickOnAssetWithKey(
            IntPtr nativeCustomTemplateAd, string assetName, bool customClickAction);

        [DllImport("__Internal")]
        internal static extern IntPtr GADUNativeCustomTemplateAdAvailableAssetKeys(
            IntPtr nativeCustomTemplateAd);

        [DllImport("__Internal")]
        internal static extern int GADUNativeCustomTemplateAdNumberOfAvailableAssetKeys(
            IntPtr nativeCustomTemplateAd);

        [DllImport("__Internal")]
        internal static extern void GADUSetNativeCustomTemplateAdUnityClient(
            IntPtr nativeCustomTemplateAd, IntPtr nativeCustomTemplateClient);

        [DllImport("__Internal")]
        internal static extern void GADUSetNativeCustomTemplateAdCallbacks(
            IntPtr nativeCustomTemplateAd,
            CustomNativeTemplateClient.GADUNativeCustomTemplateDidReceiveClick
                    adClickedCallback);

        #endregion
    }
}

#endif

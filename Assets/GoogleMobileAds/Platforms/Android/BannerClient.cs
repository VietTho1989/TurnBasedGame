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

#if UNITY_ANDROID

using System;

using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
    public class BannerClient : AndroidJavaProxy, IBannerClient
    {
        private AndroidJavaObject bannerView;

        public BannerClient() : base(Utils.UnityAdListenerClassName)
        {
            AndroidJavaClass playerClass = new AndroidJavaClass(Utils.UnityActivityClassName);
            AndroidJavaObject activity =
                    playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            this.bannerView = new AndroidJavaObject(
                Utils.BannerViewClassName, activity, this);
        }

        public event EventHandler<EventArgs> OnAdLoaded;

        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

        public event EventHandler<EventArgs> OnAdOpening;

        public event EventHandler<EventArgs> OnAdClosed;

        public event EventHandler<EventArgs> OnAdLeavingApplication;

        // Creates a banner view.
        public void CreateBannerView(string adUnitId, AdSize adSize, AdPosition position)
        {
            this.bannerView.Call(
                    "create",
                    new object[3] { adUnitId, Utils.GetAdSizeJavaObject(adSize), (int)position });
        }

        // Creates a banner view with a custom position.
        public void CreateBannerView(string adUnitId, AdSize adSize, int x, int y)
        {
            this.bannerView.Call(
                "create",
                new object[4] { adUnitId, Utils.GetAdSizeJavaObject(adSize), x, y });
        }

        // Loads an ad.
        public void LoadAd(AdRequest request)
        {
            this.bannerView.Call("loadAd", Utils.GetAdRequestJavaObject(request));
        }

        // Displays the banner view on the screen.
        public void ShowBannerView()
        {
            this.bannerView.Call("show");
        }

        // Hides the banner view from the screen.
        public void HideBannerView()
        {
            this.bannerView.Call("hide");
        }

        // Destroys the banner view.
        public void DestroyBannerView()
        {
            this.bannerView.Call("destroy");
        }

        // Returns the height of the BannerView in pixels.
        public float GetHeightInPixels()
        {
            return this.bannerView.Call<float>("getHeightInPixels");
        }

        // Returns the width of the BannerView in pixels.
        public float GetWidthInPixels()
        {
            return this.bannerView.Call<float>("getWidthInPixels");
        }

        // Set the position of the banner view using standard position.
        public void SetPosition(AdPosition adPosition)
        {
            this.bannerView.Call("setPosition", (int)adPosition);
        }

        // Set the position of the banner view using custom position.
        public void SetPosition(int x, int y)
        {
            this.bannerView.Call("setPosition", x, y);
        }

        // Returns the mediation adapter class name.
        public string MediationAdapterClassName()
        {
            return this.bannerView.Call<string>("getMediationAdapterClassName");
        }

#region Callbacks from UnityBannerAdListener.

        public void onAdLoaded()
        {
            if (this.OnAdLoaded != null)
            {
                this.OnAdLoaded(this, EventArgs.Empty);
            }
        }

        public void onAdFailedToLoad(string errorReason)
        {
            if (this.OnAdFailedToLoad != null)
            {
                AdFailedToLoadEventArgs args = new AdFailedToLoadEventArgs()
                {
                    Message = errorReason
                };
                this.OnAdFailedToLoad(this, args);
            }
        }

        public void onAdOpened()
        {
            if (this.OnAdOpening != null)
            {
                this.OnAdOpening(this, EventArgs.Empty);
            }
        }

        public void onAdClosed()
        {
            if (this.OnAdClosed != null)
            {
                this.OnAdClosed(this, EventArgs.Empty);
            }
        }

        public void onAdLeftApplication()
        {
            if (this.OnAdLeavingApplication != null)
            {
                this.OnAdLeavingApplication(this, EventArgs.Empty);
            }
        }

#endregion
    }
}

#endif

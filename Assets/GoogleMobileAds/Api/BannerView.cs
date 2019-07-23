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

using System;

using GoogleMobileAds.Common;

namespace GoogleMobileAds.Api
{
    public class BannerView
    {
        private IBannerClient client;

        // Creates a BannerView and adds it to the view hierarchy.
        public BannerView(string adUnitId, AdSize adSize, AdPosition position)
        {
            this.client = GoogleMobileAdsClientFactory.BuildBannerClient();
            client.CreateBannerView(adUnitId, adSize, position);

            ConfigureBannerEvents();
        }

        // Creates a BannerView with a custom position.
        public BannerView(string adUnitId, AdSize adSize, int x, int y)
        {
            this.client = GoogleMobileAdsClientFactory.BuildBannerClient();
            client.CreateBannerView(adUnitId, adSize, x, y);

            ConfigureBannerEvents();
        }

        // These are the ad callback events that can be hooked into.
        public event EventHandler<EventArgs> OnAdLoaded;

        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

        public event EventHandler<EventArgs> OnAdOpening;

        public event EventHandler<EventArgs> OnAdClosed;

        public event EventHandler<EventArgs> OnAdLeavingApplication;

        // Loads an ad into the BannerView.
        public void LoadAd(AdRequest request)
        {
            client.LoadAd(request);
        }

        // Hides the BannerView from the screen.
        public void Hide()
        {
            client.HideBannerView();
        }

        // Shows the BannerView on the screen.
        public void Show()
        {
            client.ShowBannerView();
        }

        // Destroys the BannerView.
        public void Destroy()
        {
            client.DestroyBannerView();
        }

        // Returns the height of the BannerView in pixels.
        public float GetHeightInPixels()
        {
            return client.GetHeightInPixels();
        }

        // Returns the width of the BannerView in pixels.
        public float GetWidthInPixels()
        {
            return client.GetWidthInPixels();
        }

        // Set the position of the BannerView using standard position.
        public void SetPosition(AdPosition adPosition)
        {
            client.SetPosition(adPosition);
        }

        // Set the position of the BannerView using custom position.
        public void SetPosition(int x, int y)
        {
            client.SetPosition(x, y);
        }

        private void ConfigureBannerEvents()
        {
            this.client.OnAdLoaded += (sender, args) =>
            {
                if (this.OnAdLoaded != null)
                {
                    this.OnAdLoaded(this, args);
                }
            };

            this.client.OnAdFailedToLoad += (sender, args) =>
            {
                if (this.OnAdFailedToLoad != null)
                {
                    this.OnAdFailedToLoad(this, args);
                }
            };

            this.client.OnAdOpening += (sender, args) =>
            {
                if (this.OnAdOpening != null)
                {
                    this.OnAdOpening(this, args);
                }
            };

            this.client.OnAdClosed += (sender, args) =>
            {
                if (this.OnAdClosed != null)
                {
                    this.OnAdClosed(this, args);
                }
            };

            this.client.OnAdLeavingApplication += (sender, args) =>
            {
                if (this.OnAdLeavingApplication != null)
                {
                    this.OnAdLeavingApplication(this, args);
                }
            };
        }

        // Returns the mediation adapter class name.
        public string MediationAdapterClassName()
        {
            return this.client.MediationAdapterClassName();
        }
    }
}

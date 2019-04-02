using UnityEngine;
using GoogleMobileAds.Api;

public class admobdemo : MonoBehaviour
{

    private BannerView bannerView;

    public void Start()
    {
#if UNITY_ANDROID
            string appId = "ca-app-pub-3940256099942544~3347511713";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
#else
        string appId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        this.RequestBanner();
    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        // AdSize adSize = new AdSize(320, 50);
        // bannerView = new BannerView(adUnitId, AdSize.SmartBanner, 0, 0);
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    void Update()
    {
        /*if (bannerView != null)
        {
            bannerView.SetPosition(0, (int)(Screen.height - bannerView.GetHeightInPixels()));
            // Debug.LogError("bannerView: " + bannerView.GetWidthInPixels() + ", " + bannerView.GetHeightInPixels());
        }
        else
        {
            Debug.LogError("bannerView null");
        }*/
    }

}
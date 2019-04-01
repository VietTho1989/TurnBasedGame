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
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    /*Admob ad;
    string appID = "";
    string bannerID = "";
    string interstitialID = "";
    string videoID = "";
    string nativeBannerID = "";

    void Start()
    {
        Debug.Log("start unity demo-------------");
        initAdmob();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log(KeyCode.Escape + "-----------------");
        }
    }

    void initAdmob()
    {
#if UNITY_IOS
                 appID="ca-app-pub-3940256099942544~1458002511";
                 bannerID="ca-app-pub-3940256099942544/2934735716";
                 interstitialID="ca-app-pub-3940256099942544/4411468910";
                 videoID="ca-app-pub-3940256099942544/1712485313";
                 nativeBannerID = "ca-app-pub-3940256099942544/3986624511";
#elif UNITY_ANDROID
                 appID="ca-app-pub-3940256099942544~3347511713";
                 bannerID="ca-app-pub-3940256099942544/6300978111";
                 interstitialID="ca-app-pub-3940256099942544/1033173712";
                 videoID="ca-app-pub-3940256099942544/5224354917";
                 nativeBannerID = "ca-app-pub-3940256099942544/2247696110";
#endif
        AdProperties adProperties = new AdProperties();
        adProperties.isTesting = true;

        ad = Admob.Instance();
        ad.bannerEventHandler += onBannerEvent;
        ad.interstitialEventHandler += onInterstitialEvent;
        ad.rewardedVideoEventHandler += onRewardedVideoEvent;
        ad.nativeBannerEventHandler += onNativeBannerEvent;
        ad.initSDK(appID, adProperties);//reqired,adProperties can been null
    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(120, 0, 100, 60), "showInterstitial"))
        {
            Debug.Log("touch inst button -------------");
            if (ad.isInterstitialReady())
            {
                ad.showInterstitial();
            }
            else
            {
                ad.loadInterstitial(interstitialID);
            }
        }
        if (GUI.Button(new Rect(240, 0, 100, 60), "showRewardVideo"))
        {
            Debug.Log("touch video button -------------");
            if (ad.isRewardedVideoReady())
            {
                ad.showRewardedVideo();
            }
            else
            {
                ad.loadRewardedVideo(videoID);
            }
        }
        if (GUI.Button(new Rect(0, 100, 100, 60), "showbanner"))
        {
            Admob.Instance().showBannerRelative(bannerID, AdSize.SMART_BANNER, AdPosition.BOTTOM_CENTER);
        }
        if (GUI.Button(new Rect(120, 100, 100, 60), "showbannerABS"))
        {
            Admob.Instance().showBannerAbsolute(bannerID, AdSize.BANNER, 20, 220, "mybanner");
        }
        if (GUI.Button(new Rect(240, 100, 100, 60), "removebanner"))
        {
            Admob.Instance().removeBanner();
            Admob.Instance().removeBanner("mybanner");
        }

        if (GUI.Button(new Rect(0, 200, 100, 60), "showNative"))
        {
            Admob.Instance().showNativeBannerRelative(nativeBannerID, new AdSize(320, 280), AdPosition.BOTTOM_CENTER);
        }
        if (GUI.Button(new Rect(120, 200, 100, 60), "showNativeABS"))
        {
            Admob.Instance().showNativeBannerAbsolute(nativeBannerID, new AdSize(-1, 132), 0, 300);
        }
        if (GUI.Button(new Rect(240, 200, 100, 60), "removeNative"))
        {
            Admob.Instance().removeNativeBanner();
        }
    }
    void onInterstitialEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobEvent---" + eventName + "   " + msg);
        if (eventName == AdmobEvent.onAdLoaded)
        {
            Admob.Instance().showInterstitial();
        }
    }
    void onBannerEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobBannerEvent---" + eventName + "   " + msg);
    }
    void onRewardedVideoEvent(string eventName, string msg)
    {
        Debug.Log("handler onRewardedVideoEvent---" + eventName + "  rewarded: " + msg);
    }
    void onNativeBannerEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobNativeBannerEvent---" + eventName + "   " + msg);
    }*/

}
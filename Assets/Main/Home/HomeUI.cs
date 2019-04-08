using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Ads;

public class HomeUI : UIBehavior<HomeUI.UIData>
{

    #region UIData

    public class UIData : MainUI.UIData.Sub
    {

        public VP<ConfirmLeaveAppUI.UIData> confirmLeave;

        #region Constructor

        public enum Property
        {
            confirmLeave
        }

        public UIData() : base()
        {
            this.confirmLeave = new VP<ConfirmLeaveAppUI.UIData>(this, (byte)Property.confirmLeave, null);
        }

        #endregion

        public override MainUI.UIData.Sub.Type getType()
        {
            return MainUI.UIData.Sub.Type.Home;
        }

        public override bool processEvent(Event e)
        {
            Debug.LogError("processEvent: " + e + "; " + this);
            bool isProcess = false;
            {
                // ConfirmLeavel
                if (!isProcess)
                {
                    ConfirmLeaveAppUI.UIData confirmLeave = this.confirmLeave.v;
                    if (confirmLeave != null)
                    {
                        isProcess = confirmLeave.processEvent(e);
                    }
                    else
                    {
                        // Debug.LogError("confirmLeave null");
                    }
                }
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        HomeUI homeUI = this.findCallBack<HomeUI>();
                        if (homeUI != null)
                        {
                            homeUI.onClickBtnBack();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("homeUI null");
                        }
                    }
                }
                // short key
                if (!isProcess)
                {
                    // TODO Can hoan thien
                }
            }
            return isProcess;
        }

        public override MainUI.UIData.AllowShowBanner getAllowShowBanner()
        {
            return MainUI.UIData.AllowShowBanner.ForceShow;
        }

    }

    #endregion

    #region txt

    public Button btnOffline;
    public Text tvOffline;
    private static readonly TxtLanguage txtOffline = new TxtLanguage("Play Offline");

    public Button btnLan;
    public Text tvLan;
    private static readonly TxtLanguage txtLan = new TxtLanguage("Play LAN");

    public Button btnOnline;
    public Text tvOnline;
    private static readonly TxtLanguage txtOnline = new TxtLanguage("Play Online");

    public Button btnLoad;
    public Text tvLoad;
    private static readonly TxtLanguage txtLoad = new TxtLanguage("Load");

    public Button btnViewAds;
    public Text tvViewAds;
    private static readonly TxtLanguage txtViewAds = new TxtLanguage("View Ads");

    private static readonly TxtLanguage txtThankYou = new TxtLanguage("Thank you so much");

    static HomeUI()
    {
        txtOffline.add(Language.Type.vi, "Chơi Offline");
        txtLan.add(Language.Type.vi, "Chơi Mạng Lan");
        txtOnline.add(Language.Type.vi, "Chơi Online");
        txtLoad.add(Language.Type.vi, "Tải");
        txtViewAds.add(Language.Type.vi, "Xem Quảng Cáo");
        txtThankYou.add(Language.Type.vi, "Cảm ơn bạn rất nhiều");
    }

    #endregion

    #region refresh

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // btnViewAds
                {
                    if (btnViewAds != null)
                    {
                        bool canViewAds = AdsManager.get().showBtnViewAds.v && AdsManager.get().IsSupportFullScreenAds();
                        btnViewAds.gameObject.SetActive(canViewAds);
                    }
                    else
                    {
                        Debug.LogError("btnViewAds null");
                    }
                }
                // txt
                {
                    if (tvOffline != null)
                    {
                        tvOffline.text = txtOffline.get();
                    }
                    else
                    {
                        Debug.LogError("tvOffline null: " + this);
                    }
                    if (tvLan != null)
                    {
                        tvLan.text = txtLan.get();
                    }
                    else
                    {
                        Debug.LogError("tvLan null: " + this);
                    }
                    if (tvOnline != null)
                    {
                        tvOnline.text = txtOnline.get();
                    }
                    else
                    {
                        Debug.LogError("tvOnline null: " + this);
                    }
                    if (tvLoad != null)
                    {
                        tvLoad.text = txtLoad.get();
                    }
                    else
                    {
                        Debug.LogError("tvLoad null: " + this);
                    }
                    if (tvViewAds != null)
                    {
                        tvViewAds.text = txtViewAds.get();
                    }
                    else
                    {
                        Debug.LogError("tvViewAds null");
                    }
                }
            }
            else
            {
                // Debug.LogError ("data null: " + this);
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public ConfirmLeaveAppUI confirmLeavePrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Ads
            {
                AdsManager.get().addCallBack(this);
            }
            // setting
            {
                Setting.get().addCallBack(this);
            }
            // Child
            {
                uiData.confirmLeave.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Ads
        if(data is AdsManager)
        {
            dirty = true;
            return;
        }
        // Setting
        if (data is Setting)
        {
            dirty = true;
            return;
        }
        // Child
        if(data is ConfirmLeaveAppUI.UIData)
        {
            ConfirmLeaveAppUI.UIData confirmLeave = data as ConfirmLeaveAppUI.UIData;
            // UI
            {
                UIUtils.Instantiate(confirmLeave, confirmLeavePrefab, this.transform);
            }
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Ads
            {
                AdsManager.get().removeCallBack(this);
            }
            // setting
            {
                Setting.get().removeCallBack(this);
            }
            // Child
            {
                uiData.confirmLeave.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Ads
        if(data is AdsManager)
        {
            return;
        }
        // Setting
        if (data is Setting)
        {
            return;
        }
        // Child
        if (data is ConfirmLeaveAppUI.UIData)
        {
            ConfirmLeaveAppUI.UIData confirmLeave = data as ConfirmLeaveAppUI.UIData;
            // UI
            {
                confirmLeave.removeCallBackAndDestroy(typeof(ConfirmLeaveAppUI));
            }
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if (wrapProperty.p is UIData)
        {
            switch ((UIData.Property)wrapProperty.n)
            {
                case UIData.Property.confirmLeave:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Ads
        if(wrapProperty.p is AdsManager)
        {
            switch ((AdsManager.Property)wrapProperty.n)
            {
                case AdsManager.Property.alreadyBuyAds:
                    break;
                case AdsManager.Property.allowEdit:
                    break;
                case AdsManager.Property.time:
                    break;
                case AdsManager.Property.realTime:
                    break;
                case AdsManager.Property.videoType:
                    dirty = true;
                    break;
                case AdsManager.Property.showBtnViewAds:
                    dirty = true;
                    break;
                case AdsManager.Property.bannerType:
                    break;
                case AdsManager.Property.bannerVisibility:
                    break;
                case AdsManager.Property.lastClickBanner:
                    break;
                case AdsManager.Property.hideBannerDurationAfterClick:
                    break;
                case AdsManager.Property.hideAdsWhenStartPlay:
                    break;
                case AdsManager.Property.showAdsWhenGameEnd:
                    break;
                case AdsManager.Property.hideAdsWhenGameStart:
                    break;
                case AdsManager.Property.showAdsWhenGamePause:
                    break;
                case AdsManager.Property.hideAdsWhenGameNotPause:
                    break;
                case AdsManager.Property.reloadBannerInterval:
                    break;
                case AdsManager.Property.lastReloadBannerTime:
                    break;
                case AdsManager.Property.unityAdsBannerPlaceMentIds:
                    break;
                case AdsManager.Property.admobAppId:
                    break;
                case AdsManager.Property.admobBannerAdUnitId:
                    break;
                case AdsManager.Property.admobVideoType:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // setting
        if (wrapProperty.p is Setting)
        {
            switch ((Setting.Property)wrapProperty.n)
            {
                case Setting.Property.language:
                    dirty = true;
                    break;
                case Setting.Property.style:
                    break;
                case Setting.Property.contentTextSize:
                    break;
                case Setting.Property.titleTextSize:
                    break;
                case Setting.Property.labelTextSize:
                    break;
                case Setting.Property.showLastMove:
                    break;
                case Setting.Property.viewUrlImage:
                    break;
                case Setting.Property.animationSetting:
                    break;
                case Setting.Property.maxThinkCount:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        if (wrapProperty.p is ConfirmLeaveAppUI.UIData)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    #region Click Button

    public void onClickBtnPlayOnline()
    {
        // Debug.LogError ("onClickBtnPlayOnline");
        if (this.data != null)
        {
            MainUI.UIData mainUIData = this.data.findDataInParent<MainUI.UIData>();
            if (mainUIData != null)
            {
                PlayOnlineUI.UIData playOnlineUIData = mainUIData.sub.newOrOld<PlayOnlineUI.UIData>();
                {

                }
                mainUIData.sub.v = playOnlineUIData;
            }
            else
            {
                Debug.LogError("mainUIData null");
            }
        }
        else
        {
            Debug.LogError("uiData null");
        }
    }

    public void onClickBtnPlayOffline()
    {
        // Debug.LogError ("onClickBtnPlayOffline");
        if (this.data != null)
        {
            MainUI.UIData mainUIData = this.data.findDataInParent<MainUI.UIData>();
            if (mainUIData != null)
            {
                OfflineUI.UIData offlineUIData = mainUIData.sub.newOrOld<OfflineUI.UIData>();
                {

                }
                mainUIData.sub.v = offlineUIData;
            }
            else
            {
                Debug.LogError("mainUIData null");
            }
        }
        else
        {
            Debug.LogError("uiData null");
        }
    }

    public void onClickBtnPlayLAN()
    {
        // Debug.LogError ("onClickBtnPlayLAN");
        if (this.data != null)
        {
            MainUI.UIData mainUIData = this.data.findDataInParent<MainUI.UIData>();
            if (mainUIData != null)
            {
                LanUI.UIData lanUIData = mainUIData.sub.newOrOld<LanUI.UIData>();
                {

                }
                mainUIData.sub.v = lanUIData;
            }
            else
            {
                Debug.LogError("mainUIData null");
            }
        }
        else
        {
            Debug.LogError("uiData null");
        }
    }

    public void onClickBtnLoadGame()
    {
        Debug.LogError("onClickBtnLoadGame");
        if (this.data != null)
        {
            MainUI.UIData mainUIData = this.data.findDataInParent<MainUI.UIData>();
            if (mainUIData != null)
            {
                LoadDataUI.UIData loadDataUIData = mainUIData.sub.newOrOld<LoadDataUI.UIData>();
                {

                }
                mainUIData.sub.v = loadDataUIData;
            }
            else
            {
                Debug.LogError("mainUIData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

    public void onClickBtnViewAds()
    {
        AdsManager.get().showFullScreenAds();
        AdsManager.get().lastClickBanner.v = float.MinValue;
        Toast.showMessage(txtThankYou.get());
    }

    #endregion

    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            if (Setting.get().confirmQuit.v)
            {
                ConfirmLeaveAppUI.UIData confirmLeave = this.data.confirmLeave.newOrOld<ConfirmLeaveAppUI.UIData>();
                {

                }
                this.data.confirmLeave.v = confirmLeave;
            }
            else
            {
                Application.Quit();
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}
﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Ads
{
    public class AdsManagerUI : UIHaveTransformDataBehavior<AdsManagerUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<EditData<AdsManager>> editAdsManager;

            #region videoType

            public VP<RequestChangeEnumUI.UIData> videoType;

            public void makeRequestChangeVideoType(RequestChangeUpdate<int>.UpdateData update, int newVideoType)
            {
                // Find
                AdsManager adsManager = null;
                {
                    EditData<AdsManager> editAdsManager = this.editAdsManager.v;
                    if (editAdsManager != null)
                    {
                        adsManager = editAdsManager.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editAdsManager null: " + this);
                    }
                }
                // Process
                if (adsManager != null)
                {
                    adsManager.videoType.v = (AdsManager.AdsType)newVideoType;
                }
                else
                {
                    Debug.LogError("adsManager null");
                }
            }

            #endregion

            #region showBtnViewAds

            public VP<RequestChangeBoolUI.UIData> showBtnViewAds;

            public void makeRequestChangeShowBtnViewAds(RequestChangeUpdate<bool>.UpdateData update, bool newShowBtnViewAds)
            {
                // Find
                AdsManager adsManager = null;
                {
                    EditData<AdsManager> editAdsManager = this.editAdsManager.v;
                    if (editAdsManager != null)
                    {
                        adsManager = editAdsManager.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editAdsManager null: " + this);
                    }
                }
                // Process
                if (adsManager != null)
                {
                    adsManager.showBtnViewAds.v = newShowBtnViewAds;
                }
                else
                {
                    Debug.LogError("adsManager null");
                }
            }

            #endregion

            #region bannerType

            public VP<RequestChangeEnumUI.UIData> bannerType;

            public void makeRequestChangeBannerType(RequestChangeUpdate<int>.UpdateData update, int newBannerType)
            {
                // Find
                AdsManager adsManager = null;
                {
                    EditData<AdsManager> editAdsManager = this.editAdsManager.v;
                    if (editAdsManager != null)
                    {
                        adsManager = editAdsManager.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editAdsManager null: " + this);
                    }
                }
                // Process
                if (adsManager != null)
                {
                    adsManager.bannerType.v = (AdsManager.AdsType)newBannerType;
                }
                else
                {
                    Debug.LogError("adsManager null");
                }
            }

            #endregion

            #region hideBannerDurationAfterClick

            public VP<RequestChangeFloatUI.UIData> hideBannerDurationAfterClick;

            public void makeRequestChangeHideBannerDurationAfterClick(RequestChangeUpdate<float>.UpdateData update, float newHideBannerDurationAfterClick)
            {
                // Find
                AdsManager adsManager = null;
                {
                    EditData<AdsManager> editAdsManager = this.editAdsManager.v;
                    if (editAdsManager != null)
                    {
                        adsManager = editAdsManager.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editAdsManager null: " + this);
                    }
                }
                // Process
                if (adsManager != null)
                {
                    adsManager.hideBannerDurationAfterClick.v = newHideBannerDurationAfterClick;
                }
                else
                {
                    Debug.LogError("adsManager null");
                }
            }

            #endregion

            #region hideAdsWhenStartPlay

            public VP<RequestChangeBoolUI.UIData> hideAdsWhenStartPlay;

            public void makeRequestChangeHideAdsWhenStartPlay(RequestChangeUpdate<bool>.UpdateData update, bool newHideAdsWhenStartPlay)
            {
                // Find
                AdsManager adsManager = null;
                {
                    EditData<AdsManager> editAdsManager = this.editAdsManager.v;
                    if (editAdsManager != null)
                    {
                        adsManager = editAdsManager.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editAdsManager null: " + this);
                    }
                }
                // Process
                if (adsManager != null)
                {
                    adsManager.hideAdsWhenStartPlay.v = newHideAdsWhenStartPlay;
                }
                else
                {
                    Debug.LogError("adsManager null");
                }
            }

            #endregion

            #region showAdsWhenGameEnd

            public VP<RequestChangeBoolUI.UIData> showAdsWhenGameEnd;

            public void makeRequestChangeShowAdsWhenGameEnd(RequestChangeUpdate<bool>.UpdateData update, bool newShowAdsWhenGameEnd)
            {
                // Find
                AdsManager adsManager = null;
                {
                    EditData<AdsManager> editAdsManager = this.editAdsManager.v;
                    if (editAdsManager != null)
                    {
                        adsManager = editAdsManager.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editAdsManager null: " + this);
                    }
                }
                // Process
                if (adsManager != null)
                {
                    adsManager.showAdsWhenGameEnd.v = newShowAdsWhenGameEnd;
                }
                else
                {
                    Debug.LogError("adsManager null");
                }
            }

            #endregion

            #region hideAdsWhenGameStart

            public VP<RequestChangeBoolUI.UIData> hideAdsWhenGameStart;

            public void makeRequestChangeHideAdsWhenGameStart(RequestChangeUpdate<bool>.UpdateData update, bool newHideAdsWhenGameStart)
            {
                // Find
                AdsManager adsManager = null;
                {
                    EditData<AdsManager> editAdsManager = this.editAdsManager.v;
                    if (editAdsManager != null)
                    {
                        adsManager = editAdsManager.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editAdsManager null: " + this);
                    }
                }
                // Process
                if (adsManager != null)
                {
                    adsManager.hideAdsWhenGameStart.v = newHideAdsWhenGameStart;
                }
                else
                {
                    Debug.LogError("adsManager null");
                }
            }

            #endregion

            #region showAdsWhenGamePause

            public VP<RequestChangeBoolUI.UIData> showAdsWhenGamePause;

            public void makeRequestChangeShowAdsWhenGamePause(RequestChangeUpdate<bool>.UpdateData update, bool newShowAdsWhenGamePause)
            {
                // Find
                AdsManager adsManager = null;
                {
                    EditData<AdsManager> editAdsManager = this.editAdsManager.v;
                    if (editAdsManager != null)
                    {
                        adsManager = editAdsManager.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editAdsManager null: " + this);
                    }
                }
                // Process
                if (adsManager != null)
                {
                    adsManager.showAdsWhenGamePause.v = newShowAdsWhenGamePause;
                }
                else
                {
                    Debug.LogError("adsManager null");
                }
            }

            #endregion

            #region hideAdsWhenGameNotPause

            public VP<RequestChangeBoolUI.UIData> hideAdsWhenGameNotPause;

            public void makeRequestChangeHideAdsWhenGameNotPause(RequestChangeUpdate<bool>.UpdateData update, bool newHideAdsWhenGameNotPause)
            {
                // Find
                AdsManager adsManager = null;
                {
                    EditData<AdsManager> editAdsManager = this.editAdsManager.v;
                    if (editAdsManager != null)
                    {
                        adsManager = editAdsManager.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editAdsManager null: " + this);
                    }
                }
                // Process
                if (adsManager != null)
                {
                    adsManager.hideAdsWhenGameNotPause.v = newHideAdsWhenGameNotPause;
                }
                else
                {
                    Debug.LogError("adsManager null");
                }
            }

            #endregion

            #region reloadBannerInterval

            public VP<RequestChangeFloatUI.UIData> reloadBannerInterval;

            public void makeRequestChangeReloadBannerInterval(RequestChangeUpdate<float>.UpdateData update, float newReloadBannerInterval)
            {
                // Find
                AdsManager adsManager = null;
                {
                    EditData<AdsManager> editAdsManager = this.editAdsManager.v;
                    if (editAdsManager != null)
                    {
                        adsManager = editAdsManager.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editAdsManager null: " + this);
                    }
                }
                // Process
                if (adsManager != null)
                {
                    adsManager.reloadBannerInterval.v = newReloadBannerInterval;
                }
                else
                {
                    Debug.LogError("adsManager null");
                }
            }

            #endregion

            #region admobVideoType

            public VP<RequestChangeEnumUI.UIData> admobVideoType;

            public void makeRequestChangeAdmobVideoType(RequestChangeUpdate<int>.UpdateData update, int newAdmobVideoType)
            {
                // Find
                AdsManager adsManager = null;
                {
                    EditData<AdsManager> editAdsManager = this.editAdsManager.v;
                    if (editAdsManager != null)
                    {
                        adsManager = editAdsManager.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editAdsManager null: " + this);
                    }
                }
                // Process
                if (adsManager != null)
                {
                    adsManager.admobVideoType.v = (AdsManager.AdMobVideoType)newAdmobVideoType;
                }
                else
                {
                    Debug.LogError("adsManager null");
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editAdsManager,
                videoType,
                showBtnViewAds,
                bannerType,
                hideBannerDurationAfterClick,
                hideAdsWhenStartPlay,
                showAdsWhenGameEnd,
                hideAdsWhenGameStart,
                showAdsWhenGamePause,
                hideAdsWhenGameNotPause,
                reloadBannerInterval,
                admobVideoType

            }

            public UIData() : base()
            {
                this.editAdsManager = new VP<EditData<AdsManager>>(this, (byte)Property.editAdsManager, new EditData<AdsManager>());
                // videoType
                {
                    this.videoType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.videoType, new RequestChangeEnumUI.UIData());
                    this.videoType.v.updateData.v.request.v = makeRequestChangeVideoType;
                    foreach (AdsManager.AdsType style in System.Enum.GetValues(typeof(AdsManager.AdsType)))
                    {
                        this.videoType.v.options.add("" + style);
                    }
                }
                // showBtnViewAds
                {
                    this.showBtnViewAds = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.showBtnViewAds, new RequestChangeBoolUI.UIData());
                    this.showBtnViewAds.v.updateData.v.request.v = makeRequestChangeShowBtnViewAds;
                }
                // bannerType
                {
                    this.bannerType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.bannerType, new RequestChangeEnumUI.UIData());
                    this.bannerType.v.updateData.v.request.v = makeRequestChangeBannerType;
                    foreach (AdsManager.AdsType style in System.Enum.GetValues(typeof(AdsManager.AdsType)))
                    {
                        this.bannerType.v.options.add("" + style);
                    }
                }
                // hideBannerDurationAfterClick
                {
                    this.hideBannerDurationAfterClick = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.hideBannerDurationAfterClick, new RequestChangeFloatUI.UIData());
                    this.hideBannerDurationAfterClick.v.updateData.v.request.v = makeRequestChangeHideBannerDurationAfterClick;
                }
                // hideAdsWhenStartPlay
                {
                    this.hideAdsWhenStartPlay = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.hideAdsWhenStartPlay, new RequestChangeBoolUI.UIData());
                    this.hideAdsWhenStartPlay.v.updateData.v.request.v = makeRequestChangeHideAdsWhenStartPlay;
                }
                // showAdsWhenGameEnd
                {
                    this.showAdsWhenGameEnd = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.showAdsWhenGameEnd, new RequestChangeBoolUI.UIData());
                    this.showAdsWhenGameEnd.v.updateData.v.request.v = makeRequestChangeShowAdsWhenGameEnd;
                }
                // hideAdsWhenGameStart
                {
                    this.hideAdsWhenGameStart = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.hideAdsWhenGameStart, new RequestChangeBoolUI.UIData());
                    this.hideAdsWhenGameStart.v.updateData.v.request.v = makeRequestChangeHideAdsWhenGameStart;
                }
                // showAdsWhenGamePause
                {
                    this.showAdsWhenGamePause = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.showAdsWhenGamePause, new RequestChangeBoolUI.UIData());
                    this.showAdsWhenGamePause.v.updateData.v.request.v = makeRequestChangeShowAdsWhenGamePause;
                }
                // hideAdsWhenGameNotPause
                {
                    this.hideAdsWhenGameNotPause = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.hideAdsWhenGameNotPause, new RequestChangeBoolUI.UIData());
                    this.hideAdsWhenGameNotPause.v.updateData.v.request.v = makeRequestChangeHideAdsWhenGameNotPause;
                }
                // reloadBannerInterval
                {
                    this.reloadBannerInterval = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.reloadBannerInterval, new RequestChangeFloatUI.UIData());
                    this.reloadBannerInterval.v.updateData.v.request.v = makeRequestChangeReloadBannerInterval;
                }
                // admobVideoType
                {
                    this.admobVideoType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.admobVideoType, new RequestChangeEnumUI.UIData());
                    this.admobVideoType.v.updateData.v.request.v = makeRequestChangeAdmobVideoType;
                    foreach (AdsManager.AdMobVideoType type in System.Enum.GetValues(typeof(AdsManager.AdMobVideoType)))
                    {
                        this.admobVideoType.v.options.add("" + type);
                    }
                }
            }

            #endregion

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Ads Manager");

        public Text lbVideoType;
        private static readonly TxtLanguage txtVideoType = new TxtLanguage("Video type");

        public Text lbShowBtnViewAds;
        private static readonly TxtLanguage txtShowBtnViewAds = new TxtLanguage("Show btn view ads");

        public Text lbBannerType;
        private static readonly TxtLanguage txtBannerType = new TxtLanguage("Banner type");

        public Text lbHideBannerDurationAfterClick;
        private static readonly TxtLanguage txtHideBannerDurationAfterClick = new TxtLanguage("Hide banner");

        public Text lbHideAdsWhenStartPlay;
        private static readonly TxtLanguage txtHideAdsWhenStartPlay = new TxtLanguage("Hide ads when start play");

        public Text lbShowAdsWhenGameEnd;
        private static readonly TxtLanguage txtShowAdsWhenGameEnd = new TxtLanguage("Show banner when game end");

        public Text lbHideAdsWhenGameStart;
        private static readonly TxtLanguage txtHideAdsWhenGameStart = new TxtLanguage("Hide banner when game start");

        public Text lbShowAdsWhenGamePause;
        private static readonly TxtLanguage txtShowAdsWhenGamePause = new TxtLanguage("Show banner when game pause");

        public Text lbHideAdsWhenGameNotPause;
        private static readonly TxtLanguage txtHideAdsWhenGameNotPause = new TxtLanguage("Hide banner when game not pause");

        public Text lbReloadBannerInterval;
        private static readonly TxtLanguage txtReloadBannerInterval = new TxtLanguage("Reload banner");

        public Text lbAdmobVideoType;
        private static readonly TxtLanguage txtAdmobVideoType = new TxtLanguage("Admob video type");

        static AdsManagerUI()
        {
            txtTitle.add(Language.Type.vi, "Quản Lý Quảng Cáo");
            txtVideoType.add(Language.Type.vi, "Loại video");
            txtShowBtnViewAds.add(Language.Type.vi, "Hiện nút quảng cáo");
            txtBannerType.add(Language.Type.vi, "Loại banner");
            txtHideBannerDurationAfterClick.add(Language.Type.vi, "Giấu banner");
            txtHideAdsWhenStartPlay.add(Language.Type.vi, "Giấu banner khi chơi");
            txtShowAdsWhenGameEnd.add(Language.Type.vi, "Hiện banner khi kết thúc");
            txtHideAdsWhenGameStart.add(Language.Type.vi, "Giấu banner khi bắt đầu");
            txtShowAdsWhenGamePause.add(Language.Type.vi, "Hiện banner khi tạm dừng");
            txtHideAdsWhenGameNotPause.add(Language.Type.vi, "Giấu banner khi huỷ tạm dừng");
            txtReloadBannerInterval.add(Language.Type.vi, "Tải lại banner");
            txtAdmobVideoType.add(Language.Type.vi, "Loại video admob");
        }

        #endregion

        #region Refresh

        private bool needReset = true;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EditData<AdsManager> editAdsManager = this.data.editAdsManager.v;
                    if (editAdsManager != null)
                    {
                        editAdsManager.update();
                        // different
                        RequestChange.ShowDifferentTitle(lbTitle, editAdsManager);
                        // request
                        Server.State.Type serverState = Server.State.Type.Connect;
                        {
                            RequestChange.RefreshUI(this.data.videoType.v, editAdsManager, serverState, needReset, editData => (int)editData.videoType.v);
                            RequestChange.RefreshUI(this.data.showBtnViewAds.v, editAdsManager, serverState, needReset, editData => editData.showBtnViewAds.v);
                            RequestChange.RefreshUI(this.data.bannerType.v, editAdsManager, serverState, needReset, editData => (int)editData.bannerType.v);
                            RequestChange.RefreshUI(this.data.hideBannerDurationAfterClick.v, editAdsManager, serverState, needReset, editData => editData.hideBannerDurationAfterClick.v);
                            RequestChange.RefreshUI(this.data.hideAdsWhenStartPlay.v, editAdsManager, serverState, needReset, editData => editData.hideAdsWhenStartPlay.v);
                            RequestChange.RefreshUI(this.data.showAdsWhenGameEnd.v, editAdsManager, serverState, needReset, editData => editData.showAdsWhenGameEnd.v);
                            RequestChange.RefreshUI(this.data.hideAdsWhenGameStart.v, editAdsManager, serverState, needReset, editData => editData.hideAdsWhenGameStart.v);
                            RequestChange.RefreshUI(this.data.showAdsWhenGamePause.v, editAdsManager, serverState, needReset, editData => editData.showAdsWhenGamePause.v);
                            RequestChange.RefreshUI(this.data.hideAdsWhenGameNotPause.v, editAdsManager, serverState, needReset, editData => editData.hideAdsWhenGameNotPause.v);
                            RequestChange.RefreshUI(this.data.reloadBannerInterval.v, editAdsManager, serverState, needReset, editData => editData.reloadBannerInterval.v);
                            RequestChange.RefreshUI(this.data.admobVideoType.v, editAdsManager, serverState, needReset, editData => (int)editData.admobVideoType.v);
                        }
                        needReset = false;
                    }
                    else
                    {
                        Debug.LogError("editAdsManager null");
                    }
                    // UI
                    {
                        float deltaY = 0;
                        // header
                        UIUtils.SetHeaderPosition(lbTitle, UIRectTransform.ShowType.Normal, ref deltaY);
                        // videoType
                        UIUtils.SetLabelContentPosition(lbVideoType, this.data.videoType.v, ref deltaY);
                        // showBtnViewAds
                        UIUtils.SetLabelContentPosition(lbShowBtnViewAds, this.data.showBtnViewAds.v, ref deltaY);
                        // bannerType
                        UIUtils.SetLabelContentPosition(lbBannerType, this.data.bannerType.v, ref deltaY);
                        // hideBannerDurationAfterClick
                        UIUtils.SetLabelContentPosition(lbHideBannerDurationAfterClick, this.data.hideBannerDurationAfterClick.v, ref deltaY);
                        // hideAdsWhenStartPlay
                        UIUtils.SetLabelContentPosition(lbHideAdsWhenStartPlay, this.data.hideAdsWhenStartPlay.v, ref deltaY);
                        // showAdsWhenGameEnd
                        UIUtils.SetLabelContentPosition(lbShowAdsWhenGameEnd, this.data.showAdsWhenGameEnd.v, ref deltaY);
                        // hideAdsWhenGameStart
                        UIUtils.SetLabelContentPosition(lbHideAdsWhenGameStart, this.data.hideAdsWhenGameStart.v, ref deltaY);
                        // showAdsWhenGamePause
                        UIUtils.SetLabelContentPosition(lbShowAdsWhenGamePause, this.data.showAdsWhenGamePause.v, ref deltaY);
                        // hideAdsWhenGameNotPause
                        UIUtils.SetLabelContentPosition(lbHideAdsWhenGameNotPause, this.data.hideAdsWhenGameNotPause.v, ref deltaY);
                        // reloadBannerInterval
                        UIUtils.SetLabelContentPosition(lbReloadBannerInterval, this.data.reloadBannerInterval.v, ref deltaY);
                        // admobVideoType
                        UIUtils.SetLabelContentPosition(lbAdmobVideoType, this.data.admobVideoType.v, ref deltaY);
                        // set
                        UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get();
                            Setting.get().setTitleTextSize(lbTitle);
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                        if (lbVideoType != null)
                        {
                            lbVideoType.text = txtVideoType.get();
                            Setting.get().setLabelTextSize(lbVideoType);
                        }
                        else
                        {
                            Debug.LogError("lbVideoType null");
                        }
                        if (lbShowBtnViewAds != null)
                        {
                            lbShowBtnViewAds.text = txtShowBtnViewAds.get();
                            Setting.get().setLabelTextSize(lbShowBtnViewAds);
                        }
                        else
                        {
                            Debug.LogError("lbShowBtnViewAds null");
                        }
                        if (lbBannerType != null)
                        {
                            lbBannerType.text = txtBannerType.get();
                            Setting.get().setLabelTextSize(lbBannerType);
                        }
                        else
                        {
                            Debug.LogError("lbBannerType null");
                        }
                        if (lbHideBannerDurationAfterClick != null)
                        {
                            lbHideBannerDurationAfterClick.text = txtHideBannerDurationAfterClick.get();
                            Setting.get().setLabelTextSize(lbHideBannerDurationAfterClick);
                        }
                        else
                        {
                            Debug.LogError("lbHideBannerDurationAfterClick null");
                        }
                        if (lbHideAdsWhenStartPlay != null)
                        {
                            lbHideAdsWhenStartPlay.text = txtHideAdsWhenStartPlay.get();
                            Setting.get().setLabelTextSize(lbHideAdsWhenStartPlay);
                        }
                        else
                        {
                            Debug.LogError("lbHideAdsWhenStartPlay null");
                        }
                        if (lbShowAdsWhenGameEnd != null)
                        {
                            lbShowAdsWhenGameEnd.text = txtShowAdsWhenGameEnd.get();
                            Setting.get().setLabelTextSize(lbShowAdsWhenGameEnd);
                        }
                        else
                        {
                            Debug.LogError("lbShowAdsWhenGameEnd null");
                        }
                        if (lbHideAdsWhenGameStart != null)
                        {
                            lbHideAdsWhenGameStart.text = txtHideAdsWhenGameStart.get();
                            Setting.get().setLabelTextSize(lbHideAdsWhenGameStart);
                        }
                        else
                        {
                            Debug.LogError("lbHideAdsWhenGameStart null");
                        }
                        if (lbShowAdsWhenGamePause != null)
                        {
                            lbShowAdsWhenGamePause.text = txtShowAdsWhenGamePause.get();
                            Setting.get().setLabelTextSize(lbShowAdsWhenGamePause);
                        }
                        else
                        {
                            Debug.LogError("lbShowAdsWhenGamePause null");
                        }
                        if(lbHideAdsWhenGameNotPause != null)
                        {
                            lbHideAdsWhenGameNotPause.text = txtHideAdsWhenGameNotPause.get();
                            Setting.get().setLabelTextSize(lbHideAdsWhenGameNotPause);
                        }
                        else
                        {
                            Debug.LogError("lbHideAdsWhenGameNotPause null");
                        }
                        if (lbReloadBannerInterval != null)
                        {
                            lbReloadBannerInterval.text = txtReloadBannerInterval.get();
                            Setting.get().setLabelTextSize(lbReloadBannerInterval);
                        }
                        else
                        {
                            Debug.LogError("lbReloadBannerInterval null");
                        }
                        if (lbAdmobVideoType != null)
                        {
                            lbAdmobVideoType.text = txtAdmobVideoType.get();
                            Setting.get().setLabelTextSize(lbAdmobVideoType);
                        }
                        else
                        {
                            Debug.LogError("lbAdmobVideoType null");
                        }
                    }
                }
                else
                {
                    // Debug.LogError("data null");
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                {
                    Setting.get().addCallBack(this);
                }
                // Child
                {
                    uiData.editAdsManager.allAddCallBack(this);
                    uiData.videoType.allAddCallBack(this);
                    uiData.showBtnViewAds.allAddCallBack(this);
                    uiData.bannerType.allAddCallBack(this);
                    uiData.hideBannerDurationAfterClick.allAddCallBack(this);
                    uiData.hideAdsWhenStartPlay.allAddCallBack(this);
                    uiData.showAdsWhenGameEnd.allAddCallBack(this);
                    uiData.hideAdsWhenGameStart.allAddCallBack(this);
                    uiData.showAdsWhenGamePause.allAddCallBack(this);
                    uiData.hideAdsWhenGameNotPause.allAddCallBack(this);
                    uiData.reloadBannerInterval.allAddCallBack(this);
                    uiData.admobVideoType.allAddCallBack(this);
                }
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
            {
                // editAdsManager
                {
                    if (data is EditData<AdsManager>)
                    {
                        EditData<AdsManager> editAdsManager = data as EditData<AdsManager>;
                        // Child
                        {
                            editAdsManager.show.allAddCallBack(this);
                            editAdsManager.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is AdsManager)
                    {
                        needReset = true;
                        dirty = true;
                        return;
                    }
                }
                // videoType, bannerType, admobVideoType
                if (data is RequestChangeEnumUI.UIData)
                {
                    RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                    // UI
                    {
                        WrapProperty wrapProperty = requestChange.p;
                        if (wrapProperty != null)
                        {
                            switch ((UIData.Property)wrapProperty.n)
                            {
                                case UIData.Property.videoType:
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestEnum, this.transform, UIConstants.RequestEnumRect);
                                    break;
                                case UIData.Property.bannerType:
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestEnum, this.transform, UIConstants.RequestEnumRect);
                                    break;
                                case UIData.Property.admobVideoType:
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestEnum, this.transform, UIConstants.RequestEnumRect);
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("wrapProperty null: " + this);
                        }
                    }
                    dirty = true;
                    return;
                }
                // showBtnViewAds, hideAdsWhenStartPlay, showAdsWhenGameEnd, hideAdsWhenGameStart, showAdsWhenGamePause
                if (data is RequestChangeBoolUI.UIData)
                {
                    RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                    // UI
                    {
                        WrapProperty wrapProperty = requestChange.p;
                        if (wrapProperty != null)
                        {
                            switch ((UIData.Property)wrapProperty.n)
                            {
                                case UIData.Property.showBtnViewAds:
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestBool, this.transform, UIConstants.RequestBoolRect);
                                    break;
                                case UIData.Property.hideAdsWhenStartPlay:
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestBool, this.transform, UIConstants.RequestBoolRect);
                                    break;
                                case UIData.Property.showAdsWhenGameEnd:
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestBool, this.transform, UIConstants.RequestBoolRect);
                                    break;
                                case UIData.Property.hideAdsWhenGameStart:
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestBool, this.transform, UIConstants.RequestBoolRect);
                                    break;
                                case UIData.Property.showAdsWhenGamePause:
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestBool, this.transform, UIConstants.RequestBoolRect);
                                    break;
                                case UIData.Property.hideAdsWhenGameNotPause:
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestBool, this.transform, UIConstants.RequestBoolRect);
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("wrapProperty null: " + this);
                        }
                    }
                    dirty = true;
                    return;
                }
                // hideBannerDurationAfterClick, reloadBannerInterval,
                if (data is RequestChangeFloatUI.UIData)
                {
                    RequestChangeFloatUI.UIData requestChange = data as RequestChangeFloatUI.UIData;
                    // UI
                    {
                        WrapProperty wrapProperty = requestChange.p;
                        if (wrapProperty != null)
                        {
                            switch ((UIData.Property)wrapProperty.n)
                            {
                                case UIData.Property.hideBannerDurationAfterClick:
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestFloat, this.transform, UIConstants.RequestRect);
                                    break;
                                case UIData.Property.reloadBannerInterval:
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestFloat, this.transform, UIConstants.RequestRect);
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("wrapProperty null: " + this);
                        }
                    }
                    dirty = true;
                    return;
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                {
                    Setting.get().removeCallBack(this);
                }
                // Child
                {
                    uiData.editAdsManager.allRemoveCallBack(this);
                    uiData.videoType.allRemoveCallBack(this);
                    uiData.showBtnViewAds.allRemoveCallBack(this);
                    uiData.bannerType.allRemoveCallBack(this);
                    uiData.hideBannerDurationAfterClick.allRemoveCallBack(this);
                    uiData.hideAdsWhenStartPlay.allRemoveCallBack(this);
                    uiData.showAdsWhenGameEnd.allRemoveCallBack(this);
                    uiData.hideAdsWhenGameStart.allRemoveCallBack(this);
                    uiData.showAdsWhenGamePause.allRemoveCallBack(this);
                    uiData.hideAdsWhenGameNotPause.allRemoveCallBack(this);
                    uiData.reloadBannerInterval.allRemoveCallBack(this);
                    uiData.admobVideoType.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Child
            {
                // editAdsManager
                {
                    if (data is EditData<AdsManager>)
                    {
                        EditData<AdsManager> editAdsManager = data as EditData<AdsManager>;
                        // Child
                        {
                            editAdsManager.show.allRemoveCallBack(this);
                            editAdsManager.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is AdsManager)
                    {
                        return;
                    }
                }
                // videoType, bannerType, admobVideoType
                if (data is RequestChangeEnumUI.UIData)
                {
                    RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeEnumUI));
                    }
                    return;
                }
                // showBtnViewAds, hideAdsWhenStartPlay, showAdsWhenGameEnd, hideAdsWhenGameStart, showAdsWhenGamePause
                if (data is RequestChangeBoolUI.UIData)
                {
                    RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeBoolUI));
                    }
                    return;
                }
                // hideBannerDurationAfterClick, reloadBannerInterval,
                if (data is RequestChangeFloatUI.UIData)
                {
                    RequestChangeFloatUI.UIData requestChange = data as RequestChangeFloatUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeFloatUI));
                    }
                    return;
                }
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
                    case UIData.Property.editAdsManager:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.videoType:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showBtnViewAds:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.bannerType:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.hideBannerDurationAfterClick:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.hideAdsWhenStartPlay:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showAdsWhenGameEnd:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.hideAdsWhenGameStart:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showAdsWhenGamePause:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.hideAdsWhenGameNotPause:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.reloadBannerInterval:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.admobVideoType:
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
            // Setting
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
                        dirty = true;
                        break;
                    case Setting.Property.titleTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.labelTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.buttonSize:
                        dirty = true;
                        break;
                    case Setting.Property.itemSize:
                        dirty = true;
                        break;
                    case Setting.Property.showLastMove:
                        break;
                    case Setting.Property.viewUrlImage:
                        break;
                    case Setting.Property.animationSetting:
                        break;
                    case Setting.Property.maxThinkCount:
                        break;
                    case Setting.Property.defaultChosenGame:
                        break;
                    case Setting.Property.defaultRoomName:
                        break;
                    case Setting.Property.defaultChatRoomStyle:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                // editAdsManager
                {
                    if (wrapProperty.p is EditData<AdsManager>)
                    {
                        switch ((EditData<AdsManager>.Property)wrapProperty.n)
                        {
                            case EditData<AdsManager>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<AdsManager>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<AdsManager>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<AdsManager>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<AdsManager>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<AdsManager>.Property.editType:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is AdsManager)
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
                                dirty = true;
                                break;
                            case AdsManager.Property.bannerVisibility:
                                break;
                            case AdsManager.Property.lastClickBanner:
                                break;
                            case AdsManager.Property.hideBannerDurationAfterClick:
                                dirty = true;
                                break;
                            case AdsManager.Property.hideAdsWhenStartPlay:
                                dirty = true;
                                break;
                            case AdsManager.Property.showAdsWhenGameEnd:
                                dirty = true;
                                break;
                            case AdsManager.Property.hideAdsWhenGameStart:
                                dirty = true;
                                break;
                            case AdsManager.Property.showAdsWhenGamePause:
                                dirty = true;
                                break;
                            case AdsManager.Property.hideAdsWhenGameNotPause:
                                dirty = true;
                                break;
                            case AdsManager.Property.reloadBannerInterval:
                                dirty = true;
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
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
                // videoType, bannerType, admobVideoType
                if (wrapProperty.p is RequestChangeEnumUI.UIData)
                {
                    return;
                }
                // showBtnViewAds, hideAdsWhenStartPlay, showAdsWhenGameEnd, hideAdsWhenGameStart, showAdsWhenGamePause
                if (wrapProperty.p is RequestChangeBoolUI.UIData)
                {
                    return;
                }
                // hideBannerDurationAfterClick, reloadBannerInterval,
                if (wrapProperty.p is RequestChangeFloatUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
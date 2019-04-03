using UnityEngine;
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
        private static readonly TxtLanguage txtTitle = new TxtLanguage();

        public Text lbVideoType;
        private static readonly TxtLanguage txtVideoType = new TxtLanguage();

        public Text lbShowBtnViewAds;
        private static readonly TxtLanguage txtShowBtnViewAds = new TxtLanguage();

        public Text lbBannerType;
        private static readonly TxtLanguage txtBannerType = new TxtLanguage();

        public Text lbHideBannerDurationAfterClick;
        private static readonly TxtLanguage txtHideBannerDurationAfterClick = new TxtLanguage();

        public Text lbHideAdsWhenStartPlay;
        private static readonly TxtLanguage txtHideAdsWhenStartPlay = new TxtLanguage();

        public Text lbShowAdsWhenGameEnd;
        private static readonly TxtLanguage txtShowAdsWhenGameEnd = new TxtLanguage();

        public Text lbReloadBannerInterval;
        private static readonly TxtLanguage txtReloadBannerInterval = new TxtLanguage();

        public Text lbAdmobVideoType;
        private static readonly TxtLanguage txtAdmobVideoType = new TxtLanguage();

        static AdsManagerUI()
        {
            txtTitle.add(Language.Type.vi, "Quản Lý Quảng Cáo");
            txtVideoType.add(Language.Type.vi, "Loại video");
            txtShowBtnViewAds.add(Language.Type.vi, "Hiện nút quảng cáo");
            txtBannerType.add(Language.Type.vi, "Loại banner");
            txtHideBannerDurationAfterClick.add(Language.Type.vi, "Giấu banner");
            txtHideAdsWhenStartPlay.add(Language.Type.vi, "Giấu banner khi chơi");
            txtShowAdsWhenGameEnd.add(Language.Type.vi, "Hiện banner khi kết thúc");
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
                        // get show
                        AdsManager show = editAdsManager.show.v.data;
                        AdsManager compare = editAdsManager.compare.v.data;
                        if (show != null)
                        {
                            // different
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editAdsManager.compareOtherType.v.data != null)
                                    {
                                        if (editAdsManager.compareOtherType.v.data.GetType() != show.GetType())
                                        {
                                            isDifferent = true;
                                        }
                                    }
                                }
                                lbTitle.color = isDifferent ? UIConstants.DifferentIndicatorColor : UIConstants.NormalTitleColor;
                            }
                            else
                            {
                                Debug.LogError("lbAdsManager null: " + this);
                            }
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = Server.State.Type.Connect;
                                /*{
                                    Server server = show.findDataInParent<Server> ();
                                    if (server != null) {
                                        if (server.state.v != null) {
                                            serverState = server.state.v.getType ();
                                        } else {
                                            Debug.LogError ("server state null: " + this);
                                        }
                                    } else {
                                        Debug.LogError ("server null: " + this);
                                    }
                                }*/
                                // set origin
                                {
                                    // videoType
                                    {
                                        RequestChangeEnumUI.UIData videoType = this.data.videoType.v;
                                        if (videoType != null)
                                        {
                                            // update
                                            RequestChangeUpdate<int>.UpdateData updateData = videoType.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = (int)show.videoType.v;
                                                updateData.canRequestChange.v = editAdsManager.canEdit.v;
                                                updateData.serverState.v = serverState;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                            // compare
                                            {
                                                if (compare != null)
                                                {
                                                    videoType.showDifferent.v = true;
                                                    videoType.compare.v = (int)compare.videoType.v;
                                                }
                                                else
                                                {
                                                    videoType.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("videoType null: " + this);
                                        }
                                    }
                                    // showBtnViewAds
                                    {
                                        RequestChangeBoolUI.UIData showBtnViewAds = this.data.showBtnViewAds.v;
                                        if (showBtnViewAds != null)
                                        {
                                            // update
                                            RequestChangeUpdate<bool>.UpdateData updateData = showBtnViewAds.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.showBtnViewAds.v;
                                                updateData.canRequestChange.v = editAdsManager.canEdit.v;
                                                updateData.serverState.v = serverState;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                            // compare
                                            {
                                                if (compare != null)
                                                {
                                                    showBtnViewAds.showDifferent.v = true;
                                                    showBtnViewAds.compare.v = compare.showBtnViewAds.v;
                                                }
                                                else
                                                {
                                                    showBtnViewAds.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("showBtnViewAds null: " + this);
                                        }
                                    }
                                    // bannerType
                                    {
                                        RequestChangeEnumUI.UIData bannerType = this.data.bannerType.v;
                                        if (bannerType != null)
                                        {
                                            // update
                                            RequestChangeUpdate<int>.UpdateData updateData = bannerType.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = (int)show.bannerType.v;
                                                updateData.canRequestChange.v = editAdsManager.canEdit.v;
                                                updateData.serverState.v = serverState;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                            // compare
                                            {
                                                if (compare != null)
                                                {
                                                    bannerType.showDifferent.v = true;
                                                    bannerType.compare.v = (int)compare.bannerType.v;
                                                }
                                                else
                                                {
                                                    bannerType.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("bannerType null: " + this);
                                        }
                                    }
                                    // hideBannerDurationAfterClick
                                    {
                                        RequestChangeFloatUI.UIData hideBannerDurationAfterClick = this.data.hideBannerDurationAfterClick.v;
                                        if (hideBannerDurationAfterClick != null)
                                        {
                                            // update
                                            RequestChangeUpdate<float>.UpdateData updateData = hideBannerDurationAfterClick.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.hideBannerDurationAfterClick.v;
                                                updateData.canRequestChange.v = editAdsManager.canEdit.v;
                                                updateData.serverState.v = serverState;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                            // compare
                                            {
                                                if (compare != null)
                                                {
                                                    hideBannerDurationAfterClick.showDifferent.v = true;
                                                    hideBannerDurationAfterClick.compare.v = compare.hideBannerDurationAfterClick.v;
                                                }
                                                else
                                                {
                                                    hideBannerDurationAfterClick.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("hideBannerDurationAfterClick null: " + this);
                                        }
                                    }
                                    // hideAdsWhenStartPlay
                                    {
                                        RequestChangeBoolUI.UIData hideAdsWhenStartPlay = this.data.hideAdsWhenStartPlay.v;
                                        if (hideAdsWhenStartPlay != null)
                                        {
                                            // update
                                            RequestChangeUpdate<bool>.UpdateData updateData = hideAdsWhenStartPlay.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.hideAdsWhenStartPlay.v;
                                                updateData.canRequestChange.v = editAdsManager.canEdit.v;
                                                updateData.serverState.v = serverState;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                            // compare
                                            {
                                                if (compare != null)
                                                {
                                                    hideAdsWhenStartPlay.showDifferent.v = true;
                                                    hideAdsWhenStartPlay.compare.v = compare.hideAdsWhenStartPlay.v;
                                                }
                                                else
                                                {
                                                    hideAdsWhenStartPlay.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("hideAdsWhenStartPlay null: " + this);
                                        }
                                    }
                                    // showAdsWhenGameEnd
                                    {
                                        RequestChangeBoolUI.UIData showAdsWhenGameEnd = this.data.showAdsWhenGameEnd.v;
                                        if (showAdsWhenGameEnd != null)
                                        {
                                            // update
                                            RequestChangeUpdate<bool>.UpdateData updateData = showAdsWhenGameEnd.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.showAdsWhenGameEnd.v;
                                                updateData.canRequestChange.v = editAdsManager.canEdit.v;
                                                updateData.serverState.v = serverState;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                            // compare
                                            {
                                                if (compare != null)
                                                {
                                                    showAdsWhenGameEnd.showDifferent.v = true;
                                                    showAdsWhenGameEnd.compare.v = compare.showAdsWhenGameEnd.v;
                                                }
                                                else
                                                {
                                                    showAdsWhenGameEnd.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("showAdsWhenGameEnd null: " + this);
                                        }
                                    }
                                    // reloadBannerInterval
                                    {
                                        RequestChangeFloatUI.UIData reloadBannerInterval = this.data.reloadBannerInterval.v;
                                        if (reloadBannerInterval != null)
                                        {
                                            // update
                                            RequestChangeUpdate<float>.UpdateData updateData = reloadBannerInterval.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.reloadBannerInterval.v;
                                                updateData.canRequestChange.v = editAdsManager.canEdit.v;
                                                updateData.serverState.v = serverState;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                            // compare
                                            {
                                                if (compare != null)
                                                {
                                                    reloadBannerInterval.showDifferent.v = true;
                                                    reloadBannerInterval.compare.v = compare.reloadBannerInterval.v;
                                                }
                                                else
                                                {
                                                    reloadBannerInterval.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("reloadBannerInterval null: " + this);
                                        }
                                    }
                                    // admobVideoType
                                    {
                                        RequestChangeEnumUI.UIData admobVideoType = this.data.admobVideoType.v;
                                        if (admobVideoType != null)
                                        {
                                            // update
                                            RequestChangeUpdate<int>.UpdateData updateData = admobVideoType.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = (int)show.admobVideoType.v;
                                                updateData.canRequestChange.v = editAdsManager.canEdit.v;
                                                updateData.serverState.v = serverState;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                            // compare
                                            {
                                                if (compare != null)
                                                {
                                                    admobVideoType.showDifferent.v = true;
                                                    admobVideoType.compare.v = (int)compare.admobVideoType.v;
                                                }
                                                else
                                                {
                                                    admobVideoType.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("admobVideoType null: " + this);
                                        }
                                    }
                                }
                            }
                            // reset
                            if (needReset)
                            {
                                needReset = false;
                                // videoType
                                {
                                    RequestChangeEnumUI.UIData videoType = this.data.videoType.v;
                                    if (videoType != null)
                                    {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = videoType.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = (int)show.videoType.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("videoType null: " + this);
                                    }
                                }
                                // showBtnViewAds
                                {
                                    RequestChangeBoolUI.UIData showBtnViewAds = this.data.showBtnViewAds.v;
                                    if (showBtnViewAds != null)
                                    {
                                        // update
                                        RequestChangeUpdate<bool>.UpdateData updateData = showBtnViewAds.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.showBtnViewAds.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("showBtnViewAds null: " + this);
                                    }
                                }
                                // bannerType
                                {
                                    RequestChangeEnumUI.UIData bannerType = this.data.bannerType.v;
                                    if (bannerType != null)
                                    {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = bannerType.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = (int)show.bannerType.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("bannerType null: " + this);
                                    }
                                }
                                // hideBannerDurationAfterClick
                                {
                                    RequestChangeFloatUI.UIData hideBannerDurationAfterClick = this.data.hideBannerDurationAfterClick.v;
                                    if (hideBannerDurationAfterClick != null)
                                    {
                                        // update
                                        RequestChangeUpdate<float>.UpdateData updateData = hideBannerDurationAfterClick.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.hideBannerDurationAfterClick.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("hideBannerDurationAfterClick null: " + this);
                                    }
                                }
                                // hideAdsWhenStartPlay
                                {
                                    RequestChangeBoolUI.UIData hideAdsWhenStartPlay = this.data.hideAdsWhenStartPlay.v;
                                    if (hideAdsWhenStartPlay != null)
                                    {
                                        // update
                                        RequestChangeUpdate<bool>.UpdateData updateData = hideAdsWhenStartPlay.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.hideAdsWhenStartPlay.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("hideAdsWhenStartPlay null: " + this);
                                    }
                                }
                                // showAdsWhenGameEnd
                                {
                                    RequestChangeBoolUI.UIData showAdsWhenGameEnd = this.data.showAdsWhenGameEnd.v;
                                    if (showAdsWhenGameEnd != null)
                                    {
                                        // update
                                        RequestChangeUpdate<bool>.UpdateData updateData = showAdsWhenGameEnd.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.showAdsWhenGameEnd.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("showAdsWhenGameEnd null: " + this);
                                    }
                                }
                                // reloadBannerInterval
                                {
                                    RequestChangeFloatUI.UIData reloadBannerInterval = this.data.reloadBannerInterval.v;
                                    if (reloadBannerInterval != null)
                                    {
                                        // update
                                        RequestChangeUpdate<float>.UpdateData updateData = reloadBannerInterval.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.reloadBannerInterval.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("reloadBannerInterval null: " + this);
                                    }
                                }
                                // admobVideoType
                                {
                                    RequestChangeEnumUI.UIData admobVideoType = this.data.admobVideoType.v;
                                    if (admobVideoType != null)
                                    {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = admobVideoType.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = (int)show.admobVideoType.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("admobVideoType null: " + this);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("show null");
                        }
                    }
                    else
                    {
                        Debug.LogError("editAdsManager null");
                    }
                    // UI
                    {
                        float deltaY = UIConstants.HeaderHeight;
                        // videoType
                        {
                            if (this.data.videoType.v != null)
                            {
                                if (lbVideoType != null)
                                {
                                    lbVideoType.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbVideoType.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbVideoType null");
                                }
                                UIRectTransform.SetPosY(this.data.videoType.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbVideoType != null)
                                {
                                    lbVideoType.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbVideoType null");
                                }
                            }
                        }
                        // showBtnViewAds
                        {
                            if (this.data.showBtnViewAds.v != null)
                            {
                                if (lbShowBtnViewAds != null)
                                {
                                    lbShowBtnViewAds.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbShowBtnViewAds.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbShowBtnViewAds null");
                                }
                                UIRectTransform.SetPosY(this.data.showBtnViewAds.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbShowBtnViewAds != null)
                                {
                                    lbShowBtnViewAds.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbShowBtnViewAds null");
                                }
                            }
                        }
                        // bannerType
                        {
                            if (this.data.bannerType.v != null)
                            {
                                if (lbBannerType != null)
                                {
                                    lbBannerType.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbBannerType.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbBannerType null");
                                }
                                UIRectTransform.SetPosY(this.data.bannerType.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbBannerType != null)
                                {
                                    lbBannerType.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbBannerType null");
                                }
                            }
                        }
                        // hideBannerDurationAfterClick
                        {
                            if (this.data.hideBannerDurationAfterClick.v != null)
                            {
                                if (lbHideBannerDurationAfterClick != null)
                                {
                                    lbHideBannerDurationAfterClick.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbHideBannerDurationAfterClick.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbHideBannerDurationAfterClick null");
                                }
                                UIRectTransform.SetPosY(this.data.hideBannerDurationAfterClick.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbHideBannerDurationAfterClick != null)
                                {
                                    lbHideBannerDurationAfterClick.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbHideBannerDurationAfterClick null");
                                }
                            }
                        }
                        // hideAdsWhenStartPlay
                        {
                            if (this.data.hideAdsWhenStartPlay.v != null)
                            {
                                if (lbHideAdsWhenStartPlay != null)
                                {
                                    lbHideAdsWhenStartPlay.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbHideAdsWhenStartPlay.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbHideAdsWhenStartPlay null");
                                }
                                UIRectTransform.SetPosY(this.data.hideAdsWhenStartPlay.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbHideAdsWhenStartPlay != null)
                                {
                                    lbHideAdsWhenStartPlay.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbHideAdsWhenStartPlay null");
                                }
                            }
                        }
                        // showAdsWhenGameEnd
                        {
                            if (this.data.showAdsWhenGameEnd.v != null)
                            {
                                if (lbShowAdsWhenGameEnd != null)
                                {
                                    lbShowAdsWhenGameEnd.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbShowAdsWhenGameEnd.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbShowAdsWhenGameEnd null");
                                }
                                UIRectTransform.SetPosY(this.data.showAdsWhenGameEnd.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbShowAdsWhenGameEnd != null)
                                {
                                    lbShowAdsWhenGameEnd.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbShowAdsWhenGameEnd null");
                                }
                            }
                        }
                        // reloadBannerInterval
                        {
                            if (this.data.reloadBannerInterval.v != null)
                            {
                                if (lbReloadBannerInterval != null)
                                {
                                    lbReloadBannerInterval.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbReloadBannerInterval.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbReloadBannerInterval null");
                                }
                                UIRectTransform.SetPosY(this.data.reloadBannerInterval.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbReloadBannerInterval != null)
                                {
                                    lbReloadBannerInterval.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbReloadBannerInterval null");
                                }
                            }
                        }
                        // admobVideoType
                        {
                            if (this.data.admobVideoType.v != null)
                            {
                                if (lbAdmobVideoType != null)
                                {
                                    lbAdmobVideoType.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbAdmobVideoType.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbAdmobVideoType null");
                                }
                                UIRectTransform.SetPosY(this.data.admobVideoType.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbAdmobVideoType != null)
                                {
                                    lbAdmobVideoType.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbAdmobVideoType null");
                                }
                            }
                        }
                        // set
                        UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get("Ads Manager");
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                        if (lbVideoType != null)
                        {
                            lbVideoType.text = txtVideoType.get("Video type");
                        }
                        else
                        {
                            Debug.LogError("lbVideoType null");
                        }
                        if (lbShowBtnViewAds != null)
                        {
                            lbShowBtnViewAds.text = txtShowBtnViewAds.get("Show btn view ads");
                        }
                        else
                        {
                            Debug.LogError("lbShowBtnViewAds null");
                        }
                        if (lbBannerType != null)
                        {
                            lbBannerType.text = txtBannerType.get("Banner type");
                        }
                        else
                        {
                            Debug.LogError("lbBannerType null");
                        }
                        if (lbHideBannerDurationAfterClick != null)
                        {
                            lbHideBannerDurationAfterClick.text = txtHideBannerDurationAfterClick.get("Hide banner");
                        }
                        else
                        {
                            Debug.LogError("lbHideBannerDurationAfterClick null");
                        }
                        if (lbHideAdsWhenStartPlay != null)
                        {
                            lbHideAdsWhenStartPlay.text = txtHideAdsWhenStartPlay.get("Hide ads when start play");
                        }
                        else
                        {
                            Debug.LogError("lbHideAdsWhenStartPlay null");
                        }
                        if (lbShowAdsWhenGameEnd != null)
                        {
                            lbShowAdsWhenGameEnd.text = txtShowAdsWhenGameEnd.get("Show banner when game end");
                        }
                        else
                        {
                            Debug.LogError("lbShowAdsWhenGameEnd null");
                        }
                        if (lbReloadBannerInterval != null)
                        {
                            lbReloadBannerInterval.text = txtReloadBannerInterval.get("Reload banner");
                        }
                        else
                        {
                            Debug.LogError("lbReloadBannerInterval null");
                        }
                        if (lbAdmobVideoType != null)
                        {
                            lbAdmobVideoType.text = txtAdmobVideoType.get("Admob video type");
                        }
                        else
                        {
                            Debug.LogError("lbAdmobVideoType null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("data null");
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public RequestChangeEnumUI requestEnumPrefab;
        public RequestChangeBoolUI requestBoolPrefab;
        public RequestChangeFloatUI requestFloatPrefab;

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
                                    UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, UIConstants.RequestEnumRect);
                                    break;
                                case UIData.Property.bannerType:
                                    UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, UIConstants.RequestEnumRect);
                                    break;
                                case UIData.Property.admobVideoType:
                                    UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, UIConstants.RequestEnumRect);
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
                // showBtnViewAds, hideAdsWhenStartPlay, showAdsWhenGameEnd,
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
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, UIConstants.RequestBoolRect);
                                    break;
                                case UIData.Property.hideAdsWhenStartPlay:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, UIConstants.RequestBoolRect);
                                    break;
                                case UIData.Property.showAdsWhenGameEnd:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, UIConstants.RequestBoolRect);
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
                                    UIUtils.Instantiate(requestChange, requestFloatPrefab, this.transform, UIConstants.RequestRect);
                                    break;
                                case UIData.Property.reloadBannerInterval:
                                    UIUtils.Instantiate(requestChange, requestFloatPrefab, this.transform, UIConstants.RequestRect);
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
                // showBtnViewAds, hideAdsWhenStartPlay, showAdsWhenGameEnd,
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
                            case AdsManager.Property.reloadBannerInterval:
                                dirty = true;
                                break;
                            case AdsManager.Property.lastReloadBannerTime:
                                break;
                            case AdsManager.Property.unityAdsBannerPlaceMentIds:
                                break;
                            case AdsManager.Property.admobAppId:
                                break;
                            case AdsManager.Property.admobAdUnitId:
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
                // showBtnViewAds, hideAdsWhenStartPlay, showAdsWhenGameEnd,
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
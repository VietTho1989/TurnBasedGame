using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace CoTuongUp
{
    public class DefaultCoTuongUpUI : UIHaveTransformDataBehavior<DefaultCoTuongUpUI.UIData>
    {

        #region UIData

        public class UIData : DefaultGameTypeUI
        {

            public VP<EditData<DefaultCoTuongUp>> editDefaultCoTuongUp;

            public VP<UIRectTransform.ShowType> showType;

            #region allowViewCaputre

            public VP<RequestChangeBoolUI.UIData> allowViewCapture;

            public void makeRequestChangeAllowViewCapture(RequestChangeUpdate<bool>.UpdateData update, bool newAllowViewCapture)
            {
                // Find
                DefaultCoTuongUp defaultCoTuongUp = null;
                {
                    EditData<DefaultCoTuongUp> editDefaultCoTuongUp = this.editDefaultCoTuongUp.v;
                    if (editDefaultCoTuongUp != null)
                    {
                        defaultCoTuongUp = editDefaultCoTuongUp.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultCoTuongUp null: " + this);
                    }
                }
                // Process
                if (defaultCoTuongUp != null)
                {
                    defaultCoTuongUp.requestChangeAllowViewCapture(Server.getProfileUserId(defaultCoTuongUp), newAllowViewCapture);
                }
                else
                {
                    Debug.LogError("defaultCoTuongUp null: " + this);
                }
            }

            #endregion

            #region allowWatcherViewHidden

            public VP<RequestChangeBoolUI.UIData> allowWatcherViewHidden;

            public void makeRequestChangeAllowWatcherViewHidden(RequestChangeUpdate<bool>.UpdateData update, bool newAllowWatcherViewHidden)
            {
                // Find
                DefaultCoTuongUp defaultCoTuongUp = null;
                {
                    EditData<DefaultCoTuongUp> editDefaultCoTuongUp = this.editDefaultCoTuongUp.v;
                    if (editDefaultCoTuongUp != null)
                    {
                        defaultCoTuongUp = editDefaultCoTuongUp.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultCoTuongUp null: " + this);
                    }
                }
                // Process
                if (defaultCoTuongUp != null)
                {
                    defaultCoTuongUp.requestChangeAllowWatcherViewHidden(Server.getProfileUserId(defaultCoTuongUp), newAllowWatcherViewHidden);
                }
                else
                {
                    Debug.LogError("defaultCoTuongUp null: " + this);
                }
            }

            #endregion

            #region allowOnlyFlip

            public VP<RequestChangeBoolUI.UIData> allowOnlyFlip;

            public void makeRequestChangeAllowOnlyFlip(RequestChangeUpdate<bool>.UpdateData update, bool newAllowOnlyFlip)
            {
                // Find
                DefaultCoTuongUp defaultCoTuongUp = null;
                {
                    EditData<DefaultCoTuongUp> editDefaultCoTuongUp = this.editDefaultCoTuongUp.v;
                    if (editDefaultCoTuongUp != null)
                    {
                        defaultCoTuongUp = editDefaultCoTuongUp.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultCoTuongUp null: " + this);
                    }
                }
                // Process
                if (defaultCoTuongUp != null)
                {
                    defaultCoTuongUp.requestChangeAllowOnlyFlip(Server.getProfileUserId(defaultCoTuongUp), newAllowOnlyFlip);
                }
                else
                {
                    Debug.LogError("defaultCoTuongUp null: " + this);
                }
            }

            #endregion

            public VP<MiniGameDataUI.UIData> miniGameDataUIData;

            #region Constructor

            public enum Property
            {
                editDefaultCoTuongUp,
                showType,

                allowViewCapture,
                allowWatcherViewHidden,
                allowOnlyFlip,

                miniGameDataUIData
            }

            public UIData() : base()
            {
                this.editDefaultCoTuongUp = new VP<EditData<DefaultCoTuongUp>>(this, (byte)Property.editDefaultCoTuongUp, new EditData<DefaultCoTuongUp>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // allowViewCapture
                {
                    this.allowViewCapture = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.allowViewCapture, new RequestChangeBoolUI.UIData());
                    // event
                    this.allowViewCapture.v.updateData.v.request.v = makeRequestChangeAllowViewCapture;
                }
                // allowWatcherViewHidden
                {
                    this.allowWatcherViewHidden = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.allowWatcherViewHidden, new RequestChangeBoolUI.UIData());
                    // event
                    this.allowWatcherViewHidden.v.updateData.v.request.v = makeRequestChangeAllowWatcherViewHidden;
                }
                // allowOnlyFlip
                {
                    this.allowOnlyFlip = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.allowOnlyFlip, new RequestChangeBoolUI.UIData());
                    // event
                    this.allowOnlyFlip.v.updateData.v.request.v = makeRequestChangeAllowOnlyFlip;
                }
                this.miniGameDataUIData = new VP<MiniGameDataUI.UIData>(this, (byte)Property.miniGameDataUIData, new MiniGameDataUI.UIData());
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.CO_TUONG_UP;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        public static readonly TxtLanguage txtTitle = new TxtLanguage();

        public Text lbAllowViewCapture;
        public static readonly TxtLanguage txtAllowViewCapture = new TxtLanguage();

        public Text lbAllowWatcherViewHidden;
        public static readonly TxtLanguage txtAllowWatcherViewHidden = new TxtLanguage();

        public Text lbAllowOnlyFlip;
        public static readonly TxtLanguage txtAllowOnlyFlip = new TxtLanguage();

        static DefaultCoTuongUpUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Mặc Định Cờ Úp");
                txtAllowViewCapture.add(Language.Type.vi, "Cho phép xem quân bị bắt");
                txtAllowWatcherViewHidden.add(Language.Type.vi, "Cho phép người xem xem quân úp");
                txtAllowOnlyFlip.add(Language.Type.vi, "Cho phép chỉ lập");
            }
            // rect
            {
                allowViewCaptureRect.setPosY(UIConstants.HeaderHeight + UIConstants.DefaultMiniGameDataUISize + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                allowWatcherViewHiddenRect.setPosY(UIConstants.HeaderHeight + UIConstants.DefaultMiniGameDataUISize + 1 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                allowOnlyFlipRect.setPosY(UIConstants.HeaderHeight + UIConstants.DefaultMiniGameDataUISize + 2 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
            }
        }

        #endregion

        #region Refresh

        private bool needReset = true;
        private bool miniGameDataDirty = true;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EditData<DefaultCoTuongUp> editDefaultCoTuongUp = this.data.editDefaultCoTuongUp.v;
                    if (editDefaultCoTuongUp != null)
                    {
                        editDefaultCoTuongUp.update();
                        // get show
                        DefaultCoTuongUp show = editDefaultCoTuongUp.show.v.data;
                        DefaultCoTuongUp compare = editDefaultCoTuongUp.compare.v.data;
                        if (show != null)
                        {
                            // different
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editDefaultCoTuongUp.compareOtherType.v.data != null)
                                    {
                                        if (editDefaultCoTuongUp.compareOtherType.v.data.GetType() != show.GetType())
                                        {
                                            isDifferent = true;
                                        }
                                    }
                                }
                                lbTitle.color = isDifferent ? UIConstants.DifferentIndicatorColor : UIConstants.NormalTitleColor;
                            }
                            else
                            {
                                Debug.LogError("differentIndicator null: " + this);
                            }
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = Server.State.Type.Connect;
                                {
                                    Server server = show.findDataInParent<Server>();
                                    if (server != null)
                                    {
                                        if (server.state.v != null)
                                        {
                                            serverState = server.state.v.getType();
                                        }
                                        else
                                        {
                                            Debug.LogError("server state null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("server null: " + this);
                                    }
                                }
                                // set origin
                                {
                                    // allowViewCapture
                                    {
                                        RequestChangeBoolUI.UIData allowViewCapture = this.data.allowViewCapture.v;
                                        if (allowViewCapture != null)
                                        {
                                            // update
                                            RequestChangeUpdate<bool>.UpdateData updateData = allowViewCapture.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.allowViewCapture.v;
                                                updateData.canRequestChange.v = editDefaultCoTuongUp.canEdit.v;
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
                                                    allowViewCapture.showDifferent.v = true;
                                                    allowViewCapture.compare.v = compare.allowViewCapture.v;
                                                }
                                                else
                                                {
                                                    allowViewCapture.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("allowViewCapture null: " + this);
                                        }
                                    }
                                    // allowWatcherViewHidden
                                    {
                                        RequestChangeBoolUI.UIData allowWatcherViewHidden = this.data.allowWatcherViewHidden.v;
                                        if (allowWatcherViewHidden != null)
                                        {
                                            // update
                                            RequestChangeUpdate<bool>.UpdateData updateData = allowWatcherViewHidden.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.allowWatcherViewHidden.v;
                                                updateData.canRequestChange.v = editDefaultCoTuongUp.canEdit.v;
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
                                                    allowWatcherViewHidden.showDifferent.v = true;
                                                    allowWatcherViewHidden.compare.v = compare.allowWatcherViewHidden.v;
                                                }
                                                else
                                                {
                                                    allowWatcherViewHidden.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("allowWatcherViewHidden null: " + this);
                                        }
                                    }
                                    // allowOnlyFlip
                                    {
                                        RequestChangeBoolUI.UIData allowOnlyFlip = this.data.allowOnlyFlip.v;
                                        if (allowOnlyFlip != null)
                                        {
                                            // update
                                            RequestChangeUpdate<bool>.UpdateData updateData = allowOnlyFlip.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.allowOnlyFlip.v;
                                                updateData.canRequestChange.v = editDefaultCoTuongUp.canEdit.v;
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
                                                    allowOnlyFlip.showDifferent.v = true;
                                                    allowOnlyFlip.compare.v = compare.allowOnlyFlip.v;
                                                }
                                                else
                                                {
                                                    allowOnlyFlip.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("allowOnlyFlip null: " + this);
                                        }
                                    }
                                }
                                // reset?
                                if (needReset)
                                {
                                    needReset = false;
                                    // allowViewCapture
                                    {
                                        RequestChangeBoolUI.UIData allowViewCapture = this.data.allowViewCapture.v;
                                        if (allowViewCapture != null)
                                        {
                                            // update
                                            RequestChangeUpdate<bool>.UpdateData updateData = allowViewCapture.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.current.v = show.allowViewCapture.v;
                                                updateData.changeState.v = Data.ChangeState.None;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("allowViewCapture null: " + this);
                                        }
                                    }
                                    // allowWatcherViewHidden
                                    {
                                        RequestChangeBoolUI.UIData allowWatcherViewHidden = this.data.allowWatcherViewHidden.v;
                                        if (allowWatcherViewHidden != null)
                                        {
                                            // update
                                            RequestChangeUpdate<bool>.UpdateData updateData = allowWatcherViewHidden.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.current.v = show.allowWatcherViewHidden.v;
                                                updateData.changeState.v = Data.ChangeState.None;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("allowWatcherViewHidden null: " + this);
                                        }
                                    }
                                    // allowOnlyFlip
                                    {
                                        RequestChangeBoolUI.UIData allowOnlyFlip = this.data.allowOnlyFlip.v;
                                        if (allowOnlyFlip != null)
                                        {
                                            // update
                                            RequestChangeUpdate<bool>.UpdateData updateData = allowOnlyFlip.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.current.v = show.allowOnlyFlip.v;
                                                updateData.changeState.v = Data.ChangeState.None;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("allowOnlyFlip null: " + this);
                                        }
                                    }
                                }
                            }
                            // miniGameDataUIData
                            if (miniGameDataDirty)
                            {
                                miniGameDataDirty = false;
                                // find miniGameDataUIData
                                MiniGameDataUI.UIData miniGameDataUIData = this.data.miniGameDataUIData.newOrOld<MiniGameDataUI.UIData>();
                                // Update Property
                                {
                                    // gameData
                                    {
                                        // Find GameData
                                        GameData gameData = null;
                                        {
                                            // Find old
                                            if (miniGameDataUIData.gameData.v.data != null)
                                            {
                                                gameData = miniGameDataUIData.gameData.v.data;
                                            }
                                            // Make new
                                            if (gameData == null)
                                            {
                                                gameData = new GameData();
                                                miniGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                        }
                                        // Update Property
                                        {
                                            // GameType
                                            {
                                                // Find coTuongUp
                                                CoTuongUp coTuongUp = gameData.gameType.newOrOld<CoTuongUp>();
                                                {
                                                    CoTuongUp defaultCoTuongUp = (CoTuongUp)show.makeDefaultGameType();
                                                    {
                                                        if (defaultCoTuongUp.nodes.vs.Count > 0)
                                                        {
                                                            Node node = defaultCoTuongUp.nodes.vs[defaultCoTuongUp.nodes.vs.Count - 1];
                                                            for (int i = 0; i < node.pieces.vs.Count; i++)
                                                            {
                                                                byte piece = node.pieces.vs[i];
                                                                if (Common.Visibility.isHide(piece))
                                                                {
                                                                    if (Common.getPieceSide(piece) == Common.Side.Red)
                                                                    {
                                                                        node.pieces.set(i, Common.HP);
                                                                    }
                                                                    else
                                                                    {
                                                                        node.pieces.set(i, Common.hp);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("why node count 0: " + this);
                                                        }
                                                    }
                                                    // Copy
                                                    DataUtils.copyData(coTuongUp, defaultCoTuongUp);
                                                }
                                                gameData.gameType.v = coTuongUp;
                                            }
                                        }
                                    }
                                }
                                this.data.miniGameDataUIData.v = miniGameDataUIData;
                            }
                        }
                        else
                        {
                            Debug.LogError("defaultCoTuongUp null: " + this);
                        }
                        // UI
                        {
                            float deltaY = 0;
                            // header
                            {
                                switch (this.data.showType.v)
                                {
                                    case UIRectTransform.ShowType.Normal:
                                        {
                                            if (lbTitle != null)
                                            {
                                                lbTitle.gameObject.SetActive(true);
                                            }
                                            else
                                            {
                                                Debug.LogError("lbTitle null");
                                            }
                                            deltaY += UIConstants.HeaderHeight;
                                        }
                                        break;
                                    case UIRectTransform.ShowType.HeadLess:
                                        {
                                            if (lbTitle != null)
                                            {
                                                lbTitle.gameObject.SetActive(false);
                                            }
                                            else
                                            {
                                                Debug.LogError("lbTitle null");
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown showType: " + this.data.showType.v);
                                        break;
                                }
                            }
                            // miniGameDataUI
                            {
                                UIRectTransform.SetPosY(this.data.miniGameDataUIData.v, deltaY + UIConstants.DefaultMiniGameDataUIPadding);
                                deltaY += UIConstants.DefaultMiniGameDataUISize;
                            }
                            // allowViewCapture
                            {
                                if (this.data.allowViewCapture.v != null)
                                {
                                    if (lbAllowViewCapture != null)
                                    {
                                        lbAllowViewCapture.gameObject.SetActive(true);
                                        UIRectTransform.SetPosY(lbAllowViewCapture.rectTransform, deltaY);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbAllowViewCapture null");
                                    }
                                    UIRectTransform.SetPosY(this.data.allowViewCapture.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                                    deltaY += UIConstants.ItemHeight;
                                }
                                else
                                {
                                    if (lbAllowViewCapture != null)
                                    {
                                        lbAllowViewCapture.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbAllowViewCapture null");
                                    }
                                }
                            }
                            // allowWatcherViewHidden
                            {
                                if (this.data.allowWatcherViewHidden.v != null)
                                {
                                    if (lbAllowWatcherViewHidden != null)
                                    {
                                        lbAllowWatcherViewHidden.gameObject.SetActive(true);
                                        UIRectTransform.SetPosY(lbAllowWatcherViewHidden.rectTransform, deltaY);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbAllowWatcherViewHidden null");
                                    }
                                    UIRectTransform.SetPosY(this.data.allowWatcherViewHidden.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                                    deltaY += UIConstants.ItemHeight;
                                }
                                else
                                {
                                    if (lbAllowWatcherViewHidden != null)
                                    {
                                        lbAllowWatcherViewHidden.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbAllowWatcherViewHidden null");
                                    }
                                }
                            }
                            // allowOnlyFlip
                            {
                                if (this.data.allowOnlyFlip.v != null)
                                {
                                    if (lbAllowOnlyFlip != null)
                                    {
                                        lbAllowOnlyFlip.gameObject.SetActive(true);
                                        UIRectTransform.SetPosY(lbAllowOnlyFlip.rectTransform, deltaY);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbAllowOnlyFlip null");
                                    }
                                    UIRectTransform.SetPosY(this.data.allowOnlyFlip.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                                    deltaY += UIConstants.ItemHeight;
                                }
                                else
                                {
                                    if (lbAllowOnlyFlip != null)
                                    {
                                        lbAllowOnlyFlip.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbAllowOnlyFlip null");
                                    }
                                }
                            }
                            // Set
                            UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                        }
                        // txt
                        {
                            if (lbTitle != null)
                            {
                                lbTitle.text = txtTitle.get("Default Hidden Chinese Chess");
                            }
                            else
                            {
                                Debug.LogError("lbTitle null: " + this);
                            }
                            if (lbAllowViewCapture != null)
                            {
                                lbAllowViewCapture.text = txtAllowViewCapture.get("Allow view capture");
                            }
                            else
                            {
                                Debug.LogError("lbAllowViewCapture null: " + this);
                            }
                            if (lbAllowWatcherViewHidden != null)
                            {
                                lbAllowWatcherViewHidden.text = txtAllowWatcherViewHidden.get("Allow watcher view hidden");
                            }
                            else
                            {
                                Debug.LogError("lbAllowWatcherViewHidden null: " + this);
                            }
                            if (lbAllowOnlyFlip != null)
                            {
                                lbAllowOnlyFlip.text = txtAllowOnlyFlip.get("Allow only flip");
                            }
                            else
                            {
                                Debug.LogError("lbAllowOnlyFlip null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("editDefaultCoTuongUp null: " + this);
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

        public MiniGameDataUI miniGameDataUIPrefab;

        public RequestChangeBoolUI requestBoolPrefab;

        public static readonly UIRectTransform allowViewCaptureRect = new UIRectTransform(UIConstants.RequestBoolRect);
        public static readonly UIRectTransform allowWatcherViewHiddenRect = new UIRectTransform(UIConstants.RequestBoolRect);
        public static readonly UIRectTransform allowOnlyFlipRect = new UIRectTransform(UIConstants.RequestBoolRect);

        private Server server = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.editDefaultCoTuongUp.allAddCallBack(this);
                    uiData.allowViewCapture.allAddCallBack(this);
                    uiData.allowWatcherViewHidden.allAddCallBack(this);
                    uiData.allowOnlyFlip.allAddCallBack(this);
                    uiData.miniGameDataUIData.allAddCallBack(this);
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
                // editDefaultCoTuongUp
                {
                    if (data is EditData<DefaultCoTuongUp>)
                    {
                        EditData<DefaultCoTuongUp> editDefaultCoTuongUp = data as EditData<DefaultCoTuongUp>;
                        // Child
                        {
                            editDefaultCoTuongUp.show.allAddCallBack(this);
                            editDefaultCoTuongUp.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is DefaultCoTuongUp)
                        {
                            DefaultCoTuongUp defaultCoTuongUp = data as DefaultCoTuongUp;
                            // Parent
                            {
                                DataUtils.addParentCallBack(defaultCoTuongUp, this, ref this.server);
                            }
                            needReset = true;
                            miniGameDataDirty = true;
                            dirty = true;
                            return;
                        }
                        // Parent
                        {
                            if (data is Server)
                            {
                                dirty = true;
                                return;
                            }
                        }
                    }
                }
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
                                case UIData.Property.allowViewCapture:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, allowViewCaptureRect);
                                    break;
                                case UIData.Property.allowWatcherViewHidden:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, allowWatcherViewHiddenRect);
                                    break;
                                case UIData.Property.allowOnlyFlip:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, allowOnlyFlipRect);
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
                // MiniGameDataUIData
                {
                    if (data is MiniGameDataUI.UIData)
                    {
                        MiniGameDataUI.UIData miniGameDataUIData = data as MiniGameDataUI.UIData;
                        // UI
                        {
                            UIUtils.Instantiate(miniGameDataUIData, miniGameDataUIPrefab, this.transform, UIConstants.MiniGameDataUIRect);
                        }
                        // Child
                        {
                            miniGameDataUIData.gameData.allAddCallBack(this);
                        }
                        miniGameDataDirty = true;
                        dirty = true;
                        return;
                    }
                    // GameData
                    {
                        if (data is GameData)
                        {
                            GameData gameData = data as GameData;
                            {
                                gameData.gameType.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // GameType
                        {
                            data.addCallBackAllChildren(this);
                            dirty = true;
                            return;
                        }
                    }
                }
            }
            // Debug.LogError ("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().removeCallBack(this);
                // Child
                {
                    uiData.editDefaultCoTuongUp.allRemoveCallBack(this);
                    uiData.allowViewCapture.allRemoveCallBack(this);
                    uiData.allowWatcherViewHidden.allRemoveCallBack(this);
                    uiData.allowOnlyFlip.allRemoveCallBack(this);
                    uiData.miniGameDataUIData.allRemoveCallBack(this);
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
                // editDefaultCoTuongUp
                {
                    if (data is EditData<DefaultCoTuongUp>)
                    {
                        EditData<DefaultCoTuongUp> editDefaultCoTuongUp = data as EditData<DefaultCoTuongUp>;
                        // Child
                        {
                            editDefaultCoTuongUp.show.allRemoveCallBack(this);
                            editDefaultCoTuongUp.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is DefaultCoTuongUp)
                        {
                            DefaultCoTuongUp defaultCoTuongUp = data as DefaultCoTuongUp;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(defaultCoTuongUp, this, ref this.server);
                            }
                            return;
                        }
                        // Parent
                        {
                            if (data is Server)
                            {
                                return;
                            }
                        }
                    }
                }
                if (data is RequestChangeBoolUI.UIData)
                {
                    RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeBoolUI));
                    }
                    return;
                }
                // MiniGameDataUIData
                {
                    if (data is MiniGameDataUI.UIData)
                    {
                        MiniGameDataUI.UIData miniGameDataUIData = data as MiniGameDataUI.UIData;
                        // UI
                        {
                            miniGameDataUIData.removeCallBackAndDestroy(typeof(MiniGameDataUI));
                        }
                        // Child
                        {
                            miniGameDataUIData.gameData.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // GameData
                    {
                        if (data is GameData)
                        {
                            GameData gameData = data as GameData;
                            {
                                gameData.gameType.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // GameType
                        {
                            data.removeCallBackAllChildren(this);
                            return;
                        }
                    }
                }
            }
            // Debug.LogError ("Don't process: " + data + "; " + this);
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
                    case UIData.Property.editDefaultCoTuongUp:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.allowViewCapture:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.allowWatcherViewHidden:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.allowOnlyFlip:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.miniGameDataUIData:
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
            {
                // EditDefaultCoTuongUp
                {
                    if (wrapProperty.p is EditData<DefaultCoTuongUp>)
                    {
                        switch ((EditData<DefaultCoTuongUp>.Property)wrapProperty.n)
                        {
                            case EditData<DefaultCoTuongUp>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<DefaultCoTuongUp>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<DefaultCoTuongUp>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<DefaultCoTuongUp>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<DefaultCoTuongUp>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<DefaultCoTuongUp>.Property.editType:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    {
                        if (wrapProperty.p is DefaultCoTuongUp)
                        {
                            switch ((DefaultCoTuongUp.Property)wrapProperty.n)
                            {
                                case DefaultCoTuongUp.Property.allowViewCapture:
                                    miniGameDataDirty = true;
                                    dirty = true;
                                    break;
                                case DefaultCoTuongUp.Property.allowWatcherViewHidden:
                                    miniGameDataDirty = true;
                                    dirty = true;
                                    break;
                                case DefaultCoTuongUp.Property.allowOnlyFlip:
                                    miniGameDataDirty = true;
                                    dirty = true;
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        if (wrapProperty.p is Server)
                        {
                            Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                            return;
                        }
                    }
                }
                if (wrapProperty.p is RequestChangeBoolUI.UIData)
                {
                    return;
                }
                // MiniGameDataUIData
                {
                    if (wrapProperty.p is MiniGameDataUI.UIData)
                    {
                        switch ((MiniGameDataUI.UIData.Property)wrapProperty.n)
                        {
                            case MiniGameDataUI.UIData.Property.gameData:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case MiniGameDataUI.UIData.Property.board:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // GameData
                    {
                        if (wrapProperty.p is GameData)
                        {
                            switch ((GameData.Property)wrapProperty.n)
                            {
                                case GameData.Property.gameType:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
                                    break;
                                case GameData.Property.useRule:
                                    break;
                                case GameData.Property.turn:
                                    break;
                                case GameData.Property.timeControl:
                                    break;
                                case GameData.Property.lastMove:
                                    break;
                                case GameData.Property.state:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // GameType
                        {
                            if (Generic.IsAddCallBackInterface<T>())
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                            }
                            dirty = true;
                            return;
                        }
                    }
                }
            }
            // Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
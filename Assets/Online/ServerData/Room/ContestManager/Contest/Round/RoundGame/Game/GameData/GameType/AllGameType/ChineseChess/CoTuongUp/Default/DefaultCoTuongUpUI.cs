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

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.CO_TUONG_UP ? 1 : 0;
        }

        #region txt

        public Text lbTitle;
        public static readonly TxtLanguage txtTitle = new TxtLanguage("Default Hidden Chinese Chess");

        public Text lbAllowViewCapture;
        public static readonly TxtLanguage txtAllowViewCapture = new TxtLanguage("Allow view capture");

        public Text lbAllowWatcherViewHidden;
        public static readonly TxtLanguage txtAllowWatcherViewHidden = new TxtLanguage("Allow watcher view hidden");

        public Text lbAllowOnlyFlip;
        public static readonly TxtLanguage txtAllowOnlyFlip = new TxtLanguage("Allow only flip");

        static DefaultCoTuongUpUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Mặc Định Cờ Úp");
                txtAllowViewCapture.add(Language.Type.vi, "Cho phép xem quân bị bắt");
                txtAllowWatcherViewHidden.add(Language.Type.vi, "Cho phép người xem xem quân úp");
                txtAllowOnlyFlip.add(Language.Type.vi, "Cho phép chỉ lập");
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
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editDefaultCoTuongUp);
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = RequestChange.GetServerState(editDefaultCoTuongUp);
                                // set origin
                                {
                                    RequestChange.RefreshUI(this.data.allowViewCapture.v, editDefaultCoTuongUp, serverState, needReset, editData => editData.allowViewCapture.v);
                                    RequestChange.RefreshUI(this.data.allowWatcherViewHidden.v, editDefaultCoTuongUp, serverState, needReset, editData => editData.allowWatcherViewHidden.v);
                                    RequestChange.RefreshUI(this.data.allowOnlyFlip.v, editDefaultCoTuongUp, serverState, needReset, editData => editData.allowOnlyFlip.v);
                                }
                                needReset = false;
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
                                                    // find new
                                                    CoTuongUp newCoTuongUp = null;
                                                    {
                                                        DefaultCoTuongUp show = editDefaultCoTuongUp.show.v.data;
                                                        if (show != null)
                                                        {
                                                            newCoTuongUp = (CoTuongUp)show.makeDefaultGameType();
                                                            {
                                                                if (newCoTuongUp.nodes.vs.Count > 0)
                                                                {
                                                                    Node node = newCoTuongUp.nodes.vs[newCoTuongUp.nodes.vs.Count - 1];
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
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("show nul");
                                                        }
                                                    }
                                                    // Copy
                                                    DataUtils.copyData(coTuongUp, newCoTuongUp);
                                                }
                                                gameData.gameType.v = coTuongUp;
                                            }
                                        }
                                    }
                                }
                                this.data.miniGameDataUIData.v = miniGameDataUIData;
                            }
                        }
                        // UI
                        {
                            float deltaY = 0;
                            // header
                            UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                            // miniGameDataUI
                            {
                                UIRectTransform.SetPosY(this.data.miniGameDataUIData.v, deltaY + UIConstants.DefaultMiniGameDataUIPadding);
                                deltaY += UIConstants.DefaultMiniGameDataUISize;
                            }
                            // allowViewCapture
                            UIUtils.SetLabelContentPosition(lbAllowViewCapture, this.data.allowViewCapture.v, ref deltaY);
                            // allowWatcherViewHidden
                            UIUtils.SetLabelContentPosition(lbAllowWatcherViewHidden, this.data.allowWatcherViewHidden.v, ref deltaY);
                            // allowOnlyFlip
                            UIUtils.SetLabelContentPosition(lbAllowOnlyFlip, this.data.allowOnlyFlip.v, ref deltaY);
                            // Set
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
                                Debug.LogError("lbTitle null: " + this);
                            }
                            if (lbAllowViewCapture != null)
                            {
                                lbAllowViewCapture.text = txtAllowViewCapture.get();
                                Setting.get().setLabelTextSize(lbAllowViewCapture);
                            }
                            else
                            {
                                Debug.LogError("lbAllowViewCapture null: " + this);
                            }
                            if (lbAllowWatcherViewHidden != null)
                            {
                                lbAllowWatcherViewHidden.text = txtAllowWatcherViewHidden.get();
                                Setting.get().setLabelTextSize(lbAllowWatcherViewHidden);
                            }
                            else
                            {
                                Debug.LogError("lbAllowWatcherViewHidden null: " + this);
                            }
                            if (lbAllowOnlyFlip != null)
                            {
                                lbAllowOnlyFlip.text = txtAllowOnlyFlip.get();
                                Setting.get().setLabelTextSize(lbAllowOnlyFlip);
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
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestBool, this.transform, UIConstants.RequestBoolRect);
                                    break;
                                case UIData.Property.allowWatcherViewHidden:
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestBool, this.transform, UIConstants.RequestBoolRect);
                                    break;
                                case UIData.Property.allowOnlyFlip:
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
                    case Setting.Property.confirmQuit:
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
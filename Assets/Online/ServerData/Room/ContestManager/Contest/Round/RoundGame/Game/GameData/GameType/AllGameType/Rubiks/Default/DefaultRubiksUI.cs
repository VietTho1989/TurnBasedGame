using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Rubiks
{
    public class DefaultRubiksUI : UIHaveTransformDataBehavior<DefaultRubiksUI.UIData>
    {

        #region UIData

        public class UIData : DefaultGameTypeUI
        {

            public VP<EditData<DefaultRubiks>> editDefaultRubiks;

            public VP<UIRectTransform.ShowType> showType;

            #region dimension

            public VP<RequestChangeIntUI.UIData> dimension;

            public void makeRequestChangeDimension(RequestChangeUpdate<int>.UpdateData update, int newDimension)
            {
                // Find
                DefaultRubiks defaultRubiks = null;
                {
                    EditData<DefaultRubiks> editDefaultRubiks = this.editDefaultRubiks.v;
                    if (editDefaultRubiks != null)
                    {
                        defaultRubiks = editDefaultRubiks.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultRubiks null: " + this);
                    }
                }
                // Process
                if (defaultRubiks != null)
                {
                    defaultRubiks.requestChangeDimension(Server.getProfileUserId(defaultRubiks), newDimension);
                }
                else
                {
                    Debug.LogError("defaultRubiks null: " + this);
                }
            }

            #endregion

            #region scrambleCount

            public VP<RequestChangeIntUI.UIData> scrambleCount;

            public void makeRequestChangeScrambleCount(RequestChangeUpdate<int>.UpdateData update, int newScrambleCount)
            {
                // Find
                DefaultRubiks defaultRubiks = null;
                {
                    EditData<DefaultRubiks> editDefaultRubiks = this.editDefaultRubiks.v;
                    if (editDefaultRubiks != null)
                    {
                        defaultRubiks = editDefaultRubiks.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultRubiks null: " + this);
                    }
                }
                // Process
                if (defaultRubiks != null)
                {
                    defaultRubiks.requestChangeScrambleCount(Server.getProfileUserId(defaultRubiks), newScrambleCount);
                }
                else
                {
                    Debug.LogError("defaultRubiks null: " + this);
                }
            }

            #endregion

            #region canFinish

            public VP<RequestChangeBoolUI.UIData> canFinish;

            public void makeRequestChangeCanFinish(RequestChangeUpdate<bool>.UpdateData update, bool newCanFinish)
            {
                // Find
                DefaultRubiks defaultRubiks = null;
                {
                    EditData<DefaultRubiks> editDefaultRubiks = this.editDefaultRubiks.v;
                    if (editDefaultRubiks != null)
                    {
                        defaultRubiks = editDefaultRubiks.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultRubiks null: " + this);
                    }
                }
                // Process
                if (defaultRubiks != null)
                {
                    defaultRubiks.requestChangeCanFinish(Server.getProfileUserId(defaultRubiks), newCanFinish);
                }
                else
                {
                    Debug.LogError("defaultRubiks null: " + this);
                }
            }

            #endregion

            public VP<MiniGameDataUI.UIData> miniGameDataUIData;

            #region Constructor

            public enum Property
            {
                editDefaultRubiks,
                showType,
                dimension,
                scrambleCount,
                canFinish,
                miniGameDataUIData
            }

            public UIData() : base()
            {
                this.editDefaultRubiks = new VP<EditData<DefaultRubiks>>(this, (byte)Property.editDefaultRubiks, new EditData<DefaultRubiks>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // dimension
                {
                    this.dimension = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.dimension, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.dimension.v.limit.makeId();
                            have.min.v = Rubiks.MinDimension;
                            have.max.v = Rubiks.MaxDimension;
                        }
                        this.dimension.v.limit.v = have;
                    }
                    // event
                    this.dimension.v.updateData.v.request.v = makeRequestChangeDimension;
                }
                // scrambleCount
                {
                    this.scrambleCount = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.scrambleCount, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.scrambleCount.v.limit.makeId();
                            have.min.v = DefaultRubiks.MinScrambleCount;
                            have.max.v = DefaultRubiks.MaxScrambleCount;
                        }
                        this.scrambleCount.v.limit.v = have;
                    }
                    // event
                    this.scrambleCount.v.updateData.v.request.v = makeRequestChangeScrambleCount;
                }
                // canFinish
                {
                    this.canFinish = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.canFinish, new RequestChangeBoolUI.UIData());
                    // event
                    this.canFinish.v.updateData.v.request.v = makeRequestChangeCanFinish;
                }
                this.miniGameDataUIData = new VP<MiniGameDataUI.UIData>(this, (byte)Property.miniGameDataUIData, new MiniGameDataUI.UIData());
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.Rubiks;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Default Rubiks");

        public Text lbDimension;
        private static readonly TxtLanguage txtDimension = new TxtLanguage("Dimension");

        public Text lbScrambleCount;
        private static readonly TxtLanguage txtScrambleCount = new TxtLanguage("Scramble count");

        public Text lbCanFinish;
        private static readonly TxtLanguage txtCanFinish = new TxtLanguage("Can finish");

        static DefaultRubiksUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Rubiks Mặc Định");
                txtDimension.add(Language.Type.vi, "Kích thước");
                txtScrambleCount.add(Language.Type.vi, "Số lần xoay trước");
                txtCanFinish.add(Language.Type.vi, "Có thể kết thúc");
            }
        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Rubiks ? 1 : 0;
        }

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
                    EditData<DefaultRubiks> editDefaultRubiks = this.data.editDefaultRubiks.v;
                    if (editDefaultRubiks != null)
                    {
                        editDefaultRubiks.update();
                        // UI
                        {
                            // differentIndicator
                            RequestChange.ShowDifferentTitle(lbTitle, editDefaultRubiks);
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = RequestChange.GetServerState(editDefaultRubiks);
                                // set origin
                                {
                                    RequestChange.RefreshUI(this.data.dimension.v, editDefaultRubiks, serverState, needReset, editData => editData.dimension.v);
                                    RequestChange.RefreshUI(this.data.scrambleCount.v, editDefaultRubiks, serverState, needReset, editData => editData.scrambleCount.v);
                                    RequestChange.RefreshUI(this.data.canFinish.v, editDefaultRubiks, serverState, needReset, editData => editData.canFinish.v);
                                }
                                needReset = false;
                            }
                            // miniGameDataUIData
                            if (miniGameDataDirty)
                            {
                                // find miniGameDataUIData
                                MiniGameDataUI.UIData miniGameDataUIData = this.data.miniGameDataUIData.newOrOld<MiniGameDataUI.UIData>();
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
                                                // Find Rubiks
                                                Rubiks rubiks = gameData.gameType.newOrOld<Rubiks>();
                                                {
                                                    // Make new rubiks
                                                    Rubiks newRubiks = null;
                                                    {
                                                        DefaultRubiks show = editDefaultRubiks.show.v.data;
                                                        if (show != null)
                                                        {
                                                            newRubiks = show.makeDefaultGameType() as Rubiks;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("show null");
                                                        }
                                                    }
                                                    // Copy
                                                    DataUtils.copyData(rubiks, newRubiks);
                                                }
                                                gameData.gameType.v = rubiks;
                                            }
                                        }
                                    }
                                }
                                this.data.miniGameDataUIData.v = miniGameDataUIData;
                                miniGameDataDirty = false;
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
                                // dimension
                                UIUtils.SetLabelContentPosition(lbDimension, this.data.dimension.v, ref deltaY);
                                // scrambleCount
                                UIUtils.SetLabelContentPosition(lbScrambleCount, this.data.scrambleCount.v, ref deltaY);
                                // canFinish
                                UIUtils.SetLabelContentPosition(lbCanFinish, this.data.canFinish.v, ref deltaY);
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
                                if (lbDimension != null)
                                {
                                    lbDimension.text = txtDimension.get();
                                    Setting.get().setLabelTextSize(lbDimension);
                                }
                                else
                                {
                                    Debug.LogError("lbDimension null");
                                }
                                if (lbScrambleCount != null)
                                {
                                    lbScrambleCount.text = txtScrambleCount.get();
                                    Setting.get().setLabelTextSize(lbScrambleCount);
                                }
                                else
                                {
                                    Debug.LogError("lbScrambleCount null");
                                }
                                if (lbCanFinish != null)
                                {
                                    lbCanFinish.text = txtCanFinish.get();
                                    Setting.get().setLabelTextSize(lbCanFinish);
                                }
                                else
                                {
                                    Debug.LogError("lbCanFinish null");
                                }
                            }
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
                    uiData.editDefaultRubiks.allAddCallBack(this);
                    uiData.dimension.allAddCallBack(this);
                    uiData.scrambleCount.allAddCallBack(this);
                    uiData.canFinish.allAddCallBack(this);
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
                // editDefaultRubiks
                {
                    if (data is EditData<DefaultRubiks>)
                    {
                        EditData<DefaultRubiks> editDefaultRubiks = data as EditData<DefaultRubiks>;
                        // Child
                        {
                            editDefaultRubiks.show.allAddCallBack(this);
                            editDefaultRubiks.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is DefaultRubiks)
                        {
                            DefaultRubiks defaultRubiks = data as DefaultRubiks;
                            // Parent
                            {
                                DataUtils.addParentCallBack(defaultRubiks, this, ref this.server);
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
                // dimension, scrambleCount
                if (data is RequestChangeIntUI.UIData)
                {
                    RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                    // UI
                    {
                        WrapProperty wrapProperty = requestChange.p;
                        if (wrapProperty != null)
                        {
                            switch ((UIData.Property)wrapProperty.n)
                            {
                                case UIData.Property.dimension:
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestInt, this.transform, UIConstants.RequestRect);
                                    break;
                                case UIData.Property.scrambleCount:
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestInt, this.transform, UIConstants.RequestRect);
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
                // canFinish
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
                                case UIData.Property.canFinish:
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
                            // Child
                            {
                                gameData.gameType.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
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
                    uiData.editDefaultRubiks.allRemoveCallBack(this);
                    uiData.dimension.allRemoveCallBack(this);
                    uiData.scrambleCount.allRemoveCallBack(this);
                    uiData.canFinish.allRemoveCallBack(this);
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
                // editDefaultRubiks
                {
                    if (data is EditData<DefaultRubiks>)
                    {
                        EditData<DefaultRubiks> editDefaultRubiks = data as EditData<DefaultRubiks>;
                        // Child
                        {
                            editDefaultRubiks.show.allRemoveCallBack(this);
                            editDefaultRubiks.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is DefaultRubiks)
                        {
                            DefaultRubiks defaultRubiks = data as DefaultRubiks;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(defaultRubiks, this, ref this.server);
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
                // dimension, scrambleCount
                if (data is RequestChangeIntUI.UIData)
                {
                    RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeIntUI));
                    }
                    return;
                }
                // canFinish
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
                            // Child
                            {
                                gameData.gameType.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // Child
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
                    case UIData.Property.editDefaultRubiks:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.dimension:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.scrambleCount:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.canFinish:
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
                // EditDefaultRubiks
                {
                    if (wrapProperty.p is EditData<DefaultRubiks>)
                    {
                        switch ((EditData<DefaultRubiks>.Property)wrapProperty.n)
                        {
                            case EditData<DefaultRubiks>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<DefaultRubiks>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<DefaultRubiks>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<DefaultRubiks>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<DefaultRubiks>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<DefaultRubiks>.Property.editType:
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
                        if (wrapProperty.p is DefaultRubiks)
                        {
                            switch ((DefaultRubiks.Property)wrapProperty.n)
                            {
                                case DefaultRubiks.Property.dimension:
                                    miniGameDataDirty = true;
                                    dirty = true;
                                    break;
                                case DefaultRubiks.Property.scrambleCount:
                                    miniGameDataDirty = true;
                                    dirty = true;
                                    break;
                                case DefaultRubiks.Property.canFinish:
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
                // dimension, scrambleCount
                if (wrapProperty.p is RequestChangeIntUI.UIData)
                {
                    return;
                }
                // canFinish
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
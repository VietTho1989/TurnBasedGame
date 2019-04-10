using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
    public class DefaultMineSweeperUI : UIHaveTransformDataBehavior<DefaultMineSweeperUI.UIData>
    {

        #region UIData

        public class UIData : DefaultGameTypeUI
        {

            public VP<EditData<DefaultMineSweeper>> editDefaultMineSweeper;

            public VP<UIRectTransform.ShowType> showType;

            #region N

            public VP<RequestChangeIntUI.UIData> N;

            public void makeRequestChangeN(RequestChangeUpdate<int>.UpdateData update, int newN)
            {
                // Find
                DefaultMineSweeper defaultMineSweeper = null;
                {
                    EditData<DefaultMineSweeper> editDefaultMineSweeper = this.editDefaultMineSweeper.v;
                    if (editDefaultMineSweeper != null)
                    {
                        defaultMineSweeper = editDefaultMineSweeper.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultMineSweeper null: " + this);
                    }
                }
                // Process
                if (defaultMineSweeper != null)
                {
                    defaultMineSweeper.requestChangeN(Server.getProfileUserId(defaultMineSweeper), newN);
                }
                else
                {
                    Debug.LogError("defaultMineSweeper null: " + this);
                }
            }

            #endregion

            #region M

            public VP<RequestChangeIntUI.UIData> M;

            public void makeRequestChangeM(RequestChangeUpdate<int>.UpdateData update, int newM)
            {
                // Find
                DefaultMineSweeper defaultMineSweeper = null;
                {
                    EditData<DefaultMineSweeper> editDefaultMineSweeper = this.editDefaultMineSweeper.v;
                    if (editDefaultMineSweeper != null)
                    {
                        defaultMineSweeper = editDefaultMineSweeper.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultMineSweeper null: " + this);
                    }
                }
                // Process
                if (defaultMineSweeper != null)
                {
                    defaultMineSweeper.requestChangeM(Server.getProfileUserId(defaultMineSweeper), newM);
                }
                else
                {
                    Debug.LogError("defaultMineSweeper null: " + this);
                }
            }

            #endregion

            #region minK

            public VP<RequestChangeFloatUI.UIData> minK;

            public void makeRequestChangeMinK(RequestChangeUpdate<float>.UpdateData update, float newMinK)
            {
                // Find
                DefaultMineSweeper defaultMineSweeper = null;
                {
                    EditData<DefaultMineSweeper> editDefaultMineSweeper = this.editDefaultMineSweeper.v;
                    if (editDefaultMineSweeper != null)
                    {
                        defaultMineSweeper = editDefaultMineSweeper.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultMineSweeper null: " + this);
                    }
                }
                // Process
                if (defaultMineSweeper != null)
                {
                    defaultMineSweeper.requestChangeMinK(Server.getProfileUserId(defaultMineSweeper), newMinK);
                }
                else
                {
                    Debug.LogError("defaultMineSweeper null: " + this);
                }
            }

            #endregion

            #region maxK

            public VP<RequestChangeFloatUI.UIData> maxK;

            public void makeRequestChangeMaxK(RequestChangeUpdate<float>.UpdateData update, float newMaxK)
            {
                // Find
                DefaultMineSweeper defaultMineSweeper = null;
                {
                    EditData<DefaultMineSweeper> editDefaultMineSweeper = this.editDefaultMineSweeper.v;
                    if (editDefaultMineSweeper != null)
                    {
                        defaultMineSweeper = editDefaultMineSweeper.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultMineSweeper null: " + this);
                    }
                }
                // Process
                if (defaultMineSweeper != null)
                {
                    defaultMineSweeper.requestChangeMaxK(Server.getProfileUserId(defaultMineSweeper), newMaxK);
                }
                else
                {
                    Debug.LogError("defaultMineSweeper null: " + this);
                }
            }

            #endregion

            #region allowWatchBomb

            public VP<RequestChangeBoolUI.UIData> allowWatchBomb;

            public void makeRequestChangeAllowWatchBomb(RequestChangeUpdate<bool>.UpdateData update, bool newAllowWatchBomb)
            {
                // Find
                DefaultMineSweeper defaultMineSweeper = null;
                {
                    EditData<DefaultMineSweeper> editDefaultMineSweeper = this.editDefaultMineSweeper.v;
                    if (editDefaultMineSweeper != null)
                    {
                        defaultMineSweeper = editDefaultMineSweeper.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultMineSweeper null: " + this);
                    }
                }
                // Process
                if (defaultMineSweeper != null)
                {
                    defaultMineSweeper.requestChangeAllowWatchBomb(Server.getProfileUserId(defaultMineSweeper), newAllowWatchBomb);
                }
                else
                {
                    Debug.LogError("defaultMineSweeper null: " + this);
                }
            }

            #endregion

            public VP<MiniGameDataUI.UIData> miniGameDataUIData;

            #region Constructor

            public enum Property
            {
                editDefaultMineSweeper,
                showType,
                N,
                M,
                minK,
                maxK,
                allowWatchBomb,
                miniGameDataUIData
            }

            public UIData() : base()
            {
                this.editDefaultMineSweeper = new VP<EditData<DefaultMineSweeper>>(this, (byte)Property.editDefaultMineSweeper, new EditData<DefaultMineSweeper>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // N
                {
                    this.N = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.N, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.N.v.limit.makeId();
                            have.min.v = MineSweeper.MIN_DIMENSION_SIZE;
                            have.max.v = MineSweeper.MAX_DIMENSION_SIZE;
                        }
                        this.N.v.limit.v = have;
                    }
                    // event
                    this.N.v.updateData.v.request.v = makeRequestChangeN;
                }
                // M
                {
                    this.M = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.M, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.M.v.limit.makeId();
                            have.min.v = MineSweeper.MIN_DIMENSION_SIZE;
                            have.max.v = MineSweeper.MAX_DIMENSION_SIZE;
                        }
                        this.M.v.limit.v = have;
                    }
                    // event
                    this.M.v.updateData.v.request.v = makeRequestChangeM;
                }
                // minK
                {
                    this.minK = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.minK, new RequestChangeFloatUI.UIData());
                    // have limit
                    {
                        FloatLimit.Have have = new FloatLimit.Have();
                        {
                            have.uid = this.minK.v.limit.makeId();
                            have.min.v = 0;
                            have.max.v = 1;
                        }
                        this.minK.v.limit.v = have;
                    }
                    // event
                    this.minK.v.updateData.v.request.v = makeRequestChangeMinK;
                }
                // maxK
                {
                    this.maxK = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.maxK, new RequestChangeFloatUI.UIData());
                    // have limit
                    {
                        FloatLimit.Have have = new FloatLimit.Have();
                        {
                            have.uid = this.maxK.v.limit.makeId();
                            have.min.v = 0;
                            have.max.v = 1;
                        }
                        this.maxK.v.limit.v = have;
                    }
                    // event
                    this.maxK.v.updateData.v.request.v = makeRequestChangeMaxK;
                }
                // allowWatchBomb
                {
                    this.allowWatchBomb = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.allowWatchBomb, new RequestChangeBoolUI.UIData());
                    this.allowWatchBomb.v.updateData.v.request.v = makeRequestChangeAllowWatchBomb;
                }
                this.miniGameDataUIData = new VP<MiniGameDataUI.UIData>(this, (byte)Property.miniGameDataUIData, new MiniGameDataUI.UIData());
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.MineSweeper;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Default Mine Sweeper");

        public Text lbN;
        private static readonly TxtLanguage txtN = new TxtLanguage("N");

        public Text lbM;
        private static readonly TxtLanguage txtM = new TxtLanguage("M");

        public Text lbMinK;
        private static readonly TxtLanguage txtMinK = new TxtLanguage("MinK");

        public Text lbMaxK;
        private static readonly TxtLanguage txtMaxK = new TxtLanguage("MaxK");

        public Text lbAllowWatchBomb;
        private static readonly TxtLanguage txtAllowWatchBomb = new TxtLanguage("Allow watch bomb");

        static DefaultMineSweeperUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Mặc Định Dò Mìn");
                txtN.add(Language.Type.vi, "Chiều dài");
                txtM.add(Language.Type.vi, "Chiều rộng");
                txtMinK.add(Language.Type.vi, "Mật độ mìn tối thiểu");
                txtMaxK.add(Language.Type.vi, "Mật độ mìn tối đa");
                txtAllowWatchBomb.add(Language.Type.vi, "Cho phép người xem thấy bom");
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
                    EditData<DefaultMineSweeper> editDefaultMineSweeper = this.data.editDefaultMineSweeper.v;
                    if (editDefaultMineSweeper != null)
                    {
                        editDefaultMineSweeper.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editDefaultMineSweeper);
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = RequestChange.GetServerState(editDefaultMineSweeper);
                                // set origin
                                {
                                    RequestChange.RefreshUI(this.data.N.v, editDefaultMineSweeper, serverState, needReset, editData => editData.N.v);
                                    RequestChange.RefreshUI(this.data.M.v, editDefaultMineSweeper, serverState, needReset, editData => editData.M.v);
                                    RequestChange.RefreshUI(this.data.minK.v, editDefaultMineSweeper, serverState, needReset, editData => editData.minK.v);
                                    RequestChange.RefreshUI(this.data.maxK.v, editDefaultMineSweeper, serverState, needReset, editData => editData.maxK.v);
                                    RequestChange.RefreshUI(this.data.allowWatchBomb.v, editDefaultMineSweeper, serverState, needReset, editData => editData.allowWatchBomb.v);
                                }
                                needReset = false;
                            }
                            // miniGameDataUIData
                            if (miniGameDataDirty)
                            {
                                miniGameDataDirty = false;
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
                                                // Find MineSweeper
                                                MineSweeper mineSweeper = gameData.gameType.newOrOld<MineSweeper>();
                                                {
                                                    // Make new mineSweeper
                                                    MineSweeper newMineSweeper = null;
                                                    {
                                                        DefaultMineSweeper show = editDefaultMineSweeper.show.v.data;
                                                        if (show != null)
                                                        {
                                                            newMineSweeper = show.makeDefaultGameType() as MineSweeper;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("show null");
                                                        }
                                                    }
                                                    // Copy
                                                    DataUtils.copyData(mineSweeper, newMineSweeper);
                                                }
                                                gameData.gameType.v = mineSweeper;
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
                            // N
                            UIUtils.SetLabelContentPosition(lbN, this.data.N.v, ref deltaY);
                            // M
                            UIUtils.SetLabelContentPosition(lbM, this.data.M.v, ref deltaY);
                            // minK
                            UIUtils.SetLabelContentPosition(lbMinK, this.data.minK.v, ref deltaY);
                            // maxK
                            UIUtils.SetLabelContentPosition(lbMaxK, this.data.maxK.v, ref deltaY);
                            // allowWatchBomb
                            UIUtils.SetLabelContentPosition(lbAllowWatchBomb, this.data.allowWatchBomb.v, ref deltaY);
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
                            if (lbN != null)
                            {
                                lbN.text = txtN.get();
                                Setting.get().setLabelTextSize(lbN);
                            }
                            else
                            {
                                Debug.LogError("lbN null: " + this);
                            }
                            if (lbM != null)
                            {
                                lbM.text = txtM.get();
                                Setting.get().setLabelTextSize(lbM);
                            }
                            else
                            {
                                Debug.LogError("lbM null: " + this);
                            }
                            if (lbMinK != null)
                            {
                                lbMinK.text = txtMinK.get();
                                Setting.get().setLabelTextSize(lbMinK);
                            }
                            else
                            {
                                Debug.LogError("lbMinK null: " + this);
                            }
                            if (lbMaxK != null)
                            {
                                lbMaxK.text = txtMaxK.get();
                                Setting.get().setLabelTextSize(lbMaxK);
                            }
                            else
                            {
                                Debug.LogError("lbMaxK null: " + this);
                            }
                            if (lbAllowWatchBomb != null)
                            {
                                lbAllowWatchBomb.text = txtAllowWatchBomb.get();
                                Setting.get().setLabelTextSize(lbAllowWatchBomb);
                            }
                            else
                            {
                                Debug.LogError("lbAllowWatchBomb null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("editDefaultMineSweeper null: " + this);
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

        public RequestChangeIntUI requestIntPrefab;
        public RequestChangeFloatUI requestFloatPrefab;
        public RequestChangeBoolUI requestBoolPrefab;

        private static readonly UIRectTransform NRect = new UIRectTransform(UIConstants.RequestRect);
        private static readonly UIRectTransform MRect = new UIRectTransform(UIConstants.RequestRect);
        private static readonly UIRectTransform minKRect = new UIRectTransform(UIConstants.RequestRect);
        private static readonly UIRectTransform maxKRect = new UIRectTransform(UIConstants.RequestRect);
        private static readonly UIRectTransform allowWatchBombRect = new UIRectTransform(UIConstants.RequestBoolRect);

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
                    uiData.editDefaultMineSweeper.allAddCallBack(this);
                    uiData.N.allAddCallBack(this);
                    uiData.M.allAddCallBack(this);
                    uiData.minK.allAddCallBack(this);
                    uiData.maxK.allAddCallBack(this);
                    uiData.allowWatchBomb.allAddCallBack(this);
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
                // editDefaultMineSweeper
                {
                    if (data is EditData<DefaultMineSweeper>)
                    {
                        EditData<DefaultMineSweeper> editDefaultMineSweeper = data as EditData<DefaultMineSweeper>;
                        // Child
                        {
                            editDefaultMineSweeper.show.allAddCallBack(this);
                            editDefaultMineSweeper.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is DefaultMineSweeper)
                        {
                            DefaultMineSweeper defaultMineSweeper = data as DefaultMineSweeper;
                            // Parent
                            {
                                DataUtils.addParentCallBack(defaultMineSweeper, this, ref this.server);
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
                // N, M
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
                                case UIData.Property.N:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, NRect);
                                    break;
                                case UIData.Property.M:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, MRect);
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
                // minK, maxK
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
                                case UIData.Property.minK:
                                    UIUtils.Instantiate(requestChange, requestFloatPrefab, this.transform, minKRect);
                                    break;
                                case UIData.Property.maxK:
                                    UIUtils.Instantiate(requestChange, requestFloatPrefab, this.transform, maxKRect);
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
                // allowWatchBomb
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
                                case UIData.Property.allowWatchBomb:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, allowWatchBombRect);
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
                    uiData.editDefaultMineSweeper.allRemoveCallBack(this);
                    uiData.N.allRemoveCallBack(this);
                    uiData.M.allRemoveCallBack(this);
                    uiData.minK.allRemoveCallBack(this);
                    uiData.maxK.allRemoveCallBack(this);
                    uiData.allowWatchBomb.allRemoveCallBack(this);
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
                // editDefaultMineSweeper
                {
                    if (data is EditData<DefaultMineSweeper>)
                    {
                        EditData<DefaultMineSweeper> editDefaultMineSweeper = data as EditData<DefaultMineSweeper>;
                        // Child
                        {
                            editDefaultMineSweeper.show.allRemoveCallBack(this);
                            editDefaultMineSweeper.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is DefaultMineSweeper)
                        {
                            DefaultMineSweeper defaultMineSweeper = data as DefaultMineSweeper;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(defaultMineSweeper, this, ref this.server);
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
                // N, M
                if (data is RequestChangeIntUI.UIData)
                {
                    RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeIntUI));
                    }
                    return;
                }
                // minK, maxK
                if (data is RequestChangeFloatUI.UIData)
                {
                    RequestChangeFloatUI.UIData requestChange = data as RequestChangeFloatUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeFloatUI));
                    }
                    return;
                }
                // alowWatchBomb
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
                    case UIData.Property.editDefaultMineSweeper:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.N:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.M:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.minK:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.maxK:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.allowWatchBomb:
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
                    case Setting.Property.contentTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.titleTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.labelTextSize:
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
                // editDefaultMineSweeper
                {
                    if (wrapProperty.p is EditData<DefaultMineSweeper>)
                    {
                        switch ((EditData<DefaultMineSweeper>.Property)wrapProperty.n)
                        {
                            case EditData<DefaultMineSweeper>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<DefaultMineSweeper>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<DefaultMineSweeper>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<DefaultMineSweeper>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<DefaultMineSweeper>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<DefaultMineSweeper>.Property.editType:
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
                        if (wrapProperty.p is DefaultMineSweeper)
                        {
                            switch ((DefaultMineSweeper.Property)wrapProperty.n)
                            {
                                case DefaultMineSweeper.Property.N:
                                    miniGameDataDirty = true;
                                    dirty = true;
                                    break;
                                case DefaultMineSweeper.Property.M:
                                    miniGameDataDirty = true;
                                    dirty = true;
                                    break;
                                case DefaultMineSweeper.Property.minK:
                                    miniGameDataDirty = true;
                                    dirty = true;
                                    break;
                                case DefaultMineSweeper.Property.maxK:
                                    miniGameDataDirty = true;
                                    dirty = true;
                                    break;
                                case DefaultMineSweeper.Property.allowWatchBomb:
                                    miniGameDataDirty = true;
                                    dirty = true;
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // Parent
                        {
                            if (wrapProperty.p is Server)
                            {
                                Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                                return;
                            }
                        }
                    }
                }
                // N, M
                if (wrapProperty.p is RequestChangeIntUI.UIData)
                {
                    return;
                }
                // minK, maxK
                if (wrapProperty.p is RequestChangeFloatUI.UIData)
                {
                    return;
                }
                // allowWatchBomb
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
                        // Child
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
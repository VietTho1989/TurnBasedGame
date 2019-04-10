using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace ChineseCheckers
{
    public class ChineseCheckersAIUI : UIHaveTransformDataBehavior<ChineseCheckersAIUI.UIData>
    {

        #region UIData

        public class UIData : AIUI.UIData.Sub
        {

            public VP<EditData<ChineseCheckersAI>> editAI;

            public VP<UIRectTransform.ShowType> showType;

            #region type

            public VP<RequestChangeEnumUI.UIData> type;

            public void makeRequestChangeType(RequestChangeUpdate<int>.UpdateData update, int newType)
            {
                // Find
                ChineseCheckersAI chineseCheckersAI = null;
                {
                    EditData<ChineseCheckersAI> editChineseCheckersAI = this.editAI.v;
                    if (editChineseCheckersAI != null)
                    {
                        chineseCheckersAI = editChineseCheckersAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editChineseCheckersAI null: " + this);
                    }
                }
                // Process
                if (chineseCheckersAI != null)
                {
                    chineseCheckersAI.requestChangeType(Server.getProfileUserId(chineseCheckersAI), (ChineseCheckersAI.Type)newType);
                }
                else
                {
                    Debug.LogError("chineseCheckersAI null: " + this);
                }
            }

            #endregion

            #region depth

            public VP<RequestChangeIntUI.UIData> depth;

            public void makeRequestChangeDepth(RequestChangeUpdate<int>.UpdateData update, int newDepth)
            {
                // Find
                ChineseCheckersAI chineseCheckersAI = null;
                {
                    EditData<ChineseCheckersAI> editChineseCheckersAI = this.editAI.v;
                    if (editChineseCheckersAI != null)
                    {
                        chineseCheckersAI = editChineseCheckersAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editChineseCheckersAI null: " + this);
                    }
                }
                // Process
                if (chineseCheckersAI != null)
                {
                    chineseCheckersAI.requestChangeDepth(Server.getProfileUserId(chineseCheckersAI), newDepth);
                }
                else
                {
                    Debug.LogError("chineseCheckersAI null: " + this);
                }
            }

            #endregion

            #region time

            public VP<RequestChangeIntUI.UIData> time;

            public void makeRequestChangeTime(RequestChangeUpdate<int>.UpdateData update, int newTime)
            {
                // Find
                ChineseCheckersAI chineseCheckersAI = null;
                {
                    EditData<ChineseCheckersAI> editChineseCheckersAI = this.editAI.v;
                    if (editChineseCheckersAI != null)
                    {
                        chineseCheckersAI = editChineseCheckersAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editChineseCheckersAI null: " + this);
                    }
                }
                // Process
                if (chineseCheckersAI != null)
                {
                    chineseCheckersAI.requestChangeTime(Server.getProfileUserId(chineseCheckersAI), newTime);
                }
                else
                {
                    Debug.LogError("chineseCheckersAI null: " + this);
                }
            }

            #endregion

            #region node

            public VP<RequestChangeIntUI.UIData> node;

            public void makeRequestChangeNode(RequestChangeUpdate<int>.UpdateData update, int newNode)
            {
                // Find
                ChineseCheckersAI chineseCheckersAI = null;
                {
                    EditData<ChineseCheckersAI> editChineseCheckersAI = this.editAI.v;
                    if (editChineseCheckersAI != null)
                    {
                        chineseCheckersAI = editChineseCheckersAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editChineseCheckersAI null: " + this);
                    }
                }
                // Process
                if (chineseCheckersAI != null)
                {
                    chineseCheckersAI.requestChangeNode(Server.getProfileUserId(chineseCheckersAI), newNode);
                }
                else
                {
                    Debug.LogError("chineseCheckersAI null: " + this);
                }
            }

            #endregion

            #region pickBestMove

            public VP<RequestChangeIntUI.UIData> pickBestMove;

            public void makeRequestChangePickBestMove(RequestChangeUpdate<int>.UpdateData update, int newPickBestMove)
            {
                // Find
                ChineseCheckersAI chineseCheckersAI = null;
                {
                    EditData<ChineseCheckersAI> editChineseCheckersAI = this.editAI.v;
                    if (editChineseCheckersAI != null)
                    {
                        chineseCheckersAI = editChineseCheckersAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editChineseCheckersAI null: " + this);
                    }
                }
                // Process
                if (chineseCheckersAI != null)
                {
                    chineseCheckersAI.requestChangePickBestMove(Server.getProfileUserId(chineseCheckersAI), newPickBestMove);
                }
                else
                {
                    Debug.LogError("chineseCheckersAI null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editAI,
                showType,
                type,
                depth,
                time,
                node,
                pickBestMove
            }

            public UIData() : base()
            {
                this.editAI = new VP<EditData<ChineseCheckersAI>>(this, (byte)Property.editAI, new EditData<ChineseCheckersAI>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // type
                {
                    this.type = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.type, new RequestChangeEnumUI.UIData());
                    this.type.v.updateData.v.request.v = makeRequestChangeType;
                    foreach (ChineseCheckersAI.Type type in System.Enum.GetValues(typeof(ChineseCheckersAI.Type)))
                    {
                        this.type.v.options.add(type.ToString());
                    }
                }
                // depth
                {
                    this.depth = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.depth, new RequestChangeIntUI.UIData());
                    this.depth.v.updateData.v.request.v = makeRequestChangeDepth;
                }
                // time
                {
                    this.time = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.time, new RequestChangeIntUI.UIData());
                    this.time.v.updateData.v.request.v = makeRequestChangeTime;
                }
                // node
                {
                    this.node = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.node, new RequestChangeIntUI.UIData());
                    this.node.v.updateData.v.request.v = makeRequestChangeNode;
                }
                // pickBestMove
                {
                    this.pickBestMove = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.pickBestMove, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.pickBestMove.v.limit.makeId();
                            have.min.v = 0;
                            have.max.v = 100;
                        }
                        this.pickBestMove.v.limit.v = have;
                    }
                    // event
                    this.pickBestMove.v.updateData.v.request.v = makeRequestChangePickBestMove;
                }
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.ChineseCheckers;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Chinese Checkers AI");

        public Text lbType;
        private static readonly TxtLanguage txtType = new TxtLanguage("Type");

        public Text lbDepth;
        private static readonly TxtLanguage txtDepth = new TxtLanguage("Depth");

        public Text lbTime;
        private static readonly TxtLanguage txtTime = new TxtLanguage("Time");

        public Text lbNode;
        private static readonly TxtLanguage txtNode = new TxtLanguage("Node count");

        public Text lbPickBestMove;
        private static readonly TxtLanguage txtPickBestMove = new TxtLanguage("Pick best move depth");

        static ChineseCheckersAIUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "AI Chinese Checkers");
                txtType.add(Language.Type.vi, "Loại");
                txtDepth.add(Language.Type.vi, "Độ sâu");
                txtTime.add(Language.Type.vi, "Thời gian");
                txtNode.add(Language.Type.vi, "Số node");
                txtPickBestMove.add(Language.Type.vi, "Tỷ lệ chọn nước đi tốt nhất");
            }
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
                    EditData<ChineseCheckersAI> editChineseCheckersAI = this.data.editAI.v;
                    if (editChineseCheckersAI != null)
                    {
                        editChineseCheckersAI.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editChineseCheckersAI);
                            // get server state
                            Server.State.Type serverState = RequestChange.GetServerState(editChineseCheckersAI);
                            // set origin
                            {
                                RequestChange.RefreshUI(this.data.type.v, editChineseCheckersAI, serverState, needReset, editData => (int)editData.type.v);
                                RequestChange.RefreshUI(this.data.depth.v, editChineseCheckersAI, serverState, needReset, editData => editData.depth.v);
                                RequestChange.RefreshUI(this.data.time.v, editChineseCheckersAI, serverState, needReset, editData => editData.time.v);
                                RequestChange.RefreshUI(this.data.node.v, editChineseCheckersAI, serverState, needReset, editData => editData.node.v);
                                RequestChange.RefreshUI(this.data.pickBestMove.v, editChineseCheckersAI, serverState, needReset, editData => editData.pickBestMove.v);
                            }
                            needReset = false;
                        }
                    }
                    else
                    {
                        Debug.LogError("editChessAI null: " + this);
                    }
                    // UI
                    {
                        float deltaY = 0;
                        // header
                        UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                        // type
                        UIUtils.SetLabelContentPosition(lbType, this.data.type.v, ref deltaY);
                        // depth
                        UIUtils.SetLabelContentPosition(lbDepth, this.data.depth.v, ref deltaY);
                        // time
                        UIUtils.SetLabelContentPosition(lbTime, this.data.time.v, ref deltaY);
                        // node
                        UIUtils.SetLabelContentPosition(lbNode, this.data.node.v, ref deltaY);
                        // pickBestMove
                        UIUtils.SetLabelContentPosition(lbPickBestMove, this.data.pickBestMove.v, ref deltaY);
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
                            Debug.LogError("lbTitle null: " + this);
                        }
                        if (lbType != null)
                        {
                            lbType.text = txtType.get();
                            Setting.get().setLabelTextSize(lbType);
                        }
                        else
                        {
                            Debug.LogError("lbType null");
                        }
                        if (lbDepth != null)
                        {
                            lbDepth.text = txtDepth.get();
                            Setting.get().setLabelTextSize(lbDepth);
                        }
                        else
                        {
                            Debug.LogError("lbDepth null");
                        }
                        if (lbTime != null)
                        {
                            lbTime.text = txtTime.get();
                            Setting.get().setLabelTextSize(lbTime);
                        }
                        else
                        {
                            Debug.LogError("lbTime null");
                        }
                        if (lbNode != null)
                        {
                            lbNode.text = txtNode.get();
                            Setting.get().setLabelTextSize(lbNode);
                        }
                        else
                        {
                            Debug.LogError("lbNode null");
                        }
                        if (lbPickBestMove != null)
                        {
                            lbPickBestMove.text = txtPickBestMove.get();
                            Setting.get().setLabelTextSize(lbPickBestMove);
                        }
                        else
                        {
                            Debug.LogError("lbPickBestMove null: " + this);
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

        public RequestChangeEnumUI requestEnumPrefab;
        public RequestChangeIntUI requestIntPrefab;

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
                    uiData.editAI.allAddCallBack(this);
                    uiData.type.allAddCallBack(this);
                    uiData.depth.allAddCallBack(this);
                    uiData.time.allAddCallBack(this);
                    uiData.node.allAddCallBack(this);
                    uiData.pickBestMove.allAddCallBack(this);
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
                // editAI
                {
                    if (data is EditData<ChineseCheckersAI>)
                    {
                        EditData<ChineseCheckersAI> editAI = data as EditData<ChineseCheckersAI>;
                        // Child
                        {
                            editAI.show.allAddCallBack(this);
                            editAI.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is ChineseCheckersAI)
                        {
                            ChineseCheckersAI chineseCheckersAI = data as ChineseCheckersAI;
                            // Parent
                            {
                                DataUtils.addParentCallBack(chineseCheckersAI, this, ref this.server);
                            }
                            dirty = true;
                            needReset = true;
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
                                case UIData.Property.type:
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
                                case UIData.Property.depth:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                    break;
                                case UIData.Property.time:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                    break;
                                case UIData.Property.node:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                    break;
                                case UIData.Property.pickBestMove:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
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
                Setting.get().removeCallBack(this);
                // Child
                {
                    uiData.editAI.allRemoveCallBack(this);
                    uiData.type.allRemoveCallBack(this);
                    uiData.depth.allRemoveCallBack(this);
                    uiData.time.allRemoveCallBack(this);
                    uiData.node.allRemoveCallBack(this);
                    uiData.pickBestMove.allRemoveCallBack(this);
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
                // editAI
                {
                    if (data is EditData<ChineseCheckersAI>)
                    {
                        EditData<ChineseCheckersAI> editAI = data as EditData<ChineseCheckersAI>;
                        // Child
                        {
                            editAI.show.allRemoveCallBack(this);
                            editAI.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is ChineseCheckersAI)
                        {
                            ChineseCheckersAI chineseCheckersAI = data as ChineseCheckersAI;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(chineseCheckersAI, this, ref this.server);
                            }
                            return;
                        }
                        if (data is Server)
                        {
                            return;
                        }
                    }
                }
                if (data is RequestChangeEnumUI.UIData)
                {
                    RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeEnumUI));
                    }
                    return;
                }
                if (data is RequestChangeIntUI.UIData)
                {
                    RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeIntUI));
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
                    case UIData.Property.editAI:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.type:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.depth:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.time:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.node:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.pickBestMove:
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
                // editAI
                {
                    if (wrapProperty.p is EditData<ChineseCheckersAI>)
                    {
                        switch ((EditData<ChineseCheckersAI>.Property)wrapProperty.n)
                        {
                            case EditData<ChineseCheckersAI>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<ChineseCheckersAI>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<ChineseCheckersAI>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<ChineseCheckersAI>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<ChineseCheckersAI>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<ChineseCheckersAI>.Property.editType:
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
                        if (wrapProperty.p is ChineseCheckersAI)
                        {
                            switch ((ChineseCheckersAI.Property)wrapProperty.n)
                            {
                                case ChineseCheckersAI.Property.type:
                                    dirty = true;
                                    break;
                                case ChineseCheckersAI.Property.depth:
                                    dirty = true;
                                    break;
                                case ChineseCheckersAI.Property.time:
                                    dirty = true;
                                    break;
                                case ChineseCheckersAI.Property.node:
                                    dirty = true;
                                    break;
                                case ChineseCheckersAI.Property.pickBestMove:
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
                if (wrapProperty.p is RequestChangeEnumUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is RequestChangeIntUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace ChineseCheckers
{
    public class ChineseCheckersAIUI : UIBehavior<ChineseCheckersAIUI.UIData>
    {

        #region UIData

        public class UIData : AIUI.UIData.Sub
        {

            public VP<EditData<ChineseCheckersAI>> editAI;

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

            public void makeRequestChangePickBestMove (RequestChangeUpdate<int>.UpdateData update, int newPickBestMove)
            {
                // Find
                ChineseCheckersAI chineseCheckersAI = null;
                {
                    EditData<ChineseCheckersAI> editChineseCheckersAI = this.editAI.v;
                    if (editChineseCheckersAI != null) {
                        chineseCheckersAI = editChineseCheckersAI.show.v.data;
                    } else {
                        Debug.LogError ("editChineseCheckersAI null: " + this);
                    }
                }
                // Process
                if (chineseCheckersAI != null) {
                    chineseCheckersAI.requestChangePickBestMove (Server.getProfileUserId (chineseCheckersAI), newPickBestMove);
                } else {
                    Debug.LogError ("chineseCheckersAI null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editAI,
                type,
                depth,
                time,
                node,
                pickBestMove
            }

            public UIData() : base()
            {
                this.editAI = new VP<EditData<ChineseCheckersAI>>(this, (byte)Property.editAI, new EditData<ChineseCheckersAI>());
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

            public override GameType.Type getType ()
            {
                return GameType.Type.ChineseCheckers;
            }

        }

        #endregion

        #region Refresh

        #region txt

        public Text lbTitle;
        public static readonly TxtLanguage txtTitle = new TxtLanguage();

        public Text lbType;
        public static readonly TxtLanguage txtType = new TxtLanguage();

        public Text lbDepth;
        public static readonly TxtLanguage txtDepth = new TxtLanguage();

        public Text lbTime;
        public static readonly TxtLanguage txtTime = new TxtLanguage();

        public Text lbNode;
        public static readonly TxtLanguage txtNode = new TxtLanguage();

        public Text lbPickBestMove;
        public static readonly TxtLanguage txtPickBestMove = new TxtLanguage();

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
            // rect
            {
                typeRect.setPosY(UIConstants.HeaderHeight + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                depthRect.setPosY(UIConstants.HeaderHeight + 1 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                timeRect.setPosY(UIConstants.HeaderHeight + 2 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                nodeRect.setPosY(UIConstants.HeaderHeight + 3 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                pickBestMoveRect.setPosY(UIConstants.HeaderHeight + 4 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
            }
        }

        #endregion

        private bool needReset = true;

        public override void refresh ()
        {
            if (dirty) {
                dirty = false;
                if (this.data != null) {
                    EditData<ChineseCheckersAI> editChineseCheckersAI = this.data.editAI.v;
                    if (editChineseCheckersAI != null) {
                        editChineseCheckersAI.update ();
                        // get show
                        ChineseCheckersAI show = editChineseCheckersAI.show.v.data;
                        ChineseCheckersAI compare = editChineseCheckersAI.compare.v.data;
                        if (show != null) {
                            // different
                            if (lbTitle != null) {
                                bool isDifferent = false;
                                {
                                    if (editChineseCheckersAI.compareOtherType.v.data != null) {
                                        if (editChineseCheckersAI.compareOtherType.v.data.GetType () != show.GetType ()) {
                                            isDifferent = true;
                                        }
                                    }
                                }
                                lbTitle.color = isDifferent ? UIConstants.DifferentIndicatorColor : UIConstants.NormalTitleColor;
                            } else {
                                Debug.LogError ("different null: " + this);
                            }
                            // get server state
                            Server.State.Type serverState = Server.State.Type.Connect;
                            {
                                Server server = show.findDataInParent<Server> ();
                                if (server != null) {
                                    if (server.state.v != null) {
                                        serverState = server.state.v.getType ();
                                    } else {
                                        Debug.LogError ("server state null: " + this);
                                    }
                                } else {
                                    // Debug.LogError ("server null: " + this);
                                }
                            }
                            // set origin
                            {
                                // type
                                {
                                    RequestChangeEnumUI.UIData type = this.data.type.v;
                                    if (type != null)
                                    {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = type.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = (int)show.type.v;
                                            updateData.canRequestChange.v = editChineseCheckersAI.canEdit.v;
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
                                                type.showDifferent.v = true;
                                                type.compare.v = (int)compare.type.v;
                                            }
                                            else
                                            {
                                                type.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("type null: " + this);
                                    }
                                }
                                // depth
                                {
                                    RequestChangeIntUI.UIData depth = this.data.depth.v;
                                    if (depth != null)
                                    {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = depth.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.depth.v;
                                            updateData.canRequestChange.v = editChineseCheckersAI.canEdit.v;
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
                                                depth.showDifferent.v = true;
                                                depth.compare.v = compare.depth.v;
                                            }
                                            else
                                            {
                                                depth.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("depth null: " + this);
                                    }
                                }
                                // time
                                {
                                    RequestChangeIntUI.UIData time = this.data.time.v;
                                    if (time != null)
                                    {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = time.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.time.v;
                                            updateData.canRequestChange.v = editChineseCheckersAI.canEdit.v;
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
                                                time.showDifferent.v = true;
                                                time.compare.v = compare.time.v;
                                            }
                                            else
                                            {
                                                time.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("time null: " + this);
                                    }
                                }
                                // node
                                {
                                    RequestChangeIntUI.UIData node = this.data.node.v;
                                    if (node != null)
                                    {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = node.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.node.v;
                                            updateData.canRequestChange.v = editChineseCheckersAI.canEdit.v;
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
                                                node.showDifferent.v = true;
                                                node.compare.v = compare.node.v;
                                            }
                                            else
                                            {
                                                node.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("node null: " + this);
                                    }
                                }
                                // pickBestMove
                                {
                                    RequestChangeIntUI.UIData pickBestMove = this.data.pickBestMove.v;
                                    if (pickBestMove != null) {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = pickBestMove.updateData.v;
                                        if (updateData != null) {
                                            updateData.origin.v = show.pickBestMove.v;
                                            updateData.canRequestChange.v = editChineseCheckersAI.canEdit.v;
                                            updateData.serverState.v = serverState;
                                        } else {
                                            Debug.LogError ("updateData null: " + this);
                                        }
                                        // compare
                                        {
                                            if (compare != null) {
                                                pickBestMove.showDifferent.v = true;
                                                pickBestMove.compare.v = compare.pickBestMove.v;
                                            } else {
                                                pickBestMove.showDifferent.v = false;
                                            }
                                        }
                                    } else {
                                        Debug.LogError ("pickBestMove null: " + this);
                                    }
                                }
                            }
                            // reset?
                            if (needReset) {
                                needReset = false;
                                // type
                                {
                                    RequestChangeEnumUI.UIData type = this.data.type.v;
                                    if (type != null)
                                    {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = type.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = (int)show.type.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("type null: " + this);
                                    }
                                }
                                // depth
                                {
                                    RequestChangeIntUI.UIData depth = this.data.depth.v;
                                    if (depth != null)
                                    {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = depth.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.depth.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("depth null: " + this);
                                    }
                                }
                                // time
                                {
                                    RequestChangeIntUI.UIData time = this.data.time.v;
                                    if (time != null)
                                    {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = time.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.time.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("time null: " + this);
                                    }
                                }
                                // node
                                {
                                    RequestChangeIntUI.UIData node = this.data.node.v;
                                    if (node != null)
                                    {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = node.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.node.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("node null: " + this);
                                    }
                                }
                                // pickBestMove
                                {
                                    RequestChangeIntUI.UIData pickBestMove = this.data.pickBestMove.v;
                                    if (pickBestMove != null) {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = pickBestMove.updateData.v;
                                        if (updateData != null) {
                                            updateData.current.v = show.pickBestMove.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        } else {
                                            Debug.LogError ("updateData null: " + this);
                                        }
                                    } else {
                                        Debug.LogError ("pickBestMove null: " + this);
                                    }
                                }
                            }
                        } else {
                            Debug.LogError ("chessAI null: " + this);
                        }
                    } else {
                        Debug.LogError ("editChessAI null: " + this);
                    }
                    // txt
                    {
                        if (lbTitle != null) {
                            lbTitle.text = txtTitle.get ("Nine Men's Morriss AI");
                        } else {
                            Debug.LogError ("lbTitle null: " + this);
                        }
                        if (lbType != null)
                        {
                            lbType.text = txtType.get("Type");
                        }
                        else
                        {
                            Debug.LogError("lbType null");
                        }
                        if (lbDepth != null)
                        {
                            lbDepth.text = txtDepth.get("Depth");
                        }
                        else
                        {
                            Debug.LogError("lbDepth null");
                        }
                        if (lbTime != null)
                        {
                            lbTime.text = txtTime.get("Time");
                        }
                        else
                        {
                            Debug.LogError("lbTime null");
                        }
                        if (lbNode != null)
                        {
                            lbNode.text = txtNode.get("Node count");
                        }
                        else
                        {
                            Debug.LogError("lbNode null");
                        }
                        if (lbPickBestMove != null) {
                            lbPickBestMove.text = txtPickBestMove.get ("Pick best move depth");
                        } else {
                            Debug.LogError ("lbPickBestMove null: " + this);
                        }
                    }
                } else {
                    // Debug.LogError ("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate ()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public static readonly UIRectTransform typeRect = new UIRectTransform(UIConstants.RequestEnumRect);
        public static readonly UIRectTransform depthRect = new UIRectTransform(UIConstants.RequestRect);
        public static readonly UIRectTransform timeRect = new UIRectTransform(UIConstants.RequestRect);
        public static readonly UIRectTransform nodeRect = new UIRectTransform(UIConstants.RequestRect);
        public static readonly UIRectTransform pickBestMoveRect = new UIRectTransform(UIConstants.RequestRect);

        public RequestChangeEnumUI requestEnumPrefab;
        public RequestChangeIntUI requestIntPrefab;

        private Server server = null;

        public override void onAddCallBack<T> (T data)
        {
            if (data is UIData) {
                UIData uiData = data as UIData;
                // Setting
                Setting.get ().addCallBack (this);
                // Child
                {
                    uiData.editAI.allAddCallBack (this);
                    uiData.type.allAddCallBack(this);
                    uiData.depth.allAddCallBack(this);
                    uiData.time.allAddCallBack(this);
                    uiData.node.allAddCallBack(this);
                    uiData.pickBestMove.allAddCallBack (this);
                }
                dirty = true;
                return;
            }
            // Setting
            if (data is Setting) {
                dirty = true;
                return;
            }
            // Child
            {
                // editAI
                {
                    if (data is EditData<ChineseCheckersAI>) {
                        EditData<ChineseCheckersAI> editAI = data as EditData<ChineseCheckersAI>;
                        // Child
                        {
                            editAI.show.allAddCallBack (this);
                            editAI.compare.allAddCallBack (this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is ChineseCheckersAI) {
                            ChineseCheckersAI chineseCheckersAI = data as ChineseCheckersAI;
                            // Parent
                            {
                                DataUtils.addParentCallBack (chineseCheckersAI, this, ref this.server);
                            }
                            dirty = true;
                            needReset = true;
                            return;
                        }
                        // Parent
                        {
                            if (data is Server) {
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
                                    UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, typeRect);
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
                if (data is RequestChangeIntUI.UIData) {
                    RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                    // UI
                    {
                        WrapProperty wrapProperty = requestChange.p;
                        if (wrapProperty != null)
                        {
                            switch ((UIData.Property)wrapProperty.n)
                            {
                                case UIData.Property.depth:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, depthRect);
                                    break;
                                case UIData.Property.time:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, timeRect);
                                    break;
                                case UIData.Property.node:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, nodeRect);
                                    break;
                                case UIData.Property.pickBestMove:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, pickBestMoveRect);
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
            Debug.LogError ("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T> (T data, bool isHide)
        {
            if (data is UIData) {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().removeCallBack(this);
                // Child
                {
                    uiData.editAI.allRemoveCallBack (this);
                    uiData.type.allRemoveCallBack(this);
                    uiData.depth.allRemoveCallBack(this);
                    uiData.time.allRemoveCallBack(this);
                    uiData.node.allRemoveCallBack(this);
                    uiData.pickBestMove.allRemoveCallBack (this);
                }
                this.setDataNull (uiData);
                return;
            }
            // Setting
            if (data is Setting) {
                return;
            }
            // Child
            {
                // editAI
                {
                    if (data is EditData<ChineseCheckersAI>) {
                        EditData<ChineseCheckersAI> editAI = data as EditData<ChineseCheckersAI>;
                        // Child
                        {
                            editAI.show.allRemoveCallBack (this);
                            editAI.compare.allRemoveCallBack (this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is ChineseCheckersAI) {
                            ChineseCheckersAI chineseCheckersAI = data as ChineseCheckersAI;
                            // Parent
                            {
                                DataUtils.removeParentCallBack (chineseCheckersAI, this, ref this.server);
                            }
                            return;
                        }
                        if (data is Server) {
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
                if (data is RequestChangeIntUI.UIData) {
                    RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy (typeof(RequestChangeIntUI));
                    }
                    return;
                }
            }
            Debug.LogError ("Don't process: " + data + "; " + this);
        }

        public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
        {
            if(WrapProperty.checkError(wrapProperty)){
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
            if (wrapProperty.p is Setting) {
                switch ((Setting.Property)wrapProperty.n) {
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
                    Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
                    break;
                }
                return;
            }
            // Child
            {
                // editAI
                {
                    if (wrapProperty.p is EditData<ChineseCheckersAI>) {
                        switch ((EditData<ChineseCheckersAI>.Property)wrapProperty.n) {
                        case EditData<ChineseCheckersAI>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<ChineseCheckersAI>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack (this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<ChineseCheckersAI>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack (this, syncs);
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
                            Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
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
                        if (wrapProperty.p is Server) {
                            Server.State.OnUpdateSyncStateChange (wrapProperty, this);
                            return;
                        }
                    }
                }
                if (wrapProperty.p is RequestChangeEnumUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is RequestChangeIntUI.UIData) {
                    return;
                }
            }
            Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
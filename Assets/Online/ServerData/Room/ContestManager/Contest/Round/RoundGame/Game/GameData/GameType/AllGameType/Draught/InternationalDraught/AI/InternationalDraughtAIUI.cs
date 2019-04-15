using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace InternationalDraught
{
    public class InternationalDraughtAIUI : UIHaveTransformDataBehavior<InternationalDraughtAIUI.UIData>
    {

        #region UIData

        public class UIData : AIUI.UIData.Sub
        {

            public VP<EditData<InternationalDraughtAI>> editAI;

            public VP<UIRectTransform.ShowType> showType;

            #region bMove

            public VP<RequestChangeBoolUI.UIData> bMove;

            public void makeRequestChangeBMove(RequestChangeUpdate<bool>.UpdateData update, bool newBMove)
            {
                // Find InternationalDraughtAI
                InternationalDraughtAI internationalDraughtAI = null;
                {
                    EditData<InternationalDraughtAI> editInternationalDraughtAI = this.editAI.v;
                    if (editInternationalDraughtAI != null)
                    {
                        internationalDraughtAI = editInternationalDraughtAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editInternationalDraughtAI null: " + this);
                    }
                }
                // Process
                if (internationalDraughtAI != null)
                {
                    internationalDraughtAI.requestChangeBMove(Server.getProfileUserId(internationalDraughtAI), newBMove);
                }
                else
                {
                    Debug.LogError("internationalDraughtAI null: " + this);
                }
            }

            #endregion

            #region book

            public VP<RequestChangeBoolUI.UIData> book;

            public void makeRequestChangeBook(RequestChangeUpdate<bool>.UpdateData update, bool newBook)
            {
                // Find InternationalDraughtAI
                InternationalDraughtAI internationalDraughtAI = null;
                {
                    EditData<InternationalDraughtAI> editInternationalDraughtAI = this.editAI.v;
                    if (editInternationalDraughtAI != null)
                    {
                        internationalDraughtAI = editInternationalDraughtAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editInternationalDraughtAI null: " + this);
                    }
                }
                // Process
                if (internationalDraughtAI != null)
                {
                    internationalDraughtAI.requestChangeBook(Server.getProfileUserId(internationalDraughtAI), newBook);
                }
                else
                {
                    Debug.LogError("internationalDraughtAI null: " + this);
                }
            }

            #endregion

            #region depth

            public VP<RequestChangeIntUI.UIData> depth;

            public void makeRequestChangeDepth(RequestChangeUpdate<int>.UpdateData update, int newDepth)
            {
                // Find InternationalDraughtAI
                InternationalDraughtAI internationalDraughtAI = null;
                {
                    EditData<InternationalDraughtAI> editInternationalDraughtAI = this.editAI.v;
                    if (editInternationalDraughtAI != null)
                    {
                        internationalDraughtAI = editInternationalDraughtAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editInternationalDraughtAI null: " + this);
                    }
                }
                // Process
                if (internationalDraughtAI != null)
                {
                    internationalDraughtAI.requestChangeDepth(Server.getProfileUserId(internationalDraughtAI), newDepth);
                }
                else
                {
                    Debug.LogError("internationalDraughtAI null: " + this);
                }
            }

            #endregion

            #region time

            public VP<RequestChangeFloatUI.UIData> time;

            public void makeRequestChangeTime(RequestChangeUpdate<float>.UpdateData update, float newTime)
            {
                // Find InternationalDraughtAI
                InternationalDraughtAI internationalDraughtAI = null;
                {
                    EditData<InternationalDraughtAI> editInternationalDraughtAI = this.editAI.v;
                    if (editInternationalDraughtAI != null)
                    {
                        internationalDraughtAI = editInternationalDraughtAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editInternationalDraughtAI null: " + this);
                    }
                }
                // Process
                if (internationalDraughtAI != null)
                {
                    internationalDraughtAI.requestChangeTime(Server.getProfileUserId(internationalDraughtAI), newTime);
                }
                else
                {
                    Debug.LogError("internationalDraughtAI null: " + this);
                }
            }

            #endregion

            #region input

            public VP<RequestChangeBoolUI.UIData> input;

            public void makeRequestChangeInput(RequestChangeUpdate<bool>.UpdateData update, bool newInput)
            {
                // Find InternationalDraughtAI
                InternationalDraughtAI internationalDraughtAI = null;
                {
                    EditData<InternationalDraughtAI> editInternationalDraughtAI = this.editAI.v;
                    if (editInternationalDraughtAI != null)
                    {
                        internationalDraughtAI = editInternationalDraughtAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editInternationalDraughtAI null: " + this);
                    }
                }
                // Process
                if (internationalDraughtAI != null)
                {
                    internationalDraughtAI.requestChangeInput(Server.getProfileUserId(internationalDraughtAI), newInput);
                }
                else
                {
                    Debug.LogError("internationalDraughtAI null: " + this);
                }
            }

            #endregion

            #region useEndGameDatabase

            public VP<RequestChangeBoolUI.UIData> useEndGameDatabase;

            public void makeRequestChangeUseEndGameDatabase(RequestChangeUpdate<bool>.UpdateData update, bool newUseEndGameDatabase)
            {
                // Find InternationalDraughtAI
                InternationalDraughtAI internationalDraughtAI = null;
                {
                    EditData<InternationalDraughtAI> editInternationalDraughtAI = this.editAI.v;
                    if (editInternationalDraughtAI != null)
                    {
                        internationalDraughtAI = editInternationalDraughtAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editInternationalDraughtAI null: " + this);
                    }
                }
                // Process
                if (internationalDraughtAI != null)
                {
                    internationalDraughtAI.requestChangeUseEndGameDatabase(Server.getProfileUserId(internationalDraughtAI), newUseEndGameDatabase);
                }
                else
                {
                    Debug.LogError("internationalDraughtAI null: " + this);
                }
            }

            #endregion

            #region pickBestMove

            public VP<RequestChangeIntUI.UIData> pickBestMove;

            public void makeRequestChangePickBestMove(RequestChangeUpdate<int>.UpdateData update, int newPickBestMove)
            {
                // Find InternationalDraughtAI
                InternationalDraughtAI internationalDraughtAI = null;
                {
                    EditData<InternationalDraughtAI> editInternationalDraughtAI = this.editAI.v;
                    if (editInternationalDraughtAI != null)
                    {
                        internationalDraughtAI = editInternationalDraughtAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editInternationalDraughtAI null: " + this);
                    }
                }
                // Process
                if (internationalDraughtAI != null)
                {
                    internationalDraughtAI.requestChangePickBestMove(Server.getProfileUserId(internationalDraughtAI), newPickBestMove);
                }
                else
                {
                    Debug.LogError("internationalDraughtAI null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editAI,
                showType,
                bMove,
                book,
                depth,
                time,
                input,
                useEndGameDatabase,
                pickBestMove
            }

            public UIData() : base()
            {
                this.editAI = new VP<EditData<InternationalDraughtAI>>(this, (byte)Property.editAI, new EditData<InternationalDraughtAI>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // Content
                {
                    // bMove
                    {
                        this.bMove = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.bMove, new RequestChangeBoolUI.UIData());
                        // event
                        this.bMove.v.updateData.v.request.v = makeRequestChangeBMove;
                    }
                    // book
                    {
                        this.book = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.book, new RequestChangeBoolUI.UIData());
                        // event
                        this.book.v.updateData.v.request.v = makeRequestChangeBook;
                    }
                    // depth
                    {
                        this.depth = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.depth, new RequestChangeIntUI.UIData());
                        // have limit
                        {
                            IntLimit.Have have = new IntLimit.Have();
                            {
                                have.uid = this.depth.v.limit.makeId();
                                have.min.v = 0;
                                have.max.v = 30;
                            }
                            this.depth.v.limit.v = have;
                        }
                        // event
                        this.depth.v.updateData.v.request.v = makeRequestChangeDepth;
                    }
                    // time
                    {
                        this.time = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.time, new RequestChangeFloatUI.UIData());
                        // event
                        this.time.v.updateData.v.request.v = makeRequestChangeTime;
                    }
                    // input
                    {
                        this.input = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.input, new RequestChangeBoolUI.UIData());
                        // event
                        this.input.v.updateData.v.request.v = makeRequestChangeInput;
                    }
                    // useEndGameDatabase
                    {
                        this.useEndGameDatabase = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.useEndGameDatabase, new RequestChangeBoolUI.UIData());
                        // event
                        this.useEndGameDatabase.v.updateData.v.request.v = makeRequestChangeUseEndGameDatabase;
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
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.InternationalDraught;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("International Draughts AI");

        public Text lbBMove;
        private static readonly TxtLanguage txtBMove = new TxtLanguage("BMove");

        public Text lbBook;
        private static readonly TxtLanguage txtBook = new TxtLanguage("Book");

        public Text lbDepth;
        private static readonly TxtLanguage txtDepth = new TxtLanguage("Depth");

        public Text lbTime;
        private static readonly TxtLanguage txtTime = new TxtLanguage("Time");

        public Text lbInput;
        private static readonly TxtLanguage txtInput = new TxtLanguage("Input");

        public Text lbUseEndGameDatabase;
        private static readonly TxtLanguage txtUseEndGameDatabase = new TxtLanguage("Use end game database");

        public Text lbPickBestMove;
        private static readonly TxtLanguage txtPickBestMove = new TxtLanguage("Pick best move");

        static InternationalDraughtAIUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Cờ Đam Kiểu Quốc Tế AI");
                txtBMove.add(Language.Type.vi, "BMove");
                txtBook.add(Language.Type.vi, "Dùng sách");
                txtDepth.add(Language.Type.vi, "Dộ sâu");
                txtTime.add(Language.Type.vi, "Thời gian");
                txtInput.add(Language.Type.vi, "Đầu vào");
                txtUseEndGameDatabase.add(Language.Type.vi, "Dùng cơ sở dữ liệu cuối game");
                txtPickBestMove.add(Language.Type.vi, "Chọn nước đi tốt nhất");
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
                    EditData<InternationalDraughtAI> editInternationalDraughtAI = this.data.editAI.v;
                    if (editInternationalDraughtAI != null)
                    {
                        editInternationalDraughtAI.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editInternationalDraughtAI);
                            // get server state
                            Server.State.Type serverState = RequestChange.GetServerState(editInternationalDraughtAI);
                            // set origin
                            {
                                RequestChange.RefreshUI(this.data.bMove.v, editInternationalDraughtAI, serverState, needReset, editData => editData.bMove.v);
                                RequestChange.RefreshUI(this.data.book.v, editInternationalDraughtAI, serverState, needReset, editData => editData.book.v);
                                RequestChange.RefreshUI(this.data.depth.v, editInternationalDraughtAI, serverState, needReset, editData => editData.depth.v);
                                RequestChange.RefreshUI(this.data.time.v, editInternationalDraughtAI, serverState, needReset, editData => editData.time.v);
                                RequestChange.RefreshUI(this.data.input.v, editInternationalDraughtAI, serverState, needReset, editData => editData.input.v);
                                RequestChange.RefreshUI(this.data.useEndGameDatabase.v, editInternationalDraughtAI, serverState, needReset, editData => editData.useEndGameDatabase.v);
                                RequestChange.RefreshUI(this.data.pickBestMove.v, editInternationalDraughtAI, serverState, needReset, editData => editData.pickBestMove.v);
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
                        // bMove
                        UIUtils.SetLabelContentPosition(lbBMove, this.data.bMove.v, ref deltaY);
                        // book
                        UIUtils.SetLabelContentPosition(lbBook, this.data.book.v, ref deltaY);
                        // depth
                        UIUtils.SetLabelContentPosition(lbDepth, this.data.depth.v, ref deltaY);
                        // time
                        UIUtils.SetLabelContentPosition(lbTime, this.data.time.v, ref deltaY);
                        // input
                        UIUtils.SetLabelContentPosition(lbInput, this.data.input.v, ref deltaY);
                        // useEndGameDatabase
                        UIUtils.SetLabelContentPosition(lbUseEndGameDatabase, this.data.useEndGameDatabase.v, ref deltaY);
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
                        if (lbBMove != null)
                        {
                            lbBMove.text = txtBMove.get();
                            Setting.get().setLabelTextSize(lbBMove);
                        }
                        else
                        {
                            Debug.LogError("lbBMove null: " + this);
                        }
                        if (lbBook != null)
                        {
                            lbBook.text = txtBook.get();
                            Setting.get().setLabelTextSize(lbBook);
                        }
                        else
                        {
                            Debug.LogError("lbBook null: " + this);
                        }
                        if (lbDepth != null)
                        {
                            lbDepth.text = txtDepth.get();
                            Setting.get().setLabelTextSize(lbDepth);
                        }
                        else
                        {
                            Debug.LogError("lbDepth null: " + this);
                        }
                        if (lbTime != null)
                        {
                            lbTime.text = txtTime.get();
                            Setting.get().setLabelTextSize(lbTime);
                        }
                        else
                        {
                            Debug.LogError("lbTime null: " + this);
                        }
                        if (lbInput != null)
                        {
                            lbInput.text = txtInput.get();
                            Setting.get().setLabelTextSize(lbInput);
                        }
                        else
                        {
                            Debug.LogError("lbInput null: " + this);
                        }
                        if (lbUseEndGameDatabase != null)
                        {
                            lbUseEndGameDatabase.text = txtUseEndGameDatabase.get();
                            Setting.get().setLabelTextSize(lbUseEndGameDatabase);
                        }
                        else
                        {
                            Debug.LogError("lbUseEndGameDatabase null: " + this);
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

        public RequestChangeIntUI requestIntPrefab;
        public RequestChangeFloatUI requestFloatPrefab;
        public RequestChangeBoolUI requestBoolPrefab;

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
                    uiData.bMove.allAddCallBack(this);
                    uiData.book.allAddCallBack(this);
                    uiData.depth.allAddCallBack(this);
                    uiData.time.allAddCallBack(this);
                    uiData.input.allAddCallBack(this);
                    uiData.useEndGameDatabase.allAddCallBack(this);
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
                    if (data is EditData<InternationalDraughtAI>)
                    {
                        EditData<InternationalDraughtAI> editAI = data as EditData<InternationalDraughtAI>;
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
                        if (data is InternationalDraughtAI)
                        {
                            InternationalDraughtAI internationalDraughtAI = data as InternationalDraughtAI;
                            // Parent
                            {
                                DataUtils.addParentCallBack(internationalDraughtAI, this, ref this.server);
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
                                case UIData.Property.bMove:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, UIConstants.RequestBoolRect);
                                    break;
                                case UIData.Property.book:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, UIConstants.RequestBoolRect);
                                    break;
                                case UIData.Property.input:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, UIConstants.RequestBoolRect);
                                    break;
                                case UIData.Property.useEndGameDatabase:
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
                                case UIData.Property.time:
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
                Setting.get().removeCallBack(this);
                // Child
                {
                    uiData.editAI.allRemoveCallBack(this);
                    uiData.bMove.allRemoveCallBack(this);
                    uiData.book.allRemoveCallBack(this);
                    uiData.depth.allRemoveCallBack(this);
                    uiData.time.allRemoveCallBack(this);
                    uiData.input.allRemoveCallBack(this);
                    uiData.useEndGameDatabase.allRemoveCallBack(this);
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
                    if (data is EditData<InternationalDraughtAI>)
                    {
                        EditData<InternationalDraughtAI> editAI = data as EditData<InternationalDraughtAI>;
                        // Child
                        {
                            editAI.show.allRemoveCallBack(this);
                            editAI.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is InternationalDraughtAI)
                        {
                            InternationalDraughtAI internationalDraughtAI = data as InternationalDraughtAI;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(internationalDraughtAI, this, ref this.server);
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
                if (data is RequestChangeIntUI.UIData)
                {
                    RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeIntUI));
                    }
                    return;
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
                    case UIData.Property.editAI:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.bMove:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.book:
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
                    case UIData.Property.input:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.useEndGameDatabase:
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
                // editAI
                {
                    if (wrapProperty.p is EditData<InternationalDraughtAI>)
                    {
                        switch ((EditData<InternationalDraughtAI>.Property)wrapProperty.n)
                        {
                            case EditData<InternationalDraughtAI>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<InternationalDraughtAI>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<InternationalDraughtAI>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<InternationalDraughtAI>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<InternationalDraughtAI>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<InternationalDraughtAI>.Property.editType:
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
                        if (wrapProperty.p is InternationalDraughtAI)
                        {
                            switch ((InternationalDraughtAI.Property)wrapProperty.n)
                            {
                                case InternationalDraughtAI.Property.bMove:
                                    dirty = true;
                                    break;
                                case InternationalDraughtAI.Property.book:
                                    dirty = true;
                                    break;
                                case InternationalDraughtAI.Property.depth:
                                    dirty = true;
                                    break;
                                case InternationalDraughtAI.Property.time:
                                    dirty = true;
                                    break;
                                case InternationalDraughtAI.Property.input:
                                    dirty = true;
                                    break;
                                case InternationalDraughtAI.Property.useEndGameDatabase:
                                    dirty = true;
                                    break;
                                case InternationalDraughtAI.Property.pickBestMove:
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
                if (wrapProperty.p is RequestChangeIntUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is RequestChangeBoolUI.UIData)
                {
                    return;
                }
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
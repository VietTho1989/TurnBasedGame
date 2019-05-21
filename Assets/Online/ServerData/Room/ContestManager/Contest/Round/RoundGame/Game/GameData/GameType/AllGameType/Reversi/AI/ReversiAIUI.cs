using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Reversi
{
    public class ReversiAIUI : UIHaveTransformDataBehavior<ReversiAIUI.UIData>
    {

        #region UIData

        public class UIData : AIUI.UIData.Sub
        {

            public VP<EditData<ReversiAI>> editAI;

            public VP<UIRectTransform.ShowType> showType;

            #region sort

            public VP<RequestChangeIntUI.UIData> sort;

            public void makeRequestChangeSort(RequestChangeUpdate<int>.UpdateData update, int newSort)
            {
                // Find ReversiAI
                ReversiAI reversiAI = null;
                {
                    EditData<ReversiAI> editReversiAI = this.editAI.v;
                    if (editReversiAI != null)
                    {
                        reversiAI = editReversiAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editReversiAI null: " + this);
                    }
                }
                // Process
                if (reversiAI != null)
                {
                    reversiAI.requestChangeSort(Server.getProfileUserId(reversiAI), newSort);
                }
                else
                {
                    Debug.LogError("reversiAI null: " + this);
                }
            }

            #endregion

            #region min

            public VP<RequestChangeIntUI.UIData> min;

            public void makeRequestChangeMin(RequestChangeUpdate<int>.UpdateData update, int newMin)
            {
                // Find ReversiAI
                ReversiAI reversiAI = null;
                {
                    EditData<ReversiAI> editReversiAI = this.editAI.v;
                    if (editReversiAI != null)
                    {
                        reversiAI = editReversiAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editReversiAI null: " + this);
                    }
                }
                // Process
                if (reversiAI != null)
                {
                    reversiAI.requestChangeMin(Server.getProfileUserId(reversiAI), newMin);
                }
                else
                {
                    Debug.LogError("reversiAI null: " + this);
                }
            }

            #endregion

            #region max

            public VP<RequestChangeIntUI.UIData> max;

            public void makeRequestChangeMax(RequestChangeUpdate<int>.UpdateData update, int newMax)
            {
                // Find ReversiAI
                ReversiAI reversiAI = null;
                {
                    EditData<ReversiAI> editReversiAI = this.editAI.v;
                    if (editReversiAI != null)
                    {
                        reversiAI = editReversiAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editReversiAI null: " + this);
                    }
                }
                // Process
                if (reversiAI != null)
                {
                    reversiAI.requestChangeMax(Server.getProfileUserId(reversiAI), newMax);
                }
                else
                {
                    Debug.LogError("reversiAI null: " + this);
                }
            }

            #endregion

            #region end

            public VP<RequestChangeIntUI.UIData> end;

            public void makeRequestChangeEnd(RequestChangeUpdate<int>.UpdateData update, int newEnd)
            {
                // Find ReversiAI
                ReversiAI reversiAI = null;
                {
                    EditData<ReversiAI> editReversiAI = this.editAI.v;
                    if (editReversiAI != null)
                    {
                        reversiAI = editReversiAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editReversiAI null: " + this);
                    }
                }
                // Process
                if (reversiAI != null)
                {
                    reversiAI.requestChangeEnd(Server.getProfileUserId(reversiAI), newEnd);
                }
                else
                {
                    Debug.LogError("reversiAI null: " + this);
                }
            }

            #endregion

            #region msLeft

            public VP<RequestChangeIntUI.UIData> msLeft;

            public void makeRequestChangeMsLeft(RequestChangeUpdate<int>.UpdateData update, int newMsLeft)
            {
                // Find ReversiAI
                ReversiAI reversiAI = null;
                {
                    EditData<ReversiAI> editReversiAI = this.editAI.v;
                    if (editReversiAI != null)
                    {
                        reversiAI = editReversiAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editReversiAI null: " + this);
                    }
                }
                // Process
                if (reversiAI != null)
                {
                    reversiAI.requestChangeMsLeft(Server.getProfileUserId(reversiAI), newMsLeft);
                }
                else
                {
                    Debug.LogError("reversiAI null: " + this);
                }
            }

            #endregion

            #region useBook

            public VP<RequestChangeBoolUI.UIData> useBook;

            public void makeRequestChangeUseBook(RequestChangeUpdate<bool>.UpdateData update, bool newUseBook)
            {
                // Find ReversiAI
                ReversiAI reversiAI = null;
                {
                    EditData<ReversiAI> editReversiAI = this.editAI.v;
                    if (editReversiAI != null)
                    {
                        reversiAI = editReversiAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editReversiAI null: " + this);
                    }
                }
                // Process
                if (reversiAI != null)
                {
                    reversiAI.requestChangeUseBook(Server.getProfileUserId(reversiAI), newUseBook);
                }
                else
                {
                    Debug.LogError("reversiAI null: " + this);
                }
            }

            #endregion

            #region percent

            public VP<RequestChangeIntUI.UIData> percent;

            public void makeRequestChangePercent(RequestChangeUpdate<int>.UpdateData update, int newPercent)
            {
                // Find ReversiAI
                ReversiAI reversiAI = null;
                {
                    EditData<ReversiAI> editReversiAI = this.editAI.v;
                    if (editReversiAI != null)
                    {
                        reversiAI = editReversiAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editReversiAI null: " + this);
                    }
                }
                // Process
                if (reversiAI != null)
                {
                    reversiAI.requestChangePercent(Server.getProfileUserId(reversiAI), newPercent);
                }
                else
                {
                    Debug.LogError("reversiAI null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editAI,
                showType,
                sort,
                min,
                max,
                end,
                msLeft,
                useBook,
                percent
            }

            public UIData() : base()
            {
                this.editAI = new VP<EditData<ReversiAI>>(this, (byte)Property.editAI, new EditData<ReversiAI>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // sort
                {
                    this.sort = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.sort, new RequestChangeIntUI.UIData());
                    // event
                    this.sort.v.updateData.v.request.v = makeRequestChangeSort;
                }
                // min
                {
                    this.min = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.min, new RequestChangeIntUI.UIData());
                    // event
                    this.min.v.updateData.v.request.v = makeRequestChangeMin;
                }
                // max
                {
                    this.max = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.max, new RequestChangeIntUI.UIData());
                    // event
                    this.max.v.updateData.v.request.v = makeRequestChangeMax;
                }
                // end
                {
                    this.end = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.end, new RequestChangeIntUI.UIData());
                    // event
                    this.end.v.updateData.v.request.v = makeRequestChangeEnd;
                }
                // msLeft
                {
                    this.msLeft = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.msLeft, new RequestChangeIntUI.UIData());
                    // event
                    this.msLeft.v.updateData.v.request.v = makeRequestChangeMsLeft;
                }
                // useBook
                {
                    this.useBook = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.useBook, new RequestChangeBoolUI.UIData());
                    // event
                    this.useBook.v.updateData.v.request.v = makeRequestChangeUseBook;
                }
                // percent
                {
                    this.percent = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.percent, new RequestChangeIntUI.UIData());
                    // event
                    this.percent.v.updateData.v.request.v = makeRequestChangePercent;
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.percent.v.limit.makeId();
                            have.min.v = 0;
                            have.max.v = 100;
                        }
                        this.percent.v.limit.v = have;
                    }
                }
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.Reversi;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Reversi ? 1 : 0;
        }

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Reversi AI");

        public Text lbSort;
        private static readonly TxtLanguage txtSort = new TxtLanguage("Sort");

        public Text lbMin;
        private static readonly TxtLanguage txtMin = new TxtLanguage("Min");

        public Text lbMax;
        private static readonly TxtLanguage txtMax = new TxtLanguage("Max");

        public Text lbEnd;
        private static readonly TxtLanguage txtEnd = new TxtLanguage("End");

        public Text lbMsLeft;
        private static readonly TxtLanguage txtMsLeft = new TxtLanguage("ms left");

        public Text lbUseBook;
        private static readonly TxtLanguage txtUseBook = new TxtLanguage("Use book");

        public Text lbPercent;
        private static readonly TxtLanguage txtPercent = new TxtLanguage("Percent");

        static ReversiAIUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Cờ Othello AI");
                txtSort.add(Language.Type.vi, "Sắp xếp");
                txtMin.add(Language.Type.vi, "Tối thiểu");
                txtMax.add(Language.Type.vi, "Tối đa");
                txtEnd.add(Language.Type.vi, "Kết thúc");
                txtMsLeft.add(Language.Type.vi, "Mili giấy còn lại");
                txtUseBook.add(Language.Type.vi, "Dùng sách");
                txtPercent.add(Language.Type.vi, "Phần trăm");
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
                    EditData<ReversiAI> editReversiAI = this.data.editAI.v;
                    if (editReversiAI != null)
                    {
                        editReversiAI.update();
                        // UI
                        {
                            // lbTitle
                            RequestChange.ShowDifferentTitle(lbTitle, editReversiAI);
                            // get server state
                            Server.State.Type serverState = RequestChange.GetServerState(editReversiAI);
                            // set origin
                            {
                                RequestChange.RefreshUI(this.data.sort.v, editReversiAI, serverState, needReset, editData => editData.sort.v);
                                RequestChange.RefreshUI(this.data.min.v, editReversiAI, serverState, needReset, editData => editData.min.v);
                                RequestChange.RefreshUI(this.data.max.v, editReversiAI, serverState, needReset, editData => editData.max.v);
                                RequestChange.RefreshUI(this.data.end.v, editReversiAI, serverState, needReset, editData => editData.end.v);
                                RequestChange.RefreshUI(this.data.msLeft.v, editReversiAI, serverState, needReset, editData => editData.msLeft.v);
                                RequestChange.RefreshUI(this.data.useBook.v, editReversiAI, serverState, needReset, editData => editData.useBook.v);
                                RequestChange.RefreshUI(this.data.percent.v, editReversiAI, serverState, needReset, editData => editData.percent.v);
                            }
                            needReset = false;
                        }
                    }
                    else
                    {
                        Debug.LogError("editReversiAI null: " + this);
                    }
                    // UI
                    {
                        float deltaY = 0;
                        // header
                        UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                        // sort
                        UIUtils.SetLabelContentPosition(lbSort, this.data.sort.v, ref deltaY);
                        // min
                        UIUtils.SetLabelContentPosition(lbMin, this.data.min.v, ref deltaY);
                        // max
                        UIUtils.SetLabelContentPosition(lbMax, this.data.max.v, ref deltaY);
                        // end
                        UIUtils.SetLabelContentPosition(lbEnd, this.data.end.v, ref deltaY);
                        // msLeft
                        UIUtils.SetLabelContentPosition(lbMsLeft, this.data.msLeft.v, ref deltaY);
                        // useBook
                        UIUtils.SetLabelContentPosition(lbUseBook, this.data.useBook.v, ref deltaY);
                        // percent
                        UIUtils.SetLabelContentPosition(lbPercent, this.data.percent.v, ref deltaY);
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
                        if (lbSort != null)
                        {
                            lbSort.text = txtSort.get();
                            Setting.get().setLabelTextSize(lbSort);
                        }
                        else
                        {
                            Debug.LogError("lbSort null: " + this);
                        }
                        if (lbMin != null)
                        {
                            lbMin.text = txtMin.get();
                            Setting.get().setLabelTextSize(lbMin);
                        }
                        else
                        {
                            Debug.LogError("lbMin null: " + this);
                        }
                        if (lbMax != null)
                        {
                            lbMax.text = txtMax.get();
                            Setting.get().setLabelTextSize(lbMax);
                        }
                        else
                        {
                            Debug.LogError("lbMax null: " + this);
                        }
                        if (lbEnd != null)
                        {
                            lbEnd.text = txtEnd.get();
                            Setting.get().setLabelTextSize(lbEnd);
                        }
                        else
                        {
                            Debug.LogError("lbEnd null: " + this);
                        }
                        if (lbMsLeft != null)
                        {
                            lbMsLeft.text = txtMsLeft.get();
                            Setting.get().setLabelTextSize(lbMsLeft);
                        }
                        else
                        {
                            Debug.LogError("lbMsLeft null: " + this);
                        }
                        if (lbUseBook != null)
                        {
                            lbUseBook.text = txtUseBook.get();
                            Setting.get().setLabelTextSize(lbUseBook);
                        }
                        else
                        {
                            Debug.LogError("lbUseBook null: " + this);
                        }
                        if (lbPercent != null)
                        {
                            lbPercent.text = txtPercent.get();
                            Setting.get().setLabelTextSize(lbPercent);
                        }
                        else
                        {
                            Debug.LogError("lbPercent null: " + this);
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
                    uiData.sort.allAddCallBack(this);
                    uiData.min.allAddCallBack(this);
                    uiData.max.allAddCallBack(this);
                    uiData.end.allAddCallBack(this);
                    uiData.msLeft.allAddCallBack(this);
                    uiData.useBook.allAddCallBack(this);
                    uiData.percent.allAddCallBack(this);
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
                    if (data is EditData<ReversiAI>)
                    {
                        EditData<ReversiAI> editAI = data as EditData<ReversiAI>;
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
                        if (data is ReversiAI)
                        {
                            ReversiAI reversiAI = data as ReversiAI;
                            // Parent
                            {
                                DataUtils.addParentCallBack(reversiAI, this, ref this.server);
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
                                case UIData.Property.sort:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                    break;
                                case UIData.Property.min:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                    break;
                                case UIData.Property.max:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                    break;
                                case UIData.Property.end:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                    break;
                                case UIData.Property.msLeft:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                    break;
                                case UIData.Property.percent:
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
                                case UIData.Property.useBook:
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
                    uiData.sort.allRemoveCallBack(this);
                    uiData.min.allRemoveCallBack(this);
                    uiData.max.allRemoveCallBack(this);
                    uiData.end.allRemoveCallBack(this);
                    uiData.msLeft.allRemoveCallBack(this);
                    uiData.useBook.allRemoveCallBack(this);
                    uiData.percent.allRemoveCallBack(this);
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
                    if (data is EditData<ReversiAI>)
                    {
                        EditData<ReversiAI> editAI = data as EditData<ReversiAI>;
                        // Child
                        {
                            editAI.show.allRemoveCallBack(this);
                            editAI.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is ReversiAI)
                        {
                            ReversiAI reversiAI = data as ReversiAI;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(reversiAI, this, ref this.server);
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
                    case UIData.Property.sort:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.min:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.max:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.end:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.msLeft:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.useBook:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.percent:
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
                    if (wrapProperty.p is EditData<ReversiAI>)
                    {
                        switch ((EditData<ReversiAI>.Property)wrapProperty.n)
                        {
                            case EditData<ReversiAI>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<ReversiAI>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<ReversiAI>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<ReversiAI>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<ReversiAI>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<ReversiAI>.Property.editType:
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
                        if (wrapProperty.p is ReversiAI)
                        {
                            switch ((ReversiAI.Property)wrapProperty.n)
                            {
                                case ReversiAI.Property.sort:
                                    dirty = true;
                                    break;
                                case ReversiAI.Property.min:
                                    dirty = true;
                                    break;
                                case ReversiAI.Property.max:
                                    dirty = true;
                                    break;
                                case ReversiAI.Property.end:
                                    dirty = true;
                                    break;
                                case ReversiAI.Property.msLeft:
                                    dirty = true;
                                    break;
                                case ReversiAI.Property.useBook:
                                    dirty = true;
                                    break;
                                case ReversiAI.Property.percent:
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
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
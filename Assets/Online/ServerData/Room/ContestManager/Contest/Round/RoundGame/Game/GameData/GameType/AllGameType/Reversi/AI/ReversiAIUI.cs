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
            // rect
            {
                sortRect.setPosY(UIConstants.HeaderHeight + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                minRect.setPosY(UIConstants.HeaderHeight + 1 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                maxRect.setPosY(UIConstants.HeaderHeight + 2 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                endRect.setPosY(UIConstants.HeaderHeight + 3 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                msLeftRect.setPosY(UIConstants.HeaderHeight + 4 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                useBookRect.setPosY(UIConstants.HeaderHeight + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                percentRect.setPosY(UIConstants.HeaderHeight + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
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
                        // get show
                        ReversiAI show = editReversiAI.show.v.data;
                        ReversiAI compare = editReversiAI.compare.v.data;
                        if (show != null)
                        {
                            // lbTitle
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editReversiAI.compareOtherType.v.data != null)
                                    {
                                        if (editReversiAI.compareOtherType.v.data.GetType() != show.GetType())
                                        {
                                            isDifferent = true;
                                        }
                                    }
                                }
                                lbTitle.color = isDifferent ? UIConstants.DifferentIndicatorColor : UIConstants.NormalTitleColor;
                            }
                            else
                            {
                                Debug.LogError("lbTitle null: " + this);
                            }
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
                                // sort
                                {
                                    RequestChangeIntUI.UIData sort = this.data.sort.v;
                                    if (sort != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<int>.UpdateData updateData = sort.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.sort.v;
                                            updateData.canRequestChange.v = editReversiAI.canEdit.v;
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
                                                sort.showDifferent.v = true;
                                                sort.compare.v = compare.sort.v;
                                            }
                                            else
                                            {
                                                sort.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("sort null: " + this);
                                    }
                                }
                                // min
                                {
                                    RequestChangeIntUI.UIData min = this.data.min.v;
                                    if (min != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<int>.UpdateData updateData = min.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.min.v;
                                            updateData.canRequestChange.v = editReversiAI.canEdit.v;
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
                                                min.showDifferent.v = true;
                                                min.compare.v = compare.min.v;
                                            }
                                            else
                                            {
                                                min.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("min null: " + this);
                                    }
                                }
                                // max
                                {
                                    RequestChangeIntUI.UIData max = this.data.max.v;
                                    if (max != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<int>.UpdateData updateData = max.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.max.v;
                                            updateData.canRequestChange.v = editReversiAI.canEdit.v;
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
                                                max.showDifferent.v = true;
                                                max.compare.v = compare.max.v;
                                            }
                                            else
                                            {
                                                max.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("max null: " + this);
                                    }
                                }
                                // end
                                {
                                    RequestChangeIntUI.UIData end = this.data.end.v;
                                    if (end != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<int>.UpdateData updateData = end.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.end.v;
                                            updateData.canRequestChange.v = editReversiAI.canEdit.v;
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
                                                end.showDifferent.v = true;
                                                end.compare.v = compare.end.v;
                                            }
                                            else
                                            {
                                                end.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("end null: " + this);
                                    }
                                }
                                // msLeft
                                {
                                    RequestChangeIntUI.UIData msLeft = this.data.msLeft.v;
                                    if (msLeft != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<int>.UpdateData updateData = msLeft.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.msLeft.v;
                                            updateData.canRequestChange.v = editReversiAI.canEdit.v;
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
                                                msLeft.showDifferent.v = true;
                                                msLeft.compare.v = compare.msLeft.v;
                                            }
                                            else
                                            {
                                                msLeft.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("msLeft null: " + this);
                                    }
                                }
                                // useBook
                                {
                                    RequestChangeBoolUI.UIData useBook = this.data.useBook.v;
                                    if (useBook != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<bool>.UpdateData updateData = useBook.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.useBook.v;
                                            updateData.canRequestChange.v = editReversiAI.canEdit.v;
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
                                                useBook.showDifferent.v = true;
                                                useBook.compare.v = compare.useBook.v;
                                            }
                                            else
                                            {
                                                useBook.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("useBook null: " + this);
                                    }
                                }
                                // percent
                                {
                                    RequestChangeIntUI.UIData percent = this.data.percent.v;
                                    if (percent != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<int>.UpdateData updateData = percent.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.percent.v;
                                            updateData.canRequestChange.v = editReversiAI.canEdit.v;
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
                                                percent.showDifferent.v = true;
                                                percent.compare.v = compare.percent.v;
                                            }
                                            else
                                            {
                                                percent.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("percent null: " + this);
                                    }
                                }
                            }
                            // reset?
                            if (needReset)
                            {
                                needReset = false;
                                // sort
                                {
                                    RequestChangeIntUI.UIData sort = this.data.sort.v;
                                    if (sort != null)
                                    {
                                        RequestChangeUpdate<int>.UpdateData updateData = sort.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.sort.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("sort null: " + this);
                                    }
                                }
                                // min
                                {
                                    RequestChangeIntUI.UIData min = this.data.min.v;
                                    if (min != null)
                                    {
                                        RequestChangeUpdate<int>.UpdateData updateData = min.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.min.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("min null: " + this);
                                    }
                                }
                                // max
                                {
                                    RequestChangeIntUI.UIData max = this.data.max.v;
                                    if (max != null)
                                    {
                                        RequestChangeUpdate<int>.UpdateData updateData = max.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.max.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("max null: " + this);
                                    }
                                }
                                // end
                                {
                                    RequestChangeIntUI.UIData end = this.data.end.v;
                                    if (end != null)
                                    {
                                        RequestChangeUpdate<int>.UpdateData updateData = end.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.end.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("end null: " + this);
                                    }
                                }
                                // msLeft
                                {
                                    RequestChangeIntUI.UIData msLeft = this.data.msLeft.v;
                                    if (msLeft != null)
                                    {
                                        RequestChangeUpdate<int>.UpdateData updateData = msLeft.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.msLeft.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("msLeft null: " + this);
                                    }
                                }
                                // useBook
                                {
                                    RequestChangeBoolUI.UIData useBook = this.data.useBook.v;
                                    if (useBook != null)
                                    {
                                        RequestChangeUpdate<bool>.UpdateData updateData = useBook.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.useBook.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("useBook null: " + this);
                                    }
                                }
                                // percent
                                {
                                    RequestChangeIntUI.UIData percent = this.data.percent.v;
                                    if (percent != null)
                                    {
                                        RequestChangeUpdate<int>.UpdateData updateData = percent.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.percent.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("percent null: " + this);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("reversiAI null: " + this);
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
                                case UIRectTransform.ShowType.OnlyHead:
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + this.data.showType.v);
                                    break;
                            }
                        }
                        // sort
                        {
                            if (this.data.sort.v != null)
                            {
                                if (lbSort != null)
                                {
                                    lbSort.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbSort.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbSort null");
                                }
                                UIRectTransform.SetPosY(this.data.sort.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbSort != null)
                                {
                                    lbSort.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbSort null");
                                }
                            }
                        }
                        // min
                        {
                            if (this.data.min.v != null)
                            {
                                if (lbMin != null)
                                {
                                    lbMin.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbMin.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbMin null");
                                }
                                UIRectTransform.SetPosY(this.data.min.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbMin != null)
                                {
                                    lbMin.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbMin null");
                                }
                            }
                        }
                        // max
                        {
                            if (this.data.max.v != null)
                            {
                                if (lbMax != null)
                                {
                                    lbMax.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbMax.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbMax null");
                                }
                                UIRectTransform.SetPosY(this.data.max.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbMax != null)
                                {
                                    lbMax.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbMax null");
                                }
                            }
                        }
                        // end
                        {
                            if (this.data.end.v != null)
                            {
                                if (lbEnd != null)
                                {
                                    lbEnd.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbEnd.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbEnd null");
                                }
                                UIRectTransform.SetPosY(this.data.end.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbEnd != null)
                                {
                                    lbEnd.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbEnd null");
                                }
                            }
                        }
                        // msLeft
                        {
                            if (this.data.msLeft.v != null)
                            {
                                if (lbMsLeft != null)
                                {
                                    lbMsLeft.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbMsLeft.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbMsLeft null");
                                }
                                UIRectTransform.SetPosY(this.data.msLeft.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbMsLeft != null)
                                {
                                    lbMsLeft.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbMsLeft null");
                                }
                            }
                        }
                        // useBook
                        {
                            if (this.data.useBook.v != null)
                            {
                                if (lbUseBook != null)
                                {
                                    lbUseBook.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbUseBook.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbUseBook null");
                                }
                                UIRectTransform.SetPosY(this.data.useBook.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbUseBook != null)
                                {
                                    lbUseBook.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbUseBook null");
                                }
                            }
                        }
                        // percent
                        {
                            if (this.data.percent.v != null)
                            {
                                if (lbPercent != null)
                                {
                                    lbPercent.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbPercent.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbPercent null");
                                }
                                UIRectTransform.SetPosY(this.data.percent.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbPercent != null)
                                {
                                    lbPercent.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbPercent null");
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

        private static readonly UIRectTransform sortRect = new UIRectTransform(UIConstants.RequestRect);
        private static readonly UIRectTransform minRect = new UIRectTransform(UIConstants.RequestRect);
        private static readonly UIRectTransform maxRect = new UIRectTransform(UIConstants.RequestRect);
        private static readonly UIRectTransform endRect = new UIRectTransform(UIConstants.RequestRect);
        private static readonly UIRectTransform msLeftRect = new UIRectTransform(UIConstants.RequestRect);
        private static readonly UIRectTransform useBookRect = new UIRectTransform(UIConstants.RequestBoolRect);
        private static readonly UIRectTransform percentRect = new UIRectTransform(UIConstants.RequestRect);

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
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, sortRect);
                                    break;
                                case UIData.Property.min:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, minRect);
                                    break;
                                case UIData.Property.max:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, maxRect);
                                    break;
                                case UIData.Property.end:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, endRect);
                                    break;
                                case UIData.Property.msLeft:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, msLeftRect);
                                    break;
                                case UIData.Property.percent:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, percentRect);
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
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, useBookRect);
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
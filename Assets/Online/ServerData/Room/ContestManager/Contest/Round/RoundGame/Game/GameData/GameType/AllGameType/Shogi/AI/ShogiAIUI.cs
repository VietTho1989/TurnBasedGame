using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Shogi
{
    public class ShogiAIUI : UIHaveTransformDataBehavior<ShogiAIUI.UIData>
    {

        #region UIData

        public class UIData : AIUI.UIData.Sub
        {

            public VP<EditData<ShogiAI>> editAI;

            public VP<UIRectTransform.ShowType> showType;

            #region depth

            public VP<RequestChangeIntUI.UIData> depth;

            public void makeRequestChangeDepth(RequestChangeUpdate<int>.UpdateData update, int newDepth)
            {
                // Find shogiAI
                ShogiAI shogiAI = null;
                {
                    EditData<ShogiAI> editShogiAI = this.editAI.v;
                    if (editShogiAI != null)
                    {
                        shogiAI = editShogiAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editShogiAI null: " + this);
                    }
                }
                // Process
                if (shogiAI != null)
                {
                    shogiAI.requestChangeDepth(Server.getProfileUserId(shogiAI), newDepth);
                }
                else
                {
                    Debug.LogError("shogiAI null: " + this);
                }
            }

            #endregion

            #region skillLevel

            public VP<RequestChangeIntUI.UIData> skillLevel;

            public void makeRequestChangeSkillLevel(RequestChangeUpdate<int>.UpdateData update, int newSkillLevel)
            {
                // Find shogiAI
                ShogiAI shogiAI = null;
                {
                    EditData<ShogiAI> editShogiAI = this.editAI.v;
                    if (editShogiAI != null)
                    {
                        shogiAI = editShogiAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editShogiAI null: " + this);
                    }
                }
                // Process
                if (shogiAI != null)
                {
                    shogiAI.requestChangeSkillLevel(Server.getProfileUserId(shogiAI), newSkillLevel);
                }
                else
                {
                    Debug.LogError("shogiAI null: " + this);
                }
            }

            #endregion

            #region mr

            /** max_random_score_diff*/
            public VP<RequestChangeIntUI.UIData> mr;

            public void makeRequestChangeMr(RequestChangeUpdate<int>.UpdateData update, int newMr)
            {
                // Find shogiAI
                ShogiAI shogiAI = null;
                {
                    EditData<ShogiAI> editShogiAI = this.editAI.v;
                    if (editShogiAI != null)
                    {
                        shogiAI = editShogiAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editShogiAI null: " + this);
                    }
                }
                // Process
                if (shogiAI != null)
                {
                    shogiAI.requestChangeMr(Server.getProfileUserId(shogiAI), newMr);
                }
                else
                {
                    Debug.LogError("shogiAI null: " + this);
                }
            }

            #endregion

            #region duration

            public VP<RequestChangeIntUI.UIData> duration;

            public void makeRequestChangeDuration(RequestChangeUpdate<int>.UpdateData update, int newDuration)
            {
                // Find shogiAI
                ShogiAI shogiAI = null;
                {
                    EditData<ShogiAI> editShogiAI = this.editAI.v;
                    if (editShogiAI != null)
                    {
                        shogiAI = editShogiAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editShogiAI null: " + this);
                    }
                }
                // Process
                if (shogiAI != null)
                {
                    shogiAI.requestChangeDuration(Server.getProfileUserId(shogiAI), newDuration);
                }
                else
                {
                    Debug.LogError("shogiAI null: " + this);
                }
            }

            #endregion

            #region useBook

            public VP<RequestChangeBoolUI.UIData> useBook;

            public void makeRequestChangeUseBook(RequestChangeUpdate<bool>.UpdateData update, bool newUseBook)
            {
                // Find shogiAI
                ShogiAI shogiAI = null;
                {
                    EditData<ShogiAI> editShogiAI = this.editAI.v;
                    if (editShogiAI != null)
                    {
                        shogiAI = editShogiAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editShogiAI null: " + this);
                    }
                }
                // Process
                if (shogiAI != null)
                {
                    shogiAI.requestChangeUseBook(Server.getProfileUserId(shogiAI), newUseBook);
                }
                else
                {
                    Debug.LogError("shogiAI null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editAI,
                showType,
                depth,
                skillLevel,
                mr,
                duration,
                useBook
            }

            public UIData() : base()
            {
                this.editAI = new VP<EditData<ShogiAI>>(this, (byte)Property.editAI, new EditData<ShogiAI>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
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
                // skillLevel
                {
                    this.skillLevel = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.skillLevel, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.skillLevel.v.limit.makeId();
                            have.min.v = 0;
                            have.max.v = 20;
                        }
                        this.skillLevel.v.limit.v = have;
                    }
                    // event
                    this.skillLevel.v.updateData.v.request.v = makeRequestChangeSkillLevel;
                }
                // mr
                {
                    this.mr = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.mr, new RequestChangeIntUI.UIData());
                    // event
                    this.mr.v.updateData.v.request.v = makeRequestChangeMr;
                }
                // duration
                {
                    this.duration = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.duration, new RequestChangeIntUI.UIData());
                    // event
                    this.duration.v.updateData.v.request.v = makeRequestChangeDuration;
                }
                // useBook
                {
                    this.useBook = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.useBook, new RequestChangeBoolUI.UIData());
                    // event
                    this.useBook.v.updateData.v.request.v = makeRequestChangeUseBook;
                }
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.SHOGI;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage();

        public Text lbDepth;
        private static readonly TxtLanguage txtDepth = new TxtLanguage();

        public Text lbSkillLevel;
        private static readonly TxtLanguage txtSkillLevel = new TxtLanguage();

        public Text lbMr;
        private static readonly TxtLanguage txtMr = new TxtLanguage();

        public Text lbDuration;
        private static readonly TxtLanguage txtDuration = new TxtLanguage();

        public Text lbUseBook;
        private static readonly TxtLanguage txtUseBook = new TxtLanguage();

        static ShogiAIUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Cờ Shogi AI");
                txtDepth.add(Language.Type.vi, "Độ sâu");
                txtSkillLevel.add(Language.Type.vi, "Cấp độ kỹ năng");
                txtMr.add(Language.Type.vi, "mr");
                txtDuration.add(Language.Type.vi, "Thời gian");
                txtUseBook.add(Language.Type.vi, "Dùng sách");
            }
            // rect
            {
                depthRect.setPosY(UIConstants.HeaderHeight + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                skillLevelRect.setPosY(UIConstants.HeaderHeight + 1 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                mrRect.setPosY(UIConstants.HeaderHeight + 2 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                durationRect.setPosY(UIConstants.HeaderHeight + 3 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                useBookRect.setPosY(UIConstants.HeaderHeight + 4 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
            }
        }

        #endregion

        #region Refresh

        private bool needReset = true;

        public Image header;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EditData<ShogiAI> editShogiAI = this.data.editAI.v;
                    if (editShogiAI != null)
                    {
                        editShogiAI.update();
                        // get show
                        ShogiAI show = editShogiAI.show.v.data;
                        ShogiAI compare = editShogiAI.compare.v.data;
                        if (show != null)
                        {
                            // different
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editShogiAI.compareOtherType.v.data != null)
                                    {
                                        if (editShogiAI.compareOtherType.v.data.GetType() != show.GetType())
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
                                // depth
                                {
                                    RequestChangeIntUI.UIData depth = this.data.depth.v;
                                    if (depth != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<int>.UpdateData updateData = depth.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.depth.v;
                                            updateData.canRequestChange.v = editShogiAI.canEdit.v;
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
                                // skillLevel
                                {
                                    RequestChangeIntUI.UIData skillLevel = this.data.skillLevel.v;
                                    if (skillLevel != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<int>.UpdateData updateData = skillLevel.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.skillLevel.v;
                                            updateData.canRequestChange.v = editShogiAI.canEdit.v;
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
                                                skillLevel.showDifferent.v = true;
                                                skillLevel.compare.v = compare.skillLevel.v;
                                            }
                                            else
                                            {
                                                skillLevel.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("skillLevel null: " + this);
                                    }
                                }
                                // mr
                                {
                                    RequestChangeIntUI.UIData mr = this.data.mr.v;
                                    if (mr != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<int>.UpdateData updateData = mr.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.mr.v;
                                            updateData.canRequestChange.v = editShogiAI.canEdit.v;
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
                                                mr.showDifferent.v = true;
                                                mr.compare.v = compare.mr.v;
                                            }
                                            else
                                            {
                                                mr.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("mr null: " + this);
                                    }
                                }
                                // duration
                                {
                                    RequestChangeIntUI.UIData duration = this.data.duration.v;
                                    if (duration != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<int>.UpdateData updateData = duration.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.duration.v;
                                            updateData.canRequestChange.v = editShogiAI.canEdit.v;
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
                                                duration.showDifferent.v = true;
                                                duration.compare.v = compare.duration.v;
                                            }
                                            else
                                            {
                                                duration.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("duration null: " + this);
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
                                            updateData.canRequestChange.v = editShogiAI.canEdit.v;
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
                            }
                            // reset?
                            if (needReset)
                            {
                                needReset = false;
                                // depth
                                {
                                    RequestChangeIntUI.UIData depth = this.data.depth.v;
                                    if (depth != null)
                                    {
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
                                // skillLevel
                                {
                                    RequestChangeIntUI.UIData skillLevel = this.data.skillLevel.v;
                                    if (skillLevel != null)
                                    {
                                        RequestChangeUpdate<int>.UpdateData updateData = skillLevel.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.skillLevel.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("skillLevel null: " + this);
                                    }
                                }
                                // mr
                                {
                                    RequestChangeIntUI.UIData mr = this.data.mr.v;
                                    if (mr != null)
                                    {
                                        RequestChangeUpdate<int>.UpdateData updateData = mr.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.mr.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("mr null: " + this);
                                    }
                                }
                                // duration
                                {
                                    RequestChangeIntUI.UIData duration = this.data.duration.v;
                                    if (duration != null)
                                    {
                                        RequestChangeUpdate<int>.UpdateData updateData = duration.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.duration.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("duration null: " + this);
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
                            }
                        }
                        else
                        {
                            Debug.LogError("shatranjAI null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("editShatranjAI null: " + this);
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
                                        if (header != null)
                                        {
                                            header.gameObject.SetActive(true);
                                        }
                                        else
                                        {
                                            Debug.LogError("header null");
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
                                        if (header != null)
                                        {
                                            header.gameObject.SetActive(false);
                                        }
                                        else
                                        {
                                            Debug.LogError("header null");
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
                        // depth
                        {
                            if (this.data.depth.v != null)
                            {
                                if (lbDepth != null)
                                {
                                    lbDepth.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbDepth.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbDepth null");
                                }
                                UIRectTransform.SetPosY(this.data.depth.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbDepth != null)
                                {
                                    lbDepth.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbDepth null");
                                }
                            }
                        }
                        // skillLevel
                        {
                            if (this.data.skillLevel.v != null)
                            {
                                if (lbSkillLevel != null)
                                {
                                    lbSkillLevel.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbSkillLevel.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbSkillLevel null");
                                }
                                UIRectTransform.SetPosY(this.data.skillLevel.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbSkillLevel != null)
                                {
                                    lbSkillLevel.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbSkillLevel null");
                                }
                            }
                        }
                        // mr
                        {
                            if (this.data.mr.v != null)
                            {
                                if (lbMr != null)
                                {
                                    lbMr.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbMr.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbMr null");
                                }
                                UIRectTransform.SetPosY(this.data.mr.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbMr != null)
                                {
                                    lbMr.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbMr null");
                                }
                            }
                        }
                        // duration
                        {
                            if (this.data.duration.v != null)
                            {
                                if (lbDuration != null)
                                {
                                    lbDuration.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbDuration.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbDuration null");
                                }
                                UIRectTransform.SetPosY(this.data.duration.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbDuration != null)
                                {
                                    lbDuration.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbDuration null");
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
                        // set
                        UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get("Shogi AI");
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                        if (lbDepth != null)
                        {
                            lbDepth.text = txtDepth.get("Depth");
                        }
                        else
                        {
                            Debug.LogError("lbDepth null: " + this);
                        }
                        if (lbSkillLevel != null)
                        {
                            lbSkillLevel.text = txtSkillLevel.get("Skill level");
                        }
                        else
                        {
                            Debug.LogError("lbSkillLevel null: " + this);
                        }
                        if (lbMr != null)
                        {
                            lbMr.text = txtMr.get("mr");
                        }
                        else
                        {
                            Debug.LogError("lbMr null: " + this);
                        }
                        if (lbDuration != null)
                        {
                            lbDuration.text = txtDuration.get("Duration");
                        }
                        else
                        {
                            Debug.LogError("lbDuration null: " + this);
                        }
                        if (lbUseBook != null)
                        {
                            lbUseBook.text = txtUseBook.get("Use book");
                        }
                        else
                        {
                            Debug.LogError("lbUseBook null: " + this);
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

        private static readonly UIRectTransform depthRect = new UIRectTransform(UIConstants.RequestRect);
        private static readonly UIRectTransform skillLevelRect = new UIRectTransform(UIConstants.RequestRect);
        private static readonly UIRectTransform mrRect = new UIRectTransform(UIConstants.RequestRect);
        private static readonly UIRectTransform durationRect = new UIRectTransform(UIConstants.RequestRect);
        private static readonly UIRectTransform useBookRect = new UIRectTransform(UIConstants.RequestBoolRect);

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
                    uiData.depth.allAddCallBack(this);
                    uiData.skillLevel.allAddCallBack(this);
                    uiData.mr.allAddCallBack(this);
                    uiData.duration.allAddCallBack(this);
                    uiData.useBook.allAddCallBack(this);
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
                    if (data is EditData<ShogiAI>)
                    {
                        EditData<ShogiAI> editAI = data as EditData<ShogiAI>;
                        // Child
                        {
                            editAI.show.allAddCallBack(this);
                            editAI.compare.allRemoveCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is ShogiAI)
                        {
                            ShogiAI shogiAI = data as ShogiAI;
                            // Parent
                            {
                                DataUtils.addParentCallBack(shogiAI, this, ref this.server);
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
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, depthRect);
                                    break;
                                case UIData.Property.skillLevel:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, skillLevelRect);
                                    break;
                                case UIData.Property.mr:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, mrRect);
                                    break;
                                case UIData.Property.duration:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, durationRect);
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
                    uiData.depth.allRemoveCallBack(this);
                    uiData.skillLevel.allRemoveCallBack(this);
                    uiData.mr.allRemoveCallBack(this);
                    uiData.duration.allRemoveCallBack(this);
                    uiData.useBook.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
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
                    if (data is EditData<ShogiAI>)
                    {
                        EditData<ShogiAI> editAI = data as EditData<ShogiAI>;
                        // Child
                        {
                            editAI.show.allRemoveCallBack(this);
                            editAI.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is ShogiAI)
                        {
                            ShogiAI shogiAI = data as ShogiAI;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(shogiAI, this, ref this.server);
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
                    case UIData.Property.depth:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.skillLevel:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.mr:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.duration:
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
                    if (wrapProperty.p is EditData<ShogiAI>)
                    {
                        switch ((EditData<ShogiAI>.Property)wrapProperty.n)
                        {
                            case EditData<ShogiAI>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<ShogiAI>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<ShogiAI>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<ShogiAI>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<ShogiAI>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<ShogiAI>.Property.editType:
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
                        if (wrapProperty.p is ShogiAI)
                        {
                            switch ((ShogiAI.Property)wrapProperty.n)
                            {
                                case ShogiAI.Property.depth:
                                    dirty = true;
                                    break;
                                case ShogiAI.Property.skillLevel:
                                    dirty = true;
                                    break;
                                case ShogiAI.Property.mr:
                                    dirty = true;
                                    break;
                                case ShogiAI.Property.duration:
                                    dirty = true;
                                    break;
                                case ShogiAI.Property.useBook:
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
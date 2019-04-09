using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
    public class EliminationFactoryUI : UIHaveTransformDataBehavior<EliminationFactoryUI.UIData>
    {

        #region UIData

        public class UIData : ContestManagerContentFactoryUI.UIData.Sub
        {

            public VP<EditData<EliminationFactory>> editEliminationFactory;

            #region singleContestFactory

            public VP<SingleContestFactoryUI.UIData> singleContestFactory;

            #endregion

            #region initTeamCounts

            public VP<RequestChangeIntUI.UIData> initTeamCountLength;

            public void makeRequestChangeInitTeamCountLength(RequestChangeUpdate<int>.UpdateData update, int newInitTeamCountLength)
            {
                // Find
                EliminationFactory eliminationFactory = null;
                {
                    EditData<EliminationFactory> editEliminationFactory = this.editEliminationFactory.v;
                    if (editEliminationFactory != null)
                    {
                        eliminationFactory = editEliminationFactory.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editEliminationFactory null: " + this);
                    }
                }
                // Process
                if (eliminationFactory != null)
                {
                    eliminationFactory.requestChangeInitTeamCountLength(Server.getProfileUserId(eliminationFactory), newInitTeamCountLength);
                }
                else
                {
                    Debug.LogError("roundRobinFactory null: " + this);
                }
            }

            public LP<RequestChangeIntUI.UIData> initTeamCounts;

            public void makeRequestChangeInitTeamCount(RequestChangeUpdate<int>.UpdateData update, int newInitTeamCount)
            {
                // Find
                EliminationFactory eliminationFactory = null;
                {
                    EditData<EliminationFactory> editEliminationFactory = this.editEliminationFactory.v;
                    if (editEliminationFactory != null)
                    {
                        eliminationFactory = editEliminationFactory.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editEliminationFactory null: " + this);
                    }
                }
                // Process
                if (eliminationFactory != null)
                {
                    int index = 0;
                    {
                        EliminationFactoryUI.UIData eliminationFactoryUIData = update.findDataInParent<EliminationFactoryUI.UIData>();
                        if (eliminationFactoryUIData != null)
                        {
                            RequestChangeIntUI.UIData requestInt = update.findDataInParent<RequestChangeIntUI.UIData>();
                            if (requestInt != null)
                            {
                                index = eliminationFactoryUIData.initTeamCounts.vs.IndexOf(requestInt);
                            }
                            else
                            {
                                Debug.LogError("requestInt null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("eliminationFactoryUIData null: " + this);
                        }
                    }
                    eliminationFactory.requestChangeInitTeamCount(Server.getProfileUserId(eliminationFactory), index, (uint)newInitTeamCount);
                }
                else
                {
                    Debug.LogError("roundRobinFactory null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editEliminationFactory,
                singleContestFactory,
                initTeamCountLength,
                initTeamCounts

            }

            public UIData() : base()
            {
                this.editEliminationFactory = new VP<EditData<EliminationFactory>>(this, (byte)Property.editEliminationFactory, new EditData<EliminationFactory>());
                this.singleContestFactory = new VP<SingleContestFactoryUI.UIData>(this, (byte)Property.singleContestFactory, new SingleContestFactoryUI.UIData());
                // initTeamCountLength
                {
                    this.initTeamCountLength = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.initTeamCountLength, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.initTeamCountLength.v.limit.makeId();
                            have.min.v = 1;
                            have.max.v = EliminationContent.MAX_BRACKET;
                        }
                        this.initTeamCountLength.v.limit.v = have;
                    }
                    // event
                    this.initTeamCountLength.v.updateData.v.request.v = makeRequestChangeInitTeamCountLength;
                }
                // initTeamCounts
                this.initTeamCounts = new LP<RequestChangeIntUI.UIData>(this, (byte)Property.initTeamCounts);
            }

            #endregion

            public override ContestManagerContent.Type getType()
            {
                return ContestManagerContent.Type.Elimination;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // singleContestFactory
                    if (!isProcess)
                    {
                        SingleContestFactoryUI.UIData singleContestFactoryUIData = this.singleContestFactory.v;
                        if (singleContestFactoryUIData != null)
                        {
                            isProcess = singleContestFactoryUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("singleContestFactoryUIData null: " + this);
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Elimination Factory");

        public Text lbInitTeamCountLength;
        private static readonly TxtLanguage txtInitTeamCountLength = new TxtLanguage("Bracket count");

        public Text lbInitTeamCounts;
        private static readonly TxtLanguage txtInitTeamCounts = new TxtLanguage("Team counts");

        static EliminationFactoryUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Tạo đấu loại trực tiếp");
                txtInitTeamCountLength.add(Language.Type.vi, "Số nhánh đấu");
                txtInitTeamCounts.add(Language.Type.vi, "Số đội");
            }
            // rect
            {

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
                    EditData<EliminationFactory> editEliminationFactory = this.data.editEliminationFactory.v;
                    if (editEliminationFactory != null)
                    {
                        editEliminationFactory.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editEliminationFactory);
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = RequestChange.GetServerState(editEliminationFactory);
                                // set origin
                                {
                                    // singleContestFactory
                                    {
                                        SingleContestFactoryUI.UIData singleContestFactory = this.data.singleContestFactory.v;
                                        if (singleContestFactory != null)
                                        {
                                            EditData<SingleContestFactory> editSingleContestFactory = singleContestFactory.editSingleContestFactory.v;
                                            if (editSingleContestFactory != null)
                                            {
                                                // origin
                                                {
                                                    SingleContestFactory originSingleContestFactory = null;
                                                    {
                                                        EliminationFactory originEliminationFactory = editEliminationFactory.origin.v.data;
                                                        if (originEliminationFactory != null)
                                                        {
                                                            originSingleContestFactory = originEliminationFactory.singleContestFactory.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("originSingleContestFactory null: " + this);
                                                        }
                                                    }
                                                    editSingleContestFactory.origin.v = new ReferenceData<SingleContestFactory>(originSingleContestFactory);
                                                }
                                                // show
                                                {
                                                    SingleContestFactory showSingleContestFactory = null;
                                                    {
                                                        EliminationFactory showEliminationFactory = editEliminationFactory.show.v.data;
                                                        if (showEliminationFactory != null)
                                                        {
                                                            showSingleContestFactory = showEliminationFactory.singleContestFactory.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("showEliminationFactory null: " + this);
                                                        }
                                                    }
                                                    editSingleContestFactory.show.v = new ReferenceData<SingleContestFactory>(showSingleContestFactory);
                                                }
                                                // compare
                                                {
                                                    SingleContestFactory compareSingleContestFactory = null;
                                                    {
                                                        EliminationFactory compareEliminationFactory = editEliminationFactory.compare.v.data;
                                                        if (compareEliminationFactory != null)
                                                        {
                                                            compareSingleContestFactory = compareEliminationFactory.singleContestFactory.v;
                                                        }
                                                        else
                                                        {
                                                            // Debug.LogError ("compareEliminationFactory null: " + this);
                                                        }
                                                    }
                                                    editSingleContestFactory.compare.v = new ReferenceData<SingleContestFactory>(compareSingleContestFactory);
                                                }
                                                // compare other type
                                                {
                                                    SingleContestFactory compareOtherTypeSingleContestFactory = null;
                                                    {
                                                        EliminationFactory compareOtherTypeEliminationFactory = (EliminationFactory)editEliminationFactory.compareOtherType.v.data;
                                                        if (compareOtherTypeEliminationFactory != null)
                                                        {
                                                            compareOtherTypeSingleContestFactory = compareOtherTypeEliminationFactory.singleContestFactory.v;
                                                        }
                                                    }
                                                    editSingleContestFactory.compareOtherType.v = new ReferenceData<Data>(compareOtherTypeSingleContestFactory);
                                                }
                                                // canEdit
                                                editSingleContestFactory.canEdit.v = editEliminationFactory.canEdit.v;
                                                // editType
                                                editSingleContestFactory.editType.v = editEliminationFactory.editType.v;
                                            }
                                            else
                                            {
                                                Debug.LogError("editSingleContestFactory null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("singleContestFactory null: " + this);
                                        }
                                    }
                                    RequestChange.RefreshUI(this.data.initTeamCountLength.v, editEliminationFactory, serverState, needReset, editData => editData.initTeamCounts.vs.Count);
                                    // initTeamCounts
                                    {
                                        EliminationFactory show = editEliminationFactory.show.v.data;
                                        EliminationFactory compare = editEliminationFactory.compare.v.data;
                                        if (show != null)
                                        {
                                            // find old
                                            List<RequestChangeIntUI.UIData> oldInitTeamCounts = new List<RequestChangeIntUI.UIData>();
                                            {
                                                oldInitTeamCounts.AddRange(this.data.initTeamCounts.vs);
                                            }
                                            // Update
                                            {
                                                for (int i = 0; i < show.initTeamCounts.vs.Count; i++)
                                                {
                                                    // find
                                                    RequestChangeIntUI.UIData initTeamCount = null;
                                                    {
                                                        // find old
                                                        if (oldInitTeamCounts.Count > 0)
                                                        {
                                                            initTeamCount = oldInitTeamCounts[0];
                                                        }
                                                        // make new
                                                        if (initTeamCount == null)
                                                        {
                                                            initTeamCount = new RequestChangeIntUI.UIData();
                                                            {
                                                                initTeamCount.uid = this.data.initTeamCounts.makeId();
                                                                // have limit
                                                                {
                                                                    IntLimit.Have have = new IntLimit.Have();
                                                                    {
                                                                        have.uid = initTeamCount.limit.makeId();
                                                                        have.min.v = i == 0 ? 4 : 0;
                                                                        have.max.v = EliminationContent.MAX_TEAM_PER_BRACKET;
                                                                    }
                                                                    initTeamCount.limit.v = have;
                                                                }
                                                                // event
                                                                initTeamCount.updateData.v.request.v = this.data.makeRequestChangeInitTeamCount;
                                                            }
                                                            this.data.initTeamCounts.add(initTeamCount);
                                                        }
                                                        else
                                                        {
                                                            oldInitTeamCounts.Remove(initTeamCount);
                                                        }
                                                    }
                                                    // Process
                                                    if (initTeamCount != null)
                                                    {
                                                        // update
                                                        RequestChangeUpdate<int>.UpdateData updateData = initTeamCount.updateData.v;
                                                        if (updateData != null)
                                                        {
                                                            updateData.origin.v = (int)show.initTeamCounts.vs[i];
                                                            updateData.canRequestChange.v = editEliminationFactory.canEdit.v;
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
                                                                initTeamCount.showDifferent.v = true;
                                                                {
                                                                    int compareInitTeamCount = int.MinValue;
                                                                    {
                                                                        if (i >= 0 && i < compare.initTeamCounts.vs.Count)
                                                                        {
                                                                            compareInitTeamCount = (int)compare.initTeamCounts.vs[i];
                                                                        }
                                                                    }
                                                                    initTeamCount.compare.v = compareInitTeamCount;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                initTeamCount.showDifferent.v = false;
                                                            }
                                                        }
                                                        // reset
                                                        if (needReset)
                                                        {
                                                            // current
                                                            {
                                                                int current = 0;
                                                                {
                                                                    if (i >= 0 && i < show.initTeamCounts.vs.Count)
                                                                    {
                                                                        current = (int)show.initTeamCounts.vs[i];
                                                                    }
                                                                    else
                                                                    {
                                                                        Debug.LogError("index error: " + i + "; " + show.initTeamCounts.vs.Count);
                                                                    }
                                                                }
                                                                updateData.current.v = current;
                                                            }
                                                            updateData.changeState.v = Data.ChangeState.None;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("initTeamCount null: " + this);
                                                    }
                                                }
                                            }
                                            // Remove old
                                            foreach (RequestChangeIntUI.UIData oldInitTeamCount in oldInitTeamCounts)
                                            {
                                                this.data.initTeamCounts.remove(oldInitTeamCount);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("show null");
                                        }
                                    }
                                }
                                needReset = false;
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("editElimination null: " + this);
                    }
                    // UI Size
                    {
                        float deltaY = UIConstants.HeaderHeight;
                        // singleContestFactory
                        deltaY += UIRectTransform.SetPosY(this.data.singleContestFactory.v, deltaY);
                        // initTeamCountLength
                        {
                            if (lbInitTeamCountLength != null)
                            {
                                UIRectTransform.SetPosY(lbInitTeamCountLength.rectTransform, deltaY);
                            }
                            else
                            {
                                Debug.LogError("lbInitTeamCountLength null");
                            }
                            UIRectTransform.SetPosY(this.data.initTeamCountLength.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                            deltaY += UIConstants.ItemHeight;
                        }
                        // initTeamCounts
                        {
                            if (lbInitTeamCounts != null)
                            {
                                UIRectTransform.SetPosY(lbInitTeamCounts.rectTransform, deltaY);
                            }
                            else
                            {
                                Debug.LogError("lbInitTeamCounts null");
                            }
                            foreach (RequestChangeIntUI.UIData initTeamCount in this.data.initTeamCounts.vs)
                            {
                                UIRectTransform.SetPosY(initTeamCount, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
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
                        if (lbInitTeamCountLength != null)
                        {
                            lbInitTeamCountLength.text = txtInitTeamCountLength.get();
                            Setting.get().setLabelTextSize(lbInitTeamCountLength);
                        }
                        else
                        {
                            Debug.LogError("lbInitTeamCountLength null: " + this);
                        }
                        if (lbInitTeamCounts != null)
                        {
                            lbInitTeamCounts.text = txtInitTeamCounts.get();
                            Setting.get().setLabelTextSize(lbInitTeamCounts);
                        }
                        else
                        {
                            Debug.LogError("lbInitTeamCounts null: " + this);
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

        public SingleContestFactoryUI singleContestFactoryPrefab;
        public RequestChangeIntUI requestIntPrefab;

        private static readonly UIRectTransform initTeamCountLengthRect = new UIRectTransform(UIConstants.RequestRect);
        private static readonly UIRectTransform initTeamCountsRect = new UIRectTransform(UIConstants.RequestRect);

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
                    uiData.editEliminationFactory.allAddCallBack(this);
                    uiData.singleContestFactory.allAddCallBack(this);
                    uiData.initTeamCountLength.allAddCallBack(this);
                    uiData.initTeamCounts.allAddCallBack(this);
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
                // editEliminationFactory
                {
                    if (data is EditData<EliminationFactory>)
                    {
                        EditData<EliminationFactory> editEliminationFactory = data as EditData<EliminationFactory>;
                        // Child
                        {
                            editEliminationFactory.show.allAddCallBack(this);
                            editEliminationFactory.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is EliminationFactory)
                        {
                            EliminationFactory eliminationFactory = data as EliminationFactory;
                            // Parent
                            {
                                DataUtils.addParentCallBack(eliminationFactory, this, ref this.server);
                            }
                            needReset = true;
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
                // initTeamCountLength, initTeamCounts
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
                                case UIData.Property.initTeamCountLength:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, initTeamCountLengthRect);
                                    break;
                                case UIData.Property.initTeamCounts:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, initTeamCountsRect);
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
                // singleContestFactoryUIData
                {
                    if (data is SingleContestFactoryUI.UIData)
                    {
                        SingleContestFactoryUI.UIData singleContestFactoryUIData = data as SingleContestFactoryUI.UIData;
                        // UI
                        {
                            UIUtils.Instantiate(singleContestFactoryUIData, singleContestFactoryPrefab, this.transform);
                        }
                        // Child
                        {
                            TransformData.AddCallBack(singleContestFactoryUIData, this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is TransformData)
                    {
                        dirty = true;
                        return;
                    }
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
                    uiData.editEliminationFactory.allRemoveCallBack(this);
                    uiData.singleContestFactory.allRemoveCallBack(this);
                    uiData.initTeamCountLength.allRemoveCallBack(this);
                    uiData.initTeamCounts.allRemoveCallBack(this);
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
                // editEliminationFactory
                {
                    if (data is EditData<EliminationFactory>)
                    {
                        EditData<EliminationFactory> editEliminationFactory = data as EditData<EliminationFactory>;
                        // Child
                        {
                            editEliminationFactory.show.allRemoveCallBack(this);
                            editEliminationFactory.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is EliminationFactory)
                        {
                            EliminationFactory eliminationFactory = data as EliminationFactory;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(eliminationFactory, this, ref this.server);
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
                // intTeamCountLength, initTeamCounts
                if (data is RequestChangeIntUI.UIData)
                {
                    RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeIntUI));
                    }
                    return;
                }
                // singleContestFactoryUIData
                {
                    if (data is SingleContestFactoryUI.UIData)
                    {
                        SingleContestFactoryUI.UIData singleContestFactoryUIData = data as SingleContestFactoryUI.UIData;
                        // Child
                        {
                            TransformData.RemoveCallBack(singleContestFactoryUIData, this);
                        }
                        // UI
                        {
                            singleContestFactoryUIData.removeCallBackAndDestroy(typeof(SingleContestFactoryUI));
                        }
                        return;
                    }
                    // Child
                    if (data is TransformData)
                    {
                        return;
                    }
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
                    case UIData.Property.editEliminationFactory:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.singleContestFactory:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.initTeamCountLength:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.initTeamCounts:
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
                // editEliminationFactory
                {
                    if (wrapProperty.p is EditData<EliminationFactory>)
                    {
                        switch ((EditData<EliminationFactory>.Property)wrapProperty.n)
                        {
                            case EditData<EliminationFactory>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<EliminationFactory>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<EliminationFactory>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<EliminationFactory>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<EliminationFactory>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<EliminationFactory>.Property.editType:
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
                        if (wrapProperty.p is EliminationFactory)
                        {
                            switch ((EliminationFactory.Property)wrapProperty.n)
                            {
                                case EliminationFactory.Property.singleContestFactory:
                                    dirty = true;
                                    break;
                                case EliminationFactory.Property.initTeamCounts:
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
                // teamCount
                if (wrapProperty.p is RequestChangeIntUI.UIData)
                {
                    return;
                }
                // singleContestFactoryUIData
                {
                    if (wrapProperty.p is SingleContestFactoryUI.UIData)
                    {
                        return;
                    }
                    // Child
                    if (wrapProperty.p is TransformData)
                    {
                        switch ((TransformData.Property)wrapProperty.n)
                        {
                            case TransformData.Property.anchoredPosition:
                                break;
                            case TransformData.Property.anchorMin:
                                break;
                            case TransformData.Property.anchorMax:
                                break;
                            case TransformData.Property.pivot:
                                break;
                            case TransformData.Property.offsetMin:
                                break;
                            case TransformData.Property.offsetMax:
                                break;
                            case TransformData.Property.sizeDelta:
                                break;
                            case TransformData.Property.rotation:
                                break;
                            case TransformData.Property.scale:
                                break;
                            case TransformData.Property.size:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
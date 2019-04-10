using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
    public class RoundRobinFactoryUI : UIHaveTransformDataBehavior<RoundRobinFactoryUI.UIData>
    {

        #region UIData

        public class UIData : ContestManagerContentFactoryUI.UIData.Sub
        {

            public VP<EditData<RoundRobinFactory>> editRoundRobinFactory;

            #region singleContestFactory

            public VP<SingleContestFactoryUI.UIData> singleContestFactory;

            #endregion

            #region teamCount

            public VP<RequestChangeIntUI.UIData> teamCount;

            public void makeRequestChangeTeamCount(RequestChangeUpdate<int>.UpdateData update, int newTeamCount)
            {
                // Find
                RoundRobinFactory roundRobinFactory = null;
                {
                    EditData<RoundRobinFactory> editRoundRobinFactory = this.editRoundRobinFactory.v;
                    if (editRoundRobinFactory != null)
                    {
                        roundRobinFactory = editRoundRobinFactory.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editRoundRobinFactory null: " + this);
                    }
                }
                // Process
                if (roundRobinFactory != null)
                {
                    roundRobinFactory.requestChangeTeamCount(Server.getProfileUserId(roundRobinFactory), newTeamCount);
                }
                else
                {
                    Debug.LogError("roundRobinFactory null: " + this);
                }
            }

            #endregion

            #region needReturnRound

            public VP<RequestChangeBoolUI.UIData> needReturnRound;

            public void makeRequestChangeNeedReturnRound(RequestChangeUpdate<bool>.UpdateData update, bool newNeedReturnRound)
            {
                // Find
                RoundRobinFactory roundRobinFactory = null;
                {
                    EditData<RoundRobinFactory> editRoundRobinFactory = this.editRoundRobinFactory.v;
                    if (editRoundRobinFactory != null)
                    {
                        roundRobinFactory = editRoundRobinFactory.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editRoundRobinFactory null: " + this);
                    }
                }
                // Process
                if (roundRobinFactory != null)
                {
                    roundRobinFactory.requestChangeNeedReturnRound(Server.getProfileUserId(roundRobinFactory), newNeedReturnRound);
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
                editRoundRobinFactory,
                singleContestFactory,
                teamCount,
                needReturnRound
            }

            public UIData() : base()
            {
                this.editRoundRobinFactory = new VP<EditData<RoundRobinFactory>>(this, (byte)Property.editRoundRobinFactory, new EditData<RoundRobinFactory>());
                this.singleContestFactory = new VP<SingleContestFactoryUI.UIData>(this, (byte)Property.singleContestFactory, new SingleContestFactoryUI.UIData());
                // teamCount
                {
                    this.teamCount = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.teamCount, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.teamCount.v.limit.makeId();
                            have.min.v = 3;
                            have.max.v = 30;
                        }
                        this.teamCount.v.limit.v = have;
                    }
                    // event
                    this.teamCount.v.updateData.v.request.v = makeRequestChangeTeamCount;
                }
                // needReturnRound
                {
                    this.needReturnRound = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.needReturnRound, new RequestChangeBoolUI.UIData());
                    this.needReturnRound.v.updateData.v.request.v = makeRequestChangeNeedReturnRound;
                }
            }

            #endregion

            public override ContestManagerContent.Type getType()
            {
                return ContestManagerContent.Type.RoundRobin;
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
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Round-robin Factory");

        public Text lbTeamCount;
        private static readonly TxtLanguage txtTeamCount = new TxtLanguage("Team count");

        public Text lbNeedReturnRound;
        private static readonly TxtLanguage txtNeedReturnRound = new TxtLanguage("Need return round");

        static RoundRobinFactoryUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Tạo Giải Đấu Vòng Tròn");
                txtTeamCount.add(Language.Type.vi, "Số đội");
                txtNeedReturnRound.add(Language.Type.vi, "Cần vòng đấu lại");
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
                    EditData<RoundRobinFactory> editRoundRobinFactory = this.data.editRoundRobinFactory.v;
                    if (editRoundRobinFactory != null)
                    {
                        editRoundRobinFactory.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editRoundRobinFactory);
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = RequestChange.GetServerState(editRoundRobinFactory);
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
                                                        RoundRobinFactory originRoundRobinFactory = editRoundRobinFactory.origin.v.data;
                                                        if (originRoundRobinFactory != null)
                                                        {
                                                            originSingleContestFactory = originRoundRobinFactory.singleContestFactory.v;
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
                                                        RoundRobinFactory showRoundRobinFactory = editRoundRobinFactory.show.v.data;
                                                        if (showRoundRobinFactory != null)
                                                        {
                                                            showSingleContestFactory = showRoundRobinFactory.singleContestFactory.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("showRoundRobinFactory null: " + this);
                                                        }
                                                    }
                                                    editSingleContestFactory.show.v = new ReferenceData<SingleContestFactory>(showSingleContestFactory);
                                                }
                                                // compare
                                                {
                                                    SingleContestFactory compareSingleContestFactory = null;
                                                    {
                                                        RoundRobinFactory compareRoundRobinFactory = editRoundRobinFactory.compare.v.data;
                                                        if (compareRoundRobinFactory != null)
                                                        {
                                                            compareSingleContestFactory = compareRoundRobinFactory.singleContestFactory.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("compareRoundRobinFactory null: " + this);
                                                        }
                                                    }
                                                    editSingleContestFactory.compare.v = new ReferenceData<SingleContestFactory>(compareSingleContestFactory);
                                                }
                                                // compare other type
                                                {
                                                    SingleContestFactory compareOtherTypeSingleContestFactory = null;
                                                    {
                                                        RoundRobinFactory compareOtherTypeRoundRobinFactory = (RoundRobinFactory)editRoundRobinFactory.compareOtherType.v.data;
                                                        if (compareOtherTypeRoundRobinFactory != null)
                                                        {
                                                            compareOtherTypeSingleContestFactory = compareOtherTypeRoundRobinFactory.singleContestFactory.v;
                                                        }
                                                    }
                                                    editSingleContestFactory.compareOtherType.v = new ReferenceData<Data>(compareOtherTypeSingleContestFactory);
                                                }
                                                // canEdit
                                                editSingleContestFactory.canEdit.v = editRoundRobinFactory.canEdit.v;
                                                // editType
                                                editSingleContestFactory.editType.v = editRoundRobinFactory.editType.v;
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
                                    RequestChange.RefreshUI(this.data.teamCount.v, editRoundRobinFactory, serverState, needReset, editData => editData.teamCount.v);
                                    RequestChange.RefreshUI(this.data.needReturnRound.v, editRoundRobinFactory, serverState, needReset, editData => editData.needReturnRound.v);
                                }
                                needReset = false;
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("editRoundRobinFactory null: " + this);
                    }
                    // UI Size
                    {
                        float deltaY = UIConstants.HeaderHeight;
                        // teamCount
                        UIUtils.SetLabelContentPosition(lbTeamCount, this.data.teamCount.v, ref deltaY);
                        // needReturnRound
                        UIUtils.SetLabelContentPosition(lbNeedReturnRound, this.data.needReturnRound.v, ref deltaY);
                        // singleContestFactory
                        deltaY += UIRectTransform.SetPosY(this.data.singleContestFactory.v, deltaY);
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
                        if (lbTeamCount != null)
                        {
                            lbTeamCount.text = txtTeamCount.get();
                            Setting.get().setLabelTextSize(lbTeamCount);
                        }
                        else
                        {
                            Debug.LogError("lbTeamCount null: " + this);
                        }
                        if (lbNeedReturnRound != null)
                        {
                            lbNeedReturnRound.text = txtNeedReturnRound.get();
                            Setting.get().setLabelTextSize(lbNeedReturnRound);
                        }
                        else
                        {
                            Debug.LogError("lbNeedReturnRound null: " + this);
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
                    uiData.editRoundRobinFactory.allAddCallBack(this);
                    uiData.singleContestFactory.allAddCallBack(this);
                    uiData.teamCount.allAddCallBack(this);
                    uiData.needReturnRound.allAddCallBack(this);
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
                // editRoundRobinFactory
                {
                    if (data is EditData<RoundRobinFactory>)
                    {
                        EditData<RoundRobinFactory> editRoundRobinFactory = data as EditData<RoundRobinFactory>;
                        // Child
                        {
                            editRoundRobinFactory.show.allAddCallBack(this);
                            editRoundRobinFactory.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is RoundRobinFactory)
                        {
                            RoundRobinFactory roundRobinFactory = data as RoundRobinFactory;
                            // Parent
                            {
                                DataUtils.addParentCallBack(roundRobinFactory, this, ref this.server);
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
                // teamCount
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
                                case UIData.Property.teamCount:
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
                // needReturnRound
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
                                case UIData.Property.needReturnRound:
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
                    uiData.editRoundRobinFactory.allRemoveCallBack(this);
                    uiData.singleContestFactory.allRemoveCallBack(this);
                    uiData.teamCount.allRemoveCallBack(this);
                    uiData.needReturnRound.allRemoveCallBack(this);
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
                // editRoundRobinFactory
                {
                    if (data is EditData<RoundRobinFactory>)
                    {
                        EditData<RoundRobinFactory> editRoundRobinFactory = data as EditData<RoundRobinFactory>;
                        // Child
                        {
                            editRoundRobinFactory.show.allRemoveCallBack(this);
                            editRoundRobinFactory.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is RoundRobinFactory)
                        {
                            RoundRobinFactory roundRobinFactory = data as RoundRobinFactory;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(roundRobinFactory, this, ref this.server);
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
                // teamCount
                if (data is RequestChangeIntUI.UIData)
                {
                    RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeIntUI));
                    }
                    return;
                }
                // needReturnRound
                if (data is RequestChangeBoolUI.UIData)
                {
                    RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeBoolUI));
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
                    case UIData.Property.editRoundRobinFactory:
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
                    case UIData.Property.teamCount:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.needReturnRound:
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
                // editRoundRobinFactory
                {
                    if (wrapProperty.p is EditData<RoundRobinFactory>)
                    {
                        switch ((EditData<RoundRobinFactory>.Property)wrapProperty.n)
                        {
                            case EditData<RoundRobinFactory>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<RoundRobinFactory>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<RoundRobinFactory>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<RoundRobinFactory>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<RoundRobinFactory>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<RoundRobinFactory>.Property.editType:
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
                        if (wrapProperty.p is RoundRobinFactory)
                        {
                            switch ((RoundRobinFactory.Property)wrapProperty.n)
                            {
                                case RoundRobinFactory.Property.singleContestFactory:
                                    dirty = true;
                                    break;
                                case RoundRobinFactory.Property.teamCount:
                                    dirty = true;
                                    break;
                                case RoundRobinFactory.Property.needReturnRound:
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
                // needReturnRound
                if (wrapProperty.p is RequestChangeBoolUI.UIData)
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
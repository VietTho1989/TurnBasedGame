using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Gomoku
{
    public class GomokuAIUI : UIHaveTransformDataBehavior<GomokuAIUI.UIData>
    {

        #region UIData

        public class UIData : AIUI.UIData.Sub
        {

            public VP<EditData<GomokuAI>> editAI;

            public VP<UIRectTransform.ShowType> showType;

            #region searchDepth

            public VP<RequestChangeIntUI.UIData> searchDepth;

            public void makeRequestChangeSearchDepth(RequestChangeUpdate<int>.UpdateData update, int newSearchDepth)
            {
                // Find gomokuAI
                GomokuAI gomokuAI = null;
                {
                    EditData<GomokuAI> editGomokuAI = this.editAI.v;
                    if (editGomokuAI != null)
                    {
                        gomokuAI = editGomokuAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editGomokuAI null: " + this);
                    }
                }
                // Process
                if (gomokuAI != null)
                {
                    gomokuAI.requestChangeSearchDepth(Server.getProfileUserId(gomokuAI), newSearchDepth);
                }
                else
                {
                    Debug.LogError("gomokuAI null: " + this);
                }
            }

            #endregion

            #region timeLimit

            public VP<RequestChangeIntUI.UIData> timeLimit;

            public void makeRequestChangeTimeLimit(RequestChangeUpdate<int>.UpdateData update, int newTimeLimit)
            {
                // Find gomokuAI
                GomokuAI gomokuAI = null;
                {
                    EditData<GomokuAI> editGomokuAI = this.editAI.v;
                    if (editGomokuAI != null)
                    {
                        gomokuAI = editGomokuAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editGomokuAI null: " + this);
                    }
                }
                // Process
                if (gomokuAI != null)
                {
                    gomokuAI.requestChangeTimeLimit(Server.getProfileUserId(gomokuAI), newTimeLimit);
                }
                else
                {
                    Debug.LogError("gomokuAI null: " + this);
                }
            }

            #endregion

            #region level

            public VP<RequestChangeIntUI.UIData> level;

            public void makeRequestChangeLevel(RequestChangeUpdate<int>.UpdateData update, int newLevel)
            {
                // Find gomokuAI
                GomokuAI gomokuAI = null;
                {
                    EditData<GomokuAI> editGomokuAI = this.editAI.v;
                    if (editGomokuAI != null)
                    {
                        gomokuAI = editGomokuAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editGomokuAI null: " + this);
                    }
                }
                // Process
                if (gomokuAI != null)
                {
                    gomokuAI.requestChangeLevel(Server.getProfileUserId(gomokuAI), newLevel);
                }
                else
                {
                    Debug.LogError("gomokuAI null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editAI,
                showType,
                searchDepth,
                timeLimit,
                level
            }

            public UIData() : base()
            {
                this.editAI = new VP<EditData<GomokuAI>>(this, (byte)Property.editAI, new EditData<GomokuAI>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // Content
                {
                    // searchDepth
                    {
                        this.searchDepth = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.searchDepth, new RequestChangeIntUI.UIData());
                        // have limit
                        {
                            IntLimit.Have have = new IntLimit.Have();
                            {
                                have.uid = this.searchDepth.v.limit.makeId();
                                have.min.v = 0;
                                have.max.v = 30;
                            }
                            this.searchDepth.v.limit.v = have;
                        }
                        // event
                        this.searchDepth.v.updateData.v.request.v = makeRequestChangeSearchDepth;
                    }
                    // timeLimit
                    {
                        this.timeLimit = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.timeLimit, new RequestChangeIntUI.UIData());
                        // event
                        this.timeLimit.v.updateData.v.request.v = makeRequestChangeTimeLimit;
                    }
                    // level
                    {
                        this.level = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.level, new RequestChangeIntUI.UIData());
                        // have limit
                        {
                            IntLimit.Have have = new IntLimit.Have();
                            {
                                have.uid = this.level.v.limit.makeId();
                                have.min.v = 0;
                                have.max.v = 20;
                            }
                            this.level.v.limit.v = have;
                        }
                        // event
                        this.level.v.updateData.v.request.v = makeRequestChangeLevel;
                    }
                }
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.Gomoku;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Gomoku AI");

        public Text lbSearchDepth;
        private static readonly TxtLanguage txtSearchDepth = new TxtLanguage("Search depth");

        public Text lbTimeLimit;
        private static readonly TxtLanguage txtTimeLimit = new TxtLanguage("Time limit");

        public Text lbLevel;
        private static readonly TxtLanguage txtLevel = new TxtLanguage("Level");

        static GomokuAIUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Cờ Caro AI");
                txtSearchDepth.add(Language.Type.vi, "Độ sâu tìm kiếm");
                txtTimeLimit.add(Language.Type.vi, "Thời gian giới hạn");
                txtLevel.add(Language.Type.vi, "Cấp độ");
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
                    EditData<GomokuAI> editGomokuAI = this.data.editAI.v;
                    if (editGomokuAI != null)
                    {
                        editGomokuAI.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editGomokuAI);
                            // get server state
                            Server.State.Type serverState = RequestChange.GetServerState(editGomokuAI);
                            // set origin
                            {
                                RequestChange.RefreshUI(this.data.searchDepth.v, editGomokuAI, serverState, needReset, editData => editData.searchDepth.v);
                                RequestChange.RefreshUI(this.data.timeLimit.v, editGomokuAI, serverState, needReset, editData => editData.timeLimit.v);
                                RequestChange.RefreshUI(this.data.level.v, editGomokuAI, serverState, needReset, editData => editData.level.v);
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
                        // searchDepth
                        UIUtils.SetLabelContentPosition(lbSearchDepth, this.data.searchDepth.v, ref deltaY);
                        // timeLimit
                        UIUtils.SetLabelContentPosition(lbTimeLimit, this.data.timeLimit.v, ref deltaY);
                        // level
                        UIUtils.SetLabelContentPosition(lbLevel, this.data.level.v, ref deltaY);
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
                        if (lbSearchDepth != null)
                        {
                            lbSearchDepth.text = txtSearchDepth.get();
                            Setting.get().setLabelTextSize(lbSearchDepth);
                        }
                        else
                        {
                            Debug.LogError("lbSearchDepth null: " + this);
                        }
                        if (lbTimeLimit != null)
                        {
                            lbTimeLimit.text = txtTimeLimit.get();
                            Setting.get().setLabelTextSize(lbTimeLimit);
                        }
                        else
                        {
                            Debug.LogError("lbTimeLimit null: " + this);
                        }
                        if (lbLevel != null)
                        {
                            lbLevel.text = txtLevel.get();
                            Setting.get().setLabelTextSize(lbLevel);
                        }
                        else
                        {
                            Debug.LogError("lbLevel null: " + this);
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
                    uiData.searchDepth.allAddCallBack(this);
                    uiData.timeLimit.allAddCallBack(this);
                    uiData.level.allAddCallBack(this);
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
                    if (data is EditData<GomokuAI>)
                    {
                        EditData<GomokuAI> editAI = data as EditData<GomokuAI>;
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
                        if (data is GomokuAI)
                        {
                            GomokuAI gomokuAI = data as GomokuAI;
                            // Parent
                            {
                                DataUtils.addParentCallBack(gomokuAI, this, ref this.server);
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
                                case UIData.Property.searchDepth:
                                    {
                                        UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                    }
                                    break;
                                case UIData.Property.timeLimit:
                                    {
                                        UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                    }
                                    break;
                                case UIData.Property.level:
                                    {
                                        UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                    }
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
                    uiData.searchDepth.allRemoveCallBack(this);
                    uiData.timeLimit.allRemoveCallBack(this);
                    uiData.level.allRemoveCallBack(this);
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
                    if (data is EditData<GomokuAI>)
                    {
                        EditData<GomokuAI> editAI = data as EditData<GomokuAI>;
                        // Child
                        {
                            editAI.show.allRemoveCallBack(this);
                            editAI.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is GomokuAI)
                        {
                            GomokuAI gomokuAI = data as GomokuAI;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(gomokuAI, this, ref this.server);
                            }
                            return;
                        }
                        if (data is Server)
                        {
                            return;
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
                    case UIData.Property.searchDepth:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.timeLimit:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.level:
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
                    if (wrapProperty.p is EditData<GomokuAI>)
                    {
                        switch ((EditData<GomokuAI>.Property)wrapProperty.n)
                        {
                            case EditData<GomokuAI>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<GomokuAI>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<GomokuAI>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<GomokuAI>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<GomokuAI>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<GomokuAI>.Property.editType:
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
                        if (wrapProperty.p is GomokuAI)
                        {
                            switch ((GomokuAI.Property)wrapProperty.n)
                            {
                                case GomokuAI.Property.searchDepth:
                                    dirty = true;
                                    break;
                                case GomokuAI.Property.timeLimit:
                                    dirty = true;
                                    break;
                                case GomokuAI.Property.level:
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
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
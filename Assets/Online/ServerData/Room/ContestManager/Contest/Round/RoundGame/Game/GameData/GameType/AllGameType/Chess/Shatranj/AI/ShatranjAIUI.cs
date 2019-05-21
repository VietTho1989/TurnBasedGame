using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Shatranj
{
    public class ShatranjAIUI : UIHaveTransformDataBehavior<ShatranjAIUI.UIData>
    {

        #region UIData

        public class UIData : AIUI.UIData.Sub
        {

            public VP<EditData<ShatranjAI>> editAI;

            public VP<UIRectTransform.ShowType> showType;

            #region depth

            public VP<RequestChangeIntUI.UIData> depth;

            public void makeRequestChangeDepth(RequestChangeUpdate<int>.UpdateData update, int newDepth)
            {
                // Find shatranjAI
                ShatranjAI shatranjAI = null;
                {
                    EditData<ShatranjAI> editShatranjAI = this.editAI.v;
                    if (editShatranjAI != null)
                    {
                        shatranjAI = editShatranjAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editShatranjAI null: " + this);
                    }
                }
                // Process
                if (shatranjAI != null)
                {
                    shatranjAI.requestChangeDepth(Server.getProfileUserId(shatranjAI), newDepth);
                }
                else
                {
                    Debug.LogError("shatranjAI null: " + this);
                }
            }

            #endregion

            #region skillLevel

            public VP<RequestChangeIntUI.UIData> skillLevel;

            public void makeRequestChangeSkillLevel(RequestChangeUpdate<int>.UpdateData update, int newSkillLevel)
            {
                // Find shatranjAI
                ShatranjAI shatranjAI = null;
                {
                    EditData<ShatranjAI> editShatranjAI = this.editAI.v;
                    if (editShatranjAI != null)
                    {
                        shatranjAI = editShatranjAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editShatranjAI null: " + this);
                    }
                }
                // Process
                if (shatranjAI != null)
                {
                    shatranjAI.requestChangeSkillLevel(Server.getProfileUserId(shatranjAI), newSkillLevel);
                }
                else
                {
                    Debug.LogError("shatranjAI null: " + this);
                }
            }

            #endregion

            #region Duration

            public VP<RequestChangeLongUI.UIData> duration;

            public void makeRequestChangeDuration(RequestChangeUpdate<long>.UpdateData update, long newDuration)
            {
                // Find shatranjAI
                ShatranjAI shatranjAI = null;
                {
                    EditData<ShatranjAI> editShatranjAI = this.editAI.v;
                    if (editShatranjAI != null)
                    {
                        shatranjAI = editShatranjAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editShatranjAI null: " + this);
                    }
                }
                // Process
                if (shatranjAI != null)
                {
                    shatranjAI.requestChangeDuration(Server.getProfileUserId(shatranjAI), newDuration);
                }
                else
                {
                    Debug.LogError("shatranjAI null: " + this);
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
                duration
            }

            public UIData() : base()
            {
                this.editAI = new VP<EditData<ShatranjAI>>(this, (byte)Property.editAI, new EditData<ShatranjAI>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // Depth
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
                // SkillLevel
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
                // Duration
                {
                    this.duration = new VP<RequestChangeLongUI.UIData>(this, (byte)Property.duration, new RequestChangeLongUI.UIData());
                    // event
                    this.duration.v.updateData.v.request.v = makeRequestChangeDuration;
                }
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.Shatranj;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Shatranj ? 1 : 0;
        }

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Shatranj AI");

        public Text lbDepth;
        private static readonly TxtLanguage txtDepth = new TxtLanguage("Depth");

        public Text lbSkillLevel;
        private static readonly TxtLanguage txtSkillLevel = new TxtLanguage("Skill level");

        public Text lbDuration;
        private static readonly TxtLanguage txtDuration = new TxtLanguage("Duration");

        static ShatranjAIUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Cờ Ba Tư AI");
                txtDepth.add(Language.Type.vi, "Độ sâu");
                txtSkillLevel.add(Language.Type.vi, "Mức kỹ năng");
                txtDuration.add(Language.Type.vi, "Thời gian");
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
                    EditData<ShatranjAI> editShatranjAI = this.data.editAI.v;
                    if (editShatranjAI != null)
                    {
                        editShatranjAI.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editShatranjAI);
                            // get server state
                            Server.State.Type serverState = RequestChange.GetServerState(editShatranjAI);
                            // set origin
                            {
                                RequestChange.RefreshUI(this.data.depth.v, editShatranjAI, serverState, needReset, editData => editData.depth.v);
                                RequestChange.RefreshUI(this.data.skillLevel.v, editShatranjAI, serverState, needReset, editData => editData.skillLevel.v);
                                RequestChange.RefreshUI(this.data.duration.v, editShatranjAI, serverState, needReset, editData => editData.duration.v);
                            }
                            needReset = false;
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
                        UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                        // depth
                        UIUtils.SetLabelContentPosition(lbDepth, this.data.depth.v, ref deltaY);
                        // skillLevel
                        UIUtils.SetLabelContentPosition(lbSkillLevel, this.data.skillLevel.v, ref deltaY);
                        // duration
                        UIUtils.SetLabelContentPosition(lbDuration, this.data.duration.v, ref deltaY);
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
                        if (lbDepth != null)
                        {
                            lbDepth.text = txtDepth.get();
                            Setting.get().setLabelTextSize(lbDepth);
                        }
                        else
                        {
                            Debug.LogError("lbDepth null: " + this);
                        }
                        if (lbSkillLevel != null)
                        {
                            lbSkillLevel.text = txtSkillLevel.get();
                            Setting.get().setLabelTextSize(lbSkillLevel);
                        }
                        else
                        {
                            Debug.LogError("lbSkillLevel null: " + this);
                        }
                        if (lbDuration != null)
                        {
                            lbDuration.text = txtDuration.get();
                            Setting.get().setLabelTextSize(lbDuration);
                        }
                        else
                        {
                            Debug.LogError("lbDuration null: " + this);
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
        public RequestChangeLongUI requestLongPrefab;

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
                    uiData.duration.allAddCallBack(this);
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
                    if (data is EditData<ShatranjAI>)
                    {
                        EditData<ShatranjAI> editAI = data as EditData<ShatranjAI>;
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
                        if (data is ShatranjAI)
                        {
                            ShatranjAI shatranjAI = data as ShatranjAI;
                            // Parent
                            {
                                DataUtils.addParentCallBack(shatranjAI, this, ref this.server);
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
                                    {
                                        UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                    }
                                    break;
                                case UIData.Property.skillLevel:
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
                if (data is RequestChangeLongUI.UIData)
                {
                    RequestChangeLongUI.UIData requestChange = data as RequestChangeLongUI.UIData;
                    // UI
                    {
                        WrapProperty wrapProperty = requestChange.p;
                        if (wrapProperty != null)
                        {
                            switch ((UIData.Property)wrapProperty.n)
                            {
                                case UIData.Property.duration:
                                    {
                                        UIUtils.Instantiate(requestChange, requestLongPrefab, this.transform, UIConstants.RequestRect);
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
                    uiData.depth.allRemoveCallBack(this);
                    uiData.skillLevel.allRemoveCallBack(this);
                    uiData.duration.allRemoveCallBack(this);
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
                    if (data is EditData<ShatranjAI>)
                    {
                        EditData<ShatranjAI> editAI = data as EditData<ShatranjAI>;
                        // Child
                        {
                            editAI.show.allRemoveCallBack(this);
                            editAI.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is ShatranjAI)
                        {
                            ShatranjAI shatranjAI = data as ShatranjAI;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(shatranjAI, this, ref this.server);
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
                if (data is RequestChangeLongUI.UIData)
                {
                    RequestChangeLongUI.UIData requestChange = data as RequestChangeLongUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeLongUI));
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
                    case UIData.Property.duration:
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
                    if (wrapProperty.p is EditData<ShatranjAI>)
                    {
                        switch ((EditData<ShatranjAI>.Property)wrapProperty.n)
                        {
                            case EditData<ShatranjAI>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<ShatranjAI>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<ShatranjAI>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<ShatranjAI>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<ShatranjAI>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<ShatranjAI>.Property.editType:
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
                        if (wrapProperty.p is ShatranjAI)
                        {
                            switch ((ShatranjAI.Property)wrapProperty.n)
                            {
                                case ShatranjAI.Property.depth:
                                    dirty = true;
                                    break;
                                case ShatranjAI.Property.skillLevel:
                                    dirty = true;
                                    break;
                                case ShatranjAI.Property.duration:
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
                if (wrapProperty.p is RequestChangeLongUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
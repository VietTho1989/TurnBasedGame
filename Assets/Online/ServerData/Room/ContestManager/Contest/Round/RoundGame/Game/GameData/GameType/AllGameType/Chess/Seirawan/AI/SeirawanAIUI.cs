using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Seirawan
{
    public class SeirawanAIUI : UIHaveTransformDataBehavior<SeirawanAIUI.UIData>
    {

        #region UIData

        public class UIData : AIUI.UIData.Sub
        {

            public VP<EditData<SeirawanAI>> editAI;

            public VP<UIRectTransform.ShowType> showType;

            #region depth

            public VP<RequestChangeIntUI.UIData> depth;

            public void makeRequestChangeDepth(RequestChangeUpdate<int>.UpdateData update, int newDepth)
            {
                // Find
                SeirawanAI seirawanAI = null;
                {
                    EditData<SeirawanAI> editSeirawanAI = this.editAI.v;
                    if (editSeirawanAI != null)
                    {
                        seirawanAI = editSeirawanAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editSeirawanAI null: " + this);
                    }
                }
                // Process
                if (seirawanAI != null)
                {
                    seirawanAI.requestChangeDepth(Server.getProfileUserId(seirawanAI), newDepth);
                }
                else
                {
                    Debug.LogError("seirawanAI null: " + this);
                }
            }

            #endregion

            #region skillLevel

            public VP<RequestChangeIntUI.UIData> skillLevel;

            public void makeRequestChangeSkillLevel(RequestChangeUpdate<int>.UpdateData update, int newSkillLevel)
            {
                // Find
                SeirawanAI seirawanAI = null;
                {
                    EditData<SeirawanAI> editSeirawanAI = this.editAI.v;
                    if (editSeirawanAI != null)
                    {
                        seirawanAI = editSeirawanAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editSeirawanAI null: " + this);
                    }
                }
                // Process
                if (seirawanAI != null)
                {
                    seirawanAI.requestChangeSkillLevel(Server.getProfileUserId(seirawanAI), newSkillLevel);
                }
                else
                {
                    Debug.LogError("seirawanAI null: " + this);
                }
            }

            #endregion

            #region Duration

            public VP<RequestChangeLongUI.UIData> duration;

            public void makeRequestChangeDuration(RequestChangeUpdate<long>.UpdateData update, long newDuration)
            {
                // Find
                SeirawanAI seirawanAI = null;
                {
                    EditData<SeirawanAI> editSeirawanAI = this.editAI.v;
                    if (editSeirawanAI != null)
                    {
                        seirawanAI = editSeirawanAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editSeirawanAI null: " + this);
                    }
                }
                // Process
                if (seirawanAI != null)
                {
                    seirawanAI.requestChangeDuration(Server.getProfileUserId(seirawanAI), newDuration);
                }
                else
                {
                    Debug.LogError("seirawanAI null: " + this);
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
                this.editAI = new VP<EditData<SeirawanAI>>(this, (byte)Property.editAI, new EditData<SeirawanAI>());
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
                return GameType.Type.Seirawan;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Seirawan AI");

        public Text lbDepth;
        private static readonly TxtLanguage txtDepth = new TxtLanguage("Depth");

        public Text lbSkillLevel;
        private static readonly TxtLanguage txtSkillLevel = new TxtLanguage("Skill level");

        public Text lbDuration;
        private static readonly TxtLanguage txtDuration = new TxtLanguage("Duration");

        static SeirawanAIUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Cờ Seirawan AI");
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
                    EditData<SeirawanAI> editSeirawanAI = this.data.editAI.v;
                    if (editSeirawanAI != null)
                    {
                        editSeirawanAI.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editSeirawanAI);
                            // get server state
                            Server.State.Type serverState = RequestChange.GetServerState(editSeirawanAI);
                            // set origin
                            {
                                RequestChange.RefreshUI(this.data.depth.v, editSeirawanAI, serverState, needReset, editData => editData.depth.v);
                                RequestChange.RefreshUI(this.data.skillLevel.v, editSeirawanAI, serverState, needReset, editData => editData.skillLevel.v);
                                RequestChange.RefreshUI(this.data.duration.v, editSeirawanAI, serverState, needReset, editData => editData.duration.v);
                            }
                            needReset = false;
                        }
                    }
                    else
                    {
                        Debug.LogError("editSeirawanAI null: " + this);
                    }
                    // UI
                    {
                        float deltaY = 0;
                        // header
                        UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
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
                        // Set
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
                    if (data is EditData<SeirawanAI>)
                    {
                        EditData<SeirawanAI> editAI = data as EditData<SeirawanAI>;
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
                        if (data is SeirawanAI)
                        {
                            SeirawanAI seirawanAI = data as SeirawanAI;
                            // Parent
                            {
                                DataUtils.addParentCallBack(seirawanAI, this, ref this.server);
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
                    if (data is EditData<SeirawanAI>)
                    {
                        EditData<SeirawanAI> editAI = data as EditData<SeirawanAI>;
                        // Child
                        {
                            editAI.show.allRemoveCallBack(this);
                            editAI.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is SeirawanAI)
                        {
                            SeirawanAI seirawanAI = data as SeirawanAI;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(seirawanAI, this, ref this.server);
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
                    if (wrapProperty.p is EditData<SeirawanAI>)
                    {
                        switch ((EditData<SeirawanAI>.Property)wrapProperty.n)
                        {
                            case EditData<SeirawanAI>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<SeirawanAI>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<SeirawanAI>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<SeirawanAI>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<SeirawanAI>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<SeirawanAI>.Property.editType:
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
                        if (wrapProperty.p is SeirawanAI)
                        {
                            switch ((SeirawanAI.Property)wrapProperty.n)
                            {
                                case SeirawanAI.Property.depth:
                                    dirty = true;
                                    break;
                                case SeirawanAI.Property.skillLevel:
                                    dirty = true;
                                    break;
                                case SeirawanAI.Property.duration:
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
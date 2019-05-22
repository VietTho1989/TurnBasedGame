﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AnimationSettingUI : UIHaveTransformDataBehavior<AnimationSettingUI.UIData>
{

    #region UIData

    public class UIData : Data, EditDataUI.UIData<AnimationSetting>
    {

        public VP<EditData<AnimationSetting>> editAnimationSetting;

        #region scale

        public VP<RequestChangeFloatUI.UIData> scale;

        public void makeRequestChangeScale(RequestChangeUpdate<float>.UpdateData update, float newScale)
        {
            // Find
            AnimationSetting animationSetting = null;
            {
                EditData<AnimationSetting> editAnimationSetting = this.editAnimationSetting.v;
                if (editAnimationSetting != null)
                {
                    animationSetting = editAnimationSetting.show.v.data;
                }
                else
                {
                    Debug.LogError("editAnimationSetting null: " + this);
                }
            }
            // Process
            if (animationSetting != null)
            {
                animationSetting.scale.v = newScale;
            }
            else
            {
                Debug.LogError("animationSetting null: " + this);
            }
        }

        #endregion

        #region fastForward

        public VP<RequestChangeBoolUI.UIData> fastForward;

        public void makeRequestChangeFastForward(RequestChangeUpdate<bool>.UpdateData update, bool newFastForward)
        {
            // Find
            AnimationSetting animationSetting = null;
            {
                EditData<AnimationSetting> editAnimationSetting = this.editAnimationSetting.v;
                if (editAnimationSetting != null)
                {
                    animationSetting = editAnimationSetting.show.v.data;
                }
                else
                {
                    Debug.LogError("editAnimationSetting null: " + this);
                }
            }
            // Process
            if (animationSetting != null)
            {
                animationSetting.fastForward.v = newFastForward;
            }
            else
            {
                Debug.LogError("animationSetting null: " + this);
            }
        }

        #endregion

        #region maxWaitAnimationCount

        public VP<RequestChangeIntUI.UIData> maxWaitAnimationCount;

        public void makeRequestChangeMaxWaitAnimationCount(RequestChangeUpdate<int>.UpdateData update, int newMaxWaitAnimationCount)
        {
            // Find
            AnimationSetting animationSetting = null;
            {
                EditData<AnimationSetting> editAnimationSetting = this.editAnimationSetting.v;
                if (editAnimationSetting != null)
                {
                    animationSetting = editAnimationSetting.show.v.data;
                }
                else
                {
                    Debug.LogError("editAnimationSetting null: " + this);
                }
            }
            // Process
            if (animationSetting != null)
            {
                animationSetting.maxWaitAnimationCount.v = newMaxWaitAnimationCount;
            }
            else
            {
                Debug.LogError("animationSetting null: " + this);
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            editAnimationSetting,
            scale,
            fastForward,
            maxWaitAnimationCount
        }

        public UIData() : base()
        {
            {
                this.editAnimationSetting = new VP<EditData<AnimationSetting>>(this, (byte)Property.editAnimationSetting, new EditData<AnimationSetting>());
                this.editAnimationSetting.v.canEdit.v = true;
            }
            // scale
            {
                this.scale = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.scale, new RequestChangeFloatUI.UIData());
                // have limit
                {
                    FloatLimit.Have have = new FloatLimit.Have();
                    {
                        have.uid = this.scale.v.limit.makeId();
                        have.min.v = 0;
                        have.max.v = 10;
                    }
                    this.scale.v.limit.v = have;
                }
                // event
                this.scale.v.updateData.v.request.v = makeRequestChangeScale;
            }
            // fastForward
            {
                this.fastForward = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.fastForward, new RequestChangeBoolUI.UIData());
                this.fastForward.v.updateData.v.request.v = makeRequestChangeFastForward;
            }
            // maxWaitAnimationCount
            {
                this.maxWaitAnimationCount = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.maxWaitAnimationCount, new RequestChangeIntUI.UIData());
                // have limit
                {
                    IntLimit.Have have = new IntLimit.Have();
                    {
                        have.uid = this.maxWaitAnimationCount.v.limit.makeId();
                        have.min.v = 0;
                        have.max.v = 100;
                    }
                    this.maxWaitAnimationCount.v.limit.v = have;
                }
                // event
                this.maxWaitAnimationCount.v.updateData.v.request.v = makeRequestChangeMaxWaitAnimationCount;
            }
        }

        #endregion

        #region implement base

        public EditData<AnimationSetting> getEditData()
        {
            return this.editAnimationSetting.v;
        }

        #endregion

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Animation Setting");

    public Text lbScale;
    private static readonly TxtLanguage txtScale = new TxtLanguage("Scale");

    public Text lbFastForward;
    private static readonly TxtLanguage txtFastForward = new TxtLanguage("Fast forward");

    public Text lbMaxWaitAnimationCount;
    private static readonly TxtLanguage txtMaxWaitAnimationCount = new TxtLanguage("Max wait animation count");

    static AnimationSettingUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Thiết Lập Animation");
            txtScale.add(Language.Type.vi, "Tỷ lệ");
            txtFastForward.add(Language.Type.vi, "Tua nhanh");
            txtMaxWaitAnimationCount.add(Language.Type.vi, "Số animation chờ tối đa");
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
                EditData<AnimationSetting> editAnimationSetting = this.data.editAnimationSetting.v;
                if (editAnimationSetting != null)
                {
                    editAnimationSetting.update();
                    // UI
                    {
                        // different
                        RequestChange.ShowDifferentTitle(lbTitle, editAnimationSetting);
                        // request
                        {
                            // get server state
                            Server.State.Type serverState = Server.State.Type.Connect;
                            // set origin
                            {
                                RequestChange.RefreshUI(this.data.scale.v, editAnimationSetting, serverState, needReset, editData => editData.scale.v);
                                RequestChange.RefreshUI(this.data.fastForward.v, editAnimationSetting, serverState, needReset, editData => editData.fastForward.v);
                                RequestChange.RefreshUI(this.data.maxWaitAnimationCount.v, editAnimationSetting, serverState, needReset, editData => editData.maxWaitAnimationCount.v);
                            }
                        }
                        needReset = false;
                    }
                }
                else
                {
                    Debug.LogError("editAnimationSetting null: " + this);
                }
                // UI
                {
                    float deltaY = 0;
                    // header
                    UIUtils.SetHeaderPosition(lbTitle, UIRectTransform.ShowType.Normal, ref deltaY);
                    // scale
                    UIUtils.SetLabelContentPosition(lbScale, this.data.scale.v, ref deltaY);
                    // fastForward
                    UIUtils.SetLabelContentPosition(lbFastForward, this.data.fastForward.v, ref deltaY);
                    // maxWaitAnimationCount
                    UIUtils.SetLabelContentPosition(lbMaxWaitAnimationCount, this.data.maxWaitAnimationCount.v, ref deltaY);
                    // set height
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
                    if (lbScale != null)
                    {
                        lbScale.text = txtScale.get();
                        Setting.get().setLabelTextSize(lbScale);
                    }
                    else
                    {
                        Debug.LogError("tvScale null: " + this);
                    }
                    if (lbFastForward != null)
                    {
                        lbFastForward.text = txtFastForward.get();
                        Setting.get().setLabelTextSize(lbFastForward);
                    }
                    else
                    {
                        Debug.LogError("tvFastForward null: " + this);
                    }
                    if (lbMaxWaitAnimationCount != null)
                    {
                        lbMaxWaitAnimationCount.text = txtMaxWaitAnimationCount.get();
                        Setting.get().setLabelTextSize(lbMaxWaitAnimationCount);
                    }
                    else
                    {
                        Debug.LogError("tvMaxWaitAnimationCount null: " + this);
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

    // private Server server = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.editAnimationSetting.allAddCallBack(this);
                uiData.scale.allAddCallBack(this);
                uiData.fastForward.allAddCallBack(this);
                uiData.maxWaitAnimationCount.allAddCallBack(this);
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
            // editAnimationSetting
            {
                if (data is EditData<AnimationSetting>)
                {
                    EditData<AnimationSetting> editAnimationSetting = data as EditData<AnimationSetting>;
                    // Child
                    {
                        editAnimationSetting.show.allAddCallBack(this);
                        editAnimationSetting.compare.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is AnimationSetting)
                    {
                        /*AnimationSetting animationSetting = data as AnimationSetting;
						// Parent
						{
							DataUtils.addParentCallBack (animationSetting, this, ref this.server);
						}*/
                        needReset = true;
                        dirty = true;
                        return;
                    }
                    // Parent
                    /*if (data is Server) {
                            dirty = true;
                            return;
                        }*/
                }
            }
            // scale
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
                            case UIData.Property.scale:
                                UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestFloat, this.transform, UIConstants.RequestRect);
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
            // fastForward
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
                            case UIData.Property.fastForward:
                                UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestBool, this.transform, UIConstants.RequestBoolRect);
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
            // maxWaitAnimationCount
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
                            case UIData.Property.maxWaitAnimationCount:
                                UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestInt, this.transform, UIConstants.RequestRect);
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
                uiData.editAnimationSetting.allRemoveCallBack(this);
                uiData.scale.allRemoveCallBack(this);
                uiData.fastForward.allRemoveCallBack(this);
                uiData.maxWaitAnimationCount.allRemoveCallBack(this);
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
            // editAnimationSetting
            {
                if (data is EditData<AnimationSetting>)
                {
                    EditData<AnimationSetting> editAnimationSetting = data as EditData<AnimationSetting>;
                    // Child
                    {
                        editAnimationSetting.show.allRemoveCallBack(this);
                        editAnimationSetting.compare.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is AnimationSetting)
                    {
                        /*AnimationSetting animationSetting = data as AnimationSetting;
						// Parent
						{
							DataUtils.removeParentCallBack (animationSetting, this, ref this.server);
						}*/
                        return;
                    }
                    // Parent
                    /*if (data is Server) {
                            return;
                        }*/
                }
            }
            // scale
            if (data is RequestChangeFloatUI.UIData)
            {
                RequestChangeFloatUI.UIData requestChange = data as RequestChangeFloatUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeFloatUI));
                }
                return;
            }
            // fastForward
            if (data is RequestChangeBoolUI.UIData)
            {
                RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeBoolUI));
                }
                return;
            }
            // maxWaitAnimationCount
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
                case UIData.Property.editAnimationSetting:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.scale:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.fastForward:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.maxWaitAnimationCount:
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
            // editAnimationSetting
            {
                if (wrapProperty.p is EditData<AnimationSetting>)
                {
                    switch ((EditData<AnimationSetting>.Property)wrapProperty.n)
                    {
                        case EditData<AnimationSetting>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<AnimationSetting>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<AnimationSetting>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<AnimationSetting>.Property.compareOtherType:
                            dirty = true;
                            break;
                        case EditData<AnimationSetting>.Property.canEdit:
                            dirty = true;
                            break;
                        case EditData<AnimationSetting>.Property.editType:
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
                    if (wrapProperty.p is AnimationSetting)
                    {
                        switch ((AnimationSetting.Property)wrapProperty.n)
                        {
                            case AnimationSetting.Property.scale:
                                dirty = true;
                                break;
                            case AnimationSetting.Property.fastForward:
                                dirty = true;
                                break;
                            case AnimationSetting.Property.maxWaitAnimationCount:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Parent
                    /*if (wrapProperty.p is Server) {
                            Server.State.OnUpdateSyncStateChange (wrapProperty, this);
                            return;
                        }*/
                }
            }
            // scale
            if (wrapProperty.p is RequestChangeFloatUI.UIData)
            {
                return;
            }
            // fastForward
            if (wrapProperty.p is RequestChangeBoolUI.UIData)
            {
                return;
            }
            // maxWaitAnimationCount
            if (wrapProperty.p is RequestChangeIntUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}
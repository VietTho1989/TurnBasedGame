using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DefaultChatRoomStyleAlwaysUI : UIHaveTransformDataBehavior<DefaultChatRoomStyleAlwaysUI.UIData>
{

    #region UIData

    public class UIData : DefaultChatRoomStyle.UIData
    {

        public VP<EditData<DefaultChatRoomStyleAlways>> editDefaultChatRoomStyleAlways;

        public VP<UIRectTransform.ShowType> showType;

        #region visibility

        public VP<RequestChangeEnumUI.UIData> visibility;

        public void makeRequestChangeVisibility(RequestChangeUpdate<int>.UpdateData update, int newVisibility)
        {
            // Find
            DefaultChatRoomStyleAlways defaultChatRoomStyleAlways = null;
            {
                EditData<DefaultChatRoomStyleAlways> editDefaultChatRoomStyleAlways = this.editDefaultChatRoomStyleAlways.v;
                if (editDefaultChatRoomStyleAlways != null)
                {
                    defaultChatRoomStyleAlways = editDefaultChatRoomStyleAlways.show.v.data;
                }
                else
                {
                    Debug.LogError("editDefaultChatRoomStyleAlways null: " + this);
                }
            }
            // Process
            if (defaultChatRoomStyleAlways != null)
            {
                defaultChatRoomStyleAlways.visibility.v = (ContestManagerBtnChatUI.UIData.Visibility)newVisibility;
            }
            else
            {
                Debug.LogError("defaultChatRoomStyleAlways null: " + this);
            }
        }

        #endregion

        #region style

        public VP<RequestChangeEnumUI.UIData> style;

        public void makeRequestChangeStyle(RequestChangeUpdate<int>.UpdateData update, int newStyle)
        {
            // Find
            DefaultChatRoomStyleAlways defaultChatRoomStyleAlways = null;
            {
                EditData<DefaultChatRoomStyleAlways> editDefaultChatRoomStyleAlways = this.editDefaultChatRoomStyleAlways.v;
                if (editDefaultChatRoomStyleAlways != null)
                {
                    defaultChatRoomStyleAlways = editDefaultChatRoomStyleAlways.show.v.data;
                }
                else
                {
                    Debug.LogError("editDefaultChatRoomStyleAlways null: " + this);
                }
            }
            // Process
            if (defaultChatRoomStyleAlways != null)
            {
                defaultChatRoomStyleAlways.style.v = (ContestManagerBtnChatUI.UIData.Style)newStyle;
            }
            else
            {
                Debug.LogError("defaultChatRoomStyleAlways null: " + this);
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            editDefaultChatRoomStyleAlways,
            showType,
            visibility,
            style
        }

        public UIData() : base()
        {
            this.editDefaultChatRoomStyleAlways = new VP<EditData<DefaultChatRoomStyleAlways>>(this, (byte)Property.editDefaultChatRoomStyleAlways, new EditData<DefaultChatRoomStyleAlways>());
            this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
            // visibility
            {
                this.visibility = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.visibility, new RequestChangeEnumUI.UIData());
                this.visibility.v.updateData.v.request.v = makeRequestChangeVisibility;
                this.visibility.v.options.copyList(ContestManagerBtnChatUI.UIData.GetStrVisibility());
            }
            // style
            {
                this.style = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.style, new RequestChangeEnumUI.UIData());
                this.style.v.updateData.v.request.v = makeRequestChangeStyle;
                this.style.v.options.copyList(ContestManagerBtnChatUI.UIData.GetStrStyles());
            }
        }

        #endregion

        public override DefaultChatRoomStyle.Type getType()
        {
            return DefaultChatRoomStyle.Type.Always;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Chat Room Always");

    public Text lbVisibility;
    private static readonly TxtLanguage txtVisibility = new TxtLanguage("Visibility");

    public Text lbStyle;
    private static readonly TxtLanguage txtStyle = new TxtLanguage("Style");

    static DefaultChatRoomStyleAlwaysUI()
    {
        txtTitle.add(Language.Type.vi, "Phòng Chat Luôn Chọn");
        txtVisibility.add(Language.Type.vi, "Ẩn/Hiện");
        txtStyle.add(Language.Type.vi, "Kiểu");
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
                EditData<DefaultChatRoomStyleAlways> editDefaultChatRoomStyleAlways = this.data.editDefaultChatRoomStyleAlways.v;
                if (editDefaultChatRoomStyleAlways != null)
                {
                    editDefaultChatRoomStyleAlways.update();
                    // UI
                    {
                        // different
                        RequestChange.ShowDifferentTitle(lbTitle, editDefaultChatRoomStyleAlways);
                        // request
                        {
                            // get server state
                            Server.State.Type serverState = Server.State.Type.Connect;
                            // set origin
                            {
                                // visibility
                                {
                                    RequestChangeEnumUI.RefreshOptions(this.data.visibility.v, ContestManagerBtnChatUI.UIData.GetStrVisibility());
                                    RequestChange.RefreshUI(this.data.visibility.v, editDefaultChatRoomStyleAlways, serverState, needReset, editData => (int)editData.visibility.v);
                                }
                                // style
                                {
                                    RequestChangeEnumUI.RefreshOptions(this.data.style.v, ContestManagerBtnChatUI.UIData.GetStrStyles());
                                    RequestChange.RefreshUI(this.data.style.v, editDefaultChatRoomStyleAlways, serverState, needReset, editData => (int)editData.style.v);
                                }
                            }
                            needReset = false;
                        }
                    }
                    // UI
                    {
                        float deltaY = 0;
                        // header
                        UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                        // visibility
                        UIUtils.SetLabelContentPosition(lbVisibility, this.data.visibility.v, ref deltaY);
                        // style
                        UIUtils.SetLabelContentPosition(lbStyle, this.data.style.v, ref deltaY);
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
                        if (lbVisibility != null)
                        {
                            lbVisibility.text = txtVisibility.get();
                            Setting.get().setLabelTextSize(lbVisibility);
                        }
                        else
                        {
                            Debug.LogError("lbVisibility null: " + this);
                        }
                        if (lbStyle != null)
                        {
                            lbStyle.text = txtStyle.get();
                            Setting.get().setLabelTextSize(lbStyle);
                        }
                        else
                        {
                            Debug.LogError("lbStyle null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("editDefaultChatRoomStyleAlways null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.editDefaultChatRoomStyleAlways.allAddCallBack(this);
                uiData.visibility.allAddCallBack(this);
                uiData.style.allAddCallBack(this);
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
            // editDefaultChatRoomStyleAlways
            {
                if (data is EditData<DefaultChatRoomStyleAlways>)
                {
                    EditData<DefaultChatRoomStyleAlways> editDefaultChatRoomStyleAlways = data as EditData<DefaultChatRoomStyleAlways>;
                    // Child
                    {
                        editDefaultChatRoomStyleAlways.show.allAddCallBack(this);
                        editDefaultChatRoomStyleAlways.compare.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is DefaultChatRoomStyleAlways)
                {
                    needReset = true;
                    dirty = true;
                    return;
                }
            }
            if (data is RequestChangeEnumUI.UIData)
            {
                RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                // UI
                {
                    WrapProperty wrapProperty = requestChange.p;
                    if (wrapProperty != null)
                    {
                        switch ((UIData.Property)wrapProperty.n)
                        {
                            case UIData.Property.visibility:
                                UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestEnum, this.transform, UIConstants.RequestEnumRect);
                                break;
                            case UIData.Property.style:
                                UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestEnum, this.transform, UIConstants.RequestEnumRect);
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
                uiData.editDefaultChatRoomStyleAlways.allRemoveCallBack(this);
                uiData.visibility.allRemoveCallBack(this);
                uiData.style.allRemoveCallBack(this);
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
            // editDefaultChatRoomStyleAlways
            {
                if (data is EditData<DefaultChatRoomStyleAlways>)
                {
                    EditData<DefaultChatRoomStyleAlways> editDefaultChatRoomStyleAlways = data as EditData<DefaultChatRoomStyleAlways>;
                    // Child
                    {
                        editDefaultChatRoomStyleAlways.show.allRemoveCallBack(this);
                        editDefaultChatRoomStyleAlways.compare.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is DefaultChatRoomStyleAlways)
                {
                    return;
                }
            }
            if (data is RequestChangeEnumUI.UIData)
            {
                RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeEnumUI));
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
                case UIData.Property.editDefaultChatRoomStyleAlways:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.showType:
                    dirty = true;
                    break;
                case UIData.Property.visibility:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.style:
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
                case Setting.Property.showLastMove:
                    break;
                case Setting.Property.viewUrlImage:
                    break;
                case Setting.Property.animationSetting:
                    break;
                case Setting.Property.maxThinkCount:
                    break;
                case Setting.Property.defaultChosenGame:
                    break;
                case Setting.Property.defaultChatRoomStyle:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            // editDefaultChatRoomStyleAlways
            {
                if (wrapProperty.p is EditData<DefaultChatRoomStyleAlways>)
                {
                    switch ((EditData<DefaultChatRoomStyleAlways>.Property)wrapProperty.n)
                    {
                        case EditData<DefaultChatRoomStyleAlways>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<DefaultChatRoomStyleAlways>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<DefaultChatRoomStyleAlways>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<DefaultChatRoomStyleAlways>.Property.compareOtherType:
                            dirty = true;
                            break;
                        case EditData<DefaultChatRoomStyleAlways>.Property.canEdit:
                            dirty = true;
                            break;
                        case EditData<DefaultChatRoomStyleAlways>.Property.editType:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is DefaultChatRoomStyleAlways)
                {
                    switch ((DefaultChatRoomStyleAlways.Property)wrapProperty.n)
                    {
                        case DefaultChatRoomStyleAlways.Property.visibility:
                            dirty = true;
                            break;
                        case DefaultChatRoomStyleAlways.Property.style:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            if (wrapProperty.p is RequestChangeEnumUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}
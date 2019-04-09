using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DefaultChatRoomStyleLastUI : UIHaveTransformDataBehavior<DefaultChatRoomStyleLastUI.UIData>
{

    #region UIData

    public class UIData : DefaultChatRoomStyle.UIData
    {

        public VP<EditData<DefaultChatRoomStyleLast>> editDefaultChatRoomStyleLast;

        public VP<UIRectTransform.ShowType> showType;

        #region visibility

        public VP<RequestChangeEnumUI.UIData> visibility;

        public void makeRequestChangeVisibility(RequestChangeUpdate<int>.UpdateData update, int newVisibility)
        {
            // Find
            DefaultChatRoomStyleLast defaultChatRoomStyleLast = null;
            {
                EditData<DefaultChatRoomStyleLast> editDefaultChatRoomStyleLast = this.editDefaultChatRoomStyleLast.v;
                if (editDefaultChatRoomStyleLast != null)
                {
                    defaultChatRoomStyleLast = editDefaultChatRoomStyleLast.show.v.data;
                }
                else
                {
                    Debug.LogError("editDefaultChatRoomStyleLast null: " + this);
                }
            }
            // Process
            if (defaultChatRoomStyleLast != null)
            {
                defaultChatRoomStyleLast.visibility.v = (ContestManagerBtnChatUI.UIData.Visibility)newVisibility;
            }
            else
            {
                Debug.LogError("defaultChatRoomStyleLast null: " + this);
            }
        }

        #endregion

        #region style

        public VP<RequestChangeEnumUI.UIData> style;

        public void makeRequestChangeStyle(RequestChangeUpdate<int>.UpdateData update, int newStyle)
        {
            // Find
            DefaultChatRoomStyleLast defaultChatRoomStyleLast = null;
            {
                EditData<DefaultChatRoomStyleLast> editDefaultChatRoomStyleLast = this.editDefaultChatRoomStyleLast.v;
                if (editDefaultChatRoomStyleLast != null)
                {
                    defaultChatRoomStyleLast = editDefaultChatRoomStyleLast.show.v.data;
                }
                else
                {
                    Debug.LogError("editDefaultChatRoomStyleLast null: " + this);
                }
            }
            // Process
            if (defaultChatRoomStyleLast != null)
            {
                defaultChatRoomStyleLast.style.v = (ContestManagerBtnChatUI.UIData.Style)newStyle;
            }
            else
            {
                Debug.LogError("defaultChatRoomStyleLast null: " + this);
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            editDefaultChatRoomStyleLast,
            showType,
            visibility,
            style
        }

        public UIData() : base()
        {
            this.editDefaultChatRoomStyleLast = new VP<EditData<DefaultChatRoomStyleLast>>(this, (byte)Property.editDefaultChatRoomStyleLast, new EditData<DefaultChatRoomStyleLast>());
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
            return DefaultChatRoomStyle.Type.Last;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Chat Room Last");

    public Text lbVisibility;
    private static readonly TxtLanguage txtVisibility = new TxtLanguage("Visibility");

    public Text lbStyle;
    private static readonly TxtLanguage txtStyle = new TxtLanguage("Style");

    static DefaultChatRoomStyleLastUI()
    {
        txtTitle.add(Language.Type.vi, "Phòng Chat Chọn Trước");
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
                EditData<DefaultChatRoomStyleLast> editDefaultChatRoomStyleLast = this.data.editDefaultChatRoomStyleLast.v;
                if (editDefaultChatRoomStyleLast != null)
                {
                    editDefaultChatRoomStyleLast.update();
                    // UI
                    {
                        // different
                        RequestChange.ShowDifferentTitle(lbTitle, editDefaultChatRoomStyleLast);
                        // request
                        {
                            // get server state
                            Server.State.Type serverState = Server.State.Type.Connect;
                            // set origin
                            {
                                // visibility
                                {
                                    RequestChangeEnumUI.RefreshOptions(this.data.visibility.v, ContestManagerBtnChatUI.UIData.GetStrVisibility());
                                    RequestChange.RefreshUI(this.data.visibility.v, editDefaultChatRoomStyleLast, serverState, needReset, editData => (int)editData.visibility.v);
                                }
                                // style
                                {
                                    RequestChangeEnumUI.RefreshOptions(this.data.style.v, ContestManagerBtnChatUI.UIData.GetStrStyles());
                                    RequestChange.RefreshUI(this.data.style.v, editDefaultChatRoomStyleLast, serverState, needReset, editData => (int)editData.style.v);
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
                        {
                            if (this.data.visibility.v != null)
                            {
                                if (lbVisibility != null)
                                {
                                    lbVisibility.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbVisibility.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbVisibility null");
                                }
                                UIRectTransform.SetPosY(this.data.visibility.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbVisibility != null)
                                {
                                    lbVisibility.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbVisibility null");
                                }
                            }
                        }
                        // style
                        {
                            if (this.data.style.v != null)
                            {
                                if (lbStyle != null)
                                {
                                    lbStyle.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbStyle.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbStyle null");
                                }
                                UIRectTransform.SetPosY(this.data.style.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbStyle != null)
                                {
                                    lbStyle.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbStyle null");
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
                    Debug.LogError("editDefaultChatRoomStyleLast null: " + this);
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

    public RequestChangeEnumUI requestEnumPrefab;
    public static readonly UIRectTransform visibilityRect = new UIRectTransform(UIConstants.RequestEnumRect);
    public static readonly UIRectTransform styleRect = new UIRectTransform(UIConstants.RequestEnumRect);

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.editDefaultChatRoomStyleLast.allAddCallBack(this);
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
            // editDefaultChatRoomStyleLast
            {
                if (data is EditData<DefaultChatRoomStyleLast>)
                {
                    EditData<DefaultChatRoomStyleLast> editDefaultChatRoomStyleLast = data as EditData<DefaultChatRoomStyleLast>;
                    // Child
                    {
                        editDefaultChatRoomStyleLast.show.allAddCallBack(this);
                        editDefaultChatRoomStyleLast.compare.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is DefaultChatRoomStyleLast)
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
                                UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, visibilityRect);
                                break;
                            case UIData.Property.style:
                                UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, styleRect);
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
                uiData.editDefaultChatRoomStyleLast.allRemoveCallBack(this);
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
            // editDefaultChatRoomStyleLast
            {
                if (data is EditData<DefaultChatRoomStyleLast>)
                {
                    EditData<DefaultChatRoomStyleLast> editDefaultChatRoomStyleLast = data as EditData<DefaultChatRoomStyleLast>;
                    // Child
                    {
                        editDefaultChatRoomStyleLast.show.allRemoveCallBack(this);
                        editDefaultChatRoomStyleLast.compare.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is DefaultChatRoomStyleLast)
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
                case UIData.Property.editDefaultChatRoomStyleLast:
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
                case Setting.Property.contentTextSize:
                    dirty = true;
                    break;
                case Setting.Property.titleTextSize:
                    dirty = true;
                    break;
                case Setting.Property.labelTextSize:
                    dirty = true;
                    break;
                case Setting.Property.style:
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
            // editDefaultChatRoomStyleLast
            {
                if (wrapProperty.p is EditData<DefaultChatRoomStyleLast>)
                {
                    switch ((EditData<DefaultChatRoomStyleLast>.Property)wrapProperty.n)
                    {
                        case EditData<DefaultChatRoomStyleLast>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<DefaultChatRoomStyleLast>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<DefaultChatRoomStyleLast>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<DefaultChatRoomStyleLast>.Property.compareOtherType:
                            dirty = true;
                            break;
                        case EditData<DefaultChatRoomStyleLast>.Property.canEdit:
                            dirty = true;
                            break;
                        case EditData<DefaultChatRoomStyleLast>.Property.editType:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is DefaultChatRoomStyleLast)
                {
                    switch ((DefaultChatRoomStyleLast.Property)wrapProperty.n)
                    {
                        case DefaultChatRoomStyleLast.Property.visibility:
                            dirty = true;
                            break;
                        case DefaultChatRoomStyleLast.Property.style:
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
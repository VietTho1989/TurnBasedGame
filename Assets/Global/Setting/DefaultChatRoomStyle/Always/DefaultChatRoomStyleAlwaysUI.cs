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
    private static readonly TxtLanguage txtTitle = new TxtLanguage();

    public Text lbVisibility;
    private static readonly TxtLanguage txtVisibility = new TxtLanguage();

    public Text lbStyle;
    private static readonly TxtLanguage txttStyle = new TxtLanguage();

    static DefaultChatRoomStyleAlwaysUI()
    {
        txtTitle.add(Language.Type.vi, "Phòng Chat Luôn Chọn");
        txtVisibility.add(Language.Type.vi, "Ẩn/Hiện");
        txttStyle.add(Language.Type.vi, "Kiểu");
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
                    // get show
                    DefaultChatRoomStyleAlways show = editDefaultChatRoomStyleAlways.show.v.data;
                    DefaultChatRoomStyleAlways compare = editDefaultChatRoomStyleAlways.compare.v.data;
                    if (show != null)
                    {
                        // different
                        if (lbTitle != null)
                        {
                            bool isDifferent = false;
                            {
                                if (editDefaultChatRoomStyleAlways.compareOtherType.v.data != null)
                                {
                                    if (editDefaultChatRoomStyleAlways.compareOtherType.v.data.GetType() != show.GetType())
                                    {
                                        isDifferent = true;
                                    }
                                }
                            }
                            lbTitle.color = isDifferent ? UIConstants.DifferentIndicatorColor : UIConstants.NormalTitleColor;
                        }
                        else
                        {
                            Debug.LogError("different null: " + this);
                        }
                        // request
                        {
                            // get server state
                            Server.State.Type serverState = Server.State.Type.Connect;
                            {
                                /*Server server = show.findDataInParent<Server>();
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
                                }*/
                            }
                            // set origin
                            {
                                // visibility
                                {
                                    RequestChangeEnumUI.UIData visibility = this.data.visibility.v;
                                    if (visibility != null)
                                    {
                                        // options
                                        {
                                            visibility.options.copyList(ContestManagerBtnChatUI.UIData.GetStrVisibility());
                                        }
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = visibility.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = (int)show.visibility.v;
                                            updateData.canRequestChange.v = editDefaultChatRoomStyleAlways.canEdit.v;
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
                                                visibility.showDifferent.v = true;
                                                visibility.compare.v = (int)compare.visibility.v;
                                            }
                                            else
                                            {
                                                visibility.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("visibility null: " + this);
                                    }
                                }
                                // style
                                {
                                    RequestChangeEnumUI.UIData style = this.data.style.v;
                                    if (style != null)
                                    {
                                        // options
                                        {
                                            style.options.copyList(ContestManagerBtnChatUI.UIData.GetStrStyles());
                                        }
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = style.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = (int)show.style.v;
                                            updateData.canRequestChange.v = editDefaultChatRoomStyleAlways.canEdit.v;
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
                                                style.showDifferent.v = true;
                                                style.compare.v = (int)compare.style.v;
                                            }
                                            else
                                            {
                                                style.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("style null: " + this);
                                    }
                                }
                            }
                            // reset?
                            if (needReset)
                            {
                                needReset = false;
                                // visibility
                                {
                                    RequestChangeEnumUI.UIData visibility = this.data.visibility.v;
                                    if (visibility != null)
                                    {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = visibility.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = (int)show.visibility.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("visibility null: " + this);
                                    }
                                }
                                // style
                                {
                                    RequestChangeEnumUI.UIData style = this.data.style.v;
                                    if (style != null)
                                    {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = style.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = (int)show.style.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("style null: " + this);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("show null: " + this);
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
                                default:
                                    Debug.LogError("unknown showType: " + this.data.showType.v);
                                    break;
                            }
                        }
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
                            lbTitle.text = txtTitle.get("Chat Room Always");
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                        if (lbVisibility != null)
                        {
                            lbVisibility.text = txtVisibility.get("Visibility");
                        }
                        else
                        {
                            Debug.LogError("lbVisibility null: " + this);
                        }
                        if (lbStyle != null)
                        {
                            lbStyle.text = txttStyle.get("Style");
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
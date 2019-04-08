using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DefaultRoomNameAlwaysUI : UIHaveTransformDataBehavior<DefaultRoomNameAlwaysUI.UIData>
{

    #region UIData

    public class UIData : DefaultRoomName.UIData
    {

        public VP<EditData<DefaultRoomNameAlways>> editDefaultRoomNameAlways;

        public VP<UIRectTransform.ShowType> showType;

        #region gameType

        public VP<RequestChangeStringUI.UIData> roomName;

        public void makeRequestChangeRoomName(RequestChangeUpdate<string>.UpdateData update, string newRoomName)
        {
            // Find
            DefaultRoomNameAlways defaultRoomNameAlways = null;
            {
                EditData<DefaultRoomNameAlways> editDefaultRoomNameAlways = this.editDefaultRoomNameAlways.v;
                if (editDefaultRoomNameAlways != null)
                {
                    defaultRoomNameAlways = editDefaultRoomNameAlways.show.v.data;
                }
                else
                {
                    Debug.LogError("editDefaultRoomNameAlways null: " + this);
                }
            }
            // Process
            if (defaultRoomNameAlways != null)
            {
                defaultRoomNameAlways.roomName.v = newRoomName;
            }
            else
            {
                Debug.LogError("defaultRoomNameAlways null: " + this);
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            editDefaultRoomNameAlways,
            showType,
            roomName
        }

        public UIData() : base()
        {
            this.editDefaultRoomNameAlways = new VP<EditData<DefaultRoomNameAlways>>(this, (byte)Property.editDefaultRoomNameAlways, new EditData<DefaultRoomNameAlways>());
            this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
            // roomName
            {
                this.roomName = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.roomName, new RequestChangeStringUI.UIData());
                // event
                this.roomName.v.updateData.v.request.v = makeRequestChangeRoomName;
            }
        }

        #endregion

        public override DefaultRoomName.Type getType()
        {
            return DefaultRoomName.Type.Always;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Room Name Always");

    public Text lbRoomName;
    private static readonly TxtLanguage txtRoomName = new TxtLanguage("Room name");

    static DefaultRoomNameAlwaysUI()
    {
        txtTitle.add(Language.Type.vi, "Tên Phòng Luôn Chọn");
        txtRoomName.add(Language.Type.vi, "Tên phòng");
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
                EditData<DefaultRoomNameAlways> editDefaultRoomNameAlways = this.data.editDefaultRoomNameAlways.v;
                if (editDefaultRoomNameAlways != null)
                {
                    editDefaultRoomNameAlways.update();
                    // get show
                    DefaultRoomNameAlways show = editDefaultRoomNameAlways.show.v.data;
                    DefaultRoomNameAlways compare = editDefaultRoomNameAlways.compare.v.data;
                    if (show != null)
                    {
                        // different
                        if (lbTitle != null)
                        {
                            bool isDifferent = false;
                            {
                                if (editDefaultRoomNameAlways.compareOtherType.v.data != null)
                                {
                                    if (editDefaultRoomNameAlways.compareOtherType.v.data.GetType() != show.GetType())
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
                                // roomName
                                {
                                    RequestChangeStringUI.UIData roomName = this.data.roomName.v;
                                    if (roomName != null)
                                    {
                                        // update
                                        RequestChangeUpdate<string>.UpdateData updateData = roomName.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.roomName.v;
                                            updateData.canRequestChange.v = editDefaultRoomNameAlways.canEdit.v;
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
                                                roomName.showDifferent.v = true;
                                                roomName.compare.v = compare.roomName.v;
                                            }
                                            else
                                            {
                                                roomName.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("roomName null: " + this);
                                    }
                                }
                            }
                            // reset?
                            if (needReset)
                            {
                                needReset = false;
                                // variant
                                {
                                    RequestChangeStringUI.UIData roomName = this.data.roomName.v;
                                    if (roomName != null)
                                    {
                                        // update
                                        RequestChangeUpdate<string>.UpdateData updateData = roomName.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.roomName.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("roomName null: " + this);
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
                        // roomName
                        {
                            if (this.data.roomName.v != null)
                            {
                                if (lbRoomName != null)
                                {
                                    lbRoomName.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbRoomName.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbRoomName null");
                                }
                                UIRectTransform.SetPosY(this.data.roomName.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbRoomName != null)
                                {
                                    lbRoomName.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbRoomName null");
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
                        if (lbRoomName != null)
                        {
                            lbRoomName.text = txtRoomName.get();
                            Setting.get().setLabelTextSize(lbRoomName);
                        }
                        else
                        {
                            Debug.LogError("lbRoomName null: " + this);
                        }
                    }
                }
                else
                {
                    Debug.LogError("editDefaultRoomNameAlways null: " + this);
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

    public RequestChangeStringUI requestStringPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.editDefaultRoomNameAlways.allAddCallBack(this);
                uiData.roomName.allAddCallBack(this);
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
            // editDefaultRoomNameAlways
            {
                if (data is EditData<DefaultRoomNameAlways>)
                {
                    EditData<DefaultRoomNameAlways> editDefaultRoomNameAlways = data as EditData<DefaultRoomNameAlways>;
                    // Child
                    {
                        editDefaultRoomNameAlways.show.allAddCallBack(this);
                        editDefaultRoomNameAlways.compare.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is DefaultRoomNameAlways)
                {
                    needReset = true;
                    dirty = true;
                    return;
                }
            }
            if (data is RequestChangeStringUI.UIData)
            {
                RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
                // UI
                {
                    WrapProperty wrapProperty = requestChange.p;
                    if (wrapProperty != null)
                    {
                        switch ((UIData.Property)wrapProperty.n)
                        {
                            case UIData.Property.roomName:
                                UIUtils.Instantiate(requestChange, requestStringPrefab, this.transform, UIConstants.RequestEnumRect);
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
                uiData.editDefaultRoomNameAlways.allRemoveCallBack(this);
                uiData.roomName.allRemoveCallBack(this);
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
            // editDefaultRoomNameAlways
            {
                if (data is EditData<DefaultRoomNameAlways>)
                {
                    EditData<DefaultRoomNameAlways> editDefaultRoomNameAlways = data as EditData<DefaultRoomNameAlways>;
                    // Child
                    {
                        editDefaultRoomNameAlways.show.allRemoveCallBack(this);
                        editDefaultRoomNameAlways.compare.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is DefaultRoomNameAlways)
                {
                    return;
                }
            }
            if (data is RequestChangeStringUI.UIData)
            {
                RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeStringUI));
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
                case UIData.Property.editDefaultRoomNameAlways:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.showType:
                    dirty = true;
                    break;
                case UIData.Property.roomName:
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
                case Setting.Property.defaultRoomName:
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
            // editDefaultRoomNameAlways
            {
                if (wrapProperty.p is EditData<DefaultRoomNameAlways>)
                {
                    switch ((EditData<DefaultRoomNameAlways>.Property)wrapProperty.n)
                    {
                        case EditData<DefaultRoomNameAlways>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<DefaultRoomNameAlways>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<DefaultRoomNameAlways>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<DefaultRoomNameAlways>.Property.compareOtherType:
                            dirty = true;
                            break;
                        case EditData<DefaultRoomNameAlways>.Property.canEdit:
                            dirty = true;
                            break;
                        case EditData<DefaultRoomNameAlways>.Property.editType:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is DefaultRoomNameAlways)
                {
                    switch ((DefaultRoomNameAlways.Property)wrapProperty.n)
                    {
                        case DefaultRoomNameAlways.Property.roomName:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            if (wrapProperty.p is RequestChangeStringUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}
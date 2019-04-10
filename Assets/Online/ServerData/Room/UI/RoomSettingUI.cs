using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Rights;

public class RoomSettingUI : UIHaveTransformDataBehavior<RoomSettingUI.UIData>
{

    #region UIData

    public class UIData : Data, EditDataUI.UIData<Room>
    {

        public VP<EditData<Room>> editRoom;

        #region name

        public VP<RequestChangeStringUI.UIData> name;

        public void makeRequestChangeName(RequestChangeUpdate<string>.UpdateData update, string newName)
        {
            // Find
            Room room = null;
            {
                EditData<Room> editRoom = this.editRoom.v;
                if (editRoom != null)
                {
                    room = editRoom.show.v.data;
                }
                else
                {
                    Debug.LogError("editRoom null: " + this);
                }
            }
            // Process
            if (room != null)
            {
                room.requestChangeName(Server.getProfileUserId(room), newName);
            }
            else
            {
                Debug.LogError("room null: " + this);
            }
        }

        #endregion

        public VP<RoomStateUI.UIData> roomStateUIData;

        #region allowHint

        public VP<RequestChangeEnumUI.UIData> allowHint;

        public void makeRequestChangeAllowHint(RequestChangeUpdate<int>.UpdateData update, int newAllowHint)
        {
            // Find
            Room room = null;
            {
                EditData<Room> editRoom = this.editRoom.v;
                if (editRoom != null)
                {
                    room = editRoom.show.v.data;
                }
                else
                {
                    Debug.LogError("editRoom null: " + this);
                }
            }
            // Process
            if (room != null)
            {
                room.requestChangeAllowHint(Server.getProfileUserId(room), newAllowHint);
            }
            else
            {
                Debug.LogError("room null: " + this);
            }
        }

        #endregion

        #region allowLoadHistory

        public VP<RequestChangeBoolUI.UIData> allowLoadHistory;

        public void makeRequestChangeAllowLoadHistory(RequestChangeUpdate<bool>.UpdateData update, bool newAllowLoadHistory)
        {
            // Find
            Room room = null;
            {
                EditData<Room> editRoom = this.editRoom.v;
                if (editRoom != null)
                {
                    room = editRoom.show.v.data;
                }
                else
                {
                    Debug.LogError("editRoom null: " + this);
                }
            }
            // Process
            if (room != null)
            {
                room.requestChangeAllowLoadHistory(Server.getProfileUserId(room), newAllowLoadHistory);
            }
            else
            {
                Debug.LogError("room null: " + this);
            }
        }

        #endregion

        #region chatInGame

        public VP<RequestChangeEnumUI.UIData> chatInGame;

        public void makeRequestChangeChatInGame(RequestChangeUpdate<int>.UpdateData update, int newChatInGame)
        {
            // Find
            Room room = null;
            {
                EditData<Room> editRoom = this.editRoom.v;
                if (editRoom != null)
                {
                    room = editRoom.show.v.data;
                }
                else
                {
                    Debug.LogError("editRoom null: " + this);
                }
            }
            // Process
            if (room != null)
            {
                room.requestChangeChatInGame(Server.getProfileUserId(room), newChatInGame);
            }
            else
            {
                Debug.LogError("room null: " + this);
            }
        }

        #endregion

        public VP<ChangeRightsUI.UIData> changeRights;

        #region Constructor

        public enum Property
        {
            editRoom,
            name,
            roomStateUIData,
            allowHint,
            allowLoadHistory,
            chatInGame,
            changeRights
        }

        public static readonly List<byte> AllowNames = new List<byte>();

        static UIData()
        {
            AllowNames.Add((byte)Room.Property.name);
            AllowNames.Add((byte)Room.Property.changeRights);
            AllowNames.Add((byte)Room.Property.allowHint);
            AllowNames.Add((byte)Room.Property.allowLoadHistory);
            AllowNames.Add((byte)Room.Property.chatInGame);
        }

        public UIData() : base()
        {
            // editRoom
            {
                EditData<Room> editDataRoom = new EditData<Room>();
                {
                    editDataRoom.allowNames = AllowNames;
                }
                this.editRoom = new VP<EditData<Room>>(this, (byte)Property.editRoom, editDataRoom);
            }
            // name
            {
                this.name = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.name, new RequestChangeStringUI.UIData());
                this.name.v.updateData.v.request.v = makeRequestChangeName;
            }
            this.roomStateUIData = new VP<RoomStateUI.UIData>(this, (byte)Property.roomStateUIData, new RoomStateUI.UIData());
            // allowHint
            {
                this.allowHint = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.allowHint, new RequestChangeEnumUI.UIData());
                // event
                this.allowHint.v.updateData.v.request.v = makeRequestChangeAllowHint;
                {
                    foreach (Room.AllowHint type in System.Enum.GetValues(typeof(Room.AllowHint)))
                    {
                        this.allowHint.v.options.add(type.ToString());
                    }
                }
            }
            // allowLoadHistory
            {
                this.allowLoadHistory = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.allowLoadHistory, new RequestChangeBoolUI.UIData());
                // event
                this.allowLoadHistory.v.updateData.v.request.v = makeRequestChangeAllowLoadHistory;
            }
            // chatInGame
            {
                this.chatInGame = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.chatInGame, new RequestChangeEnumUI.UIData());
                // event
                this.chatInGame.v.updateData.v.request.v = makeRequestChangeChatInGame;
                {
                    foreach (Room.ChatInGame type in System.Enum.GetValues(typeof(Room.ChatInGame)))
                    {
                        this.chatInGame.v.options.add(type.ToString());
                    }
                }
            }
            this.changeRights = new VP<ChangeRightsUI.UIData>(this, (byte)Property.changeRights, new ChangeRightsUI.UIData());
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {

            }
            return isProcess;
        }

        #region implement interface

        public EditData<Room> getEditData()
        {
            return this.editRoom.v;
        }

        #endregion

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Room Setting");

    public Text lbName;
    private static readonly TxtLanguage txtName = new TxtLanguage("Name");

    public Text lbFreeze;
    private static readonly TxtLanguage txtFreeze = new TxtLanguage("Freeze");

    public Text lbAllowHint;
    private static readonly TxtLanguage txtAllowHint = new TxtLanguage("Hint");

    public Text lbAllowLoadHistory;
    private static readonly TxtLanguage txtAllowLoadHistory = new TxtLanguage("Load game history");

    public Text lbChatInGame;
    private static readonly TxtLanguage txtChatInGame = new TxtLanguage("Chat in game");

    static RoomSettingUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Thiết Lập Phòng");
            txtName.add(Language.Type.vi, "Tên");
            txtFreeze.add(Language.Type.vi, "Đóng băng");
            txtAllowHint.add(Language.Type.vi, "Gợi ý");
            txtAllowLoadHistory.add(Language.Type.vi, "Tải lịch sử game");
            txtChatInGame.add(Language.Type.vi, "Chat trong game");
        }
        // rect
        {
            // roomStateRect
            {
                // anchoredPosition: (90.0, -105.0); anchorMin: (0.0, 1.0); anchorMax: (0.0, 1.0); 
                // pivot: (0.0, 1.0); offsetMin: (90.0, -135.0); offsetMax: (210.0, -105.0); sizeDelta: (120.0, 30.0);
                roomStateRect.anchoredPosition = new Vector3(90.0f, -105.0f, 0.0f);
                roomStateRect.anchorMin = new Vector2(0.0f, 1.0f);
                roomStateRect.anchorMax = new Vector2(0.0f, 1.0f);
                roomStateRect.pivot = new Vector2(0.0f, 1.0f);
                roomStateRect.offsetMin = new Vector2(90.0f, -135.0f);
                roomStateRect.offsetMax = new Vector2(210.0f, -105.0f);
                roomStateRect.sizeDelta = new Vector2(120.0f, 30.0f);
            }
        }
    }

    #endregion

    #region Refresh

    private bool needReset = true;

    public Image bgChangeRights;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                EditData<Room> editRoom = this.data.editRoom.v;
                if (editRoom != null)
                {
                    editRoom.update();
                    // UI
                    {
                        // different
                        RequestChange.ShowDifferentTitle(lbTitle, editRoom);
                        // request
                        {
                            // get server state
                            Server.State.Type serverState = RequestChange.GetServerState(editRoom);
                            // set origin
                            {
                                RequestChange.RefreshUI(this.data.name.v, editRoom, serverState, needReset, editData => editData.name.v);
                                // allowHint
                                {
                                    RequestChangeEnumUI.RefreshOptions(this.data.allowHint.v, Room.getAllowHintStr());
                                    RequestChange.RefreshUI(this.data.allowHint.v, editRoom, serverState, needReset, editData => (int)editData.allowHint.v);
                                }
                                RequestChange.RefreshUI(this.data.allowLoadHistory.v, editRoom, serverState, needReset, editData => editData.allowLoadHistory.v);
                                // chatInGame
                                {
                                    RequestChangeEnumUI.RefreshOptions(this.data.chatInGame.v, Room.getChatInGameStr());
                                    RequestChange.RefreshUI(this.data.chatInGame.v, editRoom, serverState, needReset, editData => (int)editData.chatInGame.v);
                                }
                                EditDataUI.RefreshChildUI(this.data, this.data.changeRights.v, editData => editData.changeRights.v);
                            }
                            needReset = false;
                        }
                    }
                }
                else
                {
                    Debug.LogError("editRoom null: " + this);
                }
                // UI Size
                {
                    float deltaY = UIConstants.HeaderHeight;
                    // name
                    {
                        deltaY += UIConstants.ItemHeight;
                    }
                    // freeze
                    {
                        deltaY += UIConstants.ItemHeight;
                    }
                    // allowHint
                    {
                        deltaY += UIConstants.ItemHeight;
                    }
                    // allowLoadHistory
                    {
                        deltaY += UIConstants.ItemHeight;
                    }
                    // chatInGame
                    {
                        deltaY += UIConstants.ItemHeight;
                    }
                    // changeRights
                    {
                        float bgY = deltaY;
                        float bgHeight = 0;
                        // UI
                        {
                            float height = UIRectTransform.SetPosY(this.data.changeRights.v, deltaY);
                            bgHeight += height;
                            deltaY += height;
                        }
                        // bg
                        if (bgChangeRights != null)
                        {
                            UIRectTransform.SetPosY(bgChangeRights.rectTransform, bgY);
                            UIRectTransform.SetHeight(bgChangeRights.rectTransform, bgHeight);
                        }
                        else
                        {
                            Debug.LogError("bgChangeRights null");
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
                    if (lbName != null)
                    {
                        lbName.text = txtName.get();
                        Setting.get().setLabelTextSize(lbName);
                    }
                    else
                    {
                        Debug.LogError("lbName null: " + this);
                    }
                    if (lbFreeze != null)
                    {
                        lbFreeze.text = txtFreeze.get();
                        Setting.get().setLabelTextSize(lbFreeze);
                    }
                    else
                    {
                        Debug.LogError("lbFreeze null");
                    }
                    if (lbAllowHint != null)
                    {
                        lbAllowHint.text = txtAllowHint.get();
                        Setting.get().setLabelTextSize(lbAllowHint);
                    }
                    else
                    {
                        Debug.LogError("lbAllowHint null: " + this);
                    }
                    if (lbAllowLoadHistory != null)
                    {
                        lbAllowLoadHistory.text = txtAllowLoadHistory.get();
                        Setting.get().setLabelTextSize(lbAllowLoadHistory);
                    }
                    else
                    {
                        Debug.LogError("lbAllowLoadHistory null");
                    }
                    if (lbChatInGame != null)
                    {
                        lbChatInGame.text = txtChatInGame.get();
                        Setting.get().setLabelTextSize(lbChatInGame);
                    }
                    else
                    {
                        Debug.LogError("lbChatInGame null");
                    }
                }
            }
            else
            {
                // Debug.LogError("data null: " + this);
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public RoomStateUI roomStatePrefab;
    private static readonly UIRectTransform roomStateRect = new UIRectTransform();

    public RequestChangeStringUI requestStringPrefab;
    public RequestChangeBoolUI requestBoolPrefab;
    public RequestChangeEnumUI requestEnumPrefab;
    public ChangeRightsUI changeRightsPrefab;

    private static readonly UIRectTransform nameRect = new UIRectTransform(UIConstants.RequestEnumRect,
        UIConstants.HeaderHeight + 0 * UIConstants.ItemHeight +
        (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
    private static readonly UIRectTransform allowHintRect = new UIRectTransform(UIConstants.RequestEnumRect,
        UIConstants.HeaderHeight + 2 * UIConstants.ItemHeight +
        (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
    private static readonly UIRectTransform allowLoadHistoryRect = new UIRectTransform(UIConstants.RequestBoolRect,
        UIConstants.HeaderHeight + 3 * UIConstants.ItemHeight +
        (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
    private static readonly UIRectTransform chatInGameRect = new UIRectTransform(UIConstants.RequestEnumRect,
        UIConstants.HeaderHeight + 4 * UIConstants.ItemHeight +
        (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);

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
                uiData.editRoom.allAddCallBack(this);
                uiData.name.allAddCallBack(this);
                uiData.roomStateUIData.allAddCallBack(this);
                uiData.allowHint.allAddCallBack(this);
                uiData.allowLoadHistory.allAddCallBack(this);
                uiData.chatInGame.allAddCallBack(this);
                uiData.changeRights.allAddCallBack(this);
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
            // editRoom
            {
                if (data is EditData<Room>)
                {
                    EditData<Room> editRoom = data as EditData<Room>;
                    // Child
                    {
                        editRoom.show.allAddCallBack(this);
                        editRoom.compare.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is Room)
                    {
                        Room room = data as Room;
                        // Parent
                        {
                            DataUtils.addParentCallBack(room, this, ref this.server);
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
            // name
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
                            case UIData.Property.name:
                                UIUtils.Instantiate(requestChange, requestStringPrefab, this.transform, nameRect);
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
            if (data is RoomStateUI.UIData)
            {
                RoomStateUI.UIData roomStateUIData = data as RoomStateUI.UIData;
                // Child
                {
                    UIUtils.Instantiate(roomStateUIData, roomStatePrefab, this.transform, roomStateRect);
                }
                dirty = true;
                return;
            }
            // allowHint, chatInGame
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
                            case UIData.Property.allowHint:
                                UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, allowHintRect);
                                break;
                            case UIData.Property.chatInGame:
                                UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, chatInGameRect);
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
            // allowLoadHistory
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
                            case UIData.Property.allowLoadHistory:
                                UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, allowLoadHistoryRect);
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
            // changeRights
            {
                if (data is ChangeRightsUI.UIData)
                {
                    ChangeRightsUI.UIData changeRightsUIData = data as ChangeRightsUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(changeRightsUIData, changeRightsPrefab, this.transform);
                    }
                    // Child
                    {
                        TransformData.AddCallBack(changeRightsUIData, this);
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
                uiData.editRoom.allRemoveCallBack(this);
                uiData.name.allRemoveCallBack(this);
                uiData.roomStateUIData.allRemoveCallBack(this);
                uiData.allowHint.allRemoveCallBack(this);
                uiData.allowLoadHistory.allRemoveCallBack(this);
                uiData.chatInGame.allRemoveCallBack(this);
                uiData.changeRights.allRemoveCallBack(this);
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
            // editRoom
            {
                if (data is EditData<Room>)
                {
                    EditData<Room> editRoom = data as EditData<Room>;
                    // Child
                    {
                        editRoom.show.allRemoveCallBack(this);
                        editRoom.compare.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is Room)
                    {
                        Room room = data as Room;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(room, this, ref this.server);
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
            // name
            if (data is RequestChangeStringUI.UIData)
            {
                RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeStringUI));
                }
                return;
            }
            if (data is RoomStateUI.UIData)
            {
                RoomStateUI.UIData roomStateUIData = data as RoomStateUI.UIData;
                // UI
                {
                    roomStateUIData.removeCallBackAndDestroy(typeof(RoomStateUI));
                }
                return;
            }
            // allowHint, chatInGame
            if (data is RequestChangeEnumUI.UIData)
            {
                RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeEnumUI));
                }
                return;
            }
            // allowLoadHistory
            if (data is RequestChangeBoolUI.UIData)
            {
                RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeBoolUI));
                }
                return;
            }
            // changeRights
            {
                if (data is ChangeRightsUI.UIData)
                {
                    ChangeRightsUI.UIData changeRightsUIData = data as ChangeRightsUI.UIData;
                    // Child
                    {
                        TransformData.RemoveCallBack(changeRightsUIData, this);
                    }
                    // UI
                    {
                        changeRightsUIData.removeCallBackAndDestroy(typeof(ChangeRightsUI));
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
                case UIData.Property.editRoom:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.name:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.roomStateUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.allowHint:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.allowLoadHistory:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.chatInGame:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.changeRights:
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
            // editRoom
            {
                if (wrapProperty.p is EditData<Room>)
                {
                    switch ((EditData<Room>.Property)wrapProperty.n)
                    {
                        case EditData<Room>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<Room>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<Room>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<Room>.Property.compareOtherType:
                            dirty = true;
                            break;
                        case EditData<Room>.Property.canEdit:
                            dirty = true;
                            break;
                        case EditData<Room>.Property.editType:
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
                    if (wrapProperty.p is Room)
                    {
                        switch ((Room.Property)wrapProperty.n)
                        {
                            case Room.Property.changeRights:
                                dirty = true;
                                break;
                            case Room.Property.name:
                                dirty = true;
                                break;
                            case Room.Property.password:
                                break;
                            case Room.Property.users:
                                break;
                            case Room.Property.state:
                                break;
                            case Room.Property.contestManagers:
                                break;
                            case Room.Property.timeCreated:
                                break;
                            case Room.Property.chatRoom:
                                break;
                            case Room.Property.allowHint:
                                dirty = true;
                                break;
                            case Room.Property.allowLoadHistory:
                                dirty = true;
                                break;
                            case Room.Property.chatInGame:
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
            // name
            if (wrapProperty.p is RequestChangeStringUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is RoomStateUI.UIData)
            {
                return;
            }
            // allowHint, chatInGame
            if (wrapProperty.p is RequestChangeEnumUI.UIData)
            {
                return;
            }
            // allowLoadHistory
            if (wrapProperty.p is RequestChangeBoolUI.UIData)
            {
                return;
            }
            // changeRights
            {
                if (wrapProperty.p is ChangeRightsUI.UIData)
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
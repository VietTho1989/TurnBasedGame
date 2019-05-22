using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CreateRoomUI : UIBehavior<CreateRoomUI.UIData>
{

    #region UIData

    public class UIData : RoomListUI.UIData.Sub
    {

        public VP<EditData<CreateRoom>> editCreateRoom;

        #region gameType

        public VP<RequestChangeEnumUI.UIData> gameType;

        public void makeRequestChangeGameType(RequestChangeUpdate<int>.UpdateData update, int newGameType)
        {
            // Find
            CreateRoom createRoom = null;
            {
                EditData<CreateRoom> editCreateRoom = this.editCreateRoom.v;
                if (editCreateRoom != null)
                {
                    createRoom = editCreateRoom.show.v.data;
                }
                else
                {
                    Debug.LogError("editCreateRoom null: " + this);
                }
            }
            // Process
            if (createRoom != null)
            {
                // Find gameTypeType
                GameType.Type gameTypeType = GameType.Type.CHESS;
                {
                    // find server
                    Server server = null;
                    {
                        ManagerUI.UIData managerUIData = this.findDataInParent<ManagerUI.UIData>();
                        if (managerUIData != null)
                        {
                            server = managerUIData.server.v.data;
                        }
                        else
                        {
                            Debug.LogError("managerUIData null");
                        }
                    }
                    gameTypeType = GameType.GetEnableGameTypeByIndex(server, newGameType);
                }
                createRoom.gameType.v = gameTypeType;
            }
            else
            {
                Debug.LogError("createRoom null: " + this);
            }
        }

        #endregion

        #region roomName

        public VP<RequestChangeStringUI.UIData> roomName;

        public void makeRequestChangeRoomName(RequestChangeUpdate<string>.UpdateData update, string newRoomName)
        {
            // Find
            CreateRoom createRoom = null;
            {
                EditData<CreateRoom> editCreateRoom = this.editCreateRoom.v;
                if (editCreateRoom != null)
                {
                    createRoom = editCreateRoom.show.v.data;
                }
                else
                {
                    Debug.LogError("editCreateRoom null: " + this);
                }
            }
            // Process
            if (createRoom != null)
            {
                createRoom.roomName.v = newRoomName;
            }
            else
            {
                Debug.LogError("createRoom null: " + this);
            }
        }

        #endregion

        #region password

        public VP<RequestChangeStringUI.UIData> password;

        public void makeRequestChangePassword(RequestChangeUpdate<string>.UpdateData update, string newPassword)
        {
            // Find
            CreateRoom createRoom = null;
            {
                EditData<CreateRoom> editCreateRoom = this.editCreateRoom.v;
                if (editCreateRoom != null)
                {
                    createRoom = editCreateRoom.show.v.data;
                }
                else
                {
                    Debug.LogError("editCreateRoom null: " + this);
                }
            }
            // Process
            if (createRoom != null)
            {
                createRoom.password.v = newPassword;
            }
            else
            {
                Debug.LogError("createRoom null: " + this);
            }
        }

        #endregion

        public VP<BtnCreateRoomUI.UIData> btnCreateRoom;

        #region Constructor

        public enum Property
        {
            editCreateRoom,
            gameType,
            roomName,
            password,
            btnCreateRoom
        }

        public UIData() : base()
        {
            this.editCreateRoom = new VP<EditData<CreateRoom>>(this, (byte)Property.editCreateRoom, new EditData<CreateRoom>());
            // gameType
            {
                this.gameType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.gameType, new RequestChangeEnumUI.UIData());
                // event
                this.gameType.v.updateData.v.request.v = makeRequestChangeGameType;
            }
            // roomName
            {
                this.roomName = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.roomName, new RequestChangeStringUI.UIData());
                // event
                this.roomName.v.updateData.v.request.v = makeRequestChangeRoomName;
            }
            // password
            {
                this.password = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.password, new RequestChangeStringUI.UIData());
                // event
                this.password.v.updateData.v.request.v = makeRequestChangePassword;
            }
            this.btnCreateRoom = new VP<BtnCreateRoomUI.UIData>(this, (byte)Property.btnCreateRoom, new BtnCreateRoomUI.UIData());
        }

        #endregion

        public override Type getType()
        {
            return Type.CreateRoom;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        // Debug.LogError ("createRoom: backEvent: " + this);
                        CreateRoomUI createRoomUI = this.findCallBack<CreateRoomUI>();
                        if (createRoomUI != null)
                        {
                            createRoomUI.onClickBtnCancel();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("createRoomUI null: " + this);
                        }
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        CreateRoomUI createRoomUI = this.findCallBack<CreateRoomUI>();
                        if (createRoomUI != null)
                        {
                            isProcess = createRoomUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("createRoomUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    public override int getStartAllocate()
    {
        return 1;
    }

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Create Room");

    public Text lbGameType;
    private static readonly TxtLanguage txtGameType = new TxtLanguage("Game");

    public Text lbRoomName;
    private static readonly TxtLanguage txtRoomName = new TxtLanguage("Room name");

    public Text lbPassword;
    private static readonly TxtLanguage txtPassword = new TxtLanguage("Password");

    static CreateRoomUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Tạo Phòng");
            txtGameType.add(Language.Type.vi, "Chọn trò");
            txtRoomName.add(Language.Type.vi, "Tên phòng");
            txtPassword.add(Language.Type.vi, "Mật khẩu");
        }
        // rect
        {
            // btnCreateRoomRect
            {
                // anchoredPosition: (-80.0, -220.0); anchorMin: (0.5, 1.0); anchorMax: (0.5, 1.0); pivot: (0.5, 1.0);
                // offsetMin: (-160.0, -250.0); offsetMax: (0.0, -220.0); sizeDelta: (160.0, 30.0);
                btnCreateRoomRect.anchoredPosition = new Vector3(0, -225.0f, 0f);
                btnCreateRoomRect.anchorMin = new Vector2(0.5f, 1.0f);
                btnCreateRoomRect.anchorMax = new Vector2(0.5f, 1.0f);
                btnCreateRoomRect.pivot = new Vector2(0.5f, 1.0f);
                btnCreateRoomRect.offsetMin = new Vector2(-80.0f, -255f);
                btnCreateRoomRect.offsetMax = new Vector2(80.0f, -225.0f);
                btnCreateRoomRect.sizeDelta = new Vector2(160.0f, 30.0f);
            }
        }
    }

    #endregion

    #region Refresh

    private bool needReset = true;

    public Button btnBack;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                EditData<CreateRoom> editCreateRoom = this.data.editCreateRoom.v;
                if (editCreateRoom != null)
                {
                    editCreateRoom.update();
                    // UI
                    {
                        // different
                        RequestChange.ShowDifferentTitle(lbTitle, editCreateRoom);
                        // request
                        {
                            // get server state
                            Server.State.Type serverState = RequestChange.GetServerState(editCreateRoom);
                            // set origin
                            {
                                // gameType
                                {
                                    // find server
                                    Server server = null;
                                    {
                                        ManagerUI.UIData managerUIData = this.data.findDataInParent<ManagerUI.UIData>();
                                        if (managerUIData != null)
                                        {
                                            server = managerUIData.server.v.data;
                                        }
                                        else
                                        {
                                            Debug.LogError("managerUIData null");
                                        }
                                    }
                                    // set
                                    {
                                        RequestChangeEnumUI.RefreshOptions(this.data.gameType.v, GameType.GetEnableTypeString(server));
                                        RequestChange.RefreshUI(this.data.gameType.v, editCreateRoom, serverState, needReset, editData => GameType.getEnableIndex(editData.gameType.v, server));
                                    }
                                }
                                RequestChange.RefreshUI(this.data.roomName.v, editCreateRoom, serverState, needReset, editData => editData.roomName.v);
                                RequestChange.RefreshUI(this.data.password.v, editCreateRoom, serverState, needReset, editData => editData.password.v);
                            }
                        }
                        needReset = false;
                    }
                }
                else
                {
                    Debug.LogError("editCreateRoom null: " + this);
                }
                // UI
                {
                    float buttonSize = Setting.get().getButtonSize();
                    float deltaY = 0;
                    // header
                    {
                        UIRectTransform.SetButtonTopLeftTransform(btnBack);
                        UIRectTransform.SetTitleTransform(lbTitle);
                        deltaY += buttonSize;
                    }
                    // gameType
                    UIUtils.SetLabelContentPosition(lbGameType, this.data.gameType.v, ref deltaY);
                    // roomName
                    UIUtils.SetLabelContentPosition(lbRoomName, this.data.roomName.v, ref deltaY);
                    // password
                    UIUtils.SetLabelContentPosition(lbPassword, this.data.password.v, ref deltaY);
                    // bottom
                    {
                        UIRectTransform.SetPosY(this.data.btnCreateRoom.v, deltaY + 15);
                        deltaY += 60;
                    }
                    // set height
                    {
                        UIRectTransform rect = UIRectTransform.CreateCenterRect(400, deltaY);
                        UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                    }
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
                    if (lbGameType != null)
                    {
                        lbGameType.text = txtGameType.get();
                        Setting.get().setLabelTextSize(lbGameType);
                    }
                    else
                    {
                        Debug.LogError("lbGameType null: " + this);
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
                    if (lbPassword != null)
                    {
                        lbPassword.text = txtPassword.get();
                        Setting.get().setLabelTextSize(lbPassword);
                    }
                    else
                    {
                        Debug.LogError("lbPassword null: " + this);
                    }
                }
            }
            else
            {
                Debug.Log("data null: " + this);
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public BtnCreateRoomUI btnCreateRoomPrefab;
    private static readonly UIRectTransform btnCreateRoomRect = new UIRectTransform();

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
                uiData.editCreateRoom.allAddCallBack(this);
                uiData.gameType.allAddCallBack(this);
                uiData.roomName.allAddCallBack(this);
                uiData.password.allAddCallBack(this);
                uiData.btnCreateRoom.allAddCallBack(this);
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
            // editCreateRoom
            {
                if (data is EditData<CreateRoom>)
                {
                    EditData<CreateRoom> editCreateRoom = data as EditData<CreateRoom>;
                    // Child
                    {
                        editCreateRoom.show.allAddCallBack(this);
                        editCreateRoom.compare.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is CreateRoom)
                    {
                        CreateRoom createRoom = data as CreateRoom;
                        // Parent
                        {
                            DataUtils.addParentCallBack(createRoom, this, ref this.server);
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
                            case UIData.Property.gameType:
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
                                UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestString, this.transform, UIConstants.RequestEnumRect);
                                break;
                            case UIData.Property.password:
                                UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestString, this.transform, UIConstants.RequestEnumRect);
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
            if (data is BtnCreateRoomUI.UIData)
            {
                BtnCreateRoomUI.UIData btnCreateRoomUIData = data as BtnCreateRoomUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnCreateRoomUIData, btnCreateRoomPrefab, this.transform, btnCreateRoomRect);
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
                uiData.editCreateRoom.allRemoveCallBack(this);
                uiData.gameType.allRemoveCallBack(this);
                uiData.roomName.allRemoveCallBack(this);
                uiData.password.allRemoveCallBack(this);
                uiData.btnCreateRoom.allRemoveCallBack(this);
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
            // editCreateRoom
            {
                if (data is EditData<CreateRoom>)
                {
                    EditData<CreateRoom> editCreateRoom = data as EditData<CreateRoom>;
                    // Child
                    {
                        editCreateRoom.show.allRemoveCallBack(this);
                        editCreateRoom.compare.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is CreateRoom)
                    {
                        CreateRoom createRoom = data as CreateRoom;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(createRoom, this, ref this.server);
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
            if (data is RequestChangeEnumUI.UIData)
            {
                RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeEnumUI));
                }
                return;
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
            if (data is BtnCreateRoomUI.UIData)
            {
                BtnCreateRoomUI.UIData btnCreateRoomUIData = data as BtnCreateRoomUI.UIData;
                // UI
                {
                    btnCreateRoomUIData.removeCallBackAndDestroy(typeof(BtnCreateRoomUI));
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
                case UIData.Property.editCreateRoom:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.gameType:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.roomName:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.password:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.btnCreateRoom:
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
            // editCreateRoom
            {
                if (wrapProperty.p is EditData<CreateRoom>)
                {
                    switch ((EditData<CreateRoom>.Property)wrapProperty.n)
                    {
                        case EditData<CreateRoom>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<CreateRoom>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<CreateRoom>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<CreateRoom>.Property.compareOtherType:
                            dirty = true;
                            break;
                        case EditData<CreateRoom>.Property.canEdit:
                            dirty = true;
                            break;
                        case EditData<CreateRoom>.Property.editType:
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
                    if (wrapProperty.p is CreateRoom)
                    {
                        switch ((CreateRoom.Property)wrapProperty.n)
                        {
                            case CreateRoom.Property.gameType:
                                dirty = true;
                                break;
                            case CreateRoom.Property.roomName:
                                dirty = true;
                                break;
                            case CreateRoom.Property.password:
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
                            switch ((Server.Property)wrapProperty.n)
                            {
                                case Server.Property.serverConfig:
                                    break;
                                case Server.Property.startState:
                                    break;
                                case Server.Property.type:
                                    break;
                                case Server.Property.profile:
                                    break;
                                case Server.Property.state:
                                    dirty = true;
                                    break;
                                case Server.Property.users:
                                    break;
                                case Server.Property.globalChat:
                                    break;
                                case Server.Property.friendWorld:
                                    break;
                                case Server.Property.guilds:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                    }
                }
            }
            if (wrapProperty.p is RequestChangeEnumUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is RequestChangeStringUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is BtnCreateRoomUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public override void Awake()
    {
        base.Awake();
        // OnClick
        {
            UIUtils.SetButtonOnClick(btnCreate, onClickBtnCreate);
            UIUtils.SetButtonOnClick(btnBack, onClickBtnCancel);
        }
    }

    public bool useShortKey(Event e)
    {
        bool isProcess = false;
        {
            if (e.isKey && e.type == EventType.KeyUp)
            {
                switch (e.keyCode)
                {
                    case KeyCode.O:
                        {
                            if (btnCreate != null && btnCreate.gameObject.activeInHierarchy && btnCreate.interactable)
                            {
                                this.onClickBtnCreate();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("cannot click");
                            }
                        }
                        break;
                    case KeyCode.C:
                        {
                            if (btnBack != null && btnBack.gameObject.activeInHierarchy && btnBack.interactable)
                            {
                                this.onClickBtnCancel();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("cannot click");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        return isProcess;
    }

    public Button btnCreate;

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnCreate()
    {
        if (this.data != null)
        {
            EditData<CreateRoom> editCreateRoom = this.data.editCreateRoom.v;
            if (editCreateRoom != null)
            {
                CreateRoom createRoom = editCreateRoom.show.v.data;
                if (createRoom != null)
                {
                    // globalRoomContainer
                    {
                        GlobalRoomContainerUI.UIData globalRoomContainerUIData = this.data.findDataInParent<GlobalRoomContainerUI.UIData>();
                        if (globalRoomContainerUIData != null)
                        {
                            GlobalRoomContainer globalRoomContainer = globalRoomContainerUIData.globalRoomContainer.v.data;
                            if (globalRoomContainer != null)
                            {
                                globalRoomContainer.requestMakeRoom(Server.getProfileUserId(globalRoomContainer), createRoom.makeMessage());
                                return;
                            }
                            else
                            {
                                Debug.LogError("globalRoomContainer null");
                            }
                        }
                        else
                        {
                            Debug.LogError("globalRoomContainerUIData null");
                        }
                    }
                    // limitRoomContainer
                    {
                        LimitRoomContainerUI.UIData limitRoomContainerUIData = this.data.findDataInParent<LimitRoomContainerUI.UIData>();
                        if (limitRoomContainerUIData != null)
                        {
                            LimitRoomContainer limitRoomContainer = limitRoomContainerUIData.limitRoomContainer.v.data;
                            if (limitRoomContainer != null)
                            {
                                limitRoomContainer.requestMakeRoom(Server.getProfileUserId(limitRoomContainer), createRoom.makeMessage());
                                return;
                            }
                            else
                            {
                                Debug.LogError("limitRoomContainer null");
                            }
                        }
                        else
                        {
                            Debug.LogError("limitRoomContainerUIData null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("createRoom null: " + this);
                }
            }
            else
            {
                Debug.LogError("editCreateRoom null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnCancel()
    {
        if (this.data != null)
        {
            RoomListUI.UIData roomListUIData = this.data.findDataInParent<RoomListUI.UIData>();
            if (roomListUIData != null)
            {
                roomListUIData.sub.v = null;
            }
            else
            {
                Debug.LogError("roomListUIData null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}
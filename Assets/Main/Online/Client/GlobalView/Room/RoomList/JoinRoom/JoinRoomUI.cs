using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using GameManager.Match;

public class JoinRoomUI : UIBehavior<JoinRoomUI.UIData>
{

    #region UIData

    public class UIData : RoomListUI.UIData.Sub
    {

        public VP<ReferenceData<Room>> room;

        #region State

        public enum State
        {
            None,
            Request,
            Wait
        }

        public VP<State> requestState;

        #endregion

        #region Constructor

        public enum Property
        {
            room,
            requestState
        }

        public UIData() : base()
        {
            this.room = new VP<ReferenceData<Room>>(this, (byte)Property.room, new ReferenceData<Room>(null));
            this.requestState = new VP<State>(this, (byte)Property.requestState, State.None);
        }

        #endregion

        public override Type getType()
        {
            return Type.JoinRoom;
        }

        public void reset()
        {
            this.requestState.v = State.None;
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
                        JoinRoomUI joinRoomUI = this.findCallBack<JoinRoomUI>();
                        if (joinRoomUI != null)
                        {
                            joinRoomUI.onClickBtnCancel();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("joinRoomUI null: " + this);
                        }
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        JoinRoomUI joinRoomUI = this.findCallBack<JoinRoomUI>();
                        if (joinRoomUI != null)
                        {
                            isProcess = joinRoomUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("joinRoomUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region Refresh

    public Text tvId;

    public Text tvName;

    public Text tvPlayers;

    public Text tvState;

    public Text tvTime;

    public Text tvGameType;
    public Text tvContestManagerState;

    public Image imgPassword;

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Join Room");

    #region txt Info

    public Text tvCanJoinRoom;
    private static readonly TxtLanguage txtCannotJoinRoom = new TxtLanguage("Cannot Join");
    private static readonly TxtLanguage txtCanJoinRoom = new TxtLanguage("Can Join");

    private static readonly TxtLanguage txtId = new TxtLanguage("Id");
    private static readonly TxtLanguage txtName = new TxtLanguage("Name");
    private static readonly TxtLanguage txtAdmin = new TxtLanguage("Admin");
    private static readonly TxtLanguage txtUserCount = new TxtLanguage("user count");

    private static readonly TxtLanguage txtStateNormal = new TxtLanguage("Normal");
    private static readonly TxtLanguage txtStateFreeze = new TxtLanguage("Freeze");
    private static readonly TxtLanguage txtStateEnd = new TxtLanguage("End");

    private static readonly TxtLanguage txtCreated = new TxtLanguage("created");
    private static readonly TxtLanguage txtGameType = new TxtLanguage("Game");

    private static readonly TxtLanguage txtState = new TxtLanguage("State");

    #endregion

    public Text tvPasswordPlaceHolder;
    private static readonly TxtLanguage txtPasswordPlaceHolder = new TxtLanguage("Enter password...");

    public Text tvCancel;
    public static readonly TxtLanguage txtCancel = new TxtLanguage("Cancel");

    public static readonly TxtLanguage txtJoinRoom = new TxtLanguage("Join Room");
    public static readonly TxtLanguage txtCancelJoin = new TxtLanguage("Cancel Join");
    public static readonly TxtLanguage txtJoiningRoom = new TxtLanguage("Joining room...");
    public static readonly TxtLanguage txtCannotJoin = new TxtLanguage("Cannot Join");

    static JoinRoomUI()
    {
        txtTitle.add(Language.Type.vi, "Vào Phòng");

        // txtInfo
        {
            txtCannotJoinRoom.add(Language.Type.vi, "Không Thể Vào");
            txtCanJoinRoom.add(Language.Type.vi, "Có Thể Vào");

            txtId.add(Language.Type.vi, "Id");
            txtName.add(Language.Type.vi, "Tên");
            txtAdmin.add(Language.Type.vi, "Admin");
            txtUserCount.add(Language.Type.vi, "Số người dùng");
            txtStateNormal.add(Language.Type.vi, "Bình thường");
            txtStateFreeze.add(Language.Type.vi, "Đóng băng");
            txtStateEnd.add(Language.Type.vi, "Kết thúc");
            txtCreated.add(Language.Type.vi, "Tạo ra");
            txtGameType.add(Language.Type.vi, "Trò");
            txtState.add(Language.Type.vi, "Trạng thái");
        }
        txtPasswordPlaceHolder.add(Language.Type.vi, "Điền mật khẩu...");
        // btn
        {
            txtCancel.add(Language.Type.vi, "Huỷ Bỏ");

            txtJoinRoom.add(Language.Type.vi, "Vào Phòng");
            txtCancelJoin.add(Language.Type.vi, "Huỷ Vào Phòng");
            txtJoiningRoom.add(Language.Type.vi, "Đang vào phòng");
            txtCannotJoin.add(Language.Type.vi, "Không thể vào ");
        }
    }

    #endregion

    public Button btnJoin;
    public Text tvJoin;

    public InputField edtPassword;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                Room room = this.data.room.v.data;
                if (room != null)
                {
                    // join
                    {
                        bool isCanJoin = room.isCanJoinRoom(Server.getProfileUserId(room)) == Room.JoinRoomState.Can;
                        // Process
                        if (isCanJoin)
                        {
                            // Task
                            {
                                switch (this.data.requestState.v)
                                {
                                    case UIData.State.None:
                                        {
                                            destroyRoutine(wait);
                                        }
                                        break;
                                    case UIData.State.Request:
                                        {
                                            destroyRoutine(wait);
                                            // request
                                            if (Server.IsServerOnline(room))
                                            {
                                                {
                                                    uint profileId = Server.getProfileUserId(room);
                                                    if (room.isCanJoinRoom(profileId) == Room.JoinRoomState.Can)
                                                    {
                                                        string password = "";
                                                        {
                                                            if (edtPassword != null)
                                                            {
                                                                password = edtPassword.text;
                                                            }
                                                            else
                                                            {
                                                                Debug.LogError("edtPassword null");
                                                            }
                                                        }
                                                        room.requestJoinRoom(profileId, password);
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("Cannot join room: " + this);
                                                    }
                                                }
                                                this.data.requestState.v = UIData.State.Wait;
                                            }
                                            else
                                            {
                                                Debug.LogError("server not online: " + this);
                                            }
                                        }
                                        break;
                                    case UIData.State.Wait:
                                        {
                                            if (Server.IsServerOnline(room))
                                            {
                                                startRoutine(ref this.wait, TaskWait());
                                            }
                                            else
                                            {
                                                destroyRoutine(wait);
                                                this.data.requestState.v = UIData.State.None;
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown state: " + this.data.requestState.v + "; " + this);
                                        break;
                                }
                            }
                            // UI
                            {
                                if (btnJoin != null && tvJoin != null)
                                {
                                    switch (this.data.requestState.v)
                                    {
                                        case UIData.State.None:
                                            {
                                                btnJoin.interactable = true;
                                                tvJoin.text = txtJoinRoom.get();
                                            }
                                            break;
                                        case UIData.State.Request:
                                            {
                                                btnJoin.interactable = true;
                                                tvJoin.text = txtCancelJoin.get();
                                            }
                                            break;
                                        case UIData.State.Wait:
                                            {
                                                btnJoin.interactable = false;
                                                tvJoin.text = txtJoiningRoom.get();
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown state: " + this.data.requestState.v + "; " + this);
                                            break;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("btnJoin, tvJoin null: " + this);
                                }
                            }
                        }
                        else
                        {
                            // Task
                            {
                                this.data.requestState.v = UIData.State.None;
                                destroyRoutine(wait);
                            }
                            // UI
                            {
                                if (btnJoin != null && tvJoin != null)
                                {
                                    btnJoin.interactable = false;
                                    tvJoin.text = txtCannotJoin.get();
                                }
                                else
                                {
                                    Debug.LogError("btnJoin, tvJoin null: " + this);
                                }
                            }
                        }
                    }
                    // RoomInfo
                    {
                        GameType.Type gameType = GameType.Type.CHESS;
                        {
                            RoomInform roomInform = room.roomInform.v;
                            if (roomInform != null)
                            {
                                gameType = roomInform.gameType.v;
                            }
                            else
                            {
                                Debug.LogError("roomInform null: " + this);
                            }
                        }
                        // cannot join
                        {
                            if (tvCanJoinRoom != null)
                            {
                                if (room.isCanJoinRoom(Server.getProfileUserId(room)) != Room.JoinRoomState.Can)
                                {
                                    tvCanJoinRoom.text = txtCannotJoinRoom.get();
                                    tvCanJoinRoom.color = RoomHolder.CannotJoinColor;
                                }
                                else
                                {
                                    tvCanJoinRoom.text = txtCanJoinRoom.get();
                                    tvCanJoinRoom.color = RoomHolder.CanJoinColor;
                                }
                            }
                            else
                            {
                                Debug.LogError("tvCannotJoinRoom null: " + this);
                            }
                        }
                        // tvId
                        {
                            if (tvId != null)
                            {
                                tvId.text = txtId.get() + ": " + room.uid;
                            }
                            else
                            {
                                Debug.LogError("tvId null: " + this);
                            }
                        }
                        // name
                        {
                            if (tvName != null)
                            {
                                if (string.IsNullOrEmpty(room.name.v))
                                {
                                    tvName.text = GameType.GetStrGameType(gameType);
                                }
                                else
                                {
                                    tvName.text = room.name.v;
                                }
                            }
                            else
                            {
                                Debug.LogError("tvName null: " + this);
                            }
                        }
                        // players
                        {
                            if (tvPlayers != null)
                            {
                                // find
                                string strCreator = "";
                                uint userCount = 0;
                                // set
                                {
                                    RoomInform roomInform = room.roomInform.v;
                                    if (roomInform != null)
                                    {
                                        // creator
                                        {
                                            Human creator = roomInform.creator.v;
                                            if (creator != null)
                                            {
                                                strCreator = creator.getPlayerName();
                                            }
                                            else
                                            {
                                                Debug.LogError("creator null: " + this);
                                            }
                                        }
                                        userCount = roomInform.userCount.v;
                                    }
                                    else
                                    {
                                        Debug.LogError("roomInform null: " + this);
                                    }
                                }
                                tvPlayers.text = txtAdmin.get() + ": " + strCreator
                                + "; " + txtUserCount.get() + ": " + userCount;
                            }
                            else
                            {
                                Debug.LogError("tvPlayers null: " + this);
                            }
                        }
                        // state
                        {
                            if (tvState != null)
                            {
                                Room.State state = room.state.v;
                                if (state != null)
                                {
                                    switch (state.getType())
                                    {
                                        case Room.State.Type.Normal:
                                            {
                                                RoomStateNormal normal = state as RoomStateNormal;
                                                // state
                                                {
                                                    RoomStateNormal.State normalState = normal.state.v;
                                                    if (normalState != null)
                                                    {
                                                        switch (normalState.getType())
                                                        {
                                                            case RoomStateNormal.State.Type.Normal:
                                                                tvState.text = txtStateNormal.get();
                                                                break;
                                                            case RoomStateNormal.State.Type.Freeze:
                                                                tvState.text = txtStateFreeze.get();
                                                                break;
                                                            default:
                                                                Debug.LogError("unkown type: " + normalState.getType() + "; " + this);
                                                                break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("normalState null: " + this);
                                                    }
                                                }
                                            }
                                            break;
                                        case Room.State.Type.End:
                                            {
                                                tvState.text = txtStateEnd.get();
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                            break;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("state null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("tvState null: " + this);
                            }
                        }
                        // time
                        {
                            if (tvTime != null)
                            {
                                tvTime.text = txtCreated.get() + ": " + Global.getStrTime(room.timeCreated.v);
                            }
                            else
                            {
                                Debug.LogError("tvTime null: " + this);
                            }
                        }
                        // tvGameType
                        {
                            if (tvGameType != null)
                            {
                                // tvGameType.text = txtGameType.get ("GameType") + ": " + gameType;
                                tvGameType.text = GameType.GetStrGameType(gameType);
                            }
                            else
                            {
                                Debug.LogError("tvGameType null: " + this);
                            }
                        }
                        // tvContestManagerState
                        {
                            if (tvContestManagerState != null)
                            {
                                ContestManager.State.Type contestManagerState = ContestManager.State.Type.Lobby;
                                {
                                    RoomInform roomInform = room.roomInform.v;
                                    if (roomInform != null)
                                    {
                                        contestManagerState = roomInform.contestStateType.v;
                                    }
                                    else
                                    {
                                        Debug.LogError("roomInform null: " + this);
                                    }
                                }
                                tvContestManagerState.text = txtState.get() + ": " + contestManagerState;
                            }
                            else
                            {
                                Debug.LogError("tvContestManagerState null: " + this);
                            }
                        }
                        // imgPassword
                        {
                            if (imgPassword != null)
                            {
                                bool isHavePassword = false;
                                {
                                    RoomInform roomInform = room.roomInform.v;
                                    if (roomInform != null)
                                    {
                                        isHavePassword = roomInform.isHavePassword.v;
                                    }
                                    else
                                    {
                                        Debug.LogError("roomInform null: " + this);
                                    }
                                }
                                imgPassword.gameObject.SetActive(isHavePassword);
                            }
                            else
                            {
                                Debug.LogError("tvHavePassword null: " + this);
                            }
                        }
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get();
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                        if (tvPasswordPlaceHolder != null)
                        {
                            tvPasswordPlaceHolder.text = txtPasswordPlaceHolder.get();
                        }
                        else
                        {
                            Debug.LogError("edtPassword null");
                        }
                        if (tvCancel != null)
                        {
                            tvCancel.text = txtCancel.get();
                        }
                        else
                        {
                            Debug.LogError("tvCancel null: " + this);
                        }
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return false;
    }

    #endregion

    #region Task wait

    private Routine wait;

    public IEnumerator TaskWait()
    {
        if (this.data != null)
        {
            yield return new Wait(Global.WaitSendTime);
            if (this.data != null)
            {
                this.data.requestState.v = UIData.State.None;
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
            Toast.showMessage("request error");
            Debug.LogError("request error: " + this);
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    public override List<Routine> getRoutineList()
    {
        List<Routine> ret = new List<Routine>();
        {
            ret.Add(wait);
        }
        return ret;
    }

    #endregion

    #region implement callback

    private Server server = null;

    private RoomCheckChangeAdminChange<Room> roomCheckAdminChange = new RoomCheckChangeAdminChange<Room>();

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.room.allAddCallBack(this);
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
            if (data is Room)
            {
                Room room = data as Room;
                // Reset
                {
                    if (this.data != null)
                    {
                        this.data.reset();
                    }
                    else
                    {
                        Debug.LogError("data null: " + this);
                    }
                }
                // CheckChange
                {
                    roomCheckAdminChange.addCallBack(this);
                    roomCheckAdminChange.setData(room);
                }
                // Parent
                {
                    DataUtils.addParentCallBack(room, this, ref this.server);
                }
                // Child
                {
                    room.users.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // CheckChange
            if (data is RoomCheckChangeAdminChange<Room>)
            {
                dirty = true;
                return;
            }
            // Parent
            if (data is Server)
            {
                dirty = true;
                return;
            }
            // Child
            {
                if (data is RoomUser)
                {
                    RoomUser roomUser = data as RoomUser;
                    // Child
                    {
                        roomUser.inform.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is Human)
                    {
                        Human human = data as Human;
                        // Child
                        {
                            human.account.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is Account)
                    {
                        dirty = true;
                        return;
                    }
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
                uiData.room.allRemoveCallBack(this);
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
            if (data is Room)
            {
                Room room = data as Room;
                // CheckChange
                {
                    roomCheckAdminChange.removeCallBack(this);
                    roomCheckAdminChange.setData(null);
                }
                // Parent
                {
                    DataUtils.removeParentCallBack(room, this, ref this.server);
                }
                // Child
                {
                    room.users.allRemoveCallBack(this);
                }
                return;
            }
            // CheckChange
            if (data is RoomCheckChangeAdminChange<Room>)
            {
                return;
            }
            // Parent
            if (data is Server)
            {
                return;
            }
            // Child
            {
                if (data is RoomUser)
                {
                    RoomUser roomUser = data as RoomUser;
                    // Child
                    {
                        roomUser.inform.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is Human)
                    {
                        Human human = data as Human;
                        // Child
                        {
                            human.account.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is Account)
                    {
                        return;
                    }
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
                case UIData.Property.room:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.requestState:
                    dirty = true;
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
            // Room
            {
                if (wrapProperty.p is Room)
                {
                    switch ((Room.Property)wrapProperty.n)
                    {
                        case Room.Property.changeRights:
                            break;
                        case Room.Property.name:
                            dirty = true;
                            break;
                        case Room.Property.password:
                            break;
                        case Room.Property.users:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case Room.Property.state:
                            dirty = true;
                            break;
                        case Room.Property.contestManagers:
                            break;
                        case Room.Property.timeCreated:
                            dirty = true;
                            break;
                        case Room.Property.chatRoom:
                            break;
                        case Room.Property.allowHint:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // CheckChange
                if (wrapProperty.p is RoomCheckChangeAdminChange<Room>)
                {
                    dirty = true;
                    return;
                }
                // Parent
                if (wrapProperty.p is Server)
                {
                    Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is RoomUser)
                    {
                        switch ((RoomUser.Property)wrapProperty.n)
                        {
                            case RoomUser.Property.role:
                                dirty = true;
                                break;
                            case RoomUser.Property.inform:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case RoomUser.Property.state:
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
                        if (wrapProperty.p is Human)
                        {
                            switch ((Human.Property)wrapProperty.n)
                            {
                                case Human.Property.playerId:
                                    break;
                                case Human.Property.account:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
                                    break;
                                case Human.Property.state:
                                    break;
                                case Human.Property.email:
                                    break;
                                case Human.Property.phoneNumber:
                                    break;
                                case Human.Property.status:
                                    break;
                                case Human.Property.birthday:
                                    break;
                                case Human.Property.sex:
                                    break;
                                case Human.Property.connection:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // Child
                        if (wrapProperty.p is Account)
                        {
                            Account.OnUpdateSyncAccount(wrapProperty, this);
                            return;
                        }
                    }
                }
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnJoin()
    {
        if (this.data != null)
        {
            switch (this.data.requestState.v)
            {
                case UIData.State.None:
                    this.data.requestState.v = UIData.State.Request;
                    break;
                case UIData.State.Request:
                    this.data.requestState.v = UIData.State.None;
                    break;
                case UIData.State.Wait:
                    Debug.LogError("You are requesting");
                    break;
                default:
                    Debug.LogError("unknown request state: " + this.data.requestState.v);
                    break;
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
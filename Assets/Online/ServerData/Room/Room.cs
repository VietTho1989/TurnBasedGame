using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Rights;
using GameManager.Match;

public class Room : Data
{

    public VP<RoomInform> roomInform;

    #region Rights

    public VP<ChangeRights> changeRights;

    #endregion

    #region name

    public VP<string> name;

    public void requestChangeName(uint userId, string newName)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.changeName(userId, newName);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is RoomIdentity)
                    {
                        RoomIdentity roomIdentity = dataIdentity as RoomIdentity;
                        roomIdentity.requestChangeName(userId, newName);
                    }
                    else
                    {
                        Debug.LogError("Why isn't correct identity");
                    }
                }
                else
                {
                    Debug.LogError("cannot find dataIdentity");
                }
            }
        }
        else
        {
            Debug.LogError("You cannot request");
        }
        // Setting Default
        {
            Setting.get().defaultRoomName.v.setLast(newName);
        }
    }

    public void changeName(uint userId, string newName)
    {
        if (Room.IsCanEditSetting(this, userId))
        {
            this.name.v = newName;
        }
        else
        {
            Debug.LogError("cannot change name: " + userId + "; " + this);
        }
    }

    #endregion

    public VP<string> password;

    public static bool IsCanEditSetting(Data data, uint userId)
    {
        if (data != null)
        {
            Room room = data.findDataInParent<Room>();
            if (room != null)
            {
                RoomUser admin = Room.findAdmin(data);
                if (admin != null)
                {
                    Human human = admin.inform.v;
                    if (human != null)
                    {
                        if (human.playerId.v == userId)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        Debug.LogError("human null: " + data);
                    }
                }
                else
                {
                    Debug.LogError("admin null: " + data);
                }
            }
            else
            {
                Debug.LogError("room null: " + data);
                return true;
            }
        }
        else
        {
            Debug.LogError("data null");
        }
        return false;
    }

    #region User

    public RoomUserLP users;

    public static RoomUser findUser(uint userId, Data data)
    {
        Room room = data.findDataInParent<Room>();
        if (room != null)
        {
            return room.users.getInList(userId);
        }
        else
        {
            Debug.LogError("room null");
        }
        return null;
    }

    public static bool isUserAdmin(uint userId, Data data)
    {
        Room room = data.findDataInParent<Room>();
        if (room != null)
        {
            RoomUser roomUser = room.users.getInList(userId);
            if (roomUser != null && roomUser.isInsideRoom())
            {
                if (roomUser.role.v == RoomUser.Role.ADMIN)
                {
                    return true;
                }
            }
            else
            {
                Debug.LogError("Why cannot find your roomUser");
            }
        }
        else
        {
            Debug.LogError("room null");
        }
        return false;
    }

    public static bool isYouAdmin(Data data)
    {
        if (data != null)
        {
            Room room = data.findDataInParent<Room>();
            if (room != null)
            {
                Server server = data.findDataInParent<Server>();
                if (server != null)
                {
                    RoomUser roomUser = room.users.getInList(server.profileId.v);
                    if (roomUser != null && roomUser.isInsideRoom())
                    {
                        if (roomUser.role.v == RoomUser.Role.ADMIN)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        Debug.LogError("Why cannot find your roomUser");
                    }
                }
                else
                {
                    Debug.LogError("why server null");
                }
            }
            else
            {
                Debug.LogError("room null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
        return false;
    }

    public RoomUser findAdmin()
    {
        return this.users.vs.Find(user => user.role.v == RoomUser.Role.ADMIN);
    }

    public static RoomUser findAdmin(Data data)
    {
        if (data != null)
        {
            Room room = data.findDataInParent<Room>();
            if (room != null)
            {
                return room.findAdmin();
            }
            else
            {
                Debug.LogError("room null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
        return null;
    }

    public bool isHaveActiveUser()
    {
        foreach (RoomUser roomUser in this.users.vs)
        {
            if (roomUser.isInsideRoom())
            {
                return true;
            }
        }
        // Debug.LogError ("Don't have any active user: " + this);
        return false;
    }

    #endregion

    #region State

    public abstract class State : Data
    {

        public enum Type
        {
            Normal,
            End
        }

        public abstract Type getType();

    }

    public VP<State> state;

    public bool isActive()
    {
        switch (this.state.v.getType())
        {
            case Room.State.Type.Normal:
                return true;
            case Room.State.Type.End:
                return false;
            default:
                Debug.LogError("unknown room state: " + this.state.v.getType());
                return false; ;
        }
    }

    #endregion

    #region Contest Manager

    public VP<RequestNewContestManager> requestNewContestManager;

    public LP<ContestManager> contestManagers;

    #endregion

    public VP<long> timeCreated;

    #region ChatRoom

    public VP<ChatRoom> chatRoom;

    #endregion

    #region AllowHint

    public enum AllowHint
    {
        No,
        OnlyWatcher,
        Allow
    }

    #region txt

    private static readonly TxtLanguage txtAllowHintNo = new TxtLanguage("Not Allow");
    private static readonly TxtLanguage txtAllowHintOnlyWatcher = new TxtLanguage("Only Watcher");
    private static readonly TxtLanguage txtAllowHintAllow = new TxtLanguage("Allow");

    public static List<string> getAllowHintStr()
    {
        List<string> ret = new List<string>();
        {
            ret.Add(txtAllowHintNo.get());
            ret.Add(txtAllowHintOnlyWatcher.get());
            ret.Add(txtAllowHintAllow.get());
        }
        return ret;
    }

    #endregion

    public VP<AllowHint> allowHint;

    public void requestChangeAllowHint(uint userId, int newAllowHint)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.changeAllowHint(userId, newAllowHint);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is RoomIdentity)
                    {
                        RoomIdentity roomIdentity = dataIdentity as RoomIdentity;
                        roomIdentity.requestChangeAllowHint(userId, newAllowHint);
                    }
                    else
                    {
                        Debug.LogError("Why isn't correct identity");
                    }
                }
                else
                {
                    Debug.LogError("cannot find dataIdentity");
                }
            }
        }
        else
        {
            Debug.LogError("You cannot request");
        }
    }

    public void changeAllowHint(uint userId, int newAllowHint)
    {
        if (Room.IsCanEditSetting(this, userId))
        {
            this.allowHint.v = (AllowHint)newAllowHint;
        }
        else
        {
            Debug.LogError("cannot change name: " + userId + "; " + this);
        }
    }

    #endregion

    #region allowLoadHistory

    public VP<bool> allowLoadHistory;

    public void requestChangeAllowLoadHistory(uint userId, bool newAllowLoadHistory)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.changeAllowLoadHistory(userId, newAllowLoadHistory);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is RoomIdentity)
                    {
                        RoomIdentity roomIdentity = dataIdentity as RoomIdentity;
                        roomIdentity.requestChangeAllowLoadHistory(userId, newAllowLoadHistory);
                    }
                    else
                    {
                        Debug.LogError("Why isn't correct identity");
                    }
                }
                else
                {
                    Debug.LogError("cannot find dataIdentity");
                }
            }
        }
        else
        {
            Debug.LogError("You cannot request");
        }
    }

    public void changeAllowLoadHistory(uint userId, bool newAllowLoadHistory)
    {
        if (Room.IsCanEditSetting(this, userId))
        {
            this.allowLoadHistory.v = newAllowLoadHistory;
        }
        else
        {
            Debug.LogError("cannot change allowLoadHistory: " + userId + "; " + this);
        }
    }

    #endregion

    #region ChatInGame

    public enum ChatInGame
    {
        All,
        OnlyWatcher,
        OnlyPlayer,
        OnlyAdmin
    }

    #region txt

    private static readonly TxtLanguage txtChatInGameAll = new TxtLanguage("All");
    private static readonly TxtLanguage txtChatInGameOnlyWatcher = new TxtLanguage("Only Watcher");
    private static readonly TxtLanguage txtChatInGameOnlyPlayer = new TxtLanguage("Only Player");
    private static readonly TxtLanguage txtChatInGameOnlyAdmin = new TxtLanguage("Only Admin");

    public static List<string> getChatInGameStr()
    {
        List<string> ret = new List<string>();
        {
            ret.Add(txtChatInGameAll.get());
            ret.Add(txtChatInGameOnlyWatcher.get());
            ret.Add(txtChatInGameOnlyPlayer.get());
            ret.Add(txtChatInGameOnlyAdmin.get());
        }
        return ret;
    }

    #endregion

    public VP<ChatInGame> chatInGame;

    public void requestChangeChatInGame(uint userId, int newChatInGame)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.changeChatInGame(userId, newChatInGame);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is RoomIdentity)
                    {
                        RoomIdentity roomIdentity = dataIdentity as RoomIdentity;
                        roomIdentity.requestChangeChatInGame(userId, newChatInGame);
                    }
                    else
                    {
                        Debug.LogError("Why isn't correct identity");
                    }
                }
                else
                {
                    Debug.LogError("cannot find dataIdentity");
                }
            }
        }
        else
        {
            Debug.LogError("You cannot request");
        }
    }

    public void changeChatInGame(uint userId, int newChatInGame)
    {
        if (Room.IsCanEditSetting(this, userId))
        {
            this.chatInGame.v = (ChatInGame)newChatInGame;
        }
        else
        {
            Debug.LogError("cannot change chatInGame: " + userId + "; " + this);
        }
    }

    #endregion

    #region Constructor

    public enum Property
    {
        roomInform,
        changeRights,
        name,
        password,
        users,
        state,

        requestNewContestManager,
        contestManagers,

        timeCreated,
        chatRoom,
        allowHint,
        allowLoadHistory,
        chatInGame
    }

    public Room() : base()
    {
        this.roomInform = new VP<RoomInform>(this, (byte)Property.roomInform, new RoomInform());
        this.changeRights = new VP<ChangeRights>(this, (byte)Property.changeRights, new ChangeRights());
        this.name = new VP<string>(this, (byte)Property.name, "");
        this.password = new VP<string>(this, (byte)Property.password, "");
        this.users = new RoomUserLP(this, (byte)Property.users);
        this.state = new VP<State>(this, (byte)Property.state, new RoomStateNormal());

        this.requestNewContestManager = new VP<RequestNewContestManager>(this, (byte)Property.requestNewContestManager, new RequestNewContestManager());
        this.contestManagers = new LP<ContestManager>(this, (byte)Property.contestManagers);

        this.timeCreated = new VP<long>(this, (byte)Property.timeCreated, Constants.UNKNOWN_TIME);
        // chatRoom
        {
            ChatRoom chatRoom = new ChatRoom();
            {
                chatRoom.topic.v = new RoomTopic();
            }
            this.chatRoom = new VP<ChatRoom>(this, (byte)Property.chatRoom, chatRoom);
        }
        this.allowHint = new VP<AllowHint>(this, (byte)Property.allowHint, AllowHint.Allow);
        this.allowLoadHistory = new VP<bool>(this, (byte)Property.allowLoadHistory, true);
        this.chatInGame = new VP<ChatInGame>(this, (byte)Property.chatInGame, ChatInGame.All);
    }

    static Room()
    {
        // allowHint
        {
            txtAllowHintNo.add(Language.Type.vi, "Không Cho Phép");
            txtAllowHintOnlyWatcher.add(Language.Type.vi, "Cho Người Xem");
            txtAllowHintAllow.add(Language.Type.vi, "Được Phép");
        }
        // chatInGame
        {
            txtChatInGameAll.add(Language.Type.vi, "Tất Cả");
            txtChatInGameOnlyWatcher.add(Language.Type.vi, "Chỉ Người Xem");
            txtChatInGameOnlyPlayer.add(Language.Type.vi, "Chỉ Người Chơi");
            txtChatInGameOnlyAdmin.add(Language.Type.vi, "Chỉ Admin");
        }
    }

    #endregion

    #region join room

    public enum JoinRoomState
    {
        Can,
        RoomEnd,
        AlreadyInSideRoom,
        Ban,
        WrongPassword
    }

    public JoinRoomState isCanJoinRoom(uint userId)
    {
        if (this.isActive())
        {
            RoomUser roomUser = this.users.getInList(userId);
            if (roomUser != null && roomUser.state.v == RoomUser.State.NORMAL)
            {
                Debug.LogError("you already inside room: " + this);
                return JoinRoomState.AlreadyInSideRoom;
            }
            else
            {
                bool adminBanYou = false;
                {
                    RoomUser adminUser = this.findAdmin();
                    if (adminUser != null)
                    {
                        Server server = this.findDataInParent<Server>();
                        if (server != null)
                        {
                            FriendWorld friendWorld = server.friendWorld.v;
                            if (friendWorld != null)
                            {
                                Friend friend = friendWorld.friends.getInList(adminUser.inform.v.playerId.v, userId);
                                if (friend != null)
                                {
                                    if (friend.state.v != null && friend.state.v.getType() == Friend.State.Type.Ban)
                                    {
                                        adminBanYou = true;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("friend null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("friendWorld null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("server null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("adminUser null: " + this);
                    }
                }
                if (adminBanYou)
                {
                    return JoinRoomState.Ban;
                }
                else
                {
                    return JoinRoomState.Can;
                }
            }
        }
        else
        {
            Debug.LogError("room not active: " + this);
            return JoinRoomState.RoomEnd;
        }
    }

    public void requestJoinRoom(uint userId, string password)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.joinRoom(userId, password, null);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is RoomIdentity)
                    {
                        RoomIdentity roomIdentity = dataIdentity as RoomIdentity;
                        roomIdentity.requestJoinRoom(userId, password);
                    }
                    else
                    {
                        Debug.LogError("Why isn't correct identity");
                    }
                }
                else
                {
                    Debug.LogError("cannot find dataIdentity");
                }
            }
        }
        else
        {
            Debug.LogError("You cannot request");
        }
    }

    public void joinRoom(uint userId, string password, ClientConnectIdentity clientConnectIdentity)
    {
        JoinRoomState isCan = isCanJoinRoom(userId);
        if (isCan == JoinRoomState.Can)
        {
            if (string.IsNullOrEmpty(this.password.v) || this.password.v == password)
            {
                // Already inside room
                RoomUser oldRoomUser = this.users.getInList(userId);
                if (oldRoomUser == null)
                {
                    RoomUser roomUser = new RoomUser();
                    {
                        roomUser.uid = this.users.makeId();
                        roomUser.role.v = RoomUser.Role.NORMAL;
                        {
                            Human human = new Human();
                            {
                                human.playerId.v = userId;
                            }
                            roomUser.inform.v = human;
                        }
                        roomUser.state.v = RoomUser.State.NORMAL;
                    }
                    this.users.add(roomUser);
                }
                else
                {
                    Debug.LogError("already inside room: " + oldRoomUser);
                    switch (oldRoomUser.state.v)
                    {
                        case RoomUser.State.NORMAL:
                            Debug.LogError("already inside room");
                            break;
                        case RoomUser.State.LEFT:
                            oldRoomUser.state.v = RoomUser.State.NORMAL;
                            break;
                        case RoomUser.State.KICK:
                            Debug.LogError("You already kicked, cannot join this room");
                            break;
                        default:
                            Debug.LogError("unknown roomUser state: " + oldRoomUser.state.v);
                            break;
                    }
                }
                // Add join message
                {
                    // Find RoomTopic
                    RoomTopic roomTopic = null;
                    {
                        ChatRoom chatRoom = this.chatRoom.v;
                        if (chatRoom != null)
                        {
                            roomTopic = chatRoom.topic.v as RoomTopic;
                        }
                        else
                        {
                            Debug.LogError("chatRoom null: " + this);
                        }
                    }
                    if (roomTopic != null)
                    {
                        roomTopic.addRoomUserState(userId, ChatRoomUserStateContent.Action.Join);
                    }
                    else
                    {
                        Debug.LogError("roomTopic null: " + this);
                    }
                }
                // add to lobby
                {
                    if (this.contestManagers.vs.Count > 0)
                    {
                        ContestManager contestManager = this.contestManagers.vs[this.contestManagers.vs.Count - 1];
                        if (contestManager.state.v is ContestManagerStateLobby)
                        {
                            ContestManagerStateLobby contestManagerStateLobby = contestManager.state.v as ContestManagerStateLobby;
                            if (contestManagerStateLobby.state.v.getType() == ContestManagerStateLobby.State.Type.Normal)
                            {
                                bool alreadyAdd = false;
                                foreach (LobbyTeam lobbyTeam in contestManagerStateLobby.teams.vs)
                                {
                                    // find empty player
                                    foreach (LobbyPlayer lobbyPlayer in lobbyTeam.players.vs)
                                    {
                                        if (lobbyPlayer.inform.v.getType() == GamePlayer.Inform.Type.None)
                                        {
                                            Human human = new Human();
                                            {
                                                human.uid = lobbyPlayer.inform.makeId();
                                                human.playerId.v = userId;
                                            }
                                            lobbyPlayer.inform.v = human;
                                            alreadyAdd = true;
                                            break;
                                        }
                                    }
                                    // check already add
                                    if (alreadyAdd)
                                    {
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                // already start, not add
                            }
                        }
                        else
                        {
                            // not lobby, already play, not add
                        }
                    }
                }
            }
            else
            {
                Debug.LogError("Not correct password");
                if (clientConnectIdentity != null)
                {
                    clientConnectIdentity.TargetJoinRoomError(clientConnectIdentity.connectionToClient, JoinRoomState.WrongPassword);
                }
                else
                {
                    Debug.LogError("password error: " + this);
                }
            }
        }
        else
        {
            Debug.LogError("Cannot join room: " + this);
            if (clientConnectIdentity != null)
            {
                clientConnectIdentity.TargetJoinRoomError(clientConnectIdentity.connectionToClient, isCan);
            }
            else
            {
                Debug.LogError("join room error: " + isCan + "; " + this);
            }
        }
    }

    #endregion

    #region end room

    public bool isCanEndRoom(uint userId)
    {
        bool isCanEnd = false;
        {
            // check is admin
            bool isServerAdmin = false;
            {
                Server server = this.findDataInParent<Server>();
                if (server != null)
                {
                    User user = server.users.getInList(userId);
                    if (user != null)
                    {
                        if (user.role.v == User.Role.Admin)
                        {
                            isServerAdmin = true;
                        }
                    }
                    else
                    {
                        Debug.LogError("user null");
                    }
                }
                else
                {
                    Debug.LogError("server null");
                }
            }
            // check room not end
            if (isServerAdmin)
            {
                if (this.state.v.getType() != State.Type.End)
                {
                    isCanEnd = true;
                }
            }
        }
        return isCanEnd;
    }

    public void requestEndRoom(uint userId)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.endRoom(userId);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is RoomIdentity)
                    {
                        RoomIdentity roomIdentity = dataIdentity as RoomIdentity;
                        roomIdentity.requestEndRoom(userId);
                    }
                    else
                    {
                        Debug.LogError("Why isn't correct identity");
                    }
                }
                else
                {
                    Debug.LogError("cannot find dataIdentity");
                }
            }
        }
        else
        {
            Debug.LogError("You cannot request");
        }
    }

    public void endRoom(uint userId)
    {
        if (isCanEndRoom(userId))
        {
            RoomStateEnd end = new RoomStateEnd();
            {
                end.uid = this.state.makeId();
            }
            this.state.v = end;
        }
        else
        {
            Debug.LogError("Cannot end room: " + userId);
        }
    }

    #endregion

}
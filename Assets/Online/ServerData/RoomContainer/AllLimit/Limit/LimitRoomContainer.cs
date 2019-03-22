using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

public class LimitRoomContainer : RoomContainer
{

    #region user

    public const int DefaultUserCount = 225;

    public VP<int> maxUserCount;

    public VP<int> userCount;

    public LP<Human> users;

    #endregion

    public LP<GameType.Type> gameTypes;

    #region rooms

    public LP<Room> rooms;

    #endregion

    #region Constructor

    public enum Property
    {
        maxUserCount,
        userCount,
        users,
        gameTypes,
        rooms
    }

    public LimitRoomContainer() : base()
    {
        this.maxUserCount = new VP<int>(this, (byte)Property.maxUserCount, DefaultUserCount);
        this.userCount = new VP<int>(this, (byte)Property.userCount, 0);
        this.users = new LP<Human>(this, (byte)Property.users);
        this.gameTypes = new LP<GameType.Type>(this, (byte)Property.gameTypes);
        this.rooms = new LP<Room>(this, (byte)Property.rooms);
    }

    #endregion

    public override Type getType()
    {
        return Type.Limit;
    }

    public override List<GameType.Type> getGameTypes()
    {
        if (this.gameTypes.vs.Count == 0)
        {
            List<GameType.Type> gameTypes = new List<GameType.Type>();
            {
                foreach (GameType.Type gameType in GameType.EnableTypes)
                {
                    gameTypes.Add(gameType);
                }
            }
            return gameTypes;
        }
        else
        {
            return this.gameTypes.vs;
        }
    }

    #region makeRoom

    public void requestMakeRoom(uint userId, CreateRoomMessage makeRoom)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.makeRoom(userId, makeRoom);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is LimitRoomContainerIdentity)
                    {
                        LimitRoomContainerIdentity limitRoomContainerIdentity = dataIdentity as LimitRoomContainerIdentity;
                        limitRoomContainerIdentity.requestMakeRoom(userId, makeRoom);
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
            // Debug.LogError ("You cannot request");
        }
        // DefaultChosenGame
        Setting.get().defaultChosenGame.v.setLast(makeRoom.gameType);
    }

    public void makeRoom(uint userId, CreateRoomMessage makeRoom)
    {
        bool check = true;
        // Check already in a room
        {
            foreach (Room room in this.rooms.vs)
            {
                if (room.state.v is RoomStateNormal)
                {
                    RoomUser roomUser = room.users.getInList(userId);
                    if (roomUser != null && roomUser.isInsideRoom())
                    {
                        // Debug.LogError ("already inside this room: " + roomUser + ", " + room);
                        check = false;
                    }
                }
            }
        }
        if (check)
        {
            Room room = new Room();
            {
                room.uid = this.rooms.makeId();
                // roomInform
                {
                    room.roomInform.v.creator.v.playerId.v = userId;
                }
                room.name.v = makeRoom.roomName;
                room.password.v = makeRoom.password;
                // State
                {
                    // TODO Can hoan thien
                }
                // Time
                room.timeCreated.v = Global.getRealTimeInMiliSeconds();
                // Add RoomUser
                {
                    RoomUser roomUser = new RoomUser();
                    {
                        roomUser.uid = room.users.makeId();
                        roomUser.role.v = RoomUser.Role.ADMIN;
                        // Information
                        {
                            Human human = new Human();
                            {
                                human.playerId.v = userId;
                            }
                            roomUser.inform.v = human;
                        }
                    }
                    room.users.add(roomUser);
                }
                // allowHint
                {
                    Server server = this.findDataInParent<Server>();
                    if (server != null)
                    {
                        if (server.type.v == Server.Type.Offline)
                        {
                            room.allowHint.v = Room.AllowHint.Allow;
                        }
                        else
                        {
                            room.allowHint.v = Room.AllowHint.OnlyWatcher;
                        }
                    }
                    else
                    {
                        Debug.LogError("server null");
                    }
                }
                // add create room message
                {
                    // find roomTopic
                    RoomTopic roomTopic = null;
                    {
                        ChatRoom chatRoom = room.chatRoom.v;
                        if (chatRoom != null)
                        {
                            roomTopic = chatRoom.topic.v as RoomTopic;
                        }
                        else
                        {
                            Debug.LogError("chatRoom null: " + this);
                        }
                    }
                    // Add message
                    roomTopic.addRoomUserState(userId, ChatRoomUserStateContent.Action.Create);
                }
                // contestManager
                {
                    ContestManager contestManager = new ContestManager();
                    {
                        contestManager.uid = room.contestManagers.makeId();
                        // Add admin to lobby
                        {
                            ContestManagerStateLobby lobby = contestManager.state.v as ContestManagerStateLobby;
                            if (lobby != null)
                            {
                                // Make Team
                                {
                                    LobbyTeam lobbyTeam = new LobbyTeam();
                                    {
                                        lobbyTeam.uid = lobby.teams.makeId();
                                        lobbyTeam.teamIndex.v = 0;
                                        // players
                                        {
                                            LobbyPlayer lobbyPlayer = new LobbyPlayer();
                                            {
                                                lobbyPlayer.uid = lobbyTeam.players.makeId();
                                                lobbyPlayer.playerIndex.v = 0;
                                                // inform
                                                {
                                                    Human human = new Human();
                                                    {
                                                        human.uid = lobbyPlayer.inform.makeId();
                                                        human.playerId.v = userId;
                                                    }
                                                    lobbyPlayer.inform.v = human;
                                                }
                                                lobbyPlayer.isReady.v = false;
                                            }
                                            lobbyTeam.players.add(lobbyPlayer);
                                        }
                                    }
                                    lobby.teams.add(lobbyTeam);
                                }
                                //gameType
                                {
                                    // find defaultGameDataFactory
                                    DefaultGameDataFactory defaultGameDataFactory = null;
                                    {
                                        // get singleContestFactory
                                        ContestManagerContentFactory contentManagerFactory = lobby.contentFactory.v;
                                        if (contentManagerFactory is SingleContestFactory)
                                        {
                                            SingleContestFactory singleContestFactory = contentManagerFactory as SingleContestFactory;
                                            // get normal round factory
                                            if (singleContestFactory.roundFactory.v is NormalRoundFactory)
                                            {
                                                NormalRoundFactory normalRoundFactory = singleContestFactory.roundFactory.v as NormalRoundFactory;
                                                // get gameFactory
                                                GameFactory gameFactory = normalRoundFactory.gameFactory.v;
                                                if (gameFactory != null)
                                                {
                                                    defaultGameDataFactory = gameFactory.gameDataFactory.v as DefaultGameDataFactory;
                                                }
                                                else
                                                {
                                                    Debug.LogError("gameFactory null: " + this);
                                                }
                                            }
                                        }
                                    }
                                    // Process
                                    if (defaultGameDataFactory != null)
                                    {
                                        defaultGameDataFactory.makeNewDefaultGameType(makeRoom.gameType);
                                    }
                                    else
                                    {
                                        Debug.LogError("defaultGameDataFactory null: " + this);
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("why lobby null: " + this);
                            }
                        }
                    }
                    room.contestManagers.add(contestManager);
                }
            }
            this.rooms.add(room);
        }
        else
        {
            // Debug.Log ("You cannot make room");
            // TODO Can hoan thien
            // string replyMessage = "You cannot make room, you have already been in a room";
            // TargetSendMessage(connectionToClient, replyMessage);
        }
    }

    #endregion

    #region join

    public void requestJoin(uint userId)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.join(userId);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is LimitRoomContainerIdentity)
                    {
                        LimitRoomContainerIdentity limitRoomContainerIdentity = dataIdentity as LimitRoomContainerIdentity;
                        limitRoomContainerIdentity.requestJoin(userId);
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
            // Debug.LogError ("You cannot request");
        }
    }

    public bool isCanJoin(uint userId)
    {
        bool alreadyIn = false;
        {
            if (this.users.vs.Count < this.maxUserCount.v)
            {
                foreach (Human human in this.users.vs)
                {
                    if (human.playerId.v == userId)
                    {
                        alreadyIn = true;
                        break;
                    }
                }
            }
            else
            {
                Debug.LogError("too many people in limitRoomContainer: " + this.users.vs.Count + ", " + this.maxUserCount.v);
            }
        }
        return !alreadyIn;
    }

    public void join(uint userId)
    {
        if (isCanJoin(userId))
        {
            Human human = new Human();
            {
                human.uid = this.users.makeId();
                human.playerId.v = userId;
            }
            this.users.add(human);
        }
        else
        {
            Debug.LogError("cannot join userId: " + userId);
        }
    }

    #endregion

    #region leave

    public void requestLeave(uint userId)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.leave(userId);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is LimitRoomContainerIdentity)
                    {
                        LimitRoomContainerIdentity limitRoomContainerIdentity = dataIdentity as LimitRoomContainerIdentity;
                        limitRoomContainerIdentity.requestLeave(userId);
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
            // Debug.LogError ("You cannot request");
        }
    }

    public bool isCanLeave(uint userId)
    {
        bool alreadyIn = false;
        {
            foreach (Human human in this.users.vs)
            {
                if (human.playerId.v == userId)
                {
                    alreadyIn = true;
                    break;
                }
            }
        }
        return alreadyIn;
    }

    public void leave(uint userId)
    {
        if (isCanLeave(userId))
        {
            foreach (Human human in this.users.vs)
            {
                if (human.playerId.v == userId)
                {
                    this.users.remove(human);
                    break;
                }
            }
        }
        else
        {
            Debug.LogError("cannot lave userId: " + userId);
        }
    }

    #endregion

}
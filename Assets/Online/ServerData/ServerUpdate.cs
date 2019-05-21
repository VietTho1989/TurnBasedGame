using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ServerUpdate : UpdateBehavior<Server>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // gameTypes
                {
                    if (this.data.gameTypes.vs.Count == 0)
                    {
                        // find
                        List<int> gameTypes = new List<int>();
                        {
                            foreach(GameType.Type gameType in GameType.EnableTypes)
                            {
                                gameTypes.Add((int)gameType);
                            }
                        }
                        // add
                        this.data.gameTypes.add(gameTypes);
                    }
                }
                // fastStart
                {
                    if (Setting.get().fastStart.v)
                    {
                        this.data.alreadyFastStart = true;
                        RoomManager roomManager = this.data.roomManager.v;
                        if (roomManager != null)
                        {
                            GlobalRoomContainer globalRoomContainer = roomManager.globalRoomContainer.v;
                            if (globalRoomContainer != null)
                            {
                                if (globalRoomContainer.rooms.vs.Count == 0)
                                {
                                    // fast start request make room
                                    CreateRoomMessage createRoomMessage = new CreateRoomMessage();
                                    {
                                        createRoomMessage.gameType = Setting.get().defaultChosenGame.v.getGame();
                                        createRoomMessage.roomName = Setting.get().defaultRoomName.v.getRoomName();
                                    }
                                    globalRoomContainer.requestMakeRoom(this.data.profileId.v, createRoomMessage);
                                    // fast start room
                                    Debug.LogError("ServerUpdate: fast start: " + globalRoomContainer.rooms.vs.Count);
                                    if (globalRoomContainer.rooms.vs.Count == 1)
                                    {
                                        Room room = globalRoomContainer.rooms.vs[0];
                                        room.isFastStartRoom = true;
                                        RoomUpdate roomUpdate = room.findCallBack<RoomUpdate>();
                                        if (roomUpdate != null)
                                        {
                                            roomUpdate.makeDirty();
                                        }
                                        else
                                        {
                                            Debug.LogError("roomUpdate null");
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("why room count not 1: " + globalRoomContainer.rooms.vs.Count);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("why room count not 0: " + globalRoomContainer.rooms.vs.Count);
                                }
                            }
                            else
                            {
                                Debug.LogError("globalRoomContainer null");
                            }
                        }
                        else
                        {
                            Debug.LogError("roomManager null");
                        }
                    }
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

    #region implement callBack

    public override void onAddCallBack<T>(T data)
    {
        if (data is Server)
        {
            Server server = data as Server;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                server.users.allAddCallBack(this);
                server.roomManager.allAddCallBack(this);
                server.globalChat.allAddCallBack(this);
                server.friendWorld.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Setting
        if(data is Setting)
        {
            dirty = true;
            return;
        }
        // Child
        {
            if (data is User)
            {
                User user = data as User;
                // Update
                {
                    UpdateUtils.makeUpdate<UserUpdate, User>(user, this.transform);
                }
                return;
            }
            if (data is RoomManager)
            {
                RoomManager roomManager = data as RoomManager;
                // Update
                {
                    UpdateUtils.makeUpdate<RoomManagerUpdate, RoomManager>(roomManager, this.transform);
                }
                return;
            }
            if (data is GlobalChat)
            {
                GlobalChat globalChat = data as GlobalChat;
                // Update
                {
                    UpdateUtils.makeUpdate<GlobalChatUpdate, GlobalChat>(globalChat, this.transform);
                }
                return;
            }
            if (data is FriendWorld)
            {
                FriendWorld friendWorld = data as FriendWorld;
                // Update
                {
                    UpdateUtils.makeUpdate<FriendWorldUpdate, FriendWorld>(friendWorld, this.transform);
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is Server)
        {
            Server server = data as Server;
            // Setting
            Setting.get().removeCallBack(this);
            // Child
            {
                server.users.allRemoveCallBack(this);
                server.roomManager.allRemoveCallBack(this);
                server.globalChat.allRemoveCallBack(this);
                server.friendWorld.allRemoveCallBack(this);
            }
            this.setDataNull(server);
            return;
        }
        // Setting
        if(data is Setting)
        {
            return;
        }
        // Child
        {
            if (data is User)
            {
                User user = data as User;
                // Update
                {
                    user.removeCallBackAndDestroy(typeof(UserUpdate));
                }
                return;
            }
            if (data is RoomManager)
            {
                RoomManager roomManager = data as RoomManager;
                // Update
                {
                    roomManager.removeCallBackAndDestroy(typeof(RoomManagerUpdate));
                }
                return;
            }
            if (data is GlobalChat)
            {
                GlobalChat globalChat = data as GlobalChat;
                // Update
                {
                    globalChat.removeCallBackAndDestroy(typeof(GlobalChatUpdate));
                }
                return;
            }
            if (data is FriendWorld)
            {
                FriendWorld friendWorld = data as FriendWorld;
                // Update
                {
                    friendWorld.removeCallBackAndDestroy(typeof(FriendWorldUpdate));
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
        if (wrapProperty.p is Server)
        {
            switch ((Server.Property)wrapProperty.n)
            {
                case Server.Property.serverConfig:
                    break;
                case Server.Property.instanceId:
                    break;
                case Server.Property.gameTypes:
                    dirty = true;
                    break;
                case Server.Property.startState:
                    break;
                case Server.Property.type:
                    break;
                case Server.Property.profile:
                    break;
                case Server.Property.state:
                    break;
                case Server.Property.users:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                    }
                    break;
                case Server.Property.disconnectTime:
                    break;
                case Server.Property.roomManager:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                    }
                    break;
                case Server.Property.globalChat:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                    }
                    break;
                case Server.Property.friendWorld:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Setting
        if(wrapProperty.p is Setting)
        {
            switch ((Setting.Property)wrapProperty.n)
            {
                case Setting.Property.fastStart:
                    dirty = true;
                    break;
                case Setting.Property.language:
                    break;
                case Setting.Property.useShortKey:
                    break;
                case Setting.Property.style:
                    break;
                case Setting.Property.contentTextSize:
                    break;
                case Setting.Property.titleTextSize:
                    break;
                case Setting.Property.labelTextSize:
                    break;
                case Setting.Property.buttonSize:
                    break;
                case Setting.Property.itemSize:
                    break;
                case Setting.Property.confirmQuit:
                    break;
                case Setting.Property.boardIndex:
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
                case Setting.Property.screenCaptureSetting:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            if (wrapProperty.p is User)
            {
                return;
            }
            if (wrapProperty.p is RoomManager)
            {
                return;
            }
            if (wrapProperty.p is GlobalChat)
            {
                return;
            }
            if (wrapProperty.p is FriendWorld)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}
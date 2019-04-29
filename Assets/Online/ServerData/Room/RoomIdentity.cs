using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618

/**
 * RoomIdentity ai cung thay duoc, co le neu co password se ko thay
 * */
public class RoomIdentity : DataIdentity
{

    #region SyncVar

    #region roomName

    [SyncVar(hook = "onChangeRoomName")]
    public string roomName;

    private void onChangeRoomName(string newRoomName)
    {
        this.roomName = newRoomName;
        // Debug.Log ("changeRoomName: " + newRoomName);
        if (this.netData.clientData != null)
        {
            this.netData.clientData.name.v = newRoomName;
        }
    }

    #endregion

    #region password

    [SyncVar(hook = "onChangePassword")]
    public string password;

    private void onChangePassword(string newPassword)
    {
        this.password = newPassword;
        // Debug.Log ("changePassword: " + newPassword);
        if (this.netData.clientData != null)
        {
            this.netData.clientData.password.v = newPassword;
        }
    }

    #endregion

    #region contestManagers

    [SyncVar]
    public int contestManagers;

    #endregion

    #region timeCreated

    [SyncVar(hook = "onChangeTimeCreated")]
    public long timeCreated;

    private void onChangeTimeCreated(long newTimeCreated)
    {
        this.timeCreated = newTimeCreated;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.timeCreated.v = newTimeCreated;
        }
    }

    #endregion

    #region allowHint

    [SyncVar(hook = "onChangeAllowHint")]
    public Room.AllowHint allowHint;

    private void onChangeAllowHint(Room.AllowHint newAllowHint)
    {
        this.allowHint = newAllowHint;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.allowHint.v = newAllowHint;
        }
    }

    #endregion

    #endregion

    #region allowLoadHistory

    [SyncVar(hook = "onChangeAllowLoadHistory")]
    public bool allowLoadHistory;

    private void onChangeAllowLoadHistory(bool newAllowLoadHistory)
    {
        this.allowLoadHistory = newAllowLoadHistory;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.allowLoadHistory.v = newAllowLoadHistory;
        }
    }

    #endregion

    #region chatInGame

    [SyncVar(hook = "onChangeChatInGame")]
    public Room.ChatInGame chatInGame;

    private void onChangeChatInGame(Room.ChatInGame newChatInGame)
    {
        this.chatInGame = newChatInGame;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.chatInGame.v = newChatInGame;
        }
    }

    #endregion

    #region NetData

    private NetData<Room> netData = new NetData<Room>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            this.onChangeRoomName(this.roomName);
            this.onChangePassword(this.password);
            this.onChangeTimeCreated(this.timeCreated);
            this.onChangeAllowHint(this.allowHint);
            this.onChangeAllowLoadHistory(this.allowLoadHistory);
            this.onChangeChatInGame(this.chatInGame);
        }
        else
        {
            Debug.LogError("clientData null: " + this);
        }
    }

    public override int refreshDataSize()
    {
        int ret = GetDataSize(this.netId);
        {
            ret += GetDataSize(this.roomName);
            ret += GetDataSize(this.password);
            ret += GetDataSize(this.timeCreated);
            ret += GetDataSize(this.allowHint);
            ret += GetDataSize(this.allowLoadHistory);
            ret += GetDataSize(this.chatInGame);
        }
        return ret;
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if (data is Room)
        {
            Room room = data as Room;
            // Set new parent
            this.addTransformToParent();
            // Set value for synchronize
            {
                this.serialize(this.searchInfor, room.makeSearchInforms());
                this.roomName = room.name.v;
                this.password = "";
                this.contestManagers = room.contestManagers.vs.Count;
                this.timeCreated = room.timeCreated.v;
                this.allowHint = room.allowHint.v;
                this.allowLoadHistory = room.allowLoadHistory.v;
                this.chatInGame = room.chatInGame.v;
            }
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    if (room.getDataParent() is LimitRoomContainer)
                    {
                        observer.checkChange = new LimitRoomContainerObserver(observer);
                        observer.setCheckChangeData(room.getDataParent() as LimitRoomContainer);
                    }
                    else
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(room);
                    }
                }
                else
                {
                    Debug.LogError("observer null");
                }
            }
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is Room)
        {
            // Room room = data as Room;
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.setCheckChangeData(null);
                }
                else
                {
                    Debug.LogError("observer null");
                }
            }
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if (wrapProperty.p is Room)
        {
            switch ((Room.Property)wrapProperty.n)
            {
                case Room.Property.name:
                    this.roomName = (string)wrapProperty.getValue();
                    break;
                case Room.Property.password:
                    this.password = "";// luon de nhu vay
                    break;
                case Room.Property.users:
                    break;
                case Room.Property.state:
                    break;
                case Room.Property.contestManagers:
                    {
                        Room room = wrapProperty.p as Room;
                        this.contestManagers = room.contestManagers.vs.Count;
                    }
                    break;
                case Room.Property.timeCreated:
                    this.timeCreated = (long)wrapProperty.getValue();
                    break;
                case Room.Property.chatRoom:
                    break;
                case Room.Property.allowHint:
                    this.allowHint = (Room.AllowHint)wrapProperty.getValue();
                    break;
                case Room.Property.allowLoadHistory:
                    this.allowLoadHistory = (bool)wrapProperty.getValue();
                    break;
                case Room.Property.chatInGame:
                    this.chatInGame = (Room.ChatInGame)wrapProperty.getValue();
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    #region joinRoom

    public void requestJoinRoom(uint userId, string password)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdRoomJoinRoom(this.netId, userId, password);
        }
        else
        {
            Debug.LogError("Cannot find userIdentity: " + this);
        }
    }

    public void joinRoom(uint userId, string password, ClientConnectIdentity clientConnectIdentity)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.joinRoom(userId, password, clientConnectIdentity);
        }
        else
        {
            Debug.LogError("serverData null");
        }
    }

    #endregion

    #region endRoom

    public void requestEndRoom(uint userId)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdRoomEndRoom(this.netId, userId);
        }
        else
        {
            Debug.LogError("Cannot find userIdentity: " + this);
        }
    }

    public void endRoom(uint userId)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.endRoom(userId);
        }
        else
        {
            Debug.LogError("serverData null");
        }
    }

    #endregion

    #region name

    public void requestChangeName(uint userId, string newName)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdRoomChangeName(this.netId, userId, newName);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void changeName(uint userId, string newName)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.changeName(userId, newName);
        }
        else
        {
            Debug.LogError("serverData null: " + this);
        }
    }

    #endregion

    #region allowHint

    public void requestChangeAllowHint(uint userId, int newAllowHint)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdRoomChangeAllowHint(this.netId, userId, newAllowHint);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void changeAllowHint(uint userId, int newAllowHint)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.changeAllowHint(userId, newAllowHint);
        }
        else
        {
            Debug.LogError("serverData null: " + this);
        }
    }

    #endregion

    #region allowLoadHistory

    public void requestChangeAllowLoadHistory(uint userId, bool newAllowLoadHistory)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdRoomChangeAllowLoadHistory(this.netId, userId, newAllowLoadHistory);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void changeAllowLoadHistory(uint userId, bool newAllowLoadHistory)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.changeAllowLoadHistory(userId, newAllowLoadHistory);
        }
        else
        {
            Debug.LogError("serverData null: " + this);
        }
    }

    #endregion

    #region chatInGame

    public void requestChangeChatInGame(uint userId, int newChatInGame)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdRoomChangeChatInGame(this.netId, userId, newChatInGame);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void changeChatInGame(uint userId, int newChatInGame)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.changeChatInGame(userId, newChatInGame);
        }
        else
        {
            Debug.LogError("serverData null: " + this);
        }
    }

    #endregion

}
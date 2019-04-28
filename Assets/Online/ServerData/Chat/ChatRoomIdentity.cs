using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

public class ChatRoomIdentity : DataIdentity
{

    #region messageCount

    [SyncVar(hook = "onChangeMessageCount")]
    public uint messageCount;

    public void onChangeMessageCount(uint newMessageCount)
    {
        this.messageCount = newMessageCount;
    }

    #endregion

    #region editMax

    [SyncVar(hook = "onChangeEditMax")]
    public uint editMax;

    public void onChangeEditMax(uint newEditMax)
    {
        this.editMax = newEditMax;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.editMax.v = newEditMax;
        }
        else
        {
            // Debug.LogError ("clientData null");
        }
    }

    #endregion

    #region maxId

    [SyncVar(hook = "onChangeMaxId")]
    public uint maxId;

    public void onChangeMaxId(uint newMaxId)
    {
        this.maxId = newMaxId;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.maxId.v = newMaxId;
        }
        else
        {
            // Debug.Log ("clientData null");
        }
    }

    #endregion

    #region isEnable

    [SyncVar(hook = "onChangeIsEnable")]
    public bool isEnable;

    public void onChangeIsEnable(bool newIsEnable)
    {
        this.isEnable = newIsEnable;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.isEnable.v = newIsEnable;
        }
        else
        {
            // Debug.Log ("clientData null");
        }
    }

    #endregion

    #region NetData

    public NetData<ChatRoom> netData = new NetData<ChatRoom>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            this.onChangeIsEnable(this.isEnable);
            this.onChangeEditMax(this.editMax);
            this.onChangeMaxId(this.maxId);
        }
        else
        {
            // Debug.LogError ("clientData null");
        }
    }

    public override int refreshDataSize()
    {
        int ret = GetDataSize(this.netId);
        {
            ret += GetDataSize(this.isEnable);
            ret += GetDataSize(this.messageCount);
            ret += GetDataSize(this.editMax);
            ret += GetDataSize(this.maxId);
        }
        return ret;
    }

    #endregion

    #region implement callBack

    public override void onAddCallBack<T>(T data)
    {
        if (data is ChatRoom)
        {
            ChatRoom chatRoom = data as ChatRoom;
            // Parent
            this.addTransformToParent();
            // Set Property
            {
                this.serialize(this.searchInfor, chatRoom.makeSearchInforms());
                this.isEnable = chatRoom.isEnable.v;
                this.messageCount = (uint)chatRoom.messages.vs.Count;
                this.editMax = chatRoom.editMax.v;
                this.maxId = chatRoom.maxId.v;
            }
            this.getDataSize();
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    // Find room parent
                    Room room = chatRoom.getDataParent() as Room;
                    // Process
                    if (room == null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(chatRoom);
                    }
                    else
                    {
                        observer.checkChange = new OnlyRoomPlayerObserver(observer);
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
        // Hero
        if (data is ChatRoom)
        {
            //ChatRoom chatRoom = data as ChatRoom;
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange.setData(null);
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
        if (wrapProperty.p is ChatRoom)
        {
            switch ((ChatRoom.Property)wrapProperty.n)
            {
                case ChatRoom.Property.topic:
                    break;
                case ChatRoom.Property.isEnable:
                    this.isEnable = (bool)wrapProperty.getValue();
                    break;
                case ChatRoom.Property.players:
                    break;
                case ChatRoom.Property.messages:
                    {
                        ChatRoom chatRoom = wrapProperty.p as ChatRoom;
                        this.messageCount = (uint)chatRoom.messages.vs.Count;
                    }
                    break;
                case ChatRoom.Property.editMax:
                    this.editMax = (uint)wrapProperty.getValue();
                    break;
                case ChatRoom.Property.maxId:
                    this.maxId = (uint)wrapProperty.getValue();
                    break;
                case ChatRoom.Property.chatViewers:
                    break;
                case ChatRoom.Property.typing:
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

    #region loadMore

    public void requestLoadMore(uint userId, uint loadMoreCount)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdChatRoomLoadMore(this.netId, userId, loadMoreCount);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void loadMore(uint userId, uint loadMoreCount)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.loadMore(userId, loadMoreCount);
        }
        else
        {
            Debug.LogError("serverData null");
        }
    }

    #endregion

    #region Send normal message

    public void requestSendNormalMessage(uint userId, string message)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdChatRoomSendNormalMessage(this.netId, userId, message);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void sendNormalMessage(uint userId, string message)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.sendNormalMessage(userId, message);
        }
        else
        {
            Debug.LogError("serverData null");
        }
    }

    #endregion

}
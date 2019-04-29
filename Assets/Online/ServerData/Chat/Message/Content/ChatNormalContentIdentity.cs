using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618

[NetworkSettings(channel = DataIdentity.ChatChanel)]
public class ChatNormalContentIdentity : DataIdentity
{

    #region SyncVar

    #region owner

    [SyncVar(hook = "onChangeOwner")]
    public uint owner;

    public void onChangeOwner(uint newOwner)
    {
        this.owner = newOwner;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.owner.v = newOwner;
        }
        else
        {
            // Debug.LogError ("clientData null");
        }
    }

    #endregion

    #region message

    [SyncVar(hook = "onChangeMessage")]
    public string message;

    public void onChangeMessage(string newMessage)
    {
        this.message = newMessage;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.message.v = newMessage;
        }
        else
        {
            // Debug.LogError ("clientData null");
        }
    }

    #endregion

    #endregion

    #region NetData

    private NetData<ChatNormalContent> netData = new NetData<ChatNormalContent>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void addSyncListCallBack()
    {
        base.addSyncListCallBack();
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            this.onChangeOwner(this.owner);
            this.onChangeMessage(this.message);
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
            ret += 4;
            ret += GetDataSize(this.owner);
            ret += GetDataSize(this.message);
        }
        return ret;
    }

    #endregion

    #region implement callBack

    public override void onAddCallBack<T>(T data)
    {
        // ChatPlayer
        if (data is ChatNormalContent)
        {
            ChatNormalContent chatNormalContent = data as ChatNormalContent;
            // Parent
            this.addTransformToParent();
            // Set Property
            {
                this.serialize(this.searchInfor, chatNormalContent.makeSearchInforms());
                this.owner = chatNormalContent.owner.v;
                this.message = chatNormalContent.message.v;
            }
            this.getDataSize();
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(chatNormalContent);
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
        // ChatPlayer
        if (data is ChatMessage)
        {
            //ChatMessage chatMessage = data as ChatMessage;
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
        if (wrapProperty.p is ChatNormalContent)
        {
            switch ((ChatNormalContent.Property)wrapProperty.n)
            {
                case ChatNormalContent.Property.owner:
                    this.owner = (uint)wrapProperty.getValue();
                    break;
                case ChatNormalContent.Property.message:
                    this.message = (string)wrapProperty.getValue();
                    break;
                case ChatNormalContent.Property.edits:
                    break;
                default:
                    Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
    }

    #endregion

    #region Edit

    public void requestEdit(uint userId, string newMessage)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdChatNormalContentEdit(this.netId, userId, newMessage);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void edit(uint userId, string newMessage)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.edit(userId, newMessage);
        }
        else
        {
            Debug.LogError("serverData null");
        }
    }

    #endregion

}
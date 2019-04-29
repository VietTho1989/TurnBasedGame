using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618

public class ChatNormalContentEditIdentity : DataIdentity
{

    #region SyncVar

    #region time

    [SyncVar(hook = "onChangeTime")]
    public System.Int64 time;

    public void onChangeTime(System.Int64 newTime)
    {
        this.time = newTime;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.time.v = newTime;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #region message

    [SyncVar(hook = "onChangeMessage")]
    public System.String message;

    public void onChangeMessage(System.String newMessage)
    {
        this.message = newMessage;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.message.v = newMessage;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #endregion

    #region NetData

    private NetData<ChatNormalContentEdit> netData = new NetData<ChatNormalContentEdit>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            this.onChangeTime(this.time);
            this.onChangeMessage(this.message);
        }
        else
        {
            Debug.Log("clientData null");
        }
    }

    public override int refreshDataSize()
    {
        int ret = GetDataSize(this.netId);
        {
            ret += GetDataSize(this.time);
            ret += GetDataSize(this.message);
        }
        return ret;
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is ChatNormalContentEdit)
        {
            ChatNormalContentEdit chatNormalContentEdit = data as ChatNormalContentEdit;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, chatNormalContentEdit.makeSearchInforms());
                this.time = chatNormalContentEdit.time.v;
                this.message = chatNormalContentEdit.message.v;
            }
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(chatNormalContentEdit);
                }
                else
                {
                    Debug.LogError("observer null: " + this);
                }
            }
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is ChatNormalContentEdit)
        {
            // ChatNormalContentEdit chatNormalContentEdit = data as ChatNormalContentEdit;
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.setCheckChangeData(null);
                }
                else
                {
                    Debug.LogError("observer null: " + this);
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
        if (wrapProperty.p is ChatNormalContentEdit)
        {
            switch ((ChatNormalContentEdit.Property)wrapProperty.n)
            {
                case ChatNormalContentEdit.Property.time:
                    this.time = (System.Int64)wrapProperty.getValue();
                    break;
                case ChatNormalContentEdit.Property.message:
                    this.message = (System.String)wrapProperty.getValue();
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

}
using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class ChatViewerIdentity : DataIdentity
{

    #region SyncVar

    #region userId

    [SyncVar(hook = "onChangeUserId")]
    public System.UInt32 userId;

    public void onChangeUserId(System.UInt32 newUserId)
    {
        this.userId = newUserId;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.userId.v = newUserId;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #region minViewId

    [SyncVar(hook = "onChangeMinViewId")]
    public System.UInt32 minViewId;

    public void onChangeMinViewId(System.UInt32 newMinViewId)
    {
        this.minViewId = newMinViewId;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.minViewId.v = newMinViewId;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #region isActive

    [SyncVar(hook = "onChangeIsActive")]
    public bool isActive;

    public void onChangeIsActive(bool newIsActive)
    {
        this.isActive = newIsActive;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.isActive.v = newIsActive;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #region alreadyViewMaxId

    [SyncVar(hook = "onChangeAlreadyViewMaxId")]
    public uint alreadyViewMaxId;

    public void onChangeAlreadyViewMaxId(uint newAlreadyViewMaxId)
    {
        this.alreadyViewMaxId = newAlreadyViewMaxId;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.alreadyViewMaxId.v = newAlreadyViewMaxId;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #endregion

    #region NetData

    public NetData<ChatViewer> netData = new NetData<ChatViewer>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            this.onChangeUserId(this.userId);
            this.onChangeMinViewId(this.minViewId);
            this.onChangeIsActive(this.isActive);
            this.onChangeAlreadyViewMaxId(this.alreadyViewMaxId);
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
            ret += GetDataSize(this.userId);
            ret += GetDataSize(this.minViewId);
            ret += GetDataSize(this.isActive);
            ret += GetDataSize(this.alreadyViewMaxId);
        }
        return ret;
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is ChatViewer)
        {
            ChatViewer chatViewer = data as ChatViewer;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, chatViewer.makeSearchInforms());
                this.userId = chatViewer.userId.v;
                this.minViewId = chatViewer.minViewId.v;
                this.isActive = chatViewer.isActive.v;
                this.alreadyViewMaxId = chatViewer.alreadyViewMaxId.v;
            }
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new ChatViewerObserver(observer);
                    observer.setCheckChangeData(chatViewer);
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
        if (data is ChatViewer)
        {
            // ChatViewer chatViewer = data as ChatViewer;
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
        if (wrapProperty.p is ChatViewer)
        {
            switch ((ChatViewer.Property)wrapProperty.n)
            {
                case ChatViewer.Property.userId:
                    this.userId = (System.UInt32)wrapProperty.getValue();
                    break;
                case ChatViewer.Property.minViewId:
                    this.minViewId = (System.UInt32)wrapProperty.getValue();
                    break;
                case ChatViewer.Property.subViews:
                    break;
                case ChatViewer.Property.connection:
                    break;
                case ChatViewer.Property.isActive:
                    this.isActive = (bool)wrapProperty.getValue();
                    break;
                case ChatViewer.Property.alreadyViewMaxId:
                    this.alreadyViewMaxId = (uint)wrapProperty.getValue();
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

    #region setAlreadyViewMaxId

    public void requestSetAlreadyViewMaxId(uint userId, uint newAlreadyViewMaxId)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdChatViewSetAlreadyViewMaxId(this.netId, userId, newAlreadyViewMaxId);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void setAlreadyViewMaxId(uint userId, uint newAlreadyViewMaxId)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.setAlreadyViewMaxId(userId, newAlreadyViewMaxId);
        }
        else
        {
            Debug.LogError("serverData null");
        }
    }

    #endregion

}
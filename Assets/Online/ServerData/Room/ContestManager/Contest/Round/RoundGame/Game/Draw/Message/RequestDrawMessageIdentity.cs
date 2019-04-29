using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618

[NetworkSettings(channel = DataIdentity.ChatChanel)]
public class RequestDrawMessageIdentity : DataIdentity
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

    #region action

    [SyncVar(hook = "onChangeAction")]
    public RequestDrawMessage.Action action;

    public void onChangeAction(RequestDrawMessage.Action newAction)
    {
        this.action = newAction;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.action.v = newAction;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #endregion

    #region NetData

    private NetData<RequestDrawMessage> netData = new NetData<RequestDrawMessage>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            this.onChangeUserId(this.userId);
            this.onChangeAction(this.action);
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
            ret += GetDataSize(this.action);
        }
        return ret;
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is RequestDrawMessage)
        {
            RequestDrawMessage requestDrawMessage = data as RequestDrawMessage;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, requestDrawMessage.makeSearchInforms());
                this.userId = requestDrawMessage.userId.v;
                this.action = requestDrawMessage.action.v;
            }
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(requestDrawMessage);
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
        if (data is RequestDrawMessage)
        {
            // RequestDrawMessage requestDrawMessage = data as RequestDrawMessage;
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
        if (wrapProperty.p is RequestDrawMessage)
        {
            switch ((RequestDrawMessage.Property)wrapProperty.n)
            {
                case RequestDrawMessage.Property.userId:
                    this.userId = (System.UInt32)wrapProperty.getValue();
                    break;
                case RequestDrawMessage.Property.action:
                    this.action = (RequestDrawMessage.Action)wrapProperty.getValue();
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
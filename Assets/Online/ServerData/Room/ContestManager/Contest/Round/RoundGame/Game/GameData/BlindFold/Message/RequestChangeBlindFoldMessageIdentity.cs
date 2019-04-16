using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class RequestChangeBlindFoldMessageIdentity : DataIdentity
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
    public RequestChangeBlindFoldMessage.Action action;

    public void onChangeAction(RequestChangeBlindFoldMessage.Action newAction)
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

    #region newBlindFold

    [SyncVar(hook = "onChangeNewBlindFold")]
    public System.Boolean newBlindFold;

    public void onChangeNewBlindFold(System.Boolean newNewBlindFold)
    {
        this.newBlindFold = newNewBlindFold;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.newBlindFold.v = newNewBlindFold;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #endregion

    #region NetData

    private NetData<RequestChangeBlindFoldMessage> netData = new NetData<RequestChangeBlindFoldMessage>();

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
            this.onChangeNewBlindFold(this.newBlindFold);
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
            ret += GetDataSize(this.newBlindFold);
        }
        return ret;
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is RequestChangeBlindFoldMessage)
        {
            RequestChangeBlindFoldMessage requestChangeBlindFoldMessage = data as RequestChangeBlindFoldMessage;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, requestChangeBlindFoldMessage.makeSearchInforms());
                this.userId = requestChangeBlindFoldMessage.userId.v;
                this.action = requestChangeBlindFoldMessage.action.v;
                this.newBlindFold = requestChangeBlindFoldMessage.newBlindFold.v;
            }
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(requestChangeBlindFoldMessage);
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
        if (data is RequestChangeBlindFoldMessage)
        {
            // RequestChangeBlindfoldMessage requestChangeBlindFoldMessage = data as RequestChangeBlindFoldMessage;
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
        if (wrapProperty.p is RequestChangeBlindFoldMessage)
        {
            switch ((RequestChangeBlindFoldMessage.Property)wrapProperty.n)
            {
                case RequestChangeBlindFoldMessage.Property.userId:
                    this.userId = (System.UInt32)wrapProperty.getValue();
                    break;
                case RequestChangeBlindFoldMessage.Property.action:
                    this.action = (RequestChangeBlindFoldMessage.Action)wrapProperty.getValue();
                    break;
                case RequestChangeBlindFoldMessage.Property.newBlindFold:
                    this.newBlindFold = (System.Boolean)wrapProperty.getValue();
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
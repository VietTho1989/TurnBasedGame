using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class UndoRedoRequestMessageIdentity : DataIdentity
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
    public UndoRedoRequestMessage.Action action;

    public void onChangeAction(UndoRedoRequestMessage.Action newAction)
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

    #region operation

    [SyncVar(hook = "onChangeOperation")]
    public UndoRedoRequest.Operation operation;

    public void onChangeOperation(UndoRedoRequest.Operation newOperation)
    {
        this.operation = newOperation;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.operation.v = newOperation;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #endregion

    #region NetData

    private NetData<UndoRedoRequestMessage> netData = new NetData<UndoRedoRequestMessage>();

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
            this.onChangeOperation(this.operation);
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
            ret += GetDataSize(this.operation);
        }
        return ret;
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is UndoRedoRequestMessage)
        {
            UndoRedoRequestMessage undoRedoRequestMessage = data as UndoRedoRequestMessage;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, undoRedoRequestMessage.makeSearchInforms());
                this.userId = undoRedoRequestMessage.userId.v;
                this.action = undoRedoRequestMessage.action.v;
                this.operation = undoRedoRequestMessage.operation.v;
            }
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(undoRedoRequestMessage);
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
        if (data is UndoRedoRequestMessage)
        {
            // UndoRedoRequestMessage undoRedoRequestMessage = data as UndoRedoRequestMessage;
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
        if (wrapProperty.p is UndoRedoRequestMessage)
        {
            switch ((UndoRedoRequestMessage.Property)wrapProperty.n)
            {
                case UndoRedoRequestMessage.Property.userId:
                    this.userId = (System.UInt32)wrapProperty.getValue();
                    break;
                case UndoRedoRequestMessage.Property.action:
                    this.action = (UndoRedoRequestMessage.Action)wrapProperty.getValue();
                    break;
                case UndoRedoRequestMessage.Property.operation:
                    this.operation = (UndoRedoRequest.Operation)wrapProperty.getValue();
                    break;
                default:
                    Debug.LogError("Unknown wrapProperty: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}
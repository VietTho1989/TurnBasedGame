using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class UndoRedoRequestIdentity : DataIdentity
{

    #region count

    public SyncListInt count = new SyncListInt();

    private void OnCountChanged(SyncListInt.Operation op, int index, int item)
    {
        if (this.netData.clientData != null)
        {
            IdentityUtils.onSyncListChange(this.netData.clientData.count, this.count, op, index);
        }
        else
        {
            // Debug.LogError ("clientData null: " + this);
        }
    }

    #endregion

    #region NetData

    private NetData<UndoRedoRequest> netData = new NetData<UndoRedoRequest>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void addSyncListCallBack()
    {
        base.addSyncListCallBack();
        this.count.Callback += OnCountChanged;
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            IdentityUtils.refresh(this.netData.clientData.count, this.count);
        }
        else
        {
            // Debug.Log ("clientData null: " + this);
        }
    }

    public override int refreshDataSize()
    {
        int ret = GetDataSize(this.netId);
        {
            ret += GetDataSize(this.count);
        }
        return ret;
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is UndoRedoRequest)
        {
            UndoRedoRequest undoRedoRequest = data as UndoRedoRequest;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, undoRedoRequest.makeSearchInforms());
                IdentityUtils.InitSync(this.count, undoRedoRequest.count.vs);
            }
            this.getDataSize();
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(undoRedoRequest);
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
        if (data is UndoRedoRequest)
        {
            // UndoRedoRequest undoRedoRequest = data as UndoRedoRequest;
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
        if (wrapProperty.p is UndoRedoRequest)
        {
            switch ((UndoRedoRequest.Property)wrapProperty.n)
            {
                case UndoRedoRequest.Property.state:
                    break;
                case UndoRedoRequest.Property.count:
                    IdentityUtils.UpdateSyncList(this.count, syncs, GlobalCast<T>.CastingInt32);
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
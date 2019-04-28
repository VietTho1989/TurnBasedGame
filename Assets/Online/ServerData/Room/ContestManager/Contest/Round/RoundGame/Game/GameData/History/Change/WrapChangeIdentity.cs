using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

// [NetworkSettings(channel = 4)]
public class WrapChangeIdentity : DataIdentity
{

    #region parentInfor

    public SyncListUInt parentInfor = new SyncListUInt();

    public void OnChangeParentInfor(SyncListUInt.Operation op, int index)
    {
        Debug.LogError("why parentInfo change: " + this);
        if (this.netData.clientData != null)
        {
            this.netData.clientData.pi.v = DataIdentity.deserialize(this.parentInfor);
        }
        else
        {
            // Debug.Log ("clientData null: " + this);
        }
    }

    #endregion

    #region variableName

    [SyncVar(hook = "onChangeVariableName")]
    public byte variableName;

    public void onChangeVariableName(byte newVariableName)
    {
        this.variableName = newVariableName;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.vn.v = newVariableName;
        }
        else
        {
            // Debug.Log ("clientData null: " + this);
        }
    }

    #endregion

    #region Syncs

    public SyncListByte syncs = new SyncListByte();

    private void OnSyncsChanged(SyncListByte.Operation op, int index)
    {
        if (this.netData.clientData != null)
        {
            this.netData.clientData.syncs.v = syncs.getByteArray();
        }
        else
        {
            // Debug.LogError ("clientData null: " + this);
        }
    }

    #endregion

    #region NetData

    private NetData<WrapChange> netData = new NetData<WrapChange>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void addSyncListCallBack()
    {
        base.addSyncListCallBack();
        this.syncs.Callback += OnSyncsChanged;
    }

    private bool alreadyRefresh = false;

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            if (!alreadyRefresh)
            {
                alreadyRefresh = true;
                this.netData.clientData.pi.v = DataIdentity.deserialize(this.parentInfor);
                this.onChangeVariableName(this.variableName);
                this.netData.clientData.syncs.v = this.syncs.getByteArray();
            }
            else
            {
                // Debug.Log ("already refresh: " + this);
            }
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
            ret += GetDataSize(this.parentInfor);
            ret += GetDataSize(this.variableName);
            ret += GetDataSize(this.syncs);
        }
        return ret;
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is WrapChange)
        {
            WrapChange wrapChange = data as WrapChange;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, wrapChange.makeSearchInforms());
                this.serialize(this.parentInfor, wrapChange.pi.v);
                this.variableName = wrapChange.vn.v;
                // syncs
                {
                    this.syncs.Clear();
                    foreach (byte value in wrapChange.syncs.v)
                    {
                        this.syncs.Add(new MyByte(value));
                    }
                }
            }
            this.getDataSize();
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new HistoryChangeObserver(observer);
                    observer.setCheckChangeData(wrapChange);
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
        if (data is WrapChange)
        {
            // WrapChange wrapChange = data as WrapChange;
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
        if (wrapProperty.p is WrapChange)
        {
            switch ((WrapChange.Property)wrapProperty.n)
            {
                default:
                    Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}
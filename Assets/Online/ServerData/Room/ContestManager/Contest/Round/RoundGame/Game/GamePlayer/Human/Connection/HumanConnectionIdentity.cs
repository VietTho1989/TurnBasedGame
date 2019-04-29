using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618

public class HumanConnectionIdentity : DataIdentity
{

    #region SyncVar

    #region playerId

    [SyncVar(hook = "onChangePlayerId")]
    public System.UInt32 playerId;

    public void onChangePlayerId(System.UInt32 newPlayerId)
    {
        this.playerId = newPlayerId;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.playerId.v = newPlayerId;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #endregion

    #region NetData

    private NetData<HumanConnection> netData = new NetData<HumanConnection>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            this.onChangePlayerId(this.playerId);
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
            ret += GetDataSize(this.playerId);
        }
        return ret;
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is HumanConnection)
        {
            HumanConnection humanConnection = data as HumanConnection;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, humanConnection.makeSearchInforms());
                this.playerId = humanConnection.playerId.v;
            }
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new HumanConnectionObserver(observer);
                    observer.setCheckChangeData(humanConnection);
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
        if (data is HumanConnection)
        {
            // HumanConnection humanConnection = data as HumanConnection;
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
        if (wrapProperty.p is HumanConnection)
        {
            switch ((HumanConnection.Property)wrapProperty.n)
            {
                case HumanConnection.Property.playerId:
                    this.playerId = (System.UInt32)wrapProperty.getValue();
                    break;
                case HumanConnection.Property.connection:
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
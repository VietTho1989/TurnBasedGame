using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class WaitInputActionIdentity : DataIdentity
{

    #region SyncVar

    #region serverTime

    [SyncVar(hook = "onChangeServerTime")]
    public System.Single serverTime;

    public void onChangeServerTime(System.Single newServerTime)
    {
        this.serverTime = newServerTime;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.serverTime.v = newServerTime;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #endregion

    #region NetData

    private NetData<WaitInputAction> netData = new NetData<WaitInputAction>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void afterAddNewDataToClient()
    {
        base.afterAddNewDataToClient();
        UpdateUtils.makeUpdate<WaitInputActionClientUpdate, WaitInputAction>(this.netData.clientData, this.transform);
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            this.onChangeServerTime(this.serverTime);
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
            ret += GetDataSize(this.serverTime);
        }
        return ret;
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is WaitInputAction)
        {
            WaitInputAction waitInputAction = data as WaitInputAction;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, waitInputAction.makeSearchInforms());
                this.serverTime = waitInputAction.serverTime.v;
            }
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(waitInputAction);
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
        if (data is WaitInputAction)
        {
            // WaitInputAction waitInputAction = data as WaitInputAction;
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
        if (wrapProperty.p is WaitInputAction)
        {
            switch ((WaitInputAction.Property)wrapProperty.n)
            {
                case WaitInputAction.Property.serverTime:
                    this.serverTime = (System.Single)wrapProperty.getValue();
                    break;
                case WaitInputAction.Property.clientTime:
                    break;
                case WaitInputAction.Property.sub:
                    break;
                case WaitInputAction.Property.inputs:
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

    #region sendInput

    public void requestSendInput(uint userId, GameMove gameMove, float clientTime)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null && gameMove != null)
        {
            byte[] gameMoveBytes = Data.MakeBinary(gameMove);
            if (gameMoveBytes != null)
            {
                clientConnect.CmdWaitAIMoveInputSendInput(this.netId, userId, gameMoveBytes, clientTime);
            }
            else
            {
                Debug.LogError("gameMoveBytes null: " + this);
            }
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void sendInput(uint userId, GameMove gameMove, float clientTime)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.sendInput(userId, gameMove, clientTime);
        }
        else
        {
            Debug.LogError("serverData null: " + this);
        }
    }

    #endregion

}
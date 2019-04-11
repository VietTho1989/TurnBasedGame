using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class RequestChangeUseRuleStateNoneIdentity : DataIdentity
{

    #region SyncVar

    #endregion

    #region NetData

    private NetData<RequestChangeUseRuleStateNone> netData = new NetData<RequestChangeUseRuleStateNone>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
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
        }
        return ret;
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is RequestChangeUseRuleStateNone)
        {
            RequestChangeUseRuleStateNone requestChangeUseRuleStateNone = data as RequestChangeUseRuleStateNone;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, requestChangeUseRuleStateNone.makeSearchInforms());
            }
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(requestChangeUseRuleStateNone);
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
        if (data is RequestChangeUseRuleStateNone)
        {
            // RequestChangeUseRuleStateNone requestChangeUseRuleStateNone = data as RequestChangeUseRuleStateNone;
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
        if (wrapProperty.p is RequestChangeUseRuleStateNone)
        {
            switch ((RequestChangeUseRuleStateNone.Property)wrapProperty.n)
            {
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    #region accept

    public void requestChange(uint userId)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdRequestChangeUseRuleStateNoneChange(this.netId, userId);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void change(uint userId)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.change(userId);
        }
        else
        {
            Debug.LogError("serverData null: " + this);
        }
    }

    #endregion

}
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class RequestChangeUseRuleMessageIdentity : DataIdentity
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
    public RequestChangeUseRuleMessage.Action action;

    public void onChangeAction(RequestChangeUseRuleMessage.Action newAction)
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

    #region newUseRule

    [SyncVar(hook = "onChangeNewUseRule")]
    public System.Boolean newUseRule;

    public void onChangeNewUseRule(System.Boolean newNewUseRule)
    {
        this.newUseRule = newNewUseRule;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.newUseRule.v = newNewUseRule;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #endregion

    #region NetData

    private NetData<RequestChangeUseRuleMessage> netData = new NetData<RequestChangeUseRuleMessage>();

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
            this.onChangeNewUseRule(this.newUseRule);
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
            ret += GetDataSize(this.newUseRule);
        }
        return ret;
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is RequestChangeUseRuleMessage)
        {
            RequestChangeUseRuleMessage requestChangeUseRuleMessage = data as RequestChangeUseRuleMessage;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, requestChangeUseRuleMessage.makeSearchInforms());
                this.userId = requestChangeUseRuleMessage.userId.v;
                this.action = requestChangeUseRuleMessage.action.v;
                this.newUseRule = requestChangeUseRuleMessage.newUseRule.v;
            }
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(requestChangeUseRuleMessage);
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
        if (data is RequestChangeUseRuleMessage)
        {
            // RequestChangeUseRuleMessage requestChangeUseRuleMessage = data as RequestChangeUseRuleMessage;
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
        if (wrapProperty.p is RequestChangeUseRuleMessage)
        {
            switch ((RequestChangeUseRuleMessage.Property)wrapProperty.n)
            {
                case RequestChangeUseRuleMessage.Property.userId:
                    this.userId = (System.UInt32)wrapProperty.getValue();
                    break;
                case RequestChangeUseRuleMessage.Property.action:
                    this.action = (RequestChangeUseRuleMessage.Action)wrapProperty.getValue();
                    break;
                case RequestChangeUseRuleMessage.Property.newUseRule:
                    this.newUseRule = (System.Boolean)wrapProperty.getValue();
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
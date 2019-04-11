using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RequestChangeUseRuleStateAsk : RequestChangeUseRule.State
{

    public LP<uint> accepts;

    #region Constructor

    public enum Property
    {
        accepts
    }

    public RequestChangeUseRuleStateAsk() : base()
    {
        this.accepts = new LP<uint>(this, (byte)Property.accepts);
    }

    #endregion

    public override Type getType()
    {
        return Type.Ask;
    }

    #region answer

    public bool isCanAnswer(uint userId)
    {
        bool ret = false;
        {
            RequestChangeUseRule requestChangeUseRule = this.findDataInParent<RequestChangeUseRule>();
            if (requestChangeUseRule != null)
            {
                foreach (Human human in requestChangeUseRule.whoCanAsks.vs)
                {
                    if (human.playerId.v == userId)
                    {
                        ret = true;
                        break;
                    }
                }
            }
            else
            {
                Debug.LogError("requestChangeUseRule null: " + this);
            }
        }
        return ret;
    }

    #region accept

    public void requestAccept(uint userId)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.accept(userId);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is RequestChangeUseRuleStateAskIdentity)
                    {
                        RequestChangeUseRuleStateAskIdentity requestChangeUseRuleStateAskIdentity = dataIdentity as RequestChangeUseRuleStateAskIdentity;
                        requestChangeUseRuleStateAskIdentity.requestAccept(userId);
                    }
                    else
                    {
                        Debug.LogError("Why isn't correct identity");
                    }
                }
                else
                {
                    Debug.LogError("cannot find dataIdentity");
                }
            }
        }
        else
        {
            Debug.LogError("You cannot request");
        }
    }

    public void accept(uint userId)
    {
        if (isCanAnswer(userId))
        {
            if (!this.accepts.vs.Contains(userId))
            {
                // message
                RequestChangeUseRuleMessage.Add(this, userId, RequestChangeUseRuleMessage.Action.Accept);
                // state
                this.accepts.add(userId);
            }
            else
            {
                Debug.LogError("already accept: " + userId);
            }
        }
        else
        {
            Debug.LogError("cannot change: " + userId + "; " + this);
        }
    }

    #endregion

    #region refuse

    public void requestRefuse(uint userId)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.refuse(userId);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is RequestChangeUseRuleStateAskIdentity)
                    {
                        RequestChangeUseRuleStateAskIdentity requestChangeUseRuleStateAskIdentity = dataIdentity as RequestChangeUseRuleStateAskIdentity;
                        requestChangeUseRuleStateAskIdentity.requestRefuse(userId);
                    }
                    else
                    {
                        Debug.LogError("Why isn't correct identity");
                    }
                }
                else
                {
                    Debug.LogError("cannot find dataIdentity");
                }
            }
        }
        else
        {
            Debug.LogError("You cannot request");
        }
    }

    public void refuse(uint userId)
    {
        if (isCanAnswer(userId))
        {
            RequestChangeUseRule requestChangeUseRule = this.findDataInParent<RequestChangeUseRule>();
            if (requestChangeUseRule != null)
            {
                // message
                RequestChangeUseRuleMessage.Add(this, userId, RequestChangeUseRuleMessage.Action.Refuse);
                // state
                RequestChangeUseRuleStateNone requestChangeUseRuleStateNone = new RequestChangeUseRuleStateNone();
                {
                    requestChangeUseRuleStateNone.uid = requestChangeUseRule.state.makeId();
                }
                requestChangeUseRule.state.v = requestChangeUseRuleStateNone;
            }
            else
            {
                Debug.LogError("requestChangeUseRule null: " + this);
            }
        }
        else
        {
            Debug.LogError("cannot change: " + userId + "; " + this);
        }
    }

    #endregion

    #endregion

}
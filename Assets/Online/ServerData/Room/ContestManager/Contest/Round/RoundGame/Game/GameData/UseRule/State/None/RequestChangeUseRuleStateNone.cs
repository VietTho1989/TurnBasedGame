using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RequestChangeUseRuleStateNone : RequestChangeUseRule.State
{

    #region Constructor

    public enum Property
    {

    }

    public RequestChangeUseRuleStateNone() : base()
    {

    }

    #endregion

    public override Type getType()
    {
        return Type.None;
    }

    #region request

    public bool isCanChange(uint userId)
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

    public void requestChange(uint userId)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.change(userId);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is RequestChangeUseRuleStateNoneIdentity)
                    {
                        RequestChangeUseRuleStateNoneIdentity requestChangeUseRuleStateNoneIdentity = dataIdentity as RequestChangeUseRuleStateNoneIdentity;
                        requestChangeUseRuleStateNoneIdentity.requestChange(userId);
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

    public void change(uint userId)
    {
        if (isCanChange(userId))
        {
            RequestChangeUseRule requestChangeUseRule = this.findDataInParent<RequestChangeUseRule>();
            if (requestChangeUseRule != null)
            {
                // message
                RequestChangeUseRuleMessage.Add(this, userId, RequestChangeUseRuleMessage.Action.Ask);
                // make state
                RequestChangeUseRuleStateAsk ask = new RequestChangeUseRuleStateAsk();
                {
                    ask.uid = requestChangeUseRule.state.makeId();
                    ask.accepts.add(userId);
                }
                requestChangeUseRule.state.v = ask;
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

}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RequestChangeBlindFoldStateNone : RequestChangeBlindFold.State
{

    #region Constructor

    public enum Property
    {

    }

    public RequestChangeBlindFoldStateNone() : base()
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
            RequestChangeBlindFold requestChangeBlindFold = this.findDataInParent<RequestChangeBlindFold>();
            if (requestChangeBlindFold != null)
            {
                foreach (Human human in requestChangeBlindFold.whoCanAsks.vs)
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
                // Debug.LogError("requestChangeBlindFold null: " + this);
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
                    if (dataIdentity is RequestChangeBlindFoldStateNoneIdentity)
                    {
                        RequestChangeBlindFoldStateNoneIdentity requestChangeBlindFoldStateNoneIdentity = dataIdentity as RequestChangeBlindFoldStateNoneIdentity;
                        requestChangeBlindFoldStateNoneIdentity.requestChange(userId);
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
            RequestChangeBlindFold requestChangeBlindFold = this.findDataInParent<RequestChangeBlindFold>();
            if (requestChangeBlindFold != null)
            {
                // message
                RequestChangeBlindFoldMessage.Add(this, userId, RequestChangeBlindFoldMessage.Action.Ask);
                // make state
                RequestChangeBlindFoldStateAsk ask = new RequestChangeBlindFoldStateAsk();
                {
                    ask.uid = requestChangeBlindFold.state.makeId();
                    ask.accepts.add(userId);
                }
                requestChangeBlindFold.state.v = ask;
            }
            else
            {
                Debug.LogError("requestChangeBlindFold null: " + this);
            }
        }
        else
        {
            Debug.LogError("cannot change: " + userId + "; " + this);
        }
    }

    #endregion

}
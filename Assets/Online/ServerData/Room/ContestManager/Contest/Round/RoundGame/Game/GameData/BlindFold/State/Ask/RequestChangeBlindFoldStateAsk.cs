using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RequestChangeBlindFoldStateAsk : RequestChangeBlindFold.State
{

    public LP<uint> accepts;

    #region Constructor

    public enum Property
    {
        accepts
    }

    public RequestChangeBlindFoldStateAsk() : base()
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
                Debug.LogError("requestChangeBlindFold null: " + this);
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
                    if (dataIdentity is RequestChangeBlindFoldStateAskIdentity)
                    {
                        RequestChangeBlindFoldStateAskIdentity requestChangeBlindFoldStateAskIdentity = dataIdentity as RequestChangeBlindFoldStateAskIdentity;
                        requestChangeBlindFoldStateAskIdentity.requestAccept(userId);
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
                RequestChangeBlindFoldMessage.Add(this, userId, RequestChangeBlindFoldMessage.Action.Accept);
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
                    if (dataIdentity is RequestChangeBlindFoldStateAskIdentity)
                    {
                        RequestChangeBlindFoldStateAskIdentity requestChangeBlindFoldStateAskIdentity = dataIdentity as RequestChangeBlindFoldStateAskIdentity;
                        requestChangeBlindFoldStateAskIdentity.requestRefuse(userId);
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
            RequestChangeBlindFold requestChangeBlindFold = this.findDataInParent<RequestChangeBlindFold>();
            if (requestChangeBlindFold != null)
            {
                // message
                RequestChangeBlindFoldMessage.Add(this, userId, RequestChangeBlindFoldMessage.Action.Refuse);
                // state
                RequestChangeBlindFoldStateNone requestChangeBlindFoldStateNone = new RequestChangeBlindFoldStateNone();
                {
                    requestChangeBlindFoldStateNone.uid = requestChangeBlindFold.state.makeId();
                }
                requestChangeBlindFold.state.v = requestChangeBlindFoldStateNone;
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

    #endregion

}
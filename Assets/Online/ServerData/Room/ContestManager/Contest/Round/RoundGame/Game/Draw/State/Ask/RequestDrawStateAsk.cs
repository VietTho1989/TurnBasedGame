using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RequestDrawStateAsk : RequestDraw.State
{

    public LP<uint> accepts;

    public LP<uint> refuses;

    #region Constructor

    public enum Property
    {
        accepts,
        refuses
    }

    public RequestDrawStateAsk() : base()
    {
        this.accepts = new LP<uint>(this, (byte)Property.accepts);
        this.refuses = new LP<uint>(this, (byte)Property.refuses);
    }

    #endregion

    public override Type getType()
    {
        return Type.Ask;
    }

    #region Answer

    public bool isCanAnswer(uint userId, Answer answer)
    {
        if (Game.IsPlaying(this, false))
        {
            RequestDraw requestDraw = this.findDataInParent<RequestDraw>();
            if (requestDraw != null)
            {
                // Check can answer
                HashSet<uint> whoCanAnswer = requestDraw.getWhoCanAsk();
                if (whoCanAnswer.Contains(userId))
                {
                    switch (answer)
                    {
                        case Answer.Accept:
                            {
                                if (!this.accepts.vs.Contains(userId))
                                {
                                    return true;
                                }
                                else
                                {
                                    Debug.LogError("already accept: " + userId);
                                }
                            }
                            break;
                        case Answer.Refuse:
                            {
                                if (!this.refuses.vs.Contains(userId))
                                {
                                    return true;
                                }
                                else
                                {
                                    Debug.LogError("already refuse: " + userId);
                                }
                            }
                            break;
                        default:
                            Debug.LogError("unknown answer");
                            break;
                    }
                }
            }
            else
            {
                Debug.LogError("requestDraw null");
            }
        }
        // Return
        return false;
    }

    public enum Answer
    {
        Accept,
        Refuse
    }

    public void requestAnswer(uint userId, Answer answer)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.answer(userId, answer);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is RequestDrawStateAskIdentity)
                    {
                        RequestDrawStateAskIdentity requestDrawStateAskIdentity = dataIdentity as RequestDrawStateAskIdentity;
                        requestDrawStateAskIdentity.requestAnswer(userId, answer);
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

    public void answer(uint userId, Answer answer)
    {
        if (isCanAnswer(userId, answer))
        {
            switch (answer)
            {
                case Answer.Accept:
                    {
                        this.refuses.remove(userId);
                        this.accepts.add(userId);
                    }
                    break;
                case Answer.Refuse:
                    {
                        this.accepts.remove(userId);
                        this.refuses.add(userId);
                    }
                    break;
            }
        }
        else
        {
            Debug.LogError("Cannot answer: " + userId + ", " + answer);
        }
    }

    #endregion

}
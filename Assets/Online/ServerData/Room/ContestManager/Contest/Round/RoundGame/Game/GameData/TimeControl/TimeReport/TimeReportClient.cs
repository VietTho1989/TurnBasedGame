using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeReportClient : TimeReport
{

    public VP<uint> userId;

    public VP<float> delta;

    #region reportTime

    public VP<float> reportTime;

    public bool isCanRequestReportTime(uint userId)
    {
        return this.userId.v == userId;
    }

    public void requestReportClientTime(uint userId, float clientTime)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.reportClientTime(userId, clientTime);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is TimeReportClientIdentity)
                    {
                        TimeReportClientIdentity timeReportClientIdentity = dataIdentity as TimeReportClientIdentity;
                        timeReportClientIdentity.requestReportClientTime(userId, clientTime);
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
            Debug.LogError("You cannot request: " + this);
        }
    }

    public void reportClientTime(uint userId, float clientTime)
    {
        if (isCanRequestReportTime(userId))
        {
            this.reportTime.v = clientTime;
        }
        else
        {
            Debug.LogError("cannot request report time: " + userId + "; " + this);
        }
    }

    #endregion

    #region State

    public enum State
    {
        None,
        Send,
        Sending
    }

    /** Chi dung o client*/
    public VP<State> clientState;

    #endregion

    #region Constructor

    public enum Property
    {
        userId,
        delta,
        reportTime,
        clientState
    }

    public TimeReportClient() : base()
    {
        this.userId = new VP<uint>(this, (byte)Property.userId, 0);
        this.delta = new VP<float>(this, (byte)Property.delta, 0);
        this.reportTime = new VP<float>(this, (byte)Property.reportTime, 0);
        this.clientState = new VP<State>(this, (byte)Property.clientState, State.None);
    }

    #endregion

    public override Type getType()
    {
        return Type.Client;
    }

}
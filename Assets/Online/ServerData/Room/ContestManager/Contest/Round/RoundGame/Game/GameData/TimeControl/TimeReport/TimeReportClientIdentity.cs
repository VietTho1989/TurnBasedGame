using UnityEngine;
using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;

public class TimeReportClientIdentity : DataIdentity
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

    #region delta

    [SyncVar(hook = "onChangeDelta")]
    public System.Single delta;

    public void onChangeDelta(System.Single newDelta)
    {
        this.delta = newDelta;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.delta.v = newDelta;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #region reportTime

    [SyncVar(hook = "onChangeReportTime")]
    public System.Single reportTime;

    public void onChangeReportTime(System.Single newReportTime)
    {
        this.reportTime = newReportTime;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.reportTime.v = newReportTime;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #endregion

    #region NetData

    private NetData<TimeReportClient> netData = new NetData<TimeReportClient>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void afterAddNewDataToClient()
    {
        base.afterAddNewDataToClient();
        UpdateUtils.makeUpdate<TimeReportClientUpdate, TimeReportClient>(this.netData.clientData, this.transform);
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            this.onChangeUserId(this.userId);
            this.onChangeDelta(this.delta);
            this.onChangeReportTime(this.reportTime);
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
            ret += GetDataSize(this.delta);
            ret += GetDataSize(this.reportTime);
        }
        return ret;
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is TimeReportClient)
        {
            TimeReportClient timeReportClient = data as TimeReportClient;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, timeReportClient.makeSearchInforms());
                this.userId = timeReportClient.userId.v;
                this.delta = timeReportClient.delta.v;
                this.reportTime = timeReportClient.reportTime.v;
            }
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(timeReportClient);
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
        if (data is TimeReportClient)
        {
            // TimeReportClient timeReportClient = data as TimeReportClient;
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
        if (wrapProperty.p is TimeReportClient)
        {
            switch ((TimeReportClient.Property)wrapProperty.n)
            {
                case TimeReportClient.Property.userId:
                    this.userId = (System.UInt32)wrapProperty.getValue();
                    break;
                case TimeReportClient.Property.delta:
                    this.delta = (System.Single)wrapProperty.getValue();
                    break;
                case TimeReportClient.Property.reportTime:
                    this.reportTime = (System.Single)wrapProperty.getValue();
                    break;
                case TimeReportClient.Property.clientState:
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

    #region report client time

    public void requestReportClientTime(uint userId, float clientTime)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdTimeReportClientTime(this.netId, userId, clientTime);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void reportClientTime(uint userId, float clientTime)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.reportClientTime(userId, clientTime);
        }
        else
        {
            Debug.LogError("serverData null");
        }
    }

    #endregion

}
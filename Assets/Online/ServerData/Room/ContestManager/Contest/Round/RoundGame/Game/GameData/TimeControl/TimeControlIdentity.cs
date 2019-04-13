using UnityEngine;
using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl
{
    public class TimeControlIdentity : DataIdentity
    {

        #region SyncVar

        #region isEnable

        [SyncVar(hook = "onChangeIsEnable")]
        public System.Boolean isEnable;

        public void onChangeIsEnable(System.Boolean newIsEnable)
        {
            this.isEnable = newIsEnable;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.isEnable.v = newIsEnable;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region aiCanTimeOut

        [SyncVar(hook = "onChangeAiCanTimeOut")]
        public System.Boolean aiCanTimeOut;

        public void onChangeAiCanTimeOut(System.Boolean newAiCanTimeOut)
        {
            this.aiCanTimeOut = newAiCanTimeOut;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.aiCanTimeOut.v = newAiCanTimeOut;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region timeOutPlayers

        public SyncListInt timeOutPlayers = new SyncListInt();

        private void OnTimeOutPlayersChanged(SyncListInt.Operation op, int index, int item)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.timeOutPlayers, this.timeOutPlayers, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }
        #endregion

        #region use

        [SyncVar(hook = "onChangeUse")]
        public TimeControl.Use use;

        public void onChangeUse(TimeControl.Use newUse)
        {
            this.use = newUse;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.use.v = newUse;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<TimeControl> netData = new NetData<TimeControl>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.timeOutPlayers.Callback += OnTimeOutPlayersChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeIsEnable(this.isEnable);
                this.onChangeAiCanTimeOut(this.aiCanTimeOut);
                IdentityUtils.refresh(this.netData.clientData.timeOutPlayers, this.timeOutPlayers);
                this.onChangeUse(this.use);
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
                ret += GetDataSize(this.isEnable);
                ret += GetDataSize(this.aiCanTimeOut);
                ret += GetDataSize(this.timeOutPlayers);
                ret += GetDataSize(this.use);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is TimeControl)
            {
                TimeControl timeControl = data as TimeControl;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, timeControl.makeSearchInforms());
                    this.isEnable = timeControl.isEnable.v;
                    this.aiCanTimeOut = timeControl.aiCanTimeOut.v;
                    IdentityUtils.InitSync(this.timeOutPlayers, timeControl.timeOutPlayers.vs);
                    this.use = timeControl.use.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(timeControl);
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
            if (data is TimeControl)
            {
                // TimeControl timeControl = data as TimeControl;
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
            if (wrapProperty.p is TimeControl)
            {
                switch ((TimeControl.Property)wrapProperty.n)
                {
                    case TimeControl.Property.isEnable:
                        this.isEnable = (System.Boolean)wrapProperty.getValue();
                        break;
                    case TimeControl.Property.aiCanTimeOut:
                        this.aiCanTimeOut = (System.Boolean)wrapProperty.getValue();
                        break;
                    case TimeControl.Property.timeOutPlayers:
                        IdentityUtils.UpdateSyncList(this.timeOutPlayers, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case TimeControl.Property.sub:
                        break;
                    case TimeControl.Property.use:
                        this.use = (TimeControl.Use)wrapProperty.getValue();
                        break;
                    case TimeControl.Property.timeReport:
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

        #region isEnable

        public void requestChangeIsEnable(uint userId, bool newIsEnable)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdTimeControlChangeIsEnable(this.netId, userId, newIsEnable);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeIsEnable(uint userId, bool newIsEnable)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeIsEnable(userId, newIsEnable);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region aiCanTimeOut

        public void requestChangeAICanTimeOut(uint userId, bool newAICanTimeOut)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdTimeControlChangeAICanTimeOut(this.netId, userId, newAICanTimeOut);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeAICanTimeOut(uint userId, bool newAICanTimeOut)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeAICanTimeOut(userId, newAICanTimeOut);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region use

        public void requestChangeUse(uint userId, int newUse)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdTimeControlChangeUse(this.netId, userId, newUse);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeUse(uint userId, int newUse)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeUse(userId, newUse);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region subType

        public void requestChangeSubType(uint userId, int newSubType)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdTimeControlChangeSubType(this.netId, userId, newSubType);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeSubType(uint userId, int newSubType)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeSubType(userId, newSubType);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

    }
}
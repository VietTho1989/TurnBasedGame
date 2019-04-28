using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
    public class ChangeGamePlayerRightIdentity : DataIdentity
    {

        #region SyncVar

        #region canChange

        [SyncVar(hook = "onChangeCanChange")]
        public System.Boolean canChange;

        public void onChangeCanChange(System.Boolean newCanChange)
        {
            this.canChange = newCanChange;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.canChange.v = newCanChange;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region canChangePlayerLeft

        [SyncVar(hook = "onChangeCanChangePlayerLeft")]
        public System.Boolean canChangePlayerLeft;

        public void onChangeCanChangePlayerLeft(System.Boolean newCanChangePlayerLeft)
        {
            this.canChangePlayerLeft = newCanChangePlayerLeft;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.canChangePlayerLeft.v = newCanChangePlayerLeft;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region needAdminAccept

        [SyncVar(hook = "onChangeNeedAdminAccept")]
        public System.Boolean needAdminAccept;

        public void onChangeNeedAdminAccept(System.Boolean newNeedAdminAccept)
        {
            this.needAdminAccept = newNeedAdminAccept;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.needAdminAccept.v = newNeedAdminAccept;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region onlyAdminNeed

        [SyncVar(hook = "onChangeOnlyAdminNeed")]
        public System.Boolean onlyAdminNeed;

        public void onChangeOnlyAdminNeed(System.Boolean newOnlyAdminNeed)
        {
            this.onlyAdminNeed = newOnlyAdminNeed;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.onlyAdminNeed.v = newOnlyAdminNeed;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<ChangeGamePlayerRight> netData = new NetData<ChangeGamePlayerRight>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeCanChange(this.canChange);
                this.onChangeCanChangePlayerLeft(this.canChangePlayerLeft);
                this.onChangeNeedAdminAccept(this.needAdminAccept);
                this.onChangeOnlyAdminNeed(this.onlyAdminNeed);
            }
            else
            {
                Debug.Log("clientData null: " + this);
            }
        }

        public override int refreshDataSize()
        {
            int ret = GetDataSize(this.netId);
            {
                ret += GetDataSize(this.canChange);
                ret += GetDataSize(this.canChangePlayerLeft);
                ret += GetDataSize(this.needAdminAccept);
                ret += GetDataSize(this.onlyAdminNeed);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is ChangeGamePlayerRight)
            {
                ChangeGamePlayerRight changeGamePlayerRight = data as ChangeGamePlayerRight;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, changeGamePlayerRight.makeSearchInforms());
                    this.canChange = changeGamePlayerRight.canChange.v;
                    this.canChangePlayerLeft = changeGamePlayerRight.canChangePlayerLeft.v;
                    this.needAdminAccept = changeGamePlayerRight.needAdminAccept.v;
                    this.onlyAdminNeed = changeGamePlayerRight.onlyAdminNeed.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(changeGamePlayerRight);
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
            if (data is ChangeGamePlayerRight)
            {
                // ChangeGamePlayerRight changeGamePlayerRight = data as ChangeGamePlayerRight;
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
            if (wrapProperty.p is ChangeGamePlayerRight)
            {
                switch ((ChangeGamePlayerRight.Property)wrapProperty.n)
                {
                    case ChangeGamePlayerRight.Property.canChange:
                        this.canChange = (System.Boolean)wrapProperty.getValue();
                        break;
                    case ChangeGamePlayerRight.Property.canChangePlayerLeft:
                        this.canChangePlayerLeft = (System.Boolean)wrapProperty.getValue();
                        break;
                    case ChangeGamePlayerRight.Property.needAdminAccept:
                        this.needAdminAccept = (System.Boolean)wrapProperty.getValue();
                        break;
                    case ChangeGamePlayerRight.Property.onlyAdminNeed:
                        this.onlyAdminNeed = (System.Boolean)wrapProperty.getValue();
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

        #region canChange

        public void requestChangeCanChange(uint userId, bool newCanChange)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdChangeGamePlayerRightChangeCanChange(this.netId, userId, newCanChange);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeCanChange(uint userId, bool newCanChange)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeCanChange(userId, newCanChange);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region canChangePlayerLeft

        public void requestChangeCanChangePlayerLeft(uint userId, bool newCanChangePlayerLeft)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdChangeGamePlayerRightChangeCanChangePlayerLeft(this.netId, userId, newCanChangePlayerLeft);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeCanChangePlayerLeft(uint userId, bool newCanChangePlayerLeft)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeCanChangePlayerLeft(userId, newCanChangePlayerLeft);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region needAdminAccept

        public void requestChangeNeedAdminAccept(uint userId, bool newNeedAdminAccept)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdChangeGamePlayerRightChangeNeedAdminAccept(this.netId, userId, newNeedAdminAccept);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeNeedAdminAccept(uint userId, bool newNeedAdminAccept)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeNeedAdminAccept(userId, newNeedAdminAccept);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region onlyAdminNeed

        public void requestChangeOnlyAdminNeed(uint userId, bool newOnlyAdminNeed)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdChangeGamePlayerRightChangeOnlyAdminNeed(this.netId, userId, newOnlyAdminNeed);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeOnlyAdminNeed(uint userId, bool newOnlyAdminNeed)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeOnlyAdminNeed(userId, newOnlyAdminNeed);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

    }
}
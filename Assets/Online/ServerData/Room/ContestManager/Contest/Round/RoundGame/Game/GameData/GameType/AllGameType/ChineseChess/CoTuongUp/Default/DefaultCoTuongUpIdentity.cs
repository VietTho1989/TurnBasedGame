using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace CoTuongUp
{
    public class DefaultCoTuongUpIdentity : DataIdentity
    {

        #region SyncVar

        #region move

        [SyncVar(hook = "onChangeAllowViewCapture")]
        public bool allowViewCapture;

        public void onChangeAllowViewCapture(bool newAllowViewCapture)
        {
            this.allowViewCapture = newAllowViewCapture;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.allowViewCapture.v = newAllowViewCapture;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region allowWatcherViewHidden

        [SyncVar(hook = "onChangeAllowWatcherViewHidden")]
        public bool allowWatcherViewHidden;

        public void onChangeAllowWatcherViewHidden(bool newAllowWatcherViewHidden)
        {
            this.allowWatcherViewHidden = newAllowWatcherViewHidden;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.allowWatcherViewHidden.v = newAllowWatcherViewHidden;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region allowOnlyFlip

        [SyncVar(hook = "onChangeAllowOnlyFlip")]
        public bool allowOnlyFlip;

        public void onChangeAllowOnlyFlip(bool newAllowOnlyFlip)
        {
            this.allowOnlyFlip = newAllowOnlyFlip;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.allowOnlyFlip.v = newAllowOnlyFlip;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<DefaultCoTuongUp> netData = new NetData<DefaultCoTuongUp>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeAllowViewCapture(this.allowViewCapture);
                this.onChangeAllowWatcherViewHidden(this.allowWatcherViewHidden);
                this.onChangeAllowOnlyFlip(this.allowOnlyFlip);
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
                ret += GetDataSize(this.allowViewCapture);
                ret += GetDataSize(this.allowWatcherViewHidden);
                ret += GetDataSize(this.allowOnlyFlip);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is DefaultCoTuongUp)
            {
                DefaultCoTuongUp defaultCoTuongUp = data as DefaultCoTuongUp;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, defaultCoTuongUp.makeSearchInforms());
                    this.allowViewCapture = defaultCoTuongUp.allowViewCapture.v;
                    this.allowWatcherViewHidden = defaultCoTuongUp.allowWatcherViewHidden.v;
                    this.allowOnlyFlip = defaultCoTuongUp.allowOnlyFlip.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(defaultCoTuongUp);
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
            if (data is DefaultCoTuongUp)
            {
                // DefaultCoTuongUp defaultCoTuongUp = data as DefaultCoTuongUp;
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
            if (wrapProperty.p is DefaultCoTuongUp)
            {
                switch ((DefaultCoTuongUp.Property)wrapProperty.n)
                {
                    case DefaultCoTuongUp.Property.allowViewCapture:
                        this.allowViewCapture = (bool)wrapProperty.getValue();
                        break;
                    case DefaultCoTuongUp.Property.allowWatcherViewHidden:
                        this.allowWatcherViewHidden = (bool)wrapProperty.getValue();
                        break;
                    case DefaultCoTuongUp.Property.allowOnlyFlip:
                        this.allowOnlyFlip = (bool)wrapProperty.getValue();
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

        #region Change AllowViewCapture

        public void requestChangeAllowViewCapture(uint userId, bool newAllowViewCapture)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdDefaultCoTuongUpChangeAllowViewCapture(this.netId, userId, newAllowViewCapture);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeAllowViewCapture(uint userId, bool newAllowViewCapture)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeAllowViewCapture(userId, newAllowViewCapture);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region Change AllowViewHidden

        public void requestChangeAllowWatcherViewHidden(uint userId, bool newAllowViewHidden)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdDefaultCoTuongUpChangeAllowWatcherViewHidden(this.netId, userId, newAllowViewHidden);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeAllowWatcherViewHidden(uint userId, bool newAllowViewHidden)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeAllowWatcherViewHidden(userId, newAllowViewHidden);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region change allowOnlyFlip

        public void requestChangeAllowOnlyFlip(uint userId, bool newAllowViewFlip)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdDefaultCoTuongUpChangeAllowOnlyFlip(this.netId, userId, newAllowViewFlip);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeAllowViewFlip(uint userId, bool newAllowViewFlip)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeAllowOnlyFlip(userId, newAllowViewFlip);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

    }
}
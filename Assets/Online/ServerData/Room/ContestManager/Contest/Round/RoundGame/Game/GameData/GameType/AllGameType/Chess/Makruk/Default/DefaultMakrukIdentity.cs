using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace Makruk
{
    public class DefaultMakrukIdentity : DataIdentity
    {

        #region SyncVar

        #region chess960

        [SyncVar(hook = "onChangeChess960")]
        public System.Boolean chess960;

        public void onChangeChess960(System.Boolean newChess960)
        {
            this.chess960 = newChess960;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.chess960.v = newChess960;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<DefaultMakruk> netData = new NetData<DefaultMakruk>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeChess960(this.chess960);
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
                ret += GetDataSize(this.chess960);
                return ret;
            }
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is DefaultMakruk)
            {
                DefaultMakruk defaultMakruk = data as DefaultMakruk;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, defaultMakruk.makeSearchInforms());
                    this.chess960 = defaultMakruk.chess960.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(defaultMakruk);
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
            if (data is DefaultMakruk)
            {
                // DefaultMakruk defaultMakruk = data as DefaultMakruk;
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
            if (wrapProperty.p is DefaultMakruk)
            {
                switch ((DefaultMakruk.Property)wrapProperty.n)
                {
                    case DefaultMakruk.Property.chess960:
                        this.chess960 = (System.Boolean)wrapProperty.getValue();
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

        #region Change Chess960

        public void requestChangeChess960(uint userId, bool newChess960)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdDefaultMakrukChangeChess960(this.netId, userId, newChess960);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeChess960(uint userId, bool newChess960)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeChess960(userId, newChess960);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

    }
}
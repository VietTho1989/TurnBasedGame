using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace FairyChess
{
    public class DefaultFairyChessIdentity : DataIdentity
    {

        #region SyncVar

        #region variantType

        [SyncVar(hook = "onChangeVariantType")]
        public Common.VariantType variantType;

        public void onChangeVariantType(Common.VariantType newVariantType)
        {
            this.variantType = newVariantType;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.variantType.v = newVariantType;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

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

        private NetData<DefaultFairyChess> netData = new NetData<DefaultFairyChess>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeVariantType(this.variantType);
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
                ret += GetDataSize(this.variantType);
                ret += GetDataSize(this.chess960);
                return ret;
            }
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is DefaultFairyChess)
            {
                DefaultFairyChess defaultFairyChess = data as DefaultFairyChess;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, defaultFairyChess.makeSearchInforms());
                    this.variantType = defaultFairyChess.variantType.v;
                    this.chess960 = defaultFairyChess.chess960.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(defaultFairyChess);
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
            if (data is DefaultFairyChess)
            {
                // DefaultFairyChess defaultFairyChess = data as DefaultFairyChess;
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
            if (wrapProperty.p is DefaultFairyChess)
            {
                switch ((DefaultFairyChess.Property)wrapProperty.n)
                {
                    case DefaultFairyChess.Property.variantType:
                        this.variantType = (Common.VariantType)wrapProperty.getValue();
                        break;
                    case DefaultFairyChess.Property.chess960:
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

        #region variantType

        public void requestChangeVariantType(uint userId, Common.VariantType newVariantType)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdDefaultFairyChessChangeVariantType(this.netId, userId, newVariantType);
            }
            else
            {
                Debug.LogError("Cannot find clientConnect: " + this);
            }
        }

        public void changeVariantType(uint userId, Common.VariantType newVariantType)
        {
            if (this.netData.serverData != null)
            {
                this.netData.serverData.changeVariantType(userId, newVariantType);
            }
            else
            {
                Debug.LogError("serverData null: " + this);
            }
        }

        #endregion

        #region chess960

        public void requestChangeChess960(uint userId, bool newChess960)
        {
            ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
            if (clientConnect != null)
            {
                clientConnect.CmdDefaultFairyChessChangeChess960(this.netId, userId, newChess960);
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
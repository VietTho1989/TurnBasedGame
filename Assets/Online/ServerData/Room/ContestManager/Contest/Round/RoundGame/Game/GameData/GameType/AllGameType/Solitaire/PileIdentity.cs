using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace Solitaire
{
    public class PileIdentity : DataIdentity
    {

        #region SyncVar

        #region size

        [SyncVar(hook = "onChangeSize")]
        public System.Int32 size;

        public void onChangeSize(System.Int32 newSize)
        {
            this.size = newSize;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.size.v = newSize;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region downSize

        [SyncVar(hook = "onChangeDownSize")]
        public System.Int32 downSize;

        public void onChangeDownSize(System.Int32 newDownSize)
        {
            this.downSize = newDownSize;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.downSize.v = newDownSize;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region upSize

        [SyncVar(hook = "onChangeUpSize")]
        public System.Int32 upSize;

        public void onChangeUpSize(System.Int32 newUpSize)
        {
            this.upSize = newUpSize;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.upSize.v = newUpSize;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<Pile> netData = new NetData<Pile>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeSize(this.size);
                this.onChangeDownSize(this.downSize);
                this.onChangeUpSize(this.upSize);
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
                ret += GetDataSize(this.size);
                ret += GetDataSize(this.downSize);
                ret += GetDataSize(this.upSize);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is Pile)
            {
                Pile pile = data as Pile;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, pile.makeSearchInforms());
                    this.size = pile.size.v;
                    this.downSize = pile.downSize.v;
                    this.upSize = pile.upSize.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(pile);
                    }
                    else
                    {
                        Debug.LogError("observer null: " + this);
                    }
                }
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is Pile)
            {
                // Pile pile = data as Pile;
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.setCheckChangeData(null);
                    }
                    else
                    {
                        Debug.LogError("observer null: " + this);
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
            if (wrapProperty.p is Pile)
            {
                switch ((Pile.Property)wrapProperty.n)
                {
                    case Pile.Property.down:
                        break;
                    case Pile.Property.up:
                        break;
                    case Pile.Property.size:
                        this.size = (System.Int32)wrapProperty.getValue();
                        break;
                    case Pile.Property.downSize:
                        this.downSize = (System.Int32)wrapProperty.getValue();
                        break;
                    case Pile.Property.upSize:
                        this.upSize = (System.Int32)wrapProperty.getValue();
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

    }
}
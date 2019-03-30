using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace InternationalDraught.NoneRule
{
    public class InternationalDraughtCustomFenIdentity : DataIdentity
    {

        #region SyncVar

        #region fen

        [SyncVar(hook = "onChangeFen")]
        public System.String fen;

        public void onChangeFen(System.String newFen)
        {
            this.fen = newFen;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.fen.v = newFen;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<InternationalDraughtCustomFen> netData = new NetData<InternationalDraughtCustomFen>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeFen(this.fen);
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
                ret += GetDataSize(this.fen);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is InternationalDraughtCustomFen)
            {
                InternationalDraughtCustomFen internationalDraughtCustomFen = data as InternationalDraughtCustomFen;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, internationalDraughtCustomFen.makeSearchInforms());
                    this.fen = internationalDraughtCustomFen.fen.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(internationalDraughtCustomFen);
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
            if (data is InternationalDraughtCustomFen)
            {
                // InternationalDraughtCustomFen internationalDraughtCustomFen = data as InternationalDraughtCustomFen;
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
            if (wrapProperty.p is InternationalDraughtCustomFen)
            {
                switch ((InternationalDraughtCustomFen.Property)wrapProperty.n)
                {
                    case InternationalDraughtCustomFen.Property.fen:
                        this.fen = (System.String)wrapProperty.getValue();
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
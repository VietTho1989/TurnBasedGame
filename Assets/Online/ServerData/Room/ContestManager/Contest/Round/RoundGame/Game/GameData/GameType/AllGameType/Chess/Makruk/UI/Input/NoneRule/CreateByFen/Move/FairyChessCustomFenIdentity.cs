using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess.NoneRule
{
    public class FairyChessCustomFenIdentity : DataIdentity
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

        private NetData<FairyChessCustomFen> netData = new NetData<FairyChessCustomFen>();

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
            if (data is FairyChessCustomFen)
            {
                FairyChessCustomFen fairyChessCustomFen = data as FairyChessCustomFen;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, fairyChessCustomFen.makeSearchInforms());
                    this.fen = fairyChessCustomFen.fen.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(fairyChessCustomFen);
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
            if (data is FairyChessCustomFen)
            {
                // FairyChessCustomFen fairyChessCustomFen = data as FairyChessCustomFen;
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
            if (wrapProperty.p is FairyChessCustomFen)
            {
                switch ((FairyChessCustomFen.Property)wrapProperty.n)
                {
                    case FairyChessCustomFen.Property.fen:
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
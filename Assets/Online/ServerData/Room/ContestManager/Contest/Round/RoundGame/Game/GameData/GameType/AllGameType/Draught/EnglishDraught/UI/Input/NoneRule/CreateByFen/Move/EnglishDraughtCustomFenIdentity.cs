using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace EnglishDraught.NoneRule
{
    public class EnglishDraughtCustomFenIdentity : DataIdentity
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

        private NetData<EnglishDraughtCustomFen> netData = new NetData<EnglishDraughtCustomFen>();

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
            if (data is EnglishDraughtCustomFen)
            {
                EnglishDraughtCustomFen englishDraughtCustomFen = data as EnglishDraughtCustomFen;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, englishDraughtCustomFen.makeSearchInforms());
                    this.fen = englishDraughtCustomFen.fen.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(englishDraughtCustomFen);
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
            if (data is EnglishDraughtCustomFen)
            {
                // EnglishDraughtCustomFen englishDraughtCustomFen = data as EnglishDraughtCustomFen;
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
            if (wrapProperty.p is EnglishDraughtCustomFen)
            {
                switch ((EnglishDraughtCustomFen.Property)wrapProperty.n)
                {
                    case EnglishDraughtCustomFen.Property.fen:
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
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace ChineseCheckers
{
    public class ChineseCheckersMoveIdentity : DataIdentity
    {

        #region SyncVar

        #region fromX

        [SyncVar(hook = "onChangeFromX")]
        public System.Int32 fromX;

        public void onChangeFromX(System.Int32 newFromX)
        {
            this.fromX = newFromX;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.fromX.v = newFromX;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region fromY

        [SyncVar(hook = "onChangeFromY")]
        public System.Int32 fromY;

        public void onChangeFromY(System.Int32 newFromY)
        {
            this.fromY = newFromY;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.fromY.v = newFromY;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region toX

        [SyncVar(hook = "onChangeToX")]
        public System.Int32 toX;

        public void onChangeToX(System.Int32 newToX)
        {
            this.toX = newToX;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.toX.v = newToX;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region toY

        [SyncVar(hook = "onChangeToY")]
        public System.Int32 toY;

        public void onChangeToY(System.Int32 newToY)
        {
            this.toY = newToY;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.toY.v = newToY;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<ChineseCheckersMove> netData = new NetData<ChineseCheckersMove>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeFromX(this.fromX);
                this.onChangeFromY(this.fromY);
                this.onChangeToX(this.toX);
                this.onChangeToY(this.toY);
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
                ret += GetDataSize(this.fromX);
                ret += GetDataSize(this.fromY);
                ret += GetDataSize(this.toX);
                ret += GetDataSize(this.toY);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is ChineseCheckersMove)
            {
                ChineseCheckersMove chineseCheckersMove = data as ChineseCheckersMove;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, chineseCheckersMove.makeSearchInforms());
                    this.fromX = chineseCheckersMove.fromX.v;
                    this.fromY = chineseCheckersMove.fromY.v;
                    this.toX = chineseCheckersMove.toX.v;
                    this.toY = chineseCheckersMove.toY.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(chineseCheckersMove);
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
            if (data is ChineseCheckersMove)
            {
                // ChineseCheckersMove chineseCheckersMove = data as ChineseCheckersMove;
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
            if (wrapProperty.p is ChineseCheckersMove)
            {
                switch ((ChineseCheckersMove.Property)wrapProperty.n)
                {
                    case ChineseCheckersMove.Property.fromX:
                        this.fromX = (System.Int32)wrapProperty.getValue();
                        break;
                    case ChineseCheckersMove.Property.fromY:
                        this.fromY = (System.Int32)wrapProperty.getValue();
                        break;
                    case ChineseCheckersMove.Property.toX:
                        this.toX = (System.Int32)wrapProperty.getValue();
                        break;
                    case ChineseCheckersMove.Property.toY:
                        this.toY = (System.Int32)wrapProperty.getValue();
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

    }
}
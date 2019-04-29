using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace Gomoku
{
    public class GomokuMoveIdentity : DataIdentity
    {

        #region SyncVar

        #region move

        [SyncVar(hook = "onChangeMove")]
        public System.Int32 move;

        public void onChangeMove(System.Int32 newMove)
        {
            this.move = newMove;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.move.v = newMove;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region move

        [SyncVar(hook = "onChangeBoardSize")]
        public System.Int32 boardSize;

        public void onChangeBoardSize(System.Int32 newBoardSize)
        {
            this.boardSize = newBoardSize;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.boardSize.v = newBoardSize;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<GomokuMove> netData = new NetData<GomokuMove>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeMove(this.move);
                this.onChangeBoardSize(this.boardSize);
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
                ret += GetDataSize(this.move);
                ret += GetDataSize(this.boardSize);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is GomokuMove)
            {
                GomokuMove gomokuMove = data as GomokuMove;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, gomokuMove.makeSearchInforms());
                    this.move = gomokuMove.move.v;
                    this.boardSize = gomokuMove.boardSize.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(gomokuMove);
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
            if (data is GomokuMove)
            {
                // GomokuMove gomokuMove = data as GomokuMove;
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
            if (wrapProperty.p is GomokuMove)
            {
                switch ((GomokuMove.Property)wrapProperty.n)
                {
                    case GomokuMove.Property.move:
                        this.move = (System.Int32)wrapProperty.getValue();
                        break;
                    case GomokuMove.Property.boardSize:
                        this.boardSize = (System.Int32)wrapProperty.getValue();
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
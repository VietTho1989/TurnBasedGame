using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace HEX
{
    public class HexMoveAnimationIdentity : DataIdentity
    {

        #region SyncVar

        #region boardSize

        [SyncVar(hook = "onChangeBoardSize")]
        public System.UInt16 boardSize;

        public void onChangeBoardSize(System.UInt16 newBoardSize)
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

        #region board

        public SyncListSByte board = new SyncListSByte();

        private void OnBoardChanged(SyncListSByte.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.board, this.board, op, index, MySByte.sbyteConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region move

        [SyncVar(hook = "onChangeMove")]
        public System.UInt16 move;

        public void onChangeMove(System.UInt16 newMove)
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

        #region color

        [SyncVar(hook = "onChangeColor")]
        public HEX.Common.Color color;

        public void onChangeColor(HEX.Common.Color newColor)
        {
            this.color = newColor;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.color.v = newColor;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<HexMoveAnimation> netData = new NetData<HexMoveAnimation>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.board.Callback += OnBoardChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeBoardSize(this.boardSize);
                IdentityUtils.refresh(this.netData.clientData.board, this.board, MySByte.sbyteConvert);
                this.onChangeMove(this.move);
                this.onChangeColor(this.color);
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
                ret += GetDataSize(this.boardSize);
                ret += GetDataSize(this.board);
                ret += GetDataSize(this.move);
                ret += GetDataSize(this.color);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is HexMoveAnimation)
            {
                HexMoveAnimation hexMoveAnimation = data as HexMoveAnimation;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, hexMoveAnimation.makeSearchInforms());
                    this.boardSize = hexMoveAnimation.boardSize.v;
                    IdentityUtils.InitSync(this.board, hexMoveAnimation.board, MySByte.mySByteConvert);
                    this.move = hexMoveAnimation.move.v;
                    this.color = hexMoveAnimation.color.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(hexMoveAnimation);
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
            if (data is HexMoveAnimation)
            {
                // HexMoveAnimation hexMoveAnimation = data as HexMoveAnimation;
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
            if (wrapProperty.p is HexMoveAnimation)
            {
                switch ((HexMoveAnimation.Property)wrapProperty.n)
                {
                    case HexMoveAnimation.Property.boardSize:
                        this.boardSize = (System.UInt16)wrapProperty.getValue();
                        break;
                    case HexMoveAnimation.Property.board:
                        IdentityUtils.UpdateSyncList(this.board, syncs, GlobalCast<T>.CastingMySByte);
                        break;
                    case HexMoveAnimation.Property.move:
                        this.move = (System.UInt16)wrapProperty.getValue();
                        break;
                    case HexMoveAnimation.Property.color:
                        this.color = (HEX.Common.Color)wrapProperty.getValue();
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
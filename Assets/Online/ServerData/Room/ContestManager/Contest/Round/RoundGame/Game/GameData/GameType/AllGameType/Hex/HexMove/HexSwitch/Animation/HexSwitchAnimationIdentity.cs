using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace HEX
{
    public class HexSwitchAnimationIdentity : DataIdentity
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

        #endregion

        #region NetData

        private NetData<HexSwitchAnimation> netData = new NetData<HexSwitchAnimation>();

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
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is HexSwitchAnimation)
            {
                HexSwitchAnimation hexSwitchAnimation = data as HexSwitchAnimation;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, hexSwitchAnimation.makeSearchInforms());
                    this.boardSize = hexSwitchAnimation.boardSize.v;
                    IdentityUtils.InitSync(this.board, hexSwitchAnimation.board, MySByte.mySByteConvert);
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(hexSwitchAnimation);
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
            if (data is HexSwitchAnimation)
            {
                // HexSwitchAnimation hexSwitchAnimation = data as HexSwitchAnimation;
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
            if (wrapProperty.p is HexSwitchAnimation)
            {
                switch ((HexSwitchAnimation.Property)wrapProperty.n)
                {
                    case HexSwitchAnimation.Property.boardSize:
                        this.boardSize = (System.UInt16)wrapProperty.getValue();
                        break;
                    case HexSwitchAnimation.Property.board:
                        IdentityUtils.UpdateSyncList(this.board, syncs, GlobalCast<T>.CastingMySByte);
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
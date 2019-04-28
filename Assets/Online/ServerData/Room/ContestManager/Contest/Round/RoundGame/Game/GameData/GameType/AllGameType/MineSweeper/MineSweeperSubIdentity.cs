using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
    public class MineSweeperSubIdentity : DataIdentity
    {

        #region SyncVar

        #region bombs

        public SyncListSByte bombs = new SyncListSByte();

        private void OnBombsChanged(SyncListSByte.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.bombs, this.bombs, op, index, MySByte.sbyteConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region flags

        public SyncListSByte flags = new SyncListSByte();

        private void OnFlagsChanged(SyncListSByte.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.flags, this.flags, op, index, MySByte.sbyteConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
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

        private NetData<MineSweeperSub> netData = new NetData<MineSweeperSub>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.bombs.Callback += OnBombsChanged;
            this.flags.Callback += OnFlagsChanged;
            this.board.Callback += OnBoardChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData.bombs, this.bombs, MySByte.sbyteConvert);
                IdentityUtils.refresh(this.netData.clientData.flags, this.flags, MySByte.sbyteConvert);
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
                ret += GetDataSize(this.bombs);
                ret += GetDataSize(this.flags);
                ret += GetDataSize(this.board);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is MineSweeperSub)
            {
                MineSweeperSub mineSweeperSub = data as MineSweeperSub;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, mineSweeperSub.makeSearchInforms());
                    IdentityUtils.InitSync(this.bombs, mineSweeperSub.bombs, MySByte.mySByteConvert);
                    IdentityUtils.InitSync(this.flags, mineSweeperSub.flags, MySByte.mySByteConvert);
                    IdentityUtils.InitSync(this.board, mineSweeperSub.board, MySByte.mySByteConvert);
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(mineSweeperSub);
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
            if (data is MineSweeperSub)
            {
                // MineSweeperSub mineSweeperSub = data as MineSweeperSub;
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
            if (wrapProperty.p is MineSweeperSub)
            {
                switch ((MineSweeperSub.Property)wrapProperty.n)
                {
                    case MineSweeperSub.Property.bombs:
                        IdentityUtils.UpdateSyncList(this.bombs, syncs, GlobalCast<T>.CastingMySByte);
                        break;
                    case MineSweeperSub.Property.flags:
                        IdentityUtils.UpdateSyncList(this.flags, syncs, GlobalCast<T>.CastingMySByte);
                        break;
                    case MineSweeperSub.Property.board:
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
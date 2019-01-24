using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
	public class MineSweeperMoveAnimationIdentity : DataIdentity
	{

		#region SyncVar

		#region X

		[SyncVar(hook="onChangeX")]
		public System.Int32 X;

		public void onChangeX(System.Int32 newX)
		{
			this.X = newX;
			if (this.netData.clientData != null) {
				this.netData.clientData.X.v = newX;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region Y

		[SyncVar(hook="onChangeY")]
		public System.Int32 Y;

		public void onChangeY(System.Int32 newY)
		{
			this.Y = newY;
			if (this.netData.clientData != null) {
				this.netData.clientData.Y.v = newY;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region board

		public SyncListSByte board = new SyncListSByte();

		private void OnBoardChanged(SyncListSByte.Operation op, int index, MySByte item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.board, this.board, op, index, MySByte.sbyteConvert);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region bombs

		public SyncListSByte bombs = new SyncListSByte();

		private void OnBombsChanged(SyncListSByte.Operation op, int index, MySByte item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.bombs, this.bombs, op, index, MySByte.sbyteConvert);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region flags

		public SyncListSByte flags = new SyncListSByte();

		private void OnFlagsChanged(SyncListSByte.Operation op, int index, MySByte item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.flags, this.flags, op, index, MySByte.sbyteConvert);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region booom

		[SyncVar(hook="onChangeBooom")]
		public System.Boolean booom;

		public void onChangeBooom(System.Boolean newBooom)
		{
			this.booom = newBooom;
			if (this.netData.clientData != null) {
				this.netData.clientData.booom.v = newBooom;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region move

		[SyncVar(hook="onChangeMove")]
		public System.Int32 move;

		public void onChangeMove(System.Int32 newMove)
		{
			this.move = newMove;
			if (this.netData.clientData != null) {
				this.netData.clientData.move.v = newMove;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<MineSweeperMoveAnimation> netData = new NetData<MineSweeperMoveAnimation>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void addSyncListCallBack ()
		{
			base.addSyncListCallBack ();
			this.board.Callback += OnBoardChanged;
			this.bombs.Callback += OnBombsChanged;
			this.flags.Callback += OnFlagsChanged;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeX(this.X);
				this.onChangeY(this.Y);
				IdentityUtils.refresh(this.netData.clientData.board, this.board, MySByte.sbyteConvert);
				IdentityUtils.refresh(this.netData.clientData.bombs, this.bombs, MySByte.sbyteConvert);
				IdentityUtils.refresh(this.netData.clientData.flags, this.flags, MySByte.sbyteConvert);
				this.onChangeBooom(this.booom);
				this.onChangeMove(this.move);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.X);
				ret += GetDataSize (this.Y);
				ret += GetDataSize (this.board);
				ret += GetDataSize (this.bombs);
				ret += GetDataSize (this.flags);
				ret += GetDataSize (this.booom);
				ret += GetDataSize (this.move);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is MineSweeperMoveAnimation) {
				MineSweeperMoveAnimation mineSweeperMoveAnimation = data as MineSweeperMoveAnimation;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, mineSweeperMoveAnimation.makeSearchInforms ());
					this.X = mineSweeperMoveAnimation.X.v;
					this.Y = mineSweeperMoveAnimation.Y.v;
					IdentityUtils.InitSync(this.board, mineSweeperMoveAnimation.board, MySByte.mySByteConvert);
					IdentityUtils.InitSync(this.bombs, mineSweeperMoveAnimation.bombs, MySByte.mySByteConvert);
					IdentityUtils.InitSync(this.flags, mineSweeperMoveAnimation.flags, MySByte.mySByteConvert);
					this.booom = mineSweeperMoveAnimation.booom.v;
					this.move = mineSweeperMoveAnimation.move.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (mineSweeperMoveAnimation);
					} else {
						Debug.LogError ("observer null");
					}
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is MineSweeperMoveAnimation) {
				// MineSweeperMoveAnimation mineSweeperMoveAnimation = data as MineSweeperMoveAnimation;
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.setCheckChangeData (null);
					} else {
						Debug.LogError ("observer null");
					}
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is MineSweeperMoveAnimation) {
				switch ((MineSweeperMoveAnimation.Property)wrapProperty.n) {
				case MineSweeperMoveAnimation.Property.X:
					this.X = (System.Int32)wrapProperty.getValue ();
					break;
				case MineSweeperMoveAnimation.Property.Y:
					this.Y = (System.Int32)wrapProperty.getValue ();
					break;
				case MineSweeperMoveAnimation.Property.board:
					IdentityUtils.UpdateSyncList (this.board, syncs, GlobalCast<T>.CastingMySByte);
					break;
				case MineSweeperMoveAnimation.Property.bombs:
					IdentityUtils.UpdateSyncList (this.bombs, syncs, GlobalCast<T>.CastingMySByte);
					break;
				case MineSweeperMoveAnimation.Property.flags:
					IdentityUtils.UpdateSyncList (this.flags, syncs, GlobalCast<T>.CastingMySByte);
					break;
				case MineSweeperMoveAnimation.Property.booom:
					this.booom = (System.Boolean)wrapProperty.getValue ();
					break;
				case MineSweeperMoveAnimation.Property.move:
					this.move = (System.Int32)wrapProperty.getValue ();
					break;
				default:
					Debug.LogError ("Unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
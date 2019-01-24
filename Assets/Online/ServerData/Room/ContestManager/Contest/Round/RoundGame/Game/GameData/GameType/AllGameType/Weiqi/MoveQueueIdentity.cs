using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
{
	public class MoveQueueIdentity : DataIdentity
	{

		#region SyncVar

		#region moves

		[SyncVar(hook="onChangeMoves")]
		public System.UInt32 moves;

		public void onChangeMoves(System.UInt32 newMoves)
		{
			this.moves = newMoves;
			if (this.netData.clientData != null) {
				this.netData.clientData.moves.v = newMoves;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region move

		public SyncListInt move = new SyncListInt();

		private void OnMoveChanged(SyncListInt.Operation op, int index, int item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.move, this.move, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region tag

		public SyncListByte bTag = new SyncListByte();

		private void OnTagChanged(SyncListByte.Operation op, int index, MyByte item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.tag, this.bTag, op, index, MyByte.byteConvert);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#endregion

		#region NetData

		private NetData<MoveQueue> netData = new NetData<MoveQueue>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void addSyncListCallBack ()
		{
			base.addSyncListCallBack ();
			this.move.Callback += OnMoveChanged;
			this.bTag.Callback += OnTagChanged;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeMoves(this.moves);
				IdentityUtils.refresh(this.netData.clientData.move, this.move);
				IdentityUtils.refresh(this.netData.clientData.tag, this.bTag, MyByte.byteConvert);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.moves);
				ret += GetDataSize (this.move);
				ret += GetDataSize (this.bTag);
				return ret;
			}
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is MoveQueue) {
				MoveQueue moveQueue = data as MoveQueue;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, moveQueue.makeSearchInforms ());
					this.moves = moveQueue.moves.v;
					IdentityUtils.InitSync(this.move, moveQueue.move.vs);
					IdentityUtils.InitSync(this.bTag, moveQueue.tag, MyByte.myByteConvert);
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (moveQueue);
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
			if (data is MoveQueue) {
				// MoveQueue moveQueue = data as MoveQueue;
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
			if (wrapProperty.p is MoveQueue) {
				switch ((MoveQueue.Property)wrapProperty.n) {
				case MoveQueue.Property.moves:
					this.moves = (System.UInt32)wrapProperty.getValue ();
					break;
				case MoveQueue.Property.move:
					IdentityUtils.UpdateSyncList (this.move, syncs, GlobalCast<T>.CastingInt32);
					break;
				case MoveQueue.Property.tag:
					IdentityUtils.UpdateSyncList (this.bTag, syncs, GlobalCast<T>.CastingMyByte);
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
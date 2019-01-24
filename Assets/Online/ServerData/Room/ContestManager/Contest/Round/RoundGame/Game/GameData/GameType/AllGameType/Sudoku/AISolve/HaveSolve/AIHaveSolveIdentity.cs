using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Sudoku
{
	public class AIHaveSolveIdentity : DataIdentity
	{

		#region SyncVar

		#region board

		public SyncListByte board = new SyncListByte();

		private void OnBoardChanged(SyncListByte.Operation op, int index, MyByte item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.board, this.board, op, index, MyByte.byteConvert);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region order

		public SyncListByte order = new SyncListByte();

		private void OnOrderChanged(SyncListByte.Operation op, int index, MyByte item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.order, this.order, op, index, MyByte.byteConvert);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#endregion

		#region NetData

		private NetData<AIHaveSolve> netData = new NetData<AIHaveSolve>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void addSyncListCallBack ()
		{
			base.addSyncListCallBack ();
			this.board.Callback += OnBoardChanged;
			this.order.Callback += OnOrderChanged;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				IdentityUtils.refresh(this.netData.clientData.board, this.board, MyByte.byteConvert);
				IdentityUtils.refresh(this.netData.clientData.order, this.order, MyByte.byteConvert);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.board);
				ret += GetDataSize (this.order);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is AIHaveSolve) {
				AIHaveSolve aIHaveSolve = data as AIHaveSolve;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, aIHaveSolve.makeSearchInforms ());
					IdentityUtils.InitSync(this.board, aIHaveSolve.board, MyByte.myByteConvert);
					IdentityUtils.InitSync(this.order, aIHaveSolve.order, MyByte.myByteConvert);
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (aIHaveSolve);
					} else {
						Debug.LogError ("observer null: " + this);
					}
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is AIHaveSolve) {
				// AIHaveSolve aIHaveSolve = data as AIHaveSolve;
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.setCheckChangeData (null);
					} else {
						Debug.LogError ("observer null: " + this);
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
			if (wrapProperty.p is AIHaveSolve) {
				switch ((AIHaveSolve.Property)wrapProperty.n) {
				case AIHaveSolve.Property.board:
					IdentityUtils.UpdateSyncList (this.board, syncs, GlobalCast<T>.CastingMyByte);
					break;
				case AIHaveSolve.Property.order:
					IdentityUtils.UpdateSyncList (this.order, syncs, GlobalCast<T>.CastingMyByte);
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
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
	public class MineSweeperMoveIdentity : DataIdentity
	{

		#region SyncVar

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

		#endregion

		#region NetData

		private NetData<MineSweeperMove> netData = new NetData<MineSweeperMove>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeMove (this.move);
				this.onChangeX (this.X);
				this.onChangeY (this.Y);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.move);
				ret += GetDataSize (this.X);
				ret += GetDataSize (this.Y);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is MineSweeperMove) {
				MineSweeperMove mineSweeperMove = data as MineSweeperMove;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, mineSweeperMove.makeSearchInforms ());
					this.move = mineSweeperMove.move.v;
					this.X = mineSweeperMove.X.v;
					this.Y = mineSweeperMove.Y.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (mineSweeperMove);
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
			if (data is MineSweeperMove) {
				// MineSweeperMove mineSweeperMove = data as MineSweeperMove;
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
			if (wrapProperty.p is MineSweeperMove) {
				switch ((MineSweeperMove.Property)wrapProperty.n) {
				case MineSweeperMove.Property.move:
					this.move = (System.Int32)wrapProperty.getValue ();
					break;
				case MineSweeperMove.Property.X:
					this.X = (System.Int32)wrapProperty.getValue ();
					break;
				case MineSweeperMove.Property.Y:
					this.Y = (System.Int32)wrapProperty.getValue ();
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
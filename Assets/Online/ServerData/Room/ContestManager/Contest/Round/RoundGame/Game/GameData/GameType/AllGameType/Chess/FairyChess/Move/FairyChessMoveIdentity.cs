using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess
{
	public class FairyChessMoveIdentity : DataIdentity
	{

		#region move

		[SyncVar(hook="onChangeMove")]
		public System.Int32 move;

		public void onChangeMove(System.Int32 newMove)
		{
			this.move = newMove;
			if (this.netData.clientData != null) {
				this.netData.clientData.move.v = newMove;
			} else {
				// Debug.LogError ("clientData null");
			}
		}

		#endregion

		#region strMove

		[SyncVar(hook="onChangeStrMove")]
		public string strMove;

		public void onChangeStrMove(string newStrMove)
		{
			this.strMove = newStrMove;
			if (this.netData.clientData != null) {
				this.netData.clientData.strMove.v = newStrMove;
			} else {
				// Debug.LogError ("clientData null");
			}
		}

		#endregion

		#region NetData

		private NetData<FairyChessMove> netData = new NetData<FairyChessMove>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeMove(this.move);
				this.onChangeStrMove (this.strMove);
			} else {
				// Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.move);
				ret += GetDataSize (this.strMove);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is FairyChessMove) {
				FairyChessMove fairyChessMove = data as FairyChessMove;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, fairyChessMove.makeSearchInforms ());
					this.move = fairyChessMove.move.v;
					this.strMove = fairyChessMove.strMove.v;
				}
				this.getDataSize ();
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (fairyChessMove);
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
			if (data is FairyChessMove) {
				// FairyChessMove fairyChessMove = data as FairyChessMove;
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
			if (wrapProperty.p is FairyChessMove) {
				switch ((FairyChessMove.Property)wrapProperty.n) {
				case FairyChessMove.Property.move:
					this.move = (int)wrapProperty.getValue ();
					break;
				case FairyChessMove.Property.strMove:
					this.strMove = (string)wrapProperty.getValue ();
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion
	}
}
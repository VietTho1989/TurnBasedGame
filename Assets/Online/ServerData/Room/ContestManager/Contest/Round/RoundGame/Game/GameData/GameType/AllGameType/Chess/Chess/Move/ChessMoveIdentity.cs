using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace Chess
{
	public class ChessMoveIdentity : DataIdentity
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

		#region chess960

		[SyncVar(hook="onChangeChess960")]
		public bool chess960;

		public void onChangeChess960(bool newChess960)
		{
			this.chess960 = newChess960;
			if (this.netData.clientData != null) {
				this.netData.clientData.chess960.v = newChess960;
			} else {
				// Debug.LogError ("clientData null");
			}
		}

		#endregion

		#region NetData

		private NetData<ChessMove> netData = new NetData<ChessMove>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeMove(this.move);
				this.onChangeChess960 (this.chess960);
			} else {
				// Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.move);
				ret += GetDataSize (this.chess960);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is ChessMove) {
				ChessMove chessMove = data as ChessMove;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, chessMove.makeSearchInforms ());
					this.move = chessMove.move.v;
					this.chess960 = chessMove.chess960.v;
				}
				this.getDataSize ();
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (chessMove);
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
			if (data is ChessMove) {
				// ChessMove chessMove = data as ChessMove;
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
			if (wrapProperty.p is ChessMove) {
				switch ((ChessMove.Property)wrapProperty.n) {
				case ChessMove.Property.move:
					this.move = (int)wrapProperty.getValue ();
					break;
				case ChessMove.Property.chess960:
					this.chess960 = (bool)wrapProperty.getValue ();
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
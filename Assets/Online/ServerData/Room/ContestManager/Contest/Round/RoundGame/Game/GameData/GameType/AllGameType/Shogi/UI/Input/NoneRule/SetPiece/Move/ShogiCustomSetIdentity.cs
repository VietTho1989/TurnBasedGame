using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Shogi.NoneRule
{
	public class ShogiCustomSetIdentity : DataIdentity
	{

		#region SyncVar

		#region square

		[SyncVar(hook="onChangeSquare")]
		public Common.Square square;

		public void onChangeSquare(Common.Square newSquare)
		{
			this.square = newSquare;
			if (this.netData.clientData != null) {
				this.netData.clientData.square.v = newSquare;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region piece

		[SyncVar(hook="onChangePiece")]
		public Common.Piece piece;

		public void onChangePiece(Common.Piece newPiece)
		{
			this.piece = newPiece;
			if (this.netData.clientData != null) {
				this.netData.clientData.piece.v = newPiece;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<ShogiCustomSet> netData = new NetData<ShogiCustomSet>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeSquare (this.square);
				this.onChangePiece (this.piece);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.square);
				ret += GetDataSize (this.piece);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is ShogiCustomSet) {
				ShogiCustomSet shogiCustomSet = data as ShogiCustomSet;
				// Set new parent
				this.addTransformToParent ();
				// Set property
				{
					this.serialize (this.searchInfor, shogiCustomSet.makeSearchInforms ());
					this.square = shogiCustomSet.square.v;
					this.piece = shogiCustomSet.piece.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (shogiCustomSet);
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
			if (data is ShogiCustomSet) {
				// ShogiCustomSet shogiCustomSet = data as ShogiCustomSet;
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
			if (wrapProperty.p is ShogiCustomSet) {
				switch ((ShogiCustomSet.Property)wrapProperty.n) {
				case ShogiCustomSet.Property.square:
					this.square = (Common.Square)wrapProperty.getValue ();
					break;
				case ShogiCustomSet.Property.piece:
					this.piece = (Common.Piece)wrapProperty.getValue ();
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
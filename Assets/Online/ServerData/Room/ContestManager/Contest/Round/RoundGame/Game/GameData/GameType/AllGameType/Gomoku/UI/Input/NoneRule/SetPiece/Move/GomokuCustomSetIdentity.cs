using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Gomoku.NoneRule
{
	public class GomokuCustomSetIdentity : DataIdentity
	{

		#region SyncVar

		#region square

		[SyncVar(hook="onChangeSquare")]
		public System.Int32 square;

		public void onChangeSquare(System.Int32 newSquare)
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
		public Common.Type piece;

		public void onChangePiece(Common.Type newPiece)
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

		private NetData<GomokuCustomSet> netData = new NetData<GomokuCustomSet>();

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
			if (data is GomokuCustomSet) {
				GomokuCustomSet gomokuCustomSet = data as GomokuCustomSet;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, gomokuCustomSet.makeSearchInforms ());
					this.square = gomokuCustomSet.square.v;
					this.piece = gomokuCustomSet.piece.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (gomokuCustomSet);
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
			if (data is GomokuCustomSet) {
				// GomokuCustomSet gomokuCustomSet = data as GomokuCustomSet;
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
			if (wrapProperty.p is GomokuCustomSet) {
				switch ((GomokuCustomSet.Property)wrapProperty.n) {
				case GomokuCustomSet.Property.square:
					this.square = (System.Int32)wrapProperty.getValue ();
					break;
				case GomokuCustomSet.Property.piece:
					this.piece = (Common.Type)wrapProperty.getValue ();
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
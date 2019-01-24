using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Reversi.NoneRule
{
	public class ReversiCustomSetIdentity : DataIdentity
	{

		#region SyncVar

		#region square

		[SyncVar(hook="onChangeSquare")]
		public sbyte square;

		public void onChangeSquare(sbyte newSquare)
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
		public int piece;

		public void onChangePiece(int newPiece)
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

		private NetData<ReversiCustomSet> netData = new NetData<ReversiCustomSet>();

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
			if (data is ReversiCustomSet) {
				ReversiCustomSet reversiCustomSet = data as ReversiCustomSet;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, reversiCustomSet.makeSearchInforms ());
					this.square = reversiCustomSet.square.v;
					this.piece = reversiCustomSet.piece.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (reversiCustomSet);
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
			if (data is ReversiCustomSet) {
				// ReversiCustomSet reversiCustomSet = data as ReversiCustomSet;
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
			if (wrapProperty.p is ReversiCustomSet) {
				switch ((ReversiCustomSet.Property)wrapProperty.n) {
				case ReversiCustomSet.Property.square:
					this.square = (sbyte)wrapProperty.getValue ();
					break;
				case ReversiCustomSet.Property.piece:
					this.piece = (int)wrapProperty.getValue ();
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
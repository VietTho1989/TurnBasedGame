using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Shogi.NoneRule
{
	public class ShogiCustomHandIdentity : DataIdentity
	{

		#region SyncVar

		#region piece

		[SyncVar(hook="onChangeHandPiece")]
		public Common.HandPiece handPiece;

		public void onChangeHandPiece(Common.HandPiece newHandPiece)
		{
			this.handPiece = newHandPiece;
			if (this.netData.clientData != null) {
				this.netData.clientData.handPiece.v = newHandPiece;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region color

		[SyncVar(hook="onChangeColor")]
		public Common.Color color;

		public void onChangeColor(Common.Color newColor)
		{
			this.color = newColor;
			if (this.netData.clientData != null) {
				this.netData.clientData.color.v = newColor;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region pieceCount

		[SyncVar(hook="onChangePieceCount")]
		public int pieceCount;

		public void onChangePieceCount(int newPieceCount)
		{
			this.pieceCount = newPieceCount;
			if (this.netData.clientData != null) {
				this.netData.clientData.pieceCount.v = newPieceCount;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<ShogiCustomHand> netData = new NetData<ShogiCustomHand>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeHandPiece (this.handPiece);
				this.onChangeColor (this.color);
				this.onChangePieceCount (this.pieceCount);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.handPiece);
				ret += GetDataSize (this.color);
				ret += GetDataSize (this.pieceCount);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is ShogiCustomHand) {
				ShogiCustomHand shogiCustomHand = data as ShogiCustomHand;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, shogiCustomHand.makeSearchInforms ());
					this.handPiece = shogiCustomHand.handPiece.v;
					this.color = shogiCustomHand.color.v;
					this.pieceCount = shogiCustomHand.pieceCount.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (shogiCustomHand);
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
			if (data is ShogiCustomHand) {
				// ShogiCustomHand shogiCustomHand = data as ShogiCustomHand;
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
			if (wrapProperty.p is ShogiCustomHand) {
				switch ((ShogiCustomHand.Property)wrapProperty.n) {
				case ShogiCustomHand.Property.handPiece:
					this.handPiece = (Common.HandPiece)wrapProperty.getValue ();
					break;
				case ShogiCustomHand.Property.color:
					this.color = (Common.Color)wrapProperty.getValue ();
					break;
				case ShogiCustomHand.Property.pieceCount:
					this.pieceCount = (int)wrapProperty.getValue ();
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
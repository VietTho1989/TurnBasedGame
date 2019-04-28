using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess.NoneRule
{
	public class FairyChessCustomHandIdentity : DataIdentity
	{

		#region SyncVar

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

		#region pieceType

		[SyncVar(hook="onChangePieceType")]
		public Common.PieceType pieceType;

		public void onChangePieceType(Common.PieceType newPieceType)
		{
			this.pieceType = newPieceType;
			if (this.netData.clientData != null) {
				this.netData.clientData.pieceType.v = newPieceType;
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

		private NetData<FairyChessCustomHand> netData = new NetData<FairyChessCustomHand>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeColor (this.color);
				this.onChangePieceType (this.pieceType);
				this.onChangePieceCount (this.pieceCount);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.color);
				ret += GetDataSize (this.pieceType);
				ret += GetDataSize (this.pieceCount);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is FairyChessCustomHand) {
				FairyChessCustomHand fairyChessCustomHand = data as FairyChessCustomHand;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, fairyChessCustomHand.makeSearchInforms ());
					this.color = fairyChessCustomHand.color.v;
					this.pieceType = fairyChessCustomHand.pieceType.v;
					this.pieceCount = fairyChessCustomHand.pieceCount.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (fairyChessCustomHand);
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
			if (data is FairyChessCustomHand) {
				// FairyChessCustomHand fairyChessCustomHand = data as FairyChessCustomHand;
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
			if (wrapProperty.p is FairyChessCustomHand) {
				switch ((FairyChessCustomHand.Property)wrapProperty.n) {
				case FairyChessCustomHand.Property.color:
					this.color = (Common.Color)wrapProperty.getValue ();
					break;
				case FairyChessCustomHand.Property.pieceType:
					this.pieceType = (Common.PieceType)wrapProperty.getValue ();
					break;
				case FairyChessCustomHand.Property.pieceCount:
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
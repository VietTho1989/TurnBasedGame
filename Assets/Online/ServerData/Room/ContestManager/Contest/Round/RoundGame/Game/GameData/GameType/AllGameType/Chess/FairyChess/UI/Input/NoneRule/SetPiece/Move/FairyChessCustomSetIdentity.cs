using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess.NoneRule
{
	public class FairyChessCustomSetIdentity : DataIdentity
	{

		#region SyncVar

		#region x

		[SyncVar(hook="onChangeX")]
		public System.Int32 x;

		public void onChangeX(System.Int32 newX)
		{
			this.x = newX;
			if (this.netData.clientData != null) {
				this.netData.clientData.x.v = newX;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region y

		[SyncVar(hook="onChangeY")]
		public System.Int32 y;

		public void onChangeY(System.Int32 newY)
		{
			this.y = newY;
			if (this.netData.clientData != null) {
				this.netData.clientData.y.v = newY;
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

		#endregion

		#region NetData

		private NetData<FairyChessCustomSet> netData = new NetData<FairyChessCustomSet>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeX(this.x);
				this.onChangeY(this.y);
				this.onChangeColor (this.color);
				this.onChangePieceType (this.pieceType);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.x);
				ret += GetDataSize (this.y);
				ret += GetDataSize (this.color);
				ret += GetDataSize (this.pieceType);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is FairyChessCustomSet) {
				FairyChessCustomSet fairyChessCustomSet = data as FairyChessCustomSet;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, fairyChessCustomSet.makeSearchInforms ());
					this.x = fairyChessCustomSet.x.v;
					this.y = fairyChessCustomSet.y.v;
					this.color = fairyChessCustomSet.color.v;
					this.pieceType = fairyChessCustomSet.pieceType.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (fairyChessCustomSet);
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
			if (data is FairyChessCustomSet) {
				// FairyChessCustomSet fairyChessCustomSet = data as FairyChessCustomSet;
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
			if (wrapProperty.p is FairyChessCustomSet) {
				switch ((FairyChessCustomSet.Property)wrapProperty.n) {
				case FairyChessCustomSet.Property.x:
					this.x = (System.Int32)wrapProperty.getValue ();
					break;
				case FairyChessCustomSet.Property.y:
					this.y = (System.Int32)wrapProperty.getValue ();
					break;
				case FairyChessCustomSet.Property.color:
					this.color = (Common.Color)wrapProperty.getValue ();
					break;
				case FairyChessCustomSet.Property.pieceType:
					this.pieceType = (Common.PieceType)wrapProperty.getValue ();
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
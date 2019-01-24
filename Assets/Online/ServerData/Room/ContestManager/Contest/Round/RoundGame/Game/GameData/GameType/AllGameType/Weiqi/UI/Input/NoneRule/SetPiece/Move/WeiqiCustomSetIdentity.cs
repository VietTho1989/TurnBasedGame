using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi.NoneRule
{
	public class WeiqiCustomSetIdentity : DataIdentity
	{

		#region SyncVar

		#region coord

		[SyncVar(hook="onChangeCoord")]
		public System.Int32 coord;

		public void onChangeCoord(System.Int32 newCoord)
		{
			this.coord = newCoord;
			if (this.netData.clientData != null) {
				this.netData.clientData.coord.v = newCoord;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region piece

		[SyncVar(hook="onChangePiece")]
		public Common.stone piece;

		public void onChangePiece(Common.stone newPiece)
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

		private NetData<WeiqiCustomSet> netData = new NetData<WeiqiCustomSet>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeCoord(this.coord);
				this.onChangePiece(this.piece);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.coord);
				ret += GetDataSize (this.piece);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is WeiqiCustomSet) {
				WeiqiCustomSet weiqiCustomSet = data as WeiqiCustomSet;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, weiqiCustomSet.makeSearchInforms ());
					this.coord = weiqiCustomSet.coord.v;
					this.piece = weiqiCustomSet.piece.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (weiqiCustomSet);
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
			if (data is WeiqiCustomSet) {
				// WeiqiCustomSet weiqiCustomSet = data as WeiqiCustomSet;
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
			if (wrapProperty.p is WeiqiCustomSet) {
				switch ((WeiqiCustomSet.Property)wrapProperty.n) {
				case WeiqiCustomSet.Property.coord:
					this.coord = (System.Int32)wrapProperty.getValue ();
					break;
				case WeiqiCustomSet.Property.piece:
					this.piece = (Common.stone)wrapProperty.getValue ();
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
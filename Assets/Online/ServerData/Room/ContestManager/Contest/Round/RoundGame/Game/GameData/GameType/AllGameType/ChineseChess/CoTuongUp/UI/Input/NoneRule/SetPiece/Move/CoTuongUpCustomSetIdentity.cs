using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace CoTuongUp.NoneRule
{
	public class CoTuongUpCustomSetIdentity : DataIdentity
	{

		#region SyncVar

		#region coord

		[SyncVar(hook="onChangeCoord")]
		public byte coord;

		public void onChangeCoord(byte newCoord)
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
		public byte piece;

		public void onChangePiece(byte newPiece)
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

		private NetData<CoTuongUpCustomSet> netData = new NetData<CoTuongUpCustomSet>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeCoord (this.coord);
				this.onChangePiece (this.piece);
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
			if (data is CoTuongUpCustomSet) {
				CoTuongUpCustomSet coTuongUpCustomSet = data as CoTuongUpCustomSet;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, coTuongUpCustomSet.makeSearchInforms ());
					this.coord = coTuongUpCustomSet.coord.v;
					this.piece = coTuongUpCustomSet.piece.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (coTuongUpCustomSet);
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
			if (data is CoTuongUpCustomSet) {
				// CoTuongUpCustomSet coTuongUpCustomSet = data as CoTuongUpCustomSet;
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
			if (wrapProperty.p is CoTuongUpCustomSet) {
				switch ((CoTuongUpCustomSet.Property)wrapProperty.n) {
				case CoTuongUpCustomSet.Property.coord:
					this.coord = (byte)wrapProperty.getValue ();
					break;
				case CoTuongUpCustomSet.Property.piece:
					this.piece = (byte)wrapProperty.getValue ();
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
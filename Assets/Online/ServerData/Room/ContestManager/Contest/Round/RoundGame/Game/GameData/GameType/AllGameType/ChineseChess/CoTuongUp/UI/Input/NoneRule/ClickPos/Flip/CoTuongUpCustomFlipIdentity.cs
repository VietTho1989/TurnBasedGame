using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace CoTuongUp.NoneRule
{
	public class CoTuongUpCustomFlipIdentity : DataIdentity
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

		#endregion

		#region NetData

		private NetData<CoTuongUpCustomFlip> netData = new NetData<CoTuongUpCustomFlip>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeCoord (this.coord);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.coord);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is CoTuongUpCustomFlip) {
				CoTuongUpCustomFlip coTuongUpCustomFlip = data as CoTuongUpCustomFlip;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, coTuongUpCustomFlip.makeSearchInforms ());
					this.coord = coTuongUpCustomFlip.coord.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (coTuongUpCustomFlip);
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
			if (data is CoTuongUpCustomFlip) {
				// CoTuongUpCustomFlip coTuongUpCustomFlip = data as CoTuongUpCustomFlip;
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
			if (wrapProperty.p is CoTuongUpCustomFlip) {
				switch ((CoTuongUpCustomFlip.Property)wrapProperty.n) {
				case CoTuongUpCustomFlip.Property.coord:
					this.coord = (byte)wrapProperty.getValue ();
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
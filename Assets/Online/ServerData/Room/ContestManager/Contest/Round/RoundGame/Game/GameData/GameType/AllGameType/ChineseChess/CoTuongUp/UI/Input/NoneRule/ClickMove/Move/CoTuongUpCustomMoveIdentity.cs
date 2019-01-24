using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace CoTuongUp.NoneRule
{
	public class CoTuongUpCustomMoveIdentity : DataIdentity
	{

		#region SyncVar

		#region from

		[SyncVar(hook="onChangeFrom")]
		public byte from;

		public void onChangeFrom(byte newFrom)
		{
			this.from = newFrom;
			if (this.netData.clientData != null) {
				this.netData.clientData.from.v = newFrom;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region dest

		[SyncVar(hook="onChangeDest")]
		public byte dest;

		public void onChangeDest(byte newDest)
		{
			this.dest = newDest;
			if (this.netData.clientData != null) {
				this.netData.clientData.dest.v = newDest;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<CoTuongUpCustomMove> netData = new NetData<CoTuongUpCustomMove>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeFrom(this.from);
				this.onChangeDest(this.dest);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.from);
				ret += GetDataSize (this.dest);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is CoTuongUpCustomMove) {
				CoTuongUpCustomMove coTuongUpCustomMove = data as CoTuongUpCustomMove;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, coTuongUpCustomMove.makeSearchInforms ());
					this.from = coTuongUpCustomMove.from.v;
					this.dest = coTuongUpCustomMove.dest.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (coTuongUpCustomMove);
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
			if (data is CoTuongUpCustomMove) {
				// CoTuongUpCustomMove coTuongUpCustomMove = data as CoTuongUpCustomMove;
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
			if (wrapProperty.p is CoTuongUpCustomMove) {
				switch ((CoTuongUpCustomMove.Property)wrapProperty.n) {
				case CoTuongUpCustomMove.Property.from:
					this.from = (byte)wrapProperty.getValue ();
					break;
				case CoTuongUpCustomMove.Property.dest:
					this.dest = (byte)wrapProperty.getValue ();
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
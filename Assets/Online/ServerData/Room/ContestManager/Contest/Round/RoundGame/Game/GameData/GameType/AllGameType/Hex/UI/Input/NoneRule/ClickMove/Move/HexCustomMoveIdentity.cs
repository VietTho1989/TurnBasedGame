using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace HEX.NoneRule
{
	public class HexCustomMoveIdentity : DataIdentity
	{

		#region SyncVar

		#region from

		[SyncVar(hook="onChangeFrom")]
		public ushort from;

		public void onChangeFrom(ushort newFrom)
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
		public ushort dest;

		public void onChangeDest(ushort newDest)
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

		private NetData<HexCustomMove> netData = new NetData<HexCustomMove>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeFrom (this.from);
				this.onChangeDest (this.dest);
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
			if (data is HexCustomMove) {
				HexCustomMove hexCustomMove = data as HexCustomMove;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, hexCustomMove.makeSearchInforms ());
					this.from = hexCustomMove.from.v;
					this.dest = hexCustomMove.dest.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (hexCustomMove);
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
			if (data is HexCustomMove) {
				// HexCustomMove hexCustomMove = data as HexCustomMove;
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
			if (wrapProperty.p is HexCustomMove) {
				switch ((HexCustomMove.Property)wrapProperty.n) {
				case HexCustomMove.Property.from:
					this.from = (ushort)wrapProperty.getValue ();
					break;
				case HexCustomMove.Property.dest:
					this.dest = (ushort)wrapProperty.getValue ();
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
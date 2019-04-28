using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi.NoneRule
{
	public class WeiqiCustomMoveIdentity : DataIdentity
	{

		#region SyncVar

		#region fromX

		[SyncVar(hook="onChangeFrom")]
		public System.Int32 from;

		public void onChangeFrom(System.Int32 newFrom)
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
		public System.Int32 dest;

		public void onChangeDest(System.Int32 newDest)
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

		private NetData<WeiqiCustomMove> netData = new NetData<WeiqiCustomMove>();

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
			if (data is WeiqiCustomMove) {
				WeiqiCustomMove weiqiCustomMove = data as WeiqiCustomMove;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, weiqiCustomMove.makeSearchInforms ());
					this.from = weiqiCustomMove.from.v;
					this.dest = weiqiCustomMove.dest.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (weiqiCustomMove);
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
			if (data is WeiqiCustomMove) {
				// WeiqiCustomMove weiqiCustomMove = data as WeiqiCustomMove;
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
			if (wrapProperty.p is WeiqiCustomMove) {
				switch ((WeiqiCustomMove.Property)wrapProperty.n) {
				case WeiqiCustomMove.Property.from:
					this.from = (System.Int32)wrapProperty.getValue ();
					break;
				case WeiqiCustomMove.Property.dest:
					this.dest = (System.Int32)wrapProperty.getValue ();
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
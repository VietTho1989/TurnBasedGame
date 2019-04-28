using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Khet.NoneRule
{
	public class KhetCustomRotateIdentity : DataIdentity
	{

		#region SyncVar

		#region position

		[SyncVar(hook="onChangePosition")]
		public System.Int32 position;

		public void onChangePosition(System.Int32 newPosition)
		{
			this.position = newPosition;
			if (this.netData.clientData != null) {
				this.netData.clientData.position.v = newPosition;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region isAdd

		[SyncVar(hook="onChangeIsAdd")]
		public System.Boolean isAdd;

		public void onChangeIsAdd(System.Boolean newIsAdd)
		{
			this.isAdd = newIsAdd;
			if (this.netData.clientData != null) {
				this.netData.clientData.isAdd.v = newIsAdd;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<KhetCustomRotate> netData = new NetData<KhetCustomRotate>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangePosition(this.position);
				this.onChangeIsAdd(this.isAdd);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.position);
				ret += GetDataSize (this.isAdd);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is KhetCustomRotate) {
				KhetCustomRotate khetCustomRotate = data as KhetCustomRotate;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, khetCustomRotate.makeSearchInforms ());
					this.position = khetCustomRotate.position.v;
					this.isAdd = khetCustomRotate.isAdd.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (khetCustomRotate);
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
			if (data is KhetCustomRotate) {
				// KhetCustomRotate khetCustomRotate = data as KhetCustomRotate;
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
			if (wrapProperty.p is KhetCustomRotate) {
				switch ((KhetCustomRotate.Property)wrapProperty.n) {
				case KhetCustomRotate.Property.position:
					this.position = (System.Int32)wrapProperty.getValue ();
					break;
				case KhetCustomRotate.Property.isAdd:
					this.isAdd = (System.Boolean)wrapProperty.getValue ();
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
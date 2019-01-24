using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Rights
{
	public class HaveLimitIdentity : DataIdentity
	{

		#region SyncVar

		#region limit

		[SyncVar(hook="onChangeLimit")]
		public System.Int32 limit;

		public void onChangeLimit(System.Int32 newLimit)
		{
			this.limit = newLimit;
			if (this.netData.clientData != null) {
				this.netData.clientData.limit.v = newLimit;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<HaveLimit> netData = new NetData<HaveLimit>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeLimit(this.limit);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.limit);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is HaveLimit) {
				HaveLimit haveLimit = data as HaveLimit;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, haveLimit.makeSearchInforms ());
					this.limit = haveLimit.limit.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (haveLimit);
					} else {
						Debug.LogError ("observer null");
					}
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is HaveLimit) {
				// HaveLimit haveLimit = data as HaveLimit;
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.setCheckChangeData (null);
					} else {
						Debug.LogError ("observer null");
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
			if (wrapProperty.p is HaveLimit) {
				switch ((HaveLimit.Property)wrapProperty.n) {
				case HaveLimit.Property.limit:
					this.limit = (System.Int32)wrapProperty.getValue ();
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

		#region limit

		public void requestChangeLimit(uint userId, int newLimit)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdRightsHaveLimitChangeLimit (this.netId, userId, newLimit);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeLimit(uint userId, int newLimit){
			if (this.netData.serverData != null) {
				this.netData.serverData.changeLimit (userId, newLimit);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}
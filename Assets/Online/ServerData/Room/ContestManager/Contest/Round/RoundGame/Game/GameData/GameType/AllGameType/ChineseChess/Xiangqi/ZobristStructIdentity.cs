using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Xiangqi
{
	public class ZobristStructIdentity : DataIdentity
	{

		#region SyncVar

		#region dwKey

		[SyncVar(hook="onChangeDwKey")]
		public System.UInt32 dwKey;

		public void onChangeDwKey(System.UInt32 newDwKey)
		{
			this.dwKey = newDwKey;
			if (this.netData.clientData != null) {
				this.netData.clientData.dwKey.v = newDwKey;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region dwLock0

		[SyncVar(hook="onChangeDwLock0")]
		public System.UInt32 dwLock0;

		public void onChangeDwLock0(System.UInt32 newDwLock0)
		{
			this.dwLock0 = newDwLock0;
			if (this.netData.clientData != null) {
				this.netData.clientData.dwLock0.v = newDwLock0;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region dwLock1

		[SyncVar(hook="onChangeDwLock1")]
		public System.UInt32 dwLock1;

		public void onChangeDwLock1(System.UInt32 newDwLock1)
		{
			this.dwLock1 = newDwLock1;
			if (this.netData.clientData != null) {
				this.netData.clientData.dwLock1.v = newDwLock1;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<ZobristStruct> netData = new NetData<ZobristStruct>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeDwKey(this.dwKey);
				this.onChangeDwLock0(this.dwLock0);
				this.onChangeDwLock1(this.dwLock1);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.dwKey);
				ret += GetDataSize (this.dwLock0);
				ret += GetDataSize (this.dwLock1);
				return ret;
			}
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is ZobristStruct) {
				ZobristStruct zobristStruct = data as ZobristStruct;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, zobristStruct.makeSearchInforms ());
					this.dwKey = zobristStruct.dwKey.v;
					this.dwLock0 = zobristStruct.dwLock0.v;
					this.dwLock1 = zobristStruct.dwLock1.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (zobristStruct);
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
			if (data is ZobristStruct) {
				// ZobristStruct zobristStruct = data as ZobristStruct;
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
			if (wrapProperty.p is ZobristStruct) {
				switch ((ZobristStruct.Property)wrapProperty.n) {
				case ZobristStruct.Property.dwKey:
					this.dwKey = (System.UInt32)wrapProperty.getValue ();
					break;
				case ZobristStruct.Property.dwLock0:
					this.dwLock0 = (System.UInt32)wrapProperty.getValue ();
					break;
				case ZobristStruct.Property.dwLock1:
					this.dwLock1 = (System.UInt32)wrapProperty.getValue ();
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
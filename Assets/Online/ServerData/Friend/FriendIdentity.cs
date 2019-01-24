using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class FriendIdentity : DataIdentity
{
	#region SyncVar

	[SyncVar(hook="onChangeTime")]
	public System.Int64 time;

	public void onChangeTime(System.Int64 newTime)
	{
		this.time = newTime;
		if (this.netData.clientData != null) {
			this.netData.clientData.time.v = newTime;
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	#endregion

	#region NetData

	private NetData<Friend> netData = new NetData<Friend>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void addSyncListCallBack ()
	{
		base.addSyncListCallBack ();
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeTime(this.time);
		} else {
			// Debug.Log ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += GetDataSize (this.time);
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is Friend) {
			Friend friend = data as Friend;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, friend.makeSearchInforms ());
				this.time = friend.time.v;
			}
			this.getDataSize ();
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FriendObserver (observer);
					observer.setCheckChangeData (friend);
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
		if (data is Friend) {
			// Friend friend = data as Friend;
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
		if (wrapProperty.p is Friend) {
			switch ((Friend.Property)wrapProperty.n) {
			case Friend.Property.state:
				break;
			case Friend.Property.user1:
				break;
			case Friend.Property.user2:
				break;
			case Friend.Property.time:
				this.time = (long)wrapProperty.getValue ();
				break;
			case Friend.Property.chatRoom:
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
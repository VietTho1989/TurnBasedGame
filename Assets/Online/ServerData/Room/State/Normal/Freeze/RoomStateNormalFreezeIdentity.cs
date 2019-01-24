using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class RoomStateNormalFreezeIdentity : DataIdentity
{

	#region SyncVar

	#endregion

	#region NetData

	private NetData<RoomStateNormalFreeze> netData = new NetData<RoomStateNormalFreeze>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
		} else {
			Debug.Log ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is RoomStateNormalFreeze) {
			RoomStateNormalFreeze roomStateNormalFreeze = data as RoomStateNormalFreeze;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, roomStateNormalFreeze.makeSearchInforms ());
			}
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (roomStateNormalFreeze);
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
		if (data is RoomStateNormalFreeze) {
			// RoomStateNormalFreeze roomStateNormalFreeze = data as RoomStateNormalFreeze;
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
		if (wrapProperty.p is RoomStateNormalFreeze) {
			switch ((RoomStateNormalFreeze.Property)wrapProperty.n) {
			default:
				Debug.LogError ("Unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	#region unfreeze

	public void requestUnFreeze(uint userId)
	{
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdRoomStateNormalFreezeUnFreeze (this.netId, userId);
		} else {
			Debug.LogError ("Cannot find clientConnect: " + this);
		}
	}

	public void unFreeze(uint userId)
	{
		if (this.netData.serverData != null) {
			this.netData.serverData.unFreeze(userId);
		} else {
			Debug.LogError ("serverData null: " + this);
		}
	}

	#endregion

}
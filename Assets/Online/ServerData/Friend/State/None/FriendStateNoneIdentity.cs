using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class FriendStateNoneIdentity : DataIdentity
{

	#region SyncVar

	#endregion

	#region NetData

	private NetData<FriendStateNone> netData = new NetData<FriendStateNone>();

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
		if (data is FriendStateNone) {
			FriendStateNone friendStateNone = data as FriendStateNone;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, friendStateNone.makeSearchInforms ());
			}
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (friendStateNone);
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
		if (data is FriendStateNone) {
			// FriendStateNone friendStateNone = data as FriendStateNone;
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
		if (wrapProperty.p is FriendStateNone) {
			switch ((FriendStateNone.Property)wrapProperty.n) {
			default:
				Debug.LogError ("Unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	#region MakeFriend

	public void requestMakeFriend(uint userId)
	{
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdFriendStateNoneMakeFriend (this.netId, userId);
		} else {
			Debug.LogError ("Cannot find clientConnect: " + this);
		}
	}

	public void makeFriend(uint userId){
		if (this.netData.serverData != null) {
			this.netData.serverData.makeFriend (userId);
		} else {
			Debug.LogError ("serverData null: " + this);
		}
	}

	#endregion

	#region Ban

	public void requestBan(uint userId)
	{
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdFriendStateNoneBan (this.netId, userId);
		} else {
			Debug.LogError ("Cannot find clientConnect: " + this);
		}
	}

	public void ban(uint userId){
		if (this.netData.serverData != null) {
			this.netData.serverData.ban (userId);
		} else {
			Debug.LogError ("serverData null: " + this);
		}
	}

	#endregion

}
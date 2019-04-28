using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class FriendStateBanIdentity : DataIdentity
{

	#region SyncVar

	#region userId

	[SyncVar(hook="onChangeUserId")]
	public System.UInt32 userId;

	public void onChangeUserId(System.UInt32 newUserId)
	{
		this.userId = newUserId;
		if (this.netData.clientData != null) {
			this.netData.clientData.userId.v = newUserId;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#endregion

	#region NetData

	private NetData<FriendStateBan> netData = new NetData<FriendStateBan>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeUserId(this.userId);
		} else {
			Debug.Log ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += GetDataSize (this.userId);
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is FriendStateBan) {
			FriendStateBan friendStateBan = data as FriendStateBan;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, friendStateBan.makeSearchInforms ());
				this.userId = friendStateBan.userId.v;
			}
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (friendStateBan);
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
		if (data is FriendStateBan) {
			// FriendStateBan friendStateBan = data as FriendStateBan;
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
		if (wrapProperty.p is FriendStateBan) {
			switch ((FriendStateBan.Property)wrapProperty.n) {
			case FriendStateBan.Property.userId:
				this.userId = (System.UInt32)wrapProperty.getValue ();
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

	#region UnBan

	public void requestUnBan(uint userId)
	{
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdFriendStateBanUnBan (this.netId, userId);
		} else {
			Debug.LogError ("Cannot find clientConnect: " + this);
		}
	}

	public void unBan(uint userId){
		if (this.netData.serverData != null) {
			this.netData.serverData.unBan (userId);
		} else {
			Debug.LogError ("serverData null: " + this);
		}
	}

	#endregion

}
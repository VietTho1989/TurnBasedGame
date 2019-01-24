using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

// TODO Tam bo [NetworkSettings(channel = Constants.ChatChanel)]
public class FriendStateChangeContentIdentity : DataIdentity
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

	#region action

	[SyncVar(hook="onChangeAction")]
	public FriendStateChangeContent.Action action;

	public void onChangeAction(FriendStateChangeContent.Action newAction)
	{
		this.action = newAction;
		if (this.netData.clientData != null) {
			this.netData.clientData.action.v = newAction;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#endregion

	#region NetData

	private NetData<FriendStateChangeContent> netData = new NetData<FriendStateChangeContent>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeUserId(this.userId);
			this.onChangeAction(this.action);
		} else {
			Debug.Log ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += GetDataSize (this.userId);
			ret += GetDataSize (this.action);
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is FriendStateChangeContent) {
			FriendStateChangeContent friendStateChangeContent = data as FriendStateChangeContent;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, friendStateChangeContent.makeSearchInforms ());
				this.userId = friendStateChangeContent.userId.v;
				this.action = friendStateChangeContent.action.v;
			}
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (friendStateChangeContent);
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
		if (data is FriendStateChangeContent) {
			// FriendStateChangeContent friendStateChangeContent = data as FriendStateChangeContent;
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
		if (wrapProperty.p is FriendStateChangeContent) {
			switch ((FriendStateChangeContent.Property)wrapProperty.n) {
			case FriendStateChangeContent.Property.userId:
				this.userId = (System.UInt32)wrapProperty.getValue ();
				break;
			case FriendStateChangeContent.Property.action:
				this.action = (FriendStateChangeContent.Action)wrapProperty.getValue ();
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
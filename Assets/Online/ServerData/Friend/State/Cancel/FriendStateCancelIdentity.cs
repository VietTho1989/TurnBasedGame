using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class FriendStateCancelIdentity : DataIdentity
{

	#region SyncVar

	#region state

	[SyncVar(hook="onChangeState")]
	public FriendStateCancel.State state;

	public void onChangeState(FriendStateCancel.State newState)
	{
		this.state = newState;
		if (this.netData.clientData != null) {
			this.netData.clientData.state.v = newState;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#endregion

	#region NetData

	private NetData<FriendStateCancel> netData = new NetData<FriendStateCancel>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeState(this.state);
		} else {
			Debug.Log ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += GetDataSize (this.state);
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is FriendStateCancel) {
			FriendStateCancel friendStateCancel = data as FriendStateCancel;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, friendStateCancel.makeSearchInforms ());
				this.state = friendStateCancel.state.v;
			}
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (friendStateCancel);
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
		if (data is FriendStateCancel) {
			// FriendStateCancel friendStateCancel = data as FriendStateCancel;
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
		if (wrapProperty.p is FriendStateCancel) {
			switch ((FriendStateCancel.Property)wrapProperty.n) {
			case FriendStateCancel.Property.state:
				this.state = (FriendStateCancel.State)wrapProperty.getValue ();
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
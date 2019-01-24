using UnityEngine;
using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;

public class UserStateIdentity : DataIdentity
{

	#region SyncVar

	#region state

	[SyncVar(hook="onChangeState")]
	public UserState.State state;

	public void onChangeState(UserState.State newState)
	{
		this.state = newState;
		if (this.netData.clientData != null) {
			this.netData.clientData.state.v = newState;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#region hide

	[SyncVar(hook="onChangeHide")]
	public System.Boolean hide;

	public void onChangeHide(System.Boolean newHide)
	{
		this.hide = newHide;
		if (this.netData.clientData != null) {
			this.netData.clientData.hide.v = newHide;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#region time

	[SyncVar(hook="onChangeTime")]
	public System.Int64 time;

	public void onChangeTime(System.Int64 newTime)
	{
		this.time = newTime;
		if (this.netData.clientData != null) {
			this.netData.clientData.time.v = newTime;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#endregion

	#region NetData

	private NetData<UserState> netData = new NetData<UserState>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeState(this.state);
			this.onChangeHide(this.hide);
			this.onChangeTime(this.time);
		} else {
			Debug.Log ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += GetDataSize (this.state);
			ret += GetDataSize (this.hide);
			ret += GetDataSize (this.time);
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is UserState) {
			UserState userState = data as UserState;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, userState.makeSearchInforms ());
				this.state = userState.state.v;
				this.hide = userState.hide.v;
				this.time = userState.time.v;
			}
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (userState);
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
		if (data is UserState) {
			// UserState userState = data as UserState;
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
		if (wrapProperty.p is UserState) {
			switch ((UserState.Property)wrapProperty.n) {
			case UserState.Property.state:
				this.state = (UserState.State)wrapProperty.getValue ();
				break;
			case UserState.Property.hide:
				this.hide = (System.Boolean)wrapProperty.getValue ();
				break;
			case UserState.Property.time:
				this.time = (System.Int64)wrapProperty.getValue ();
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
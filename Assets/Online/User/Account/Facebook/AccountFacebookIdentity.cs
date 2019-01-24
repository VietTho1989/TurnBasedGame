using UnityEngine;
using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;

public class AccountFacebookIdentity : DataIdentity
{

	#region SyncVar

	#region userId

	[SyncVar(hook="onChangeUserId")]
	public System.String userId;

	public void onChangeUserId(System.String newUserId)
	{
		this.userId = newUserId;
		if (this.netData.clientData != null) {
			this.netData.clientData.userId.v = newUserId;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#region firstName

	[SyncVar(hook="onChangeFirstName")]
	public System.String firstName;

	public void onChangeFirstName(System.String newFirstName)
	{
		this.firstName = newFirstName;
		if (this.netData.clientData != null) {
			this.netData.clientData.firstName.v = newFirstName;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#region lastName

	[SyncVar(hook="onChangeLastName")]
	public System.String lastName;

	public void onChangeLastName(System.String newLastName)
	{
		this.lastName = newLastName;
		if (this.netData.clientData != null) {
			this.netData.clientData.lastName.v = newLastName;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#endregion

	#region NetData

	private NetData<AccountFacebook> netData = new NetData<AccountFacebook>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeUserId(this.userId);
			this.onChangeFirstName(this.firstName);
			this.onChangeLastName(this.lastName);
		} else {
			Debug.Log ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += GetDataSize (this.userId);
			ret += GetDataSize (this.firstName);
			ret += GetDataSize (this.lastName);
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is AccountFacebook) {
			AccountFacebook accountFacebook = data as AccountFacebook;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, accountFacebook.makeSearchInforms ());
				this.userId = accountFacebook.userId.v;
				this.firstName = accountFacebook.firstName.v;
				this.lastName = accountFacebook.lastName.v;
			}
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (accountFacebook);
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
		if (data is AccountFacebook) {
			// AccountFacebook accountFacebook = data as AccountFacebook;
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
		if (wrapProperty.p is AccountFacebook) {
			switch ((AccountFacebook.Property)wrapProperty.n) {
			case AccountFacebook.Property.userId:
				this.userId = (System.String)wrapProperty.getValue ();
				break;
			case AccountFacebook.Property.firstName:
				this.firstName = (System.String)wrapProperty.getValue ();
				break;
			case AccountFacebook.Property.lastName:
				this.lastName = (System.String)wrapProperty.getValue ();
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
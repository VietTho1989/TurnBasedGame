using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

public class AccountAdminIdentity : DataIdentity
{

	#region SyncVar

	#region customName

	[SyncVar(hook="onChangeCustomName")]
	public System.String customName;

	public void onChangeCustomName(System.String newCustomName)
	{
		this.customName = newCustomName;
		if (this.netData.clientData != null) {
			this.netData.clientData.customName.v = newCustomName;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#region avatarUrl

	[SyncVar(hook="onChangeAvatarUrl")]
	public System.String avatarUrl;

	public void onChangeAvatarUrl(System.String newAvatarUrl)
	{
		this.avatarUrl = newAvatarUrl;
		if (this.netData.clientData != null) {
			this.netData.clientData.avatarUrl.v = newAvatarUrl;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#endregion

	#region NetData

	private NetData<AccountAdmin> netData = new NetData<AccountAdmin>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeCustomName(this.customName);
			this.onChangeAvatarUrl(this.avatarUrl);
		} else {
			Debug.Log ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += GetDataSize (this.customName);
			ret += GetDataSize (this.avatarUrl);
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is AccountAdmin) {
			AccountAdmin accountAdmin = data as AccountAdmin;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, accountAdmin.makeSearchInforms ());
				this.customName = accountAdmin.customName.v;
				this.avatarUrl = accountAdmin.avatarUrl.v;
			}
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (accountAdmin);
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
		if (data is AccountAdmin) {
			// AccountAdmin accountAdmin = data as AccountAdmin;
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
		if (wrapProperty.p is AccountAdmin) {
			switch ((AccountAdmin.Property)wrapProperty.n) {
			case AccountAdmin.Property.customName:
				this.customName = (System.String)wrapProperty.getValue ();
				break;
			case AccountAdmin.Property.avatarUrl:
				this.avatarUrl = (System.String)wrapProperty.getValue ();
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

	#region customName

	/**
	 * Client request
	 * */
	public void requestChangeCustomName(uint userId, string newCustomName){
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdAccountAdminChangeCustomName (this.netId, userId, newCustomName);
		} else {
			Debug.LogError ("Cannot find clientConnect: " + this);
		}
	}

	/**
	* Server process
	 * */
	public void changeCustomName(uint userId, string newCustomName){
		if (this.netData.serverData != null) {
			this.netData.serverData.changeCustomName (userId, newCustomName);
		} else {
			Debug.LogError ("serverData null: " + this);
		}
	}

	#endregion

	#region avatarUrl

	/**
	 * Client request
	 * */
	public void requestChangeAvatarUrl(uint userId, string newAvatarUrl){
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdAccountAdminChangeAvatarUrl (this.netId, userId, newAvatarUrl);
		} else {
			Debug.LogError ("Cannot find clientConnect: " + this);
		}
	}

	/**
	* Server process
	 * */
	public void changeAvatarUrl(uint userId, string newAvatarUrl){
		if (this.netData.serverData != null) {
			this.netData.serverData.changeAvatarUrl (userId, newAvatarUrl);
		} else {
			Debug.LogError ("serverData null: " + this);
		}
	}

	#endregion

}
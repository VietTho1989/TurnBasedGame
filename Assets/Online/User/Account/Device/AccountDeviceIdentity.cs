using UnityEngine;
using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;

public class AccountDeviceIdentity : DataIdentity
{

	#region SyncVar

	#region imei

	[SyncVar(hook="onChangeImei")]
	public System.String imei;

	public void onChangeImei(System.String newImei)
	{
		this.imei = newImei;
		if (this.netData.clientData != null) {
			this.netData.clientData.imei.v = newImei;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#region deviceName

	[SyncVar(hook="onChangeDeviceName")]
	public System.String deviceName;

	public void onChangeDeviceName(System.String newDeviceName)
	{
		this.deviceName = newDeviceName;
		if (this.netData.clientData != null) {
			this.netData.clientData.deviceName.v = newDeviceName;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#region deviceType

	[SyncVar(hook="onChangeDeviceType")]
	public System.Int32 deviceType;

	public void onChangeDeviceType(System.Int32 newDeviceType)
	{
		this.deviceType = newDeviceType;
		if (this.netData.clientData != null) {
			this.netData.clientData.deviceType.v = newDeviceType;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

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

	private NetData<AccountDevice> netData = new NetData<AccountDevice>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeImei(this.imei);
			this.onChangeDeviceName(this.deviceName);
			this.onChangeDeviceType (this.deviceType);
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
			ret += GetDataSize (this.imei);
			ret += GetDataSize (this.deviceName);
			ret += GetDataSize (this.deviceType);
			ret += GetDataSize (this.customName);
			ret += GetDataSize (this.avatarUrl);
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is AccountDevice) {
			AccountDevice accountDevice = data as AccountDevice;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, accountDevice.makeSearchInforms ());
				this.imei = accountDevice.imei.v;
				this.deviceName = accountDevice.deviceName.v;
				this.deviceType = accountDevice.deviceType.v;
				this.customName = accountDevice.customName.v;
				this.avatarUrl = accountDevice.avatarUrl.v;
			}
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (accountDevice);
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
		if (data is AccountDevice) {
			// AccountDevice accountDevice = data as AccountDevice;
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
		if (wrapProperty.p is AccountDevice) {
			switch ((AccountDevice.Property)wrapProperty.n) {
			case AccountDevice.Property.imei:
				this.imei = (System.String)wrapProperty.getValue ();
				break;
			case AccountDevice.Property.deviceName:
				this.deviceName = (System.String)wrapProperty.getValue ();
				break;
			case AccountDevice.Property.deviceType:
				this.deviceType = (System.Int32)wrapProperty.getValue ();
				break;
			case AccountDevice.Property.customName:
				this.customName = (System.String)wrapProperty.getValue ();
				break;
			case AccountDevice.Property.avatarUrl:
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
			clientConnect.CmdAccountDeviceChangeCustomName (this.netId, userId, newCustomName);
		} else {
			Debug.LogError ("Cannot find userIdentity: " + this);
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
			clientConnect.CmdAccountDeviceChangeAvatarUrl (this.netId, userId, newAvatarUrl);
		} else {
			Debug.LogError ("Cannot find userIdentity: " + this);
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
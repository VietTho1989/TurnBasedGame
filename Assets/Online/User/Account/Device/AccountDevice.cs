using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AccountDevice : Account
{

	public VP<string> imei;

	public VP<string> deviceName;

	public VP<int> deviceType;

	#region customName

	public VP<string> customName;

	public void requestChangeCustomName(uint userId, string newCustomName){
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.changeCustomName (userId, newCustomName);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is AccountDeviceIdentity) {
						AccountDeviceIdentity accountDeviceIdentity = dataIdentity as AccountDeviceIdentity;
						accountDeviceIdentity.requestChangeCustomName (userId, newCustomName);
					} else {
						Debug.LogError ("Why isn't correct identity");
					}
				} else {
					Debug.LogError ("cannot find dataIdentity");
				}
			}
		} else {
			Debug.LogError ("You cannot request: " + this);
		}
	}

	public void changeCustomName(uint userId, string newCustomName){
		if (isCanChange (userId)) {
			this.customName.v = newCustomName;
		} else {
			Debug.LogError ("cannot request: " + userId + "; " + this);
		}
	}

	#endregion

	#region avatarUrl

	public VP<string> avatarUrl;

	public void requestChangeAvatarUrl(uint userId, string newAvatarUrl){
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.changeAvatarUrl (userId, newAvatarUrl);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is AccountDeviceIdentity) {
						AccountDeviceIdentity accountDeviceIdentity = dataIdentity as AccountDeviceIdentity;
						accountDeviceIdentity.requestChangeAvatarUrl (userId, newAvatarUrl);
					} else {
						Debug.LogError ("Why isn't correct identity");
					}
				} else {
					Debug.LogError ("cannot find dataIdentity");
				}
			}
		} else {
			Debug.LogError ("You cannot request: " + this);
		}
	}

	public void changeAvatarUrl(uint userId, string newAvatarUrl){
		if (isCanChange (userId)) {
			this.avatarUrl.v = newAvatarUrl;
		} else {
			Debug.LogError ("cannot request: " + userId + "; " + this);
		}
	}

	#endregion

	#region Constructor

	public enum Property
	{
		imei,
		deviceName,
		deviceType,
		customName,
		avatarUrl
	}

	public AccountDevice() : base()
	{
		this.imei = new VP<string> (this, (byte)Property.imei, "");
		this.deviceName = new VP<string>(this, (byte)Property.deviceName, "");
		this.deviceType = new VP<int> (this, (byte)Property.deviceType, (int)DeviceType.Console);
		this.customName = new VP<string> (this, (byte)Property.customName, "");
		this.avatarUrl = new VP<string> (this, (byte)Property.avatarUrl, DefaultAvatarUrl);
	}

	#endregion

	public override Type getType ()
	{
		return Type.DEVICE;
	}

	public override void requestUpdate (uint userId, Account account)
	{
		if (account != null && account != this && account is AccountDevice) {
			AccountDevice accountDevice = account as AccountDevice;
			// imei,
			// deviceName
			// deviceType
			// customName
			if (this.customName.v != accountDevice.customName.v) {
				this.requestChangeCustomName (userId, accountDevice.customName.v);
			}
			// avatarUrl
			if (this.avatarUrl.v != accountDevice.avatarUrl.v) {
				this.requestChangeAvatarUrl (userId, accountDevice.avatarUrl.v);
			}
		} else {
			Debug.LogError ("account not correct: " + account + "; " + this);
		}
	}

	public override AccountMessage makeAccountMessage ()
	{
		AccountDeviceMessage accountDeviceMessage = new AccountDeviceMessage ();
		{
			accountDeviceMessage.imei = this.imei.v;
			accountDeviceMessage.deviceName = this.deviceName.v;
			accountDeviceMessage.customName = this.customName.v;
			accountDeviceMessage.deviceType = this.deviceType.v;
		}
		return accountDeviceMessage;
	}

	public override bool isEqual (AccountMessage accountMessage)
	{
		if (accountMessage is AccountDeviceMessage) {
			AccountDeviceMessage accountDeviceMessage = accountMessage as AccountDeviceMessage;
			return this.imei.v == accountDeviceMessage.imei;
		} else {
			return false;
		}
	}

	public override bool checkCorrectAccount (AccountMessage accountMessage)
	{
		return true;
	}

	public override void updateAccount (AccountMessage accountMessage)
	{
		if (accountMessage is AccountDeviceMessage) {
			AccountDeviceMessage accountDeviceMessage = accountMessage as AccountDeviceMessage;
			this.deviceName.v = accountDeviceMessage.deviceName;
			this.customName.v = accountDeviceMessage.customName;
			this.deviceType.v = accountDeviceMessage.deviceType;
		} else {
			Debug.LogError ("not account device message: " + this);
		}
	}

	public override string getName ()
	{
		return string.IsNullOrEmpty(this.customName.v) ? this.deviceName.v : this.customName.v;
	}

	public override string getAvatarUrl ()
	{
		return this.avatarUrl.v;
	}

}
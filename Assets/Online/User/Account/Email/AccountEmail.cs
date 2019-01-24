using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AccountEmail : Account
{

	public VP<string> email;

	#region password

	public VP<string> password;

	public void requestChangePassword(uint userId, string newPassword, string oldPassword){
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.changePassword (userId, newPassword, oldPassword);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is AccountEmailIdentity) {
						AccountEmailIdentity accountEmailIdentity = dataIdentity as AccountEmailIdentity;
						accountEmailIdentity.requestChangePassword (userId, newPassword, oldPassword);
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

	public void changePassword(uint userId, string newPassword, string oldPassword){
		if (isCanChange (userId)) {
			if (this.password.v == oldPassword) {
				this.password.v = newPassword;
			} else {
				Debug.LogError ("different password: " + this);
			}
		} else {
			Debug.LogError ("cannot request: " + userId + "; " + this);
		}
	}

	#endregion

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
					if (dataIdentity is AccountEmailIdentity) {
						AccountEmailIdentity accountEmailIdentity = dataIdentity as AccountEmailIdentity;
						accountEmailIdentity.requestChangeCustomName (userId, newCustomName);
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

	public VP<string> avatarUrl;

	public void requestChangeAvatarUrl(uint userId, string newAvatarUrl){
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.changeAvatarUrl (userId, newAvatarUrl);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is AccountEmailIdentity) {
						AccountEmailIdentity accountEmailIdentity = dataIdentity as AccountEmailIdentity;
						accountEmailIdentity.requestChangeAvatarUrl (userId, newAvatarUrl);
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
			this.customName.v = newAvatarUrl;
		} else {
			Debug.LogError ("cannot request: " + userId + "; " + this);
		}
	}

	#region Constructor

	public enum Property
	{
		email,
		password,
		customName,
		avatarUrl
	}

	public AccountEmail() : base()
	{
		this.email = new VP<string> (this, (byte)Property.email, "");
		this.password = new VP<string> (this, (byte)Property.password, "");
		this.customName = new VP<string> (this, (byte)Property.customName, "");
		this.avatarUrl = new VP<string> (this, (byte)Property.avatarUrl, DefaultAvatarUrl);
	}

	#endregion

	public override Type getType ()
	{
		return Type.EMAIL;
	}

	public override void requestUpdate (uint userId, Account account)
	{
		if (account != null && account != this && account is AccountEmail) {
			AccountEmail accountEmail = account as AccountEmail;
			// email
			// password
			// customName
			if (this.customName.v != accountEmail.customName.v) {
				this.requestChangeCustomName (userId, accountEmail.customName.v);
			}
			// avatarUrl
			if (this.avatarUrl.v != accountEmail.avatarUrl.v) {
				this.requestChangeAvatarUrl (userId, accountEmail.avatarUrl.v);
			}
		} else {
			Debug.LogError ("not correct account: " + this);
		}
	}

	public override AccountMessage makeAccountMessage ()
	{
		AccountEmailMessage accountEmailMessage = new AccountEmailMessage ();
		{
			accountEmailMessage.email = this.email.v;
			accountEmailMessage.password = this.password.v;
		}
		return accountEmailMessage;
	}

	public override bool isEqual (AccountMessage accountMessage)
	{
		if (accountMessage is AccountEmailMessage) {
			AccountEmailMessage accountEmailMessage = accountMessage as AccountEmailMessage;
			return this.email.v == accountEmailMessage.email;
		} else {
			return false;
		}
	}

	public override bool checkCorrectAccount (AccountMessage accountMessage)
	{
		if (accountMessage is AccountEmailMessage) {
			AccountEmailMessage accountEmailMessage = accountMessage as AccountEmailMessage;
			return this.password.v == accountEmailMessage.password;
		} else {
			return false;
		}
	}

	public override void updateAccount (AccountMessage accountMessage)
	{
		
	}

	public override string getName ()
	{
		return string.IsNullOrEmpty (this.customName.v) ? this.customName.v : this.email.v;
	}

	public override string getAvatarUrl ()
	{
		return this.avatarUrl.v;
	}

}
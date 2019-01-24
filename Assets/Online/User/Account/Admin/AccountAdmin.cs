using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AccountAdmin : Account
{

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
					if (dataIdentity is AccountAdminIdentity) {
						AccountAdminIdentity accountAdminIdentity = dataIdentity as AccountAdminIdentity;
						accountAdminIdentity.requestChangeCustomName (userId, newCustomName);
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
					if (dataIdentity is AccountAdminIdentity) {
						AccountAdminIdentity accountAdminIdentity = dataIdentity as AccountAdminIdentity;
						accountAdminIdentity.requestChangeAvatarUrl (userId, newAvatarUrl);
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
		customName,
		avatarUrl
	}

	public AccountAdmin() : base()
	{
		this.customName = new VP<string> (this, (byte)Property.customName, "Admin");
		this.avatarUrl = new VP<string> (this, (byte)Property.avatarUrl, "");
	}

	#endregion

	public override Type getType ()
	{
		return Type.Admin;
	}

	public override void requestUpdate (uint userId, Account account)
	{
		if (account != null && account != this && account is AccountAdmin) {
			AccountAdmin accountAdmin = account as AccountAdmin;
			// customName
			if (this.customName.v != accountAdmin.customName.v) {
				this.requestChangeCustomName (userId, accountAdmin.customName.v);
			}
			// avatarUrl
			if (this.avatarUrl.v != accountAdmin.avatarUrl.v) {
				this.requestChangeAvatarUrl (userId, accountAdmin.avatarUrl.v);
			}
		} else {
			Debug.LogError ("not correct account: " + account + "; " + this);
		}
	}

	public override AccountMessage makeAccountMessage ()
	{
		Debug.LogError ("why make account message: " + this);
		return null;
	}

	public override bool isEqual (AccountMessage accountMessage)
	{
		if (accountMessage.getType () == Type.Admin) {
			return true;
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
		
	}

	public override string getName ()
	{
		return this.customName.v;
	}

	public override string getAvatarUrl ()
	{
		return this.avatarUrl.v;
	}

}
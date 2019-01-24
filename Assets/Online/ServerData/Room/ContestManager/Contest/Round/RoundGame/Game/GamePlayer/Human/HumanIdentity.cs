using UnityEngine;
using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;

public class HumanIdentity : DataIdentity
{

	#region SyncVar

	[SyncVar(hook="onChangePlayerId")]
	public uint playerId;

	public void onChangePlayerId(uint newPlayerId){
		this.playerId = newPlayerId;
		if (this.netData.clientData != null) {
			this.netData.clientData.playerId.v = newPlayerId;
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	[SyncVar(hook="onChangeEmail")]
	public string email;

	public void onChangeEmail(string newEmail){
		this.email = newEmail;
		if (this.netData.clientData != null) {
			this.netData.clientData.email.v = newEmail;
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	[SyncVar(hook="onChangePhoneNumber")]
	public string phoneNumber;

	public void onChangePhoneNumber(string newPhoneNumber){
		this.phoneNumber = newPhoneNumber;
		if (this.netData.clientData != null) {
			this.netData.clientData.phoneNumber.v = newPhoneNumber;
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	[SyncVar(hook="onChangeStatus")]
	public string status;

	public void onChangeStatus(string newStatus){
		this.status = newStatus;
		if(this.netData.clientData!=null){
			this.netData.clientData.status.v = newStatus;
		}else{
			// Debug.LogError("clientData null");
		}
	}

	[SyncVar(hook="onChangeBirthday")]
	public long birthday;

	public void onChangeBirthday(long newBirthday){
		this.birthday = newBirthday;
		if (this.netData.clientData != null) {
			this.netData.clientData.birthday.v = newBirthday;
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	[SyncVar(hook="onChangeSex")]
	public User.SEX sex;

	public void onChangeSex(User.SEX newSex){
		this.sex = newSex;
		if (this.netData.clientData != null) {
			this.netData.clientData.sex.v = newSex;
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	#endregion

	#region NetData

	private NetData<Human> netData = new NetData<Human>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			onChangePlayerId(this.playerId);
			onChangeEmail(this.email);
			onChangePhoneNumber(this.phoneNumber);
			onChangeStatus(this.status);
			onChangeBirthday(this.birthday);
			onChangeSex (this.sex);
		} else {
			Debug.LogError ("clientDuelResult null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += GetDataSize (this.playerId);
			ret += GetDataSize (this.email);
			ret += GetDataSize (this.phoneNumber);
			ret += GetDataSize (this.status);
			ret += GetDataSize (this.birthday);
			ret += GetDataSize (this.sex);
		}
		return ret;
	}

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is Human) {
			Human human = data as Human;
			// set new parent
			this.addTransformToParent();
			// Property
			{
				this.serialize (this.searchInfor, human.makeSearchInforms ());
				this.playerId = human.playerId.v;
				this.email = human.email.v;
				this.phoneNumber = human.phoneNumber.v;
				this.status = human.status.v;
				this.birthday = human.birthday.v;
				this.sex = human.sex.v;
			}
			this.getDataSize ();
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					if (human.getDataParent () is LimitRoomContainer) {
						observer.checkChange = new LimitRoomContainerObserver (observer);
						observer.setCheckChangeData (human.getDataParent () as LimitRoomContainer);
					} else {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (human);
					}
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
		if (data is Human) {
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
		if (wrapProperty.p is Human) {
			switch ((Human.Property)wrapProperty.n) {
			case Human.Property.playerId:
				this.playerId = (uint)wrapProperty.getValue ();
				break;
			case Human.Property.account:
				break;
			case Human.Property.email:
				this.email = (string)wrapProperty.getValue ();
				break;
			case Human.Property.phoneNumber:
				this.phoneNumber = (string)wrapProperty.getValue ();
				break;
			case Human.Property.status:
				this.status = (string)wrapProperty.getValue ();
				break;
			case Human.Property.birthday:
				this.birthday = (long)wrapProperty.getValue ();
				break;
			case Human.Property.sex:
				this.sex = (User.SEX)wrapProperty.getValue ();
				break;
			case Human.Property.connection:
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
	}

	#endregion

	#region email

	public void requestChangeEmail(uint userId, string newEmail)
	{
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdHumanChangeEmail (this.netId, userId, newEmail);
		} else {
			Debug.LogError ("Cannot find userIdentity: " + this);
		}
	}

	public void changeEmail(uint userId, string newEmail){
		if (this.netData.serverData != null) {
			this.netData.serverData.changeEmail (userId, newEmail);
		} else {
			Debug.LogError ("serverData null: " + this);
		}
	}

	#endregion

	#region phoneNumber

	public void requestChangePhoneNumber(uint userId, string newPhoneNumber)
	{
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdHumanChangePhoneNumber (this.netId, userId, newPhoneNumber);
		} else {
			Debug.LogError ("Cannot find userIdentity: " + this);
		}
	}

	public void changePhoneNumber(uint userId, string newPhoneNumber){
		if (this.netData.serverData != null) {
			this.netData.serverData.changePhoneNumber (userId, newPhoneNumber);
		} else {
			Debug.LogError ("serverData null: " + this);
		}
	}

	#endregion

	#region status

	public void requestChangeStatus(uint userId, string newStatus)
	{
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdHumanChangeStatus (this.netId, userId, newStatus);
		} else {
			Debug.LogError ("Cannot find userIdentity: " + this);
		}
	}

	public void changeStatus(uint userId, string newStatus){
		if (this.netData.serverData != null) {
			this.netData.serverData.changeStatus (userId, newStatus);
		} else {
			Debug.LogError ("serverData null: " + this);
		}
	}

	#endregion

	#region birthday

	public void requestChangeBirthday(uint userId, long newBirthday)
	{
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdHumanChangeBirthday (this.netId, userId, newBirthday);
		} else {
			Debug.LogError ("Cannot find userIdentity: " + this);
		}
	}

	public void changeBirthday(uint userId, long newBirthday){
		if (this.netData.serverData != null) {
			this.netData.serverData.changeBirthday (userId, newBirthday);
		} else {
			Debug.LogError ("serverData null: " + this);
		}
	}

	#endregion

	#region sex

	public void requestChangeSex(uint userId, User.SEX newSex)
	{
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdHumanChangeSex (this.netId, userId, newSex);
		} else {
			Debug.LogError ("Cannot find userIdentity: " + this);
		}
	}

	public void changeSex(uint userId, User.SEX newSex){
		if (this.netData.serverData != null) {
			this.netData.serverData.changeSex (userId, newSex);
		} else {
			Debug.LogError ("serverData null: " + this);
		}
	}

	#endregion

}
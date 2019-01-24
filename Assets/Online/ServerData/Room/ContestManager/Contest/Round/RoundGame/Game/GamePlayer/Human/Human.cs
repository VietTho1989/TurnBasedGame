using UnityEngine;
using Mirror;
using System.Collections;

public class Human : GamePlayer.Inform
{
	
	public VP<uint> playerId;

	public VP<Account> account;

	public VP<UserState> state;

	public bool isCanChange(uint userId)
	{
		return this.playerId.v == userId;
	}

	#region email

	public VP<string> email;

	public void requestChangeEmail(uint userId, string newEmail){
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.changeEmail (userId, newEmail);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is HumanIdentity) {
						HumanIdentity humanIdentity = dataIdentity as HumanIdentity;
						humanIdentity.requestChangeEmail (userId, newEmail);
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

	public void changeEmail(uint userId, string newEmail){
		if (isCanChange (userId)) {
			this.email.v = newEmail;
		} else {
			Debug.LogError ("cannot request: " + userId + "; " + this);
		}
	}

	#endregion

	#region phoneNumber

	public VP<string> phoneNumber;

	public void requestChangePhoneNumber(uint userId, string newPhoneNumber){
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.changePhoneNumber (userId, newPhoneNumber);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is HumanIdentity) {
						HumanIdentity humanIdentity = dataIdentity as HumanIdentity;
						humanIdentity.requestChangePhoneNumber (userId, newPhoneNumber);
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

	public void changePhoneNumber(uint userId, string newPhoneNumber){
		if (isCanChange (userId)) {
			this.phoneNumber.v = newPhoneNumber;
		} else {
			Debug.LogError ("cannot request: " + userId + "; " + this);
		}
	}

	#endregion

	#region status

	public VP<string> status;

	public void requestChangeStatus(uint userId, string newStatus){
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.changeStatus (userId, newStatus);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is HumanIdentity) {
						HumanIdentity humanIdentity = dataIdentity as HumanIdentity;
						humanIdentity.requestChangeStatus (userId, newStatus);
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

	public void changeStatus(uint userId, string newStatus){
		if (isCanChange (userId)) {
			this.status.v = newStatus;
		} else {
			Debug.LogError ("cannot request: " + userId + "; " + this);
		}
	}

	#endregion

	#region birtyday

	public VP<long> birthday;

	public void requestChangeBirthday(uint userId, long newBirthday){
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.changeBirthday (userId, newBirthday);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is HumanIdentity) {
						HumanIdentity humanIdentity = dataIdentity as HumanIdentity;
						humanIdentity.requestChangeBirthday (userId, newBirthday);
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

	public void changeBirthday(uint userId, long newBirthday){
		if (isCanChange (userId)) {
			this.birthday.v = newBirthday;
		} else {
			Debug.LogError ("cannot request: " + userId + "; " + this);
		}
	}

	#endregion

	#region sex

	public VP<User.SEX> sex;

	public void requestChangeSex(uint userId, User.SEX newSex){
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.changeSex (userId, newSex);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is HumanIdentity) {
						HumanIdentity humanIdentity = dataIdentity as HumanIdentity;
						humanIdentity.requestChangeSex (userId, newSex);
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

	public void changeSex(uint userId, User.SEX newSex){
		if (isCanChange (userId)) {
			this.sex.v = newSex;
		} else {
			Debug.LogError ("cannot request: " + userId + "; " + this);
		}
	}

	#endregion

	public VP<NetworkConnection> connection;

	public VP<Ban> ban;

	#region Constructor

	public enum Property
	{
		playerId,
		account,
		state,
		email,
		phoneNumber,
		status,
		birthday,
		sex,
		connection,
		ban
	}

	public Human() : base()
	{
		this.playerId = new VP<uint>(this, (byte)Property.playerId, Data.UNKNOWN_ID);
		this.account = new VP<Account> (this, (byte)Property.account, new AccountNone ());

		{
			this.state = new VP<UserState> (this, (byte)Property.state, new UserState ());
			this.state.v.state.v = UserState.State.Online;
		}
		this.email = new VP<string>(this, (byte)Property.email, "");
		this.phoneNumber = new VP<string>(this, (byte)Property.phoneNumber, "");
		this.status = new VP<string>(this, (byte)Property.status, "");
		this.birthday = new VP<long>(this, (byte)Property.birthday, Constants.UNKNOWN_TIME);
		this.sex = new VP<User.SEX>(this, (byte)Property.sex, User.SEX.UNKNOWN);
		this.connection = new VP<NetworkConnection> (this, (byte)Property.connection, null);
		this.ban = new VP<Ban> (this, (byte)Property.ban, new BanNormal ());
	}

	public override string ToString ()
	{
		return string.Format ("[Human: {0},  {1}]", this.playerId.v, this.account.v.getName ());
	}

	#endregion

	public override Type getType ()
	{
		return GamePlayer.Inform.Type.Human;
	}

	public override string getPlayerName ()
	{
		if (this.account.v != null) {
			return this.account.v.getName ();
		} else {
			Debug.LogError ("account null: " + this);
			return "";
		}
	}

	#region Utils

	public static void onUpdateSyncPlayerIdChange(WrapProperty wrapProperty, DirtyInterface dirtyInterface)
	{
		switch ((Human.Property)wrapProperty.n) {
		case Human.Property.playerId:
			dirtyInterface.makeDirty ();
			break;
		case Human.Property.account:
			break;
		case Human.Property.state:
			break;
		case Human.Property.email:
			break;
		case Human.Property.phoneNumber:
			break;
		case Human.Property.status:
			break;
		case Human.Property.birthday:
			break;
		case Human.Property.sex:
			break;
		case Human.Property.connection:
			break;
		default:
			Debug.LogError ("Don't process: " + wrapProperty + "; " + dirtyInterface);
			break;
		}
	}

	#endregion

	public void requestUpdate(uint userId, Human human)
	{
		if (this.playerId.v == userId) {
			if (human != null && this != human) {
				// playerId
				// account
				this.account.v.requestUpdate(userId, human.account.v);
				//state
				// email
				if (this.email.v != human.email.v) {
					this.requestChangeEmail (userId, human.email.v);
				}
				// phoneNumber
				if (this.phoneNumber.v != human.phoneNumber.v) {
					this.requestChangePhoneNumber (userId, human.phoneNumber.v);
				}
				// status
				if (this.status.v != human.status.v) {
					this.requestChangeStatus (userId, human.status.v);
				}
				// birthday
				if (this.birthday.v != human.birthday.v) {
					this.requestChangeBirthday (userId, human.birthday.v);
				}
				// sex
				if (this.sex.v != human.sex.v) {
					this.requestChangeSex (userId, human.sex.v);
				}
				// connection
				// ban
			} else {
				Debug.LogError ("human not correct: " + human + "; " + this);
			}
		} else {
			Debug.LogError ("not correct userId: " + this);
		}
	}

}
using UnityEngine;

public class User : Data
{
	
	public override string ToString ()
	{
		return "User: " + uid + "; " + this.human.v.account.v.getName () + "; " + this.human.v.account.v.getType ();
	}

	public VP<Human> human;

	#region Role

	public const uint AdminUniqueId = 0;

	public enum Role
	{
		Normal,
		Admin
	}
	public VP<Role> role;

	public bool isCanChangeRole(uint userId)
	{
		bool canChange = false;
		{
			Server server = this.findDataInParent<Server> ();
			if (server != null) {
				if (server.type.v == Server.Type.Host || server.type.v == Server.Type.Server) {
					if (server.profileId.v == userId) {
						canChange = true;
					}
				} else {
					Debug.LogError ("not correct server type: " + server);
				}
			} else {
				Debug.LogError ("server null: " + this);
			}
		}
		return canChange;
	}

	public void requestChangeRole(uint userId, User.Role newRole){
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.changeRole (userId, newRole);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is UserIdentity) {
						UserIdentity userIdentity = dataIdentity as UserIdentity;
						userIdentity.requestChangeRole (userId, newRole);
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

	public void changeRole(uint userId, User.Role newRole){
		if (isCanChangeRole (userId)) {
			this.role.v = newRole;
		} else {
			Debug.LogError ("cannot request: " + userId + "; " + this);
		}
	}

	#endregion

	public enum ACCOUNT_TYPE
	{
		NOTHING,
		DEVICE,
		EMAIL,
		FACEBOOK
	}

    #region sex

    public enum SEX
	{
		UNKNOWN,
		MALE,
		FEMALE
	}

    private static readonly TxtLanguage txtSexUnknown = new TxtLanguage();
    private static readonly TxtLanguage txtSexMale = new TxtLanguage();
    private static readonly TxtLanguage txtSexFemale = new TxtLanguage();

    public static string getStrSex(SEX sex)
    {
        switch (sex)
        {
            case SEX.UNKNOWN:
                return txtSexUnknown.get("Unknown");
            case SEX.MALE:
                return txtSexMale.get("Male");
            case SEX.FEMALE:
                return txtSexFemale.get("Female");
            default:
                Debug.LogError("unknown sex: " + sex);
                return sex.ToString();
        }
    }

    #endregion

    public VP<string> ipAddress;

	public VP<long> registerTime;

	public VP<ChatRoom> chatRoom;

	#region Constructor

	public enum Property
	{
		human,
		role,
		ipAddress,
		registerTime,
		chatRoom
	}

    static User()
    {
        // sex
        {
            txtSexUnknown.add(Language.Type.vi, "Không Biết");
            txtSexMale.add(Language.Type.vi, "Nam");
            txtSexFemale.add(Language.Type.vi, "Nữ");
        }
    }

    public User() : base()
	{
		this.human = new VP<Human> (this, (byte)Property.human, new Human ());
		role = new VP<Role> (this, (byte)Property.role, Role.Normal);
		ipAddress = new VP<string>(this, (byte)Property.ipAddress, "");
		registerTime = new VP<long>(this, (byte)Property.registerTime, Constants.UNKNOWN_TIME);
		{
			ChatRoom chatRoom = new ChatRoom ();
			{
				chatRoom.topic.v = new UserTopic ();
			}
			this.chatRoom = new VP<ChatRoom> (this, (byte)Property.chatRoom, chatRoom);
		}
	}

	#endregion

	#region Make Friend Request

	public bool isCanMakeFriendRequest(uint friendId){
		bool ret = true;
		// Same Id?
		if (ret) {
			if (this.uid == friendId) {
				Debug.LogError ("the same Id: " + friendId);
				ret = false;
			}
		}
		// Already  is Friend
		if (ret) {
			bool alreadyFriend = false;
			{
				Server server = this.findDataInParent<Server> ();
				if (server != null) {
					for (int i = 0; i < server.friendWorld.v.friends.vs.Count; i++) {
						Friend friend = server.friendWorld.v.friends.vs [i];
						// Check
						if ((friend.user1.v.playerId.v == this.uid && friend.user2.v.playerId.v == friendId)
						    || (friend.user1.v.playerId.v == friendId && friend.user2.v.playerId.v == this.uid)) {
							if (friend.state.v.getType() != Friend.State.Type.None) {
								Debug.LogError ("already is friend: " + friend);
								alreadyFriend = true;
								break;
							}
						}
					}
				} else {
					Debug.LogError ("server null");
				}
			}
			if (alreadyFriend) {
				ret = false;
			}
		}
		return ret;
	}

	public void requestMakeFriendRequest(uint friendId){
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.makeFriendRequest (friendId);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is UserIdentity) {
						UserIdentity userIdentity = dataIdentity as UserIdentity;
						userIdentity.requestMakeFriendRequest (friendId);
					} else {
						Debug.LogError ("Why isn't correct identity");
					}
				} else {
					Debug.LogError ("cannot find dataIdentity");
				}
			}
		} else {
			Debug.LogError ("You cannot request");
		}
	}

	public void makeFriendRequest(uint friendId){
		if (isCanMakeFriendRequest (friendId)) {
			Friend oldFriend = null;
			// Find oldFriend
			{
				Server server = this.findDataInParent<Server> ();
				if (server != null) {
					for (int i = 0; i < server.friendWorld.v.friends.vs.Count; i++) {
						Friend friend = server.friendWorld.v.friends.vs [i];
						// Check
						if ((friend.user1.v.playerId.v == this.uid && friend.user2.v.playerId.v == friendId)
							|| (friend.user1.v.playerId.v == friendId && friend.user2.v.playerId.v == this.uid)) {
							oldFriend = friend;
							break;
						}
					}
				} else {
					Debug.LogError ("server null");
				}
			}
			// Process
			if (oldFriend != null) {
				FriendStateNone friendStateNone = oldFriend.state.v as FriendStateNone;
				if (friendStateNone != null) {
					friendStateNone.makeFriend (this.human.v.playerId.v);
				} else {
					Debug.LogError ("friendStateNone null: " + this);
				}
			} else {
				Server server = this.findDataInParent<Server> ();
				if (server != null) {
					FriendWorld friendWorld = server.friendWorld.v;
					// Make new Friend
					{
						Friend friend = new Friend ();
						{
							friend.uid = friendWorld.friends.makeId ();
							// user1
							{
								Human user1 = new Human ();
								{
									user1.uid = friend.user1.makeId ();
									user1.playerId.v = this.uid;
								}
								friend.user1.v = user1;
							}
							// user2
							{
								Human user2 = new Human ();
								{
									user2.uid = friend.user2.makeId ();
									user2.playerId.v = friendId;
								}
								friend.user2.v = user2;
							}
							// time
							friend.time.v = Global.getRealTimeInMiliSeconds();
						}
						friendWorld.friends.add (friend);
						// state
						{
							FriendStateNone friendStateNone = friend.state.v as FriendStateNone;
							if (friendStateNone != null) {
								friendStateNone.requestMakeFriend (this.human.v.playerId.v);
							} else {
								Debug.LogError ("friendStateNone null: " + this);
							}
						}
					}
				} else {
					Debug.LogError ("server null");
				}
			}
		} else {
			Debug.LogError ("Cannot make friend request: " + friendId);
		}
	}

	#endregion

	#region logOut

	public void requestLogOut(uint userId){
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.logOut (userId);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is UserIdentity) {
						UserIdentity userIdentity = dataIdentity as UserIdentity;
						userIdentity.requestLogOut (userId);
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

	public void logOut(uint userId){
		Debug.LogError ("logOut");
	}

	#endregion

	public void requestUpdate(uint userId, User user)
	{
		if (this.human.v != null && this.human.v.playerId.v == userId) {
			if (this != user && user!=null) {
				// human
				this.human.v.requestUpdate(userId, user.human.v);
				// role
				// ipAddress
				// registerTime
			} else {
				Debug.LogError ("why different: " + this);
			}
		} else {
			Debug.LogError ("not correct userId: " + userId + "; " + this);
		}
	}
}
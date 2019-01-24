using UnityEngine;
using Mirror;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;
using GameManager.ContestManager;
using GameManager.Match.RoundRobin;
using GameManager.Match.Elimination;
using GameManager.Match.Swap;

[RequireComponent (typeof (NetworkIdentity))]
public class ClientConnectIdentity : NetworkBehaviour
{

	public ServerManager ServerManager;
	public ServerManager serverManager
	{
		get{
			if(ServerManager==null){
				ServerManager = ServerManager.instance;
			}
			return ServerManager;
		}

		set{
			ServerManager = value;
		}
	}

    public static T GetDataIdentity<T>(uint networkInstanceId) where T : DataIdentity
    {
        T ret = null;
        {
            NetworkIdentity networkIdentity = null;
            if (NetworkIdentity.spawned.TryGetValue(networkInstanceId, out networkIdentity))
            {
                ret = networkIdentity.GetComponent<T>();
            }
        }
        return ret;
    }

    public static ClientConnectIdentity findYourClientConnectIdentity(Data yourData)
	{
		if (yourData == null) {
			// Debug.LogError ("data null");
			return null;
		}
		ClientConnectIdentity[] clientConnects = FindObjectsOfType<ClientConnectIdentity>();
		{
			foreach (ClientConnectIdentity clientConnect in clientConnects) {
				if (clientConnect.hasAuthority) {
					return clientConnect;
				} else {
					Debug.LogError ("clientConnect don't have authority: " + clientConnect);
				}
			}
		}
		return null;
	}

	#region Delete when user lost connection

    // TODO Tam bo
	/*void OnPlayerDisconnected(NetworkPlayer player) {
		// Debug.Log("Clean up after player " + player);
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects(player);
	}

	void OnDisconnectedFromServer(NetworkDisconnection info) {
		if (Network.isServer) {
			// Debug.LogError("Local server connection disconnected");
		} else if (info == NetworkDisconnection.LostConnection) {
			// Debug.LogError ("Lost connection to the server");
		} else {
			// Debug.LogError ("Successfully diconnected from the server");
		}
	}*/

	#endregion

	#region Observer: only who have authority can

	// called when a new player enters the game
	public override bool OnCheckObserver(NetworkConnection newObserver)
	{
		// Debug.Log ("OnCheckObserver: "+newObserver);
		return false;
	}

	// Only client user can see this class
	public override bool OnRebuildObservers(HashSet<NetworkConnection> observers, bool initial)
	{
		// Debug.Log ("OnRebuildObservers: " + observers.Count + ", " + initial + ", " + this.connectionToClient);
		{
			observers.Clear ();
			observers.Add (this.connectionToClient);
		}
		return true;
	}

	#endregion

	#region MonoBehavior

	void Start()
	{
		// Set new parent
		if (serverManager != null) {
			this.transform.SetParent (serverManager.transform, true);
		} else {
			// Debug.Log ("not in server");
		}
		// increate userIdentity count for login
		{
			if (serverManager != null) {
				ServerManager.UIData serverManagerUIData = serverManager.data;
				if (serverManagerUIData != null) {
					Server server = serverManagerUIData.server.v.data;
					if (server != null) {
						if (server.type.v == Server.Type.Client) {
							// Find Login
							Login login = null;
							{
								if (server.state.v != null) {
									switch (server.state.v.getType ()) {
									case Server.State.Type.Offline:
										{
											Server.State.Offline offline = server.state.v as Server.State.Offline;
											login = offline.login.v;
										}
										break;
									case Server.State.Type.Connect:
										break;
									case Server.State.Type.Disconnect:
										{
											Server.State.Disconnect disconnect = server.state.v as Server.State.Disconnect;
											login = disconnect.login.v;
										}
										break;
									default:
										Debug.LogError ("unknown type: " + server.state.v.getType () + "; " + this);
										break;
									}
								} else {
									Debug.LogError ("server state null: " + this);
								}
							}
							// Process
							if (login != null) {
								LoginState.Log log = login.state.v as LoginState.Log;
								if (log != null) {
									LoginState.CheckConnectUpdate checkConnectUpdate = log.findCallBack<LoginState.CheckConnectUpdate> ();
									if (checkConnectUpdate != null) {
										checkConnectUpdate.makeDirty ();
									} else {
										Debug.LogError ("checkConnectUpdate null: " + this);
									}
								} else {
									// Debug.LogError ("log null: " + this);
								}
							} else {
								Debug.LogError ("login null: " + this);
							}
						}
					} else {
						Debug.LogError ("server null: " + this);
					}
				} else {
					Debug.LogError ("serverManagerUIData null: " + this);
				}
			} else {
				Debug.LogError ("serverManager null: " + this);
			}
		}
	}

	void OnDestroy()
	{
		// decrease userIdentity count for login
		{
			if (serverManager != null) {
				ServerManager.UIData serverManagerUIData = serverManager.data;
				if (serverManagerUIData != null) {
					Server server = serverManagerUIData.server.v.data;
					if (server != null) {
						if (server.type.v == Server.Type.Client) {
							// Find Login
							Login login = null;
							{
								if (server.state.v != null) {
									switch (server.state.v.getType ()) {
									case Server.State.Type.Offline:
										{
											Server.State.Offline offline = server.state.v as Server.State.Offline;
											login = offline.login.v;
										}
										break;
									case Server.State.Type.Connect:
										break;
									case Server.State.Type.Disconnect:
										{
											Server.State.Disconnect disconnect = server.state.v as Server.State.Disconnect;
											login = disconnect.login.v;
										}
										break;
									default:
										Debug.LogError ("unknown type: " + server.state.v.getType () + "; " + this);
										break;
									}
								} else {
									Debug.LogError ("server state null: " + this);
								}
							}
							// Process
							if (login != null) {
								LoginState.Log log = login.state.v as LoginState.Log;
								if (log != null) {
									LoginState.CheckConnectUpdate checkConnectUpdate = log.findCallBack<LoginState.CheckConnectUpdate> ();
									if (checkConnectUpdate != null) {
										checkConnectUpdate.makeDirty ();
									} else {
										Debug.LogError ("checkConnectUpdate null: " + this);
									}
								} else {
									Debug.LogError ("log null: " + this);
								}
							} else {
								Debug.LogError ("login null: " + this);
							}
						}
					} else {
						Debug.LogError ("server null: " + this);
					}
				} else {
					Debug.LogError ("serverManagerUIData null: " + this);
				}
			} else {
				Debug.LogError ("serverManager null: " + this);
			}
		}
	}

	#endregion

	#region All Command

	public void requestLogin(AccountMessage accountMessage, uint[] checkIds, byte[] currentChatViewer)
	{
		switch (accountMessage.getType ()) {
		case Account.Type.DEVICE:
			{
				AccountDeviceMessage accountDeviceMessage = accountMessage as AccountDeviceMessage;
				this.CmdLoginAccountDevice (accountDeviceMessage, checkIds, currentChatViewer);
			}
			break;
		case Account.Type.EMAIL:
			{
				AccountEmailMessage accountEmailMessage = accountMessage as AccountEmailMessage;
				this.CmdLoginAccountEmail (accountEmailMessage, checkIds, currentChatViewer);
			}
			break;
		case Account.Type.FACEBOOK:
			{
				AccountFacebookMessage accountFacebookMessage = accountMessage as AccountFacebookMessage;
				this.CmdLoginAccountFacebook (accountFacebookMessage, checkIds, currentChatViewer);
			}
			break;
		default:
			Debug.LogError ("unknown type: " + accountMessage.getType () + "; " + this);
			break;
		}
	}

	[Command]
	public void CmdLoginAccountDevice(AccountDeviceMessage accountDeviceMessage, uint[] checkIds, byte[] currentChatViewer)
	{
		this.CmdLogin (accountDeviceMessage, checkIds, currentChatViewer);
	}

	[Command]
	public void CmdLoginAccountEmail(AccountEmailMessage accountEmailMessage, uint[] checkIds, byte[] currentChatViewer)
	{
		this.CmdLogin (accountEmailMessage, checkIds, currentChatViewer);
	}

	[Command]
	public void CmdLoginAccountFacebook(AccountFacebookMessage accountFacebookMessage, uint[] checkIds, byte[] currentChatViewer)
	{
		this.CmdLogin (accountFacebookMessage, checkIds, currentChatViewer);
	}

	public void CmdLogin(AccountMessage accountMessage, uint[] checkIds, byte[] currentChatViewer)
	{
		Debug.LogError ("CmdLogin: " + accountMessage + "; " + this);
		if (serverManager != null && serverManager.data!=null && serverManager.data.server.v.data!=null) {
			// User login
			// Debug.Log ("onLogin: " + login + ", " + connectionToClient+", "+login.imei);
			User user = null;
			// Find already have this user
			{
				foreach (User check in serverManager.data.server.v.data.users.vs) {
					if (check.human.v.account.v.isEqual (accountMessage)) {
						user = check;
					}
				}
			}
			// Make new user
			if (user == null) {
				if (accountMessage.getType () != Account.Type.EMAIL) {
					// Make new user
					user = new User ();
					{
						// UniqueId
						user.uid = serverManager.data.server.v.data.users.makeId ();
						user.human.v.playerId.v = user.uid;
						// account
						{
							Account newAccount = (Account)DataUtils.cloneData (accountMessage.makeAccount ());
							{
								newAccount.uid = user.human.v.account.makeId ();
							}
							user.human.v.account.v = newAccount;
						}
						user.registerTime.v = Global.getRealTimeInMiliSeconds ();
					}
					serverManager.data.server.v.data.users.add (user);
					// add message register
					{
						// Find user topic
						UserTopic userTopic = null;
						{
							ChatRoom chatRoom = user.chatRoom.v;
							if (chatRoom != null) {
								if (chatRoom.topic.v != null && chatRoom.topic.v is UserTopic) {
									userTopic = chatRoom.topic.v as UserTopic;
								}
							} else {
								Debug.LogError ("chatRoom null");
							}
						}
						// add message
						if (userTopic != null) {
							userTopic.addUserAction (user.human.v.playerId.v, UserActionMessage.Action.Register);
						} else {
							Debug.LogError ("userTopic null: " + this);
						}
					}
				} else {
					Debug.LogError ("email: cannot create new");
				}
			} else {
				user.human.v.account.v.updateAccount (accountMessage);
				// add message login
				{
					// Find user topic
					UserTopic userTopic = null;
					{
						ChatRoom chatRoom = user.chatRoom.v;
						if (chatRoom != null) {
							if (chatRoom.topic.v != null && chatRoom.topic.v is UserTopic) {
								userTopic = chatRoom.topic.v as UserTopic;
							}
						} else {
							Debug.LogError ("chatRoom null");
						}
					}
					// add message
					if (userTopic != null) {
						userTopic.addUserAction (user.human.v.playerId.v, UserActionMessage.Action.Login);
					} else {
						Debug.LogError ("userTopic null: " + this);
					}
				}
			}
			// Update data
			if (user != null) {
				user.ipAddress.v = connectionToClient.address;
				// check correct 
				if (user.human.v.account.v.checkCorrectAccount (accountMessage)) {
					// Update data
					{
						// State
						{
							user.human.v.state.v.state.v = UserState.State.Online;
							user.human.v.state.v.time.v = Global.getRealTimeInMiliSeconds ();
						}
						user.human.v.connection.v = connectionToClient;
					}
					// update chat
					{
						ChatViewer.UpdateChatViewer (user.human.v.playerId.v, currentChatViewer);
					}
					// connectionToClient.address
					// Inform login success
					TargetLoginSuccess(connectionToClient);
				} else {
					Debug.LogError ("account not correct: " + accountMessage + "; " + this);
					TargetLoginError (connectionToClient);
				}
			} else {
				Debug.LogError ("user null: " + this);
				TargetLoginEmailError (connectionToClient);
			}
			// Destroy old identity
			{
				List<uint> destroyIds = new List<uint> ();
				{
					for (int i = checkIds.Length - 1; i >= 0; i--) {
						uint checkId = checkIds [i];
						Debug.Log ("checkIds: " + checkId);
						if (!NetworkIdentity.spawned.ContainsKey (checkId)) {
							Debug.LogError ("Don't contain networkIdentity anymore: " + checkId);
							destroyIds.Add (checkId);
						} else {
							// Debug.Log ("still contain networkIdentity: " + checkId);
						}
					}
				}
				// Target destroy
				TargetSendDestroyIdentity (connectionToClient, destroyIds.ToArray());
			}
		} else {
			// Debug.LogError ("Why server manager null");
		}
	}

	[TargetRpc]
	public void TargetLoginSuccess(NetworkConnection target)
	{
		// ServerManager serverManager = ServerManager.instance;
		if (serverManager != null) {
			ServerManager.UIData serverUIData = serverManager.data;
			if (serverUIData != null) {
				Server server = serverUIData.server.v.data;
				if (server != null) {
					Server.State.Disconnect disconnect = server.state.v as Server.State.Disconnect;
					if (disconnect != null) {
						// set connect
						{
							Server.State.Connect connect = new Server.State.Connect ();
							{
								connect.uid = serverManager.data.server.v.data.state.makeId ();
							}
							serverManager.data.server.v.data.state.v = connect;
						}
					} else {
						Debug.LogError ("disconnect null: " + this);
					}
				} else {
					Debug.LogError ("server null: " + this);
				}
			} else {
				Debug.LogError ("serverUIData null: " + this);
			}
		} else {
			Debug.LogError ("serverManager null: " + this);
		}
	}

	[TargetRpc]
	public void TargetLoginEmailError(NetworkConnection target)
	{
		Debug.LogError ("login email error: " + this);
	}

	[TargetRpc]
	public void TargetLoginError(NetworkConnection target)
	{
		Debug.LogError ("login error: " + this);
	}

	[Command]
	public void CmdRegisterEmailAccount(AccountEmailMessage accountEmailMessage)
	{
		if (serverManager != null && serverManager.data!=null && serverManager.data.server.v.data!=null) {
			// User login
			// Debug.Log ("onLogin: " + login + ", " + connectionToClient+", "+login.imei);
			User user = null;
			// Find already have this user
			{
				foreach (User check in serverManager.data.server.v.data.users.vs) {
					if (check.human.v.account.v.isEqual (accountEmailMessage)) {
						user = check;
					}
				}
			}
			// Make new user
			if (user == null) {
				// Make new user
				{
					user = new User ();
					{
						// UniqueId
						user.uid = serverManager.data.server.v.data.users.makeId ();
						user.human.v.playerId.v = user.uid;
						// account
						{
							Account newAccount = (Account)DataUtils.cloneData (accountEmailMessage.makeAccount ());
							{
								newAccount.uid = user.human.v.account.makeId ();
							}
							user.human.v.account.v = newAccount;
						}
						user.registerTime.v = Global.getRealTimeInMiliSeconds ();
					}
					serverManager.data.server.v.data.users.add (user);
				}
				// Update data
				{
					// State
					{
						user.human.v.state.v.state.v = UserState.State.Online;
						user.human.v.state.v.time.v = Global.getRealTimeInMiliSeconds ();
					}
					user.human.v.connection.v = connectionToClient;
				}
				// add message register
				{
					// Find user topic
					UserTopic userTopic = null;
					{
						ChatRoom chatRoom = user.chatRoom.v;
						if (chatRoom != null) {
							if (chatRoom.topic.v != null && chatRoom.topic.v is UserTopic) {
								userTopic = chatRoom.topic.v as UserTopic;
							}
						} else {
							Debug.LogError ("chatRoom null");
						}
					}
					// add message
					if (userTopic != null) {
						userTopic.addUserAction (user.human.v.playerId.v, UserActionMessage.Action.Register);
					} else {
						Debug.LogError ("userTopic null: " + this);
					}
				}
			} else {
				Debug.LogError ("already have email: " + this);
				TargetRegisterError (connectionToClient);
			}
		} else {
			Debug.LogError ("Why server manager null: " + this);
		}
	}

	[TargetRpc]
	public void TargetRegisterError(NetworkConnection target)
	{
		Debug.LogError ("register error: " + this);
		Toast.showMessage ("register error");
	}

	[TargetRpc]
	public void TargetRegisterSuccess(NetworkConnection target)
	{
		Debug.LogError ("register success: " + this);
		Toast.showMessage ("register success");
	}

	[Command]
	public void CmdLogOut(uint networkIdentityId, uint userId)
	{
		Debug.LogError ("cmdLogout: " + userId + "; " + this);
		// TargetLogOut
		TargetLogout(connectionToClient);
        // Update
        UserIdentity userIdentity = GetDataIdentity<UserIdentity>(networkIdentityId);
        if (userIdentity != null)
        {
            userIdentity.logOut(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[TargetRpc]
	public void TargetLogout(NetworkConnection target)
	{
		Debug.LogError ("Target logout: " + this);
		// ServerManager serverManager = ServerManager.instance;
		if (serverManager != null && serverManager.data != null && serverManager.data.server.v.data != null) {
			if (serverManager.data.server.v.data.state.v.getType () == Server.State.Type.Connect) {
				Server.State.Connect connect = serverManager.data.server.v.data.state.v as Server.State.Connect;
				if (connect.state.v == Server.State.Connect.State.LoggingOut) {
					serverManager.logOut ();
				}
			}
		} else {
			// Debug.LogError ("logOut: clientManager null");
		}
	}

	/////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////// Human ////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////

	[Command]
	public void CmdHumanChangeEmail(uint networkIdentityId, uint userId, string newEmail)
	{
        // Call
        HumanIdentity humanIdentity = GetDataIdentity<HumanIdentity>(networkIdentityId);
        if (humanIdentity != null)
        {
            humanIdentity.changeEmail(userId, newEmail);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdHumanChangePhoneNumber(uint networkIdentityId, uint userId, string newPhoneNumber)
	{
        // Call
        HumanIdentity humanIdentity = GetDataIdentity<HumanIdentity>(networkIdentityId);
        if (humanIdentity != null)
        {
            humanIdentity.changePhoneNumber(userId, newPhoneNumber);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdHumanChangeStatus(uint networkIdentityId, uint userId, string newStatus)
	{
        // Call
        HumanIdentity humanIdentity = GetDataIdentity<HumanIdentity>(networkIdentityId);
        if (humanIdentity != null)
        {
            humanIdentity.changeStatus(userId, newStatus);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdHumanChangeBirthday(uint networkIdentityId, uint userId, long newBirthday)
	{
        HumanIdentity humanIdentity = GetDataIdentity<HumanIdentity>(networkIdentityId);
        if (humanIdentity != null)
        {
            humanIdentity.changeBirthday(userId, newBirthday);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdHumanChangeSex(uint networkIdentityId, uint userId, User.SEX newSex)
	{
        HumanIdentity humanIdentity = GetDataIdentity<HumanIdentity>(networkIdentityId);
        if (humanIdentity != null)
        {
            humanIdentity.changeSex(userId, newSex);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	/////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////// Account ////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////

	#region Account Admin

	[Command]
	public void CmdAccountAdminChangeCustomName(uint networkIdentityId, uint userId, string newCustomName)
	{
        AccountAdminIdentity accountAdminIdentity = GetDataIdentity<AccountAdminIdentity>(networkIdentityId);
        if (accountAdminIdentity != null)
        {
            accountAdminIdentity.changeCustomName(userId, newCustomName);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdAccountAdminChangeAvatarUrl(uint networkIdentityId, uint userId, string newAvatarUrl)
	{
        AccountAdminIdentity accountAdminIdentity = GetDataIdentity<AccountAdminIdentity>(networkIdentityId);
        if (accountAdminIdentity != null)
        {
            accountAdminIdentity.changeAvatarUrl(userId, newAvatarUrl);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	#region Account Device

	[Command]
	public void CmdAccountDeviceChangeCustomName(uint networkIdentityId, uint userId, string newCustomName)
	{
        AccountDeviceIdentity accountDeviceIdentity = GetDataIdentity<AccountDeviceIdentity>(networkIdentityId);
        if (accountDeviceIdentity != null)
        {
            accountDeviceIdentity.changeCustomName(userId, newCustomName);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdAccountDeviceChangeAvatarUrl(uint networkIdentityId, uint userId, string newAvatarUrl)
	{
        AccountDeviceIdentity accountDeviceIdentity = GetDataIdentity<AccountDeviceIdentity>(networkIdentityId);
        if (accountDeviceIdentity != null)
        {
            accountDeviceIdentity.changeAvatarUrl(userId, newAvatarUrl);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	#region Account Email

	[Command]
	public void CmdAccountEmailChangePassword(uint networkIdentityId, uint userId, string newPassword, string oldPassword)
	{
        AccountEmailIdentity accountEmailIdentity = GetDataIdentity<AccountEmailIdentity>(networkIdentityId);
        if (accountEmailIdentity != null)
        {
            accountEmailIdentity.changePassword(userId, newPassword, oldPassword);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdAccountEmailChangeCustomName(uint networkIdentityId, uint userId, string newCustomName)
	{
        AccountEmailIdentity accountEmailIdentity = GetDataIdentity<AccountEmailIdentity>(networkIdentityId);
        if (accountEmailIdentity != null)
        {
            accountEmailIdentity.changeCustomName(userId, newCustomName);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdAccountEmailChangeAvatarUrl(uint networkIdentityId, uint userId, string newAvatarUrl)
	{
        AccountEmailIdentity accountEmailIdentity = GetDataIdentity<AccountEmailIdentity>(networkIdentityId);
        if (accountEmailIdentity != null)
        {
            accountEmailIdentity.changeAvatarUrl(userId, newAvatarUrl);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	#region Room

	#region password

	[Command]
	public void CmdRoomJoinRoom(uint networkIdentityId, uint userId, string password)
	{
        RoomIdentity roomIdentity = GetDataIdentity<RoomIdentity>(networkIdentityId);
        if (roomIdentity != null)
        {
            roomIdentity.joinRoom(userId, password, this);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[TargetRpc]
	public void TargetJoinRoomError(NetworkConnection target, Room.JoinRoomState joinRoomState)
	{
		Debug.LogError ("join room error: " + joinRoomState);
		Toast.showMessage ("join room error: " + joinRoomState);
	}

	[Command]
	public void CmdRoomChangeName(uint networkIdentityId, uint userId, string newName)
	{
        RoomIdentity roomIdentity = GetDataIdentity<RoomIdentity>(networkIdentityId);
        if (roomIdentity != null)
        {
            roomIdentity.changeName(userId, newName);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdRoomChangeAllowHint(uint networkIdentityId, uint userId, int newAllowHint)
	{
        RoomIdentity roomIdentity = GetDataIdentity<RoomIdentity>(networkIdentityId);
        if (roomIdentity != null)
        {
            roomIdentity.changeAllowHint(userId, newAllowHint);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	#region roomState

	[Command]
	public void CmdRoomStateNormalNormalFreeze(uint networkIdentityId, uint userId)
	{
        RoomStateNormalNormalIdentity roomStateNormalNormalIdentity = GetDataIdentity<RoomStateNormalNormalIdentity>(networkIdentityId);
        if (roomStateNormalNormalIdentity != null)
        {
            roomStateNormalNormalIdentity.freeze(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdRoomStateNormalFreezeUnFreeze(uint networkIdentityId, uint userId)
	{
        RoomStateNormalFreezeIdentity roomStateNormalFreezeIdentity = GetDataIdentity<RoomStateNormalFreezeIdentity>(networkIdentityId);
        if (roomStateNormalFreezeIdentity != null)
        {
            roomStateNormalFreezeIdentity.unFreeze(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	[Command]
	public void CmdUserChangeRole(uint networkIdentityId, uint userId, User.Role newRole)
	{
        UserIdentity userIdentity = GetDataIdentity<UserIdentity>(networkIdentityId);
        if (userIdentity != null)
        {
            userIdentity.changeRole(userId, newRole);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdUserMakeFriendRequest(uint networkIdentityId, uint friendId)
	{
        UserIdentity userIdentity = GetDataIdentity<UserIdentity>(networkIdentityId);
        if (userIdentity != null)
        {
            userIdentity.makeFriendRequest(friendId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#region Ban

	[Command]
	public void CmdBanNormalBan(uint networkIdentityId, uint userId)
	{
        BanNormalIdentity banNormalIdentity = GetDataIdentity<BanNormalIdentity>(networkIdentityId);
        if (banNormalIdentity != null)
        {
            banNormalIdentity.ban(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdBanBanUnBan(uint networkIdentityId, uint userId)
	{
        BanBanIdentity banBanIdentity = GetDataIdentity<BanBanIdentity>(networkIdentityId);
        if (banBanIdentity != null)
        {
            banBanIdentity.unBan(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	#endregion

	[TargetRpc]
	public void TargetSendMessage(NetworkConnection target, string message)
	{
		Debug.Log (message);
	}

	[TargetRpc]
	public void TargetSendDestroyIdentity(NetworkConnection target, uint[] destroyIds)
	{
		NetworkIdentity[] identities = FindObjectsOfType<NetworkIdentity> ();
		for (int i = identities.Length - 1; i >= 0; i--) {
			NetworkIdentity identity = identities [i];
			// Check contain
			bool contain = false;
			{
				for (int j = 0; j < destroyIds.Length; j++) {
					if (destroyIds [j] == identity.netId) {
						contain = true;
						break;
					}
				}
			}
			// Process
			if (contain) {
                Debug.LogError("destroy object: " + identity + ", " + identity.netId);
				Destroy (identity.gameObject);
			}
		}
	}

	#endregion

	#region UndoRedoRequest

	[Command]
	public void CmdUndoRedoNoneAskLastTurn(uint networkIdentityId, uint userId, UndoRedoRequest.Operation operation)
	{
        UndoRedo.NoneIdentity noneIdentity = GetDataIdentity<UndoRedo.NoneIdentity>(networkIdentityId);
        if (noneIdentity != null)
        {
            noneIdentity.askLastTurn(userId, operation);
        }
        else
        {
            Debug.LogError("identity null");
        }
    }

	[Command]
	public void CmdUndoRedoNoneAskLastYourTurn(uint networkIdentityId, uint userId, UndoRedoRequest.Operation operation)
	{
        UndoRedo.NoneIdentity noneIdentity = GetDataIdentity<UndoRedo.NoneIdentity>(networkIdentityId);
        if (noneIdentity != null)
        {
            noneIdentity.askLastYourTurn(userId, operation);
        }
        else
        {
            Debug.LogError("identity null");
        }
    }

	[Command]
	public void CmdUndoRedoAskAnswer(uint networkIdentityId, uint userId, UndoRedo.Ask.Answer answer)
	{
        UndoRedo.AskIdentity noneIdentity = GetDataIdentity<UndoRedo.AskIdentity>(networkIdentityId);
        if (noneIdentity != null)
        {
            noneIdentity.answer(userId, answer);
        }
        else
        {
            Debug.LogError("identity null");
        }
    }

	#endregion

	#region Player

	[Command]
	public void CmdPlayerLeaveRoom(uint networkIdentityId)
	{
        RoomUserIdentity roomUserIdentity = GetDataIdentity<RoomUserIdentity>(networkIdentityId);
        if (roomUserIdentity != null)
        {
            roomUserIdentity.leaveRoom();
        }
        else
        {
            Debug.LogError("identity null");
        }
    }

	[Command]
	public void CmdRoomUserKick(uint networkIdentityId, uint adminId)
	{
        RoomUserIdentity roomUserIdentity = GetDataIdentity<RoomUserIdentity>(networkIdentityId);
        if (roomUserIdentity != null)
        {
            roomUserIdentity.kick(adminId);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdRoomUserUnKick(uint networkIdentityId, uint adminId)
	{
        RoomUserIdentity roomUserIdentity = GetDataIdentity<RoomUserIdentity>(networkIdentityId);
        if (roomUserIdentity != null)
        {
            roomUserIdentity.unKick(adminId);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#region RequestDraw

	[Command]
	public void CmdRequestDrawStateNoneMakeRequest(uint networkIdentityId, uint userId)
	{
        RequestDrawStateNoneIdentity requestDrawStateNoneIdentity = GetDataIdentity<RequestDrawStateNoneIdentity>(networkIdentityId); if (requestDrawStateNoneIdentity != null)
        {
            requestDrawStateNoneIdentity.makeRequestDraw(userId);
        }
        else
        {
            Debug.LogError("playerInfoIdentity null");
        }
    }

	[Command]
	public void CmdRequestDrawStateAskAnswer(uint networkIdentityId, uint userId, RequestDrawStateAsk.Answer answer)
	{
        RequestDrawStateAskIdentity requestDrawStateAskIdentity = GetDataIdentity<RequestDrawStateAskIdentity>(networkIdentityId);
        if (requestDrawStateAskIdentity != null)
        {
            requestDrawStateAskIdentity.answer(userId, answer);
        }
        else
        {
            Debug.LogError("identity null");
        }
    }

	[Command]
	public void CmdRequestDrawStateAcceptAnswer(uint networkIdentityId, uint userId, RequestDrawStateAccept.Answer answer)
	{
        RequestDrawStateAcceptIdentity requestDrawStateAcceptIdentity = GetDataIdentity<RequestDrawStateAcceptIdentity>(networkIdentityId);
        if (requestDrawStateAcceptIdentity != null)
        {
            requestDrawStateAcceptIdentity.answer(userId, answer);
        }
        else
        {
            Debug.LogError("identity null");
        }
    }

	#endregion

	#region GameFactory

	[Command]
	public void CmdGameFactoryChangeGameDataFactoryType(uint networkIdentityId, uint userId, GameDataFactory.Type newType)
	{
        GameFactoryIdentity gameFactoryIdentity = GetDataIdentity<GameFactoryIdentity>(networkIdentityId);
        if (gameFactoryIdentity != null)
        {
            gameFactoryIdentity.changeGameDataFactoryType(userId, newType);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	#region PostureGameDataFactory

	[Command]
	public void CmdPostureGameDataFactoryChangeGameData(uint networkIdentityId, uint userId, byte[] gameDataBytes)
	{
        PostureGameDataFactoryIdentity postureGameDataFactoryIdentity = GetDataIdentity<PostureGameDataFactoryIdentity>(networkIdentityId);
        if (postureGameDataFactoryIdentity != null)
        {
            // find gameData
            GameData gameData = null;
            {
                if (gameDataBytes != null)
                {
                    try
                    {
                        using (BinaryReader reader = new BinaryReader(new MemoryStream(gameDataBytes)))
                        {
                            Data gameDataData = Data.parseBinary(reader);
                            if (gameDataData != null)
                            {
                                if (gameDataData is GameData)
                                {
                                    gameData = gameDataData as GameData;
                                }
                            }
                            else
                            {
                                Debug.LogError("gameDataData null: " + this);
                            }
                        }
                    }
                    catch (System.Exception e)
                    {
                        Debug.LogError(e);
                    }
                }
                else
                {
                    Debug.LogError("gameDataBytes null: " + this);
                }
            }
            // process
            if (gameData != null)
            {
                postureGameDataFactoryIdentity.changeGameData(userId, gameData);
            }
            else
            {
                Debug.LogError("gameData null");
            }
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdPostureGameDataFactoryChangeType(uint networkIdentityId, uint userId, GameType.Type newGameType)
	{
        PostureGameDataFactoryIdentity postureGameDataFactoryIdentity = GetDataIdentity<PostureGameDataFactoryIdentity>(networkIdentityId);
        if (postureGameDataFactoryIdentity != null)
        {
            postureGameDataFactoryIdentity.changeType(userId, newGameType);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	#region DefaultGameDataFactory

	[Command]
	public void CmdDefaultGameDataFactoryChangeType(uint networkIdentityId, uint userId, GameType.Type newGameType)
	{
        DefaultGameDataFactoryIdentity defaultGameDataFactoryIdentity = GetDataIdentity<DefaultGameDataFactoryIdentity>(networkIdentityId);
        if (defaultGameDataFactoryIdentity != null)
        {
            defaultGameDataFactoryIdentity.changeType(userId, newGameType);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdDefaultGameDataFactoryChangeUseRule(uint networkIdentityId, uint userId, bool newUseRule)
	{
        DefaultGameDataFactoryIdentity defaultGameDataFactoryIdentity = GetDataIdentity<DefaultGameDataFactoryIdentity>(networkIdentityId);
        if (defaultGameDataFactoryIdentity != null)
        {
            defaultGameDataFactoryIdentity.changeUseRule(userId, newUseRule);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	#region PostureGameDataFactory

	[Command]
	public void CmdPostureGameDataFactoryChangeUseRule(uint networkIdentityId, uint userId, bool newUseRule)
	{
        PostureGameDataFactoryIdentity postureGameDataFactoryIdentity = GetDataIdentity<PostureGameDataFactoryIdentity>(networkIdentityId);
        if (postureGameDataFactoryIdentity != null)
        {
            postureGameDataFactoryIdentity.changeUseRule(userId, newUseRule);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	#region GamePlayer

	[Command]
	public void CmdGamePlayerStateNormalSurrender(uint networkIdentityId, uint userId)
	{
        GamePlayerStateNormalIdentity gamePlayerStateNormalIdentity = GetDataIdentity<GamePlayerStateNormalIdentity>(networkIdentityId);
        if (gamePlayerStateNormalIdentity != null)
        {
            gamePlayerStateNormalIdentity.surrender(userId);
        }
        else
        {
            Debug.LogError("identity null");
        }
    }

	#endregion

	#region Game State

	[Command]
	public void CmdPlayNormalPause(uint networkIdentityId, uint userId)
	{
        GameState.PlayNormalIdentity playNormalIdentity = GetDataIdentity<GameState.PlayNormalIdentity>(networkIdentityId);
        if (playNormalIdentity != null)
        {
            playNormalIdentity.pause(userId);
        }
        else
        {
            Debug.LogError("identity null");
        }
    }

	[Command]
	public void CmdPlayPauseUnPause(uint networkIdentityId, uint userId)
	{
        GameState.PlayPauseIdentity playPauseIdentity = GetDataIdentity<GameState.PlayPauseIdentity>(networkIdentityId);
        if (playPauseIdentity != null)
        {
            playPauseIdentity.unPause(userId);
        }
        else
        {
            Debug.LogError("identity null");
        }
    }

	#endregion

	#region GamePlayerStateSurrender

	[Command]
	public void CmdGamePlayerStateSurrenderNoneMakeRequestCancel(uint networkIdentityId, uint userId)
	{
        GamePlayerStateSurrenderNoneIdentity gamePlayerStateSurrenderNoneIdentity = GetDataIdentity<GamePlayerStateSurrenderNoneIdentity>(networkIdentityId);
        if (gamePlayerStateSurrenderNoneIdentity != null)
        {
            gamePlayerStateSurrenderNoneIdentity.makeRequestCancel(userId);
        }
        else
        {
            Debug.LogError("identity null");
        }
    }

	[Command]
	public void CmdGamePlayerStateSurrenderAskAccept(uint networkIdentityId, uint userId)
	{
        GamePlayerStateSurrenderAskIdentity gamePlayerStateSurrenderAskIdentity = GetDataIdentity<GamePlayerStateSurrenderAskIdentity>(networkIdentityId);
        if (gamePlayerStateSurrenderAskIdentity != null)
        {
            gamePlayerStateSurrenderAskIdentity.accept(userId);
        }
        else
        {
            Debug.LogError("identity null");
        }
    }

	[Command]
	public void CmdGamePlayerStateSurrenderAskRefuse(uint networkIdentityId, uint userId)
	{
        GamePlayerStateSurrenderAskIdentity gamePlayerStateSurrenderAskIdentity = GetDataIdentity<GamePlayerStateSurrenderAskIdentity>(networkIdentityId);
        if (gamePlayerStateSurrenderAskIdentity != null)
        {
            gamePlayerStateSurrenderAskIdentity.refuse(userId);
        }
        else
        {
            Debug.LogError("identity null");
        }
    }

	#endregion

	[Command]
	public void CmdHistoryAddHumanConnection(uint networkIdentityId, uint userId)
	{
        HistoryIdentity historyIdentity = GetDataIdentity<HistoryIdentity>(networkIdentityId);
        if (historyIdentity != null)
        {
            historyIdentity.addHumanConnection(userId);
        }
        else
        {
            Debug.LogError("identity null");
        }
    }

	[Command]
	public void CmdHistoryRemoveHumanConnection(uint networkIdentityId, uint userId)
	{
        HistoryIdentity historyIdentity = GetDataIdentity<HistoryIdentity>(networkIdentityId);
        if (historyIdentity != null)
        {
            historyIdentity.removeHumanConnection(userId);
        }
        else
        {
            Debug.LogError("identity null");
        }
    }

	#region Friend

	[Command]
	public void CmdFriendStateNoneMakeFriend(uint networkIdentityId, uint userId){
        FriendStateNoneIdentity friendStateNoneIdentity = GetDataIdentity<FriendStateNoneIdentity>(networkIdentityId);
        if (friendStateNoneIdentity != null)
        {
            friendStateNoneIdentity.makeFriend(userId);
        }
        else
        {
            Debug.LogError("identity null");
        }
    }

	[Command]
	public void CmdFriendStateNoneBan(uint networkIdentityId, uint userId){
        FriendStateNoneIdentity friendStateNoneIdentity = GetDataIdentity<FriendStateNoneIdentity>(networkIdentityId);
        if (friendStateNoneIdentity != null)
        {
            friendStateNoneIdentity.ban(userId);
        }
        else
        {
            Debug.LogError("identity null");
        }
    }

	#region friendStateRequest

	[Command]
	public void CmdFriendStateRequestAccept(uint networkIdentityId, uint userId){
        FriendStateRequestIdentity friendStateRequestIdentity = GetDataIdentity<FriendStateRequestIdentity>(networkIdentityId);
        if (friendStateRequestIdentity != null)
        {
            friendStateRequestIdentity.accept(userId);
        }
        else
        {
            Debug.LogError("identity null");
        }
    }

	[Command]
	public void CmdFriendStateRequestRefuse(uint networkIdentityId, uint userId){
        FriendStateRequestIdentity friendStateRequestIdentity = GetDataIdentity<FriendStateRequestIdentity>(networkIdentityId);
        if (friendStateRequestIdentity != null)
        {
            friendStateRequestIdentity.refuse(userId);
        }
        else
        {
            Debug.LogError("identity null");
        }
    }

	[Command]
	public void CmdFriendStateRequestCancel(uint networkIdentityId, uint userId){
        FriendStateRequestIdentity friendStateRequestIdentity = GetDataIdentity<FriendStateRequestIdentity>(networkIdentityId);
        if (friendStateRequestIdentity != null)
        {
            friendStateRequestIdentity.cancel(userId);
        }
        else
        {
            Debug.LogError("identity null");
        }
    }

	#endregion

	[Command]
	public void CmdFriendStateAcceptUnFriend(uint networkIdentityId, uint userId){
        FriendStateAcceptIdentity friendStateAcceptIdentity = GetDataIdentity<FriendStateAcceptIdentity>(networkIdentityId);
        if (friendStateAcceptIdentity != null)
        {
            friendStateAcceptIdentity.unFriend(userId);
        }
        else
        {
            Debug.LogError("identity null");
        }
    }

	[Command]
	public void CmdFriendStateBanUnBan(uint networkIdentityId, uint userId){
        FriendStateBanIdentity friendStateBanIdentity = GetDataIdentity<FriendStateBanIdentity>(networkIdentityId);
        if (friendStateBanIdentity != null)
        {
            friendStateBanIdentity.unBan(userId);
        }
        else
        {
            Debug.LogError("identity null");
        }
    }

	#endregion

	#endregion

	#region Chat

	[Command]
	public void CmdChatRoomLoadMore(uint networkIdentityId, uint userId, uint loadMoreCount)
	{
        ChatRoomIdentity chatRoomIdentity = GetDataIdentity<ChatRoomIdentity>(networkIdentityId);
        if (chatRoomIdentity != null)
        {
            chatRoomIdentity.loadMore(userId, loadMoreCount);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdChatRoomSendNormalMessage(uint networkIdentityId, uint userId, string message)
	{
        ChatRoomIdentity chatRoomIdentity = GetDataIdentity<ChatRoomIdentity>(networkIdentityId);
        if (chatRoomIdentity != null)
        {
            chatRoomIdentity.sendNormalMessage(userId, message);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdChatMessageChangeState(uint networkIdentityId, uint userId, ChatMessage.State newState)
	{
        ChatMessageIdentity chatMessageIdentity = GetDataIdentity<ChatMessageIdentity>(networkIdentityId);
        if (chatMessageIdentity != null)
        {
            chatMessageIdentity.changeState(userId, newState);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdChatNormalContentEdit(uint networkIdentityId, uint userId, string newMessage)
	{
        ChatNormalContentIdentity chatNormalContentIdentity = GetDataIdentity<ChatNormalContentIdentity>(networkIdentityId);
        if (chatNormalContentIdentity != null)
        {
            chatNormalContentIdentity.edit(userId, newMessage);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	#region Typing

	[Command]
	public void CmdTypingSendTyping(uint networkIdentityId, uint userId)
	{
        TypingIdentity typingIdentity = GetDataIdentity<TypingIdentity>(networkIdentityId);
        if (typingIdentity != null)
        {
            typingIdentity.sendTyping(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	//////////////////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////// Default ////////////////////////////
	//////////////////////////////////////////////////////////////////////////////////////////////////////

	#region Default

	[Command]
	public void CmdDefaultChessChangeChess960(uint networkIdentityId, uint userId, bool newChess960)
	{
        Chess.DefaultChessIdentity defaultChessIdentity = GetDataIdentity<Chess.DefaultChessIdentity>(networkIdentityId);
        if (defaultChessIdentity != null)
        {
            defaultChessIdentity.changeChess960(userId, newChess960);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdDefaultShatranjChangeChess960(uint networkIdentityId, uint userId, bool newChess960)
	{
        Shatranj.DefaultShatranjIdentity defaultShatranjIdentity = GetDataIdentity<Shatranj.DefaultShatranjIdentity>(networkIdentityId);
        if (defaultShatranjIdentity != null)
        {
            defaultShatranjIdentity.changeChess960(userId, newChess960);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdDefaultMakrukChangeChess960(uint networkIdentityId, uint userId, bool newChess960)
	{
        Makruk.DefaultMakrukIdentity defaultMakrukIdentity = GetDataIdentity<Makruk.DefaultMakrukIdentity>(networkIdentityId);
        if (defaultMakrukIdentity != null)
        {
            defaultMakrukIdentity.changeChess960(userId, newChess960);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdDefaultSeirawanChangeChess960(uint networkIdentityId, uint userId, bool newChess960)
	{
        Seirawan.DefaultSeirawanIdentity defaultSeirawanIdentity = GetDataIdentity<Seirawan.DefaultSeirawanIdentity>(networkIdentityId);
        if (defaultSeirawanIdentity != null)
        {
            defaultSeirawanIdentity.changeChess960(userId, newChess960);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#region DefaultFairyChess

	[Command]
	public void CmdDefaultFairyChessChangeVariantType(uint networkIdentityId, uint userId, FairyChess.Common.VariantType newVariantType)
	{
        FairyChess.DefaultFairyChessIdentity defaultFairyChessIdentity = GetDataIdentity<FairyChess.DefaultFairyChessIdentity>(networkIdentityId);
        if (defaultFairyChessIdentity != null)
        {
            defaultFairyChessIdentity.changeVariantType(userId, newVariantType);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdDefaultFairyChessChangeChess960(uint networkIdentityId, uint userId, bool newChess960)
	{
        FairyChess.DefaultFairyChessIdentity defaultFairyChessIdentity = GetDataIdentity<FairyChess.DefaultFairyChessIdentity>(networkIdentityId);
        if (defaultFairyChessIdentity != null)
        {
            defaultFairyChessIdentity.changeChess960(userId, newChess960);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region DefaultCoTuongUp

	[Command]
	public void CmdDefaultCoTuongUpChangeAllowViewCapture(uint networkIdentityId, uint userId, bool newAllowViewCapture)
	{
        CoTuongUp.DefaultCoTuongUpIdentity defaultCoTuongUpIdentity = GetDataIdentity<CoTuongUp.DefaultCoTuongUpIdentity>(networkIdentityId);
        if (defaultCoTuongUpIdentity != null)
        {
            defaultCoTuongUpIdentity.changeAllowViewCapture(userId, newAllowViewCapture);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdDefaultCoTuongUpChangeAllowWatcherViewHidden(uint networkIdentityId, uint userId, bool newAllowViewHidden)
	{
        CoTuongUp.DefaultCoTuongUpIdentity defaultCoTuongUpIdentity = GetDataIdentity<CoTuongUp.DefaultCoTuongUpIdentity>(networkIdentityId);
        if (defaultCoTuongUpIdentity != null)
        {
            defaultCoTuongUpIdentity.changeAllowWatcherViewHidden(userId, newAllowViewHidden);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdDefaultCoTuongUpChangeAllowOnlyFlip(uint networkIdentityId, uint userId, bool newAllowViewFlip)
	{
        CoTuongUp.DefaultCoTuongUpIdentity defaultCoTuongUpIdentity = GetDataIdentity<CoTuongUp.DefaultCoTuongUpIdentity>(networkIdentityId);
        if (defaultCoTuongUpIdentity != null)
        {
            defaultCoTuongUpIdentity.changeAllowViewFlip(userId, newAllowViewFlip);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	[Command]
	public void CmdDefaultGomokuChangeBoardSize(uint networkIdentityId, uint userId, int newBoardSize)
	{
        Gomoku.DefaultGomokuIdentity defaultGomokuIdentity = GetDataIdentity<Gomoku.DefaultGomokuIdentity>(networkIdentityId);
        if (defaultGomokuIdentity != null)
        {
            defaultGomokuIdentity.changeBoardSize(userId, newBoardSize);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdDefaultEnglishDraughtChangeMaxPly(uint networkIdentityId, uint userId, int newMaxPly)
	{
        EnglishDraught.DefaultEnglishDraughtIdentity defaultEnglishDraughtIdentity = GetDataIdentity<EnglishDraught.DefaultEnglishDraughtIdentity>(networkIdentityId);
        if (defaultEnglishDraughtIdentity != null)
        {
            defaultEnglishDraughtIdentity.changeMaxPly(userId, newMaxPly);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdDefaultEnglishDraughtChangeThreeMoveRandom(uint networkIdentityId, uint userId, bool newThreeMoveRandom)
	{
        EnglishDraught.DefaultEnglishDraughtIdentity defaultEnglishDraughtIdentity = GetDataIdentity<EnglishDraught.DefaultEnglishDraughtIdentity>(networkIdentityId);
        if (defaultEnglishDraughtIdentity != null)
        {
            defaultEnglishDraughtIdentity.changeThreeMoveRandom(userId, newThreeMoveRandom);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdDefaultInternationalDraughtChangeVariant(uint networkIdentityId, uint userId, int newVariant)
	{
        InternationalDraught.DefaultInternationalDraughtIdentity defaultInternationalDraughtIdentity = GetDataIdentity<InternationalDraught.DefaultInternationalDraughtIdentity>(networkIdentityId);
        if (defaultInternationalDraughtIdentity != null)
        {
            defaultInternationalDraughtIdentity.changeVariant(userId, newVariant);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdDefaultWeiqiChangeSize(uint networkIdentityId, uint userId, int newSize)
	{
        Weiqi.DefaultWeiqiIdentity defaultWeiqiIdentity = GetDataIdentity<Weiqi.DefaultWeiqiIdentity>(networkIdentityId);
        if (defaultWeiqiIdentity != null)
        {
            defaultWeiqiIdentity.changeSize(userId, newSize);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdDefaultWeiqiChangeKomi(uint networkIdentityId, uint userId, float newKomi)
	{
        Weiqi.DefaultWeiqiIdentity defaultWeiqiIdentity = GetDataIdentity<Weiqi.DefaultWeiqiIdentity>(networkIdentityId);
        if (defaultWeiqiIdentity != null)
        {
            defaultWeiqiIdentity.changeKomi(userId, newKomi);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdDefaultWeiqiChangeRule(uint networkIdentityId, uint userId, int newRule)
	{
        Weiqi.DefaultWeiqiIdentity defaultWeiqiIdentity = GetDataIdentity<Weiqi.DefaultWeiqiIdentity>(networkIdentityId);
        if (defaultWeiqiIdentity != null)
        {
            defaultWeiqiIdentity.changeRule(userId, newRule);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdDefaultWeiqiChangeHandicap(uint networkIdentityId, uint userId, int newHandicap)
	{
        Weiqi.DefaultWeiqiIdentity defaultWeiqiIdentity = GetDataIdentity<Weiqi.DefaultWeiqiIdentity>(networkIdentityId);
        if (defaultWeiqiIdentity != null)
        {
            defaultWeiqiIdentity.changeHandicap(userId, newHandicap);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region MineSweeper

	[Command]
	public void CmdDefaultMineSweeperChangeN(uint networkIdentityId, uint userId, int newN)
	{
        MineSweeper.DefaultMineSweeperIdentity defaultMineSweeperIdentity = GetDataIdentity<MineSweeper.DefaultMineSweeperIdentity>(networkIdentityId);
        if (defaultMineSweeperIdentity != null)
        {
            defaultMineSweeperIdentity.changeN(userId, newN);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdDefaultMineSweeperChangeM(uint networkIdentityId, uint userId, int newM)
	{
        MineSweeper.DefaultMineSweeperIdentity defaultMineSweeperIdentity = GetDataIdentity<MineSweeper.DefaultMineSweeperIdentity>(networkIdentityId);
        if (defaultMineSweeperIdentity != null)
        {
            defaultMineSweeperIdentity.changeM(userId, newM);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdDefaultMineSweeperChangeMinK(uint networkIdentityId, uint userId, float newMinK)
	{
        MineSweeper.DefaultMineSweeperIdentity defaultMineSweeperIdentity = GetDataIdentity<MineSweeper.DefaultMineSweeperIdentity>(networkIdentityId);
        if (defaultMineSweeperIdentity != null)
        {
            defaultMineSweeperIdentity.changeMinK(userId, newMinK);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdDefaultMineSweeperChangeMaxK(uint networkIdentityId, uint userId, float newMaxK)
	{
        MineSweeper.DefaultMineSweeperIdentity defaultMineSweeperIdentity = GetDataIdentity<MineSweeper.DefaultMineSweeperIdentity>(networkIdentityId);
        if (defaultMineSweeperIdentity != null)
        {
            defaultMineSweeperIdentity.changeMaxK(userId, newMaxK);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdDefaultMineSweeperChangeAllowWatchBomb(uint networkIdentityId, uint userId, bool newAllowWatchBomb)
	{
        MineSweeper.DefaultMineSweeperIdentity defaultMineSweeperIdentity = GetDataIdentity<MineSweeper.DefaultMineSweeperIdentity>(networkIdentityId);
        if (defaultMineSweeperIdentity != null)
        {
            defaultMineSweeperIdentity.changeAllowWatchBomb(userId, newAllowWatchBomb);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	[Command]
	public void CmdDefaultHexChangeBoardSize(uint networkIdentityId, uint userId, System.UInt16 newBoardSize)
	{
        HEX.DefaultHexIdentity defaultHexIdentity = GetDataIdentity<HEX.DefaultHexIdentity>(networkIdentityId);
        if (defaultHexIdentity != null)
        {
            defaultHexIdentity.changeBoardSize(userId, newBoardSize);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#region Solitaire

	[Command]
	public void CmdDefaultSolitaireChangeDrawCount(uint networkIdentityId, uint userId, int newDrawCount)
	{
        Solitaire.DefaultSolitaireIdentity defaultSolitaireIdentity = GetDataIdentity<Solitaire.DefaultSolitaireIdentity>(networkIdentityId);
        if (defaultSolitaireIdentity != null)
        {
            defaultSolitaireIdentity.changeDrawCount(userId, newDrawCount);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region Khet

	[Command]
	public void CmdDefaultKhetChangeStartPos(uint networkIdentityId, uint userId, Khet.DefaultKhet.StartPos newStartPos)
	{
        Khet.DefaultKhetIdentity defaultKhetIdentity = GetDataIdentity<Khet.DefaultKhetIdentity>(networkIdentityId);
        if (defaultKhetIdentity != null)
        {
            defaultKhetIdentity.changeStartPos(userId, newStartPos);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	//////////////////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////// Send Input ////////////////////////////
	//////////////////////////////////////////////////////////////////////////////////////////////////////

	#region WaitAIMoveInput

	[Command]
	public void CmdWaitAIMoveInputSendInput(uint networkIdentityId, uint userId, byte[] gameMoveBytes, float clientTime)
	{
        WaitInputActionIdentity waitInputActionIdentity = GetDataIdentity<WaitInputActionIdentity>(networkIdentityId);
        if (waitInputActionIdentity != null)
        {
            // find gameMove
            GameMove gameMove = null;
            {
                if (gameMoveBytes != null)
                {
                    try
                    {
                        using (BinaryReader reader = new BinaryReader(new MemoryStream(gameMoveBytes)))
                        {
                            Data gameMoveData = Data.parseBinary(reader);
                            if (gameMoveData != null)
                            {
                                if (gameMoveData is GameMove)
                                {
                                    gameMove = gameMoveData as GameMove;
                                }
                            }
                            else
                            {
                                Debug.LogError("gameMoveData null: " + this);
                            }
                        }
                    }
                    catch (System.Exception e)
                    {
                        Debug.LogError(e);
                    }
                }
                else
                {
                    Debug.LogError("gameMoveBytes null: " + this);
                }
            }
            // Process
            if (gameMove != null)
            {
                waitInputActionIdentity.sendInput(userId, gameMove, clientTime);
            }
            else
            {
                Debug.LogError("gameMove null: " + this);
            }
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////// TimeControl /////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////

	#region TimeControl

	[Command]
	public void CmdTimeReportClientTime(uint networkIdentityId, uint userId, float clientTime)
	{
        TimeReportClientIdentity timeReportClientIdentity = GetDataIdentity<TimeReportClientIdentity>(networkIdentityId);
        if (timeReportClientIdentity != null)
        {
            timeReportClientIdentity.reportClientTime(userId, clientTime);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdTimeControlChangeIsEnable(uint networkIdentityId, uint userId, bool newIsEnable)
	{
        TimeControl.TimeControlIdentity timeControlIdentity = GetDataIdentity<TimeControl.TimeControlIdentity>(networkIdentityId);
        if (timeControlIdentity != null)
        {
            timeControlIdentity.changeIsEnable(userId, newIsEnable);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdTimeControlChangeAICanTimeOut(uint networkIdentityId, uint userId, bool newAICanTimeOut)
	{
        TimeControl.TimeControlIdentity timeControlIdentity = GetDataIdentity<TimeControl.TimeControlIdentity>(networkIdentityId);
        if (timeControlIdentity != null)
        {
            timeControlIdentity.changeAICanTimeOut(userId, newAICanTimeOut);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdTimeControlChangeUse(uint networkIdentityId, uint userId, int newUse)
	{
        TimeControl.TimeControlIdentity timeControlIdentity = GetDataIdentity<TimeControl.TimeControlIdentity>(networkIdentityId);
        if (timeControlIdentity != null)
        {
            timeControlIdentity.changeUse(userId, newUse);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdTimeControlChangeSubType(uint networkIdentityId, uint userId, int newSubType)
	{
        TimeControl.TimeControlIdentity timeControlIdentity = GetDataIdentity<TimeControl.TimeControlIdentity>(networkIdentityId);
        if (timeControlIdentity != null)
        {
            timeControlIdentity.changeSubType(userId, newSubType);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdTimePerTurnInfoLimitChangePerTurn(uint networkIdentityId, uint userId, float newPerTurn)
	{
        TimeControl.Normal.TimePerTurnInfoLimitIdentity timePerTurnInfoLimitIdentity = GetDataIdentity<TimeControl.Normal.TimePerTurnInfoLimitIdentity>(networkIdentityId);
        if (timePerTurnInfoLimitIdentity != null)
        {
            timePerTurnInfoLimitIdentity.changePerTurn(userId, newPerTurn);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdTotalTimeInfoLimitChangeTotalTime(uint networkIdentityId, uint userId, float newTotalTime)
	{
        TimeControl.Normal.TotalTimeInfoLimitIdentity totalTimeInfoLimitIdentity = GetDataIdentity<TimeControl.Normal.TotalTimeInfoLimitIdentity>(networkIdentityId);
        if (totalTimeInfoLimitIdentity != null)
        {
            totalTimeInfoLimitIdentity.changeTotalTime(userId, newTotalTime);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#region TimeInfo

	[Command]
	public void CmdTimeInfoChangeTimePerTurnType(uint networkIdentityId, uint userId, int newTimePerTurnType)
	{
        TimeControl.Normal.TimeInfoIdentity timeInfoIdentity = GetDataIdentity<TimeControl.Normal.TimeInfoIdentity>(networkIdentityId);
        if (timeInfoIdentity != null)
        {
            timeInfoIdentity.changeTimePerTurnType(userId, newTimePerTurnType);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdTimeInfoChangeTotalTimeType(uint networkIdentityId, uint userId, int newTotalTimeType)
	{
        TimeControl.Normal.TimeInfoIdentity timeInfoIdentity = GetDataIdentity<TimeControl.Normal.TimeInfoIdentity>(networkIdentityId);
        if (timeInfoIdentity != null)
        {
            timeInfoIdentity.changeTotalTimeType(userId, newTotalTimeType);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdTimeInfoChangeOverTimePerTurnType(uint networkIdentityId, uint userId, int newOverTimePerTurnType)
	{
        TimeControl.Normal.TimeInfoIdentity timeInfoIdentity = GetDataIdentity<TimeControl.Normal.TimeInfoIdentity>(networkIdentityId);
        if (timeInfoIdentity != null)
        {
            timeInfoIdentity.changeOverTimePerTurnType(userId, newOverTimePerTurnType);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdTimeInfoChangeLagCompensation(uint networkIdentityId, uint userId, float newLagCompensation)
	{
        TimeControl.Normal.TimeInfoIdentity timeInfoIdentity = GetDataIdentity<TimeControl.Normal.TimeInfoIdentity>(networkIdentityId);
        if (timeInfoIdentity != null)
        {
            timeInfoIdentity.changeLagCompensation(userId, newLagCompensation);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region TimeControlHourGlass

	[Command]
	public void CmdTimeControlHourGlassChangeInitTime(uint networkIdentityId, uint userId, float newInitTime)
	{
        TimeControl.HourGlass.TimeControlHourGlassIdentity timeControlHourGlassIdentity = GetDataIdentity<TimeControl.HourGlass.TimeControlHourGlassIdentity>(networkIdentityId);
        if (timeControlHourGlassIdentity != null)
        {
            timeControlHourGlassIdentity.changeInitTime(userId, newInitTime);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdTimeControlHourGlassChangeLagCompensation(uint networkIdentityId, uint userId, float newLagCompensation)
	{
        TimeControl.HourGlass.TimeControlHourGlassIdentity timeControlHourGlassIdentity = GetDataIdentity<TimeControl.HourGlass.TimeControlHourGlassIdentity>(networkIdentityId);
        if (timeControlHourGlassIdentity != null)
        {
            timeControlHourGlassIdentity.changeLagCompensation(userId, newLagCompensation);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#endregion

	/////////////////////////////////////////////////////////////////////////////////////////
	/////////////////////////////// AI ////////////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////////

	#region Chess

	[Command]
	public void CmdChessAIChangeDepth(uint networkIdentityId, uint userId, int newDepth)
	{
        Chess.ChessAIIdentity chessAIIdentity = GetDataIdentity<Chess.ChessAIIdentity>(networkIdentityId);
        if (chessAIIdentity != null)
        {
            chessAIIdentity.changeDepth(userId, newDepth);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdChessAIChangeSkillLevel(uint networkIdentityId, uint userId, int newSkillLevel)
	{
        Chess.ChessAIIdentity chessAIIdentity = GetDataIdentity<Chess.ChessAIIdentity>(networkIdentityId);
        if (chessAIIdentity != null)
        {
            chessAIIdentity.changeSkillLevel(userId, newSkillLevel);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdChessAIChangeDuration(uint networkIdentityId, uint userId, long newDuration)
	{
        Chess.ChessAIIdentity chessAIIdentity = GetDataIdentity<Chess.ChessAIIdentity>(networkIdentityId);
        if (chessAIIdentity != null)
        {
            chessAIIdentity.changeDuration(userId, newDuration);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region FairyChess

	[Command]
	public void CmdFairyChessAIChangeDepth(uint networkIdentityId, uint userId, int newDepth)
	{
        FairyChess.FairyChessAIIdentity fairyChessAIIdentity = GetDataIdentity<FairyChess.FairyChessAIIdentity>(networkIdentityId);
        if (fairyChessAIIdentity != null)
        {
            fairyChessAIIdentity.changeDepth(userId, newDepth);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdFairyChessAIChangeSkillLevel(uint networkIdentityId, uint userId, int newSkillLevel)
	{
        FairyChess.FairyChessAIIdentity fairyChessAIIdentity = GetDataIdentity<FairyChess.FairyChessAIIdentity>(networkIdentityId);
        if (fairyChessAIIdentity != null)
        {
            fairyChessAIIdentity.changeSkillLevel(userId, newSkillLevel);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdFairyChessAIChangeDuration(uint networkIdentityId, uint userId, long newDuration)
	{
        FairyChess.FairyChessAIIdentity fairyChessAIIdentity = GetDataIdentity<FairyChess.FairyChessAIIdentity>(networkIdentityId);
        if (fairyChessAIIdentity != null)
        {
            fairyChessAIIdentity.changeDuration(userId, newDuration);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region gomoku

	[Command]
	public void CmdGomokuAIChangeSearchDepth(uint networkIdentityId, uint userId, int newSearchDepth)
	{
        Gomoku.GomokuAIIdentity gomokuAIIdentity = GetDataIdentity<Gomoku.GomokuAIIdentity>(networkIdentityId);
        if (gomokuAIIdentity != null)
        {
            gomokuAIIdentity.changeSearchDepth(userId, newSearchDepth);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdGomokuAIChangeTimeLimit(uint networkIdentityId, uint userId, int newTimeLimit)
	{
        Gomoku.GomokuAIIdentity gomokuAIIdentity = GetDataIdentity<Gomoku.GomokuAIIdentity>(networkIdentityId);
        if (gomokuAIIdentity != null)
        {
            gomokuAIIdentity.changeTimeLimit(userId, newTimeLimit);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdGomokuAIChangeLevel(uint networkIdentityId, uint userId, int newLevel)
	{
        Gomoku.GomokuAIIdentity gomokuAIIdentity = GetDataIdentity<Gomoku.GomokuAIIdentity>(networkIdentityId);
        if (gomokuAIIdentity != null)
        {
            gomokuAIIdentity.changeLevel(userId, newLevel);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region InternationalDraught

	[Command]
	public void CmdInternationalDraughtAIChangeBMove(uint networkIdentityId, uint userId, bool newBMove)
	{
        InternationalDraught.InternationalDraughtAIIdentity internationalDraughtAIIdentity = GetDataIdentity<InternationalDraught.InternationalDraughtAIIdentity>(networkIdentityId);
        if (internationalDraughtAIIdentity != null)
        {
            internationalDraughtAIIdentity.changeBMove(userId, newBMove);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdInternationalDraughtAIChangeBook(uint networkIdentityId, uint userId, bool newBook)
	{
        InternationalDraught.InternationalDraughtAIIdentity internationalDraughtAIIdentity = GetDataIdentity<InternationalDraught.InternationalDraughtAIIdentity>(networkIdentityId);
        if (internationalDraughtAIIdentity != null)
        {
            internationalDraughtAIIdentity.changeBook(userId, newBook);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdInternationalDraughtAIChangeDepth(uint networkIdentityId, uint userId, int newDepth)
	{
        InternationalDraught.InternationalDraughtAIIdentity internationalDraughtAIIdentity = GetDataIdentity<InternationalDraught.InternationalDraughtAIIdentity>(networkIdentityId);
        if (internationalDraughtAIIdentity != null)
        {
            internationalDraughtAIIdentity.changeDepth(userId, newDepth);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdInternationalDraughtAIChangeTime(uint networkIdentityId, uint userId, float newTime)
	{
        InternationalDraught.InternationalDraughtAIIdentity internationalDraughtAIIdentity = GetDataIdentity<InternationalDraught.InternationalDraughtAIIdentity>(networkIdentityId);
        if (internationalDraughtAIIdentity != null)
        {
            internationalDraughtAIIdentity.changeTime(userId, newTime);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdInternationalDraughtAIChangeInput(uint networkIdentityId, uint userId, bool newInput)
	{
        InternationalDraught.InternationalDraughtAIIdentity internationalDraughtAIIdentity = GetDataIdentity<InternationalDraught.InternationalDraughtAIIdentity>(networkIdentityId);
        if (internationalDraughtAIIdentity != null)
        {
            internationalDraughtAIIdentity.changeInput(userId, newInput);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdInternationalDraughtAIChangeUseEndGameDatabase(uint networkIdentityId, uint userId, bool newUseEndGameDatabase)
	{
        InternationalDraught.InternationalDraughtAIIdentity internationalDraughtAIIdentity = GetDataIdentity<InternationalDraught.InternationalDraughtAIIdentity>(networkIdentityId);
        if (internationalDraughtAIIdentity != null)
        {
            internationalDraughtAIIdentity.changeUseEndGameDatabase(userId, newUseEndGameDatabase);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdInternationalDraughtAIChangePickBestMove(uint networkIdentityId, uint userId, int newPickBestMove)
	{
        InternationalDraught.InternationalDraughtAIIdentity internationalDraughtAIIdentity = GetDataIdentity<InternationalDraught.InternationalDraughtAIIdentity>(networkIdentityId);
        if (internationalDraughtAIIdentity != null)
        {
            internationalDraughtAIIdentity.changePickBestMove(userId, newPickBestMove);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region EnglishDraught

	[Command]
	public void CmdEnglishDraughtAIChangeThreeMoveRandom(uint networkIdentityId, uint userId, bool newThreeMoveRandom)
	{
        EnglishDraught.EnglishDraughtAIIdentity englishDraughtAIIdentity = GetDataIdentity<EnglishDraught.EnglishDraughtAIIdentity>(networkIdentityId);
        if (englishDraughtAIIdentity != null)
        {
            englishDraughtAIIdentity.changeThreeMoveRandom(userId, newThreeMoveRandom);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdEnglishDraughtAIChangeFMaxSeconds(uint networkIdentityId, uint userId, float newFMaxSeconds)
	{
        EnglishDraught.EnglishDraughtAIIdentity englishDraughtAIIdentity = GetDataIdentity<EnglishDraught.EnglishDraughtAIIdentity>(networkIdentityId);
        if (englishDraughtAIIdentity != null)
        {
            englishDraughtAIIdentity.changeFMaxSeconds(userId, newFMaxSeconds);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdEnglishDraughtAIChangeGMaxDepth(uint networkIdentityId, uint userId, int newGMaxDepth)
	{
        EnglishDraught.EnglishDraughtAIIdentity englishDraughtAIIdentity = GetDataIdentity<EnglishDraught.EnglishDraughtAIIdentity>(networkIdentityId);
        if (englishDraughtAIIdentity != null)
        {
            englishDraughtAIIdentity.changeGMaxDepth(userId, newGMaxDepth);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdEnglishDraughtAIChangePickBestMove(uint networkIdentityId, uint userId, int newPickBestMove)
	{
        EnglishDraught.EnglishDraughtAIIdentity englishDraughtAIIdentity = GetDataIdentity<EnglishDraught.EnglishDraughtAIIdentity>(networkIdentityId);
        if (englishDraughtAIIdentity != null)
        {
            englishDraughtAIIdentity.changePickBestMove(userId, newPickBestMove);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region RussianDraught

	[Command]
	public void CmdRussianDraughtAIChangeTimeLimit(uint networkIdentityId, uint userId, int newTimeLimit)
	{
        RussianDraught.RussianDraughtAIIdentity russianDraughtAIIdentity = GetDataIdentity<RussianDraught.RussianDraughtAIIdentity>(networkIdentityId);
        if (russianDraughtAIIdentity != null)
        {
            russianDraughtAIIdentity.changeTimeLimit(userId, newTimeLimit);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdRussianDraughtAIChangePickBestMove(uint networkIdentityId, uint userId, int newPickBestMove)
	{
        RussianDraught.RussianDraughtAIIdentity russianDraughtAIIdentity = GetDataIdentity<RussianDraught.RussianDraughtAIIdentity>(networkIdentityId);
        if (russianDraughtAIIdentity != null)
        {
            russianDraughtAIIdentity.changePickBestMove(userId, newPickBestMove);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region Reversi

	[Command]
	public void CmdReversiAIChangeSort(uint networkIdentityId, uint userId, int newSort)
	{
        Reversi.ReversiAIIdentity reversiAIIdentity = GetDataIdentity<Reversi.ReversiAIIdentity>(networkIdentityId);
        if (reversiAIIdentity != null)
        {
            reversiAIIdentity.changeSort(userId, newSort);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdReversiAIChangeMin(uint networkIdentityId, uint userId, int newMin)
	{
        Reversi.ReversiAIIdentity reversiAIIdentity = GetDataIdentity<Reversi.ReversiAIIdentity>(networkIdentityId);
        if (reversiAIIdentity != null)
        {
            reversiAIIdentity.changeMin(userId, newMin);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdReversiAIChangeMax(uint networkIdentityId, uint userId, int newMax)
	{
        Reversi.ReversiAIIdentity reversiAIIdentity = GetDataIdentity<Reversi.ReversiAIIdentity>(networkIdentityId);
        if (reversiAIIdentity != null)
        {
            reversiAIIdentity.changeMax(userId, newMax);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdReversiAIChangeEnd(uint networkIdentityId, uint userId, int newEnd)
	{
        Reversi.ReversiAIIdentity reversiAIIdentity = GetDataIdentity<Reversi.ReversiAIIdentity>(networkIdentityId);
        if (reversiAIIdentity != null)
        {
            reversiAIIdentity.changeEnd(userId, newEnd);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdReversiAIChangeMsLeft(uint networkIdentityId, uint userId, int newMsLeft)
	{
        Reversi.ReversiAIIdentity reversiAIIdentity = GetDataIdentity<Reversi.ReversiAIIdentity>(networkIdentityId);
        if (reversiAIIdentity != null)
        {
            reversiAIIdentity.changeMsLeft(userId, newMsLeft);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdReversiAIChangeUseBook(uint networkIdentityId, uint userId, bool newUseBook)
	{
        Reversi.ReversiAIIdentity reversiAIIdentity = GetDataIdentity<Reversi.ReversiAIIdentity>(networkIdentityId);
        if (reversiAIIdentity != null)
        {
            reversiAIIdentity.changeUseBook(userId, newUseBook);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdReversiAIChangePercent(uint networkIdentityId, uint userId, int newPercent)
	{
        Reversi.ReversiAIIdentity reversiAIIdentity = GetDataIdentity<Reversi.ReversiAIIdentity>(networkIdentityId);
        if (reversiAIIdentity != null)
        {
            reversiAIIdentity.changePercent(userId, newPercent);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region Shatranj

	[Command]
	public void CmdShatranjAIChangeDepth(uint networkIdentityId, uint userId, int newDepth)
	{
        Shatranj.ShatranjAIIdentity shatranjAIIdentity = GetDataIdentity<Shatranj.ShatranjAIIdentity>(networkIdentityId);
        if (shatranjAIIdentity != null)
        {
            shatranjAIIdentity.changeDepth(userId, newDepth);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdShatranjAIChangeSkillLevel(uint networkIdentityId, uint userId, int newSkillLevel)
	{
        Shatranj.ShatranjAIIdentity shatranjAIIdentity = GetDataIdentity<Shatranj.ShatranjAIIdentity>(networkIdentityId);
        if (shatranjAIIdentity != null)
        {
            shatranjAIIdentity.changeSkillLevel(userId, newSkillLevel);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdShatranjAIChangeDuration(uint networkIdentityId, uint userId, long newDuration)
	{
        Shatranj.ShatranjAIIdentity shatranjAIIdentity = GetDataIdentity<Shatranj.ShatranjAIIdentity>(networkIdentityId);
        if (shatranjAIIdentity != null)
        {
            shatranjAIIdentity.changeDuration(userId, newDuration);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region Makruk

	[Command]
	public void CmdMakrukAIChangeDepth(uint networkIdentityId, uint userId, int newDepth)
	{
        Makruk.MakrukAIIdentity makrukAIIdentity = GetDataIdentity<Makruk.MakrukAIIdentity>(networkIdentityId);
        if (makrukAIIdentity != null)
        {
            makrukAIIdentity.changeDepth(userId, newDepth);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdMakrukAIChangeSkillLevel(uint networkIdentityId, uint userId, int newSkillLevel)
	{
        Makruk.MakrukAIIdentity makrukAIIdentity = GetDataIdentity<Makruk.MakrukAIIdentity>(networkIdentityId);
        if (makrukAIIdentity != null)
        {
            makrukAIIdentity.changeSkillLevel(userId, newSkillLevel);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdMakrukAIChangeDuration(uint networkIdentityId, uint userId, long newDuration)
	{
        Makruk.MakrukAIIdentity makrukAIIdentity = GetDataIdentity<Makruk.MakrukAIIdentity>(networkIdentityId);
        if (makrukAIIdentity != null)
        {
            makrukAIIdentity.changeDuration(userId, newDuration);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region Seirawan

	[Command]
	public void CmdSeirawanAIChangeDepth(uint networkIdentityId, uint userId, int newDepth)
	{
        Seirawan.SeirawanAIIdentity seirawanAIIdentity = GetDataIdentity<Seirawan.SeirawanAIIdentity>(networkIdentityId);
        if (seirawanAIIdentity != null)
        {
            seirawanAIIdentity.changeDepth(userId, newDepth);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdSeirawanAIChangeSkillLevel(uint networkIdentityId, uint userId, int newSkillLevel)
	{
        Seirawan.SeirawanAIIdentity seirawanAIIdentity = GetDataIdentity<Seirawan.SeirawanAIIdentity>(networkIdentityId);
        if (seirawanAIIdentity != null)
        {
            seirawanAIIdentity.changeSkillLevel(userId, newSkillLevel);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdSeirawanAIChangeDuration(uint networkIdentityId, uint userId, long newDuration)
	{
        Seirawan.SeirawanAIIdentity seirawanAIIdentity = GetDataIdentity<Seirawan.SeirawanAIIdentity>(networkIdentityId);
        if (seirawanAIIdentity != null)
        {
            seirawanAIIdentity.changeDuration(userId, newDuration);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region Shogi

	[Command]
	public void CmdShogiAIChangeDepth(uint networkIdentityId, uint userId, int newDepth)
	{
        Shogi.ShogiAIIdentity shogiAIIdentity = GetDataIdentity<Shogi.ShogiAIIdentity>(networkIdentityId);
        if (shogiAIIdentity != null)
        {
            shogiAIIdentity.changeDepth(userId, newDepth);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdShogiAIChangeSkillLevel(uint networkIdentityId, uint userId, int newSkillLevel)
	{
        Shogi.ShogiAIIdentity shogiAIIdentity = GetDataIdentity<Shogi.ShogiAIIdentity>(networkIdentityId);
        if (shogiAIIdentity != null)
        {
            shogiAIIdentity.changeSkillLevel(userId, newSkillLevel);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdShogiAIChangeMr(uint networkIdentityId, uint userId, int newMr)
	{
        Shogi.ShogiAIIdentity shogiAIIdentity = GetDataIdentity<Shogi.ShogiAIIdentity>(networkIdentityId);
        if (shogiAIIdentity != null)
        {
            shogiAIIdentity.changeMr(userId, newMr);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    } 

	[Command]
	public void CmdShogiAIChangeDuration(uint networkIdentityId, uint userId, int newDuration)
	{
        Shogi.ShogiAIIdentity shogiAIIdentity = GetDataIdentity<Shogi.ShogiAIIdentity>(networkIdentityId);
        if (shogiAIIdentity != null)
        {
            shogiAIIdentity.changeDuration(userId, newDuration);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdShogiAIChangeUseBook(uint networkIdentityId, uint userId, bool newUseBook)
	{
        Shogi.ShogiAIIdentity shogiAIIdentity = GetDataIdentity<Shogi.ShogiAIIdentity>(networkIdentityId);
        if (shogiAIIdentity != null)
        {
            shogiAIIdentity.changeUseBook(userId, newUseBook);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region weiqi

	[Command]
	public void CmdWeiqiAIChangeCanResign(uint networkIdentityId, uint userId, bool newCanResign)
	{
        Weiqi.WeiqiAIIdentity weiqiAIIdentity = GetDataIdentity<Weiqi.WeiqiAIIdentity>(networkIdentityId);
        if (weiqiAIIdentity != null)
        {
            weiqiAIIdentity.changeCanResign(userId, newCanResign);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdWeiqiAIChangeUseBook(uint networkIdentityId, uint userId, bool newUseBook)
	{
        Weiqi.WeiqiAIIdentity weiqiAIIdentity = GetDataIdentity<Weiqi.WeiqiAIIdentity>(networkIdentityId);
        if (weiqiAIIdentity != null)
        {
            weiqiAIIdentity.changeUseBook(userId, newUseBook);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdWeiqiAIChangeTime(uint networkIdentityId, uint userId, int newTime)
	{
        Weiqi.WeiqiAIIdentity weiqiAIIdentity = GetDataIdentity<Weiqi.WeiqiAIIdentity>(networkIdentityId);
        if (weiqiAIIdentity != null)
        {
            weiqiAIIdentity.changeTime(userId, newTime);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdWeiqiAIChangeGames(uint networkIdentityId, uint userId, int newGames)
	{
        Weiqi.WeiqiAIIdentity weiqiAIIdentity = GetDataIdentity<Weiqi.WeiqiAIIdentity>(networkIdentityId);
        if (weiqiAIIdentity != null)
        {
            weiqiAIIdentity.changeGames(userId, newGames);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdWeiqiAIChangeEngine(uint networkIdentityId, uint userId, int newEngine)
	{
        Weiqi.WeiqiAIIdentity weiqiAIIdentity = GetDataIdentity<Weiqi.WeiqiAIIdentity>(networkIdentityId);
        if (weiqiAIIdentity != null)
        {
            weiqiAIIdentity.changeEngine(userId, newEngine);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region Xiangqi

	[Command]
	public void CmdXiangqiAIChangeDepth(uint networkIdentityId, uint userId, int newDepth)
	{
        Xiangqi.XiangqiAIIdentity xiangqiAIIdentity = GetDataIdentity<Xiangqi.XiangqiAIIdentity>(networkIdentityId);
        if (xiangqiAIIdentity != null)
        {
            xiangqiAIIdentity.changeDepth(userId, newDepth);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdXiangqiAIChangeThinkTime(uint networkIdentityId, uint userId, int newThinkTime)
	{
        Xiangqi.XiangqiAIIdentity xiangqiAIIdentity = GetDataIdentity<Xiangqi.XiangqiAIIdentity>(networkIdentityId);
        if (xiangqiAIIdentity != null)
        {
            xiangqiAIIdentity.changeThinkTime(userId, newThinkTime);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdXiangqiAIChangeUseBook(uint networkIdentityId, uint userId, bool newUseBook)
	{
        Xiangqi.XiangqiAIIdentity xiangqiAIIdentity = GetDataIdentity<Xiangqi.XiangqiAIIdentity>(networkIdentityId);
        if (xiangqiAIIdentity != null)
        {
            xiangqiAIIdentity.changeUseBook(userId, newUseBook);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdXiangqiAIChangePickBestMove(uint networkIdentityId, uint userId, int newPickBestMove)
	{
        Xiangqi.XiangqiAIIdentity xiangqiAIIdentity = GetDataIdentity<Xiangqi.XiangqiAIIdentity>(networkIdentityId);
        if (xiangqiAIIdentity != null)
        {
            xiangqiAIIdentity.changePickBestMove(userId, newPickBestMove);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region MineSweeper

	[Command]
	public void CmdMineSweeperAIChangeFirstMoveType(uint networkIdentityId, uint userId, int newFirstMoveType)
	{
        MineSweeper.MineSweeperAIIdentity mineSweeperAIIdentity = GetDataIdentity<MineSweeper.MineSweeperAIIdentity>(networkIdentityId);
        if (mineSweeperAIIdentity != null)
        {
            mineSweeperAIIdentity.changeFirstMoveType(userId, newFirstMoveType);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region Hex

	[Command]
	public void CmdHexAIChangeLimitTime(uint networkIdentityId, uint userId, int newLimitTime)
	{
        HEX.HexAIIdentity hexAIIdentity = GetDataIdentity<HEX.HexAIIdentity>(networkIdentityId);
        if (hexAIIdentity != null)
        {
            hexAIIdentity.changeLimitTime(userId, newLimitTime);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdHexAIChangeFirstMoveCenter(uint networkIdentityId, uint userId, bool newFirstMoveCenter)
	{
        HEX.HexAIIdentity hexAIIdentity = GetDataIdentity<HEX.HexAIIdentity>(networkIdentityId);
        if (hexAIIdentity != null)
        {
            hexAIIdentity.changeFirstMoveCenter(userId, newFirstMoveCenter);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region Solitaire

	[Command]
	public void CmdSolitaireAIChangeMultiThreaded(uint networkIdentityId, uint userId, int newMultiThreaded)
	{
        Solitaire.SolitaireAIIdentity solitaireAIIdentity = GetDataIdentity<Solitaire.SolitaireAIIdentity>(networkIdentityId);
        if (solitaireAIIdentity != null)
        {
            solitaireAIIdentity.changeMultiThreaded(userId, newMultiThreaded);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdSolitaireAIChangeMaxClosedCount(uint networkIdentityId, uint userId, int newMaxClosedCount)
	{
        Solitaire.SolitaireAIIdentity solitaireAIIdentity = GetDataIdentity<Solitaire.SolitaireAIIdentity>(networkIdentityId);
        if (solitaireAIIdentity != null)
        {
            solitaireAIIdentity.changeMaxClosedCount(userId, newMaxClosedCount);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdSolitaireAIChangeFastMode(uint networkIdentityId, uint userId, bool newFastMode)
	{
        Solitaire.SolitaireAIIdentity solitaireAIIdentity = GetDataIdentity<Solitaire.SolitaireAIIdentity>(networkIdentityId);
        if (solitaireAIIdentity != null)
        {
            solitaireAIIdentity.changeFastMode(userId, newFastMode);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region Khet

	[Command]
	public void CmdKhetAIChangeInfinite(uint networkIdentityId, uint userId, bool newInfinite)
	{
        Khet.KhetAIIdentity khetAIIdentity = GetDataIdentity<Khet.KhetAIIdentity>(networkIdentityId);
        if (khetAIIdentity != null)
        {
            khetAIIdentity.changeInfinite(userId, newInfinite);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdKhetAIChangeMoveTime(uint networkIdentityId, uint userId, int newMoveTime)
	{
        Khet.KhetAIIdentity khetAIIdentity = GetDataIdentity<Khet.KhetAIIdentity>(networkIdentityId);
        if (khetAIIdentity != null)
        {
            khetAIIdentity.changeMoveTime(userId, newMoveTime);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdKhetAIChangeDepth(uint networkIdentityId, uint userId, int newDepth)
	{
        Khet.KhetAIIdentity khetAIIdentity = GetDataIdentity<Khet.KhetAIIdentity>(networkIdentityId);
        if (khetAIIdentity != null)
        {
            khetAIIdentity.changeDepth(userId, newDepth);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdKhetAIChangePickBestMove(uint networkIdentityId, uint userId, int newPickBestMove)
	{
        Khet.KhetAIIdentity khetAIIdentity = GetDataIdentity<Khet.KhetAIIdentity>(networkIdentityId);
        if (khetAIIdentity != null)
        {
            khetAIIdentity.changePickBestMove(userId, newPickBestMove);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region Janggi

	[Command]
	public void CmdJanggiAIChangeMaxVisitCount(uint networkIdentityId, uint userId, int newMaxVisitCount)
	{
        Janggi.JanggiAIIdentity janggiAIIdentity = GetDataIdentity<Janggi.JanggiAIIdentity>(networkIdentityId);
        if (janggiAIIdentity != null)
        {
            janggiAIIdentity.changeMaxVisitCount(userId, newMaxVisitCount);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region Banqi

	[Command]
	public void CmdBanqiAIChangeDepth (uint networkIdentityId, uint userId, int newDepth)
	{
        Banqi.BanqiAIIdentity banqiAIIdentity = GetDataIdentity<Banqi.BanqiAIIdentity>(networkIdentityId);
        if (banqiAIIdentity != null)
        {
            banqiAIIdentity.changeDepth(userId, newDepth);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region NineMenMorris

	[Command]
	public void CmdNineMenMorrisAIChangeMaxNormal (uint networkIdentityId, uint userId, int newMaxNormal)
	{
        NineMenMorris.NineMenMorrisAIIdentity nineMenMorrisAIIdentity = GetDataIdentity<NineMenMorris.NineMenMorrisAIIdentity>(networkIdentityId);
        if (nineMenMorrisAIIdentity != null)
        {
            nineMenMorrisAIIdentity.changeMaxNormal(userId, newMaxNormal);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdNineMenMorrisAIChangeMaxPositioning (uint networkIdentityId, uint userId, int newMaxPositioning)
	{
        NineMenMorris.NineMenMorrisAIIdentity nineMenMorrisAIIdentity = GetDataIdentity<NineMenMorris.NineMenMorrisAIIdentity>(networkIdentityId);
        if (nineMenMorrisAIIdentity != null)
        {
            nineMenMorrisAIIdentity.changeMaxPositioning(userId, newMaxPositioning);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdNineMenMorrisAIChangeMaxBlackAndWhite3 (uint networkIdentityId, uint userId, int newMaxBlackAndWhite3)
	{
        NineMenMorris.NineMenMorrisAIIdentity nineMenMorrisAIIdentity = GetDataIdentity<NineMenMorris.NineMenMorrisAIIdentity>(networkIdentityId);
        if (nineMenMorrisAIIdentity != null)
        {
            nineMenMorrisAIIdentity.changeMaxBlackAndWhite3(userId, newMaxBlackAndWhite3);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdNineMenMorrisAIChangeMaxBlackOrWhite3 (uint networkIdentityId, uint userId, int newMaxBlackOrWhite3)
	{
        NineMenMorris.NineMenMorrisAIIdentity nineMenMorrisAIIdentity = GetDataIdentity<NineMenMorris.NineMenMorrisAIIdentity>(networkIdentityId);
        if (nineMenMorrisAIIdentity != null)
        {
            nineMenMorrisAIIdentity.changeMaxBlackOrWhite3(userId, newMaxBlackOrWhite3);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdNineMenMorrisAIChangePickBestMove (uint networkIdentityId, uint userId, int newPickBestMove)
	{
        NineMenMorris.NineMenMorrisAIIdentity nineMenMorrisAIIdentity = GetDataIdentity<NineMenMorris.NineMenMorrisAIIdentity>(networkIdentityId);
        if (nineMenMorrisAIIdentity != null)
        {
            nineMenMorrisAIIdentity.changePickBestMove(userId, newPickBestMove);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	#region Computer

	[Command]
	public void CmdComputerChangeName(uint networkIdentityId, uint userId, string newName)
	{
        ComputerIdentity computerIdentity = GetDataIdentity<ComputerIdentity>(networkIdentityId);
        if (computerIdentity != null)
        {
            computerIdentity.changeName(userId, newName);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	[Command]
	public void CmdComputerChangeAvatarUrl(uint networkIdentityId, uint userId, string newAvatarUrl)
	{
        ComputerIdentity computerIdentity = GetDataIdentity<ComputerIdentity>(networkIdentityId);
        if (computerIdentity != null)
        {
            computerIdentity.changeAvatarUrl(userId, newAvatarUrl);
        }
        else
        {
            Debug.LogError("identity null: " + this);
        }
    }

	#endregion

	///////////////////////////////////////////////////////////////////////////////
	/////////////////////// Rights //////////////////////
	///////////////////////////////////////////////////////////////////////////////

	[Command]
	public void CmdRightsHaveLimitChangeLimit(uint networkIdentityId, uint userId, int newLimit)
	{
        Rights.HaveLimitIdentity haveLimitIdentity = GetDataIdentity<Rights.HaveLimitIdentity>(networkIdentityId);
        if (haveLimitIdentity != null)
        {
            haveLimitIdentity.changeLimit(userId, newLimit);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#region UndoRedoRight

	[Command]
	public void CmdUndoRedoRightChangeNeedAccept(uint networkIdentityId, uint userId, bool newNeedAccept)
	{
        Rights.UndoRedoRightIdentity undoRedoRightIdentity = GetDataIdentity<Rights.UndoRedoRightIdentity>(networkIdentityId);
        if (undoRedoRightIdentity != null)
        {
            undoRedoRightIdentity.changeNeedAccept(userId, newNeedAccept);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdUndoRedoRightChangeNeedAdmin(uint networkIdentityId, uint userId, bool newNeedAdmin)
	{
        Rights.UndoRedoRightIdentity undoRedoRightIdentity = GetDataIdentity<Rights.UndoRedoRightIdentity>(networkIdentityId);
        if (undoRedoRightIdentity != null)
        {
            undoRedoRightIdentity.changeNeedAdmin(userId, newNeedAdmin);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdUndoRedoRightChangeLimitType(uint networkIdentityId, uint userId, int newLimitType)
	{
        Rights.UndoRedoRightIdentity undoRedoRightIdentity = GetDataIdentity<Rights.UndoRedoRightIdentity>(networkIdentityId);
        if (undoRedoRightIdentity != null)
        {
            undoRedoRightIdentity.changeLimitType(userId, newLimitType);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	#region changeGamePlayerRight

	[Command]
	public void CmdChangeGamePlayerRightChangeCanChange(uint networkIdentityId, uint userId, bool newCanChange)
	{
        GameManager.Match.Swap.ChangeGamePlayerRightIdentity changeGamePlayerRightIdentity = GetDataIdentity<GameManager.Match.Swap.ChangeGamePlayerRightIdentity>(networkIdentityId);
        if (changeGamePlayerRightIdentity != null)
        {
            changeGamePlayerRightIdentity.changeCanChange(userId, newCanChange);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdChangeGamePlayerRightChangeCanChangePlayerLeft(uint networkIdentityId, uint userId, bool newCanChangePlayerLeft)
	{
        GameManager.Match.Swap.ChangeGamePlayerRightIdentity changeGamePlayerRightIdentity = GetDataIdentity<GameManager.Match.Swap.ChangeGamePlayerRightIdentity>(networkIdentityId);
        if (changeGamePlayerRightIdentity != null)
        {
            changeGamePlayerRightIdentity.changeCanChangePlayerLeft(userId, newCanChangePlayerLeft);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdChangeGamePlayerRightChangeNeedAdminAccept(uint networkIdentityId, uint userId, bool newNeedAdminAccept)
	{
        GameManager.Match.Swap.ChangeGamePlayerRightIdentity changeGamePlayerRightIdentity = GetDataIdentity<GameManager.Match.Swap.ChangeGamePlayerRightIdentity>(networkIdentityId);
        if (changeGamePlayerRightIdentity != null)
        {
            changeGamePlayerRightIdentity.changeNeedAdminAccept(userId, newNeedAdminAccept);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdChangeGamePlayerRightChangeOnlyAdminNeed(uint networkIdentityId, uint userId, bool newOnlyAdminNeed)
	{
        GameManager.Match.Swap.ChangeGamePlayerRightIdentity changeGamePlayerRightIdentity = GetDataIdentity<GameManager.Match.Swap.ChangeGamePlayerRightIdentity>(networkIdentityId);
        if (changeGamePlayerRightIdentity != null)
        {
            changeGamePlayerRightIdentity.changeOnlyAdminNeed(userId, newOnlyAdminNeed);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	///////////////////////////////////////////////////////////////////////////////
	/////////////////////// Contest //////////////////////
	///////////////////////////////////////////////////////////////////////////////

	#region SingleContestFactory

	[Command]
	public void CmdSingleContestFactoryChangePlayerPerTeam(uint networkIdentityId, uint userId, int newPlayerPerTeam)
	{
        SingleContestFactoryIdentity singleContestFactoryIdentity = GetDataIdentity<SingleContestFactoryIdentity>(networkIdentityId);
        if (singleContestFactoryIdentity != null)
        {
            singleContestFactoryIdentity.changePlayerPerTeam(userId, newPlayerPerTeam);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdSingleContestFactoryChangeRoundFactoryType(uint networkIdentityId, uint userId, int newRoundFactoryType)
	{
        SingleContestFactoryIdentity singleContestFactoryIdentity = GetDataIdentity<SingleContestFactoryIdentity>(networkIdentityId);
        if (singleContestFactoryIdentity != null)
        {
            singleContestFactoryIdentity.changeRoundFactoryType(userId, newRoundFactoryType);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdSingleContestFactoryChangeNewRoundLimitType(uint networkIdentityId, uint userId, int newRoundLimitType)
	{
        SingleContestFactoryIdentity singleContestFactoryIdentity = GetDataIdentity<SingleContestFactoryIdentity>(networkIdentityId);
        if (singleContestFactoryIdentity != null)
        {
            singleContestFactoryIdentity.changeNewRoundLimitType(userId, newRoundLimitType);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdSingleContestFactoryChangeCalculateScoreType(uint networkIdentityId, uint userId, int newCalculateScoreType)
	{
        SingleContestFactoryIdentity singleContestFactoryIdentity = GetDataIdentity<SingleContestFactoryIdentity>(networkIdentityId);
        if (singleContestFactoryIdentity != null)
        {
            singleContestFactoryIdentity.changeCalculateScoreType(userId, newCalculateScoreType);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	///////////////////////////////////////////////////////////////////////////////
	/////////////////////// Request New Round //////////////////////
	///////////////////////////////////////////////////////////////////////////////
	 
	#region haveLimit

	[Command]
	public void CmdRequestNewRoundHaveLimitChangeMaxRound(uint networkIdentityId, uint userId, int newMaxRound)
	{
        RequestNewRoundHaveLimitIdentity requestNewRoundHaveLimitIdentity = GetDataIdentity<RequestNewRoundHaveLimitIdentity>(networkIdentityId);
        if (requestNewRoundHaveLimitIdentity != null)
        {
            requestNewRoundHaveLimitIdentity.changeMaxRound(userId, newMaxRound);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdRequestNewRoundHaveLimitChangeEnoughScoreStop(uint networkIdentityId, uint userId, bool newEnoughScoreStop)
	{
        RequestNewRoundHaveLimitIdentity requestNewRoundHaveLimitIdentity = GetDataIdentity<RequestNewRoundHaveLimitIdentity>(networkIdentityId);
        if (requestNewRoundHaveLimitIdentity != null)
        {
            requestNewRoundHaveLimitIdentity.changeEnoughScoreStop(userId, newEnoughScoreStop);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	#region noLimit

	[Command]
	public void CmdRequestNewRoundNoLimitChangeIsStopMakeMoreRound(uint networkIdentityId, uint userId, bool newIsStopMakeMoreRound)
	{
        RequestNewRoundNoLimitIdentity requestNewRoundNoLimitIdentity = GetDataIdentity<RequestNewRoundNoLimitIdentity>(networkIdentityId);
        if (requestNewRoundNoLimitIdentity != null)
        {
            requestNewRoundNoLimitIdentity.changeIsStopMakeMoreRound(userId, newIsStopMakeMoreRound);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	#region StateAsk

	[Command]
	public void CmdRequestNewRoundStateAskAccept(uint networkIdentityId, uint userId)
	{
        RequestNewRoundStateAskIdentity requestNewRoundStateAskIdentity = GetDataIdentity<RequestNewRoundStateAskIdentity>(networkIdentityId);
        if (requestNewRoundStateAskIdentity != null)
        {
            requestNewRoundStateAskIdentity.accept(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdRequestNewRoundStateAskCancel(uint networkIdentityId, uint userId)
	{
        RequestNewRoundStateAskIdentity requestNewRoundStateAskIdentity = GetDataIdentity<RequestNewRoundStateAskIdentity>(networkIdentityId);
        if (requestNewRoundStateAskIdentity != null)
        {
            requestNewRoundStateAskIdentity.cancel(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	///////////////////////////////////////////////////////////////////////////////
	/////////////////////// Normal Round Factory //////////////////////
	///////////////////////////////////////////////////////////////////////////////
	 
	[Command]
	public void CmdNormalRoundFactoryChangeIsChangeSideBetweenRound(uint networkIdentityId, uint userId, bool newIsChangeSideBetweenRound)
	{
        NormalRoundFactoryIdentity normalRoundFactoryIdentity = GetDataIdentity<NormalRoundFactoryIdentity>(networkIdentityId);
        if (normalRoundFactoryIdentity != null)
        {
            normalRoundFactoryIdentity.changeIsChangeSideBetweenRound(userId, newIsChangeSideBetweenRound);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdNormalRoundFactoryChangeIsSwitchPlayer(uint networkIdentityId, uint userId, bool newIsSwitchPlayer)
	{
        NormalRoundFactoryIdentity normalRoundFactoryIdentity = GetDataIdentity<NormalRoundFactoryIdentity>(networkIdentityId);
        if (normalRoundFactoryIdentity != null)
        {
            normalRoundFactoryIdentity.changeIsSwitchPlayer(userId, newIsSwitchPlayer);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdNormalRoundFactoryChangeIsDifferentInTeam(uint networkIdentityId, uint userId, bool newIsDifferentInTeam)
	{
        NormalRoundFactoryIdentity normalRoundFactoryIdentity = GetDataIdentity<NormalRoundFactoryIdentity>(networkIdentityId);
        if (normalRoundFactoryIdentity != null)
        {
            normalRoundFactoryIdentity.changeIsDifferentInTeam(userId, newIsDifferentInTeam);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdNormalRoundFactoryChangeCalculateScoreType(uint networkIdentityId, uint userId, int newCalculateScoreType)
	{
        NormalRoundFactoryIdentity normalRoundFactoryIdentity = GetDataIdentity<NormalRoundFactoryIdentity>(networkIdentityId);
        if (normalRoundFactoryIdentity != null)
        {
            normalRoundFactoryIdentity.changeCalculateScoreType(userId, newCalculateScoreType);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	///////////////////////////////////////////////////////////////////////////////
	/////////////////////// Lobby //////////////////////
	///////////////////////////////////////////////////////////////////////////////

	[Command]
	public void CmdContestManagerStateLobbyChangeRandomTeamIndex(uint networkIdentityId, uint userId, bool newRandomTeamIndex)
	{
        ContestManagerStateLobbyIdentity contestManagerStateLobbyIdentity = GetDataIdentity<ContestManagerStateLobbyIdentity>(networkIdentityId);
        if (contestManagerStateLobbyIdentity != null)
        {
            contestManagerStateLobbyIdentity.changeRandomTeamIndex(userId, newRandomTeamIndex);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdContestManagerStateLobbyChangeContentFactoryType(uint networkIdentityId, uint userId, int newContentFactoryType)
	{
        ContestManagerStateLobbyIdentity contestManagerStateLobbyIdentity = GetDataIdentity<ContestManagerStateLobbyIdentity>(networkIdentityId);
        if (contestManagerStateLobbyIdentity != null)
        {
            contestManagerStateLobbyIdentity.changeContentFactoryType(userId, newContentFactoryType);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdContestManagerStateLobbyStateNormalStart(uint networkIdentityId, uint userId)
	{
        GameManager.Match.Lobby.StateNormalIdentity startNormalIdentity = GetDataIdentity<GameManager.Match.Lobby.StateNormalIdentity>(networkIdentityId);
        if (startNormalIdentity != null)
        {
            startNormalIdentity.start(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#region lobbyPlayer

	[Command]
	public void CmdLobbyPlayerSetReady(uint networkIdentityId, uint userId, bool newReady)
	{
        LobbyPlayerIdentity lobbyPlayerIdentity = GetDataIdentity<LobbyPlayerIdentity>(networkIdentityId);
        if (lobbyPlayerIdentity != null)
        {
            lobbyPlayerIdentity.setReady(userId, newReady);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdLobbyPlayerAdminChangeHuman(uint networkIdentityId, uint userId, uint humanId)
	{
        LobbyPlayerIdentity lobbyPlayerIdentity = GetDataIdentity<LobbyPlayerIdentity>(networkIdentityId);
        if (lobbyPlayerIdentity != null)
        {
            lobbyPlayerIdentity.adminChangeHuman(userId, humanId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdLobbyPlayerAdminChangeEmpty(uint networkIdentityId, uint userId)
	{
        LobbyPlayerIdentity lobbyPlayerIdentity = GetDataIdentity<LobbyPlayerIdentity>(networkIdentityId);
        if (lobbyPlayerIdentity != null)
        {
            lobbyPlayerIdentity.adminChangeEmpty(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdLobbyPlayerAdminChangeComputer(uint networkIdentityId, uint userId, string strComputer)
	{
        LobbyPlayerIdentity lobbyPlayerIdentity = GetDataIdentity<LobbyPlayerIdentity>(networkIdentityId);
        if (lobbyPlayerIdentity != null)
        {
            Computer computer = StringSerializationAPI.Deserialize(typeof(Computer), strComputer) as Computer;
            if (computer != null)
            {
                lobbyPlayerIdentity.adminChangeComputer(userId, computer);
            }
            else
            {
                Debug.LogError("computer null: " + this);
            }
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdLobbyPlayerNormalSet(uint networkIdentityId, uint userId)
	{
        LobbyPlayerIdentity lobbyPlayerIdentity = GetDataIdentity<LobbyPlayerIdentity>(networkIdentityId);
        if (lobbyPlayerIdentity != null)
        {
            lobbyPlayerIdentity.normalSet(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdLobbyPlayerIdentityNormalEmpty(uint networkIdentityId, uint userId)
	{
        LobbyPlayerIdentity lobbyPlayerIdentity = GetDataIdentity<LobbyPlayerIdentity>(networkIdentityId);
        if (lobbyPlayerIdentity != null)
        {
            lobbyPlayerIdentity.normalEmpty(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	///////////////////////////////////////////////////////////////////////////////
	/////////////////////// Play //////////////////////
	///////////////////////////////////////////////////////////////////////////////

	[Command]
	public void CmdContestManagerStatePlayChangeIsForceEnd (uint networkIdentityId, uint userId, bool newIsForceEnd)
	{
        ContestManagerStatePlayIdentity contestManagerStatePlayIdentity = GetDataIdentity<ContestManagerStatePlayIdentity>(networkIdentityId);
        if (contestManagerStatePlayIdentity != null)
        {
            contestManagerStatePlayIdentity.changeIsForceEnd(userId, newIsForceEnd);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#region requestNewContestManagerStateAsk

	[Command]
	public void CmdRequestNewContestManagerStateAskAccept (uint networkIdentityId, uint userId)
	{
        RequestNewContestManagerStateAskIdentity requestNewContestManagerStateAskIdentity = GetDataIdentity<RequestNewContestManagerStateAskIdentity>(networkIdentityId);
        if (requestNewContestManagerStateAskIdentity != null)
        {
            requestNewContestManagerStateAskIdentity.accept(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdRequestNewContestManagerStateAskCancel (uint networkIdentityId, uint userId)
	{
        RequestNewContestManagerStateAskIdentity requestNewContestManagerStateAskIdentity = GetDataIdentity<RequestNewContestManagerStateAskIdentity>(networkIdentityId);
        if (requestNewContestManagerStateAskIdentity != null)
        {
            requestNewContestManagerStateAskIdentity.cancel(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	#region Calculate Score

	[Command]
	public void CmdCalculateScoreWinLoseDrawChangeWinScore (uint networkIdentityId, uint userId, float newWinScore)
	{
        CalculateScoreWinLoseDrawIdentity calculateScoreWinLoseDrawIdentity = GetDataIdentity<CalculateScoreWinLoseDrawIdentity>(networkIdentityId);
        if (calculateScoreWinLoseDrawIdentity != null)
        {
            calculateScoreWinLoseDrawIdentity.changeWinScore(userId, newWinScore);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdCalculateScoreWinLoseDrawChangeLoseScore (uint networkIdentityId, uint userId, float newLoseScore)
	{
        CalculateScoreWinLoseDrawIdentity calculateScoreWinLoseDrawIdentity = GetDataIdentity<CalculateScoreWinLoseDrawIdentity>(networkIdentityId);
        if (calculateScoreWinLoseDrawIdentity != null)
        {
            calculateScoreWinLoseDrawIdentity.changeLoseScore(userId, newLoseScore);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdCalculateScoreWinLoseDrawChangeDrawScore (uint networkIdentityId, uint userId, float newDrawScore)
	{
        CalculateScoreWinLoseDrawIdentity calculateScoreWinLoseDrawIdentity = GetDataIdentity<CalculateScoreWinLoseDrawIdentity>(networkIdentityId);
        if (calculateScoreWinLoseDrawIdentity != null)
        {
            calculateScoreWinLoseDrawIdentity.changeDrawScore(userId, newDrawScore);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	/////////////////////////////////////////////////////////////////////////////////////
	////////////////////////// RoundRobinContent ////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////

	#region RoundRobinFactory

	[Command]
	public void CmdRoundRobinFactoryChangeTeamCount (uint networkIdentityId, uint userId, int newTeamCount)
	{
        RoundRobinFactoryIdentity roundRobinFactoryIdentity = GetDataIdentity<RoundRobinFactoryIdentity>(networkIdentityId);
        if (roundRobinFactoryIdentity != null)
        {
            roundRobinFactoryIdentity.changeTeamCount(userId, newTeamCount);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdRoundRobinFactoryChangeNeedReturnRound (uint networkIdentityId, uint userId, bool newNeedReturnRound)
	{
        RoundRobinFactoryIdentity roundRobinFactoryIdentity = GetDataIdentity<RoundRobinFactoryIdentity>(networkIdentityId);
        if (roundRobinFactoryIdentity != null)
        {
            roundRobinFactoryIdentity.changeNeedReturnRound(userId, newNeedReturnRound);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	#region requestNewRoundRobin

	[Command]
	public void CmdRequestNewRoundRobinStateAskAccept (uint networkIdentityId, uint userId)
	{
        RequestNewRoundRobinStateAskIdentity requestNewRoundRobinStateAskIdentity = GetDataIdentity<RequestNewRoundRobinStateAskIdentity>(networkIdentityId);
        if (requestNewRoundRobinStateAskIdentity != null)
        {
            requestNewRoundRobinStateAskIdentity.accept(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdRequestNewRoundRobinStateAskCancel (uint networkIdentityId, uint userId)
	{
        RequestNewRoundRobinStateAskIdentity requestNewRoundRobinStateAskIdentity = GetDataIdentity<RequestNewRoundRobinStateAskIdentity>(networkIdentityId);
        if (requestNewRoundRobinStateAskIdentity != null)
        {
            requestNewRoundRobinStateAskIdentity.cancel(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	/////////////////////////////////////////////////////////////////////////////////////
	////////////////////////// Elimination ////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////

	#region eliminationFactory

	[Command]
	public void CmdEliminationFactoryChangeInitTeamCountLength (uint networkIdentityId, uint userId, int newLength)
	{
        EliminationFactoryIdentity eliminationFactoryIdentity = GetDataIdentity<EliminationFactoryIdentity>(networkIdentityId);
        if (eliminationFactoryIdentity != null)
        {
            eliminationFactoryIdentity.changeInitTeamCountLength(userId, newLength);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdEliminationFactoryChangeInitTeamCount (uint networkIdentityId, uint userId, int index, uint newInitTeamCount)
	{
        EliminationFactoryIdentity eliminationFactoryIdentity = GetDataIdentity<EliminationFactoryIdentity>(networkIdentityId);
        if (eliminationFactoryIdentity != null)
        {
            eliminationFactoryIdentity.changeInitTeamCount(userId, index, newInitTeamCount);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	#region requestNewEliminationRoundState

	[Command]
	public void CmdRequestNewEliminationRoundStateAskAccept (uint networkIdentityId, uint userId)
	{
        RequestNewEliminationRoundStateAskIdentity requestNewEliminationRoundStateAskIdentity = GetDataIdentity<RequestNewEliminationRoundStateAskIdentity>(networkIdentityId);
        if (requestNewEliminationRoundStateAskIdentity != null)
        {
            requestNewEliminationRoundStateAskIdentity.accept(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdRequestNewEliminationRoundStateAskCancel (uint networkIdentityId, uint userId)
	{
        RequestNewEliminationRoundStateAskIdentity requestNewEliminationRoundStateAskIdentity = GetDataIdentity<RequestNewEliminationRoundStateAskIdentity>(networkIdentityId);
        if (requestNewEliminationRoundStateAskIdentity != null)
        {
            requestNewEliminationRoundStateAskIdentity.cancel(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	/////////////////////////////////////////////////////////////////////////////////////
	////////////////////////// Swap ////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////

	#region makeRequest

	[Command]
	public void CmdSwapIdentityChangeHuman (uint networkIdentityId, uint userId, int teamIndex, int playerIndex, uint newHumanId)
	{
        SwapIdentity swapIdentity = GetDataIdentity<SwapIdentity>(networkIdentityId);
        if (swapIdentity != null)
        {
            swapIdentity.changeHuman(userId, teamIndex, playerIndex, newHumanId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdSwapIdentityChangeComputer (uint networkIdentityId, uint userId, int teamIndex, int playerIndex, string strComputer)
	{
        SwapIdentity swapIdentity = GetDataIdentity<SwapIdentity>(networkIdentityId);
        if (swapIdentity != null)
        {
            Computer newComputer = StringSerializationAPI.Deserialize(typeof(Computer), strComputer) as Computer;
            swapIdentity.changeComputer(userId, teamIndex, playerIndex, newComputer);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	#region swapRequestStateAsk

	[Command]
	public void CmdSwapRequestStateAskAccept (uint networkIdentityId, uint userId)
	{
        SwapRequestStateAskIdentity swapRequestStateAskIdentity = GetDataIdentity<SwapRequestStateAskIdentity>(networkIdentityId);
        if (swapRequestStateAskIdentity != null)
        {
            swapRequestStateAskIdentity.accept(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdSwapRequestStateAskRefuse (uint networkIdentityId, uint userId)
	{
        SwapRequestStateAskIdentity swapRequestStateAskIdentity = GetDataIdentity<SwapRequestStateAskIdentity>(networkIdentityId);
        if (swapRequestStateAskIdentity != null)
        {
            swapRequestStateAskIdentity.refuse(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	/////////////////////////////////////////////////////////////////////////////////////
	////////////////////////// RequestChangeUseRule ////////////////////////
	/////////////////////////////////////////////////////////////////////////////////////

	[Command]
	public void CmdRequestChangeUseRuleStateNoneChange (uint networkIdentityId, uint userId)
	{
        RequestChangeUseRuleStateNoneIdentity requestChangeUseRuleStateNoneIdentity = GetDataIdentity<RequestChangeUseRuleStateNoneIdentity>(networkIdentityId);
        if (requestChangeUseRuleStateNoneIdentity != null)
        {
            requestChangeUseRuleStateNoneIdentity.change(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdRequestChangeUseRuleStateAskAccept (uint networkIdentityId, uint userId)
	{
        RequestChangeUseRuleStateAskIdentity requestChangeUseRuleStateAskIdentity = GetDataIdentity<RequestChangeUseRuleStateAskIdentity>(networkIdentityId);
        if (requestChangeUseRuleStateAskIdentity != null)
        {
            requestChangeUseRuleStateAskIdentity.accept(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdRequestChangeUseRuleStateAskRefuse (uint networkIdentityId, uint userId)
	{
        RequestChangeUseRuleStateAskIdentity requestChangeUseRuleStateAskIdentity = GetDataIdentity<RequestChangeUseRuleStateAskIdentity>(networkIdentityId);
        if (requestChangeUseRuleStateAskIdentity != null)
        {
            requestChangeUseRuleStateAskIdentity.refuse(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#region changeUseRuleRight

	[Command]
	public void CmdChangeUseRuleRightChangeOnlyAdmin (uint networkIdentityId, uint userId, bool newOnlyAdmin)
	{
        ChangeUseRuleRightIdentity changeUseRuleRightIdentity = GetDataIdentity<ChangeUseRuleRightIdentity>(networkIdentityId);
        if (changeUseRuleRightIdentity != null)
        {
            changeUseRuleRightIdentity.changeOnlyAdmin(userId, newOnlyAdmin);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdChangeUseRuleRightChangeNeedAdmin (uint networkIdentityId, uint userId, bool newNeedAdmin)
	{
        ChangeUseRuleRightIdentity changeUseRuleRightIdentity = GetDataIdentity<ChangeUseRuleRightIdentity>(networkIdentityId);
        if (changeUseRuleRightIdentity != null)
        {
            changeUseRuleRightIdentity.changeNeedAdmin(userId, newNeedAdmin);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdChangeUseRuleRightChangeNeedAccept (uint networkIdentityId, uint userId, bool newNeedAccept)
	{
        ChangeUseRuleRightIdentity changeUseRuleRightIdentity = GetDataIdentity<ChangeUseRuleRightIdentity>(networkIdentityId);
        if (changeUseRuleRightIdentity != null)
        {
            changeUseRuleRightIdentity.changeNeedAccept(userId, newNeedAccept);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

	#region roomManager

	[Command]
	public void CmdGlobalRoomContainerMakeRoom(uint networkIdentityId, uint userId, CreateRoomMessage makeRoom){
        GlobalRoomContainerIdentity globalRoomContainerIdentity = GetDataIdentity<GlobalRoomContainerIdentity>(networkIdentityId);
        if (globalRoomContainerIdentity != null)
        {
            globalRoomContainerIdentity.makeRoom(userId, makeRoom);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdLimitRoomContainerMakeRoom(uint networkIdentityId, uint userId, CreateRoomMessage makeRoom){
        LimitRoomContainerIdentity limitRoomContainerIdentity = GetDataIdentity<LimitRoomContainerIdentity>(networkIdentityId);
        if (limitRoomContainerIdentity != null)
        {
            limitRoomContainerIdentity.makeRoom(userId, makeRoom);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdLimitRoomContainerJoin(uint networkIdentityId, uint userId){
        LimitRoomContainerIdentity limitRoomContainerIdentity = GetDataIdentity<LimitRoomContainerIdentity>(networkIdentityId);
        if (limitRoomContainerIdentity != null)
        {
            limitRoomContainerIdentity.join(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	[Command]
	public void CmdLimitRoomContainerLeave(uint networkIdentityId, uint userId){
        LimitRoomContainerIdentity limitRoomContainerIdentity = GetDataIdentity<LimitRoomContainerIdentity>(networkIdentityId);
        if (limitRoomContainerIdentity != null)
        {
            limitRoomContainerIdentity.leave(userId);
        }
        else
        {
            Debug.LogError("Identity null");
        }
    }

	#endregion

}
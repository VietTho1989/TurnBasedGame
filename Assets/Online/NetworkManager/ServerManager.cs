using UnityEngine;
using Mirror;
using System.Collections.Generic;

public class ServerManager : NetworkManager, ValueChangeCallBack
{

    #region UIData

    public class UIData : Data
	{
		
		public VP<ReferenceData<Server>> server;

		public VP<ManagerUI.UIData> managerUI;

		#region Constructor

		public enum Property
		{
			server,
			managerUI
		}

		public UIData() : base()
		{
			this.server = new VP<ReferenceData<Server>>(this, (byte)Property.server, new ReferenceData<Server>(null));
			this.managerUI = new VP<ManagerUI.UIData>(this, (byte)Property.managerUI, new ManagerUI.UIData());
		}

		#endregion

		public interface OnClick
		{
			void onClickReturn ();
		}

		public bool processEvent(Event e)
		{
			bool isProcess = false;
			{
				// managerUI
				if (!isProcess) {
					ManagerUI.UIData managerUIData = this.managerUI.v;
					if (managerUIData != null) {
						isProcess = managerUIData.processEvent (e);
					} else {
						Debug.LogError ("managerUIData null: " + this);
					}
				}
				// back
				/*if (!isProcess) {
					if (InputEvent.isBackEvent (e)) {

					}
				}*/
			}
			return isProcess;
		}

	}

	public UIData data;

	public void setData(UIData newData){
		if (this.data != newData) {
			// remove old
			if (this.data != null) {
				this.data.removeCallBack (this);
			}
			// set new
			this.data = newData;
			if (this.data != null) {
				this.data.addCallBack (this);
			}
		} else {
			Debug.LogError ("the same");
		}
	}

	#endregion

	#region singleton

	public static ServerManager instance;

	public override void Awake(){
		// Time.fixedDeltaTime = 0.02f;
		instance = this;
		// TODO co dung khong nhi?
		NetworkServer.Reset ();
	}

	public override void OnDestroy(){
		// Debug.Log ("OnDestroy");
		if (instance == this) {
			instance = null;
		}
		NetworkServer.Shutdown ();
	}

	#endregion

	#region Server

	public override void OnStartServer()
	{
		base.OnStartServer ();
		// Debug.Log ("OnStartServer");
		// CallBack
		//initCreateDataIdentityCallBack ();
	}

	public override void OnServerReady(NetworkConnection conn){
		// Debug.Log ("OnServerReady: " + conn);
		base.OnServerReady (conn);
	}

	// called when a client disconnects
	public override void OnServerDisconnect(NetworkConnection conn)
	{
		// Debug.Log ("OnServerDisconnect: " + conn);
		if (this.data != null) {
			if (this.data.server.v.data != null) {
				foreach (User user in this.data.server.v.data.users.vs) {
					if (user.human.v.connection.v == conn) {
						// Debug.Log ("user disconnect: " + user.name.property);
						if (user.human.v.state.v.state.v == UserState.State.Online) {
							user.human.v.state.v.state.v = UserState.State.Disconnect;
							// Add message
							{
								// Find userTopic
								UserTopic userTopic = null;
								{
									ChatRoom chatRoom = user.chatRoom.v;
									if (chatRoom != null) {
										if (chatRoom.topic.v != null && chatRoom.topic.v is UserTopic) {
											userTopic = chatRoom.topic.v as UserTopic;
										}
									} else {
										Debug.LogError ("chatRoom null: " + this);
									}
								}
								// Add message
								if (userTopic != null) {
									userTopic.addUserAction (user.human.v.playerId.v, UserActionMessage.Action.Disconnect);
								} else {
									Debug.LogError ("userTopic null: " + this);
								}
							}
						} else {
							// Debug.Log ("user disconnect: " + user.state.property.state.property);
							user.human.v.state.v.state.v = UserState.State.Offline;
						}
						user.human.v.connection.v = null;
						break;
					}
				}
			}
		} else {
			Debug.LogError ("data null");
		}
		base.OnServerDisconnect (conn);
	}

	// called when a network error occurs
	public override void OnServerError(NetworkConnection conn, int errorCode)
	{
		// Debug.Log ("OnServerError: " + conn + ", " + errorCode);
	}

	#region client

	public const int CheckClientInstanceIdMsgType = 100;

	private long checkInstanceId = 0;
	private bool alreadyReady = true;

	public NetworkClient myStartClient()
	{
		// NetworkServer.RegisterHandler(ClientReadyMsgType, OnReceiveMsgClientReady);
		NetworkClient networkClient = this.StartClient ();
		client.RegisterHandler (CheckClientInstanceIdMsgType, OnReceiveMsgClientReady);
		// init value to check
		{
			alreadyReady = false;
			// checkInstanceId
			{
				checkInstanceId = 0;
				{
					if (this.data != null) {
						Server server = this.data.server.v.data;
						if (server != null) {
							if (server.state.v.getType () == Server.State.Type.Disconnect) {
								if (FindObjectOfType<DataIdentity> () != null) {
									checkInstanceId = server.instanceId.v;
								} else {
									Debug.LogError ("Don't have any dataIdentities");
								}
							}
						} else {
							Debug.LogError ("server null: " + this);
						}
					}
				}

			}
		}
		return networkClient;
	}

	private long lastServerInstanceId = 0;

	void OnReceiveMsgClientReady(NetworkMessage msg)
	{
		Debug.LogError ("OnReceiveMsgClientReady: " + msg);
		// check need delete
		bool needDelete = false;
		{
			ServerInstanceIdMessage serverInstanceIdMessage = msg.ReadMessage<ServerInstanceIdMessage> ();
			if (serverInstanceIdMessage != null) {
				if (lastServerInstanceId == 0) {
					needDelete = false;
				} else if (lastServerInstanceId != serverInstanceIdMessage.instanceId) {
					needDelete = true;
				}
				lastServerInstanceId = serverInstanceIdMessage.instanceId;
			} else {
				Debug.LogError ("serverInstanceIdMessage null");
			}
		}
		// update
		if (!alreadyReady) {
			alreadyReady = true;
			// remove dataIdentities if need
			{
				if (needDelete) {
					Debug.LogError ("need delete identities: " + checkInstanceId + ", " + lastServerInstanceId);
					DataIdentity[] dataIdentities = FindObjectsOfType<DataIdentity> ();
					foreach (DataIdentity dataIdentity in dataIdentities) {
						Destroy (dataIdentity.gameObject);
					}
				} else {
					Debug.LogError ("Don't need delete identities: " + checkInstanceId + ", " + lastServerInstanceId);
				}
			}
			// client ready
			if (this.client.connection != null) {
				ClientScene.Ready (this.client.connection);
                // ClientScene.AddPlayer (0);
                ClientScene.AddPlayer();
            } else {
				Debug.LogError ("why client connection null");
			}
		}
	}

	// called when connected to a server
	public override void OnClientConnect(NetworkConnection conn)
	{
		Debug.LogError ("OnClientConnect: " + conn);
		//ClientScene.Ready (conn);
		if (checkInstanceId == 0) {
			alreadyReady = true;
			ClientScene.Ready (conn);
            // ClientScene.AddPlayer (0);
            ClientScene.AddPlayer();
        } else {
			Debug.LogError ("need check instanceId");
		}
	}

	#endregion

	// called when a client connects 
	public override void OnServerConnect(NetworkConnection conn)
	{
		Debug.LogError ("in server: OnServerConnect: " + conn);
		// TODO Test
		{
			long instanceId = 0;
			{
				if (this.data != null) {
					Server server = this.data.server.v.data;
					if (server != null) {
						instanceId = server.instanceId.v;
					} else {
						Debug.LogError ("server null: " + this);
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
			ServerInstanceIdMessage serverInstanceIdMessage = new ServerInstanceIdMessage ();
			{
				serverInstanceIdMessage.instanceId = instanceId;
			}
			Debug.LogError ("serverInstanceId: " + instanceId);
			conn.Send (CheckClientInstanceIdMsgType, serverInstanceIdMessage);
		}
		//NetworkServer.SetClientReady (conn);
	}

	/** call in server*/
    // TODO Tam bo
	/*public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{
		// Debug.LogError ("OnServerAddPlayer: " + playerControllerId + "; " + conn);
		base.OnServerAddPlayer (conn, playerControllerId);
	}*/

    // TODO Tam bo
	/*public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
	{
		if (extraMessageReader != null) {
			StringMessage s = extraMessageReader.ReadMessage<StringMessage> ();
			Debug.LogError ("onServerAddPlayer: have message: " + s.value);
		} else {
			Debug.LogError ("onServerAddPlayer: don't have message");
		}
		base.OnServerAddPlayer (conn, playerControllerId, extraMessageReader);
	}*/

	#endregion

	#region Client

	public void logOut()
	{
		// Set new state
		if (this.data != null) {
			Server server = this.data.server.v.data;
			if (server != null) {
				if (server.type.v == Server.Type.Client) {
					server.state.v = new Server.State.Offline ();
					// NetworkManager.Shutdown ();
					NetworkManager.singleton.StopClient ();
					// destroy all identites
					{
						DataIdentity[] dataIdentities = FindObjectsOfType<DataIdentity> ();
						foreach (DataIdentity dataIdentity in dataIdentities) {
							Destroy (dataIdentity.gameObject);
						}
					}
				} else {
					// Debug.LogError ("not client");
				}
			} else {
				Debug.LogError ("server null");
			}
		} else {
			Debug.LogError ("data null");
		}
	}

	public override void OnClientSceneChanged(NetworkConnection conn)
	{
		//base.OnClientSceneChanged(conn);
		//by overriding this function and commenting the base we are removing the functionality of this function 
		//so we dont have conflict with  OnClientConnect
	}

	// called when disconnected from a server
	public override void OnClientDisconnect(NetworkConnection conn)
	{
		if (this.data != null) {
			Server server = this.data.server.v.data;
			if (server != null) {
				if (server.type.v == Server.Type.Client) {
					// Stop Client
					{
						if (this.client != null)
						{
							// only shutdown this client, not ALL clients.
							this.client.Disconnect();
							this.client.Shutdown();
							this.client = null;
						}
					}
					// Debug.LogError("OnClientDisconnect: " + conn + ", " + server.state.property);
					switch (server.state.v.getType()) {
					case Server.State.Type.Offline:
						{
						}
						break;
					case Server.State.Type.Connect:
						{
							Server.State.Disconnect disconnect = new Server.State.Disconnect ();
							{
								disconnect.uid = server.state.makeId ();
							}
							server.state.v = disconnect;
						}
						break;
					case Server.State.Type.Disconnect:
						{
							// Debug.Log ("disconnect server when not login");
						}
						break;
					default:
						// Debug.LogError ("unknown server state: " + server.state.property);
						break;
					}
					// TODO Destroy
					{
						ClientConnectIdentity clientConnectIdentity = FindObjectOfType<ClientConnectIdentity> ();
						if (clientConnectIdentity != null) {
							Destroy (clientConnectIdentity.gameObject);
						}
					}
				} else {
					Debug.LogError ("Why not client");
				}
			} else {
				Debug.LogError ("server null");
			}
		} else {
			Debug.LogError ("data null");
		}
	}

	// called when a network error occurs
	public override void OnClientError(NetworkConnection conn, int errorCode)
	{
		// Debug.Log ("OnClientError: " + conn + ", " + errorCode);
	}

	// called when told to be not-ready by a server
	public override void OnClientNotReady(NetworkConnection conn)
	{
		// Debug.Log ("OnClientNotReady: " + conn);
	}

    // TODO Tam bo
	/*void OnDisconnectedFromServer(NetworkDisconnection info) {
		if (Network.isServer) {
			// Debug.LogError("Local server connection disconnected");
		} else if (info == NetworkDisconnection.LostConnection) {
			// Debug.LogError ("Lost connection to the server");
		} else {
			// Debug.LogError ("Successfully diconnected from the server");
		}
	}*/

	#endregion

	#region implement callBacks

	public ManagerUI managerUIPrefab;

	public void onAddCallBack<T> (T data) where T:Data
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
            // Child
			{
				uiData.server.allAddCallBack (this);
				uiData.managerUI.allAddCallBack (this);
			}
            return;
		}
		// Child
		{
            if (data is Server)
            {
                Server server = data as Server;
                // serverManager
                {
                    this.maxClientUserCount = server.maxClientUserCount;
                }
                // ManagerUI
                {
                    if (this.data != null)
                    {
                        // Find 
                        ManagerUI.UIData managerUIData = this.data.managerUI.newOrOld<ManagerUI.UIData>();
                        // Update Property
                        {
                            managerUIData.server.v = new ReferenceData<Server>(server);
                        }
                        this.data.managerUI.v = managerUIData;
                    }
                    else
                    {
                        Debug.LogError("data null");
                    }
                }
                // Update
                {
                    UpdateUtils.makeUpdate<ManagerUpdate, Server>(server, this.transform);
                }
                return;
            }
            if (data is ManagerUI.UIData) {
				ManagerUI.UIData subUIData = data as ManagerUI.UIData;
                // UI
				{
					UIUtils.Instantiate (subUIData, managerUIPrefab, this.transform);
				}
                return;
			}
		}
        Debug.LogError("Don't process: " + data + "; " + this);
	}

	public void onRemoveCallBack<T> (T data, bool isHide) where T:Data
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
            // Child
			{
				uiData.server.allRemoveCallBack (this);
				uiData.managerUI.allRemoveCallBack (this);
			}
			this.data = null;
            return;
		}
		// Child
		{
            if (data is Server)
            {
                Server server = data as Server;
                // ManagerUI
                {
                    if (this.data != null)
                    {
                        if (this.data.managerUI.v != null)
                        {
                            ManagerUI.UIData subUIData = this.data.managerUI.v;
                            if (subUIData.server.v.data == server)
                            {
                                subUIData.server.v = new ReferenceData<Server>(null);
                            }
                            else
                            {
                                Debug.LogError("why different: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("data null");
                    }
                }
                // Update
                {
                    server.removeCallBackAndDestroy(typeof(ManagerUpdate));
                }
                return;
            }
            if (data is ManagerUI.UIData) {
				ManagerUI.UIData managerUIData = data as ManagerUI.UIData;
                // UI
                {
                    managerUIData.removeCallBackAndDestroy(typeof(ManagerUI));
                }
                return;
			}
		}
        Debug.LogError("Don't process: " + data + ", " + this);
	}

	public void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is UIData) {
			switch ((UIData.Property)wrapProperty.n) {
			case UIData.Property.server:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
				}
				break;
			case UIData.Property.managerUI:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
				}
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
        // Child
        {
            if (wrapProperty.p is Server)
            {
                return;
            }
            if (wrapProperty.p is ManagerUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion
}
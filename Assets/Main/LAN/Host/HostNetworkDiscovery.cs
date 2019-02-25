using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class BroadcastData
{
	public static int VERSION = 1;

	public int version = VERSION;
	public int port = 0;
	public int player = 0;

	// TODO co the co ten cua server nua

	public override string ToString()
	{
		// IMPORTANT: I'm adding a token at the end of this string (in this case two colons "::") so I can tell when the
		// data ends because Unity doesn't seem to clear the broadcastData buffer when changing it. This led to a weird
		// bug where the final element would get overwritten. eg. Previously, before adding the token, if the final
		// value was 999 but then changed to 1, it would be received as 199 because Unity would write the new value over
		// the previous value without clearing it. This way, the garbage data at the end will just get ignored.
		//
		// TODO: Find a better way of dealing with this!
		return String.Format("{0}:{1}:{2}", version, port, player);
	}

	public void FromString(string aString)
	{
		var items = aString.Split(':');
		version = Convert.ToInt32(items[0]);
		port = Convert.ToInt32 (items [1]);
		player = Convert.ToInt32 (items [2]);
	}
}

#pragma warning disable CS0618 // Type or member is obsolete
public class HostNetworkDiscovery : NetworkDiscovery, ValueChangeCallBack
#pragma warning restore CS0618 // Type or member is obsolete
{
    void Awake()
	{
		this.broadcastData = new BroadcastData ().ToString ();
	}

	#region update broadcast data

	private Server server;

	public void setData(Server newServer)
	{
		if (this.server != newServer) {
			// remove old
			if (this.server != null) {
				this.server.removeCallBack (this);
			}
			// set new
			this.server = newServer;
			if (this.server != null) {
				this.server.addCallBack (this);
			}
		} else {
			// Debug.LogError ("the same");
		}
	}

	private bool dirty = true;

	void FixedUpdate()
	{
		if (dirty) {
			dirty = false;
			if (this.server != null) {
				BroadcastData broadcastData = new BroadcastData ();
				{
					// PlayerCount
					{
						int playerCount = 0;
						for (int i = 0; i < server.users.vs.Count; i++) {
							User user = server.users.vs [i];
							switch (user.human.v.state.v.state.v) {
							case UserState.State.Online:
								playerCount++;
								break;
							case UserState.State.Disconnect:
								playerCount++;
								break;
							case UserState.State.Offline:
								break;
							default:
								// Debug.LogError ("unknown user state: " + user.state.property.state.property);
								break;
							}
						}
						broadcastData.player = playerCount;
					}
					// Port
					{
						ServerManager serverManager = ServerManager.instance;
						if (serverManager != null) {
							// Debug.LogError ("serverManager port: " + serverManager.networkPort);
							broadcastData.port = serverManager.networkPort;
						} else {
							// Debug.LogError ("serverManager null");
						}
					}
				}
				this.broadcastData = broadcastData.ToString ();
			} else {
				// Debug.LogError ("server null");
			}
		}
	}

	public void onAddCallBack<T> (T data) where T:Data
	{
		if (data is Server) {
			Server server = data as Server;
			// Child
			{
				server.users.allAddCallBack (this);
			}
			this.StartHosting ();
			dirty = true;
			return;
		}
		// Child
		{
			if (data is User) {
				User user = data as User;
				// Child
				{
					user.human.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is Human) {
					Human human = data as Human;
					// Child
					{
						human.state.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is UserState) {
					dirty = true;
					return;
				}
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public void onRemoveCallBack<T> (T data, bool isHide) where T:Data
	{
		if (data is Server) {
			Server server = data as Server;
			// Child
			{
				server.users.allRemoveCallBack (this);
			}
			return;
		}
		// Child
		{
			if (data is User) {
				User user = data as User;
				// Child
				{
					user.human.allRemoveCallBack (this);
				}
				return;
			}
			// Child
			{
				if (data is Human) {
					Human human = data as Human;
					// Child
					{
						human.state.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is UserState) {
					return;
				}
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		// Server
		if (wrapProperty.p is Server) {
			switch ((Server.Property)wrapProperty.n) {
			case Server.Property.startState:
				break;
			case Server.Property.type:
				break;
			case Server.Property.profile:
				break;
			case Server.Property.state:
				break;
			case Server.Property.users:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case Server.Property.globalChat:
				break;
			case Server.Property.friendWorld:
				break;
			case Server.Property.guilds:
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		{
			if (wrapProperty.p is User) {
				switch ((User.Property)wrapProperty.n) {
				case User.Property.human:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case User.Property.role:
					break;
				case User.Property.ipAddress:
					break;
				case User.Property.registerTime:
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			{
				if (wrapProperty.p is Human) {
					switch ((Human.Property)wrapProperty.n) {
					case Human.Property.playerId:
						break;
					case Human.Property.account:
						break;
					case Human.Property.state:
						{
							ValueChangeUtils.replaceCallBack(this, syncs);
							dirty = true;
						}
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
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				if (wrapProperty.p is UserState) {
					switch ((UserState.Property)wrapProperty.n) {
					case UserState.Property.state:
						dirty = true;
						break;
					case UserState.Property.hide:
						break;
					case UserState.Property.time:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
		}
	}

	#endregion

	public void StartHosting()
	{
		this.RestartBroadcast();
	}

	public void RestartBroadcast()
	{
		if (running)
		{
			StopBroadcast();
		}

		// Delay briefly to let things settle down
		CancelInvoke("RestartBroadcastInternal");
		Invoke("RestartBroadcastInternal", 0.5f);
	}

	private void RestartBroadcastInternal()
	{
		// Debug.Log("#CaptainsMess# Restarting server with data: " + broadcastData);

		// You can't update broadcastData while the server is running so I have to reinitialize and restart it
		// I think Unity is fixing this

		if (!Initialize()) {
			// Debug.LogError("#CaptainsMess# Network port is unavailable!");
		}
		if (!StartAsServer())
		{
			// Debug.LogError("#CaptainsMess# Unable to broadcast!");

			// Clean up some data that Unity seems not to
			if (hostId != -1)
			{
				if (isServer) {
#pragma warning disable CS0618 // Type or member is obsolete
                    NetworkTransport.StopBroadcastDiscovery();
#pragma warning restore CS0618 // Type or member is obsolete
                }
#pragma warning disable CS0618 // Type or member is obsolete
                NetworkTransport.RemoveHost(hostId);
#pragma warning restore CS0618 // Type or member is obsolete
                hostId = -1;
			}
		}
	}
}
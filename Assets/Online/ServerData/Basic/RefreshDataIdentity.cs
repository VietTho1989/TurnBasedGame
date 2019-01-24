using UnityEngine;
using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;

public class RefreshDataIdentity : UpdateBehavior<Server>
{
	#region MonoBehavior

	void Awake()
	{
		ServerManager clientManager = ServerManager.instance;
		if (clientManager != null) {
			if (clientManager.data != null) {
				Server server = clientManager.data.server.v.data;
				if (server != null) {
					if (server.type.v == Server.Type.Client) {
						this.setData (server);
					}
				} else {
					Debug.LogError ("server null");
				}
			} else {
				Debug.LogError ("data null");
			}
		}
	}

	public override void OnDestroy ()
	{
		base.OnDestroy ();
		ServerManager clientManager = ServerManager.instance;
		if (clientManager != null) {
			if (clientManager.data != null) {
				Server server = clientManager.data.server.v.data;
				if (server != null) {
					if (server.type.v == Server.Type.Client) {
						this.setData (null);
					}
				} else {
					Debug.LogError ("server null");
				}
			} else {
				Debug.LogError ("data null");
			}
		}
	}

	private bool isClient()
	{
		ServerManager clientManager = ServerManager.instance;
		if (clientManager.data != null) {
			Server server = clientManager.data.server.v.data;
			if (server != null) {
				if (server.type.v == Server.Type.Client) {
					return true;
				}
			} else {
				Debug.LogError ("server null");
			}
		} else {
			Debug.LogError ("data null");
		}
		return false;
	}

	#endregion

	#region Update

	public override void update ()
	{
		if (this.isClient ()) {
			// Refresh
			DataIdentity dataIdentity = GetComponent<DataIdentity> ();
			if (dataIdentity != null) {
				if (dataIdentity.refresh) {
					dataIdentity.refreshClientData ();
					this.enabled = false;
				}
			} else {
				Debug.LogError ("dataIdentity null");
			}
		} else {
			// Debug.LogError ("network is not client");
			this.enabled = false;
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return false;
	}

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is Server) {
			Server server = data as Server;
			{
				server.state.allAddCallBack (this);
			}
			return;
		}
		if (data is Server.State) {
			Server.State state = data as Server.State;
			{
				switch (state.getType()) {
				case Server.State.Type.Offline:
					break;
				case Server.State.Type.Connect:
					break;
				case Server.State.Type.Disconnect:
					{
						this.enabled = true;
						// Refresh
						DataIdentity dataIdentity = this.GetComponent<DataIdentity> ();
						if (dataIdentity != null) {
							dataIdentity.refresh = false;
						} else {
							Debug.LogError ("dataIdentity null");
						}
					}
					break;
				default:
					Debug.LogError ("unknown server state: " + state.getType());
					break;
				}
			}
			return;
		}
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is Server) {
			Server server = data as Server;
			{
				server.state.allRemoveCallBack (this);
			}
			this.setDataNull (server);
			return;
		}
		if (data is Server.State) {
			return;
		}
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is Server) {
			switch ((Server.Property)wrapProperty.n) {
			case Server.Property.serverConfig:
				break;
			case Server.Property.instanceId:
				break;
			case Server.Property.startState:
				break;
			case Server.Property.type:
				break;
			case Server.Property.profile:
				break;
			case Server.Property.state:
				{
					ValueChangeUtils.replaceCallBack(this, syncs);
				}
				break;
			case Server.Property.users:
				break;
			case Server.Property.disconnectTime:
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
	}

	#endregion
}
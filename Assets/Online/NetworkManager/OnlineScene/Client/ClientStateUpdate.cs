using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientStateUpdate : UpdateBehavior<Server>
{
	
	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {

			} else {
				Debug.LogError ("data null: " + this);
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is Server) {
			Server server = data as Server;
			// Child
			{
				server.state.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		if (data is Server.State) {
			Server.State state = data as Server.State;
			// Update
			{
				switch (state.getType ()) {
				case Server.State.Type.Offline:
					{
						Server.State.Offline offline = state as Server.State.Offline;
						UpdateUtils.makeUpdate<ClientOfflineStateUpdate, Server.State.Offline> (offline, this.transform);
					}
					break;
				case Server.State.Type.Connect:
					{
						Server.State.Connect connect = state as Server.State.Connect;
						UpdateUtils.makeUpdate<ClientConnectStateUpdate, Server.State.Connect> (connect, this.transform);
					}
					break;
				case Server.State.Type.Disconnect:
					{
						Server.State.Disconnect disconnect = state as Server.State.Disconnect;
						UpdateUtils.makeUpdate<ClientDisconnectStateUpdate, Server.State.Disconnect> (disconnect, this.transform);
					}
					break;
				default:
					Debug.LogError ("unknown type: " + state.getType ());
					break;
				}
			}
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}
		
	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is Server) {
			Server server = data as Server;
			// Child
			{
				server.state.allRemoveCallBack (this);
			}
			this.setDataNull (server);
			return;
		}
		// Child
		if (data is Server.State) {
			Server.State state = data as Server.State;
			// Update
			{
				switch (state.getType ()) {
				case Server.State.Type.Offline:
					{
						Server.State.Offline offline = state as Server.State.Offline;
						offline.removeCallBackAndDestroy (typeof(ClientOfflineStateUpdate));
					}
					break;
				case Server.State.Type.Connect:
					{
						Server.State.Connect connect = state as Server.State.Connect;
						connect.removeCallBackAndDestroy (typeof(ClientConnectStateUpdate));
					}
					break;
				case Server.State.Type.Disconnect:
					{
						Server.State.Disconnect disconnect = state as Server.State.Disconnect;
						disconnect.removeCallBackAndDestroy (typeof(ClientDisconnectStateUpdate));
					}
					break;
				default:
					Debug.LogError ("unknown type: " + state.getType ());
					break;
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
		if (wrapProperty.p is Server) {
			switch ((Server.Property)wrapProperty.n) {
			case Server.Property.serverConfig:
				break;
			case Server.Property.instanceId:
				{
					Debug.LogError ("server instanceId change, so logout");
					/*Server server = wrapProperty.p as Server;
					if (server.state.v.getType () != Server.State.Type.Offline) {
						ServerManager clientManager = ServerManager.instance;
						if (clientManager != null) {
							clientManager.logOut ();
						} else {
							Debug.LogError ("logOut: clientManager null");
						} 
					}*/
				}
				break;
			case Server.Property.startState:
				break;
			case Server.Property.type:
				break;
			case Server.Property.profile:
				break;
			case Server.Property.state:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case Server.Property.users:
				break;
			case Server.Property.globalChat:
				break;
			case Server.Property.friendWorld:
				break;
			case Server.Property.guilds:
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		if (wrapProperty.p is Server.State) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
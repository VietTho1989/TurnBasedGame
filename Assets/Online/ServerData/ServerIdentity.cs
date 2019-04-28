using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class ServerIdentity : DataIdentity
{

	#region instanceId

	[SyncVar(hook="onChangeInstanceId")]
	public long instanceId;

	public void onChangeInstanceId(long newInstanceId)
	{
		this.instanceId = newInstanceId;
		if (this.netData.clientData != null) {
			this.netData.clientData.instanceId.v = newInstanceId;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#region disconnectTime

	[SyncVar(hook="onChangeDisconnectTime")]
	public float disconnectTime;

	public void onChangeDisconnectTime(float newDisconnectTime)
	{
		this.disconnectTime = newDisconnectTime;
		if (this.netData.clientData != null) {
			this.netData.clientData.disconnectTime.v = newDisconnectTime;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#region NetData

	private NetData<Server> netData = new NetData<Server>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void maybeAddNewDataToClient()
	{
		Debug.LogError ("addServerIdentityToClient");
		if (this.netData.clientData == null) {
			if (searchInfor.Count != 0) {
				if (serverManager != null && serverManager.data != null && serverManager.data.server.v.data != null
				    && serverManager.data.server.v.data.type.v == Server.Type.Client) {
					this.netData.clientData = serverManager.data.server.v.data;
					// Add to parent
					this.transform.SetParent (serverManager.transform, true);
					// ClientMap
					DataIdentity.addToClientMap (this.netData.clientData, this);
					// Set Property
					refreshClientData ();
				} else {
					// Debug.LogError ("why clientManager null");
				}
			} else {
				Debug.LogError ("searchInfo count = 0: " + this);
			}
		} else {
			// Debug.Log ("already have client match");
		}
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeDisconnectTime (this.disconnectTime);
			this.onChangeDisconnectTime (this.instanceId);
		} else {
			// Debug.Log ("clientMatch null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += GetDataSize (this.disconnectTime);
			ret += GetDataSize (this.instanceId);
		}
		return ret;
	}

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is Server) {
			Server server = data as Server;
			// Set new parent
			{
				ServerManager serverManager = ServerManager.instance;
				if (serverManager != null) {
					this.transform.parent = serverManager.transform;
				} else {
					Debug.LogError ("serverManager null");
				}
			}
			// Property
			{
				this.serialize (this.searchInfor, server.makeSearchInforms ());
				this.disconnectTime = server.disconnectTime.v;
				this.instanceId = server.instanceId.v;
			}
			this.getDataSize ();
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new EveryOneObserver (observer);
					observer.setCheckChangeData (server);
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
		if (data is Server) {
			// Server server = data as Server;
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
		if (wrapProperty.p is Server) {
			switch ((Server.Property)wrapProperty.n) {
			case Server.Property.serverConfig:
				break;
			case Server.Property.instanceId:
				this.instanceId = (long)wrapProperty.getValue ();
				break;
			case Server.Property.startState:
				break;
			case Server.Property.type:
				break;
			case Server.Property.profile:
				break;
			case Server.Property.state:
				break;
			case Server.Property.users:
				break;
			case Server.Property.disconnectTime:
				this.disconnectTime = (float)wrapProperty.getValue ();
				break;
			case Server.Property.roomManager:
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
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
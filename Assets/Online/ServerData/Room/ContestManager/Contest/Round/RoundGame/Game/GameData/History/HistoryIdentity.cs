using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class HistoryIdentity : DataIdentity
{
	#region SyncVar

	#region isActive

	[SyncVar(hook="onChangeIsActive")]
	public System.Boolean isActive;

	public void onChangeIsActive(System.Boolean newIsActive)
	{
		this.isActive = newIsActive;
		if (this.netData.clientData != null) {
			this.netData.clientData.isActive.v = newIsActive;
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	#endregion

	#region position

	[SyncVar(hook="onChangePosition")]
	public System.Int32 position;

	public void onChangePosition(System.Int32 newPosition)
	{
		this.position = newPosition;
		if (this.netData.clientData != null) {
			this.netData.clientData.position.v = newPosition;
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	#endregion

	#region changeCount

	[SyncVar(hook="onChangeChangeCount")]
	public System.UInt32 changeCount;

	public void onChangeChangeCount(System.UInt32 newChangeCount)
	{
		this.changeCount = newChangeCount;
		if (this.netData.clientData != null) {
			this.netData.clientData.changeCount.v = newChangeCount;
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	#endregion

	#endregion

	#region NetData

	private NetData<History> netData = new NetData<History>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeIsActive(this.isActive);
			this.onChangePosition(this.position);
			this.onChangeChangeCount (this.changeCount);
		} else {
			// Debug.Log ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += GetDataSize (this.isActive);
			ret += GetDataSize (this.position);
			ret += GetDataSize (this.changeCount);
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is History) {
			History history = data as History;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, history.makeSearchInforms ());
				this.isActive = history.isActive.v;
				this.position = history.position.v;
				this.changeCount = history.changeCount.v;
			}
			this.getDataSize ();
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (history);
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
		if (data is History) {
			// History history = data as History;
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
		if (wrapProperty.p is History) {
			switch ((History.Property)wrapProperty.n) {
			case History.Property.isActive:
				this.isActive = (bool)wrapProperty.getValue ();
				break;
			case History.Property.changes:
				break;
			case History.Property.position:
				this.position = (int)wrapProperty.getValue ();
				break;
			case History.Property.changeCount:
				this.changeCount = (System.UInt32)wrapProperty.getValue ();
				break;
			case History.Property.humanConnections:
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

	#region add humanConnection

	public void requestAddHumanConnection(uint userId)
	{
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdHistoryAddHumanConnection (this.netId, userId);
		} else {
			Debug.LogError ("Cannot find clientConnect: " + this);
		}
	}

	public void addHumanConnection(uint userId)
	{
		if (this.netData.serverData != null) {
			this.netData.serverData.addHumanConnection (userId);
		} else {
			Debug.LogError ("serverData null");
		}
	}

	#endregion

	#region remove humanConnection

	public void requestRemoveHumanConnection(uint userId)
	{
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdHistoryRemoveHumanConnection (this.netId, userId);
		} else {
			Debug.LogError ("Cannot find clientConnect: " + this);
		}
	}

	public void removeHumanConnection(uint userId)
	{
		if (this.netData.serverData != null) {
			this.netData.serverData.removeHumanConnection (userId);
		} else {
			Debug.LogError ("serverData null");
		}
	}

	#endregion

}
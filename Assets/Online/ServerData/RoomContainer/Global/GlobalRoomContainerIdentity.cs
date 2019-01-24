using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class GlobalRoomContainerIdentity : DataIdentity
{

	#region SyncVar

	#endregion

	#region NetData

	private NetData<GlobalRoomContainer> netData = new NetData<GlobalRoomContainer>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
		} else {
			Debug.Log ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is GlobalRoomContainer) {
			GlobalRoomContainer globalRoomContainer = data as GlobalRoomContainer;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, globalRoomContainer.makeSearchInforms ());
			}
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (globalRoomContainer);
				} else {
					Debug.LogError ("observer null: " + this);
				}
			}
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is GlobalRoomContainer) {
			// GlobalRoomContainer globalRoomContainer = data as GlobalRoomContainer;
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.setCheckChangeData (null);
				} else {
					Debug.LogError ("observer null: " + this);
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
		if (wrapProperty.p is GlobalRoomContainer) {
			switch ((GlobalRoomContainer.Property)wrapProperty.n) {
			case GlobalRoomContainer.Property.rooms:
				break;
			default:
				Debug.LogError ("Unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	#region makeRoom

	public void requestMakeRoom(uint userId, CreateRoomMessage makeRoom)
	{
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdGlobalRoomContainerMakeRoom (this.netId, userId, makeRoom);
		} else {
			Debug.LogError ("Cannot find clientConnect: " + this);
		}
	}

	public void makeRoom(uint userId, CreateRoomMessage makeRoom)
	{
		if (this.netData.serverData != null) {
			this.netData.serverData.makeRoom (userId, makeRoom);
		} else {
			Debug.LogError ("serverData null: " + this);
		}
	}

	#endregion

}
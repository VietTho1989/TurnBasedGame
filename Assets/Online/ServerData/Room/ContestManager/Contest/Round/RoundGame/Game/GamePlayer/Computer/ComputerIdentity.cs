using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ComputerIdentity : DataIdentity
{

	#region SyncVar

	[SyncVar(hook="onChangeComputerName")]
	public System.String computerName;

	public void onChangeComputerName(System.String newComputerName)
	{
		this.computerName = newComputerName;
		if (this.netData.clientData != null) {
			this.netData.clientData.computerName.v = newComputerName;
		} else {
			// Debug.LogError ("clientData null: " + this);
		}
	}

	[SyncVar(hook="onChangeAvatarUrl")]
	public System.String avatarUrl;

	public void onChangeAvatarUrl(System.String newAvatarUrl)
	{
		this.avatarUrl = newAvatarUrl;
		if (this.netData.clientData != null) {
			this.netData.clientData.avatarUrl.v = newAvatarUrl;
		} else {
			// Debug.LogError ("clientData null: " + this);
		}
	}

	#endregion

	#region NetData

	private NetData<Computer> netData = new NetData<Computer>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeComputerName(this.computerName);
			this.onChangeAvatarUrl(this.avatarUrl);
		} else {
			// Debug.LogError ("clientData null: " + this);
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += GetDataSize (this.computerName);
			ret += GetDataSize (this.avatarUrl);
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is Computer) {
			Computer computer = data as Computer;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, computer.makeSearchInforms ());
				this.computerName = computer.computerName.v;
				this.avatarUrl = computer.avatarUrl.v;
			}
			this.getDataSize ();
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (computer);
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
		if (data is Computer) {
			// Computer computer = data as Computer;
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
		if (wrapProperty.p is Computer) {
			switch ((Computer.Property)wrapProperty.n) {
			case Computer.Property.computerName:
				this.computerName = (string)wrapProperty.getValue ();
				break;
			case Computer.Property.avatarUrl:
				this.avatarUrl = (string)wrapProperty.getValue ();
				break;
			case Computer.Property.ai:
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	#region change name

	public void requestChangeName(uint userId, string newName)
	{
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdComputerChangeName (this.netId, userId, newName);
		} else {
			Debug.LogError ("Cannot find clientConnect: " + this);
		}
	}

	public void changeName(uint userId, string newName)
	{
		if (this.netData.serverData != null) {
			this.netData.serverData.changeName (userId, newName);
		} else {
			Debug.LogError ("serverData null: " + this);
		}
	}

	#endregion

	#region change avatarUrl

	public void requestChangeAvatarUrl(uint userId, string newAvatarUrl)
	{
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdComputerChangeAvatarUrl (this.netId, userId, newAvatarUrl);
		} else {
			Debug.LogError ("Cannot find clientConnect: " + this);
		}
	}

	public void changeAvatarUrl(uint userId, string newAvatarUrl)
	{
		if (this.netData.serverData != null) {
			this.netData.serverData.changeAvatarUrl (userId, newAvatarUrl);
		} else {
			Debug.LogError ("serverData null: " + this);
		}
	}

	#endregion

}
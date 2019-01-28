﻿using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class PostureGameDataFactoryIdentity : DataIdentity
{

	#region SyncVar

	[SyncVar(hook="onChangeUseRule")]
	public System.Boolean useRule;

	public void onChangeUseRule(System.Boolean newUseRule)
	{
		this.useRule = newUseRule;
		if (this.netData.clientData != null) {
			this.netData.clientData.useRule.v = newUseRule;
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	#endregion

	#region NetData

	private NetData<PostureGameDataFactory> netData = new NetData<PostureGameDataFactory>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeUseRule(this.useRule);
		} else {
			// Debug.Log ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += GetDataSize (this.useRule);
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is PostureGameDataFactory) {
			PostureGameDataFactory postureGameDataFactory = data as PostureGameDataFactory;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, postureGameDataFactory.makeSearchInforms ());
				this.useRule = postureGameDataFactory.useRule.v;
			}
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (postureGameDataFactory);
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
		if (data is PostureGameDataFactory) {
			// PostureGameDataFactory postureGameDataFactory = data as PostureGameDataFactory;
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
		if (wrapProperty.p is PostureGameDataFactory) {
			switch ((PostureGameDataFactory.Property)wrapProperty.n) {
			case PostureGameDataFactory.Property.useRule:
				this.useRule = (bool)wrapProperty.getValue();
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

	#region Request Change GameData

	public void requestChangeGameData(uint userId, GameData newGameData)
	{
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			byte[] gameDataBytes = Data.MakeBinary (newGameData);
			if (gameDataBytes != null) {
				clientConnect.CmdPostureGameDataFactoryChangeGameData (this.netId, userId, gameDataBytes);
			} else {
				Debug.LogError ("gameDataBytes null");
			}
		} else {
			Debug.LogError ("Cannot find clientConnect: " + this);
		}
	}

	public void changeGameData(uint userId, GameData newGameData)
	{
		if (this.netData.serverData != null) {
			this.netData.serverData.changeGameData (userId, newGameData);
		} else {
			Debug.LogError ("serverData null");
		}
	}

	#endregion

	#region Request Change Type

	public void requestChangeType(uint userId, GameType.Type newGameType)
	{
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdPostureGameDataFactoryChangeType (this.netId, userId, newGameType);
		} else {
			Debug.LogError ("Cannot find clientConnect: " + this);
		}
	}

	public void changeType(uint userId, GameType.Type newGameType)
	{
		if (this.netData.serverData != null) {
			this.netData.serverData.changeGameType (userId, newGameType);
		} else {
			Debug.LogError ("serverData null");
		}
	}

	#endregion

	#region Change UseRule

	public void requestChangeUseRule(uint userId, bool newUseRule)
	{
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdPostureGameDataFactoryChangeUseRule (this.netId, userId, newUseRule);
		} else {
			Debug.LogError ("Cannot find clientConnect: " + this);
		}
	}

	public void changeUseRule(uint userId, bool newUseRule){
		if (this.netData.serverData != null) {
			this.netData.serverData.changeUseRule (userId, newUseRule);
		} else {
			Debug.LogError ("serverData null");
		}
	}

	#endregion
}
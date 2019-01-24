using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class GameFactoryIdentity : DataIdentity
{

	#region SyncVar

	#endregion

	#region NetData

	private NetData<GameFactory> netData = new NetData<GameFactory>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
		} else {
			// Debug.Log ("clientData null");
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
		if (data is GameFactory) {
			GameFactory gameFactory = data as GameFactory;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, gameFactory.makeSearchInforms ());
			}
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (gameFactory);
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
		if (data is GameFactory) {
			// GameFactory gameFactory = data as GameFactory;
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
		if (wrapProperty.p is GameFactory) {
			switch ((GameFactory.Property)wrapProperty.n) {
			default:
				Debug.LogError ("Unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	#region Request Change GameDataFactoryType

	public void requestChangeGameDataFactoryType(uint userId, GameDataFactory.Type newType)
	{
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdGameFactoryChangeGameDataFactoryType (this.netId, userId, newType);
		} else {
			Debug.LogError ("Cannot find clientConnect: " + this);
		}
	}

	public void changeGameDataFactoryType(uint userId, GameDataFactory.Type newType){
		if (this.netData.serverData != null) {
			this.netData.serverData.changeGameDataFactoryType (userId, newType);
		} else {
			Debug.LogError ("serverData null");
		}
	}

	#endregion

}
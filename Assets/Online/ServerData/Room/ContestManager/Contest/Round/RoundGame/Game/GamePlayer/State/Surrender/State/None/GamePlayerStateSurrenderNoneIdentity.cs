using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class GamePlayerStateSurrenderNoneIdentity : DataIdentity
{

	#region SyncVar

	#endregion

	#region NetData

	private NetData<GamePlayerStateSurrenderNone> netData = new NetData<GamePlayerStateSurrenderNone>();

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
		if (data is GamePlayerStateSurrenderNone) {
			GamePlayerStateSurrenderNone gamePlayerStateSurrenderNone = data as GamePlayerStateSurrenderNone;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, gamePlayerStateSurrenderNone.makeSearchInforms ());
			}
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (gamePlayerStateSurrenderNone);
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
		if (data is GamePlayerStateSurrenderNone) {
			// GamePlayerStateSurrenderNone gamePlayerStateSurrenderNone = data as GamePlayerStateSurrenderNone;
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
		if (wrapProperty.p is GamePlayerStateSurrenderNone) {
			switch ((GamePlayerStateSurrenderNone.Property)wrapProperty.n) {
			default:
				Debug.LogError ("Unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	#region Request

	public void requestMakeRequestCancel(uint userId)
	{
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdGamePlayerStateSurrenderNoneMakeRequestCancel (this.netId, userId);
		} else {
			Debug.LogError ("Cannot find clientConnect: " + this);
		}
	}

	public void makeRequestCancel(uint userId)
	{
		if (this.netData.serverData != null) {
			this.netData.serverData.makeRequestCancel (userId);
		} else {
			Debug.LogError ("serverData null");
		}
	}

	#endregion

}
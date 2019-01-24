using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class GamePlayerStateSurrenderIdentity : DataIdentity
{

	#region SyncVar

	#endregion

	#region NetData

	private NetData<GamePlayerStateSurrender> netData = new NetData<GamePlayerStateSurrender>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void addSyncListCallBack ()
	{
		base.addSyncListCallBack ();
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			
		} else {
			Debug.Log ("clientData null: " + this);
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
		if (data is GamePlayerStateSurrender) {
			GamePlayerStateSurrender gamePlayerStateSurrender = data as GamePlayerStateSurrender;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, gamePlayerStateSurrender.makeSearchInforms ());
			}
			this.getDataSize ();
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (gamePlayerStateSurrender);
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
		if (data is GamePlayerStateSurrender) {
			// GamePlayerStateSurrender gamePlayerStateSurrender = data as GamePlayerStateSurrender;
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
		if (wrapProperty.p is GamePlayerStateSurrender) {
			switch ((GamePlayerStateSurrender.Property)wrapProperty.n) {
			case GamePlayerStateSurrender.Property.state:
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

}
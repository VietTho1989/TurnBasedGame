using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

// [NetworkSettings(channel = Constants.ChatChanel)]
public class ChatGameMoveContentIdentity : DataIdentity
{

	#region SyncVar

	#endregion

	#region NetData

	private NetData<ChatGameMoveContent> netData = new NetData<ChatGameMoveContent>();

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
		if (data is ChatGameMoveContent) {
			ChatGameMoveContent chatGameMoveContent = data as ChatGameMoveContent;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, chatGameMoveContent.makeSearchInforms ());
			}
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (chatGameMoveContent);
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
		if (data is ChatGameMoveContent) {
			// ChatGameMoveContent chatGameMoveContent = data as ChatGameMoveContent;
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
		if (wrapProperty.p is ChatGameMoveContent) {
			switch ((ChatGameMoveContent.Property)wrapProperty.n) {
			case ChatGameMoveContent.Property.turn:
				break;
			case ChatGameMoveContent.Property.gameMove:
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

}
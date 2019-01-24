using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

// [NetworkSettings(channel = Constants.ChatChanel)]
public class ChatRoomUserStateContentIdentity : DataIdentity
{

	#region SyncVar

	[SyncVar(hook="onChangeUserId")]
	public System.UInt32 userId;

	public void onChangeUserId(System.UInt32 newUserId)
	{
		this.userId = newUserId;
		if (this.netData.clientData != null) {
			this.netData.clientData.userId.v = newUserId;
		} else {
			// Debug.LogError ("clientData null: " + this);
		}
	}

	[SyncVar(hook="onChangeAction")]
	public ChatRoomUserStateContent.Action action;

	public void onChangeAction(ChatRoomUserStateContent.Action newAction)
	{
		this.action = newAction;
		if (this.netData.clientData != null) {
			this.netData.clientData.action.v = newAction;
		} else {
			// Debug.LogError ("clientData null: " + this);
		}
	}

	#endregion

	#region NetData

	private NetData<ChatRoomUserStateContent> netData = new NetData<ChatRoomUserStateContent>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeUserId(this.userId);
			this.onChangeAction(this.action);
		} else {
			// Debug.Log ("clientData null: " + this);
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			// this.onChangeUserId(this.userId);
			ret += GetDataSize (this.userId);
			// this.onChangeState(this.state);
			ret += 4;// GetDataSize(this.state);
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is ChatRoomUserStateContent) {
			ChatRoomUserStateContent chatRoomUserStateContent = data as ChatRoomUserStateContent;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, chatRoomUserStateContent.makeSearchInforms ());
				this.userId = chatRoomUserStateContent.userId.v;
				this.action = chatRoomUserStateContent.action.v;
			}
			this.getDataSize ();
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (chatRoomUserStateContent);
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
		if (data is ChatRoomUserStateContent) {
			// ChatRoomUserStateContent chatRoomUserStateContent = data as ChatRoomUserStateContent;
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
		if (wrapProperty.p is ChatRoomUserStateContent) {
			switch ((ChatRoomUserStateContent.Property)wrapProperty.n) {
			case ChatRoomUserStateContent.Property.userId:
				this.userId = (System.UInt32)wrapProperty.getValue ();
				break;
			case ChatRoomUserStateContent.Property.action:
				this.action = (ChatRoomUserStateContent.Action)wrapProperty.getValue ();
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
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

// [NetworkSettings(channel = Constants.ChatChanel)]
public class ChatMessageIdentity : DataIdentity
{
	#region SyncVar

	[SyncVar(hook="onChangeState")]
	public ChatMessage.State state;

	public void onChangeState(ChatMessage.State newState)
	{
		this.state = newState;
		if (this.netData.clientData != null) {
			this.netData.clientData.state.v = newState;
		} else {
			// Debug.Log ("clientData null");
		}
	}

	[SyncVar(hook="onChangeTime")]
	public long time;

	public void onChangeTime(long newTime)
	{
		this.time = newTime;
		if (this.netData.clientData != null) {
			this.netData.clientData.time.v = newTime;
		} else {
			// Debug.Log ("clientData null");
		}
	}

	#endregion

	#region NetData

	private NetData<ChatMessage> netData = new NetData<ChatMessage>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeState (this.state);
			this.onChangeTime (this.time);
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += 4;
			ret += GetDataSize (this.time);
		}
		return ret;
	}

	#endregion

	#region implement callBack

	public override void onAddCallBack<T> (T data)
	{
		// ChatPlayer
		if (data is ChatMessage) {
			ChatMessage chatMessage = data as ChatMessage;
			// Parent
			this.addTransformToParent();
			// Set Property
			{
				this.serialize (this.searchInfor, chatMessage.makeSearchInforms ());
				this.state = chatMessage.state.v;
				this.time = chatMessage.time.v;
			}
			this.getDataSize ();
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new ChatMessageObserver (observer);
					observer.setCheckChangeData (chatMessage);
				} else {
					Debug.LogError ("observer null");
				}
			}
			return;
		}
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		// ChatPlayer
		if (data is ChatMessage) {
			//ChatMessage chatMessage = data as ChatMessage;
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
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is ChatMessage) {
			switch ((ChatMessage.Property)wrapProperty.n) {
			case ChatMessage.Property.state:
				this.state = (ChatMessage.State)wrapProperty.getValue();
				break;
			case ChatMessage.Property.time:
				this.time = (long)wrapProperty.getValue();
				break;
			case ChatMessage.Property.content:
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
	}

	#endregion

	#region Change State

	public void requestChangeState(uint userId, ChatMessage.State newState)
	{
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdChatMessageChangeState (this.netId, userId, newState);
		} else {
			Debug.LogError ("Cannot find clientConnect: " + this);
		}
	}

	public void changeState(uint userId, ChatMessage.State newState)
	{
		if (this.netData.serverData != null) {
			this.netData.serverData.changeState (userId, newState);
		} else {
			Debug.LogError ("serverData null: " + this);
		}
	}

	#endregion

}
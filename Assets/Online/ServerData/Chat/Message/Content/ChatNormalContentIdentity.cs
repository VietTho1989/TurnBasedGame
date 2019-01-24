using UnityEngine;
using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;

// [NetworkSettings(channel = Constants.ChatChanel)]
public class ChatNormalContentIdentity : DataIdentity
{

	#region SyncVar

	[SyncVar(hook="onChangeOwner")]
	public uint owner;

	public void onChangeOwner(uint newOwner)
	{
		this.owner = newOwner;
		if (this.netData.clientData != null) {
			this.netData.clientData.owner.v = newOwner;
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	[SyncVar(hook="onChangeEditMax")]
	public int editMax;

	public void onChangeEditMax(int newEditMax)
	{
		this.editMax = newEditMax;
		if (this.netData.clientData != null) {
			this.netData.clientData.editMax.v = newEditMax;
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	#region Message

	public class SyncListContent : SyncListSTRUCT<ChatNormalContent.Message>
	{
		
	}

	public  SyncListContent messages = new  SyncListContent();

	void onChangeMessages(SyncListSTRUCT<ChatNormalContent.Message>.Operation op, int index, ChatNormalContent.Message item)
	{
		if (this.netData.clientData != null) {
			IdentityUtils.onSyncListChange (this.netData.clientData.messages, this.messages, op, index);
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	#endregion

	#endregion

	#region NetData

	private NetData<ChatNormalContent> netData = new NetData<ChatNormalContent>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void addSyncListCallBack ()
	{
		base.addSyncListCallBack ();
		this.messages.Callback += onChangeMessages;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeOwner (this.owner);
			this.onChangeEditMax (this.editMax);
			IdentityUtils.refresh(this.netData.clientData.messages, this.messages);
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			// this.onChangeOwner (this.owner);
			ret+= 4;//GetDataSize(this.owner);
			// this.onChangeEditMax (this.editMax);
			ret+=GetDataSize(this.editMax);
			// IdentityUtils.refresh(this.netData.clientData.messages, this.messages);
			ret+=GetDataSize(this.messages);
		}
		return ret;
	}

	#endregion

	#region implement callBack

	public override void onAddCallBack<T> (T data)
	{
		// ChatPlayer
		if (data is ChatNormalContent) {
			ChatNormalContent chatNormalContent = data as ChatNormalContent;
			// Parent
			this.addTransformToParent();
			// Set Property
			{
				this.serialize (this.searchInfor, chatNormalContent.makeSearchInforms ());
				this.owner = chatNormalContent.owner.v;
				IdentityUtils.InitSync (this.messages, chatNormalContent.messages.vs);
				this.editMax = chatNormalContent.editMax.v;
			}
			this.getDataSize ();
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (chatNormalContent);
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
			// Set Property
			{
				this.messages.Clear ();
			}
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
		if (wrapProperty.p is ChatNormalContent) {
			switch ((ChatNormalContent.Property)wrapProperty.n) {
			case ChatNormalContent.Property.owner:
				this.owner = (uint)wrapProperty.getValue ();
				break;
			case ChatNormalContent.Property.messages:
				IdentityUtils.UpdateSyncList (this.messages, syncs, GlobalCast<T>.CastingChatNormalContentMessage);
				break;
			case ChatNormalContent.Property.editMax:
				this.editMax = (int)wrapProperty.getValue ();
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
	}

	#endregion

	#region Edit

	public void requestEdit(uint userId, string newMessage)
	{
		ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
		if (clientConnect != null) {
			clientConnect.CmdChatNormalContentEdit (this.netId, userId, newMessage);
		} else {
			Debug.LogError ("Cannot find clientConnect: " + this);
		}
	}

	public void edit(uint userId, string newMessage)
	{
		if (this.netData.serverData != null) {
			this.netData.serverData.edit (userId, newMessage);
		} else {
			Debug.LogError ("serverData null");
		}
	}

	#endregion
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatNormalContent : ChatMessage.Content 
{

	public const uint MAX_LENGTH = 100;
	public const uint MAX_EDIT = 5;

	#region Owner

	public VP<uint> owner;

	public bool isMine()
	{
		if (Server.getProfileUserId (this) == this.owner.v) {
			return true;
		}
		return false;
	}

	#endregion

	#region Content

	public struct Message
	{
		public long time;
		public string message;
	}

	public LP<Message> messages;

	/**
	 * // TODO Sau nay chuyen sang chatRoom
	 * */
	public VP<int> editMax;

	public bool isCanEdit(uint userId, string newMessage)
	{
		if (string.IsNullOrEmpty (newMessage)) {
			return false;
		}
		// Can edit anymore
		if (messages.vs.Count >= editMax.v) {
			return false;
		}
		// different message
		{
			if (this.messages.vs.Count > 0) {
				string lastMessage = this.messages.vs [messages.vs.Count - 1].message;
				if (lastMessage == newMessage) {
					Debug.LogError ("the same messages");
					return false;
				}
			} else {
				return false;
			}
		}
		// correct user
		if (this.owner.v == userId) {
			Debug.Log ("not correct userId: " + userId);
		} else {
			return false;
		}
		// return
		return true;
	}

	public void requestEdit(uint userId, string newMessage){
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.edit (userId, newMessage);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is ChatNormalContentIdentity) {
						ChatNormalContentIdentity chatNormalContentIdentity = dataIdentity as ChatNormalContentIdentity;
						chatNormalContentIdentity.requestEdit (userId, newMessage);
					} else {
						Debug.LogError ("Why isn't correct identity");
					}
				} else {
					Debug.LogError ("cannot find dataIdentity");
				}
			}
		} else {
			Debug.LogError ("You cannot request");
		}
	}

	public void edit(uint userId, string newMessage){
		if (isCanEdit (userId, newMessage)) {
			Message message = new Message ();
			{
				message.time = Global.getRealTimeInMiliSeconds ();
				message.message = newMessage;
			}
			this.messages.add (message);
		} else {
			Debug.LogError ("cannot edit: " + this + ", " + userId + ", " + newMessage);
		}
	}

	#endregion

	#region Constructor

	public enum Property
	{
		owner,
		messages,
		editMax
	}

	public ChatNormalContent(): base()
	{
		this.owner = new VP<uint> (this, (byte)Property.owner, 0);
		this.messages = new LP<Message> (this, (byte)Property.messages);
		this.editMax = new VP<int> (this, (byte)Property.editMax, 5);
	}

	#endregion

	public override Type getType ()
	{
		return ChatMessage.Content.Type.Normal;
	}

}
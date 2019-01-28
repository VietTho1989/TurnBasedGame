﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** TODO AlreadyView voi moi nguoi nen cho vao 1 list, ko de o tung message*/
public class ChatRoom : Data 
{

	public VP<Topic> topic;

	public VP<bool> isEnable;

	#region Player

	public LP<Human> players;

	public Human findHuman(uint humanId){
		return this.players.vs.Find (player => player.playerId.v == humanId);
	}

	public static Human findHuman(Data childData, uint humanId)
	{
		if (childData != null) {
			ChatRoom chatRoom = childData.findDataInParent<ChatRoom> ();
			if (chatRoom != null) {
				return chatRoom.findHuman (humanId);
			} else {
				Debug.LogError ("chatRoom null");
			}
		}
		return null;
	}

	/**
	 * Add player
	 * return already have
	 * */
	public bool addPlayer(uint playerId){
		for (int i = 0; i < this.players.vs.Count; i++) {
			Human player = this.players.vs [i];
			if (player.playerId.v == playerId) {
				return true;
			}
		}
		// Make new Human
		{
			Human human = new Human ();
			{
				human.uid = this.players.makeId ();
				human.playerId.v = playerId;
			}
			this.players.add (human);
		}
		return false;
	}

	#endregion

	#region Message

	public LP<ChatMessage> messages;

	public const uint LoadMorePerRequest = 20;

	public LP<ChatViewer> chatViewers;

	public ChatViewer findChatViewer(uint userId)
	{
		return this.chatViewers.vs.Find (chatViewer => chatViewer.userId.v == userId);
	}

	public void requestLoadMore(uint userId, uint loadMoreCount)
	{
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.loadMore (userId, loadMoreCount);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is ChatRoomIdentity) {
						ChatRoomIdentity chatRoomIdentity = dataIdentity as ChatRoomIdentity;
						chatRoomIdentity.requestLoadMore(userId, loadMoreCount);
					} else {
						Debug.LogError ("Why isn't correct identity");
					}
				}
			}
		} else {
			Debug.LogError ("You cannot request");
		}
	}

	public void loadMore(uint userId, uint loadMoreCount)
	{
		Debug.LogError ("loadMore: " + userId + ", " + loadMoreCount);
		ChatViewer chatViewer = this.findChatViewer (userId);
		if (chatViewer != null) {
			if (chatViewer.minViewId.v > loadMoreCount) {
				chatViewer.minViewId.v = chatViewer.minViewId.v - loadMoreCount;
			} else {
				chatViewer.minViewId.v = 0;
			}
		} else {
			chatViewer = new ChatViewer ();
			{
				chatViewer.uid = this.chatViewers.makeId ();
				chatViewer.userId.v = userId;
				// minViewId
				{
					if (this.messages.vs.Count > 0) {
						ChatMessage lastMessage = this.messages.vs [this.messages.vs.Count - 1];
						if (lastMessage.uid > loadMoreCount) {
							chatViewer.minViewId.v = lastMessage.uid - loadMoreCount;
						} else {
							chatViewer.minViewId.v = 0;
						}
					} else {
						chatViewer.minViewId.v = 0;
					}
				}
				// subViews: ko can
				// connection: xet sau
			}
			this.chatViewers.add (chatViewer);
		}
	}

	#endregion

	#region Typing

	public VP<Typing> typing;

	#endregion

	#region Constructor

	public enum Property
	{
		topic,
		isEnable,
		players,
		messages,
		chatViewers,
		typing
	}

	public ChatRoom():base()
	{
		this.topic = new VP<Topic> (this, (byte)Property.topic, new GeneralTopic ());
		this.isEnable = new VP<bool> (this, (byte)Property.isEnable, true);
		this.players = new LP<Human> (this, (byte)Property.players);
		this.messages = new LP<ChatMessage> (this, (byte)Property.messages);
		this.chatViewers = new LP<ChatViewer> (this, (byte)Property.chatViewers);
		this.typing = new VP<Typing> (this, (byte)Property.typing, new Typing ());
	}

	#endregion

	#region Normal Chat Message

	public void requestSendNormalMessage(uint userId, string message)
	{
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.sendNormalMessage (userId, message);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is ChatRoomIdentity) {
						ChatRoomIdentity chatRoomIdentity = dataIdentity as ChatRoomIdentity;
						chatRoomIdentity.requestSendNormalMessage (userId, message);
					} else {
						Debug.LogError ("Why isn't correct identity");
					}
				}
			}
		} else {
			Debug.LogError ("You cannot request");
		}
	}

	public void sendNormalMessage(uint userId, string newMessage)
	{
		if (this.isEnable.v) {
			if (this.topic.v.isCanSendNormalMessage (userId)) {
				// Add player
				this.addPlayer (userId);
				// Make new message
				ChatMessage chatMessage = new ChatMessage ();
				{
					chatMessage.uid = this.messages.makeId ();
					// state
					chatMessage.state.v = ChatMessage.State.Normal;
					// time
					chatMessage.time.v = Global.getRealTimeInMiliSeconds();
					// content
					{
						ChatNormalContent chatNormalContent = new ChatNormalContent ();
						{
							chatNormalContent.uid = chatMessage.content.makeId ();
							// owner
							chatNormalContent.owner.v = userId;
							// messages
							{
								ChatNormalContent.Message message = new ChatNormalContent.Message ();
								{
									message.time = Global.getRealTimeInMiliSeconds ();
									message.message = newMessage;
								}
								chatNormalContent.messages.add (message);
							}
						}
						chatMessage.content.v = chatNormalContent;
					}
				}
				// Add
				this.messages.add (chatMessage);
			} else {
				Debug.LogError ("Cannot send message: " + userId);
			}
		} else {
			Debug.LogError ("chatRoom is not enable: " + this);
		}
	}

	#endregion

}
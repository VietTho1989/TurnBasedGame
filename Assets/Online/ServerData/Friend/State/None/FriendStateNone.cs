using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FriendStateNone : Friend.State
{

	#region Constructor

	public enum Property
	{

	}

	public FriendStateNone() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.None;
	}

	public bool isCanRequest(uint userId)
	{
		bool ret = true;
		{
			// Check can answer
			if (ret) {
				List<uint> whoCanAnswer = Friend.GetWhoCanAnswer (this);
				if (!whoCanAnswer.Contains (userId)) {
					ret = false;
				}
			}
		}
		return ret;
	}

	#region MakeFriend

	public void requestMakeFriend(uint userId)
	{
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.makeFriend (userId);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is FriendStateNoneIdentity) {
						FriendStateNoneIdentity friendStateNoneIdentity = dataIdentity as FriendStateNoneIdentity;
						friendStateNoneIdentity.requestMakeFriend (userId);
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

	public void makeFriend(uint userId)
	{
		if (isCanRequest (userId)) {
			Friend friend = this.findDataInParent<Friend> ();
			if (friend != null) {
				FriendStateRequest friendStateRequest = new FriendStateRequest ();
				{
					friendStateRequest.uid = friend.state.makeId ();
					friendStateRequest.accepts.add (userId);
				}
				friend.state.v = friendStateRequest;
				// Add message
				{
					// Find FriendTopic
					FriendTopic friendTopic = null;
					{
						ChatRoom chatRoom = friend.chatRoom.v;
						if (chatRoom != null) {
							friendTopic = chatRoom.topic.v as FriendTopic;
						} else {
							Debug.LogError ("chatRoom null: " + this);
						}
					}
					if (friendTopic != null) {
						friendTopic.addFriendState (userId, FriendStateChangeContent.Action.Request);
					} else {
						Debug.LogError ("roomTopic null: " + this);
					}
				}
			} else {
				Debug.LogError ("friend null: " + this);
			}
		} else {
			Debug.LogError ("error, cannot make friend: " + userId + "; " + this);
		}
	}

	#endregion

	#region Ban

	public void requestBan(uint userId)
	{
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.ban (userId);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is FriendStateNoneIdentity) {
						FriendStateNoneIdentity friendStateNoneIdentity = dataIdentity as FriendStateNoneIdentity;
						friendStateNoneIdentity.requestBan (userId);
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

	public void ban(uint userId)
	{
		if (isCanRequest (userId)) {
			Friend friend = this.findDataInParent<Friend> ();
			if (friend != null) {
				FriendStateBan ban = new FriendStateBan ();
				{
					ban.uid = friend.state.makeId ();
					ban.userId.v = userId;
				}
				friend.state.v = ban;
				// Add message
				{
					// Find FriendTopic
					FriendTopic friendTopic = null;
					{
						ChatRoom chatRoom = friend.chatRoom.v;
						if (chatRoom != null) {
							friendTopic = chatRoom.topic.v as FriendTopic;
						} else {
							Debug.LogError ("chatRoom null: " + this);
						}
					}
					if (friendTopic != null) {
						friendTopic.addFriendState (userId, FriendStateChangeContent.Action.Ban);
					} else {
						Debug.LogError ("roomTopic null: " + this);
					}
				}
			} else {
				Debug.LogError ("friend null: " + this);
			}
		} else {
			Debug.LogError ("error, cannot ban: " + userId + "; " + this);
		}
	}

	#endregion

}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FriendStateAccept : Friend.State
{

	#region Constructor

	public enum Property
	{

	}

	public FriendStateAccept() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.Accept;
	}

	#region UnFriend

	public bool isCanUnFriend(uint userId)
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

	public void requestUnFriend(uint userId)
	{
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.unFriend (userId);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is FriendStateAcceptIdentity) {
						FriendStateAcceptIdentity friendStateAcceptIdentity = dataIdentity as FriendStateAcceptIdentity;
						friendStateAcceptIdentity.requestUnFriend (userId);
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

	public void unFriend(uint userId)
	{
		if (isCanUnFriend (userId)) {
			Friend friend = this.findDataInParent<Friend> ();
			if (friend != null) {
				FriendStateNone friendStateNone = new FriendStateNone ();
				{
					friendStateNone.uid = friend.state.makeId ();
				}
				friend.state.v = friendStateNone;
				// Add Message
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
						friendTopic.addFriendState (userId, FriendStateChangeContent.Action.UnFriend);
					} else {
						Debug.LogError ("roomTopic null: " + this);
					}
				}
			} else {
				Debug.LogError ("friend null: " + this);
			}
		} else {
			Debug.LogError ("Cannot unFriend: " + userId + "; " + this);
		}
	}

	#endregion

}
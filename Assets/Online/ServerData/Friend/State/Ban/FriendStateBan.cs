using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FriendStateBan : Friend.State
{

	public VP<uint> userId;

	#region Constructor

	public enum Property
	{
		userId
	}

	public FriendStateBan() : base()
	{
		this.userId = new VP<uint> (this, (byte)Property.userId, 0);
	}

	#endregion

	public override Type getType ()
	{
		return Type.Ban;
	}

	#region unBan

	public bool isCanUnBan(uint userId)
	{
		if (this.userId.v == userId) {
			return true;
		} else {
			return false;
		}
	}

	public void requestUnBan(uint userId)
	{
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.unBan (userId);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is FriendStateBanIdentity) {
						FriendStateBanIdentity friendStateBanIdentity = dataIdentity as FriendStateBanIdentity;
						friendStateBanIdentity.requestUnBan (userId);
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

	public void unBan(uint userId)
	{
		if (isCanUnBan (userId)) {
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
						friendTopic.addFriendState (userId, FriendStateChangeContent.Action.UnBan);
					} else {
						Debug.LogError ("roomTopic null: " + this);
					}
				}
			} else {
				Debug.LogError ("friend null: " + this);
			}
		} else {
			Debug.LogError ("Cannot unban: " + this);
		}
	}

	#endregion

}
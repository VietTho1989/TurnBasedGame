using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BanBan : Ban
{

	#region Constructor

	public enum Property
	{

	}

	public BanBan() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.Ban;
	}

	#region unBan

	public void requestUnBan(uint userId)
	{
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.unBan (userId);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is BanBanIdentity) {
						BanBanIdentity banBanIdentity = dataIdentity as BanBanIdentity;
						banBanIdentity.requestUnBan (userId);
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
		if (isCanBanOrUnBan (userId)) {
			Human human = this.findDataInParent<Human> ();
			if (human != null) {
				BanNormal banNormal = new BanNormal ();
				{
					banNormal.uid = human.ban.makeId ();
				}
				human.ban.v = banNormal;
				// Add message unban
				{
					// Find Topic
					UserTopic userTopic = null;
					{
						User user = human.findDataInParent<User> ();
						if (user != null) {
							ChatRoom chatRoom = user.chatRoom.v;
							if (chatRoom != null) {
								if (chatRoom.topic.v != null && chatRoom.topic.v is UserTopic) {
									userTopic = chatRoom.topic.v as UserTopic;
								}
							} else {
								Debug.LogError ("chatRoom null: " + this);
							}
						} else {
							Debug.LogError ("user null: " + this);
						}
					}
					// Add message
					if (userTopic != null) {
						userTopic.addUserAction (human.playerId.v, UserActionMessage.Action.UnBanned);
					} else {
						Debug.LogError ("userTopic null: " + this);
					}
				}
			} else {
				Debug.LogError ("human null: " + this);
			}
		} else {
			Debug.LogError ("User cannot make request unBan: " + userId + "; " + this);
		}
	}

	#endregion

}
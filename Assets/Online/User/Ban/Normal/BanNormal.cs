using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BanNormal : Ban
{

	#region Constructor

	public enum Property
	{

	}

	public BanNormal() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.Normal;
	}

	#region ban

	public void requestBan(uint userId)
	{
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.ban (userId);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is BanNormalIdentity) {
						BanNormalIdentity banNormalIdentity = dataIdentity as BanNormalIdentity;
						banNormalIdentity.requestBan (userId);
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

	/** TODO con thieu reason: de sau*/
	public void ban(uint userId)
	{
		if (isCanBanOrUnBan (userId)) {
			Human human = this.findDataInParent<Human> ();
			if (human != null) {
				BanBan banBan = new BanBan ();
				{
					banBan.uid = human.ban.makeId ();
				}
				human.ban.v = banBan;
				// Add message ban
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
						userTopic.addUserAction (human.playerId.v, UserActionMessage.Action.Banned);
					} else {
						Debug.LogError ("userTopic null: " + this);
					}
				}
			} else {
				Debug.LogError ("user null: " + this);
			}
		} else {
			Debug.LogError ("User cannot make request ban: " + userId + "; " + this);
		}
	}

	#endregion

}
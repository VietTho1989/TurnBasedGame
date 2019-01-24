using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FriendStateRequest : Friend.State
{

	public LP<uint> accepts;

	public LP<uint> refuses;

	#region Constructor

	public enum Property
	{
		accepts,
		refuses
	}

	public FriendStateRequest() : base()
	{
		this.accepts = new LP<uint> (this, (byte)Property.accepts);
		this.refuses = new LP<uint> (this, (byte)Property.refuses);
	}

	#endregion

	public override Type getType ()
	{
		return Type.Request;
	}

	#region Answer

	public bool isCanAnswer(uint userId)
	{
		bool ret = true;
		// can answer
		if(ret){
			List<uint> whoCanAnswer = Friend.GetWhoCanAnswer (this);
			if (!whoCanAnswer.Contains (userId)) {
				Debug.LogError ("Cannot answer: " + userId + "; " + this);
				ret = false;
			}
		}
		// already answer
		if(ret){
			if (this.accepts.vs.Contains (userId) || this.refuses.vs.Contains (userId)) {
				Debug.LogError ("already answer: " + this);
				ret = false;
			}
		}
		// return
		return ret;
	}

	#region accept

	public void requestAccept(uint userId)
	{
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.accept (userId);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is FriendStateRequestIdentity) {
						FriendStateRequestIdentity friendStateRequestIdentity = dataIdentity as FriendStateRequestIdentity;
						friendStateRequestIdentity.requestAccept (userId);
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

	public void accept(uint userId)
	{
		if (isCanAnswer (userId)) {
			this.accepts.add (userId);
			// Add message
			{
				Friend friend = this.findDataInParent<Friend> ();
				if (friend != null) {
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
						friendTopic.addFriendState (userId, FriendStateChangeContent.Action.Accept);
					} else {
						Debug.LogError ("roomTopic null: " + this);
					}
				} else {
					Debug.LogError ("friend null: " + this);
				}
			}
		} else {
			Debug.LogError ("cannot answer: "+userId+"; " + this);
		}
	}

	#endregion

	#region refuse

	public void requestRefuse(uint userId)
	{
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.refuse (userId);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is FriendStateRequestIdentity) {
						FriendStateRequestIdentity friendStateRequestIdentity = dataIdentity as FriendStateRequestIdentity;
						friendStateRequestIdentity.requestRefuse (userId);
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

	public void refuse(uint userId)
	{
		if (isCanAnswer (userId)) {
			this.refuses.add (userId);
			// Add message
			{
				Friend friend = this.findDataInParent<Friend> ();
				if (friend != null) {
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
						friendTopic.addFriendState (userId, FriendStateChangeContent.Action.Refuse);
					} else {
						Debug.LogError ("roomTopic null: " + this);
					}
				} else {
					Debug.LogError ("friend null: " + this);
				}
			}
		} else {
			Debug.LogError ("cannot answer: "+userId+"; "+this);
		}
	}

	#endregion

	#endregion

	#region cancel

	public bool isCanCancel(uint userId)
	{
		bool ret = true;
		// can answer
		if (ret) {
			List<uint> whoCanAnswer = Friend.GetWhoCanAnswer (this);
			if (!whoCanAnswer.Contains (userId)) {
				ret = false;
			}
		}
		// already answer
		if (ret) {
			if (!this.accepts.vs.Contains (userId)) {
				ret = false;
			}
		}
		// return
		return ret;
	}

	public void requestCancel(uint userId)
	{
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.cancel (userId);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is FriendStateRequestIdentity) {
						FriendStateRequestIdentity friendStateRequestIdentity = dataIdentity as FriendStateRequestIdentity;
						friendStateRequestIdentity.requestCancel (userId);
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

	public void cancel(uint userId)
	{
		if (isCanCancel (userId)) {
			Friend friend = this.findDataInParent<Friend> ();
			if (friend != null) {
				FriendStateNone friendStateNone = new FriendStateNone ();
				{
					friendStateNone.uid = friend.state.makeId ();
				}
				friend.state.v = friendStateNone;
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
						friendTopic.addFriendState (userId, FriendStateChangeContent.Action.Cancel);
					} else {
						Debug.LogError ("roomTopic null: " + this);
					}
				}
			} else {
				Debug.LogError ("friend null: " + this);
			}
		} else {
			Debug.LogError ("cannot cancel: " + this);
		}
	}

	#endregion

}
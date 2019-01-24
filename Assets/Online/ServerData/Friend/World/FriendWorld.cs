using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendWorld : Data
{
	public LP<Friend> friends;

	#region Constructor

	public FriendHashMap friendHashMap = new FriendHashMap();

	public enum Property
	{
		friends
	}

	public FriendWorld() : base()
	{
		this.friends = new LP<Friend> (this, (byte)Property.friends);
		// hashMap
		this.addCallBack(friendHashMap);
	}

	#endregion

	public List<Friend> getFriendList(uint userId)
	{
		return this.friendHashMap.getFriends(userId);
	}

	public Friend findFriend(uint user1Id, uint user2Id)
	{
		// get user1 friend list
		List<Friend> friends = getFriendList (user1Id);
		// Check
		foreach (Friend friend in friends) {
			if ((friend.user1.v.playerId.v == user1Id && friend.user2.v.playerId.v == user2Id)
			    || (friend.user1.v.playerId.v == user2Id && friend.user2.v.playerId.v == user1Id)) {
				return friend;
			}
		}
		// return
		return null;
	}

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendWorld : Data
{

    public FriendLP friends;

    #region Constructor

    public FriendHashMap friendHashMap = new FriendHashMap();

    public enum Property
    {
        friends
    }

    public FriendWorld() : base()
    {
        this.friends = new FriendLP(this, (byte)Property.friends);
        // hashMap
        this.addCallBack(friendHashMap);
    }

    #endregion

    public List<Friend> getFriendList(uint userId)
    {
        return this.friendHashMap.getFriends(userId);
    }

}
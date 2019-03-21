using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FriendLP : LP<Friend>, ValueChangeCallBack
{

    #region Constructor

    public FriendLP(Data parent, byte name) : base(parent, name)
    {
        parent.addCallBack(this);
    }

    #endregion

    #region dictionary

    private Dictionary<Tuple<uint, uint>, Friend> friendDict = new Dictionary<Tuple<uint, uint>, Friend>();

    public Friend getInList(uint user1Id, uint user2Id)
    {
        Friend ret = null;
        {
            Tuple<uint, uint> key = Tuple.Create(Math.Min(user1Id, user2Id), Math.Max(user1Id, user2Id));
            if(!friendDict.TryGetValue(key, out ret))
            {
                Debug.LogError("Don't have value: " + key);
            }
        }
        return ret;
    }

    #endregion

    #region implement callBacks

    public void onAddCallBack<T>(T data) where T : Data
    {
        if(data == p)
        {
            return;
        }
        // child
        if(data is Friend)
        {
            Friend friend = data as Friend;
            // add
            {
                Tuple<uint, uint> key = Tuple.Create(Math.Min(friend.user1Id.v, friend.user2Id.v), Math.Max(friend.user1Id.v, friend.user2Id.v));
                friendDict[key] = friend;
            }
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public void onRemoveCallBack<T>(T data, bool isHide) where T : Data
    {
        if (data == p)
        {
            return;
        }
        // child
        if (data is Friend)
        {
            Friend friend = data as Friend;
            // remove
            {
                Tuple<uint, uint> key = Tuple.Create(Math.Min(friend.user1Id.v, friend.user2Id.v), Math.Max(friend.user1Id.v, friend.user2Id.v));
                friendDict.Remove(key);
            }
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if(wrapProperty.p == p)
        {
            if (wrapProperty == this)
            {
                ValueChangeUtils.replaceCallBack(this, syncs);
            }
            return;
        }
        // Child
        if(wrapProperty.p is Friend)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}
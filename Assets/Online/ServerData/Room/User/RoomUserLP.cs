using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomUserLP : LP<RoomUser>, ValueChangeCallBack
{

    #region Constructor

    public RoomUserLP(Data parent, byte name) : base(parent, name)
    {
        //Debug.Log ("ListProperty Constructor: " + parent + ", " + properties);
        parent.addCallBack(this);
    }

    #endregion

    #region dict

    private Dictionary<uint, RoomUser> roomUserDict = new Dictionary<uint, RoomUser>();
    private HashSet<RoomUser> notCorrectRoomUsers = new HashSet<RoomUser>();

    public RoomUser getInList(uint userId)
    {
        RoomUser ret = null;
        {
            // get in dict
            RoomUser oldRoomUser = null;
            {
                if (!roomUserDict.TryGetValue(userId, out oldRoomUser))
                {
                    Debug.LogError("Don't have roomUser");
                }
            }
            // get in notCorrectUsers
            if (oldRoomUser != null && oldRoomUser.inform.v.playerId.v == userId)
            {
                // Debug.LogError("already found, not find in notCorrectRoomUsers anymore");
                ret = oldRoomUser;
            }
            else
            {
                // add to notCorrectRoomUsers
                if (oldRoomUser != null)
                {
                    notCorrectRoomUsers.Add(oldRoomUser);
                    roomUserDict.Remove(userId);
                }
                // find in notCorrectRoomUsers
                {
                    // find
                    foreach (RoomUser roomUser in notCorrectRoomUsers)
                    {
                        if (roomUser.inform.v.playerId.v == userId)
                        {
                            ret = roomUser;
                            break;
                        }
                    }
                    // add to dict
                    if (ret != null)
                    {
                        roomUserDict[userId] = ret;
                        notCorrectRoomUsers.Remove(ret);
                    }
                }
            }
        }
        return ret;
    }

    #endregion

    #region implement callBacks

    public void onAddCallBack<T>(T data) where T : Data
    {
        if (data is RoomUser)
        {
            RoomUser roomUser = data as RoomUser;
            // add
            {
                // find old
                RoomUser oldRoomUser = null;
                {
                    if (roomUserDict.TryGetValue(roomUser.inform.v.playerId.v, out oldRoomUser))
                    {
                        Debug.LogError("already have oldRoomUser: " + oldRoomUser);
                    }
                }
                // process
                if (oldRoomUser == null)
                {
                    roomUserDict[roomUser.inform.v.playerId.v] = roomUser;
                }
                else
                {
                    notCorrectRoomUsers.Add(roomUser);
                }
            }
            // Child
            {
                roomUser.inform.allAddCallBack(this);
            }
            return;
        }
        // Child
        if (data is Human)
        {
            Human human = data as Human;
            // add
            {
                RoomUser roomUser = human.findDataInParent<RoomUser>();
                if (roomUser != null)
                {
                    notCorrectRoomUsers.Add(roomUser);
                }
                else
                {
                    Debug.LogError("roomUser null");
                }
            }
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public void onRemoveCallBack<T>(T data, bool isHide) where T : Data
    {
        if (data is RoomUser)
        {
            RoomUser roomUser = data as RoomUser;
            // remove
            {
                // find old
                RoomUser oldRoomUser = null;
                {
                    if (roomUserDict.TryGetValue(roomUser.inform.v.playerId.v, out oldRoomUser))
                    {

                    }
                }
                // process
                if (oldRoomUser == roomUser)
                {
                    roomUserDict.Remove(roomUser.inform.v.playerId.v);
                    notCorrectRoomUsers.Remove(roomUser);
                }
                else
                {
                    Debug.LogError("Don't have old roomUser");
                    notCorrectRoomUsers.Remove(roomUser);
                }
            }
            // child
            {
                roomUser.inform.allRemoveCallBack(this);
            }
            return;
        }
        // Child
        if (data is Human)
        {
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
        if (wrapProperty.p == p)
        {
            if (wrapProperty == this)
            {
                ValueChangeUtils.replaceCallBack(this, syncs);
            }
            return;
        }
        if (wrapProperty.p is RoomUser)
        {
            switch ((RoomUser.Property)wrapProperty.n)
            {
                case RoomUser.Property.role:
                    break;
                case RoomUser.Property.inform:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                    }
                    break;
                case RoomUser.Property.state:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        if (wrapProperty.p is Human)
        {
            switch ((Human.Property)wrapProperty.n)
            {
                case Human.Property.playerId:
                    {
                        RoomUser roomUser = wrapProperty.p.findDataInParent<RoomUser>();
                        if (roomUser != null)
                        {
                            notCorrectRoomUsers.Add(roomUser);
                        }
                        else
                        {
                            Debug.LogError("roomUser null");
                        }
                    }
                    break;
                case Human.Property.account:
                    break;
                case Human.Property.state:
                    break;
                case Human.Property.email:
                    break;
                case Human.Property.phoneNumber:
                    break;
                case Human.Property.status:
                    break;
                case Human.Property.birthday:
                    break;
                case Human.Property.sex:
                    break;
                case Human.Property.connection:
                    break;
                case Human.Property.ban:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion   

}
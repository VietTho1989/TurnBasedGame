using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserLP : LP<User>, ValueChangeCallBack
{

    #region Constructor

    public UserLP(Data parent, byte name) : base(parent, name)
    {
        //Debug.Log ("ListProperty Constructor: " + parent + ", " + properties);
        parent.addCallBack(this);
    }

    #endregion

    #region dict

    private Dictionary<uint, User> userDict = new Dictionary<uint, User>();
    private HashSet<User> notCorrectUsers = new HashSet<User>();

    public User getInList(uint userId)
    {
        User ret = null;
        {
            // get in dict
            User oldUser = null;
            {
                if (!userDict.TryGetValue(userId, out oldUser))
                {
                    Debug.LogError("Don't have user");
                }
            }
            // get in notCorrectUsers
            if (oldUser != null && oldUser.human.v.playerId.v == userId)
            {
                // Debug.LogError("already found, not find in notCorrectUsers anymore");
                ret = oldUser;
            }
            else
            {
                // add to notCorrectUsers
                if (oldUser != null)
                {
                    notCorrectUsers.Add(oldUser);
                    userDict.Remove(userId);
                }
                // find in not correctUsers
                {
                    // find
                    foreach (User user in notCorrectUsers)
                    {
                        if (user.human.v.playerId.v == userId)
                        {
                            ret = user;
                            break;
                        }
                    }
                    // add to dict
                    if (ret != null)
                    {
                        userDict[userId] = ret;
                        notCorrectUsers.Remove(ret);
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
        if (data is User)
        {
            User user = data as User;
            // add
            {
                // find old
                User oldUser = null;
                {
                    if (userDict.TryGetValue(user.human.v.playerId.v, out oldUser))
                    {
                        // Debug.LogError("already have oldUser: " + oldUser);
                    }
                }
                // process
                if (oldUser == null)
                {
                    userDict[user.human.v.playerId.v] = user;
                }
                else
                {
                    notCorrectUsers.Add(user);
                }
            }
            // Child
            {
                user.human.allAddCallBack(this);
            }
            return;
        }
        // Child
        if (data is Human)
        {
            Human human = data as Human;
            // add
            {
                User user = human.findDataInParent<User>();
                if (user != null)
                {
                    notCorrectUsers.Add(user);
                }
                else
                {
                    Debug.LogError("user null");
                }
            }
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public void onRemoveCallBack<T>(T data, bool isHide) where T : Data
    {
        if (data is User)
        {
            User user = data as User;
            // remove
            {
                // find old
                User oldUser = null;
                {
                    if (userDict.TryGetValue(user.human.v.playerId.v, out oldUser))
                    {

                    }
                }
                // process
                if (oldUser == user)
                {
                    userDict.Remove(user.human.v.playerId.v);
                    notCorrectUsers.Remove(user);
                }
                else
                {
                    Debug.LogError("Don't have old user");
                    notCorrectUsers.Remove(user);
                }
            }
            // child
            {
                user.human.allRemoveCallBack(this);
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
        if (wrapProperty.p is User)
        {
            switch ((User.Property)wrapProperty.n)
            {
                case User.Property.human:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                    }
                    break;
                case User.Property.role:
                    break;
                case User.Property.ipAddress:
                    break;
                case User.Property.registerTime:
                    break;
                case User.Property.chatRoom:
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
                        User user = wrapProperty.p.findDataInParent<User>();
                        if (user != null)
                        {
                            notCorrectUsers.Add(user);
                        }
                        else
                        {
                            Debug.LogError("user null");
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

    public User findUserByAccount(AccountMessage accountMessage)
    {
        User user = null;
        {
            // TODO Can hoan thien
            foreach (User check in this.vs)
            {
                if (check.human.v.account.v.isEqual(accountMessage))
                {
                    user = check;
                    break;
                }
            }
        }
        return user;
    }

}
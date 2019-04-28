using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

public class UserIdentity : DataIdentity
{

    #region SyncVar

    #region role

    [SyncVar(hook = "onChangeRole")]
    public User.Role role;

    public void onChangeRole(User.Role newRole)
    {
        this.role = newRole;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.role.v = newRole;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #region token

    [SyncVar(hook = "onChangeToken")]
    public System.String token;

    public void onChangeToken(System.String newToken)
    {
        this.token = newToken;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.ipAddress.v = newToken;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #region registerTime

    [SyncVar(hook = "onChangeRegisterTime")]
    public System.Int64 registerTime;

    public void onChangeRegisterTime(System.Int64 newRegisterTime)
    {
        this.registerTime = newRegisterTime;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.registerTime.v = newRegisterTime;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #endregion

    #region NetData

    private NetData<User> netData = new NetData<User>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            this.onChangeRole(this.role);
            this.onChangeToken(this.token);
            this.onChangeRegisterTime(this.registerTime);
        }
        else
        {
            Debug.Log("clientData null");
        }
    }

    public override int refreshDataSize()
    {
        int ret = GetDataSize(this.netId);
        {
            ret += GetDataSize(this.role);
            ret += GetDataSize(this.token);
            ret += GetDataSize(this.registerTime);
        }
        return ret;
    }

    public override void afterAddNewDataToClient()
    {
        base.afterAddNewDataToClient();
        Debug.LogError("afterAddNewDataToClient: " + this.netData.getClientData());
        // Set server online
        if (serverManager != null && serverManager.data != null && serverManager.data.server.v.data != null
            && serverManager.data.server.v.data.type.v == Server.Type.Client)
        {
            // set connect
            {
                Server.State.Connect connect = new Server.State.Connect();
                {
                    connect.uid = serverManager.data.server.v.data.state.makeId();
                }
                serverManager.data.server.v.data.state.v = connect;
            }
            // Set Profile
            {
                // Debug.Log ("new server profile: " + clientData);
                // TODO se co van de neu uid vao playerId cua user khac nhau
                serverManager.data.server.v.data.profileId.v = this.netData.clientData.uid;// this.netData.clientData.human.v.playerId.v;
            }
        }
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is User)
        {
            User user = data as User;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, user.makeSearchInforms());
                this.role = user.role.v;
                this.token = user.ipAddress.v;
                this.registerTime = user.registerTime.v;
            }
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new UserObserver(observer);
                    observer.setCheckChangeData(user);
                }
                else
                {
                    Debug.LogError("observer null");
                }
            }
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is User)
        {
            // User user = data as User;
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.setCheckChangeData(null);
                }
                else
                {
                    Debug.LogError("observer null");
                }
            }
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if (wrapProperty.p is User)
        {
            switch ((User.Property)wrapProperty.n)
            {
                case User.Property.human:
                    break;
                case User.Property.role:
                    this.role = (User.Role)wrapProperty.getValue();
                    break;
                case User.Property.ipAddress:
                    this.token = (System.String)wrapProperty.getValue();
                    break;
                case User.Property.registerTime:
                    this.registerTime = (System.Int64)wrapProperty.getValue();
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

    #region Logout

    public void requestLogOut(uint userId)
    {
        Debug.LogError("requestLogout: " + userId + "; " + this);
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdLogOut(this.netId, userId);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void logOut(uint userId)
    {
        if (this.netData.serverData != null)
        {
            if (this.netData.serverData.human.v.playerId.v == userId)
            {
                // TargetLogout
                {
                    // TODO Can hoan thien
                }
                this.netData.serverData.human.v.state.v.state.v = UserState.State.Offline;
                // add message logout
                {
                    User user = this.netData.serverData;
                    // Find user topic
                    UserTopic userTopic = null;
                    {
                        ChatRoom chatRoom = user.chatRoom.v;
                        if (chatRoom != null)
                        {
                            if (chatRoom.topic.v != null && chatRoom.topic.v is UserTopic)
                            {
                                userTopic = chatRoom.topic.v as UserTopic;
                            }
                        }
                        else
                        {
                            Debug.LogError("chatRoom null");
                        }
                    }
                    // add message
                    if (userTopic != null)
                    {
                        userTopic.addUserAction(user.human.v.playerId.v, UserActionMessage.Action.Logout);
                    }
                    else
                    {
                        Debug.LogError("userTopic null: " + this);
                    }
                }
            }
            else
            {
                Debug.LogError("wrong user: " + this);
            }
        }
        else
        {
            Debug.LogError("serverData null: " + this);
        }
    }

    #endregion

    #region role

    public void requestChangeRole(uint userId, User.Role newRole)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdUserChangeRole(this.netId, userId, newRole);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void changeRole(uint userId, User.Role newRole)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.changeRole(userId, newRole);
        }
        else
        {
            Debug.LogError("serverData null: " + this);
        }
    }

    #endregion

    #region makeFriendRequest

    public void requestMakeFriendRequest(uint friendId)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdUserMakeFriendRequest(this.netId, friendId);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void makeFriendRequest(uint friendId)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.makeFriendRequest(friendId);
        }
        else
        {
            Debug.LogError("serverData null: " + this);
        }
    }

    #endregion

}
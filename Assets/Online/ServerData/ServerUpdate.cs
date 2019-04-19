using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ServerUpdate : UpdateBehavior<Server>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {

            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBack

    public override void onAddCallBack<T>(T data)
    {
        if (data is Server)
        {
            Server server = data as Server;
            // Child
            {
                server.users.allAddCallBack(this);
                server.roomManager.allAddCallBack(this);
                server.globalChat.allAddCallBack(this);
                server.friendWorld.allAddCallBack(this);
            }
            return;
        }
        // Child
        {
            if (data is User)
            {
                User user = data as User;
                // Update
                {
                    UpdateUtils.makeUpdate<UserUpdate, User>(user, this.transform);
                }
                return;
            }
            if (data is RoomManager)
            {
                RoomManager roomManager = data as RoomManager;
                // Update
                {
                    UpdateUtils.makeUpdate<RoomManagerUpdate, RoomManager>(roomManager, this.transform);
                }
                return;
            }
            if (data is GlobalChat)
            {
                GlobalChat globalChat = data as GlobalChat;
                // Update
                {
                    UpdateUtils.makeUpdate<GlobalChatUpdate, GlobalChat>(globalChat, this.transform);
                }
                return;
            }
            if (data is FriendWorld)
            {
                FriendWorld friendWorld = data as FriendWorld;
                // Update
                {
                    UpdateUtils.makeUpdate<FriendWorldUpdate, FriendWorld>(friendWorld, this.transform);
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is Server)
        {
            Server server = data as Server;
            // Child
            {
                server.users.allRemoveCallBack(this);
                server.roomManager.allRemoveCallBack(this);
                server.globalChat.allRemoveCallBack(this);
                server.friendWorld.allRemoveCallBack(this);
            }
            this.setDataNull(server);
            return;
        }
        // Child
        {
            if (data is User)
            {
                User user = data as User;
                // Update
                {
                    user.removeCallBackAndDestroy(typeof(UserUpdate));
                }
                return;
            }
            if (data is RoomManager)
            {
                RoomManager roomManager = data as RoomManager;
                // Update
                {
                    roomManager.removeCallBackAndDestroy(typeof(RoomManagerUpdate));
                }
                return;
            }
            if (data is GlobalChat)
            {
                GlobalChat globalChat = data as GlobalChat;
                // Update
                {
                    globalChat.removeCallBackAndDestroy(typeof(GlobalChatUpdate));
                }
                return;
            }
            if (data is FriendWorld)
            {
                FriendWorld friendWorld = data as FriendWorld;
                // Update
                {
                    friendWorld.removeCallBackAndDestroy(typeof(FriendWorldUpdate));
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if (wrapProperty.p is Server)
        {
            switch ((Server.Property)wrapProperty.n)
            {
                case Server.Property.state:
                    break;
                case Server.Property.profile:
                    break;
                case Server.Property.users:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                    }
                    break;
                case Server.Property.roomManager:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                    }
                    break;
                case Server.Property.globalChat:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                    }
                    break;
                case Server.Property.friendWorld:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            if (wrapProperty.p is User)
            {
                return;
            }
            if (wrapProperty.p is RoomManager)
            {
                return;
            }
            if (wrapProperty.p is GlobalChat)
            {
                return;
            }
            if (wrapProperty.p is FriendWorld)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}
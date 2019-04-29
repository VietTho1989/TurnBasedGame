using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618

public class RoomUserIdentity : DataIdentity
{
    #region SyncVar

    [SyncVar(hook = "onChangeRole")]
    public RoomUser.Role role;

    public void onChangeRole(RoomUser.Role newRole)
    {
        this.role = newRole;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.role.v = newRole;
        }
        else
        {
            // Debug.Log ("clientData null");
        }
    }

    [SyncVar(hook = "onChangeState")]
    public RoomUser.State state;

    public void onChangeState(RoomUser.State newState)
    {
        this.state = newState;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.state.v = newState;
        }
        else
        {
            // Debug.Log ("clientData null");
        }
    }

    #endregion

    #region NetData

    private NetData<RoomUser> netData = new NetData<RoomUser>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            this.onChangeRole(this.role);
            this.onChangeState(this.state);
        }
        else
        {
            // Debug.LogError ("clientData null");
        }
    }

    public override int refreshDataSize()
    {
        int ret = GetDataSize(this.netId);
        {
            ret += GetDataSize(this.role);
            ret += GetDataSize(this.state);
        }
        return ret;
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if (data is RoomUser)
        {
            RoomUser roomUser = data as RoomUser;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, roomUser.makeSearchInforms());
                this.role = roomUser.role.v;
                this.state = roomUser.state.v;
            }
            this.getDataSize();
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new RoomUserObserver(observer);
                    observer.setCheckChangeData(roomUser);
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
        if (data is RoomUser)
        {
            // RoomUser roomUser = data as RoomUser;
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
        if (wrapProperty.p is RoomUser)
        {
            switch ((RoomUser.Property)wrapProperty.n)
            {
                case RoomUser.Property.role:
                    this.role = (RoomUser.Role)wrapProperty.getValue();
                    break;
                case RoomUser.Property.inform:
                    break;
                case RoomUser.Property.state:
                    this.state = (RoomUser.State)wrapProperty.getValue();
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

    #region LeaveRoom

    public void requestLeaveRoom()
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdPlayerLeaveRoom(this.netId);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void leaveRoom()
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.leaveRoom();
        }
        else
        {
            Debug.LogError("serverData null");
        }
    }

    #endregion

    #region Kick

    public void requestKick(uint adminId)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdRoomUserKick(this.netId, adminId);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void kick(uint adminId)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.kick(adminId);
        }
        else
        {
            Debug.LogError("serverData null");
        }
    }

    #endregion

    #region UnKick

    public void requestUnKick(uint adminId)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdRoomUserUnKick(this.netId, adminId);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void unKick(uint adminId)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.unKick(adminId);
        }
        else
        {
            Debug.LogError("serverData null");
        }
    }

    #endregion

}
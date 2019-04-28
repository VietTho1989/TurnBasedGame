using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class LimitRoomContainerIdentity : DataIdentity
{

    #region SyncVar

    #region maxUserCount

    [SyncVar(hook = "onChangeMaxUserCount")]
    public System.Int32 maxUserCount;

    public void onChangeMaxUserCount(System.Int32 newMaxUserCount)
    {
        this.maxUserCount = newMaxUserCount;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.maxUserCount.v = newMaxUserCount;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #region userCount

    [SyncVar(hook = "onChangeUserCount")]
    public System.Int32 userCount;

    public void onChangeUserCount(System.Int32 newUserCount)
    {
        this.userCount = newUserCount;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.userCount.v = newUserCount;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #region gameTypes

    public SyncListInt gameTypes = new SyncListInt();

    private void OnGameTypesChanged(SyncListInt.Operation op, int index)
    {
        if (this.netData.clientData != null)
        {
            IdentityUtils.onSyncListChange(this.netData.clientData.gameTypes, this.gameTypes, op, index, GameType.gameTypeConvert);
        }
        else
        {
            // Debug.LogError ("clientData null: " + this);
        }
    }

    #endregion

    #endregion

    #region NetData

    private NetData<LimitRoomContainer> netData = new NetData<LimitRoomContainer>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void addSyncListCallBack()
    {
        base.addSyncListCallBack();
        this.gameTypes.Callback += OnGameTypesChanged;
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            this.onChangeMaxUserCount(this.maxUserCount);
            this.onChangeUserCount(this.userCount);
            IdentityUtils.refresh(this.netData.clientData.gameTypes, this.gameTypes, GameType.gameTypeConvert);
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
            ret += GetDataSize(this.maxUserCount);
            ret += GetDataSize(this.userCount);
            ret += GetDataSize(this.gameTypes);
        }
        return ret;
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is LimitRoomContainer)
        {
            LimitRoomContainer limitRoomContainer = data as LimitRoomContainer;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, limitRoomContainer.makeSearchInforms());
                this.maxUserCount = limitRoomContainer.maxUserCount.v;
                this.userCount = limitRoomContainer.userCount.v;
                IdentityUtils.InitSync(this.gameTypes, limitRoomContainer.gameTypes, GameType.intConvert);
            }
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(limitRoomContainer);
                }
                else
                {
                    Debug.LogError("observer null: " + this);
                }
            }
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is LimitRoomContainer)
        {
            // LimitRoomContainer limitRoomContainer = data as LimitRoomContainer;
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.setCheckChangeData(null);
                }
                else
                {
                    Debug.LogError("observer null: " + this);
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
        if (wrapProperty.p is LimitRoomContainer)
        {
            switch ((LimitRoomContainer.Property)wrapProperty.n)
            {
                case LimitRoomContainer.Property.maxUserCount:
                    this.maxUserCount = (System.Int32)wrapProperty.getValue();
                    break;
                case LimitRoomContainer.Property.userCount:
                    this.userCount = (System.Int32)wrapProperty.getValue();
                    break;
                case LimitRoomContainer.Property.users:
                    break;
                case LimitRoomContainer.Property.gameTypes:
                    IdentityUtils.UpdateSyncList(this.gameTypes, syncs, GlobalCast<T>.CastingInt32);
                    break;
                case LimitRoomContainer.Property.rooms:
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

    #region makeRoom

    public void requestMakeRoom(uint userId, CreateRoomMessage makeRoom)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdLimitRoomContainerMakeRoom(this.netId, userId, makeRoom);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void makeRoom(uint userId, CreateRoomMessage makeRoom)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.makeRoom(userId, makeRoom);
        }
        else
        {
            Debug.LogError("serverData null: " + this);
        }
    }

    #endregion

    #region join

    public void requestJoin(uint userId)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdLimitRoomContainerJoin(this.netId, userId);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void join(uint userId)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.join(userId);
        }
        else
        {
            Debug.LogError("serverData null: " + this);
        }
    }

    #endregion

    #region leave

    public void requestLeave(uint userId)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdLimitRoomContainerLeave(this.netId, userId);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void leave(uint userId)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.leave(userId);
        }
        else
        {
            Debug.LogError("serverData null: " + this);
        }
    }

    #endregion

}
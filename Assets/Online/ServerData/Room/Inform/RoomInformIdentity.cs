using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618

public class RoomInformIdentity : DataIdentity
{

    #region SyncVar

    #region userCount

    [SyncVar(hook = "onChangeUserCount")]
    public System.UInt32 userCount;

    public void onChangeUserCount(System.UInt32 newUserCount)
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

    #region isHavePassword

    [SyncVar(hook = "onChangeIsHavePassword")]
    public bool isHavePassword;

    public void onChangeIsHavePassword(bool newIsHavePassword)
    {
        this.isHavePassword = newIsHavePassword;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.isHavePassword.v = newIsHavePassword;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #region contestStateType

    [SyncVar(hook = "onChangeContestStateType")]
    public GameManager.Match.ContestManager.State.Type contestStateType;

    public void onChangeContestStateType(GameManager.Match.ContestManager.State.Type newContestStateType)
    {
        this.contestStateType = newContestStateType;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.contestStateType.v = newContestStateType;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #region gameType

    [SyncVar(hook = "onChangeGameType")]
    public GameType.Type gameType;

    public void onChangeGameType(GameType.Type newGameType)
    {
        this.gameType = newGameType;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.gameType.v = newGameType;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #endregion

    #region NetData

    private NetData<RoomInform> netData = new NetData<RoomInform>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            this.onChangeUserCount(this.userCount);
            this.onChangeIsHavePassword(this.isHavePassword);
            this.onChangeContestStateType(this.contestStateType);
            this.onChangeGameType(this.gameType);
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
            ret += GetDataSize(this.userCount);
            ret += GetDataSize(this.isHavePassword);
            ret += GetDataSize(this.contestStateType);
            ret += GetDataSize(this.gameType);
        }
        return ret;
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is RoomInform)
        {
            RoomInform roomInform = data as RoomInform;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, roomInform.makeSearchInforms());
                this.userCount = roomInform.userCount.v;
                this.isHavePassword = roomInform.isHavePassword.v;
                this.contestStateType = roomInform.contestStateType.v;
                this.gameType = roomInform.gameType.v;
            }
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(roomInform);
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
        if (data is RoomInform)
        {
            // RoomInform roomInform = data as RoomInform;
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
        if (wrapProperty.p is RoomInform)
        {
            switch ((RoomInform.Property)wrapProperty.n)
            {
                case RoomInform.Property.creator:
                    break;
                case RoomInform.Property.userCount:
                    this.userCount = (System.UInt32)wrapProperty.getValue();
                    break;
                case RoomInform.Property.isHavePassword:
                    this.isHavePassword = (bool)wrapProperty.getValue();
                    break;
                case RoomInform.Property.contestStateType:
                    this.contestStateType = (GameManager.Match.ContestManager.State.Type)wrapProperty.getValue();
                    break;
                case RoomInform.Property.gameType:
                    this.gameType = (GameType.Type)wrapProperty.getValue();
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
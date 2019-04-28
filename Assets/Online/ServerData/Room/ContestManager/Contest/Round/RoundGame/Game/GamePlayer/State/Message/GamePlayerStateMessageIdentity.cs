using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class GamePlayerStateMessageIdentity : DataIdentity
{

    #region SyncVar

    #region userId

    [SyncVar(hook = "onChangeUserId")]
    public System.UInt32 userId;

    public void onChangeUserId(System.UInt32 newUserId)
    {
        this.userId = newUserId;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.userId.v = newUserId;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #region playerIndex

    [SyncVar(hook = "onChangePlayerIndex")]
    public System.Int32 playerIndex;

    public void onChangePlayerIndex(System.Int32 newPlayerIndex)
    {
        this.playerIndex = newPlayerIndex;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.playerIndex.v = newPlayerIndex;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #region action

    [SyncVar(hook = "onChangeAction")]
    public GamePlayerStateMessage.Action action;

    public void onChangeAction(GamePlayerStateMessage.Action newAction)
    {
        this.action = newAction;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.action.v = newAction;
        }
        else
        {
            // Debug.LogError ("clientData null: "+this);
        }
    }

    #endregion

    #endregion

    #region NetData

    private NetData<GamePlayerStateMessage> netData = new NetData<GamePlayerStateMessage>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            this.onChangeUserId(this.userId);
            this.onChangePlayerIndex(this.playerIndex);
            this.onChangeAction(this.action);
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
            ret += GetDataSize(this.userId);
            ret += GetDataSize(this.playerIndex);
            ret += GetDataSize(this.action);
        }
        return ret;
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is GamePlayerStateMessage)
        {
            GamePlayerStateMessage gamePlayerStateMessage = data as GamePlayerStateMessage;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, gamePlayerStateMessage.makeSearchInforms());
                this.userId = gamePlayerStateMessage.userId.v;
                this.playerIndex = gamePlayerStateMessage.playerIndex.v;
                this.action = gamePlayerStateMessage.action.v;
            }
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(gamePlayerStateMessage);
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
        if (data is GamePlayerStateMessage)
        {
            // GamePlayerStateMessage gamePlayerStateMessage = data as GamePlayerStateMessage;
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
        if (wrapProperty.p is GamePlayerStateMessage)
        {
            switch ((GamePlayerStateMessage.Property)wrapProperty.n)
            {
                case GamePlayerStateMessage.Property.userId:
                    this.userId = (System.UInt32)wrapProperty.getValue();
                    break;
                case GamePlayerStateMessage.Property.playerIndex:
                    this.playerIndex = (System.Int32)wrapProperty.getValue();
                    break;
                case GamePlayerStateMessage.Property.action:
                    this.action = (GamePlayerStateMessage.Action)wrapProperty.getValue();
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
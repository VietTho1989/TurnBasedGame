using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618

public class GamePlayerIdentity : DataIdentity
{

    #region SyncVar

    [SyncVar(hook = "onChangePlayerIndex")]
    public int playerIndex;

    public void onChangePlayerIndex(int newPlayerIndex)
    {
        this.playerIndex = newPlayerIndex;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.playerIndex.v = newPlayerIndex;
        }
        else
        {
            // Debug.LogError ("clientData null");
        }
    }

    #endregion

    #region NetData

    private NetData<GamePlayer> netData = new NetData<GamePlayer>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            this.onChangePlayerIndex(this.playerIndex);
        }
        else
        {
            Debug.LogError("clientData null");
        }
    }

    public override int refreshDataSize()
    {
        int ret = GetDataSize(this.netId);
        {
            ret += GetDataSize(this.playerIndex);
        }
        return ret;
    }

    #endregion

    #region server callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is GamePlayer)
        {
            GamePlayer gamePlayer = data as GamePlayer;
            // set new parent
            this.addTransformToParent();
            // Property
            {
                this.serialize(this.searchInfor, gamePlayer.makeSearchInforms());
                this.playerIndex = gamePlayer.playerIndex.v;
            }
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(gamePlayer);
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
        if (data is GamePlayer)
        {
            //PlayerInfo playerInfo = data as PlayerInfo;
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
        if (wrapProperty.p is GamePlayer)
        {
            switch ((GamePlayer.Property)wrapProperty.n)
            {
                case GamePlayer.Property.playerIndex:
                    this.playerIndex = (int)wrapProperty.getValue();
                    break;
                case GamePlayer.Property.inform:
                    break;
                case GamePlayer.Property.state:
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
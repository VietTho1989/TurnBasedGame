using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameDataIdentity : DataIdentity
{

    #region SyncVar

    #region useRule

    [SyncVar(hook = "onChangeUseRule")]
    public bool useRule;

    public void onChangeUseRule(bool newUseRule)
    {
        this.useRule = newUseRule;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.useRule.v = newUseRule;
        }
        else
        {
            // Debug.LogError ("clientData null");
        }
    }

    #endregion

    #region blindFold

    [SyncVar(hook = "onChangeBlindFold")]
    public bool blindFold;

    public void onChangeBlindFold(bool newBlindFold)
    {
        this.blindFold = newBlindFold;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.blindFold.v = newBlindFold;
        }
        else
        {
            // Debug.LogError ("clientData null");
        }
    }

    #endregion

    #endregion

    #region NetData

    private NetData<GameData> netData = new NetData<GameData>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            this.onChangeUseRule(this.useRule);
            this.onChangeBlindFold(this.blindFold);
        }
        else
        {
            // Debug.Log ("clientData null");
        }
    }

    public override int refreshDataSize()
    {
        int ret = GetDataSize(this.netId);
        {
            ret += GetDataSize(this.useRule);
            ret += GetDataSize(this.blindFold);
        }
        return ret;
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is GameData)
        {
            GameData gameData = data as GameData;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, gameData.makeSearchInforms());
                this.useRule = gameData.useRule.v;
                this.blindFold = gameData.blindFold.v;
            }
            this.getDataSize();
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(gameData);
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
        if (data is GameData)
        {
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
        if (wrapProperty.p is GameData)
        {
            switch ((GameData.Property)wrapProperty.n)
            {
                case GameData.Property.gameType:
                    break;

                case GameData.Property.useRule:
                    this.useRule = (bool)wrapProperty.getValue();
                    break;
                case GameData.Property.requestChangeUseRule:
                    break;

                case GameData.Property.blindFold:
                    this.blindFold = (bool)wrapProperty.getValue();
                    break;
                case GameData.Property.requestChangeBlindFold:
                    break;

                case GameData.Property.turn:
                    break;
                case GameData.Property.timeControl:
                    break;
                case GameData.Property.lastMove:
                    break;
                case GameData.Property.state:
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
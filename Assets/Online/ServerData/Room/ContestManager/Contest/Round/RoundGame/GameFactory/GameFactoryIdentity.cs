using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class GameFactoryIdentity : DataIdentity
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
            // Debug.Log ("clientData null");
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
            // Debug.Log ("clientData null");
        }
    }

    #endregion

    #endregion

    #region NetData

    private NetData<GameFactory> netData = new NetData<GameFactory>();

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
        if (data is GameFactory)
        {
            GameFactory gameFactory = data as GameFactory;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, gameFactory.makeSearchInforms());
                this.useRule = gameFactory.useRule.v;
                this.blindFold = gameFactory.blindFold.v;
            }
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(gameFactory);
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
        if (data is GameFactory)
        {
            // GameFactory gameFactory = data as GameFactory;
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
        if (wrapProperty.p is GameFactory)
        {
            switch ((GameFactory.Property)wrapProperty.n)
            {
                case GameFactory.Property.useRule:
                    this.useRule = (bool)wrapProperty.getValue();
                    break;
                case GameFactory.Property.blindFold:
                    this.blindFold = (bool)wrapProperty.getValue();
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

    #region Request Change GameDataFactoryType

    public void requestChangeGameDataFactoryType(uint userId, GameDataFactory.Type newType)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdGameFactoryChangeGameDataFactoryType(this.netId, userId, newType);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void changeGameDataFactoryType(uint userId, GameDataFactory.Type newType)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.changeGameDataFactoryType(userId, newType);
        }
        else
        {
            Debug.LogError("serverData null");
        }
    }

    #endregion

    #region Change UseRule

    public void requestChangeUseRule(uint userId, bool newUseRule)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdGameFactoryChangeUseRule(this.netId, userId, newUseRule);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void changeUseRule(uint userId, bool newUseRule)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.changeUseRule(userId, newUseRule);
        }
        else
        {
            Debug.LogError("serverData null");
        }
    }

    #endregion

    #region Change BlindFold

    public void requestChangeBlindFold(uint userId, bool newBlindFold)
    {
        ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity(this.netData.clientData);
        if (clientConnect != null)
        {
            clientConnect.CmdGameFactoryChangeBlindFold(this.netId, userId, newBlindFold);
        }
        else
        {
            Debug.LogError("Cannot find clientConnect: " + this);
        }
    }

    public void changeBlindFold(uint userId, bool newBlindFold)
    {
        if (this.netData.serverData != null)
        {
            this.netData.serverData.changeBlindFold(userId, newBlindFold);
        }
        else
        {
            Debug.LogError("serverData null");
        }
    }

    #endregion

}
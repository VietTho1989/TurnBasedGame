using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618

public class PlayerResultIdentity : DataIdentity
{
    #region SyncVar

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
            // Debug.LogError ("clientData null");
        }
    }

    [SyncVar(hook = "onChangeScore")]
    public float score;

    public void onChangeScore(float newScore)
    {
        this.score = newScore;
        if (this.netData.clientData != null)
        {
            this.netData.clientData.score.v = newScore;
        }
        else
        {
            // Debug.LogError ("clientData null");
        }
    }

    #endregion

    #region NetData

    private NetData<PlayerResult> netData = new NetData<PlayerResult>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {
            this.onChangePlayerIndex(this.playerIndex);
            this.onChangeScore(this.score);
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
            ret += GetDataSize(this.playerIndex);
            ret += GetDataSize(this.score);
        }
        return ret;
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is PlayerResult)
        {
            PlayerResult playerResult = data as PlayerResult;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, playerResult.makeSearchInforms());
                this.playerIndex = playerResult.playerIndex.v;
                this.score = playerResult.score.v;
            }
            this.getDataSize();
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(playerResult);
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
        if (data is PlayerResult)
        {
            // PlayerResult playerResult = data as PlayerResult;
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
        if (wrapProperty.p is PlayerResult)
        {
            switch ((PlayerResult.Property)wrapProperty.n)
            {
                case PlayerResult.Property.playerIndex:
                    this.playerIndex = (int)wrapProperty.getValue();
                    break;
                case PlayerResult.Property.score:
                    this.score = (float)wrapProperty.getValue();
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
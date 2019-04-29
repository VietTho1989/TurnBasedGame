using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618

public class AnimationDataIdentity : DataIdentity
{

    #region SyncVar

    [SyncVar]
    public int moveAnimations;

    #endregion

    #region NetData

    private NetData<AnimationData> netData = new NetData<AnimationData>();

    public override NetDataDelegate getNetData()
    {
        return this.netData;
    }

    public override void refreshClientData()
    {
        if (this.netData.clientData != null)
        {

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

        }
        return ret;
    }

    #endregion

    #region implemt callback

    public override void onAddCallBack<T>(T data)
    {
        if (data is AnimationData)
        {
            AnimationData animationData = data as AnimationData;
            // Set new parent
            this.addTransformToParent();
            // Set property
            {
                this.serialize(this.searchInfor, animationData.makeSearchInforms());
                this.moveAnimations = animationData.moveAnimations.vs.Count;
            }
            // Observer
            {
                GameObserver observer = GetComponent<GameObserver>();
                if (observer != null)
                {
                    observer.checkChange = new FollowParentObserver(observer);
                    observer.setCheckChangeData(animationData);
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
        if (data is AnimationData)
        {
            // AnimationData animationData = data as AnimationData;
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
        if (wrapProperty.p is AnimationData)
        {
            switch ((AnimationData.Property)wrapProperty.n)
            {
                case AnimationData.Property.moveAnimations:
                    {
                        AnimationData animationData = wrapProperty.p as AnimationData;
                        this.moveAnimations = animationData.moveAnimations.vs.Count;
                    }
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
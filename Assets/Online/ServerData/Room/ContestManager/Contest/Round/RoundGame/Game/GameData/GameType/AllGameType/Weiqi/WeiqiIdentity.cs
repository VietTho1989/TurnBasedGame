using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace Weiqi
{
    public class WeiqiIdentity : DataIdentity
    {

        #region SyncVar

        #region scoreOwnerMap

        public SyncListInt scoreOwnerMap = new SyncListInt();

        private void OnScoreOwnerMapChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.scoreOwnerMap, this.scoreOwnerMap, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region scoreOwnerMapSize

        [SyncVar(hook = "onChangeScoreOwnerMapSize")]
        public System.Int32 scoreOwnerMapSize;

        public void onChangeScoreOwnerMapSize(System.Int32 newScoreOwnerMapSize)
        {
            this.scoreOwnerMapSize = newScoreOwnerMapSize;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.scoreOwnerMapSize.v = newScoreOwnerMapSize;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region scoreBlack

        [SyncVar(hook = "onChangeScoreBlack")]
        public System.Int32 scoreBlack;

        public void onChangeScoreBlack(System.Int32 newScoreBlack)
        {
            this.scoreBlack = newScoreBlack;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.scoreBlack.v = newScoreBlack;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region scoreWhite

        [SyncVar(hook = "onChangeScoreWhite")]
        public System.Int32 scoreWhite;

        public void onChangeScoreWhite(System.Int32 newScoreWhite)
        {
            this.scoreWhite = newScoreWhite;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.scoreWhite.v = newScoreWhite;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region dame

        [SyncVar(hook = "onChangeDame")]
        public System.Int32 dame;

        public void onChangeDame(System.Int32 newDame)
        {
            this.dame = newDame;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.dame.v = newDame;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region score

        [SyncVar(hook = "onChangeScore")]
        public System.Single score;

        public void onChangeScore(System.Single newScore)
        {
            this.score = newScore;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.score.v = newScore;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<Weiqi> netData = new NetData<Weiqi>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.scoreOwnerMap.Callback += OnScoreOwnerMapChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData.scoreOwnerMap, this.scoreOwnerMap);
                this.onChangeScoreOwnerMapSize(this.scoreOwnerMapSize);
                this.onChangeScoreBlack(this.scoreBlack);
                this.onChangeScoreWhite(this.scoreWhite);
                this.onChangeDame(this.dame);
                this.onChangeScore(this.score);
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
                ret += GetDataSize(this.scoreOwnerMap);
                ret += GetDataSize(this.scoreOwnerMapSize);
                ret += GetDataSize(this.scoreBlack);
                ret += GetDataSize(this.scoreWhite);
                ret += GetDataSize(this.dame);
                ret += GetDataSize(this.score);
                return ret;
            }
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is Weiqi)
            {
                Weiqi weiqi = data as Weiqi;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, weiqi.makeSearchInforms());
                    IdentityUtils.InitSync(this.scoreOwnerMap, weiqi.scoreOwnerMap.vs);
                    this.scoreOwnerMapSize = weiqi.scoreOwnerMapSize.v;
                    this.scoreBlack = weiqi.scoreBlack.v;
                    this.scoreWhite = weiqi.scoreWhite.v;
                    this.dame = weiqi.dame.v;
                    this.score = weiqi.score.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(weiqi);
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
            if (data is Weiqi)
            {
                // Weiqi weiqi = data as Weiqi;
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
            if (wrapProperty.p is Weiqi)
            {
                switch ((Weiqi.Property)wrapProperty.n)
                {
                    case Weiqi.Property.b:
                        break;
                    case Weiqi.Property.deadgroup:
                        break;
                    case Weiqi.Property.scoreOwnerMap:
                        IdentityUtils.UpdateSyncList(this.scoreOwnerMap, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case Weiqi.Property.scoreOwnerMapSize:
                        this.scoreOwnerMapSize = (System.Int32)wrapProperty.getValue();
                        break;
                    case Weiqi.Property.scoreBlack:
                        this.scoreBlack = (System.Int32)wrapProperty.getValue();
                        break;
                    case Weiqi.Property.scoreWhite:
                        this.scoreWhite = (System.Int32)wrapProperty.getValue();
                        break;
                    case Weiqi.Property.dame:
                        this.dame = (System.Int32)wrapProperty.getValue();
                        break;
                    case Weiqi.Property.score:
                        this.score = (System.Single)wrapProperty.getValue();
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
}
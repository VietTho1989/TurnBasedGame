using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace EnglishDraught
{
    public class EnglishDraughtMoveAnimationIdentity : DataIdentity
    {

        #region SyncVar

        #region Sqs

        public SyncListByte Sqs = new SyncListByte();

        private void OnSqsChanged(SyncListByte.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.Sqs, this.Sqs, op, index, MyByte.byteConvert);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region duration

        [SyncVar(hook = "onChangeDuration")]
        public float duration;

        public void onChangeDuration(float newDuration)
        {
            this.duration = newDuration;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.duration.v = newDuration;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<EnglishDraughtMoveAnimation> netData = new NetData<EnglishDraughtMoveAnimation>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.Sqs.Callback += OnSqsChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData.Sqs, this.Sqs, MyByte.byteConvert);
                this.onChangeDuration(this.duration);
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
                ret += GetDataSize(this.Sqs);
                ret += GetDataSize(this.duration);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is EnglishDraughtMoveAnimation)
            {
                EnglishDraughtMoveAnimation englishDraughtMoveAnimation = data as EnglishDraughtMoveAnimation;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, englishDraughtMoveAnimation.makeSearchInforms());
                    IdentityUtils.InitSync(this.Sqs, englishDraughtMoveAnimation.Sqs, MyByte.myByteConvert);
                    this.duration = englishDraughtMoveAnimation.duration.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(englishDraughtMoveAnimation);
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
            if (data is EnglishDraughtMoveAnimation)
            {
                // EnglishDraughtMoveAnimation englishDraughtMoveAnimation = data as EnglishDraughtMoveAnimation;
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
            if (wrapProperty.p is EnglishDraughtMoveAnimation)
            {
                switch ((EnglishDraughtMoveAnimation.Property)wrapProperty.n)
                {
                    case EnglishDraughtMoveAnimation.Property.Sqs:
                        IdentityUtils.UpdateSyncList(this.Sqs, syncs, GlobalCast<T>.CastingMyByte);
                        break;
                    case EnglishDraughtMoveAnimation.Property.move:
                        break;
                    case EnglishDraughtMoveAnimation.Property.duration:
                        this.duration = (float)wrapProperty.getValue();
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
using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
{
    public class WeiqiMoveAnimationIdentity : DataIdentity
    {

        #region SyncVar

        #region b

        public SyncListInt b = new SyncListInt();

        private void OnBChanged(SyncListInt.Operation op, int index, int item)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.b, this.b, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }
        #endregion

        #region coord

        [SyncVar(hook = "onChangeCoord")]
        public System.Int32 coord;

        public void onChangeCoord(System.Int32 newCoord)
        {
            this.coord = newCoord;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.coord.v = newCoord;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region color

        [SyncVar(hook = "onChangeColor")]
        public System.Int32 color;

        public void onChangeColor(System.Int32 newColor)
        {
            this.color = newColor;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.color.v = newColor;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region captureCoords

        public SyncListInt captureCoords = new SyncListInt();

        private void OnCaptureCoordsChanged(SyncListInt.Operation op, int index, int item)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.captureCoords, this.captureCoords, op, index);
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

        private NetData<WeiqiMoveAnimation> netData = new NetData<WeiqiMoveAnimation>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.b.Callback += OnBChanged;
            this.captureCoords.Callback += OnCaptureCoordsChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData.b, this.b);
                this.onChangeCoord(this.coord);
                this.onChangeColor(this.color);
                IdentityUtils.refresh(this.netData.clientData.captureCoords, this.captureCoords);
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
                ret += GetDataSize(this.b);
                ret += GetDataSize(this.coord);
                ret += GetDataSize(this.color);
                ret += GetDataSize(this.captureCoords);
                ret += GetDataSize(this.duration);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is WeiqiMoveAnimation)
            {
                WeiqiMoveAnimation weiqiMoveAnimation = data as WeiqiMoveAnimation;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, weiqiMoveAnimation.makeSearchInforms());
                    IdentityUtils.InitSync(this.b, weiqiMoveAnimation.b.vs);
                    this.coord = weiqiMoveAnimation.coord.v;
                    this.color = weiqiMoveAnimation.color.v;
                    IdentityUtils.InitSync(this.captureCoords, weiqiMoveAnimation.captureCoords.vs);
                    this.duration = weiqiMoveAnimation.duration.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(weiqiMoveAnimation);
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
            if (data is WeiqiMoveAnimation)
            {
                // WeiqiMoveAnimation weiqiMoveAnimation = data as WeiqiMoveAnimation;
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
            if (wrapProperty.p is WeiqiMoveAnimation)
            {
                switch ((WeiqiMoveAnimation.Property)wrapProperty.n)
                {
                    case WeiqiMoveAnimation.Property.b:
                        IdentityUtils.UpdateSyncList(this.b, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case WeiqiMoveAnimation.Property.coord:
                        this.coord = (System.Int32)wrapProperty.getValue();
                        break;
                    case WeiqiMoveAnimation.Property.color:
                        this.color = (System.Int32)wrapProperty.getValue();
                        break;
                    case WeiqiMoveAnimation.Property.captureCoords:
                        IdentityUtils.UpdateSyncList(this.captureCoords, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case WeiqiMoveAnimation.Property.duration:
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
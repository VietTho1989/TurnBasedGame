using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
    public class BracketStateEndIdentity : DataIdentity
    {

        #region SyncVar

        #region winTeamIndexs

        public SyncListInt winTeamIndexs = new SyncListInt();

        private void OnWinTeamIndexsChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.winTeamIndexs, this.winTeamIndexs, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region loseTeamIndexs

        public SyncListInt loseTeamIndexs = new SyncListInt();

        private void OnLoseTeamIndexsChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.loseTeamIndexs, this.loseTeamIndexs, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<BracketStateEnd> netData = new NetData<BracketStateEnd>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.winTeamIndexs.Callback += OnWinTeamIndexsChanged;
            this.loseTeamIndexs.Callback += OnLoseTeamIndexsChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData.winTeamIndexs, this.winTeamIndexs);
                IdentityUtils.refresh(this.netData.clientData.loseTeamIndexs, this.loseTeamIndexs);
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
                ret += GetDataSize(this.winTeamIndexs);
                ret += GetDataSize(this.loseTeamIndexs);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is BracketStateEnd)
            {
                BracketStateEnd bracketStateEnd = data as BracketStateEnd;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, bracketStateEnd.makeSearchInforms());
                    IdentityUtils.InitSync(this.winTeamIndexs, bracketStateEnd.winTeamIndexs.vs);
                    IdentityUtils.InitSync(this.loseTeamIndexs, bracketStateEnd.loseTeamIndexs.vs);
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(bracketStateEnd);
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
            if (data is BracketStateEnd)
            {
                // BracketStateEnd bracketStateEnd = data as BracketStateEnd;
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
            if (wrapProperty.p is BracketStateEnd)
            {
                switch ((BracketStateEnd.Property)wrapProperty.n)
                {
                    case BracketStateEnd.Property.winTeamIndexs:
                        IdentityUtils.UpdateSyncList(this.winTeamIndexs, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case BracketStateEnd.Property.loseTeamIndexs:
                        IdentityUtils.UpdateSyncList(this.loseTeamIndexs, syncs, GlobalCast<T>.CastingInt32);
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
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
    public class BracketContestIdentity : DataIdentity
    {

        #region SyncVar

        #region isActive

        [SyncVar(hook = "onChangeIsActive")]
        public System.Boolean isActive;

        public void onChangeIsActive(System.Boolean newIsActive)
        {
            this.isActive = newIsActive;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.isActive.v = newIsActive;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region index

        [SyncVar(hook = "onChangeIndex")]
        public System.Int32 index;

        public void onChangeIndex(System.Int32 newIndex)
        {
            this.index = newIndex;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.index.v = newIndex;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region teamIndexs

        public SyncListInt teamIndexs = new SyncListInt();

        private void OnTeamIndexsChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.teamIndexs, this.teamIndexs, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<BracketContest> netData = new NetData<BracketContest>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.teamIndexs.Callback += OnTeamIndexsChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeIsActive(this.isActive);
                this.onChangeIndex(this.index);
                IdentityUtils.refresh(this.netData.clientData.teamIndexs, this.teamIndexs);
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
                ret += GetDataSize(this.isActive);
                ret += GetDataSize(this.index);
                ret += GetDataSize(this.teamIndexs);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is BracketContest)
            {
                BracketContest bracketContest = data as BracketContest;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, bracketContest.makeSearchInforms());
                    this.isActive = bracketContest.isActive.v;
                    this.index = bracketContest.index.v;
                    IdentityUtils.InitSync(this.teamIndexs, bracketContest.teamIndexs.vs);
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(bracketContest);
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
            if (data is BracketContest)
            {
                // BracketContest bracketContest = data as BracketContest;
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
            if (wrapProperty.p is BracketContest)
            {
                switch ((BracketContest.Property)wrapProperty.n)
                {
                    case BracketContest.Property.isActive:
                        this.isActive = (System.Boolean)wrapProperty.getValue();
                        break;
                    case BracketContest.Property.index:
                        this.index = (System.Int32)wrapProperty.getValue();
                        break;
                    case BracketContest.Property.teamIndexs:
                        IdentityUtils.UpdateSyncList(this.teamIndexs, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case BracketContest.Property.contest:
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
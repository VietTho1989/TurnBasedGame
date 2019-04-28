using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
    public class BracketIdentity : DataIdentity
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

        #region bracketContests

        [SyncVar]
        public int bracketContests;

        #endregion

        #region byeTeamIndexs

        public SyncListInt byeTeamIndexs = new SyncListInt();

        private void OnByeTeamIndexsChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.byeTeamIndexs, this.byeTeamIndexs, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<Bracket> netData = new NetData<Bracket>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.byeTeamIndexs.Callback += OnByeTeamIndexsChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeIsActive(this.isActive);
                this.onChangeIndex(this.index);
                IdentityUtils.refresh(this.netData.clientData.byeTeamIndexs, this.byeTeamIndexs);
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
                ret += GetDataSize(this.byeTeamIndexs);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is Bracket)
            {
                Bracket bracket = data as Bracket;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, bracket.makeSearchInforms());
                    this.isActive = bracket.isActive.v;
                    this.index = bracket.index.v;
                    this.bracketContests = bracket.bracketContests.vs.Count;
                    IdentityUtils.InitSync(this.byeTeamIndexs, bracket.byeTeamIndexs.vs);
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(bracket);
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
            if (data is Bracket)
            {
                // Bracket bracket = data as Bracket;
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
            if (wrapProperty.p is Bracket)
            {
                switch ((Bracket.Property)wrapProperty.n)
                {
                    case Bracket.Property.isActive:
                        this.isActive = (System.Boolean)wrapProperty.getValue();
                        break;
                    case Bracket.Property.state:
                        break;
                    case Bracket.Property.index:
                        this.index = (System.Int32)wrapProperty.getValue();
                        break;
                    case Bracket.Property.bracketContests:
                        {
                            Bracket bracket = wrapProperty.p as Bracket;
                            this.bracketContests = bracket.bracketContests.vs.Count;
                        }
                        break;
                    case Bracket.Property.byeTeamIndexs:
                        IdentityUtils.UpdateSyncList(this.byeTeamIndexs, syncs, GlobalCast<T>.CastingInt32);
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
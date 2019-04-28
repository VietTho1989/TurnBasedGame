using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class RoundGameIdentity : DataIdentity
    {

        #region SyncVar

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

        #region playerInTeam

        public SyncListInt playerInTeam = new SyncListInt();

        private void OnPlayerInTeamChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.playerInTeam, this.playerInTeam, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region playerInGame

        public SyncListInt playerInGame = new SyncListInt();

        private void OnPlayerInGameChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.playerInGame, this.playerInGame, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<RoundGame> netData = new NetData<RoundGame>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.playerInTeam.Callback += OnPlayerInTeamChanged;
            this.playerInGame.Callback += OnPlayerInGameChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeIndex(this.index);
                IdentityUtils.refresh(this.netData.clientData.playerInTeam, this.playerInTeam);
                IdentityUtils.refresh(this.netData.clientData.playerInGame, this.playerInGame);
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
                ret += GetDataSize(this.index);
                ret += GetDataSize(this.playerInTeam);
                ret += GetDataSize(this.playerInGame);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is RoundGame)
            {
                RoundGame roundGame = data as RoundGame;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, roundGame.makeSearchInforms());
                    this.index = roundGame.index.v;
                    IdentityUtils.InitSync(this.playerInTeam, roundGame.playerInTeam.vs);
                    IdentityUtils.InitSync(this.playerInGame, roundGame.playerInGame.vs);
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(roundGame);
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
            if (data is RoundGame)
            {
                // RoundGame roundGame = data as RoundGame;
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
            if (wrapProperty.p is RoundGame)
            {
                switch ((RoundGame.Property)wrapProperty.n)
                {
                    case RoundGame.Property.index:
                        this.index = (System.Int32)wrapProperty.getValue();
                        break;
                    case RoundGame.Property.playerInTeam:
                        IdentityUtils.UpdateSyncList(this.playerInTeam, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case RoundGame.Property.playerInGame:
                        IdentityUtils.UpdateSyncList(this.playerInGame, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case RoundGame.Property.game:
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
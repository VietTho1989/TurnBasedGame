using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace GameManager.Match
{
    public class MatchTeamIdentity : DataIdentity
    {

        #region SyncVar

        #region teamIndex

        [SyncVar(hook = "onChangeTeamIndex")]
        public System.Int32 teamIndex;

        public void onChangeTeamIndex(System.Int32 newTeamIndex)
        {
            this.teamIndex = newTeamIndex;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.teamIndex.v = newTeamIndex;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<MatchTeam> netData = new NetData<MatchTeam>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeTeamIndex(this.teamIndex);
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
                ret += GetDataSize(this.teamIndex);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is MatchTeam)
            {
                MatchTeam matchTeam = data as MatchTeam;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, matchTeam.makeSearchInforms());
                    this.teamIndex = matchTeam.teamIndex.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(matchTeam);
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
            if (data is MatchTeam)
            {
                // MatchTeam matchTeam = data as MatchTeam;
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
            if (wrapProperty.p is MatchTeam)
            {
                switch ((MatchTeam.Property)wrapProperty.n)
                {
                    case MatchTeam.Property.teamIndex:
                        this.teamIndex = (System.Int32)wrapProperty.getValue();
                        break;
                    case MatchTeam.Property.state:
                        break;
                    case MatchTeam.Property.players:
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
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
    public class RoundRobinFactoryUpdate : UpdateBehavior<RoundRobinFactory>
    {

        #region Update

        public override void update()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    ContestManagerStateLobby lobby = this.data.findDataInParent<ContestManagerStateLobby>();
                    if (lobby != null)
                    {
                        GameType.Type gameTypeType = GameType.Type.Xiangqi;
                        int teamCount = 1;
                        int playerPerTeam = 1;
                        // Find
                        {
                            this.data.singleContestFactory.v.getTeamCountAndPlayerPerTeamGameType(out teamCount, out playerPerTeam, out gameTypeType);
                        }
                        this.data.teamCount.v = Mathf.Max(this.data.teamCount.v, teamCount + 1);
                        // Update
                        {
                            lobby.gameType.v = gameTypeType;
                            lobby.refreshTeam(this.data.teamCount.v, playerPerTeam);
                        }
                    }
                    else
                    {
                        Debug.LogError("lobby null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        private SingleContestFactoryCheckChange<SingleContestFactory> singleContestFactoryCheckChange = new SingleContestFactoryCheckChange<SingleContestFactory>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is RoundRobinFactory)
            {
                RoundRobinFactory roundRobinFactory = data as RoundRobinFactory;
                // Child
                {
                    roundRobinFactory.singleContestFactory.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                if (data is SingleContestFactory)
                {
                    SingleContestFactory singleContestFactory = data as SingleContestFactory;
                    // CheckChange
                    {
                        singleContestFactoryCheckChange.addCallBack(this);
                        singleContestFactoryCheckChange.setData(singleContestFactory);
                    }
                    dirty = true;
                    return;
                }
                // CheckChange
                if (data is SingleContestFactoryCheckChange<SingleContestFactory>)
                {
                    dirty = true;
                    return;
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is RoundRobinFactory)
            {
                RoundRobinFactory roundRobinFactory = data as RoundRobinFactory;
                // Child
                {
                    roundRobinFactory.singleContestFactory.allRemoveCallBack(this);
                }
                this.setDataNull(roundRobinFactory);
                return;
            }
            // Child
            {
                if (data is SingleContestFactory)
                {
                    // SingleContestFactory singleContestFactory = data as SingleContestFactory;
                    // CheckChange
                    {
                        singleContestFactoryCheckChange.removeCallBack(this);
                        singleContestFactoryCheckChange.setData(null);
                    }
                    return;
                }
                // CheckChange
                if (data is SingleContestFactoryCheckChange<SingleContestFactory>)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
        {
            if (WrapProperty.checkError(wrapProperty))
            {
                return;
            }
            if (wrapProperty.p is RoundRobinFactory)
            {
                switch ((RoundRobinFactory.Property)wrapProperty.n)
                {
                    case RoundRobinFactory.Property.singleContestFactory:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case RoundRobinFactory.Property.teamCount:
                        dirty = true;
                        break;
                    case RoundRobinFactory.Property.needReturnRound:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                if (wrapProperty.p is SingleContestFactory)
                {
                    return;
                }
                // CheckChange
                if (wrapProperty.p is SingleContestFactoryCheckChange<SingleContestFactory>)
                {
                    dirty = true;
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
        }

        #endregion

    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match.Swap;

namespace GameManager.Match
{
    public class ContestManagerStatePlay : ContestManager.State
    {

        #region State

        public abstract class State : Data
        {

            public enum Type
            {
                Normal,
                End
            }

            public abstract Type getType();

        }

        public VP<State> state;

        #endregion

        #region isForceEnd

        public VP<bool> isForceEnd;

        public bool isCanChangeForceEnd(uint userId)
        {
            return Room.isUserAdmin(userId, this);
        }

        public void requestChangeIsForceEnd(uint userId, bool newIsForceEnd)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeIsForceEnd(userId, newIsForceEnd);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is ContestManagerStatePlayIdentity)
                        {
                            ContestManagerStatePlayIdentity contestManagerStatePlayIdentity = dataIdentity as ContestManagerStatePlayIdentity;
                            contestManagerStatePlayIdentity.requestChangeIsForceEnd(userId, newIsForceEnd);
                        }
                        else
                        {
                            Debug.LogError("Why isn't correct identity");
                        }
                    }
                    else
                    {
                        Debug.LogError("cannot find dataIdentity");
                    }
                }
            }
            else
            {
                Debug.LogError("You cannot request");
            }
        }

        public void changeIsForceEnd(uint userId, bool newIsForceEnd)
        {
            if (isCanChangeForceEnd(userId))
            {
                this.isForceEnd.v = newIsForceEnd;
            }
            else
            {
                Debug.LogError("cannot change: " + userId + "; " + this);
            }
        }

        #endregion

        #region Team

        public LP<MatchTeam> teams;

        public MatchTeam findTeam(int teamIndex)
        {
            return this.teams.vs.Find(team => team.teamIndex.v == teamIndex);
        }

        public TeamPlayer findPlayer(int teamIndex, int playerIndex)
        {
            TeamPlayer teamPlayer = null;
            {
                MatchTeam team = this.findTeam(teamIndex);
                if (team != null)
                {
                    return team.findPlayer(playerIndex);
                }
                else
                {
                    Debug.LogError("team null: " + this);
                }
            }
            return teamPlayer;
        }

        #endregion

        #region swap

        public VP<Swap.Swap> swap;

        #endregion

        #region content

        public VP<ContestManagerContent> content;

        public VP<ContentTeamResult> contentTeamResult;

        public VP<GameType.Type> gameTypeType;

        #endregion

        /** lay tu lobby, ko su dung*/
        public VP<bool> randomTeamIndex;

        #region Constructor

        public enum Property
        {
            state,
            isForceEnd,

            teams,
            swap,

            content,
            contentTeamResult,
            gameTypeType,

            randomTeamIndex
        }

        public ContestManagerStatePlay() : base()
        {
            this.state = new VP<State>(this, (byte)Property.state, new ContestManagerStatePlayNormal());
            this.isForceEnd = new VP<bool>(this, (byte)Property.isForceEnd, false);
            // teams
            {
                this.teams = new LP<MatchTeam>(this, (byte)Property.teams);
                this.swap = new VP<Swap.Swap>(this, (byte)Property.swap, new Swap.Swap());
            }
            // content
            {
                this.content = new VP<ContestManagerContent>(this, (byte)Property.content, new SingleContestContent());
                this.contentTeamResult = new VP<ContentTeamResult>(this, (byte)Property.contentTeamResult, new ContentTeamResult());
                this.gameTypeType = new VP<GameType.Type>(this, (byte)Property.gameTypeType, GameType.Type.CHESS);
            }
            this.randomTeamIndex = new VP<bool>(this, (byte)Property.randomTeamIndex, false);
        }

        #endregion

        public override Type getType()
        {
            return Type.Play;
        }

    }
}
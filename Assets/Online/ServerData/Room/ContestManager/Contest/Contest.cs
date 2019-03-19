using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{

    public class Contest : Data
    {

        #region state

        public VP<ContestState> state;

        public VP<CalculateScore> calculateScore;

        #endregion

        #region team

        public VP<int> playerPerTeam;

        public int getPlayerPerTeam()
        {
            return Mathf.Max(this.playerPerTeam.v, 1);
        }

        /** so team = so nguoi choi can trong game*/
        public LP<MatchTeam> teams;

        public TeamPlayer findTeamPlayer(int teamIndex, int playerIndex)
        {
            TeamPlayer ret = null;
            {
                foreach (MatchTeam team in this.teams.vs)
                {
                    if (team.teamIndex.v == teamIndex)
                    {
                        foreach (TeamPlayer teamPlayer in team.players.vs)
                        {
                            if (teamPlayer.playerIndex.v == playerIndex)
                            {
                                ret = teamPlayer;
                                break;
                            }
                        }
                    }
                }
            }
            return ret;
        }

        #endregion

        #region Round

        public VP<RoundFactory> roundFactory;

        public LP<Round> rounds;

        #endregion

        public VP<RequestNewRound> requestNewRound;

        #region Constructor

        public enum Property
        {
            state,
            calculateScore,

            playerPerTeam,
            teams,

            roundFactory,
            rounds,

            requestNewRound
        }

        public Contest() : base()
        {
            this.state = new VP<ContestState>(this, (byte)Property.state, new ContestStateLoad());
            this.calculateScore = new VP<CalculateScore>(this, (byte)Property.calculateScore, new CalculateScoreWinLoseDraw());
            // team
            {
                this.playerPerTeam = new VP<int>(this, (byte)Property.playerPerTeam, 1);
                this.teams = new LP<MatchTeam>(this, (byte)Property.teams);
            }
            // round
            {
                this.roundFactory = new VP<RoundFactory>(this, (byte)Property.roundFactory, new NormalRoundFactory());
                this.rounds = new LP<Round>(this, (byte)Property.rounds);
            }
            this.requestNewRound = new VP<RequestNewRound>(this, (byte)Property.requestNewRound, new RequestNewRound());
        }

        #endregion

    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
    public class RoundRobinContent : ContestManagerContent
    {

        #region singleContestFactory

        public VP<SingleContestFactory> singleContestFactory;

        public int getMaxRound()
        {
            int ret = 1;
            {
                // get teamCountPerContest
                int teamCountPerContest = 1;
                {
                    int playerPerTeam = 1;
                    GameType.Type gameTypeType = GameType.Type.CHESS;
                    singleContestFactory.v.getTeamCountAndPlayerPerTeamGameType(out teamCountPerContest, out playerPerTeam, out gameTypeType);
                }
                if (teamCountPerContest == 2)
                {
                    ContestManagerStatePlay contestManagerStatePlay = this.findDataInParent<ContestManagerStatePlay>();
                    if (contestManagerStatePlay != null)
                    {
                        int allTeamCount = contestManagerStatePlay.teams.vs.Count + (contestManagerStatePlay.teams.vs.Count % 2);
                        ret = allTeamCount - 1;
                    }
                    else
                    {
                        Debug.LogError("contestManagerStatePlay null: " + this);
                    }
                }
                else
                {
                    // TODO Tam de 1, ko biet lam gi khac
                    return 1;
                }
            }
            return ret;
        }

        #endregion

        #region roundRobin

        public LP<RoundRobin> roundRobins;

        public void makeNewRound()
        {
            RoundRobin roundRobin = new RoundRobin();
            {
                roundRobin.uid = this.roundRobins.makeId();
                roundRobin.index.v = this.roundRobins.vs.Count;
                // roundContest
                {
                    ContestManagerStatePlay contestManagerStatePlay = this.findDataInParent<ContestManagerStatePlay>();
                    if (contestManagerStatePlay != null)
                    {
                        Contest contest = ((SingleContestContent)this.singleContestFactory.v.makeContent()).contest.v;
                        // get inform
                        int teamCount = 1;
                        int playerPerTeam = 1;
                        GameType.Type gameTypeType = GameType.Type.Xiangqi;
                        this.singleContestFactory.v.getTeamCountAndPlayerPerTeamGameType(out teamCount, out playerPerTeam, out gameTypeType);
                        if (teamCount == 2)
                        {
                            int allTeamCount = contestManagerStatePlay.teams.vs.Count + (contestManagerStatePlay.teams.vs.Count % 2);
                            if (allTeamCount >= 3)
                            {
                                // get teamList
                                List<int> teamList = new List<int>();
                                {
                                    // 0 1 
                                    // 3 2
                                    teamList.Add(0);
                                    // get otherTeams list
                                    for (int i = 0; i < allTeamCount - 1; i++)
                                    {
                                        teamList.Add((i + roundRobin.index.v) % (allTeamCount - 1) + 1);
                                    }
                                }
                                // make team1
                                List<int> team1 = new List<int>();
                                {
                                    team1.AddRange(teamList.GetRange(0, allTeamCount / 2));
                                }
                                // make team2 
                                List<int> team2 = new List<int>();
                                {
                                    team2.AddRange(teamList.GetRange(allTeamCount / 2, allTeamCount / 2));
                                    team2.Reverse();
                                }
                                // make round test
                                for (int i = 0; i < allTeamCount / 2; i++)
                                {
                                    if (i < team1.Count && i < team2.Count)
                                    {
                                        int team1Index = team1[i];
                                        int team2Index = team2[i];
                                        if (team1Index < contestManagerStatePlay.teams.vs.Count && team2Index < contestManagerStatePlay.teams.vs.Count)
                                        {
                                            RoundContest roundContest = new RoundContest();
                                            {
                                                roundContest.uid = roundRobin.roundContests.makeId();
                                                roundContest.index.v = i;
                                                //teamIndexs
                                                {
                                                    if ((roundContest.index.v + roundRobin.index.v + (roundRobin.index.v / (allTeamCount - 1))) % 2 == 0)
                                                    {
                                                        roundContest.teamIndexs.add(team1Index);
                                                        roundContest.teamIndexs.add(team2Index);
                                                    }
                                                    else
                                                    {
                                                        roundContest.teamIndexs.add(team2Index);
                                                        roundContest.teamIndexs.add(team1Index);
                                                    }
                                                }
                                                // contest
                                                {
                                                    Contest newContest = DataUtils.cloneData(contest) as Contest;
                                                    {
                                                        newContest.uid = roundContest.contest.makeId();
                                                    }
                                                    roundContest.contest.v = newContest;
                                                }
                                            }
                                            roundRobin.roundContests.add(roundContest);
                                        }
                                        else
                                        {
                                            // bye match, not make
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("teamCount error: " + i + "; " + team1.Count + "; " + team2.Count);
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("allTeamCount wrong: " + allTeamCount);
                            }
                        }
                        else
                        {
                            if (teamCount > 0)
                            {
                                for (int i = 0; i < contestManagerStatePlay.teams.vs.Count / teamCount; i++)
                                {
                                    RoundContest roundContest = new RoundContest();
                                    {
                                        roundContest.uid = roundRobin.roundContests.makeId();
                                        roundContest.index.v = i;
                                        //teamIndexs
                                        {
                                            for (int j = 0; j < teamCount; j++)
                                            {
                                                roundContest.teamIndexs.add(i * teamCount + j);
                                            }
                                        }
                                        // contest
                                        {
                                            Contest newContest = DataUtils.cloneData(contest) as Contest;
                                            {
                                                newContest.uid = roundContest.contest.makeId();
                                            }
                                            roundContest.contest.v = newContest;
                                        }
                                    }
                                    roundRobin.roundContests.add(roundContest);
                                }
                            }
                            else
                            {
                                Debug.LogError("why teamCount too small");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("contestManagerStatePlay null: " + this);
                    }
                }
            }
            this.roundRobins.add(roundRobin);
        }

        #endregion

        #region requestNewRoundRobin

        public VP<RequestNewRoundRobin> requestNewRoundRobin;

        #endregion

        public VP<bool> needReturnRound;

        #region Constructor

        public enum Property
        {
            singleContestFactory,
            roundRobins,
            requestNewRoundRobin,
            needReturnRound
        }

        public RoundRobinContent() : base()
        {
            this.singleContestFactory = new VP<SingleContestFactory>(this, (byte)Property.singleContestFactory, new SingleContestFactory());
            this.roundRobins = new LP<RoundRobin>(this, (byte)Property.roundRobins);
            this.requestNewRoundRobin = new VP<RequestNewRoundRobin>(this, (byte)Property.requestNewRoundRobin, new RequestNewRoundRobin());
            this.needReturnRound = new VP<bool>(this, (byte)Property.needReturnRound, false);
        }

        #endregion

        public override Type getType()
        {
            return Type.RoundRobin;
        }

        public override ContestManagerContentFactory makeContentFactory()
        {
            RoundRobinFactory roundRobinFactory = new RoundRobinFactory();
            {
                // singleContestFactory
                {
                    SingleContestFactory singleContestFactory = DataUtils.cloneData(this.singleContestFactory.v) as SingleContestFactory;
                    {
                        singleContestFactory.uid = roundRobinFactory.singleContestFactory.makeId();
                    }
                    roundRobinFactory.singleContestFactory.v = singleContestFactory;
                }
                // teamCount
                {
                    int teamCount = 4;
                    {
                        ContestManagerStatePlay contestManagerStatePlay = this.findDataInParent<ContestManagerStatePlay>();
                        if (contestManagerStatePlay != null)
                        {
                            teamCount = contestManagerStatePlay.teams.vs.Count;
                        }
                        else
                        {
                            Debug.LogError("contestManagerStatePlay null: " + this);
                        }
                    }
                    roundRobinFactory.teamCount.v = teamCount;
                }
                // needReturnRound
                roundRobinFactory.needReturnRound.v = this.needReturnRound.v;
            }
            return roundRobinFactory;
        }

        public override GameType.Type getGameTypeType()
        {
            GameType.Type gameTypeType = GameType.Type.CHESS;
            {
                SingleContestFactory singleContestFactory = this.singleContestFactory.v;
                if (singleContestFactory != null)
                {
                    int teamCountPerContest = 1;
                    int playerPerTeam = 1;
                    singleContestFactory.getTeamCountAndPlayerPerTeamGameType(out teamCountPerContest, out playerPerTeam, out gameTypeType);
                }
                else
                {
                    Debug.LogError("singleContestFactory null: " + this);
                }
            }
            return gameTypeType;
        }

    }
}
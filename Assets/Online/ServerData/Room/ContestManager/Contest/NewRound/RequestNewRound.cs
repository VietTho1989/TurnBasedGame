using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class RequestNewRound : Data
    {

        #region State

        public abstract class State : Data
        {

            public enum Type
            {
                None,
                Ask,
                Accept
            }

            public abstract Type getType();

        }

        public VP<State> state;

        public static HashSet<uint> WhoCanAsk(Data data)
        {
            HashSet<uint> ret = new HashSet<uint>();
            {
                if (data != null)
                {
                    RequestNewRound requestNewRound = data.findDataInParent<RequestNewRound>();
                    if (requestNewRound != null)
                    {
                        // add all team member of round
                        {
                            Contest contest = requestNewRound.findDataInParent<Contest>();
                            if (contest != null)
                            {
                                foreach (MatchTeam team in contest.teams.vs)
                                {
                                    foreach (TeamPlayer teamPlayer in team.players.vs)
                                    {
                                        if (teamPlayer.inform.v is Human)
                                        {
                                            Human human = teamPlayer.inform.v as Human;
                                            ret.Add(human.playerId.v);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("contest null: " + data);
                            }
                        }
                        // add admin
                        if (ret.Count == 0)
                        {
                            RoomUser admin = Room.findAdmin(requestNewRound);
                            if (admin != null)
                            {
                                Human adminHuman = admin.inform.v;
                                if (adminHuman != null)
                                {
                                    ret.Add(adminHuman.playerId.v);
                                }
                                else
                                {
                                    Debug.LogError("adminHuman null: " + data);
                                }
                            }
                            else
                            {
                                Debug.LogError("admin null: " + data);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("requestNewRound null: " + data);
                    }
                }
                else
                {
                    Debug.LogError("data null");
                }
            }
            return ret;
        }

        #endregion

        #region Limit

        public abstract class Limit : Data
        {

            public enum Type
            {
                NoLimit,
                HaveLimit
            }

            public abstract Type getType();

            public abstract bool isCanMakeMoreRound();

        }

        public VP<Limit> limit;

        #endregion

        #region Constructor

        public enum Property
        {
            state,
            limit
        }

        public RequestNewRound() : base()
        {
            this.state = new VP<State>(this, (byte)Property.state, new RequestNewRoundStateNone());
            this.limit = new VP<Limit>(this, (byte)Property.limit, new RequestNewRoundNoLimit());
        }

        #endregion

        public static bool IsCanMakeNewRound(Data data)
        {
            if (data != null)
            {
                RequestNewRound requestNewRound = data.findDataInParent<RequestNewRound>();
                if (requestNewRound != null)
                {
                    return requestNewRound.isCanMakeNewRound();
                }
                else
                {
                    Debug.LogError("requestNewRound null: " + data);
                }
            }
            else
            {
                Debug.LogError("data null");
            }
            return false;
        }

        public bool isCanMakeNewRound()
        {
            bool allRoundEnd = true;
            {
                Contest contest = this.findDataInParent<Contest>();
                if (contest != null)
                {
                    foreach (Round round in contest.rounds.vs)
                    {
                        if (!(round.state.v is RoundStateEnd))
                        {
                            allRoundEnd = false;
                            break;
                        }
                    }
                }
                else
                {
                    Debug.LogError("contest null: " + this);
                }
            }
            if (allRoundEnd)
            {
                return this.limit.v.isCanMakeMoreRound();
            }
            else
            {
                return false;
            }
        }

    }
}
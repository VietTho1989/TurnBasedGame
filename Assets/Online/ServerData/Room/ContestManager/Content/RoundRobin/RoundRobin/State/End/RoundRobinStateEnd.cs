using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
    public class RoundRobinStateEnd : RoundRobin.State
    {

        #region teamResult

        public LP<TeamResult> teamResults;

        public float getResult(int teamIndex)
        {
            foreach (TeamResult teamResult in this.teamResults.vs)
            {
                if (teamResult.teamIndex.v == teamIndex)
                {
                    return teamResult.score.v;
                }
            }
            return 0;
        }

        #endregion

        #region Constructor

        public enum Property
        {
            teamResults
        }

        public RoundRobinStateEnd() : base()
        {
            this.teamResults = new LP<TeamResult>(this, (byte)Property.teamResults);
        }

        #endregion

        public override Type getType()
        {
            return Type.End;
        }

    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
    public class TimeControlNormal : TimeControl.Sub
    {

        #region Info

        public VP<TimeInfo> generalInfo;

        public LP<PlayerTimeInfo> playerTimeInfos;

        public TimeInfo getTimeInfo(int playerIndex)
        {
            foreach (PlayerTimeInfo playerTimeInfo in this.playerTimeInfos.vs)
            {
                if (playerTimeInfo.playerIndex.v == playerIndex)
                {
                    return playerTimeInfo.timeInfo.v;
                }
            }
            return this.generalInfo.v;
        }

        #endregion

        public LP<PlayerTotalTime> playerTotalTimes;

        public PlayerTotalTime getPlayerTotalTime(int playerIndex)
        {
            return this.playerTotalTimes.vs.Find(playerTotalTime => playerTotalTime.playerIndex.v == playerIndex);
        }

        #region Constructor

        public enum Property
        {
            generalInfo,
            playerTimeInfos,
            playerTotalTimes
        }

        public TimeControlNormal() : base()
        {
            {
                this.generalInfo = new VP<TimeInfo>(this, (byte)Property.generalInfo, new TimeInfo());
                this.generalInfo.nh = 0;
            }
            {
                this.playerTimeInfos = new LP<PlayerTimeInfo>(this, (byte)Property.playerTimeInfos);
                this.playerTimeInfos.nh = 0;
            }
            this.playerTotalTimes = new LP<PlayerTotalTime>(this, (byte)Property.playerTotalTimes);
        }

        #endregion

        public override Type getType()
        {
            return Type.Normal;
        }

    }
}
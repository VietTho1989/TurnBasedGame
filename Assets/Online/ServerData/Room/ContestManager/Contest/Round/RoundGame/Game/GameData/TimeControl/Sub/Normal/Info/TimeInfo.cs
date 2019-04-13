using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
    public class TimeInfo : Data
    {

        #region timePerTurn

        public VP<TimePerTurnInfo> timePerTurn;

        public void requestChangeTimePerTurnType(uint userId, int newTimePerTurnType)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeTimePerTurnType(userId, newTimePerTurnType);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is TimeInfoIdentity)
                        {
                            TimeInfoIdentity timeInfoIdentity = dataIdentity as TimeInfoIdentity;
                            timeInfoIdentity.requestChangeTimePerTurnType(userId, newTimePerTurnType);
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

        public void changeTimePerTurnType(uint userId, int newTimePerTurnType)
        {
            // Process
            if (GameManager.Match.ContestManagerStateLobby.IsCanChange(this, userId))
            {
                TimePerTurnInfo.Type type = (TimePerTurnInfo.Type)newTimePerTurnType;
                // need make new?
                bool needMakeNew = true;
                {
                    if (this.timePerTurn.v != null)
                    {
                        if (type == this.timePerTurn.v.getType())
                        {
                            needMakeNew = false;
                        }
                    }
                    else
                    {
                        Debug.LogError("timePerTurn null: " + this);
                    }
                }
                // Process
                if (needMakeNew)
                {
                    TimePerTurnInfo timePerTurnInfo = null;
                    {
                        switch (type)
                        {
                            case TimePerTurnInfo.Type.Limit:
                                timePerTurnInfo = new TimePerTurnInfo.Limit();
                                break;
                            case TimePerTurnInfo.Type.NoLimit:
                                timePerTurnInfo = new TimePerTurnInfo.NoLimit();
                                break;
                            default:
                                Debug.LogError("unknown type: " + type + "; " + this);
                                break;
                        }
                    }
                    if (timePerTurnInfo != null)
                    {
                        timePerTurnInfo.uid = this.timePerTurn.makeId();
                        this.timePerTurn.v = timePerTurnInfo;
                    }
                    else
                    {
                        Debug.LogError("timePerTurnInfo null: " + this);
                    }
                }
            }
        }

        public TimePerTurnInfo.Type getTimePerTurnType()
        {
            TimePerTurnInfo.Type ret = TimePerTurnInfo.Type.Limit;
            {
                if (this.timePerTurn.v != null)
                {
                    ret = this.timePerTurn.v.getType();
                }
                else
                {
                    Debug.LogError("timePerTurn null: " + this);
                }
            }
            return ret;
        }

        #endregion

        #region totalTime

        public VP<TotalTimeInfo> totalTime;

        public void requestChangeTotalTimeType(uint userId, int newTotalTimeType)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeTotalTimeType(userId, newTotalTimeType);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is TimeInfoIdentity)
                        {
                            TimeInfoIdentity timeInfoIdentity = dataIdentity as TimeInfoIdentity;
                            timeInfoIdentity.requestChangeTotalTimeType(userId, newTotalTimeType);
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

        public void changeTotalTimeType(uint userId, int newTotalTimeType)
        {
            // Process
            if (GameManager.Match.ContestManagerStateLobby.IsCanChange(this, userId))
            {
                TotalTimeInfo.Type type = (TotalTimeInfo.Type)newTotalTimeType;
                // need make new?
                bool needMakeNew = true;
                {
                    if (this.timePerTurn.v != null)
                    {
                        if (type == this.totalTime.v.getType())
                        {
                            needMakeNew = false;
                        }
                    }
                    else
                    {
                        Debug.LogError("timePerTurn null: " + this);
                    }
                }
                // Process
                if (needMakeNew)
                {
                    TotalTimeInfo totalTimeInfo = null;
                    {
                        switch (type)
                        {
                            case TotalTimeInfo.Type.Limit:
                                totalTimeInfo = new TotalTimeInfo.Limit();
                                break;
                            case TotalTimeInfo.Type.NoLimit:
                                totalTimeInfo = new TotalTimeInfo.NoLimit();
                                break;
                            default:
                                Debug.LogError("unknown type: " + type + "; " + this);
                                break;
                        }
                    }
                    if (totalTimeInfo != null)
                    {
                        totalTimeInfo.uid = this.totalTime.makeId();
                        this.totalTime.v = totalTimeInfo;
                    }
                    else
                    {
                        Debug.LogError("totalTimeInfo null: " + this);
                    }
                }
            }
        }

        public TotalTimeInfo.Type getTotalTimeType()
        {
            TotalTimeInfo.Type ret = TotalTimeInfo.Type.Limit;
            {
                if (this.totalTime.v != null)
                {
                    ret = this.totalTime.v.getType();
                }
                else
                {
                    Debug.LogError("totalTime null: " + this);
                }
            }
            return ret;
        }

        #endregion

        #region overTimePerTurn

        public VP<TimePerTurnInfo> overTimePerTurn;

        public void requestChangeOverTimePerTurnType(uint userId, int newOverTimePerTurnType)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeOverTimePerTurnType(userId, newOverTimePerTurnType);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is TimeInfoIdentity)
                        {
                            TimeInfoIdentity timeInfoIdentity = dataIdentity as TimeInfoIdentity;
                            timeInfoIdentity.requestChangeOverTimePerTurnType(userId, newOverTimePerTurnType);
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

        public void changeOverTimePerTurnType(uint userId, int newOverTimePerTurnType)
        {
            // Process
            if (GameManager.Match.ContestManagerStateLobby.IsCanChange(this, userId))
            {
                TimePerTurnInfo.Type type = (TimePerTurnInfo.Type)newOverTimePerTurnType;
                // need make new?
                bool needMakeNew = true;
                {
                    if (this.timePerTurn.v != null)
                    {
                        if (type == this.overTimePerTurn.v.getType())
                        {
                            needMakeNew = false;
                        }
                    }
                    else
                    {
                        Debug.LogError("timePerTurn null: " + this);
                    }
                }
                // Process
                if (needMakeNew)
                {
                    TimePerTurnInfo overTimePerTurnInfo = null;
                    {
                        switch (type)
                        {
                            case TimePerTurnInfo.Type.Limit:
                                overTimePerTurnInfo = new TimePerTurnInfo.Limit();
                                break;
                            case TimePerTurnInfo.Type.NoLimit:
                                overTimePerTurnInfo = new TimePerTurnInfo.NoLimit();
                                break;
                            default:
                                Debug.LogError("unknown type: " + type + "; " + this);
                                break;
                        }
                    }
                    if (overTimePerTurnInfo != null)
                    {
                        overTimePerTurnInfo.uid = this.timePerTurn.makeId();
                        this.overTimePerTurn.v = overTimePerTurnInfo;
                    }
                    else
                    {
                        Debug.LogError("overTimePerTurnInfo null: " + this);
                    }
                }
            }
        }

        public TimePerTurnInfo.Type getOverTimePerTurnType()
        {
            TimePerTurnInfo.Type ret = TimePerTurnInfo.Type.Limit;
            {
                if (this.overTimePerTurn.v != null)
                {
                    ret = this.overTimePerTurn.v.getType();
                }
                else
                {
                    Debug.LogError("overTimePerTurn null: " + this);
                }
            }
            return ret;
        }

        #endregion

        #region lagCompensation

        public VP<float> lagCompensation;

        public void requestChangeLagCompensation(uint userId, float newLagCompensation)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeLagCompensation(userId, newLagCompensation);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is TimeInfoIdentity)
                        {
                            TimeInfoIdentity timeInfoIdentity = dataIdentity as TimeInfoIdentity;
                            timeInfoIdentity.requestChangeLagCompensation(userId, newLagCompensation);
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

        public void changeLagCompensation(uint userId, float newLagCompensation)
        {
            // Process
            if (GameManager.Match.ContestManagerStateLobby.IsCanChange(this, userId))
            {
                this.lagCompensation.v = newLagCompensation;
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            timePerTurn,
            totalTime,
            overTimePerTurn,
            lagCompensation
        }

        public TimeInfo() : base()
        {
            // timePerTime
            {
                TimePerTurnInfo.Limit limit = new TimePerTurnInfo.Limit();
                {
                    limit.perTurn.v = TimePerTurnInfo.DefaultPerTurn;
                }
                this.timePerTurn = new VP<TimePerTurnInfo>(this, (byte)Property.timePerTurn, limit);
            }
            // totalTime
            {
                /*TotalTimeInfo.Limit limit = new TotalTimeInfo.Limit ();
				{
					limit.totalTime.v = TotalTimeInfo.DefaultTotalTime;
				}*/
                this.totalTime = new VP<TotalTimeInfo>(this, (byte)Property.totalTime, new TotalTimeInfo.NoLimit());
            }
            // overTimePerTurn
            {
                TimePerTurnInfo.Limit limit = new TimePerTurnInfo.Limit();
                {
                    limit.perTurn.v = TimePerTurnInfo.DefaultPerTurn / 2;
                }
                this.overTimePerTurn = new VP<TimePerTurnInfo>(this, (byte)Property.overTimePerTurn, limit);
            }
            this.lagCompensation = new VP<float>(this, (byte)Property.lagCompensation, 60f);
        }

        #endregion

    }
}
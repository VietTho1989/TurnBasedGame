using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TimeControl.Normal;
using TimeControl.HourGlass;

namespace TimeControl
{
    public class TimeControl : Data
    {

        #region isEnable

        public VP<bool> isEnable;

        public void requestChangeIsEnable(uint userId, bool newIsEnable)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeIsEnable(userId, newIsEnable);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is TimeControlIdentity)
                        {
                            TimeControlIdentity timeControlIdentity = dataIdentity as TimeControlIdentity;
                            timeControlIdentity.requestChangeIsEnable(userId, newIsEnable);
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
                Debug.LogError("You cannot request: " + this);
            }
        }

        public void changeIsEnable(uint userId, bool newIsEnable)
        {
            if (GameManager.Match.ContestManagerStateLobby.IsCanChange(this, userId))
            {
                this.isEnable.v = newIsEnable;
            }
            else
            {
                Debug.LogError("cannot request: " + userId + "; " + this);
            }
        }

        #endregion

        #region aiCanTimeOut

        public VP<bool> aiCanTimeOut;

        public void requestChangeAICanTimeOut(uint userId, bool newAICanTimeOut)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeAICanTimeOut(userId, newAICanTimeOut);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is TimeControlIdentity)
                        {
                            TimeControlIdentity timeControlIdentity = dataIdentity as TimeControlIdentity;
                            timeControlIdentity.requestChangeAICanTimeOut(userId, newAICanTimeOut);
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
                Debug.LogError("You cannot request: " + this);
            }
        }

        public void changeAICanTimeOut(uint userId, bool newAICanTimeOut)
        {
            if (GameManager.Match.ContestManagerStateLobby.IsCanChange(this, userId))
            {
                this.aiCanTimeOut.v = newAICanTimeOut;
            }
            else
            {
                Debug.LogError("cannot request: " + userId + "; " + this);
            }
        }

        #endregion

        public LP<int> timeOutPlayers;

        #region Sub

        public abstract class Sub : Data
        {

            public enum Type
            {
                Normal,
                HourGlass
            }

            public abstract Type getType();

        }

        public VP<Sub> sub;

        public void requestChangeSubType(uint userId, int newSubType)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeSubType(userId, newSubType);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is TimeControlIdentity)
                        {
                            TimeControlIdentity timeControlIdentity = dataIdentity as TimeControlIdentity;
                            timeControlIdentity.requestChangeSubType(userId, newSubType);
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
                Debug.LogError("You cannot request: " + this);
            }
        }

        public void changeSubType(uint userId, int newSubType)
        {
            if (GameManager.Match.ContestManagerStateLobby.IsCanChange(this, userId))
            {
                Sub.Type type = (Sub.Type)newSubType;
                // check need new
                bool needNew = true;
                {
                    if (this.sub.v != null)
                    {
                        if (this.sub.v.getType() == type)
                        {
                            needNew = false;
                        }
                    }
                    else
                    {
                        Debug.LogError("sub null: " + this);
                    }
                }
                if (needNew)
                {
                    Sub sub = null;
                    {
                        switch (type)
                        {
                            case Sub.Type.Normal:
                                sub = new TimeControlNormal();
                                break;
                            case Sub.Type.HourGlass:
                                sub = new TimeControlHourGlass();
                                break;
                            default:
                                Debug.LogError("unknown type: " + type + "; " + this);
                                break;
                        }
                    }
                    if (sub != null)
                    {
                        sub.uid = this.sub.makeId();
                        this.sub.v = sub;
                    }
                    else
                    {
                        Debug.LogError("sub null: " + this);
                    }
                }
            }
            else
            {
                Debug.LogError("cannot request: " + userId + "; " + this);
            }
        }

        public Sub.Type getSubType()
        {
            Sub.Type ret = Sub.Type.Normal;
            {
                if (this.sub.v != null)
                {
                    ret = this.sub.v.getType();
                }
            }
            return ret;
        }

        #endregion

        #region Report

        #region use

        public enum Use
        {
            ServerTime,
            ClientTime
        }

        public VP<Use> use;

        public void requestChangeUse(uint userId, int newUse)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeUse(userId, newUse);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is TimeControlIdentity)
                        {
                            TimeControlIdentity timeControlIdentity = dataIdentity as TimeControlIdentity;
                            timeControlIdentity.requestChangeUse(userId, newUse);
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
                Debug.LogError("You cannot request: " + this);
            }
        }

        public void changeUse(uint userId, int newUse)
        {
            if (GameManager.Match.ContestManagerStateLobby.IsCanChange(this, userId))
            {
                this.use.v = (Use)newUse;
            }
            else
            {
                Debug.LogError("cannot request: " + userId + "; " + this);
            }
        }

        #endregion

        public VP<TimeReport> timeReport;

        #endregion

        #region Constructor

        public enum Property
        {
            isEnable,
            aiCanTimeOut,
            timeOutPlayers,
            sub,
            use,
            timeReport
        }

        public TimeControl() : base()
        {
            {
                this.isEnable = new VP<bool>(this, (byte)Property.isEnable, true);
                this.isEnable.nh = 0;
            }
            {
                this.aiCanTimeOut = new VP<bool>(this, (byte)Property.aiCanTimeOut, false);
                this.aiCanTimeOut.nh = 0;
            }
            {
                this.timeOutPlayers = new LP<int>(this, (byte)Property.timeOutPlayers);
                this.timeOutPlayers.nh = 0;
            }
            {
                this.sub = new VP<Sub>(this, (byte)Property.sub, new TimeControlNormal());
            }
            {
                this.use = new VP<Use>(this, (byte)Property.use, Use.ClientTime);
                this.use.nh = 0;
            }
            {
                this.timeReport = new VP<TimeReport>(this, (byte)Property.timeReport, null);
                this.timeReport.nh = 0;
            }
        }

        #endregion

    }
}
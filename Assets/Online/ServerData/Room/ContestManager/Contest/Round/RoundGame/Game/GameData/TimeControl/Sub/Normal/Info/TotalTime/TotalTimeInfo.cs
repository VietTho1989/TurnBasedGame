using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
    public abstract class TotalTimeInfo : Data
    {

        public const float DefaultTotalTime = 60 * 60f;

        public enum Type
        {
            Limit,
            NoLimit
        }

        #region txt

        private static readonly TxtLanguage txtLimit = new TxtLanguage("Have Limit");
        private static readonly TxtLanguage txtNoLimit = new TxtLanguage("No Limit");

        static TotalTimeInfo()
        {
            txtLimit.add(Language.Type.vi, "Có Giới Hạn");
            txtNoLimit.add(Language.Type.vi, "Không Giới Hạn");
        }

        public static List<string> getStrTypes()
        {
            List<string> ret = new List<string>();
            {
                ret.Add(txtLimit.get());
                ret.Add(txtNoLimit.get());
            }
            return ret;
        }

        #endregion

        public abstract Type getType();

        public abstract bool isOverTime(float time);

        #region Limit

        public class Limit : TotalTimeInfo
        {

            #region totalTime

            /** seconds*/
            public VP<float> totalTime;

            public void requestChangeTotalTime(uint userId, float newTotalTime)
            {
                Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
                if (needRequest.canRequest)
                {
                    if (!needRequest.needIdentity)
                    {
                        this.changeTotalTime(userId, newTotalTime);
                    }
                    else
                    {
                        DataIdentity dataIdentity = null;
                        if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                        {
                            if (dataIdentity is TotalTimeInfoLimitIdentity)
                            {
                                TotalTimeInfoLimitIdentity totalTimeInfoLimitIdentity = dataIdentity as TotalTimeInfoLimitIdentity;
                                totalTimeInfoLimitIdentity.requestChangeTotalTime(userId, newTotalTime);
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

            public void changeTotalTime(uint userId, float newTotalTime)
            {
                // Process
                if (GameManager.Match.ContestManagerStateLobby.IsCanChange(this, userId))
                {
                    this.totalTime.v = newTotalTime;
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                totalTime
            }

            public Limit() : base()
            {
                this.totalTime = new VP<float>(this, (byte)Property.totalTime, DefaultTotalTime);
            }

            #endregion

            public override Type getType()
            {
                return Type.Limit;
            }

            public override bool isOverTime(float time)
            {
                return time >= this.totalTime.v;
            }

        }

        #endregion

        #region NoLimit

        public class NoLimit : TotalTimeInfo
        {

            #region Constructor

            public enum Property
            {

            }

            public NoLimit() : base()
            {

            }

            #endregion

            public override Type getType()
            {
                return Type.NoLimit;
            }

            public override bool isOverTime(float time)
            {
                return false;
            }

        }

        #endregion

    }
}
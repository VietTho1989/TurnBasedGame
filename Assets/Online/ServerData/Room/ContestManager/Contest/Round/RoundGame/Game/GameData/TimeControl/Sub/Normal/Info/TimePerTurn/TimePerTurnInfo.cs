using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
    public abstract class TimePerTurnInfo : Data
    {

        public const float DefaultPerTurn = 120f;
        // public const float DefaultPerTurn = 30f;

        public enum Type
        {
            Limit,
            NoLimit
        }

        #region txt

        private static readonly TxtLanguage txtLimit = new TxtLanguage("Have Limit");
        private static readonly TxtLanguage txtNoLimit = new TxtLanguage("No Limit");

        static TimePerTurnInfo()
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

        public class Limit : TimePerTurnInfo
        {

            #region perTurn

            /** second*/
            public VP<float> perTurn;

            public void requestChangePerTurn(uint userId, float newPerTurn)
            {
                Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
                if (needRequest.canRequest)
                {
                    if (!needRequest.needIdentity)
                    {
                        this.changePerTurn(userId, newPerTurn);
                    }
                    else
                    {
                        DataIdentity dataIdentity = null;
                        if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                        {
                            if (dataIdentity is TimePerTurnInfoLimitIdentity)
                            {
                                TimePerTurnInfoLimitIdentity timePerTurnInfoLimitIdentity = dataIdentity as TimePerTurnInfoLimitIdentity;
                                timePerTurnInfoLimitIdentity.requestChangePerTurn(userId, newPerTurn);
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

            public void changePerTurn(uint userId, float newPerTurn)
            {
                // Process
                if (GameManager.Match.ContestManagerStateLobby.IsCanChange(this, userId))
                {
                    this.perTurn.v = newPerTurn;
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                perTurn
            }

            public Limit() : base()
            {
                this.perTurn = new VP<float>(this, (byte)Property.perTurn, DefaultPerTurn);
            }

            #endregion

            public override Type getType()
            {
                return Type.Limit;
            }

            public override bool isOverTime(float time)
            {
                return time >= this.perTurn.v;
            }

        }

        #endregion

        #region NoLimt

        public class NoLimit : TimePerTurnInfo
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
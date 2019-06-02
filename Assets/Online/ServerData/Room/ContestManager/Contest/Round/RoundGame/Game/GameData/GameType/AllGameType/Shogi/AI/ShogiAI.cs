using UnityEngine;
using System.Collections;

namespace Shogi
{
    public class ShogiAI : Computer.AI
    {

        #region Property

        #region depth

        public VP<int> depth;

        public void requestChangeDepth(uint userId, int newDepth)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeDepth(userId, newDepth);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is ShogiAIIdentity)
                        {
                            ShogiAIIdentity shogiAIIdentity = dataIdentity as ShogiAIIdentity;
                            shogiAIIdentity.requestChangeDepth(userId, newDepth);
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

        public void changeDepth(uint userId, int newDepth)
        {
            if (isCanRequest(userId))
            {
                this.depth.v = newDepth;
            }
            else
            {
                Debug.LogError("cannot request: " + userId + "; " + this);
            }
        }

        #endregion

        #region skillLevel

        public VP<int> skillLevel;

        public void requestChangeSkillLevel(uint userId, int newSkillLevel)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeSkillLevel(userId, newSkillLevel);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is ShogiAIIdentity)
                        {
                            ShogiAIIdentity shogiAIIdentity = dataIdentity as ShogiAIIdentity;
                            shogiAIIdentity.requestChangeSkillLevel(userId, newSkillLevel);
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

        public void changeSkillLevel(uint userId, int newSkillLevel)
        {
            if (isCanRequest(userId))
            {
                this.skillLevel.v = newSkillLevel;
            }
            else
            {
                Debug.LogError("cannot request: " + userId + "; " + this);
            }
        }

        #endregion

        #region mr

        /** max_random_score_diff*/
        public VP<int> mr;

        public void requestChangeMr(uint userId, int newMr)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeMr(userId, newMr);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is ShogiAIIdentity)
                        {
                            ShogiAIIdentity shogiAIIdentity = dataIdentity as ShogiAIIdentity;
                            shogiAIIdentity.requestChangeMr(userId, newMr);
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

        public void changeMr(uint userId, int newMr)
        {
            if (isCanRequest(userId))
            {
                this.mr.v = newMr;
            }
            else
            {
                Debug.LogError("cannot request: " + userId + "; " + this);
            }
        }

        #endregion

        #region duration

        public VP<int> duration;

        public void requestChangeDuration(uint userId, int newDuration)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeDuration(userId, newDuration);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is ShogiAIIdentity)
                        {
                            ShogiAIIdentity shogiAIIdentity = dataIdentity as ShogiAIIdentity;
                            shogiAIIdentity.requestChangeDuration(userId, newDuration);
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

        public void changeDuration(uint userId, int newDuration)
        {
            if (isCanRequest(userId))
            {
                this.duration.v = newDuration;
            }
            else
            {
                Debug.LogError("cannot request: " + userId + "; " + this);
            }
        }

        #endregion

        #region useBook

        public VP<bool> useBook;

        public void requestChangeUseBook(uint userId, bool newUseBook)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeUseBook(userId, newUseBook);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is ShogiAIIdentity)
                        {
                            ShogiAIIdentity shogiAIIdentity = dataIdentity as ShogiAIIdentity;
                            shogiAIIdentity.requestChangeUseBook(userId, newUseBook);
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

        public void changeUseBook(uint userId, bool newUseBook)
        {
            if (isCanRequest(userId))
            {
                this.useBook.v = newUseBook;
            }
            else
            {
                Debug.LogError("cannot request: " + userId + "; " + this);
            }
        }

        #endregion

        #endregion

        #region Constructor

        public enum Property
        {
            depth,
            skillLevel,
            mr,
            duration,
            useBook
        }

        public ShogiAI() : base()
        {
            this.depth = new VP<int>(this, (byte)Property.depth, 19);
            this.skillLevel = new VP<int>(this, (byte)Property.skillLevel, 18);
            this.mr = new VP<int>(this, (byte)Property.mr, 0);
            this.duration = new VP<int>(this, (byte)Property.duration, 5000);
            this.useBook = new VP<bool>(this, (byte)Property.useBook, true);
        }

        #endregion

        public override GameType.Type getType()
        {
            return GameType.Type.SHOGI;
        }

    }
}
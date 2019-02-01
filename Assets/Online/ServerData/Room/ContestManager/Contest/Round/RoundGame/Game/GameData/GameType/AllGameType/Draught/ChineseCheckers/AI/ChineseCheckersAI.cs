using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChineseCheckers
{
    public class ChineseCheckersAI : Computer.AI
    {

        #region type

        public enum Type
        {
            Depth,
            Time,
            Node
        }

        public VP<Type> type;

        public void requestChangeType(uint userId, Type newType)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeType(userId, newType);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is ChineseCheckersAIIdentity)
                        {
                            ChineseCheckersAIIdentity chineseCheckersAIIdentity = dataIdentity as ChineseCheckersAIIdentity;
                            chineseCheckersAIIdentity.requestChangeType(userId, newType);
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

        public void changeType(uint userId, Type newType)
        {
            if (isCanRequest(userId))
            {
                this.type.v = newType;
            }
            else
            {
                Debug.LogError("cannot request: " + userId + "; " + this);
            }
        }

        #endregion

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
                        if (dataIdentity is ChineseCheckersAIIdentity)
                        {
                            ChineseCheckersAIIdentity chineseCheckersAIIdentity = dataIdentity as ChineseCheckersAIIdentity;
                            chineseCheckersAIIdentity.requestChangeDepth(userId, newDepth);
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

        #region time

        public VP<int> time;

        public void requestChangeTime(uint userId, int newTime)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeTime(userId, newTime);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is ChineseCheckersAIIdentity)
                        {
                            ChineseCheckersAIIdentity chineseCheckersAIIdentity = dataIdentity as ChineseCheckersAIIdentity;
                            chineseCheckersAIIdentity.requestChangeTime(userId, newTime);
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

        public void changeTime(uint userId, int newTime)
        {
            if (isCanRequest(userId))
            {
                this.time.v = newTime;
            }
            else
            {
                Debug.LogError("cannot request: " + userId + "; " + this);
            }
        }

        #endregion

        #region node

        public VP<int> node;

        public void requestChangeNode(uint userId, int newNode)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeNode(userId, newNode);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is ChineseCheckersAIIdentity)
                        {
                            ChineseCheckersAIIdentity chineseCheckersAIIdentity = dataIdentity as ChineseCheckersAIIdentity;
                            chineseCheckersAIIdentity.requestChangeNode(userId, newNode);
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

        public void changeNode(uint userId, int newNode)
        {
            if (isCanRequest(userId))
            {
                this.node.v = newNode;
            }
            else
            {
                Debug.LogError("cannot request: " + userId + "; " + this);
            }
        }

        #endregion

        #region pickBestMove

        public VP<int> pickBestMove;

        public void requestChangePickBestMove(uint userId, int newPickBestMove)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changePickBestMove(userId, newPickBestMove);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is ChineseCheckersAIIdentity)
                        {
                            ChineseCheckersAIIdentity chineseCheckersAIIdentity = dataIdentity as ChineseCheckersAIIdentity;
                            chineseCheckersAIIdentity.requestChangePickBestMove(userId, newPickBestMove);
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

        public void changePickBestMove(uint userId, int newPickBestMove)
        {
            if (isCanRequest(userId))
            {
                this.pickBestMove.v = newPickBestMove;
            }
            else
            {
                Debug.LogError("cannot request: " + userId + "; " + this);
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            type,
            depth,
            time,
            node,
            pickBestMove
        }

        public ChineseCheckersAI() : base()
        {
            this.type = new VP<Type>(this, (byte)Property.type, Type.Time);
            this.depth = new VP<int>(this, (byte)Property.depth, 5);
            this.time = new VP<int>(this, (byte)Property.time, 5000);
            this.node = new VP<int>(this, (byte)Property.node, 1000);
            this.pickBestMove = new VP<int>(this, (byte)Property.pickBestMove, 90);
        }

        #endregion

        public override GameType.Type getType()
        {
            return GameType.Type.ChineseCheckers;
        }

    }
}
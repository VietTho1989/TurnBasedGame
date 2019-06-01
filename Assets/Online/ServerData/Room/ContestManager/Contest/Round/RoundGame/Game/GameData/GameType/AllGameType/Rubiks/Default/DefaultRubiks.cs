using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Rubiks
{
    public class DefaultRubiks : DefaultGameType
    {

        #region dimension

        public VP<int> dimension;

        public void requestChangeDimension(uint userId, int newDimension)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeDimension(userId, newDimension);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        // TODO Can hoan thien
                        /*if (dataIdentity is DefaultRubiksIdentity)
                        {
                            DefaultRubiksIdentity defaultRubiksIdentity = dataIdentity as DefaultRubiksIdentity;
                            defaultRubiksIdentity.requestChangeDimension(userId, newDimension);
                        }
                        else
                        {
                            Debug.LogError("Why isn't correct identity");
                        }*/
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

        public void changeDimension(uint userId, int newDimension)
        {
            if (GameManager.Match.ContestManagerStateLobby.IsCanChange(this, userId))
            {
                this.dimension.v = newDimension;
            }
            else
            {
                Debug.LogError("cannot change config: " + this);
            }
        }

        #endregion

        #region scrambleCount

        public const int MinScrambleCount = 0;
        public const int MaxScrambleCount = 10000;
        public VP<int> scrambleCount;

        public void requestChangeScrambleCount(uint userId, int newScrambleCount)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeScrambleCount(userId, newScrambleCount);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        // TODO Can hoan thien
                        /*if (dataIdentity is DefaultRubiksIdentity)
                        {
                            DefaultRubiksIdentity defaultRubiksIdentity = dataIdentity as DefaultRubiksIdentity;
                            defaultRubiksIdentity.requestChangeScrambleCount(userId, newScrambleCount);
                        }
                        else
                        {
                            Debug.LogError("Why isn't correct identity");
                        }*/
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

        public void changeScrambleCount(uint userId, int newScrambleCount)
        {
            if (GameManager.Match.ContestManagerStateLobby.IsCanChange(this, userId))
            {
                this.scrambleCount.v = newScrambleCount;
            }
            else
            {
                Debug.LogError("cannot change config: " + this);
            }
        }

        #endregion

        #region canFinish

        public VP<bool> canFinish;

        public void requestChangeCanFinish(uint userId, bool newCanFinish)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeCanFinish(userId, newCanFinish);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        // TODO Can hoan thien
                        /*if (dataIdentity is DefaultRubiksIdentity)
                        {
                            DefaultRubiksIdentity defaultRubiksIdentity = dataIdentity as DefaultRubiksIdentity;
                            defaultRubiksIdentity.requestChangeCanFinish(userId, newCanFinish);
                        }
                        else
                        {
                            Debug.LogError("Why isn't correct identity");
                        }*/
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

        public void changeCanFinish(uint userId, bool newCanFinish)
        {
            if (GameManager.Match.ContestManagerStateLobby.IsCanChange(this, userId))
            {
                this.canFinish.v = newCanFinish;
            }
            else
            {
                Debug.LogError("cannot change config: " + this);
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            dimension,
            scrambleCount,
            canFinish
        }

        public DefaultRubiks() : base()
        {
            this.dimension = new VP<int>(this, (byte)Property.dimension, 3);
            this.scrambleCount = new VP<int>(this, (byte)Property.scrambleCount, 0);
            this.canFinish = new VP<bool>(this, (byte)Property.canFinish, true);
        }

        #endregion

        #region implement base

        public override GameType.Type getType()
        {
            return GameType.Type.Rubiks;
        }

        public override GameType makeDefaultGameType()
        {
            int dimension = Mathf.Clamp(this.dimension.v, Rubiks.MinDimension, Rubiks.MaxDimension);
            Cubenxn cube = new Cubenxn(dimension);
            {
                int scrambleCount = this.scrambleCount.v;
                {
                    if (scrambleCount < 0)
                    {
                        scrambleCount = dimension * dimension;
                    }
                    else
                    {
                        scrambleCount = Mathf.Clamp(scrambleCount, MinScrambleCount, MaxScrambleCount);
                    }
                }
                cube.scrambleNxN(scrambleCount);
            }
            Rubiks rubiks = Rubiks.parseCube(cube);
            {
                rubiks.canFinish.v = this.canFinish.v;
            }
            return rubiks;
        }

        #endregion

    }
}
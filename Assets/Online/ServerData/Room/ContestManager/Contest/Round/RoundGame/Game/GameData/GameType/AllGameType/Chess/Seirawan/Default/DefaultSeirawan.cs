using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seirawan
{
    public class DefaultSeirawan : DefaultGameType
    {

        #region Chess960

        public VP<bool> chess960;

        public void requestChangeChess960(uint userId, bool newChess960)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeChess960(userId, newChess960);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is DefaultSeirawanIdentity)
                        {
                            DefaultSeirawanIdentity defaultSeirawanIdentity = dataIdentity as DefaultSeirawanIdentity;
                            defaultSeirawanIdentity.requestChangeChess960(userId, newChess960);
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

        public void changeChess960(uint userId, bool newChess960)
        {
            if (GameManager.Match.ContestManagerStateLobby.IsCanChange(this, userId))
            {
                this.chess960.v = newChess960;
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
            chess960
        }

        public DefaultSeirawan() : base()
        {
            this.chess960 = new VP<bool>(this, (byte)Property.chess960, false);
        }

        #endregion

        public override GameType.Type getType()
        {
            return GameType.Type.Seirawan;
        }

        public override GameType makeDefaultGameType()
        {
            string strFen = Seirawan.DefaultFen;
            {
                if (this.chess960.v)
                {
                    string rank = Chess.Chess960.generateFirstRank();
                    strFen = rank.ToLower() + "/pppppppp/8/8/8/8/PPPPPPPP/" + rank + "[HEhe] w KQBCDFGkqbcdfg - 0 1";
                }
            }
            Seirawan newSeirawan = Core.unityMakePositionByFen(strFen, this.chess960.v);
            return newSeirawan;
        }
    }

}
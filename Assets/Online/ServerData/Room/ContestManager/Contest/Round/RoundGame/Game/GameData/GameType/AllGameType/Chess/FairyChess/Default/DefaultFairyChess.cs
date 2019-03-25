using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FairyChess
{
    public class DefaultFairyChess : DefaultGameType
    {

        #region VariantType

        public VP<Common.VariantType> variantType;

        public void requestChangeVariantType(uint userId, Common.VariantType newVariantType)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeVariantType(userId, newVariantType);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is DefaultFairyChessIdentity)
                        {
                            DefaultFairyChessIdentity defaultFairyChessIdentity = dataIdentity as DefaultFairyChessIdentity;
                            defaultFairyChessIdentity.requestChangeVariantType(userId, newVariantType);
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

        public void changeVariantType(uint userId, Common.VariantType newVariantType)
        {
            if (GameManager.Match.ContestManagerStateLobby.IsCanChange(this, userId))
            {
                this.variantType.v = newVariantType;
            }
            else
            {
                Debug.LogError("cannot change config: " + this);
            }
        }

        #endregion

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
                        if (dataIdentity is DefaultFairyChessIdentity)
                        {
                            DefaultFairyChessIdentity defaultFairyChessIdentity = dataIdentity as DefaultFairyChessIdentity;
                            defaultFairyChessIdentity.requestChangeChess960(userId, newChess960);
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
            variantType,
            chess960
        }

        public DefaultFairyChess() : base()
        {
            this.variantType = new VP<Common.VariantType>(this, (byte)Property.variantType, Common.VariantType.asean);
            this.chess960 = new VP<bool>(this, (byte)Property.chess960, false);
        }

        #endregion

        public override GameType.Type getType()
        {
            return GameType.Type.FairyChess;
        }

        public override GameType makeDefaultGameType()
        {
            string strFen = VariantMap.GetStartFen(this.variantType.v);
            {
                /*if (this.chess960.v) {
					string rank = Chess960.generateFirstRank ();
					strFen = rank.ToLower () + "/pppppppp/8/8/8/8/PPPPPPPP/" + rank + " w KQkq - 0 1";
				}*/
            }
            FairyChess newFairyChess = Core.unityMakePositionByFen(this.variantType.v, strFen, this.chess960.v);
            return newFairyChess;
        }
    }

}
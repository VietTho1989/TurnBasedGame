using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HEX
{
    public class DefaultHex : DefaultGameType
    {

        #region boardSize

        public VP<System.UInt16> boardSize;

        public void requestChangeBoardSize(uint userId, System.UInt16 newBoardSize)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeBoardSize(userId, newBoardSize);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is DefaultHexIdentity)
                        {
                            DefaultHexIdentity defaultHexIdentity = dataIdentity as DefaultHexIdentity;
                            defaultHexIdentity.requestChangeBoardSize(userId, newBoardSize);
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

        public void changeBoardSize(uint userId, System.UInt16 newBoardSize)
        {
            if (GameManager.Match.ContestManagerStateLobby.IsCanChange(this, userId))
            {
                this.boardSize.v = newBoardSize;
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
            boardSize
        }

        public DefaultHex() : base()
        {
            this.boardSize = new VP<ushort>(this, (byte)Property.boardSize, 11);
        }

        #endregion

        #region implement base

        public override GameType.Type getType()
        {
            return GameType.Type.Hex;
        }

        public override GameType makeDefaultGameType()
        {
            Hex hex = Core.unityMakeDefaultPosition(this.boardSize.v);
            return hex;
        }

        #endregion

    }
}
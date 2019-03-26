using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Gomoku
{
    public class DefaultGomoku : DefaultGameType
    {
        #region BoardSize

        public VP<int> boardSize;

        public void requestChangeBoardSize(uint userId, int newBoardSize)
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
                        if (dataIdentity is DefaultGomokuIdentity)
                        {
                            DefaultGomokuIdentity defaultGomokuIdentity = dataIdentity as DefaultGomokuIdentity;
                            defaultGomokuIdentity.requestChangeBoardSize(userId, newBoardSize);
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

        public void changeBoardSize(uint userId, int newBoardSize)
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

        public DefaultGomoku() : base()
        {
            this.boardSize = new VP<int>(this, (byte)Property.boardSize, 19);
        }

        #endregion

        public override GameType.Type getType()
        {
            return GameType.Type.Gomoku;
        }

        public override GameType makeDefaultGameType()
        {
            int size = Mathf.Clamp(this.boardSize.v, Gomoku.MinBoardSize, Gomoku.MaxBoardSize);
            Gomoku startGomoku = Core.unityMakeDefaultPosition(size);
            return startGomoku;
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostureGameDataFactory : GameDataFactory
{
    #region GameData

    public VP<GameData> gameData;

    #region Change GameData

    public void requestChangeGameData(uint userId, GameData newGameData)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.changeGameData(userId, newGameData);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is PostureGameDataFactoryIdentity)
                    {
                        PostureGameDataFactoryIdentity postureGameDataFactoryIdentity = dataIdentity as PostureGameDataFactoryIdentity;
                        postureGameDataFactoryIdentity.requestChangeGameData(userId, newGameData);
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

    public void changeGameData(uint userId, GameData newGameData)
    {
        if (GameManager.Match.ContestManagerStateLobby.IsCanChange(this, userId))
        {
            GameData newData = DataUtils.cloneData(newGameData) as GameData;
            {
                newData.uid = this.gameData.makeId();
            }
            this.gameData.v = newData;
        }
        else
        {
            Debug.LogError("Cannot change: " + userId + ", " + newGameData);
        }
    }

    #endregion

    #region Change GameType

    public void requestChangeGameType(uint userId, GameType.Type newGameType)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.changeGameType(userId, newGameType);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is PostureGameDataFactoryIdentity)
                    {
                        PostureGameDataFactoryIdentity postureGameDataFactoryIdentity = dataIdentity as PostureGameDataFactoryIdentity;
                        postureGameDataFactoryIdentity.requestChangeType(userId, newGameType);
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
        // DefaultChosenGame
        Setting.get().defaultChosenGame.v.setLast(newGameType);
    }

    public void changeGameType(uint userId, GameType.Type newGameType)
    {
        if (GameManager.Match.ContestManagerStateLobby.IsCanChange(this, userId))
        {
            if (newGameType != this.gameData.v.gameType.v.getType())
            {
                GameData gameData = new GameData();
                {
                    gameData.uid = this.gameData.makeId();
                    gameData.gameType.v = GameType.makeDefaultGameType(newGameType);
                }
                this.gameData.v = gameData;
            }
            else
            {
                Debug.LogError("the same old gameType: " + newGameType);
            }
        }
        else
        {
            Debug.LogError("Cannot change: " + userId + ", " + newGameType);
        }
    }

    #endregion

    public override GameType.Type getGameTypeType()
    {
        GameType.Type ret = GameType.Type.Xiangqi;
        {
            GameData gameData = this.gameData.v;
            if (gameData != null)
            {
                GameType gameType = gameData.gameType.v;
                if (gameType != null)
                {
                    ret = gameType.getType();
                }
                else
                {
                    Debug.LogError("gameType null: " + this);
                }
            }
            else
            {
                Debug.LogError("gameData null: " + this);
            }
        }
        return ret;
    }

    #endregion

    #region Constructor

    public enum Property
    {
        gameData
    }

    public PostureGameDataFactory() : base()
    {
        this.gameData = new VP<GameData>(this, (byte)Property.gameData, new GameData());
    }

    #endregion

    public override Type getType()
    {
        return Type.Posture;
    }

    public override void initGameData(GameData gameData)
    {
        DataUtils.copyData(gameData, this.gameData.v);
        {
            // gameType
            // useRule
            // turn
            {
                Turn turn = new Turn();
                {
                    turn.uid = gameData.turn.makeId();
                }
                gameData.turn.v = turn;
            }
            // pieces
            // lastMove
            {
                LastMove lastMove = new LastMove();
                {
                    lastMove.uid = gameData.lastMove.makeId();
                }
                gameData.lastMove.v = lastMove;
            }
            // state
            // playerResults
        }
    }

}
using UnityEngine;
using System.Collections;

public class GameFactory : Data
{

    public VP<TimeControl.TimeControl> timeControl;

    #region GameDataFactory

    public VP<GameDataFactory> gameDataFactory;

    public void requestChangeGameDataFactoryType(uint userId, GameDataFactory.Type newType)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.changeGameDataFactoryType(userId, newType);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is GameFactoryIdentity)
                    {
                        GameFactoryIdentity gameFactoryIdentity = dataIdentity as GameFactoryIdentity;
                        gameFactoryIdentity.requestChangeGameDataFactoryType(userId, newType);
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

    public void changeGameDataFactoryType(uint userId, GameDataFactory.Type newType)
    {
        if (GameManager.Match.ContestManagerStateLobby.IsCanChange(this, userId))
        {
            if (this.gameDataFactory.v.getType() != newType)
            {
                switch (newType)
                {
                    case GameDataFactory.Type.Default:
                        {
                            DefaultGameDataFactory defaultGameDataFactory = new DefaultGameDataFactory();
                            {
                                defaultGameDataFactory.uid = this.gameDataFactory.makeId();
                                // DefaultGameType
                                {
                                    GameType.Type postureGameType = GameType.Type.Xiangqi;
                                    {
                                        if (this.gameDataFactory.v is PostureGameDataFactory)
                                        {
                                            PostureGameDataFactory postureGameDataFactory = this.gameDataFactory.v as PostureGameDataFactory;
                                            // Get GameData
                                            GameData gameData = postureGameDataFactory.gameData.v;
                                            if (gameData != null)
                                            {
                                                // Get GameType
                                                GameType gameType = gameData.gameType.v;
                                                if (gameType != null)
                                                {
                                                    // get GameType Type
                                                    postureGameType = gameType.getType();
                                                }
                                                else
                                                {
                                                    Debug.LogError("postureGameDataFactory: gameType null: " + this);
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("postureGameDataFactory: gameData null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("why not postureGameDataFactory: " + this);
                                        }
                                    }
                                    defaultGameDataFactory.makeNewDefaultGameType(postureGameType);
                                }
                            }
                            this.gameDataFactory.v = defaultGameDataFactory;
                        }
                        break;
                    case GameDataFactory.Type.Posture:
                        {
                            PostureGameDataFactory postureGameDataFactory = new PostureGameDataFactory();
                            {
                                postureGameDataFactory.uid = this.gameDataFactory.makeId();
                                // GameData
                                {
                                    GameData gameData = new GameData();
                                    {
                                        gameData.uid = postureGameDataFactory.gameData.makeId();
                                        // GameType
                                        {
                                            GameType gameType = null;
                                            {
                                                if (this.gameDataFactory.v is DefaultGameDataFactory)
                                                {
                                                    DefaultGameDataFactory defaultGameDataFactory = this.gameDataFactory.v as DefaultGameDataFactory;
                                                    if (defaultGameDataFactory.defaultGameType.v != null)
                                                    {
                                                        gameType = defaultGameDataFactory.defaultGameType.v.makeDefaultGameType();
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("defaultGameType null: " + this);
                                                    }
                                                }
                                                else
                                                {
                                                    Debug.LogError("why not defaultGameDataFactory: " + this);
                                                }
                                            }
                                            // Check null
                                            if (gameType == null)
                                            {
                                                Xiangqi.DefaultXiangqi defaultXiangqi = new Xiangqi.DefaultXiangqi();
                                                gameType = defaultXiangqi.makeDefaultGameType();
                                            }
                                            // Set
                                            gameData.gameType.v = gameType;
                                        }
                                    }
                                    postureGameDataFactory.gameData.v = gameData;
                                }
                            }
                            this.gameDataFactory.v = postureGameDataFactory;
                        }
                        break;
                    default:
                        Debug.LogError("unknown type: " + newType);
                        break;
                }
            }
            else
            {
                Debug.LogError("Not change type");
            }
        }
        else
        {
            Debug.LogError("Cannot change: " + userId + ", " + newType);
        }
    }

    public GameDataFactory.Type getGameDataFactoryType()
    {
        GameDataFactory.Type ret = GameDataFactory.Type.Default;
        {
            GameDataFactory gameDataFactory = this.gameDataFactory.v;
            if (gameDataFactory != null)
            {
                ret = gameDataFactory.getType();
            }
            else
            {
                Debug.LogError("gameDataFactory null: " + this);
            }
        }
        return ret;
    }

    #endregion

    #region UseRule

    public VP<bool> useRule;

    public void requestChangeUseRule(uint userId, bool newUseRule)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.changeUseRule(userId, newUseRule);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is GameFactoryIdentity)
                    {
                        GameFactoryIdentity gameFactoryIdentity = dataIdentity as GameFactoryIdentity;
                        gameFactoryIdentity.requestChangeUseRule(userId, newUseRule);
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

    public void changeUseRule(uint userId, bool newUseRule)
    {
        // Process
        if (GameManager.Match.ContestManagerStateLobby.IsCanChange(this, userId))
        {
            this.useRule.v = newUseRule;
        }
    }

    #endregion

    #region blindFold

    public VP<bool> blindFold;

    public void requestChangeBlindFold(uint userId, bool newBlindFold)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.changeBlindFold(userId, newBlindFold);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is GameFactoryIdentity)
                    {
                        GameFactoryIdentity gameFactoryIdentity = dataIdentity as GameFactoryIdentity;
                        gameFactoryIdentity.requestChangeBlindFold(userId, newBlindFold);
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

    public void changeBlindFold(uint userId, bool newBlindFold)
    {
        // Process
        if (GameManager.Match.ContestManagerStateLobby.IsCanChange(this, userId))
        {
            this.blindFold.v = newBlindFold;
        }
    }

    #endregion

    #region Constructor

    public enum Property
    {
        timeControl,
        gameDataFactory,
        useRule,
        blindFold
    }

    public GameFactory() : base()
    {
        this.timeControl = new VP<TimeControl.TimeControl>(this, (byte)Property.timeControl, new TimeControl.TimeControl());
        this.gameDataFactory = new VP<GameDataFactory>(this, (byte)Property.gameDataFactory, new DefaultGameDataFactory());
        this.useRule = new VP<bool>(this, (byte)Property.useRule, true);
        this.blindFold = new VP<bool>(this, (byte)Property.blindFold, false);
    }

    #endregion

    public void initGame(Game game)
    {
        if (game != null)
        {
            // GameData
            this.gameDataFactory.v.initGameData(game.gameData.v);
            // TimeControl
            game.gameData.v.timeControl.v = (TimeControl.TimeControl)DataUtils.cloneData(this.timeControl.v);
            // useRule
            game.gameData.v.useRule.v = this.useRule.v;
            // blindFold
            game.gameData.v.blindFold.v = this.blindFold.v;
        }
        else
        {
            Debug.LogError("game null");
        }
    }

}
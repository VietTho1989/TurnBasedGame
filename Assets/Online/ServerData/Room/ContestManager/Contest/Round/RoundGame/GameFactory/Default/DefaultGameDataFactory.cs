using UnityEngine;
using System.Collections;

/**
 * Ve sau se them timeControl o day
 * */
public class DefaultGameDataFactory : GameDataFactory
{

    #region GameType

    public VP<DefaultGameType> defaultGameType;

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
                    if (dataIdentity is DefaultGameDataFactoryIdentity)
                    {
                        DefaultGameDataFactoryIdentity defaultGameDataFactoryIdentity = dataIdentity as DefaultGameDataFactoryIdentity;
                        defaultGameDataFactoryIdentity.requestChangeType(userId, newGameType);
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
            this.makeNewDefaultGameType(newGameType);
        }
        else
        {
            Debug.LogError("Cannot change: " + userId + ", " + newGameType);
        }
    }

    public void makeNewDefaultGameType(GameType.Type newGameType)
    {
        // check need new
        bool needNew = true;
        {
            if (this.defaultGameType.v != null)
            {
                if (this.defaultGameType.v.getType() == newGameType)
                {
                    needNew = false;
                }
            }
        }
        if (needNew)
        {
            DefaultGameType newDefaultGameType = null;
            {
                // init
                switch (newGameType)
                {
                    case GameType.Type.CHESS:
                        newDefaultGameType = new Chess.DefaultChess();
                        break;
                    case GameType.Type.Shatranj:
                        newDefaultGameType = new Shatranj.DefaultShatranj();
                        break;
                    case GameType.Type.Makruk:
                        newDefaultGameType = new Makruk.DefaultMakruk();
                        break;
                    case GameType.Type.Seirawan:
                        newDefaultGameType = new Seirawan.DefaultSeirawan();
                        break;
                    case GameType.Type.FairyChess:
                        newDefaultGameType = new FairyChess.DefaultFairyChess();
                        break;

                    case GameType.Type.Xiangqi:
                        newDefaultGameType = new Xiangqi.DefaultXiangqi();
                        break;
                    case GameType.Type.CO_TUONG_UP:
                        newDefaultGameType = new CoTuongUp.DefaultCoTuongUp();
                        break;
                    case GameType.Type.Janggi:
                        newDefaultGameType = new Janggi.DefaultJanggi();
                        break;
                    case GameType.Type.Banqi:
                        newDefaultGameType = new Banqi.DefaultBanqi();
                        break;

                    case GameType.Type.Weiqi:
                        newDefaultGameType = new Weiqi.DefaultWeiqi();
                        break;
                    case GameType.Type.SHOGI:
                        newDefaultGameType = new Shogi.DefaultShogi();
                        break;
                    case GameType.Type.Reversi:
                        newDefaultGameType = new Reversi.DefaultReversi();
                        break;
                    case GameType.Type.Gomoku:
                        newDefaultGameType = new Gomoku.DefaultGomoku();
                        break;

                    case GameType.Type.EnglishDraught:
                        newDefaultGameType = new EnglishDraught.DefaultEnglishDraught();
                        break;
                    case GameType.Type.InternationalDraught:
                        newDefaultGameType = new InternationalDraught.DefaultInternationalDraught();
                        break;
                    case GameType.Type.RussianDraught:
                        newDefaultGameType = new RussianDraught.DefaultRussianDraught();
                        break;
                    case GameType.Type.ChineseCheckers:
                        newDefaultGameType = new ChineseCheckers.DefaultChineseCheckers();
                        break;

                    case GameType.Type.MineSweeper:
                        newDefaultGameType = new MineSweeper.DefaultMineSweeper();
                        break;
                    case GameType.Type.Hex:
                        newDefaultGameType = new HEX.DefaultHex();
                        break;
                    case GameType.Type.Solitaire:
                        newDefaultGameType = new Solitaire.DefaultSolitaire();
                        break;
                    case GameType.Type.Sudoku:
                        newDefaultGameType = new Sudoku.DefaultSudoku();
                        break;
                    case GameType.Type.Khet:
                        newDefaultGameType = new Khet.DefaultKhet();
                        break;
                    case GameType.Type.NineMenMorris:
                        newDefaultGameType = new NineMenMorris.DefaultNineMenMorris();
                        break;
                    default:
                        Debug.LogError("unknown gameType: " + newGameType + "; " + this);
                        break;
                }
                // check null
                if (newDefaultGameType == null)
                {
                    Debug.LogError("newDefaultGameType null: " + this);
                    newDefaultGameType = new Xiangqi.DefaultXiangqi();
                }
                //uid
                newDefaultGameType.uid = this.defaultGameType.makeId();
            }
            this.defaultGameType.v = newDefaultGameType;
        }
        else
        {
            Debug.LogError("don't need new defaultGameType: " + this);
        }
    }

    public override GameType.Type getGameTypeType()
    {
        GameType.Type ret = GameType.Type.Xiangqi;
        {
            DefaultGameType defaultGameType = this.defaultGameType.v;
            if (defaultGameType != null)
            {
                ret = defaultGameType.getType();
            }
            else
            {
                Debug.LogError("defaultGameType null: " + this);
            }
        }
        return ret;
    }

    #endregion

    #region UserRule

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
                    if (dataIdentity is DefaultGameDataFactoryIdentity)
                    {
                        DefaultGameDataFactoryIdentity defaultGameDataFactoryIdentity = dataIdentity as DefaultGameDataFactoryIdentity;
                        defaultGameDataFactoryIdentity.requestChangeUseRule(userId, newUseRule);
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

    #region Constructor

    public enum Property
    {
        defaultGameType,
        useRule
    }

    public DefaultGameDataFactory() : base()
    {
        this.defaultGameType = new VP<DefaultGameType>(this, (byte)Property.defaultGameType, new Xiangqi.DefaultXiangqi());
        this.useRule = new VP<bool>(this, (byte)Property.useRule, true);
    }

    #endregion

    public override Type getType()
    {
        return GameDataFactory.Type.Default;
    }

    public override void initGameData(GameData gameData)
    {
        gameData.useRule.v = this.useRule.v;
        // gameType
        {
            // find gameType
            GameType newDefaultGameType = null;
            {
                if (this.defaultGameType.v != null)
                {
                    newDefaultGameType = this.defaultGameType.v.makeDefaultGameType();
                }
                else
                {
                    Debug.LogError("defaultGameType null: " + this);
                }
            }
            // check null
            if (newDefaultGameType == null)
            {
                Debug.LogError("newDefaultGameType null: " + this);
                Xiangqi.DefaultXiangqi defaultXiangqi = new Xiangqi.DefaultXiangqi();
                newDefaultGameType = (Xiangqi.Xiangqi)defaultXiangqi.makeDefaultGameType();
            }
            // set
            {
                // check need set
                bool needSet = true;
                {
                    if (gameData.gameType.v != null)
                    {
                        if (gameData.gameType.v.getType() == newDefaultGameType.getType())
                        {
                            needSet = false;
                        }
                    }
                }
                if (needSet)
                {
                    newDefaultGameType.uid = gameData.gameType.makeId();
                    gameData.gameType.v = newDefaultGameType;
                }
                else
                {
                    DataUtils.copyData(gameData.gameType.v, newDefaultGameType);
                }
            }
        }
    }

}
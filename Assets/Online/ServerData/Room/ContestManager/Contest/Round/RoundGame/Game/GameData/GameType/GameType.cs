using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class GameType : Data
{

    // https://www.miniwebtool.com/adler32-checksum-calculator/
    public enum Type
    {
        CHESS = 71041399,
        Shatranj = 238224188,
        Makruk = 135266924,
        Seirawan = 237765435,
        FairyChess = 350356466,

        Weiqi = 97649152,
        SHOGI = 76022139,
        ROCK_SCISSOR_PAPER = 886244748,
        Reversi = 187302625,

        Xiangqi = 184681170,
        CO_TUONG_UP = 350159747,
        Janggi = 130744913,
        Banqi = 90702316,

        Gomoku = 136774259,

        InternationalDraught = 1427310632,
        EnglishDraught = 687932826,
        RussianDraught = 712836533,
        ChineseCheckers = 771360232,

        MineSweeper = 430048357,
        Hex = 35455270,
        Solitaire = 304219053,

        Sudoku = 141099644,
        Khet = 61211021,
        NineMenMorris = 584451367
    }

    #region txt

    private static readonly Dictionary<GameType.Type, TxtLanguage> typeTxtDict = new Dictionary<Type, TxtLanguage>();

    static GameType()
    {
        foreach (GameType.Type gameType in GameType.EnableTypes)
        {
            AllEnableGameTypes.Add(gameType);
        }
        // typeTxtDict
        {
            // CHESS
            {
                TxtLanguage txt = new TxtLanguage("Chess");
                {
                    txt.add(Language.Type.vi, "Cờ Vua");
                }
                typeTxtDict.Add(Type.CHESS, txt);
            }
            // Shatranj
            {
                TxtLanguage txt = new TxtLanguage("Shatranj");
                {
                    txt.add(Language.Type.vi, "Cờ Ba Tư (Shatranj)");
                }
                typeTxtDict.Add(Type.Shatranj, txt);
            }
            // Makruk
            {
                TxtLanguage txt = new TxtLanguage("Makruk");
                {
                    txt.add(Language.Type.vi, "Cờ Thái (Makruk)");
                }
                typeTxtDict.Add(Type.Makruk, txt);
            }
            // Seirawan
            {
                TxtLanguage txt = new TxtLanguage("Seirawan Chess");
                {
                    txt.add(Language.Type.vi, "Cờ Vua Seirawan");
                }
                typeTxtDict.Add(Type.Seirawan, txt);
            }
            // FairyChess
            {
                TxtLanguage txt = new TxtLanguage("Fairy Chess");
                {
                    txt.add(Language.Type.vi, "Các Biến Thể Cờ Vua");
                }
                typeTxtDict.Add(Type.FairyChess, txt);
            }

            // Weiqi
            {
                TxtLanguage txt = new TxtLanguage("Weiqi");
                {
                    txt.add(Language.Type.vi, "Cờ Vây");
                }
                typeTxtDict.Add(Type.Weiqi, txt);
            }
            // SHOGI
            {
                TxtLanguage txt = new TxtLanguage("Shogi");
                {
                    txt.add(Language.Type.vi, "Cờ Tướng Nhật (Shogi)");
                }
                typeTxtDict.Add(Type.SHOGI, txt);
            }
            // ROCK_SCISSOR_PAPER
            {
                TxtLanguage txt = new TxtLanguage("Rock Scissor Paper");
                {
                    txt.add(Language.Type.vi, "Oẳn Tù Tì");
                }
                typeTxtDict.Add(Type.ROCK_SCISSOR_PAPER, txt);
            }
            // Reversi
            {
                TxtLanguage txt = new TxtLanguage("Reversi");
                {
                    txt.add(Language.Type.vi, "Cờ Othello");
                }
                typeTxtDict.Add(Type.Reversi, txt);
            }

            // Xiangqi
            {
                TxtLanguage txt = new TxtLanguage("Chinese Chess");
                {
                    txt.add(Language.Type.vi, "Cờ Tướng");
                }
                typeTxtDict.Add(Type.Xiangqi, txt);
            }
            // CO_TUONG_UP
            {
                TxtLanguage txt = new TxtLanguage("Vietnamese Hidden Chess");
                {
                    txt.add(Language.Type.vi, "Cờ Úp");
                }
                typeTxtDict.Add(Type.CO_TUONG_UP, txt);
            }
            // Janggi
            {
                TxtLanguage txt = new TxtLanguage("Janggi");
                {
                    txt.add(Language.Type.vi, "Cờ Tướng Triều Tiên (Janggi)");
                }
                typeTxtDict.Add(Type.Janggi, txt);
            }
            // Banqi
            {
                TxtLanguage txt = new TxtLanguage("Banqi");
                {
                    txt.add(Language.Type.vi, "Banqi");
                }
                typeTxtDict.Add(Type.Banqi, txt);
            }
            // Gomoku
            {
                TxtLanguage txt = new TxtLanguage("Gomoku");
                {
                    txt.add(Language.Type.vi, "Cờ Caro (Gomoku)");
                }
                typeTxtDict.Add(Type.Gomoku, txt);
            }

            // InternationalDraught
            {
                TxtLanguage txt = new TxtLanguage("International Draught");
                {
                    txt.add(Language.Type.vi, "Cờ Đam Quốc Tế (International Draught)");
                }
                typeTxtDict.Add(Type.InternationalDraught, txt);
            }
            // EnglishDraught
            {
                TxtLanguage txt = new TxtLanguage("English Draught");
                {
                    txt.add(Language.Type.vi, "Cờ Đam Anh (English Draught)");
                }
                typeTxtDict.Add(Type.EnglishDraught, txt);
            }
            // RussianDraught
            {
                TxtLanguage txt = new TxtLanguage("Russian Draught");
                {
                    txt.add(Language.Type.vi, "Cờ Đam Nga (Russian Draught)");
                }
                typeTxtDict.Add(Type.RussianDraught, txt);
            }
            // ChineseCheckers
            {
                TxtLanguage txt = new TxtLanguage("Chinese Checkers");
                {
                    txt.add(Language.Type.vi, "Chinese Checkers");
                }
                typeTxtDict.Add(Type.ChineseCheckers, txt);
            }

            // MineSweeper
            {
                TxtLanguage txt = new TxtLanguage("Minesweeper");
                {
                    txt.add(Language.Type.vi, "Dò Mìn");
                }
                typeTxtDict.Add(Type.MineSweeper, txt);
            }
            // Hex
            {
                TxtLanguage txt = new TxtLanguage("Hex");
                {
                    txt.add(Language.Type.vi, "Hex");
                }
                typeTxtDict.Add(Type.Hex, txt);
            }
            // Solitaire
            {
                TxtLanguage txt = new TxtLanguage("Solitaire");
                {
                    txt.add(Language.Type.vi, "Solitaire");
                }
                typeTxtDict.Add(Type.Solitaire, txt);
            }

            // Sudoku
            {
                TxtLanguage txt = new TxtLanguage("Sudoku");
                {
                    txt.add(Language.Type.vi, "Sudoku");
                }
                typeTxtDict.Add(Type.Sudoku, txt);
            }
            // Khet
            {
                TxtLanguage txt = new TxtLanguage("Khet");
                {
                    txt.add(Language.Type.vi, "Khet");
                }
                typeTxtDict.Add(Type.Khet, txt);
            }
            // NineMenMorris
            {
                TxtLanguage txt = new TxtLanguage("Nine Men's Morris");
                {
                    txt.add(Language.Type.vi, "Nine Men's Morris");
                }
                typeTxtDict.Add(Type.NineMenMorris, txt);
            }
        }
    }

    public static List<string> GetEnableTypeString()
    {
        List<string> ret = new List<string>();
        {
            foreach (GameType.Type gameType in EnableTypes)
            {
                string strGameType = gameType.ToString();
                {
                    TxtLanguage txtGameType = null;
                    if (typeTxtDict.TryGetValue(gameType, out txtGameType))
                    {
                        strGameType = txtGameType.get();
                    }
                }
                ret.Add(strGameType);
            }
        }
        return ret;
    }

    public static string GetStrGameType(GameType.Type gameType)
    {
        string ret = gameType.ToString();
        {
            TxtLanguage txtGameType = null;
            if (typeTxtDict.TryGetValue(gameType, out txtGameType))
            {
                ret = txtGameType.get();
            }
        }
        return ret;
    }

    #endregion

    public abstract Type getType();

    public static readonly GameType.Type[] EnableTypes = {
        GameType.Type.CHESS,
        GameType.Type.Shatranj,
        GameType.Type.Makruk,
        GameType.Type.Seirawan,
        GameType.Type.FairyChess,

        GameType.Type.Weiqi,
        GameType.Type.SHOGI,
        GameType.Type.Reversi,

        GameType.Type.Xiangqi,
        GameType.Type.CO_TUONG_UP,
        GameType.Type.Janggi,
        GameType.Type.Banqi,

        GameType.Type.Gomoku,

        GameType.Type.InternationalDraught,
        GameType.Type.EnglishDraught,
        GameType.Type.RussianDraught,
        GameType.Type.ChineseCheckers,

        GameType.Type.MineSweeper,
        GameType.Type.Hex,
        GameType.Type.Solitaire,

        GameType.Type.Sudoku,
        GameType.Type.Khet,
        GameType.Type.NineMenMorris
    };

    public static readonly List<GameType.Type> AllEnableGameTypes = new List<Type>();

    public static int getEnableIndex(GameType.Type gameTypeType)
    {
        int index = 0;
        {
            for (int i = 0; i < EnableTypes.Length; i++)
            {
                if (EnableTypes[i] == gameTypeType)
                {
                    index = i;
                }
            }
        }
        return index;
    }

    #region Logic

    public abstract int getTeamCount();

    public abstract int getPerspectiveCount();

    public virtual int getDefaultPerspective(int playerIndex)
    {
        return playerIndex;
    }

    public abstract int getPlayerIndex();

    public abstract bool checkLegalMove(InputData inputData);

    public abstract void processGameMove(GameMove gameMove);

    public abstract GameMove getAIMove(Computer.AI computerAI, bool isFindHint);

    public abstract Result isGameFinish();

    #region solved move

    public virtual bool isHaveSolvedMove()
    {
        return false;
    }

    public virtual GameMove getSolvedMove()
    {
        return this.getAIMove(null, false);
    }

    public virtual GameMove preprocessGameMove(GameMove gameMove)
    {
        return gameMove;
    }

    #endregion

    #region check isGameFinish and score

    public class Score
    {
        public int playerIndex;
        public float score;

        public Score(int playerIndex, float score)
        {
            this.playerIndex = playerIndex;
            this.score = score;
        }
    }

    public struct Result
    {
        public bool isGameFinish;
        public List<Score> scores;

        public Result(bool isGameFinish, List<Score> scores)
        {
            this.isGameFinish = isGameFinish;
            this.scores = scores;
        }

        public Score findScore(int playerIndex)
        {
            for (int i = 0; i < scores.Count; i++)
            {
                Score score = scores[i];
                if (score.playerIndex == playerIndex)
                {
                    return score;
                }
            }
            return null;
        }

        public static Result makeDefault()
        {
            bool isGameFinish = false;
            List<Score> scores = new List<Score>();
            return new Result(isGameFinish, scores);
        }
    }

    #endregion

    #region convert

    public class Cast<K> : ConvertDelegate<GameType.Type, K>
    {
        public override GameType.Type convert(K value)
        {
            if (value is int)
            {
                return (GameType.Type)((int)(object)value);
            }
            else
            {
                Debug.LogError("convert gameType error");
                return GameType.Type.CHESS;
            }
        }
    }

    #region gameTypeConvert

    public class GameTypeConvert : ConvertDelegate<GameType.Type, int>
    {
        public override GameType.Type convert(int value)
        {
            return (GameType.Type)value;
        }
    }

    public static GameTypeConvert gameTypeConvert = new GameTypeConvert();

    #endregion

    #region intConvert

    public class IntConvert : ConvertDelegate<int, GameType.Type>
    {
        public override int convert(GameType.Type value)
        {
            return (int)value;
        }
    }

    public static IntConvert intConvert = new IntConvert();

    #endregion

    #endregion

    #endregion

    public static GameType makeDefaultGameType(GameType.Type type)
    {
        GameType gameType = null;
        {
            DefaultGameDataFactory defaultGameDataFactory = new DefaultGameDataFactory();
            {
                defaultGameDataFactory.makeNewDefaultGameType(type);
            }
            if (defaultGameDataFactory.defaultGameType.v == null)
            {
                defaultGameDataFactory.defaultGameType.v = new Xiangqi.DefaultXiangqi();
            }
            gameType = defaultGameDataFactory.defaultGameType.v.makeDefaultGameType();
        }
        return gameType;
    }

    public const string AlwaysIn = "AlwaysIn";
    public const string NotAlwaysIn = "NotAlwaysIn";

    #region BundleName

#if UNITY_STANDALONE_OSX

    public const string BundleName = "UnityNativeCore";

#elif UNITY_IPHONE

	public const string BundleName = "__Internal";

#elif UNITY_ANDROID

	public const string BundleName = "NativeCore";

#elif UNITY_STANDALONE_LINUX

    public const string BundleName = "NativeCore";

#elif UNITY_STANDALONE_WIN

    public const string BundleName = "WindowsCore";

#endif

    #endregion

    #region make Path

    public static string MakeCorePath(params string[] paths)
    {
#if UNITY_ANDROID
        return System.IO.Path.Combine(paths);
#else
        List<string> pathList = new List<string>();
        {
            pathList.Add(Application.streamingAssetsPath);
            pathList.AddRange(paths);
        }
        return System.IO.Path.Combine(pathList.ToArray());
#endif
    }

    #endregion

}
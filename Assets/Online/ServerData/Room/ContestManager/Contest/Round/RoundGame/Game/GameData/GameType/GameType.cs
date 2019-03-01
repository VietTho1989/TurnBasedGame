using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class GameType : Data
{

	public enum Type
	{
		CHESS,
		Shatranj,
		Makruk,
		Seirawan,
		FairyChess,

		Weiqi,
		SHOGI,
		ROCK_SCISSOR_PAPER,
		Reversi,

		Xiangqi,
		CO_TUONG_UP,
		Janggi,
		Banqi,

		Gomoku,

		InternationalDraught,
		EnglishDraught,
		RussianDraught,
        ChineseCheckers,

		MineSweeper,
		Hex,
		Solitaire,

		Sudoku,
		Khet,
		NineMenMorris
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
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Cờ Vua");
                    txt.add(Language.Type.en, "Chess");
                }
                typeTxtDict.Add(Type.CHESS, txt);
            }
            // Shatranj
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Cờ Ba Tư(Shatranj)");
                    txt.add(Language.Type.en, "Shatranj");
                }
                typeTxtDict.Add(Type.Shatranj, txt);
            }
            // Makruk
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Cờ Thái(Makruk)");
                    txt.add(Language.Type.en, "Makruk");
                }
                typeTxtDict.Add(Type.Makruk, txt);
            }
            // Seirawan
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Cờ Vua Seirawan");
                    txt.add(Language.Type.en, "Seirawan Chess");
                }
                typeTxtDict.Add(Type.Seirawan, txt);
            }
            // FairyChess
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Các Biến Thể Cờ Vua");
                    txt.add(Language.Type.en, "Fairy Chess");
                }
                typeTxtDict.Add(Type.FairyChess, txt);
            }

            // Weiqi
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Cờ Vây");
                    txt.add(Language.Type.en, "Go");
                }
                typeTxtDict.Add(Type.Weiqi, txt);
            }
            // SHOGI
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Cờ Tướng Nhật(Shogi)");
                    txt.add(Language.Type.en, "Shogi");
                }
                typeTxtDict.Add(Type.SHOGI, txt);
            }
            // ROCK_SCISSOR_PAPER
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Oẳn Tù Tì");
                    txt.add(Language.Type.en, "Rock Scissor Paper");
                }
                typeTxtDict.Add(Type.ROCK_SCISSOR_PAPER, txt);
            }
            // Reversi
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Cờ Othello");
                    txt.add(Language.Type.en, "Reversi");
                }
                typeTxtDict.Add(Type.Reversi, txt);
            }

            // Xiangqi
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Cờ Tướng");
                    txt.add(Language.Type.en, "Chinese Chess");
                }
                typeTxtDict.Add(Type.Xiangqi, txt);
            }
            // CO_TUONG_UP
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Cờ Úp");
                    txt.add(Language.Type.en, "Vietnamese Hidden Chess");
                }
                typeTxtDict.Add(Type.CO_TUONG_UP, txt);
            }
            // Janggi
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Cờ Tướng Triều Tiên(Janggi)");
                    txt.add(Language.Type.en, "Janggi");
                }
                typeTxtDict.Add(Type.Janggi, txt);
            }
            // Banqi
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Banqi");
                    txt.add(Language.Type.en, "Banqi");
                }
                typeTxtDict.Add(Type.Banqi, txt);
            }
            // Gomoku
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Cờ Caro(Gomoku)");
                    txt.add(Language.Type.en, "Gomoku");
                }
                typeTxtDict.Add(Type.Gomoku, txt);
            }

            // InternationalDraught
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Cờ Đam Quốc Tế(International Draught)");
                    txt.add(Language.Type.en, "International Draught");
                }
                typeTxtDict.Add(Type.InternationalDraught, txt);
            }
            // EnglishDraught
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Cờ Đam Anh(English Draught)");
                    txt.add(Language.Type.en, "English Draught");
                }
                typeTxtDict.Add(Type.EnglishDraught, txt);
            }
            // RussianDraught
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Cờ Đam Nga(Russian Draught)");
                    txt.add(Language.Type.en, "Russian Draught");
                }
                typeTxtDict.Add(Type.RussianDraught, txt);
            }
            // ChineseCheckers
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Chinese Checkers");
                    txt.add(Language.Type.en, "Chinese Checkers");
                }
                typeTxtDict.Add(Type.ChineseCheckers, txt);
            }

            // MineSweeper
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Dò Mìn");
                    txt.add(Language.Type.en, "Minesweeper");
                }
                typeTxtDict.Add(Type.MineSweeper, txt);
            }
            // Hex
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Hex");
                    txt.add(Language.Type.en, "Hex");
                }
                typeTxtDict.Add(Type.Hex, txt);
            }
            // Solitaire
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Solitaire");
                    txt.add(Language.Type.en, "Solitaire");
                }
                typeTxtDict.Add(Type.Solitaire, txt);
            }

            // Sudoku
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Sudoku");
                    txt.add(Language.Type.en, "Sudoku");
                }
                typeTxtDict.Add(Type.Sudoku, txt);
            }
            // Khet
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Khet");
                    txt.add(Language.Type.en, "Khet");
                }
                typeTxtDict.Add(Type.Khet, txt);
            }
            // NineMenMorris
            {
                TxtLanguage txt = new TxtLanguage();
                {
                    txt.add(Language.Type.vi, "Nine Men's Morris");
                    txt.add(Language.Type.en, "Nine Men's Morris");
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
                        strGameType = txtGameType.get(gameType.ToString());
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
                ret = txtGameType.get(gameType.ToString());
            }
        }
        return ret;
    }

    #endregion

    public abstract Type getType ();

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

	public static readonly List<GameType.Type> AllEnableGameTypes = new List<Type> ();

	public static int getEnableIndex(GameType.Type gameTypeType)
	{
		int index = 0;
		{
			for (int i = 0; i < EnableTypes.Length; i++) {
				if (EnableTypes [i] == gameTypeType) {
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

    public abstract int getPlayerIndex ();

	public abstract bool checkLegalMove (InputData inputData);

	public abstract void processGameMove(GameMove gameMove);

	public abstract GameMove getAIMove (Computer.AI computerAI, bool isFindHint);

	public abstract Result isGameFinish();

	#region solved move

	public virtual bool isHaveSolvedMove()
	{
		return false;
	}

	public virtual GameMove getSolvedMove()
	{
		return this.getAIMove (null, false);
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

		public Score(int playerIndex, float score){
			this.playerIndex = playerIndex;
			this.score = score;
		}
	}

	public struct Result
	{
		public bool isGameFinish;
		public List<Score> scores;

		public Result(bool isGameFinish, List<Score> scores){
			this.isGameFinish = isGameFinish;
			this.scores = scores;
		}

		public Score findScore(int playerIndex){
			for (int i = 0; i < scores.Count; i++) {
				Score score = scores [i];
				if (score.playerIndex == playerIndex) {
					return score;
				}
			}
			return null;
		}

		public static Result makeDefault()
		{
			bool isGameFinish = false;
			List<Score> scores = new List<Score> ();
			return new Result (isGameFinish, scores);
		}
	}

	#endregion

	#region convert

	public class Cast<K> : ConvertDelegate<GameType.Type, K>
	{
		public override GameType.Type convert (K value)
		{
			if (value is int) {
				return (GameType.Type) ((int)(object)value);
			} else {
				Debug.LogError ("convert gameType error");
				return GameType.Type.CHESS;
			}
		}
	}

	#region gameTypeConvert

	public class GameTypeConvert : ConvertDelegate<GameType.Type, int>
	{
		public override GameType.Type convert (int value)
		{
			return (GameType.Type)value;
		}
	}

	public static GameTypeConvert gameTypeConvert = new GameTypeConvert();

	#endregion

	#region intConvert

	public class IntConvert : ConvertDelegate<int, GameType.Type>
	{
		public override int convert (GameType.Type value)
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
			DefaultGameDataFactory defaultGameDataFactory = new DefaultGameDataFactory ();
			{
				defaultGameDataFactory.makeNewDefaultGameType (type);
			}
			if (defaultGameDataFactory.defaultGameType.v == null) {
				defaultGameDataFactory.defaultGameType.v = new Xiangqi.DefaultXiangqi ();
			}
			gameType = defaultGameDataFactory.defaultGameType.v.makeDefaultGameType ();
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

	#endif

	#endregion
}
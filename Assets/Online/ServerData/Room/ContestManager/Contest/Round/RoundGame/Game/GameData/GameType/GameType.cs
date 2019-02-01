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

		GameType.Type.MineSweeper,
		GameType.Type.Hex,
		GameType.Type.Solitaire,

		GameType.Type.Sudoku,
		GameType.Type.Khet,
		GameType.Type.NineMenMorris
	};

	public static readonly List<GameType.Type> AllEnableGameTypes = new List<Type> ();

	static GameType()
	{
		foreach (GameType.Type gameType in GameType.EnableTypes) {
			AllEnableGameTypes.Add (gameType);
		}
	}

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
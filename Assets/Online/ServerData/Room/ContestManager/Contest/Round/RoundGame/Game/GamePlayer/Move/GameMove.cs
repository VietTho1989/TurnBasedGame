using UnityEngine;
using System.Collections;

public abstract class GameMove : Data
{

	public enum Type
	{
		None,
		EndTurn,
		Clear,

		ChessMove,
		ChessCustomSet,
		ChessCustomMove,

		ShatranjMove,
		ShatranjCustomMove,
		ShatranjCustomSet,

		MakrukMove,
		MakrukCustomMove,
		MakrukCustomSet,

		SeirawanMove,
		SeirawanCustomMove,
		SeirawanCustomSet,
		SeirawanCustomHand,

		FairyChessMove,
		FairyChessCustomMove,
		FairyChessCustomSet,
		FairyChessCustomHand,

		XiangqiMove,
		XiangqiCustomSet,
		XiangqiCustomMove,

		CoTuongUpMove,
		CoTuongUpCustomMove,
		CoTuongUpCustomSet,
		CoTuongUpCustomFlip,

		JanggiMove,
		JanggiCustomMove,
		JanggiCustomSet,

		BanqiMove,
		BanqiCustomMove,
		BanqiCustomSet,
		BanqiCustomFlip,

		WeiqiMove,
		WeiqiCustomMove,
		WeiqiCustomSet,

		ReversiMove,
		ReversiCustomMove,
		ReversiCustomSet,

		ShogiMove,
		ShogiCustomMove,
		ShogiCustomSet,
		ShogiCustomHand,

		GomokuMove,
		GomokuCustomMove,
		GomokuCustomSet,

		InternationalDraughtMove,
		InternationalDraughtCustomMove,
		InternationalDraughtCustomSet,

		EnglishDraughtMove,
		EnglishDraughtCustomMove,
		EnglishDraughtCustomSet,

		RussianDraughtMove,
		RussianDraughtCustomMove,
		RussianDraughtCustomSet,

        ChineseCheckersMove,

		MineSweeperMove,
		MineSweeperCustomMove,
		MineSweeperCustomSet,

		HexMove,
		HexSwitch,
		HexCustomMove,
		HexCustomSet,

		SolitaireMove,
		SolitaireReset,
		SolitaireSolved,

		SudokuMove,
		SudokuSolve,
		SudokuCustomMove,

		KhetMove,
		KhetCusomMove,
		KhetCusomSet,
		KhetCustomRotate,

		NineMenMorrisMove,
        NineMenMorrisCustomMove,
        NineMenMorrisCustomSet
    }

	public abstract Type getType();

	public abstract MoveAnimation makeAnimation (GameType gameType);

	public abstract string print();

	public abstract void getInforBeforeProcess (GameType gameType);

	public virtual bool isCanMakeMoveMessage()
	{
		return true;
	}

	public virtual GameMove getForHintMove(GameType gameType)
	{
		return this;
	}

}
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
        ChessCustomFen,

		ShatranjMove,
		ShatranjCustomMove,
		ShatranjCustomSet,
        ShatranjCustomFen,

		MakrukMove,
		MakrukCustomMove,
		MakrukCustomSet,
        MakrukCustomFen,

		SeirawanMove,
		SeirawanCustomMove,
		SeirawanCustomSet,
		SeirawanCustomHand,
        SeirawanCustomFen,

		FairyChessMove,
		FairyChessCustomMove,
		FairyChessCustomSet,
		FairyChessCustomHand,
        FairyChessCustomFen,

		XiangqiMove,
		XiangqiCustomSet,
		XiangqiCustomMove,
        XiangqiCustomFen,

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
        EnglishDraughtCustomFen,

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
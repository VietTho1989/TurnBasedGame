using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Sudoku
{
	public class AIHaveSolve : AISolve
	{

		public LP<byte> board;

		public LP<byte> order;

		#region Constructor

		public enum Property
		{
			board,
			order
		}

		public AIHaveSolve() : base()
		{
			this.board = new LP<byte> (this, (byte)Property.board);
			this.order = new LP<byte> (this, (byte)Property.order);
		}

		#endregion

		public override Type getType ()
		{
			return Type.HaveSove;
		}

		public class BoardAndOrder
		{
			public int[,] board;
			public int[,] order;
			public int correctCount = 0;
		}

		public override GameMove getAIMove ()
		{
			List<byte> allBoards = new List<byte> ();
			List<byte> allOrders = new List<byte> ();
			{
				allBoards.AddRange (this.board.vs);
				allOrders.AddRange (this.order.vs);
			}
			// make board and order
			List<BoardAndOrder> boardAndOrders = new List<BoardAndOrder>();
			{
				while (allBoards.Count >= 81) {
					BoardAndOrder boardAndOrder = new BoardAndOrder ();
					{
						boardAndOrder.board = new int[9, 9];
						boardAndOrder.order = new int[9, 9];
						for (int y = 0; y < 9; y++)
							for (int x = 0; x < 9; x++) {
								// make board
								int index = 9 * y + x;
								boardAndOrder.board [x, y] = allBoards [index];
								// make order
								{
									int orderXY = int.MaxValue;
									{
										if (allOrders.Count > 0) {
											orderXY = allOrders [0];
											allOrders.RemoveAt (0);
										}
									}
									boardAndOrder.order [x, y] = orderXY;
								}
							}
					}
					boardAndOrders.Add (boardAndOrder);
					// remove and next round
					allBoards.RemoveRange (0, 81);
				}
			}
			// find solve board
			Sudoku sudoku = this.findDataInParent<Sudoku>();
			if (sudoku != null) {
				// remove board and order cannot solve
				{
					// make origin sudoku board
					int[,] originSudokuBoard = new int[9, 9];
					{
						for (int y = 0; y < 9; y++)
							for (int x = 0; x < 9; x++) {
								int index = 9 * y + x;
								// find value
								int value = 0;
								{
									// get board
									if (index >= 0 && index < sudoku.board.vs.Count) {
										value = sudoku.board.vs [index];
									} else {
										Debug.LogError ("index error: " + index + ", " + sudoku.board.vs.Count);
									}
								}
								originSudokuBoard [x, y] = value;
							}
					}
					for (int i = boardAndOrders.Count - 1; i >= 0; i--) {
						BoardAndOrder boardAndOrder = boardAndOrders [i];
						// check correct
						bool isCorrect = true;
						{
							for (int y = 0; y < 9; y++)
								for (int x = 0; x < 9; x++) {
									if (originSudokuBoard [x, y] != 0) {
										if (boardAndOrder.board [x, y] != originSudokuBoard [x, y]) {
											isCorrect = false;
											break;
										}
									}
								}
						}
						// process
						if (!isCorrect) {
							boardAndOrders.RemoveAt (i);
						}
					}
				}
				// find correct count
				if (boardAndOrders.Count > 0) {
					// get current board
					int[,] currentSudokuBoard = new int[9, 9];
					{
						for (int y = 0; y < 9; y++)
							for (int x = 0; x < 9; x++) {
								int index = 9 * y + x;
								// find value
								int value = 0;
								{
									// get board
									if (index >= 0 && index < sudoku.board.vs.Count) {
										value = sudoku.board.vs [index];
										if (value == 0) {
											if (index >= 0 && index < sudoku.userSolve.vs.Count) {
												value = sudoku.userSolve.vs [index];
											}
										}
									} else {
										Debug.LogError ("index error: " + index + ", " + sudoku.board.vs.Count);
									}
								}
								currentSudokuBoard [x, y] = value;
							}
					}
					// set correct count
					int maxCorrectCount = 0;
					foreach (BoardAndOrder boardAndOrder in boardAndOrders) {
						int correctCount = 0;
						{
							for (int y = 0; y < 9; y++)
								for (int x = 0; x < 9; x++) {
									if (currentSudokuBoard [x, y] != 0) {
										if (currentSudokuBoard [x, y] == boardAndOrder.board [x, y]) {
											correctCount++;
										}
									}
								}
						}
						boardAndOrder.correctCount = correctCount;
						if (correctCount > maxCorrectCount) {
							maxCorrectCount = correctCount;
						}
					}
					// only choose max correct count
					for (int i = boardAndOrders.Count - 1; i >= 0; i--) {
						BoardAndOrder boardAndOrder = boardAndOrders [i];
						if (boardAndOrder.correctCount != maxCorrectCount) {
							boardAndOrders.RemoveAt (i);
						}
					}
					// choose boardAndOrder
					if (boardAndOrders.Count > 0) {
						BoardAndOrder boardAndOrder = boardAndOrders[0];
						{
							System.Random random = new System.Random ();
							int index = random.Next (boardAndOrders.Count);
							if (index >= 0 && index < boardAndOrders.Count) {
								boardAndOrder = boardAndOrders [index];
							} else {
								Debug.LogError ("index error: " + index + ", " + boardAndOrders.Count);
							}
						}
						// choose move
						List<SudokuMove> sudokuMoves = new List<SudokuMove>();
						{
							for (int y = 0; y < 9; y++)
								for (int x = 0; x < 9; x++) {
									if (currentSudokuBoard [x, y] == 0 || currentSudokuBoard [x, y] != boardAndOrder.board [x, y]) {
										SudokuMove sudokuMove = new SudokuMove ();
										{
											sudokuMove.x.v = (byte)x;
											sudokuMove.y.v = (byte)y;
											sudokuMove.value.v = (byte)boardAndOrder.board [x, y];
										}
										sudokuMoves.Add (sudokuMove);
									}
								}
						}
						if (sudokuMoves.Count > 0) {
							if (sudokuMoves.Count > 1) {
								sudokuMoves.Sort ((A, B) => -boardAndOrder.order [A.x.v, A.y.v].CompareTo (boardAndOrder.order [B.x.v, B.y.v]));
							}
							// random in chosen move
							for (int i = sudokuMoves.Count - 1; i >= 1; i--) {
								if (boardAndOrder.order [sudokuMoves [i].x.v, sudokuMoves [i].y.v] != boardAndOrder.order [sudokuMoves [0].x.v, sudokuMoves [0].y.v]) {
									sudokuMoves.RemoveAt (i);
								}
							}
							// random
							{
								System.Random random = new System.Random ();
								int index = random.Next (sudokuMoves.Count);
								if (index >= 0 && index < sudokuMoves.Count) {

								} else {
									Debug.LogError ("index error: " + index + ", " + boardAndOrders.Count);
									index = 0;
								}
								return sudokuMoves [index];
							}
						} else {
							Debug.LogError ("why don't have any sudokuMoves");
						}
					} else {
						Debug.LogError ("why don't have boardAndOrders");
					}
				}
			} else {
				Debug.LogError ("sudoku null");
			}
			return null;
		}

	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Janggi.Ai;

namespace Janggi
{
	public class Core
	{

		public static Janggi makeDefaultPosition()
		{
			Janggi janggi = new Janggi ();
			{
				Board board = new Board (Board.Tables.Outer, Board.Tables.Left, true);
				Janggi.parseFromBoard (janggi, board);
			}
			return janggi;
		}

		public static bool isLegalMove(Janggi janggi, JanggiMove janggiMove)
		{
			bool ret = false;
			{
				Board board = Janggi.convertToBoard (janggi);
				List<Common.Move> allPossibleMoves = board.GetAllPossibleMoves ();
				foreach (Common.Move move in allPossibleMoves) {
					if (janggiMove.fromX.v == move.From.X && janggiMove.fromY.v == move.From.Y
					   && janggiMove.toX.v == move.To.X && janggiMove.toY.v == move.To.Y) {
						ret = true;
						break;
					}
				}
			}
			return ret;
		}

		public static Janggi doMove(Janggi janggi, JanggiMove janggiMove)
		{
			Janggi newJanggi = new Janggi ();
			{
				// get
				Board board = Janggi.convertToBoard (janggi);
				Common.Move move = new Common.Move ();
				// make move
				{
					move.From.X = janggiMove.fromX.v;
					move.From.Y = janggiMove.fromY.v;
					move.To.X = janggiMove.toX.v;
					move.To.Y = janggiMove.toY.v;
				}
				board.MoveNext (move);
				// parse
				Janggi.parseFromBoard(newJanggi, board);
			}
			return newJanggi;
		}

		public static JanggiMove letComputerThink(Janggi janggi, int maxVisitCount)
		{
			JanggiMove janggiMove = new JanggiMove ();
			{
				// correct maxVisitCount
				{
					if (maxVisitCount < 100) {
						Debug.LogError ("why maxVisitCount too small");
						maxVisitCount = 100;
					}
				}
				Board board = Janggi.convertToBoard (janggi);
				// PrimaryUcb primaryUcb = new PrimaryUcb();
				PseudoYame pseudoYame = new PseudoYame ();
				Mcts mcts = new Mcts(pseudoYame, maxVisitCount);
				mcts.Init(board);

				Node node = mcts.SearchNextAsync ();
				// set
				if (node != null) {
					janggiMove.fromX.v = node.prevMove.From.X;
					janggiMove.fromY.v = node.prevMove.From.Y;
					janggiMove.toX.v = node.prevMove.To.X;
					janggiMove.toY.v = node.prevMove.To.Y;
				} else {
					Debug.LogError ("node null");
				}
				if (!board.IsMyWin && !board.IsYoWin) {
					
				} else {
					Debug.LogError ("why board already finish");
				}
			}
			return janggiMove;
		}

		public static int isGameFinish(Janggi janggi)
		{
			int ret = 0;
			{
				Board board = Janggi.convertToBoard (janggi);
				if (board.IsMyWin) {
					ret = 1;
				} else if (board.IsYoWin) {
					ret = 2;
				}
			}
			return ret;
		}

		public static string getStrPosition(Janggi janggi)
		{
			Board board = Janggi.convertToBoard (janggi);
			return board.PrintStones ();
		}

		public static List<JanggiMove> getLegalMoves(Janggi janggi)
		{
			List<JanggiMove> ret = new List<JanggiMove> ();
			{
				Board board = Janggi.convertToBoard (janggi);
				List<Common.Move> moves = board.GetAllPossibleMoves ();
				foreach (Common.Move move in moves) {
					JanggiMove janggiMove = new JanggiMove ();
					{
						janggiMove.fromX.v = move.From.X;
						janggiMove.fromY.v = move.From.Y;
						janggiMove.toX.v = move.To.X;
						janggiMove.toY.v = move.To.Y;
					}
					ret.Add (janggiMove);
				}
			}
			return ret;
		}

	}
}
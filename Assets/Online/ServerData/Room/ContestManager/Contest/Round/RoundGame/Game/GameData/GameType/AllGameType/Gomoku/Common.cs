using UnityEngine;
using System.Collections;
using System.Text;

namespace Gomoku
{
	public class Common
	{

		public enum Type
		{
			None,
			Black,
			White
		}

		public static string printPosition(Gomoku gomoku){
			StringBuilder builder = new StringBuilder ();
			{
				long length = gomoku.gs.vs.Count;
				if (length == gomoku.boardSize.v * gomoku.boardSize.v) {
					for (int y = 0; y < gomoku.boardSize.v; y++) {
						for (int x = 0; x < gomoku.boardSize.v; x++) {
							int coord = x + gomoku.boardSize.v * y;
							if (gomoku.gs.vs [coord] == '1' || gomoku.gs.vs [coord] == '2') {
								// get char
								char c = 'X';
								{
									bool isWinCoord = false;
									// check is win coord
									{
										if (gomoku.winSize.v >= 0 && gomoku.winSize.v < 100) {
											for (int i = 0; i < gomoku.winSize.v; i++) {
												if (i < gomoku.winCoord.vs.Count) {
													if (gomoku.winCoord.vs [i] == coord) {
														isWinCoord = true;
														break;
													}
												} else {
													Debug.LogError ("winCoord size error: " + i + "; " + gomoku.winCoord.vs.Count);
												}
											}
										} else {
											Debug.LogError ("winSize error: " + gomoku.winSize.v);
										}
									}
									if (!isWinCoord) {
										if (gomoku.gs.vs [coord] == '1') {
											c = 'X';
										} else {
											c = 'O';
										}
									} else {
										if (gomoku.gs.vs [coord] == '1') {
											c = 'x';
										} else {
											c = 'o';
										}
									}
								}
								// print
								{
									// find lastMoveIndex
									int lastMoveIndex = -1;
									for (int i = Gomoku.LastMoveCount - 1; i >= 0; i--) {
										if (i < gomoku.lastMove.vs.Count) {
											if (coord == gomoku.lastMove.vs [i]) {
												lastMoveIndex = i;
											}
										} else {
											Debug.LogError ("error, gomoku lastMoveCount error: " + i + "; " + gomoku.lastMove.vs.Count);
										}
									}
									if (lastMoveIndex >= 0) {
										builder.Append (string.Format (" {0}{1}", c, lastMoveIndex + 1));
									} else {
										builder.Append (string.Format (" {0} ", c));
									}
								}
							} else {
								builder.Append (" . ");
							}
						}
						builder.Append ("\n");
					}
				} else {
					Debug.LogError (string.Format ("error, length error: {0}, {1}", length, gomoku.boardSize.v));
				}
			}
			return builder.ToString();
		}

		public static int convertLocalPositionToSquare(Gomoku gomoku, Vector3 localPosition)
		{
			int x = Mathf.RoundToInt (localPosition.x + gomoku.boardSize.v / 2.0f - 0.5f);
			int y = Mathf.RoundToInt (localPosition.y + gomoku.boardSize.v / 2.0f - 0.5f);
			return x + gomoku.boardSize.v * y;
		}

		public static Vector3 convertSquareToLocalPosition(int boardSize, int square)
		{
			if (boardSize > 0) {
				int x = square % boardSize;
				int y = square / boardSize;
				return new Vector3 (x + 0.5f - boardSize / 2.0f, y + 0.5f - boardSize / 2.0f, 0);
			} else {
				Debug.LogError ("error, why boardSize <=0: " + boardSize);
				return Vector3.zero;
			}
		}

	}
}
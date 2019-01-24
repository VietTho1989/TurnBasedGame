using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RussianDraught
{
	public class Common
	{

		public const int MAXDEPTH = 80;

		/* board values */
		public const int OCCUPIED = 0xf0;
		public const int WHITE = 1;
		public const int BLACK = 2;
		public const int MAN = 4;
		public const int KING = 8;
		public const int FREE = 0;
		public const int MCP_MARGIN = 32;

		public const int WHT_MAN = 5;
		public const int BLK_MAN = 6;
		public const int WHT_KNG = 9;
		public const int BLK_KNG = 10;

		public static bool isRealPiece(int piece)
		{
			return (piece == WHT_MAN) || (piece == WHT_KNG) || (piece == BLK_MAN) || (piece == BLK_KNG);
		}

		public static bool isDarkSquare(int square)
		{
			int x = square % 8;
			int y = square / 8;
			return (x % 2) == (y % 2);
		}

		#region Convert

		public static Vector2 convertSquareToLocalPosition(int square)
		{
			float x = square % 8;
			float y = square / 8;
			return new Vector2 ((7 - x) + 0.5f - 4, (7 - y) + 0.5f - 4);
		}

		public static int converLocalPositionToSquare(Vector3 localPosition)
		{
			int x = 7 - Mathf.RoundToInt (localPosition.x - (0.5f - 4f));
			int y = 7 - Mathf.RoundToInt (localPosition.y - (0.5f - 4f));
			if (x >= 0 && x < 8 && y >= 0 && y < 8) {
				return x + 8 * y;
			} else {
				Debug.LogError ("click outside board: " + localPosition);
				return -1;
			}
		}

		#endregion

		public static void makeBoardMatrix(int[,] b, List<int> Board)
		{
			if (Board.Count == 46) {
				b [0, 0] = Board [5];
				b [2, 0] = Board [6];
				b [4, 0] = Board [7];
				b [6, 0] = Board [8];
				b [1, 1] = Board [10];
				b [3, 1] = Board [11];
				b [5, 1] = Board [12];
				b [7, 1] = Board [13];
				b [0, 2] = Board [14];
				b [2, 2] = Board [15];
				b [4, 2] = Board [16];
				b [6, 2] = Board [17];
				b [1, 3] = Board [19];
				b [3, 3] = Board [20];
				b [5, 3] = Board [21];
				b [7, 3] = Board [22];
				b [0, 4] = Board [23];
				b [2, 4] = Board [24];
				b [4, 4] = Board [25];
				b [6, 4] = Board [26];
				b [1, 5] = Board [28];
				b [3, 5] = Board [29];
				b [5, 5] = Board [30];
				b [7, 5] = Board [31];
				b [0, 6] = Board [32];
				b [2, 6] = Board [33];
				b [4, 6] = Board [34];
				b [6, 6] = Board [35];
				b [1, 7] = Board [37];
				b [3, 7] = Board [38];
				b [5, 7] = Board [39];
				b [7, 7] = Board [40];
			} else {
				Debug.LogError ("why Board count wrong: " + Board.Count);
			}
		}

	}
}
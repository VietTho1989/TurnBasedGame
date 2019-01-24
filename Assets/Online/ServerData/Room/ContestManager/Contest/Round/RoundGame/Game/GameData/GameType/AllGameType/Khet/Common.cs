using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
	public class Common
	{

		// The padded dimensions of the board.
		public const int BoardWidth = 12;
		public const int BoardHeight = 10;
		public const int BoardArea = BoardWidth * BoardHeight;
		public const int NumPiecesPerPlayer = 13;

		// Rules constants.
		public const int RepetitionLimit = 3;
		public const int TimeSinceCaptureLimit = 100; // 100 plys = 50 moves each.

		// Can compute an upper-bound for the maximum game length.
		// Assume that one piece is captured per TimeSinceCaptureLimit of moves.
		public const int MaxGameLength = TimeSinceCaptureLimit * 2 * (NumPiecesPerPlayer - 4);

		// This constant is used to indicate that a location is off board.
		public const byte OffBoard = 0;

		// This constant is used to indicate that a location is empty.
		public const byte Empty = 1;

		// This constant is used to indicate that no move was available.
		public const uint NoMove = 0;

		// The player types.
		public enum Player
		{
			Silver = 0,
			Red = 1
		};

		// The piece types.
		public enum Piece
		{
			None = 1,
			Anubis = 2,
			Pyramid = 3,
			Scarab = 4,
			Pharaoh = 5,
			Sphinx = 6
		};

		// The orientation of a piece.
		public enum Orientation
		{
			Up = 0,
			Right = 1,
			Down = 2,
			Left = 3
		};

		public static Player GetOwner(byte s)
		{
			return (Player)(s >> 1 & 0x1);
		}

		public static Piece GetPiece(byte s)
		{
			return (Piece)(s >> 2 & 0x7);
		}

		public static Orientation GetOrientation(byte s)
		{
			return (Orientation)(s >> 5 & 0x7);
		}

		public static byte MakeSquare(Player player, Piece piece, Orientation orientation)
		{
			return (byte)((int)player << 1 | (int)piece << 2 | (int)orientation << 5);
		}

		public static Vector2 getLocalPosition(int position)
		{
			int x = position % Common.BoardWidth;
			int y = position / Common.BoardWidth;
			return new Vector2 (x + 0.5f - 12 / 2f, y + 0.5f - 10 / 2f);
		}

		public static void convertLocalPositionToXY(Vector3 localPosition, out int x, out int y)
		{
			x = Mathf.RoundToInt (localPosition.x + 4.5f);
			y = Mathf.RoundToInt (localPosition.y + 3.5f);
		}

		public struct PieceAndPlayer
		{
			
			public Player player;

			public Piece piece;

			public override bool Equals (object obj)
			{
				if (obj is PieceAndPlayer) {
					PieceAndPlayer other = (PieceAndPlayer)obj;
					return other.player == this.player && other.piece == this.piece;
				} else {
					return false;
				}
			}

			public override int GetHashCode ()
			{
				return 10 * player.GetHashCode () + piece.GetHashCode ();
			}

		}

	}
}
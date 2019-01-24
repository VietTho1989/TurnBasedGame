using UnityEngine;
using System;
using System.Collections;
using System.Reflection;
using System.Text;
using System.Collections.Generic;

namespace Shatranj
{
	public class Common 
	{
		
		public enum Piece 
		{
			NO_PIECE,

			W_PAWN = 1, 
			W_BISHOP, 
			W_QUEEN,
			W_KNIGHT, 
			W_ROOK, 
			W_KING,

			B_PAWN = 9, 
			B_BISHOP,
			B_QUEEN, 
			B_KNIGHT, 
			B_ROOK,
			B_KING,
			PIECE_NB = 16
		};

		public static Piece make_piece(Color c, PieceType pt) {
			return (Piece)(((int)c << 3) + (int)pt);
		}
				
		public enum Square : int {
			SQ_A1, SQ_B1, SQ_C1, SQ_D1, SQ_E1, SQ_F1, SQ_G1, SQ_H1,
			SQ_A2, SQ_B2, SQ_C2, SQ_D2, SQ_E2, SQ_F2, SQ_G2, SQ_H2,
			SQ_A3, SQ_B3, SQ_C3, SQ_D3, SQ_E3, SQ_F3, SQ_G3, SQ_H3,
			SQ_A4, SQ_B4, SQ_C4, SQ_D4, SQ_E4, SQ_F4, SQ_G4, SQ_H4,
			SQ_A5, SQ_B5, SQ_C5, SQ_D5, SQ_E5, SQ_F5, SQ_G5, SQ_H5,
			SQ_A6, SQ_B6, SQ_C6, SQ_D6, SQ_E6, SQ_F6, SQ_G6, SQ_H6,
			SQ_A7, SQ_B7, SQ_C7, SQ_D7, SQ_E7, SQ_F7, SQ_G7, SQ_H7,
			SQ_A8, SQ_B8, SQ_C8, SQ_D8, SQ_E8, SQ_F8, SQ_G8, SQ_H8,
			SQ_NONE,

			SQUARE_NB = 64,

			NORTH =  8,
			EAST  =  1,
			SOUTH = -8,// -NORTH,
			WEST  = -1,//-EAST,

			NORTH_EAST = NORTH + EAST,
			SOUTH_EAST = SOUTH + EAST,
			SOUTH_WEST = SOUTH + WEST,
			NORTH_WEST = NORTH + WEST
		};


		public enum PieceType {
			NO_PIECE_TYPE, 
			PAWN, 
			BISHOP, 
			QUEEN, 
			KNIGHT, 
			ROOK, 
			KING,
			ALL_PIECES = 0,
			PIECE_TYPE_NB = 8
		};

		const int MAX_PLY   = 32;

		public enum Value : int {
			VALUE_ZERO      = 0,
			VALUE_DRAW      = 0,
			VALUE_KNOWN_WIN = 10000,
			VALUE_MATE      = 32000,
			VALUE_INFINITE  = 32001,
			VALUE_NONE      = 32002,

			VALUE_MATE_IN_MAX_PLY  =  32000 - 2 * MAX_PLY,
			VALUE_MATED_IN_MAX_PLY = -32000 + 2 * MAX_PLY,

			PawnValueMg   = 175,   PawnValueEg   = 231,
			BishopValueMg = 332,   BishopValueEg = 337,
			QueenValueMg  = 417,   QueenValueEg  = 540,
			KnightValueMg = 877,   KnightValueEg = 1110,
			RookValueMg   = 1337,  RookValueEg   = 1965,

			MidgameLimit  = 15258, EndgameLimit  = 3915
		};

		public enum Color {
			WHITE, BLACK, COLOR_NB = 2
		};

		public static Color color_of(Piece pc) {
			if (!(pc != Piece.NO_PIECE)) {
				Debug.LogError ("error, assert(pc != NO_PIECE)");
			}
			return (Color)((int)pc >> 3);
		}

		public enum File : int {
			FILE_A, FILE_B, FILE_C, FILE_D, FILE_E, FILE_F, FILE_G, FILE_H, FILE_NB
		};

		public enum Rank : int {
			RANK_1, RANK_2, RANK_3, RANK_4, RANK_5, RANK_6, RANK_7, RANK_8, RANK_NB
		};

		static Rank rank_of(Square s) {
			return (Rank)((int)s >> 3);
		}

		/// Score enum stores a middlegame and an endgame value in a single integer
		/// (enum). The least significant 16 bits are used to store the endgame value
		/// and the upper 16 bits are used to store the middlegame value. Take some
		/// care to avoid left-shifting a signed int to avoid undefined behavior.
		public enum Score : int { SCORE_ZERO };

		public enum MoveType {
			NORMAL,
			PROMOTION = 1 << 14
		};

		static MoveType type_of(int m) {
			return (MoveType)(m & (3 << 14));
		}

		static PieceType promotion_type(int m) {
			return (PieceType)(((m >> 12) & 3) + PieceType.KNIGHT);
		}

		#region MoveToString

		enum Move : int {
			MOVE_NONE,
			MOVE_NULL = 65
		};

		static Square from_sq(int m) {
			return (Square)((m >> 6) & 0x3F);
		}

		static Square to_sq(int m) {
			return (Square)(m & 0x3F);
		}

		public static Square make_square(File f, Rank r) {
			return (Square)(((int)r << 3) + f);
		}

		public static string moveToString(int m, bool chess960)
		{
			Square from = from_sq(m);
			Square to = to_sq(m);

			if (m == (int)Move.MOVE_NONE)
				return "(none)";

			if (m == (int)Move.MOVE_NULL)
				return "0000";

			string move = squareToString(from) + squareToString(to);

			if (type_of (m) == MoveType.PROMOTION) {
				string pieceChars = " pnbrqk";
				int promotionType = (int)promotion_type (m);
				if (promotionType >= 0 && promotionType < pieceChars.Length) {
					move += pieceChars [promotionType];
				} else {
					Debug.LogError ("promotionType error: " + promotionType);
				}
			}

			return move;
		}

		static string squareToString(Square s) {
			char c1 = (char)('a' + (int)file_of (s));
			char c2 = (char)('1' + (int)rank_of (s));
			return c1.ToString() + c2.ToString ();
		}

		static File file_of(Square s) {
			return (File)((int)s & 7);
		}

		#endregion

		#region PositionToString

		public static string positionToString(Shatranj shatranj)
		{
			StringBuilder ss = new StringBuilder ();
			{
				ss.Append ("\n +---+---+---+---+---+---+---+---+\n");
				const string PieceToChar = " PNBRQK  pnbrqk";
				for (Rank y = Rank.RANK_8; y >= Rank.RANK_1; --y) {
					for (File x = File.FILE_A; x <= File.FILE_H; ++x){
						// find char index
						int charIndex = 0;
						{
							charIndex = (int)shatranj.piece_on (make_square (x, y));
							if (!(charIndex >= 0 && charIndex < PieceToChar.Length)) {
								Debug.LogError ("error, charIndex: " + charIndex);
								charIndex = 0;
							}
						}
						ss.Append (string.Format (" | {0}", PieceToChar [charIndex]));
					}
					ss.Append (" |\n +---+---+---+---+---+---+---+---+\n");
				}

				// sprintf(ret, "%s\nFen: %s\nKey: %llu\nCheckers: ", ret, pos.fen().c_str(), pos.key());

				// printf("makePrintPos: checker: %llu\n", pos.checkers());
				/*for (Bitboard b = pos.checkers(); b; ){
					sprintf(ret, "%s%s ", ret, UCI::square(pop_lsb(&b)).c_str());
				}*/
			}
			return ss.ToString();
		}

		#endregion

		public static int GetDistance(Common.Square ori, Common.Square dest)
		{
			File oriFile = Common.file_of (ori);
			Rank oriRank = Common.rank_of (ori);
			File destFile = Common.file_of (dest);
			Rank destRank = Common.rank_of (dest);
			return Mathf.Abs (destFile - oriFile) + Mathf.Abs (destRank - oriRank);
		}

		public static void convertLocalPositionToXY(Vector3 localPosition, out int x, out int y)
		{
			x = Mathf.RoundToInt (localPosition.x + 3.5f);
			y = Mathf.RoundToInt (localPosition.y + 3.5f);
		}

		public static Vector3 convertXYToLocalPosition(int x, int y)
		{
			return new Vector3 (x - 3.5f, y - 3.5f, 0);
		}

	}
}
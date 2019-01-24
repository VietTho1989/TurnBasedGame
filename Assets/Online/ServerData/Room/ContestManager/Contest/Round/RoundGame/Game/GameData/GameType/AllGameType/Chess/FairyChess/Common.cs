using UnityEngine;
using System;
using System.Collections;
using System.Reflection;
using System.Text;
using System.Collections.Generic;

namespace FairyChess
{
	public class Common 
	{

		public class ColorAndPiece
		{

			public Common.Color color;

			public Common.PieceType pieceType;

			public override bool Equals (object obj)
			{
				if (obj!=null && obj is ColorAndPiece) {
					ColorAndPiece other = obj as ColorAndPiece;
					return this.color == other.color && this.pieceType == other.pieceType;
				} else {
					return false;
				}
			}

			public override int GetHashCode ()
			{
				return color.GetHashCode () + pieceType.GetHashCode ();
			}

		}

		public enum VariantType
		{
			chess,
			standard,
			makruk,
			asean,
			ai_wok,
			shatranj,
			amazon,
			hoppelpoppel,
			kingofthehill,
			racingkings,
			losers,
			giveaway,
			antichess,
			extinction,
			kinglet,
			three_check,
			five_check,
			crazyhouse,
			loop,
			chessgi,
			pocketknight,
			euroshogi,
			judkinshogi,
			minishogi,
			losalamos,
			almost,
			chigorin,
			shatar
		};

		private const int PIECE_TYPE_BITS = 5;

		public enum PieceType
		{
			NO_PIECE_TYPE, 
			PAWN, 
			KNIGHT, 
			BISHOP, 
			ROOK,
			QUEEN, 
			FERS, 
			MET = FERS, 
			ALFIL, 
			SILVER, 
			KHON = SILVER,
			AIWOK, 
			BERS, 
			DRAGON = BERS, 
			CHANCELLOR,
			AMAZON, 
			KNIBIS, 
			BISKNI,
			SHOGI_PAWN, 
			LANCE, 
			SHOGI_KNIGHT,
			EUROSHOGI_KNIGHT,
			GOLD, 
			HORSE, 
			COMMONER, 
			KING,
			ALL_PIECES = 0,

			PIECE_TYPE_NB = 1 << PIECE_TYPE_BITS
		};

		public enum Piece 
		{
			NO_PIECE,
			PIECE_NB = 2 * (int)PieceType.PIECE_TYPE_NB
		};

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

			SQUARE_NB = 64
		};

		public const int MAX_MOVES = 512;
		public const int MAX_PLY   = 128;

		public enum Value : int {
			VALUE_ZERO      = 0,
			VALUE_DRAW      = 0,
			VALUE_KNOWN_WIN = 10000,
			VALUE_MATE      = 32000,
			VALUE_INFINITE  = 32001,
			VALUE_NONE      = 32002,

			VALUE_MATE_IN_MAX_PLY  =  32000 - 2 * MAX_PLY,
			VALUE_MATED_IN_MAX_PLY = -32000 + 2 * MAX_PLY,

			PawnValueMg            = 171,   PawnValueEg            = 240,
			KnightValueMg          = 764,   KnightValueEg          = 848,
			BishopValueMg          = 826,   BishopValueEg          = 891,
			RookValueMg            = 1282,  RookValueEg            = 1373,
			QueenValueMg           = 2500,  QueenValueEg           = 2670,
			FersValueMg            = 400,   FersValueEg            = 400,
			AlfilValueMg           = 300,   AlfilValueEg           = 300,
			SilverValueMg          = 600,   SilverValueEg          = 600,
			AiwokValueMg           = 2500,  AiwokValueEg           = 2500,
			BersValueMg            = 2000,  BersValueEg            = 2000,
			ChancellorValueMg      = 2500,  ChancellorValueEg      = 2500,
			AmazonValueMg          = 3000,  AmazonValueEg          = 3000,
			KnibisValueMg          = 800,   KnibisValueEg          = 800,
			BiskniValueMg          = 800,   BiskniValueEg          = 800,
			ShogiPawnValueMg       = 100,   ShogiPawnValueEg       = 100,
			LanceValueMg           = 300,   LanceValueEg           = 300,
			ShogiKnightValueMg     = 300,   ShogiKnightValueEg     = 300,
			EuroShogiKnightValueMg = 400,   EuroShogiKnightValueEg = 400,
			GoldValueMg            = 600,   GoldValueEg            = 600,
			HorseValueMg           = 1500,  HorseValueEg           = 1500,
			CommonerValueMg        = 600,   CommonerValueEg        = 600,

			MidgameLimit  = 15258, EndgameLimit  = 3915
		};

		public enum Color {
			WHITE, BLACK, COLOR_NB = 2
		};

		public static Color color_of(Piece pc) {
			if (pc == Piece.NO_PIECE || pc == Piece.PIECE_NB) {
				// Debug.LogError ("error, assert(pc != NO_PIECE)\n");
				return Color.COLOR_NB;
			}
			return (Color) ((int)pc >> PIECE_TYPE_BITS);
		}

		public enum CastlingRight {
			NO_CASTLING,
			WHITE_OO,
			WHITE_OOO = WHITE_OO << 1,
			BLACK_OO  = WHITE_OO << 2,
			BLACK_OOO = WHITE_OO << 3,
			ANY_CASTLING = WHITE_OO | WHITE_OOO | BLACK_OO | BLACK_OOO,
			CASTLING_RIGHT_NB = 16
		};

		public enum File : int {
			FILE_A, FILE_B, FILE_C, FILE_D, FILE_E, FILE_F, FILE_G, FILE_H, FILE_NB
		};

		public enum Rank : int {
			RANK_1, RANK_2, RANK_3, RANK_4, RANK_5, RANK_6, RANK_7, RANK_8, RANK_NB
		};

		public static Rank rank_of(Square s) {
			return (Rank)((int)s >> 3);
		}

		/// Score enum stores a middlegame and an endgame value in a single integer
		/// (enum). The least significant 16 bits are used to store the endgame value
		/// and the upper 16 bits are used to store the middlegame value. Take some
		/// care to avoid left-shifting a signed int to avoid undefined behavior.
		public enum Score : int { SCORE_ZERO };

		public enum MoveType {
			NORMAL,
			ENPASSANT          = 1 << 12,
			CASTLING           = 2 << 12,
			PROMOTION          = 3 << 12,
			PROMOTION_STRAIGHT = PROMOTION,
			PROMOTION_LEFT     = 4 << 12,
			PROMOTION_RIGHT    = 5 << 12,
			DROP               = 6 << 12,
			PIECE_PROMOTION    = 7 << 12,
		};
			
		public static MoveType type_of(Move m) {
			MoveType t = (MoveType)((int)m & (15 << 12));
			if (t == MoveType.PROMOTION_STRAIGHT || t == MoveType.PROMOTION_LEFT || t == MoveType.PROMOTION_RIGHT)
				return MoveType.PROMOTION;
			return t;
		}

		public static PieceType promotion_type(Move m) {
			return type_of(m) == MoveType.PROMOTION ? (PieceType)(((int)m >> 6) & 63) : PieceType.NO_PIECE_TYPE;
		}

		public static PieceType dropped_piece_type(Move m) {
			return (PieceType)(((int)m >> 6) & 63);
		}

		public static PieceType type_of(Piece pc) {
			return (PieceType)((int)pc & ((int)Common.PieceType.PIECE_TYPE_NB - 1));
		}

		#region MoveToString

		public enum Move : int {
			MOVE_NONE,
			MOVE_NULL = 65
		};

		public const int NORTH = 8;
		public const int EAST = 1;
		public const int SOUTH = -NORTH;
		public const int WEST = -EAST;

		public const int NORTH_EAST = NORTH + EAST;
		public const int SOUTH_EAST = SOUTH + EAST;
		public const int SOUTH_WEST = SOUTH + WEST;
		public const int NORTH_WEST = NORTH + WEST;

		public static Square from_sq(Move m) {
			if (type_of (m) == MoveType.DROP)
				return Square.SQ_NONE;
			if (type_of (m) == MoveType.PROMOTION) {
				Square to = to_sq (m);
				MoveType t = (MoveType)((int)m & (15 << 12));
				// Assume here that promotion occur only for relative ranks >= RANK_5.
				int up = (((int)to & 32) != 0) ? NORTH : SOUTH;
				if (t == MoveType.PROMOTION_STRAIGHT)
					return (Square)(to - up);
				if (t == MoveType.PROMOTION_LEFT)
					return (Square)(to - up - WEST);
				if (t == MoveType.PROMOTION_RIGHT)
					return (Square)(to - up - EAST);
				// assert(false);
				Debug.LogError ("error, assert(false)");
			}
			return (Square)(((int)m >> 6) & 0x3F);
		}

		public static Square to_sq(Move m) {
			return (Square)((int)m & 0x3F);
		}

		public static Square make_square(File f, Rank r) {
			return (Square)(((int)r << 3) + f);
		}

		public static Piece make_piece(Color c, PieceType pt) {
			return (Piece)(((int)c << PIECE_TYPE_BITS) + (int)pt);
		}

		static string squareToString(Square s) {
			char c1 = (char)('a' + (int)file_of (s));
			char c2 = (char)('1' + (int)rank_of (s));
			return c1.ToString() + c2.ToString ();
		}

		public static File file_of(Square s) {
			return (File)((int)s & 7);
		}

		#endregion

		public static bool isInsideBoard(int positionX, int positionY){
			if (positionX >= 0 && positionX < 8 && positionY >= 0 && positionY < 8) {
				return true;
			} else {
				Debug.LogError ("why not inside board: " + positionX + "; " + positionY);
				return false;
			}
		}

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

		public static Vector2 convertXYToLocalPosition(int x, int y)
		{
			return new Vector2 (x - 3.5f, y - 3.5f);
		}

	}
}
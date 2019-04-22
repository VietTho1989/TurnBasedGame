using UnityEngine;
using System;
using System.Collections;
using System.Reflection;
using System.Text;
using System.Collections.Generic;

namespace Seirawan
{
    public class Common
    {

        public enum Piece
        {
            NO_PIECE,

            W_PAWN = 1,
            W_KNIGHT,
            W_BISHOP,
            W_ROOK,
            W_HAWK,
            W_ELEPHANT,
            W_QUEEN,
            W_KING,

            B_PAWN = 10,
            B_KNIGHT,
            B_BISHOP,
            B_ROOK,
            B_HAWK,
            B_ELEPHANT,
            B_QUEEN,
            B_KING,

            PIECE_NB = 18
        };

        public static Common.Piece make_piece(Common.Color c, PieceType pt)
        {
            return (Common.Piece)((((int)c != 0) ? 9 : 0) + (int)pt);
        }

        public enum Square : int
        {
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

            NORTH = 8,
            EAST = 1,
            SOUTH = -8,// -NORTH,
            WEST = -1,//-EAST,

            NORTH_EAST = NORTH + EAST,
            SOUTH_EAST = SOUTH + EAST,
            SOUTH_WEST = SOUTH + WEST,
            NORTH_WEST = NORTH + WEST
        };


        public enum PieceType
        {
            NO_PIECE_TYPE,
            PAWN,
            KNIGHT,
            BISHOP,
            ROOK,
            HAWK,
            ELEPHANT,
            QUEEN,
            KING,
            ALL_PIECES = 0,
            PIECE_TYPE_NB = 9,
            NO_GATE_TYPE = ROOK
        };

        public static PieceType type_of(Piece pc)
        {
            return (PieceType)((int)pc < 9 ? pc : pc - 9);
        }

        const int MAX_MOVES = 288;
        const int MAX_PLY = 128;

        public enum Value : int
        {
            VALUE_ZERO = 0,
            VALUE_DRAW = 0,
            VALUE_KNOWN_WIN = 10000,
            VALUE_MATE = 32000,
            VALUE_INFINITE = 32001,
            VALUE_NONE = 32002,

            VALUE_MATE_IN_MAX_PLY = 32000 - 2 * MAX_PLY,
            VALUE_MATED_IN_MAX_PLY = -32000 + 2 * MAX_PLY,

            PawnValueMg = 166, PawnValueEg = 245,
            KnightValueMg = 801, KnightValueEg = 772,
            BishopValueMg = 893, BishopValueEg = 856,
            RookValueMg = 1313, RookValueEg = 1261,
            HawkValueMg = 1954, HawkValueEg = 2172,
            ElephantValueMg = 2060, ElephantValueEg = 2556,
            QueenValueMg = 2198, QueenValueEg = 2617,

            MidgameLimit = 15258, EndgameLimit = 3915
        };

        public enum Color
        {
            WHITE, BLACK, COLOR_NB = 2
        };

        public static Color color_of(Piece pc)
        {
            if (pc == Piece.NO_PIECE)
            {
                Debug.LogError("error, assert(pc != NO_PIECE)");
                return Color.WHITE;
            }
            return (int)pc >= 9 ? Color.BLACK : Color.WHITE;
        }

        #region Castle

        public enum CastlingSide
        {
            KING_SIDE, QUEEN_SIDE, CASTLING_SIDE_NB = 2
        };

        public enum CastlingRight
        {
            NO_CASTLING,
            WHITE_OO,
            WHITE_OOO = WHITE_OO << 1,
            BLACK_OO = WHITE_OO << 2,
            BLACK_OOO = WHITE_OO << 3,
            ANY_CASTLING = WHITE_OO | WHITE_OOO | BLACK_OO | BLACK_OOO,
            CASTLING_RIGHT_NB = 16
        };

        #endregion

        public enum File : int
        {
            FILE_A, FILE_B, FILE_C, FILE_D, FILE_E, FILE_F, FILE_G, FILE_H, FILE_NB
        };

        public static Common.File file_of(Common.Square s)
        {
            return (Common.File)((int)s & 7);
        }

        public enum Rank : int
        {
            RANK_1, RANK_2, RANK_3, RANK_4, RANK_5, RANK_6, RANK_7, RANK_8, RANK_NB
        };

        public static Rank rank_of(Square s)
        {
            return (Rank)((int)s >> 3);
        }

        /// Score enum stores a middlegame and an endgame value in a single integer
        /// (enum). The least significant 16 bits are used to store the endgame value
        /// and the upper 16 bits are used to store the middlegame value. Take some
        /// care to avoid left-shifting a signed int to avoid undefined behavior.
        public enum Score : int { SCORE_ZERO };

        public enum MoveType
        {
            NORMAL,
            ENPASSANT = 1 << 13,
            CASTLING = 1 << 12,
            PROMOTION = CASTLING | 8,        // The 8 is used in decoding not encoding.
            CASTLING2 = CASTLING | (1 << 13) // Not returned by type_of. Just a helper.
        };

        public static MoveType type_of(int m)
        {
            return (MoveType)(((m & (int)MoveType.CASTLING) != 0)
                ? ((m ^ (m >> 6)) & (int)MoveType.PROMOTION)
                : (m & (int)MoveType.ENPASSANT));
        }

        public static PieceType promotion_type(int m)
        {
            return (PieceType)(m >> 13);
        }

        #region MoveToString

        public enum Move : int
        {
            MOVE_NONE,
            MOVE_NULL = 65
        };

        static Square from_sq(int m)
        {
            return (Square)((m >> 6) & 0x3F);
        }

        static Square to_sq(int m)
        {
            return (Square)(m & 0x3F);
        }

        public static Square make_square(File f, Rank r)
        {
            return (Square)(((int)r << 3) + f);
        }

        #region gating

        public static bool is_normal(int m)
        {
            return !((m & (3 << 12)) != 0);
        }

        public static bool is_gating(int m)
        {
            return ((m & (3 << 14)) != 0) && (is_normal(m) || !(((m ^ (m >> 6)) & 8) != 0));
        }

        public static PieceType gating_type(int m)
        {
            if (!(type_of(m) == MoveType.NORMAL || type_of(m) == MoveType.CASTLING))
            {
                Debug.LogError("error, assert(type_of(m) == NORMAL || type_of(m) == CASTLING)");
            }
            return (PieceType)((m >> 14) + PieceType.NO_GATE_TYPE);
        }

        public static bool gating_on_to_sq(int m)
        {
            if (!(type_of(m) == MoveType.NORMAL || type_of(m) == MoveType.CASTLING))
            {
                Debug.LogError("error, assert(type_of(m) == NORMAL || type_of(m) == CASTLING)");
            }
            return (m & (1 << 13)) != 0;
        }

        #endregion

        public static string moveToString(int m, bool chess960)
        {
            Square from = from_sq(m);
            Square to = to_sq(m);

            if (m == (int)Move.MOVE_NONE)
                return "(none)";

            if (m == (int)Move.MOVE_NULL)
                return "0000";

            if (type_of(m) == MoveType.CASTLING)
            {
                if (gating_on_to_sq(m))
                {
                    from = to_sq(m);
                    to = from_sq(m);
                }

                else if (!chess960)
                    to = make_square(to > from ? File.FILE_G : File.FILE_C, rank_of(from));
            }

            string move = squareToString(from) + squareToString(to);

            string pieceChars = " pnbrheqk";
            // promotion
            if (type_of(m) == MoveType.PROMOTION)
            {
                int promotionType = (int)promotion_type(m);
                if (promotionType >= 0 && promotionType < pieceChars.Length)
                {
                    move += pieceChars[promotionType];
                }
                else
                {
                    Debug.LogError("promotionType error: " + promotionType);
                }
            }
            // gating
            else if (is_gating(m))
            {
                move += pieceChars[(int)gating_type(m)];
            }

            return move;
        }

        public static string squareToString(Square s)
        {
            char c1 = (char)('a' + (int)file_of(s));
            char c2 = (char)('1' + (int)rank_of(s));
            return c1.ToString() + c2.ToString();
        }

        #endregion

        public static int GetDistance(Common.Square ori, Common.Square dest)
        {
            File oriFile = Common.file_of(ori);
            Rank oriRank = Common.rank_of(ori);
            File destFile = Common.file_of(dest);
            Rank destRank = Common.rank_of(dest);
            return Mathf.Abs(destFile - oriFile) + Mathf.Abs(destRank - oriRank);
        }

        public static void convertLocalPositionToXY(Vector3 localPosition, out int x, out int y)
        {
            x = Mathf.RoundToInt(localPosition.x + 3.5f);
            y = Mathf.RoundToInt(localPosition.y + 3.5f);
        }

        public static Vector3 convertXYToLocalPosition(int x, int y)
        {
            return new Vector3(x - 3.5f, y - 3.5f, 0);
        }

    }
}
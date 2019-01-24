/*
  Stockfish, a UCI chess playing engine derived from Glaurung 2.1
  Copyright (C) 2004-2008 Tord Romstad (Glaurung author)
  Copyright (C) 2008-2015 Marco Costalba, Joona Kiiski, Tord Romstad
  Copyright (C) 2015-2018 Marco Costalba, Joona Kiiski, Gary Linscott, Tord Romstad

  Stockfish is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  Stockfish is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

#ifndef SEIRAWAN_TYPES_H_INCLUDED
#define SEIRAWAN_TYPES_H_INCLUDED

/// When compiling with provided Makefile (e.g. for Linux and OSX), configuration
/// is done automatically. To get started type 'make help'.
///
/// When Makefile is not used (e.g. with Microsoft Visual Studio) some switches
/// need to be set manually:
///
/// -DNDEBUG      | Disable debugging mode. Always use this for release.
///
/// -DNO_PREFETCH | Disable use of prefetch asm-instruction. You may need this to
///               | run on some very old machines.
///
/// -DUSE_POPCNT  | Add runtime support for use of popcnt asm-instruction. Works
///               | only in 64-bit mode and requires hardware with popcnt support.
///
/// -DUSE_PEXT    | Add runtime support for use of pext asm-instruction. Works
///               | only in 64-bit mode and requires hardware with pext support.

#include <cassert>
#include <cctype>
#include <climits>
#include <cstdint>
#include <cstdlib>

namespace Seirawan
{
    
#if defined(_MSC_VER)
    // Disable some silly and noisy warning from MSVC compiler
#pragma warning(disable: 4127) // Conditional expression is constant
#pragma warning(disable: 4146) // Unary minus operator applied to unsigned type
#pragma warning(disable: 4800) // Forcing value to bool 'true' or 'false'
#endif
    
    /// Predefined macros hell:
    ///
    /// __GNUC__           Compiler is gcc, Clang or Intel on Linux
    /// __INTEL_COMPILER   Compiler is Intel
    /// _MSC_VER           Compiler is MSVC or Intel on Windows
    /// _WIN32             Building on Windows (any)
    /// _WIN64             Building on Windows 64 bit
    
#if defined(_WIN64) && defined(_MSC_VER) // No Makefile used
#  include <intrin.h> // Microsoft header for _BitScanForward64()
#  define IS_64BIT
#endif
    
#if defined(USE_POPCNT) && (defined(__INTEL_COMPILER) || defined(_MSC_VER))
#  include <nmmintrin.h> // Intel and Microsoft header for _mm_popcnt_u64()
#endif
    
#if !defined(NO_PREFETCH) && (defined(__INTEL_COMPILER) || defined(_MSC_VER))
#  include <xmmintrin.h> // Intel and Microsoft header for _mm_prefetch()
#endif
    
#if defined(USE_PEXT)
#  include <immintrin.h> // Header for _pext_u64() intrinsic
#  define pext(b, m) _pext_u64(b, m)
#else
#  define pext(b, m) 0
#endif
    
#ifdef USE_POPCNT
    const bool HasPopCnt = true;
#else
    const bool HasPopCnt = false;
#endif
    
#ifdef USE_PEXT
    const bool HasPext = true;
#else
    const bool HasPext = false;
#endif
    
#ifdef IS_64BIT
    const bool Is64Bit = true;
#else
    const bool Is64Bit = false;
#endif
    
    typedef uint64_t Key;
    typedef uint64_t Bitboard;
    
    const int32_t MAX_MOVES = 288;
    const int32_t MAX_PLY   = 128;
    
    /// A move needs 16 bits to be stored
    ///
    /// bit  0- 5: destination square (from 0 to 63)
    /// bit  6-11: origin square (from 0 to 63)
    /// bit 12-15: special bits as described below
    ///
    /// NORMAL moves have bits 12 and 13 set to 0. We encode gating of HAWK,
    /// ELEPHANT or QUEEN by adding (gated piece type - ROOK) in bits 14-15.
    ///
    /// ENPASSANT moves are encoded with bit 13 set to 1 and bit 12 set to 0.
    /// NOTE: ENPASSANT is set only when a pawn can be captured.
    ///
    /// PROMOTION and CASTLING moves have bit 12 set. We distinguish between
    /// promotions and castlings by checking the parities of the ranks of the to
    /// and from square. If they are different it is a PROMOTION otherwise it is
    /// a CASTLING. For technical reasons we do this test in bit 3 so it is
    /// convenient to set CASTLING = 1 << 12 and PROMOTION = CASTLING | 8.
    ///
    /// With promotions and castlings we have bits 13-15 free to store further
    /// information. For promotions we use these bits to encode the promotion
    /// type ranging from 2 for KNIGHT up to 7 for QUEEN. With castling moves we
    /// set bit 13 if gating takes place on the square of the rook. We encode
    /// the gated piece just as for NORMAL moves.
    ///
    /// Special cases are MOVE_NONE and MOVE_NULL. We can sneak these in because in
    /// any normal move destination square is always different from origin square
    /// while MOVE_NONE and MOVE_NULL have the same origin and destination square.
    
    enum Move : int32_t {
        MOVE_NONE,
        MOVE_NULL = 65
    };
    
    enum MoveType {
        NORMAL,
        ENPASSANT = 1 << 13,
        CASTLING  = 1 << 12,
        PROMOTION = CASTLING | 8,        // The 8 is used in decoding not encoding.
        CASTLING2 = CASTLING | (1 << 13) // Not returned by type_of. Just a helper.
    };
    
    enum Color {
        WHITE, BLACK, COLOR_NB = 2
    };
    
    enum CastlingSide {
        KING_SIDE, QUEEN_SIDE, CASTLING_SIDE_NB = 2
    };
    
    enum CastlingRight {
        NO_CASTLING,
        WHITE_OO,
        WHITE_OOO = WHITE_OO << 1,
        BLACK_OO  = WHITE_OO << 2,
        BLACK_OOO = WHITE_OO << 3,
        ANY_CASTLING = WHITE_OO | WHITE_OOO | BLACK_OO | BLACK_OOO,
        CASTLING_RIGHT_NB = 16
    };
    
    template<Color C, CastlingSide S> struct MakeCastling {
        static constexpr CastlingRight
        right = C == WHITE ? S == QUEEN_SIDE ? WHITE_OOO : WHITE_OO
        : S == QUEEN_SIDE ? BLACK_OOO : BLACK_OO;
    };
    
    enum Phase {
        PHASE_ENDGAME,
        PHASE_MIDGAME = 128,
        MG = 0, EG = 1, PHASE_NB = 2
    };
    
    enum ScaleFactor {
        SCALE_FACTOR_DRAW    = 0,
        SCALE_FACTOR_ONEPAWN = 48,
        SCALE_FACTOR_NORMAL  = 64,
        SCALE_FACTOR_MAX     = 128,
        SCALE_FACTOR_NONE    = 255
    };
    
    enum Bound {
        BOUND_NONE,
        BOUND_UPPER,
        BOUND_LOWER,
        BOUND_EXACT = BOUND_UPPER | BOUND_LOWER
    };
    
    enum Value : int32_t {
        VALUE_ZERO      = 0,
        VALUE_DRAW      = 0,
        VALUE_KNOWN_WIN = 10000,
        VALUE_MATE      = 32000,
        VALUE_INFINITE  = 32001,
        VALUE_NONE      = 32002,
        
        VALUE_MATE_IN_MAX_PLY  =  VALUE_MATE - 2 * MAX_PLY,
        VALUE_MATED_IN_MAX_PLY = -VALUE_MATE + 2 * MAX_PLY,
        
        PawnValueMg     = 166,   PawnValueEg     = 245,
        KnightValueMg   = 801,   KnightValueEg   = 772,
        BishopValueMg   = 893,   BishopValueEg   = 856,
        RookValueMg     = 1313,  RookValueEg     = 1261,
        HawkValueMg     = 1954,  HawkValueEg     = 2172,
        ElephantValueMg = 2060,  ElephantValueEg = 2556,
        QueenValueMg    = 2198,  QueenValueEg    = 2617,
        
        MidgameLimit  = 15258, EndgameLimit  = 3915
    };
    
    enum PieceType {
        NO_PIECE_TYPE, PAWN, KNIGHT, BISHOP, ROOK, HAWK, ELEPHANT, QUEEN, KING,
        ALL_PIECES = 0,
        PIECE_TYPE_NB = 9,
        NO_GATE_TYPE = ROOK
    };
    
    enum Piece {
        NO_PIECE,
        W_PAWN = 1,  W_KNIGHT, W_BISHOP, W_ROOK, W_HAWK, W_ELEPHANT, W_QUEEN, W_KING,
        B_PAWN = 10, B_KNIGHT, B_BISHOP, B_ROOK, B_HAWK, B_ELEPHANT, B_QUEEN, B_KING,
        PIECE_NB = 18
    };
    
    extern Value PieceValue[PHASE_NB][PIECE_NB];
    
    enum Depth : int32_t {
        
        ONE_PLY = 1,
        
        DEPTH_ZERO          =  0 * ONE_PLY,
        DEPTH_QS_CHECKS     =  0 * ONE_PLY,
        DEPTH_QS_NO_CHECKS  = -1 * ONE_PLY,
        DEPTH_QS_RECAPTURES = -5 * ONE_PLY,
        
        DEPTH_NONE = -6 * ONE_PLY,
        DEPTH_MAX  = MAX_PLY * ONE_PLY
    };
    
    // static_assert(!(ONE_PLY & (ONE_PLY - 1)), "ONE_PLY is not a power of 2");
    
    enum Square : int32_t
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
        
        SQUARE_NB = 64
    };
    
    enum Direction : int32_t {
        NORTH =  8,
        EAST  =  1,
        SOUTH = -NORTH,
        WEST  = -EAST,
        
        NORTH_EAST = NORTH + EAST,
        SOUTH_EAST = SOUTH + EAST,
        SOUTH_WEST = SOUTH + WEST,
        NORTH_WEST = NORTH + WEST
    };
    
    enum File : int32_t {
        FILE_A, FILE_B, FILE_C, FILE_D, FILE_E, FILE_F, FILE_G, FILE_H, FILE_NB
    };
    
    enum Rank : int32_t {
        RANK_1, RANK_2, RANK_3, RANK_4, RANK_5, RANK_6, RANK_7, RANK_8, RANK_NB
    };
    
    
    /// Score enum stores a middlegame and an endgame value in a single integer
    /// (enum). The least significant 16 bits are used to store the endgame value
    /// and the upper 16 bits are used to store the middlegame value. Take some
    /// care to avoid left-shifting a signed int to avoid undefined behavior.
    enum Score : int32_t { SCORE_ZERO };
    
    extern Score PieceScore[PIECE_TYPE_NB];
    
    constexpr Score make_score(int32_t mg, int32_t eg) {
        return Score((int32_t)((unsigned int)eg << 16) + mg);
    }
    
    /// Extracting the signed lower and upper 16 bits is not so trivial because
    /// according to the standard a simple cast to short is implementation defined
    /// and so is a right shift of a signed integer.
    inline Value eg_value(Score s) {
        union { uint16_t u; int16_t s; } eg = { uint16_t(unsigned(s + 0x8000) >> 16) };
        return Value(eg.s);
    }
    
    inline Value mg_value(Score s) {
        union { uint16_t u; int16_t s; } mg = { uint16_t(unsigned(s)) };
        return Value(mg.s);
    }
    
#define ENABLE_BASE_OPERATORS_ON(T)                                \
constexpr T operator+(T d1, T d2) { return T(int(d1) + int(d2)); } \
constexpr T operator-(T d1, T d2) { return T(int(d1) - int(d2)); } \
constexpr T operator-(T d) { return T(-int(d)); }                  \
inline T& operator+=(T& d1, T d2) { return d1 = d1 + d2; }         \
inline T& operator-=(T& d1, T d2) { return d1 = d1 - d2; }
    
#define ENABLE_INCR_OPERATORS_ON(T)                                \
inline T& operator++(T& d) { return d = T(int(d) + 1); }           \
inline T& operator--(T& d) { return d = T(int(d) - 1); }
    
#define ENABLE_FULL_OPERATORS_ON(T)                                \
ENABLE_BASE_OPERATORS_ON(T)                                        \
ENABLE_INCR_OPERATORS_ON(T)                                        \
constexpr T operator*(int32_t i, T d) { return T(i * int32_t(d)); }        \
constexpr T operator*(T d, int32_t i) { return T(int32_t(d) * i); }        \
constexpr T operator/(T d, int32_t i) { return T(int32_t(d) / i); }        \
constexpr int32_t operator/(T d1, T d2) { return int32_t(d1) / int32_t(d2); }  \
inline T& operator*=(T& d, int32_t i) { return d = T(int32_t(d) * i); }    \
inline T& operator/=(T& d, int32_t i) { return d = T(int32_t(d) / i); }
    
    ENABLE_FULL_OPERATORS_ON(Value)
    ENABLE_FULL_OPERATORS_ON(Depth)
    ENABLE_FULL_OPERATORS_ON(Direction)
    
    ENABLE_INCR_OPERATORS_ON(PieceType)
    ENABLE_INCR_OPERATORS_ON(Piece)
    ENABLE_INCR_OPERATORS_ON(Color)
    ENABLE_INCR_OPERATORS_ON(Square)
    ENABLE_INCR_OPERATORS_ON(File)
    ENABLE_INCR_OPERATORS_ON(Rank)
    
    ENABLE_BASE_OPERATORS_ON(Score)
    
#undef ENABLE_FULL_OPERATORS_ON
#undef ENABLE_INCR_OPERATORS_ON
#undef ENABLE_BASE_OPERATORS_ON
    
    /// Additional operators to add integers to a Value
    constexpr Value operator+(Value v, int32_t i) { return Value(int32_t(v) + i); }
    constexpr Value operator-(Value v, int32_t i) { return Value(int32_t(v) - i); }
    inline Value& operator+=(Value& v, int32_t i) { return v = v + i; }
    inline Value& operator-=(Value& v, int32_t i) { return v = v - i; }
    
    /// Additional operators to add a Direction to a Square
    inline Square operator+(Square s, Direction d) { return Square(int32_t(s) + int32_t(d)); }
    inline Square operator-(Square s, Direction d) { return Square(int32_t(s) - int32_t(d)); }
    inline Square& operator+=(Square &s, Direction d) { return s = s + d; }
    inline Square& operator-=(Square &s, Direction d) { return s = s - d; }
    
    /// Only declared but not defined. We don't want to multiply two scores due to
    /// a very high risk of overflow. So user should explicitly convert to integer.
    Score operator*(Score, Score) = delete;
    
    /// Division of a Score must be handled separately for each term
    inline Score operator/(Score s, int32_t i) {
        return make_score(mg_value(s) / i, eg_value(s) / i);
    }
    
    /// Multiplication of a Score by an integer. We check for overflow in debug mode.
    inline Score operator*(Score s, int32_t i) {
        
        Score result = Score(int32_t(s) * i);
        
        // assert(eg_value(result) == (i * eg_value(s)));
        if(eg_value(result) != (i * eg_value(s))){
            printf("error, assert(eg_value(result) == (i * eg_value(s)))\n");
        }
        // assert(mg_value(result) == (i * mg_value(s)));
        if(mg_value(result) != (i * mg_value(s))){
            printf("error, assert(mg_value(result) == (i * mg_value(s)))\n");
        }
        // assert((i == 0) || (result / i) == s );
        if(!((i == 0) || (result / i) == s)){
            printf("error, assert((i == 0) || (result / i) == s )\n");
        }
        
        return result;
    }
    
    constexpr Color operator~(Color c) {
        return Color(c ^ BLACK); // Toggle color
    }
    
    constexpr Square operator~(Square s) {
        return Square(s ^ SQ_A8); // Vertical flip SQ_A1 -> SQ_A8
    }
    
    constexpr File operator~(File f) {
        return File(f ^ FILE_H); // Horizontal flip FILE_A -> FILE_H
    }
    
    constexpr Piece operator~(Piece pc) {
        return Piece(pc < 9 ? pc + 9 : pc - 9); // Swap color of piece B_KNIGHT -> W_KNIGHT
    }
    
    constexpr CastlingRight operator|(Color c, CastlingSide s) {
        return CastlingRight(WHITE_OO << ((s == QUEEN_SIDE) + 2 * c));
    }
    
    constexpr Value mate_in(int32_t ply) {
        return VALUE_MATE - ply;
    }
    
    constexpr Value mated_in(int32_t ply) {
        return -VALUE_MATE + ply;
    }
    
    constexpr Square make_square(File f, Rank r) {
        return Square((r << 3) + f);
    }
    
    constexpr Piece make_piece(Color c, PieceType pt) {
        return Piece((c ? 9 : 0) + pt);
    }
    
    constexpr PieceType type_of(Piece pc) {
        return PieceType(pc < 9 ? pc : pc - 9);
    }
    
    inline Color color_of(Piece pc) {
        // assert(pc != NO_PIECE);
        if(pc == NO_PIECE){
            printf("error, assert(pc != NO_PIECE)\n");
        }
        return Color(pc >= 9);
    }
    
    constexpr bool is_ok(Square s) {
        return s >= SQ_A1 && s <= SQ_H8;
    }
    
    constexpr File file_of(Square s) {
        return File(s & 7);
    }
    
    constexpr Rank rank_of(Square s) {
        return Rank(s >> 3);
    }
    
    constexpr Square relative_square(Color c, Square s) {
        return Square(s ^ (c * 56));
    }
    
    constexpr Rank relative_rank(Color c, Rank r) {
        return Rank(r ^ (c * 7));
    }
    
    constexpr Rank relative_rank(Color c, Square s) {
        return relative_rank(c, rank_of(s));
    }
    
    inline bool opposite_colors(Square s1, Square s2) {
        int32_t s = int32_t(s1) ^ int32_t(s2);
        return ((s >> 3) ^ s) & 1;
    }
    
    constexpr Direction pawn_push(Color c) {
        return c == WHITE ? NORTH : SOUTH;
    }
    
    constexpr Square from_sq(Move m) {
        return Square((m >> 6) & 0x3F);
    }
    
    constexpr Square to_sq(Move m) {
        return Square(m & 0x3F);
    }
    
    constexpr int32_t from_to(Move m) {
        return m & 0xFFF;
    }
    
    constexpr MoveType type_of(Move m) {
        // If the conditional is true we return either CASTLING
        // or PROMOTION, otherwise we return NORMAL or ENPASSANT.
        return MoveType(m & CASTLING ? (m ^ (m >> 6)) & PROMOTION : m & ENPASSANT);
    }
    
    constexpr bool is_normal(Move m) {
        return !(m & (3 << 12));
    }
    
    inline PieceType promotion_type(Move m) {
        // assert(type_of(m) == PROMOTION);
        if(type_of(m) != PROMOTION){
            printf("error, assert(type_of(m) == PROMOTION)\n");
        }
        return PieceType(m >> 13);
    }
    
    constexpr bool is_gating(Move m) {
        return (m & (3 << 14)) && (is_normal(m) || !((m ^ (m >> 6)) & 8));
    }
    
    inline PieceType gating_type(Move m) {
        // assert(type_of(m) == NORMAL || type_of(m) == CASTLING);
        if(!(type_of(m) == NORMAL || type_of(m) == CASTLING)){
            printf("error, assert(type_of(m) == NORMAL || type_of(m) == CASTLING)\n");
        }
        return PieceType((m >> 14) + NO_GATE_TYPE);
    }
    
    inline bool gating_on_to_sq(Move m) {
        // assert(type_of(m) == NORMAL || type_of(m) == CASTLING);
        if(!(type_of(m) == NORMAL || type_of(m) == CASTLING)){
            printf("error, assert(type_of(m) == NORMAL || type_of(m) == CASTLING)\n");
        }
        return m & (1 << 13);
    }
    
    constexpr Move make_move(Square from, Square to) {
        return Move((from << 6) + to);
    }
    
    template<MoveType T>
    inline Move make(Square from, Square to, PieceType pt = NO_GATE_TYPE) {
        int32_t      Shift = T == PROMOTION ? 13 : 14;
        PieceType Base = T == PROMOTION ? NO_PIECE_TYPE : NO_GATE_TYPE;
        return Move((T & (3 << 12)) + ((pt - Base) << Shift) + (from << 6) + to);
    }
    
    constexpr bool is_ok(Move m) {
        return from_sq(m) != to_sq(m); // Catch MOVE_NULL and MOVE_NONE
    }
    
}

#endif // #ifndef TYPES_H_INCLUDED

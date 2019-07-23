//
//  types.h
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef types_hpp
#define types_hpp

#include <cassert>
#include <cctype>
#include <climits>
#include <cstdint>
#include <cstdlib>

namespace Shatranj
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
    
    const int32_t MAX_MOVES = 256;
    const int32_t MAX_PLY   = 128;
    
    /// A move needs 16 bits to be stored
    ///
    /// bit  0- 5: destination square (from 0 to 63)
    /// bit  6-11: origin square (from 0 to 63)
    /// bit 12-13: promotion piece type - 2 (from BISHOP-2 to ROOK-2)
    /// bit 14-15: special move flag: promotion (1)
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
        PROMOTION = 1 << 14
    };
    
    enum Color {
        WHITE, BLACK, COLOR_NB = 2
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
        
        PawnValueMg   = 175,   PawnValueEg   = 231,
        BishopValueMg = 332,   BishopValueEg = 337,
        QueenValueMg  = 417,   QueenValueEg  = 540,
        KnightValueMg = 877,   KnightValueEg = 1110,
        RookValueMg   = 1337,  RookValueEg   = 1965,
        
        MidgameLimit  = 15258, EndgameLimit  = 3915
    };
    
    enum PieceType {
        NO_PIECE_TYPE, PAWN, BISHOP, QUEEN, KNIGHT, ROOK, KING,
        ALL_PIECES = 0,
        PIECE_TYPE_NB = 8
    };
    
    enum Piece {
        NO_PIECE,
        W_PAWN = 1, W_BISHOP, W_QUEEN, W_KNIGHT, W_ROOK, W_KING,
        B_PAWN = 9, B_BISHOP, B_QUEEN, B_KNIGHT, B_ROOK, B_KING,
        PIECE_NB = 16
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
    
    enum Square {
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
    
    inline Score make_score(int32_t mg, int32_t eg) {
        return Score((int32_t)((uint32_t)eg << 16) + mg);
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
    
#define ENABLE_BASE_OPERATORS_ON(T)                             \
inline T operator+(T d1, T d2) { return T(int(d1) + int(d2)); } \
inline T operator-(T d1, T d2) { return T(int(d1) - int(d2)); } \
inline T operator-(T d) { return T(-int(d)); }                  \
inline T& operator+=(T& d1, T d2) { return d1 = d1 + d2; }      \
inline T& operator-=(T& d1, T d2) { return d1 = d1 - d2; }      \

#define ENABLE_FULL_OPERATORS_ON(T)                             \
ENABLE_BASE_OPERATORS_ON(T)                                     \
inline T operator*(int32_t i, T d) { return T(i * int32_t(d)); }        \
inline T operator*(T d, int32_t i) { return T(int32_t(d) * i); }        \
inline T& operator++(T& d) { return d = T(int32_t(d) + 1); }        \
inline T& operator--(T& d) { return d = T(int32_t(d) - 1); }        \
inline T operator/(T d, int32_t i) { return T(int32_t(d) / i); }        \
inline int32_t operator/(T d1, T d2) { return int32_t(d1) / int32_t(d2); }  \
inline T& operator*=(T& d, int32_t i) { return d = T(int32_t(d) * i); } \
inline T& operator/=(T& d, int32_t i) { return d = T(int32_t(d) / i); }
    
    ENABLE_FULL_OPERATORS_ON(Value)
    ENABLE_FULL_OPERATORS_ON(PieceType)
    ENABLE_FULL_OPERATORS_ON(Piece)
    ENABLE_FULL_OPERATORS_ON(Color)
    ENABLE_FULL_OPERATORS_ON(Depth)
    ENABLE_FULL_OPERATORS_ON(Square)
    ENABLE_FULL_OPERATORS_ON(File)
    ENABLE_FULL_OPERATORS_ON(Rank)
    
    ENABLE_BASE_OPERATORS_ON(Score)
    
#undef ENABLE_FULL_OPERATORS_ON
#undef ENABLE_BASE_OPERATORS_ON
    
    /// Additional operators to add integers to a Value
    inline Value operator+(Value v, int32_t i) { return Value(int32_t(v) + i); }
    inline Value operator-(Value v, int32_t i) { return Value(int32_t(v) - i); }
    inline Value& operator+=(Value& v, int32_t i) { return v = v + i; }
    inline Value& operator-=(Value& v, int32_t i) { return v = v - i; }
    
    /// Only declared but not defined. We don't want to multiply two scores due to
    /// a very high risk of overflow. So user should explicitly convert to integer.
    inline Score operator*(Score s1, Score s2);
    
    /// Division of a Score must be handled separately for each term
    inline Score operator/(Score s, int32_t i) {
        return make_score(mg_value(s) / i, eg_value(s) / i);
    }
    
    /// Multiplication of a Score by an integer. We check for overflow in debug mode.
    inline Score operator*(Score s, int32_t i) {
        
        Score result = Score(int32_t(s) * i);
        
        // assert(eg_value(result) == (i * eg_value(s)));
        if(!(eg_value(result) == (i * eg_value(s)))){
            printf("error, assert(eg_value(result) == (i * eg_value(s)))\n");
        }
        // assert(mg_value(result) == (i * mg_value(s)));
        if(!(mg_value(result) == (i * mg_value(s)))){
            printf("error, assert(mg_value(result) == (i * mg_value(s)))\n");
        }
        // assert((i == 0) || (result / i) == s );
        if(!((i == 0) || (result / i) == s)){
            printf("error, assert((i == 0) || (result / i) == s )\n");
        }
        
        return result;
    }
    
    inline Color operator~(Color c) {
        return Color(c ^ BLACK); // Toggle color
    }
    
    inline Square operator~(Square s) {
        return Square(s ^ SQ_A8); // Vertical flip SQ_A1 -> SQ_A8
    }
    
    inline Piece operator~(Piece pc) {
        return Piece(pc ^ 8); // Swap color of piece B_KNIGHT -> W_KNIGHT
    }
    
    inline Value mate_in(int32_t ply) {
        return VALUE_MATE - ply;
    }
    
    inline Value mated_in(int32_t ply) {
        return -VALUE_MATE + ply;
    }
    
    inline Square make_square(File f, Rank r) {
        return Square((r << 3) + f);
    }
    
    inline Piece make_piece(Color c, PieceType pt) {
        return Piece((c << 3) + pt);
    }
    
    inline PieceType type_of(Piece pc) {
        return PieceType(pc & 7);
    }
    
    inline Color color_of(Piece pc) {
        // assert(pc != NO_PIECE);
        if(!(pc != NO_PIECE)){
            printf("error, assert(pc != NO_PIECE)\n");
        }
        return Color(pc >> 3);
    }
    
    inline bool is_ok(Square s) {
        return s >= SQ_A1 && s <= SQ_H8;
    }
    
    inline File file_of(Square s) {
        return File(s & 7);
    }
    
    inline Rank rank_of(Square s) {
        return Rank(s >> 3);
    }
    
    inline Square relative_square(Color c, Square s) {
        return Square(s ^ (c * 56));
    }
    
    inline Rank relative_rank(Color c, Rank r) {
        return Rank(r ^ (c * 7));
    }
    
    inline Rank relative_rank(Color c, Square s) {
        return relative_rank(c, rank_of(s));
    }
    
    inline bool opposite_colors(Square s1, Square s2) {
        int32_t s = int32_t(s1) ^ int32_t(s2);
        return ((s >> 3) ^ s) & 1;
    }
    
    inline Square pawn_push(Color c) {
        return c == WHITE ? NORTH : SOUTH;
    }
    
    inline Square from_sq(Move m) {
        return Square((m >> 6) & 0x3F);
    }
    
    inline Square to_sq(Move m) {
        return Square(m & 0x3F);
    }
    
    inline int32_t from_to(Move m) {
        return m & 0xFFF;
    }
    
    inline MoveType type_of(Move m) {
        return MoveType(m & (3 << 14));
    }
    
    inline PieceType promotion_type(Move m) {
        return PieceType(((m >> 12) & 3) + BISHOP);
    }
    
    inline Move make_move(Square from, Square to) {
        return Move((from << 6) + to);
    }
    
    template<MoveType T>
    inline Move make(Square from, Square to, PieceType pt = BISHOP) {
        return Move(T + ((pt - BISHOP) << 12) + (from << 6) + to);
    }
    
    inline bool is_ok(Move m) {
        return from_sq(m) != to_sq(m); // Catch MOVE_NULL and MOVE_NONE
    }
}

#endif /* types_hpp */

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

#include <algorithm>

#include "fairy_chess_bitboard.hpp"
#include "fairy_chess_misc.hpp"

using namespace std;

namespace FairyChess
{
    uint8_t PopCnt16[1 << 16];
    int32_t SquareDistance[SQUARE_NB][SQUARE_NB];
    
    Bitboard BoardSizeBB[FILE_NB][RANK_NB];
    Bitboard SquareBB[SQUARE_NB];
    Bitboard FileBB[FILE_NB];
    Bitboard RankBB[RANK_NB];
    Bitboard AdjacentFilesBB[FILE_NB];
    Bitboard ForwardRanksBB[COLOR_NB][RANK_NB];
    Bitboard BetweenBB[SQUARE_NB][SQUARE_NB];
    Bitboard LineBB[SQUARE_NB][SQUARE_NB];
    Bitboard DistanceRingBB[SQUARE_NB][8];
    Bitboard ForwardFileBB[COLOR_NB][SQUARE_NB];
    Bitboard PassedPawnMask[COLOR_NB][SQUARE_NB];
    Bitboard PawnAttackSpan[COLOR_NB][SQUARE_NB];
    Bitboard PseudoAttacks[COLOR_NB][PIECE_TYPE_NB][SQUARE_NB];
    Bitboard PseudoMoves[COLOR_NB][PIECE_TYPE_NB][SQUARE_NB];
    Bitboard LeaperAttacks[COLOR_NB][PIECE_TYPE_NB][SQUARE_NB];
    Bitboard LeaperMoves[COLOR_NB][PIECE_TYPE_NB][SQUARE_NB];
    
    Magic RookMagics[SQUARE_NB];
    Magic BishopMagics[SQUARE_NB];
    
    namespace {
        
        Bitboard RookTable[0x19000];  // To store rook attacks
        Bitboard BishopTable[0x1480]; // To store bishop attacks
        
        void init_magics(Bitboard table[], Magic magics[], Direction directions[]);
        
        // popcount16() counts the non-zero bits using SWAR-Popcount algorithm
        
        unsigned popcount16(unsigned u) {
            u -= (u >> 1) & 0x5555U;
            u = ((u >> 2) & 0x3333U) + (u & 0x3333U);
            u = ((u >> 4) + u) & 0x0F0FU;
            return (u * 0x0101U) >> 8;
        }
        
        Bitboard sliding_attack(Direction directions[], Square sq, Bitboard occupied, int32_t maxDist = 7) {
            
            Bitboard attack = 0;
            
            for (int32_t i = 0; directions[i]; ++i)
                for (Square s = sq + directions[i];
                     is_ok(s) && distance(s, s - directions[i]) == 1 && distance(s, sq) <= maxDist;
                     s += directions[i])
                {
                    attack |= s;
                    
                    if (occupied & s)
                        break;
                }
            
            return attack;
        }
    }
    
    
    /// Bitboards::pretty() returns an ASCII representation of a bitboard suitable
    /// to be printed to standard output. Useful for debugging.
    
    const std::string Bitboards::pretty(Bitboard b) {
        
        std::string s = "+---+---+---+---+---+---+---+---+\n";
        
        for (Rank r = RANK_8; r >= RANK_1; --r)
        {
            for (File f = FILE_A; f <= FILE_H; ++f)
                s += b & make_square(f, r) ? "| X " : "|   ";
            
            s += "|\n+---+---+---+---+---+---+---+---+\n";
        }
        
        return s;
    }
    
    
    /// Bitboards::init() initializes various bitboard tables. It is called at
    /// startup and relies on global objects to be already zero-initialized.
    
    void Bitboards::init() {
        
        for (unsigned i = 0; i < (1 << 16); ++i)
            PopCnt16[i] = (uint8_t) popcount16(i);
        
        for (Square s = SQ_A1; s <= SQ_H8; ++s)
            SquareBB[s] = make_bitboard(s);
        
        for (File f = FILE_A; f <= FILE_H; ++f)
            FileBB[f] = f > FILE_A ? FileBB[f - 1] << 1 : FileABB;
        
        for (Rank r = RANK_1; r <= RANK_8; ++r)
            RankBB[r] = r > RANK_1 ? RankBB[r - 1] << 8 : Rank1BB;
        
        for (File f = FILE_A; f <= FILE_H; ++f)
            AdjacentFilesBB[f] = (f > FILE_A ? FileBB[f - 1] : 0) | (f < FILE_H ? FileBB[f + 1] : 0);
        
        for (Rank r = RANK_1; r < RANK_8; ++r)
            ForwardRanksBB[WHITE][r] = ~(ForwardRanksBB[BLACK][r + 1] = ForwardRanksBB[BLACK][r] | RankBB[r]);
        
        for (Color c = WHITE; c <= BLACK; ++c)
            for (Square s = SQ_A1; s <= SQ_H8; ++s)
            {
                ForwardFileBB [c][s] = ForwardRanksBB[c][rank_of(s)] & FileBB[file_of(s)];
                PawnAttackSpan[c][s] = ForwardRanksBB[c][rank_of(s)] & AdjacentFilesBB[file_of(s)];
                PassedPawnMask[c][s] = ForwardFileBB [c][s] | PawnAttackSpan[c][s];
            }
        
        for (File f = FILE_A; f <= FILE_H; ++f)
            for (Rank r = RANK_1; r <= RANK_8; ++r)
                BoardSizeBB[f][r] = ForwardFileBB[BLACK][make_square(f, r)] | SquareBB[make_square(f, r)] | (f > FILE_A ? BoardSizeBB[f - 1][r] : 0);
        
        for (Square s1 = SQ_A1; s1 <= SQ_H8; ++s1)
            for (Square s2 = SQ_A1; s2 <= SQ_H8; ++s2)
                if (s1 != s2)
                {
                    SquareDistance[s1][s2] = max(distanceT<File>(s1, s2), distanceT<Rank>(s1, s2));
                    DistanceRingBB[s1][SquareDistance[s1][s2] - 1] |= s2;
                }
        
        // Piece moves
        Direction RookDirections[5] = { NORTH,  EAST,  SOUTH,  WEST };
        Direction BishopDirections[5] = { NORTH_EAST, SOUTH_EAST, SOUTH_WEST, NORTH_WEST };
        
        init_magics(RookTable, RookMagics, RookDirections);
        init_magics(BishopTable, BishopMagics, BishopDirections);

        int32_t stepsCapture[][13] = {
            {}, // NO_PIECE_TYPE
            { 7, 9 }, // pawn
            { -17, -15, -10, -6, 6, 10, 15, 17 }, // knight
            {}, // bishop
            {}, // rook
            {}, // queen
            { -9, -7, 7, 9 }, // fers/met
            { -18, -14, 14, 18 }, // alfil
            { -9, -7, 7, 8, 9 }, // silver/khon
            { -17, -15, -10, -9, -7, -6, 6, 7, 9, 10, 15, 17 }, // aiwok
            { -9, -7, 7, 9 }, // bers/dragon
            { -17, -15, -10, -6, 6, 10, 15, 17 }, // chancellor
            { -17, -15, -10, -6, 6, 10, 15, 17 }, // amazon
            {}, // knibis
            { -17, -15, -10, -6, 6, 10, 15, 17 }, // biskni
            { 8 }, // shogi pawn
            {}, // lance
            { 15, 17 }, // shogi knight
            { -1, 1, 15, 17 }, // euroshogi knight
            { -8, -1, 1, 7, 8, 9 }, // gold
            { -8, -1, 1, 8 }, // horse
            { -9, -8, -7, -1, 1, 7, 8, 9 }, // commoner
            { -9, -8, -7, -1, 1, 7, 8, 9 } // king
        };
        int32_t stepsQuiet[][13] = {
            {}, // NO_PIECE_TYPE
            { 8 }, // pawn
            { -17, -15, -10, -6, 6, 10, 15, 17 }, // knight
            {}, // bishop
            {}, // rook
            {}, // queen
            { -9, -7, 7, 9 }, // fers/met
            { -18, -14, 14, 18 }, // alfil
            { -9, -7, 7, 8, 9 }, // silver/khon
            { -17, -15, -10, -9, -7, -6, 6, 7, 9, 10, 15, 17 }, // aiwok
            { -9, -7, 7, 9 }, // bers/dragon
            { -17, -15, -10, -6, 6, 10, 15, 17 }, // chancellor
            { -17, -15, -10, -6, 6, 10, 15, 17 }, // amazon
            { -17, -15, -10, -6, 6, 10, 15, 17 }, // knibis
            {}, // biskni
            { 8 }, // shogi pawn
            {}, // lance
            { 15, 17 }, // shogi knight
            { -1, 1, 15, 17 }, // euroshogi knight
            { -8, -1, 1, 7, 8, 9 }, // gold
            { -8, -1, 1, 8 }, // horse
            { -9, -8, -7, -1, 1, 7, 8, 9 }, // commoner
            { -9, -8, -7, -1, 1, 7, 8, 9 } // king
        };
        Direction sliderCapture[][9] = {
            {}, // NO_PIECE_TYPE
            {}, // pawn
            {}, // knight
            { NORTH_EAST, SOUTH_EAST, SOUTH_WEST, NORTH_WEST }, // bishop
            { NORTH,  EAST,  SOUTH,  WEST }, // rook
            { NORTH,  EAST,  SOUTH,  WEST, NORTH_EAST, SOUTH_EAST, SOUTH_WEST, NORTH_WEST }, // queen
            {}, // fers/met
            {}, // alfil
            {}, // silver/khon
            { NORTH,  EAST,  SOUTH,  WEST }, // aiwok
            { NORTH,  EAST,  SOUTH,  WEST }, // bers/dragon
            { NORTH,  EAST,  SOUTH,  WEST }, // chancellor
            { NORTH,  EAST,  SOUTH,  WEST, NORTH_EAST, SOUTH_EAST, SOUTH_WEST, NORTH_WEST }, // amazon
            { NORTH_EAST, SOUTH_EAST, SOUTH_WEST, NORTH_WEST }, // knibis
            {}, // biskni
            {}, // shogi pawn
            { NORTH }, // lance
            {}, // shogi knight
            {}, // euroshogi knight
            {}, // gold
            { NORTH_EAST, SOUTH_EAST, SOUTH_WEST, NORTH_WEST }, // horse
            {}, // commoner
            {} // king
        };
        Direction sliderQuiet[][9] = {
            {}, // NO_PIECE_TYPE
            {}, // pawn
            {}, // knight
            { NORTH_EAST, SOUTH_EAST, SOUTH_WEST, NORTH_WEST }, // bishop
            { NORTH,  EAST,  SOUTH,  WEST }, // rook
            { NORTH,  EAST,  SOUTH,  WEST, NORTH_EAST, SOUTH_EAST, SOUTH_WEST, NORTH_WEST }, // queen
            {}, // fers/met
            {}, // alfil
            {}, // silver/khon
            { NORTH,  EAST,  SOUTH,  WEST }, // aiwok
            { NORTH,  EAST,  SOUTH,  WEST }, // bers/dragon
            { NORTH,  EAST,  SOUTH,  WEST }, // chancellor
            { NORTH,  EAST,  SOUTH,  WEST, NORTH_EAST, SOUTH_EAST, SOUTH_WEST, NORTH_WEST }, // amazon
            {}, // knibis
            { NORTH_EAST, SOUTH_EAST, SOUTH_WEST, NORTH_WEST }, // biskni
            {}, // shogi pawn
            { NORTH }, // lance
            {}, // shogi knight
            {}, // euroshogi knight
            {}, // gold
            { NORTH_EAST, SOUTH_EAST, SOUTH_WEST, NORTH_WEST }, // horse
            {}, // commoner
            {} // king
        };
        int32_t sliderDistCapture[] = {
            0, // NO_PIECE_TYPE
            0, // pawn
            0, // knight
            7, // bishop
            7, // rook
            7, // queen
            0, // fers/met
            0, // alfil
            0, // silver/khon
            7, // aiwok
            7, // bers/dragon
            7, // chancellor
            7, // amazon
            7, // knibis
            0, // biskni
            0, // shogi pawn
            7, // lance
            0, // shogi knight
            0, // euroshogi knight
            0, // gold
            7, // horse
            0, // commoner
            0  // king
        };
        int32_t sliderDistQuiet[] = {
            0, // NO_PIECE_TYPE
            0, // pawn
            0, // knight
            7, // bishop
            7, // rook
            7, // queen
            0, // fers/met
            0, // alfil
            0, // silver/khon
            7, // aiwok
            7, // bers/dragon
            7, // chancellor
            7, // amazon
            0, // knibis
            7, // biskni
            0, // shogi pawn
            7, // lance
            0, // shogi knight
            0, // euroshogi knight
            0, // gold
            7, // horse
            0, // commoner
            0  // king
        };
        
        for (Color c = WHITE; c <= BLACK; ++c)
            for (PieceType pt = PAWN; pt <= KING; ++pt)
                for (Square s = SQ_A1; s <= SQ_H8; ++s)
                {
                    for (int32_t i = 0; stepsCapture[pt][i]; ++i)
                    {
                        Square to = s + Direction(c == WHITE ? stepsCapture[pt][i] : -stepsCapture[pt][i]);
                        
                        if (is_ok(to) && distance(s, to) < 4)
                        {
                            PseudoAttacks[c][pt][s] |= to;
                            LeaperAttacks[c][pt][s] |= to;
                        }
                    }
                    for (int32_t i = 0; stepsQuiet[pt][i]; ++i)
                    {
                        Square to = s + Direction(c == WHITE ? stepsQuiet[pt][i] : -stepsQuiet[pt][i]);
                        
                        if (is_ok(to) && distance(s, to) < 4)
                        {
                            PseudoMoves[c][pt][s] |= to;
                            LeaperMoves[c][pt][s] |= to;
                        }
                    }
                    PseudoAttacks[c][pt][s] |= sliding_attack(sliderCapture[pt], s, 0, sliderDistCapture[pt]);
                    PseudoMoves[c][pt][s] |= sliding_attack(sliderQuiet[pt], s, 0, sliderDistQuiet[pt]);
                }
        
        for (Square s1 = SQ_A1; s1 <= SQ_H8; ++s1)
        {
            for (PieceType pt : { BISHOP, ROOK })
                for (Square s2 = SQ_A1; s2 <= SQ_H8; ++s2)
                {
                    if (!(PseudoAttacks[WHITE][pt][s1] & s2))
                        continue;
                    
                    LineBB[s1][s2] = (attacks_bb(WHITE, pt, s1, 0) & attacks_bb(WHITE, pt, s2, 0)) | s1 | s2;
                    BetweenBB[s1][s2] = attacks_bb(WHITE, pt, s1, SquareBB[s2]) & attacks_bb(WHITE, pt, s2, SquareBB[s1]);
                }
        }
    }
    
    
    namespace {
        
        // init_magics() computes all rook and bishop attacks at startup. Magic
        // bitboards are used to look up attacks of sliding pieces. As a reference see
        // chessprogramming.wikispaces.com/Magic+Bitboards. In particular, here we
        // use the so called "fancy" approach.
        
        void init_magics(Bitboard table[], Magic magics[], Direction directions[]) {
            
            // Optimal PRNG seeds to pick the correct magics in the shortest time
            int32_t seeds[][RANK_NB] = { { 8977, 44560, 54343, 38998,  5731, 95205, 104912, 17020 },
                {  728, 10316, 55013, 32803, 12281, 15100,  16645,   255 } };
            
            Bitboard occupancy[4096], reference[4096], edges, b;
            int32_t epoch[4096] = {}, cnt = 0, size = 0;
            
            for (Square s = SQ_A1; s <= SQ_H8; ++s)
            {
                // Board edges are not considered in the relevant occupancies
                edges = ((Rank1BB | Rank8BB) & ~rank_bb(s)) | ((FileABB | FileHBB) & ~file_bb(s));
                
                // Given a square 's', the mask is the bitboard of sliding attacks from
                // 's' computed on an empty board. The index must be big enough to contain
                // all the attacks for each possible subset of the mask and so is 2 power
                // the number of 1s of the mask. Hence we deduce the size of the shift to
                // apply to the 64 or 32 bits word to get the index.
                Magic& m = magics[s];
                m.mask  = sliding_attack(directions, s, 0) & ~edges;
                m.shift = (Is64Bit ? 64 : 32) - popcount(m.mask);
                
                // Set the offset for the attacks table of the square. We have individual
                // table sizes for each square with "Fancy Magic Bitboards".
                m.attacks = s == SQ_A1 ? table : magics[s - 1].attacks + size;
                
                // Use Carry-Rippler trick to enumerate all subsets of masks[s] and
                // store the corresponding sliding attack bitboard in reference[].
                b = size = 0;
                do {
                    occupancy[size] = b;
                    reference[size] = sliding_attack(directions, s, b);
                    
                    if (HasPext)
                        m.attacks[pext(b, m.mask)] = reference[size];
                    
                    size++;
                    b = (b - m.mask) & m.mask;
                } while (b);
                
                if (HasPext)
                    continue;
                
                PRNG rng(seeds[Is64Bit][rank_of(s)]);
                
                // Find a magic for square 's' picking up an (almost) random number
                // until we find the one that passes the verification test.
                for (int32_t i = 0; i < size; )
                {
                    for (m.magic = 0; popcount((m.magic * m.mask) >> 56) < 6; )
                        m.magic = rng.sparse_rand<Bitboard>();
                    
                    // A good magic must map every possible occupancy to an index that
                    // looks up the correct sliding attack in the attacks[s] database.
                    // Note that we build up the database for square 's' as a side
                    // effect of verifying the magic. Keep track of the attempt count
                    // and save it in epoch[], little speed-up trick to avoid resetting
                    // m.attacks[] after every failed attempt.
                    for (++cnt, i = 0; i < size; ++i)
                    {
                        unsigned idx = m.index(occupancy[i]);
                        
                        if (epoch[idx] < cnt)
                        {
                            epoch[idx] = cnt;
                            m.attacks[idx] = reference[i];
                        }
                        else if (m.attacks[idx] != reference[i])
                            break;
                    }
                }
            }
        }
    }
}

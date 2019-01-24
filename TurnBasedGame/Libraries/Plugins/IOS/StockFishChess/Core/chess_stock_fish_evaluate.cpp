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
#include <cassert>
#include <cstring>   // For std::memset
#include <iomanip>
#include <sstream>

#include "../../Platform.h"
#include "chess_stock_fish_bitboard.hpp"
#include "chess_stock_fish_evaluate.hpp"
#include "chess_stock_fish_material.hpp"
#include "chess_stock_fish_pawns.hpp"

#include "../chess_stock_fish_jni.hpp"

using namespace std;

namespace StockFishChess
{
    namespace {
        
        const Bitboard Center      = (FileDBB | FileEBB) & (Rank4BB | Rank5BB);
        const Bitboard QueenSide   = FileABB | FileBBB | FileCBB | FileDBB;
        const Bitboard CenterFiles = FileCBB | FileDBB | FileEBB | FileFBB;
        const Bitboard KingSide    = FileEBB | FileFBB | FileGBB | FileHBB;
        
        const Bitboard KingFlank[FILE_NB] = {
            QueenSide, QueenSide, QueenSide, CenterFiles, CenterFiles, KingSide, KingSide, KingSide
        };
        
        namespace Trace {
            
            enum Tracing {NO_TRACE, TRACE};
            
            enum Term { // The first 8 entries are for PieceType
                MATERIAL = 8, IMBALANCE, MOBILITY, THREAT, PASSED, SPACE, INITIATIVE, TOTAL, TERM_NB
            };
            
            double scores[TERM_NB][COLOR_NB][PHASE_NB];
            
            double to_cp(Value v) { return double(v) / PawnValueEg; }
            
            void add(int32_t idx, Color c, Score s) {
                scores[idx][c][MG] = to_cp(mg_value(s));
                scores[idx][c][EG] = to_cp(eg_value(s));
            }
            
            void add(int32_t idx, Score w, Score b = SCORE_ZERO) {
                add(idx, WHITE, w); add(idx, BLACK, b);
            }
            
            std::ostream& operator<<(std::ostream& os, Term t) {
                
                if (t == MATERIAL || t == IMBALANCE || t == Term(PAWN) || t == INITIATIVE || t == TOTAL)
                    os << "  ---   --- |   ---   --- | ";
                else
                    os << std::setw(5) << scores[t][WHITE][MG] << " "
                    << std::setw(5) << scores[t][WHITE][EG] << " | "
                    << std::setw(5) << scores[t][BLACK][MG] << " "
                    << std::setw(5) << scores[t][BLACK][EG] << " | ";
                
                os << std::setw(5) << scores[t][WHITE][MG] - scores[t][BLACK][MG] << " "
                << std::setw(5) << scores[t][WHITE][EG] - scores[t][BLACK][EG] << " \n";
                
                return os;
            }
        }
        
        using namespace Trace;
        
        // Evaluation class contains various information computed and collected
        // by the evaluation functions.
        template<Tracing T = NO_TRACE> class Evaluation {
            
        public:
            Evaluation() = delete;
            Evaluation(const Position& p) : pos(p) {}
            Evaluation& operator=(const Evaluation&) = delete;
            
            Value value();
            
        private:
            // Evaluation helpers (used when calling value())
            template<Color Us> void initialize();
            template<Color Us> Score evaluate_king();
            template<Color Us> Score evaluate_threats();
            template<Color Us> Score evaluate_passed_pawns();
            template<Color Us> Score evaluate_space();
            template<Color Us, PieceType Pt> Score evaluate_pieces();
            ScaleFactor evaluate_scale_factor(Value eg);
            Score evaluate_initiative(Value eg);
            
            // Data members
            const Position& pos;
            Material::Entry* me;
            Pawns::Entry* pe;
            Bitboard mobilityArea[COLOR_NB];
            Score mobility[COLOR_NB] = { SCORE_ZERO, SCORE_ZERO };
            
            // attackedBy[color][piece type] is a bitboard representing all squares
            // attacked by a given color and piece type. Special "piece types" which are
            // also calculated are QUEEN_DIAGONAL and ALL_PIECES.
            Bitboard attackedBy[COLOR_NB][PIECE_TYPE_NB];
            
            // attackedBy2[color] are the squares attacked by 2 pieces of a given color,
            // possibly via x-ray or by one pawn and one piece. Diagonal x-ray through
            // pawn or squares attacked by 2 pawns are not explicitly added.
            Bitboard attackedBy2[COLOR_NB];
            
            // kingRing[color] is the zone around the king which is considered
            // by the king safety evaluation. This consists of the squares directly
            // adjacent to the king, and (only for a king on its first rank) the
            // squares two ranks in front of the king. For instance, if black's king
            // is on g8, kingRing[BLACK] is a bitboard containing the squares f8, h8,
            // f7, g7, h7, f6, g6 and h6.
            Bitboard kingRing[COLOR_NB];
            
            // kingAttackersCount[color] is the number of pieces of the given color
            // which attack a square in the kingRing of the enemy king.
            int32_t kingAttackersCount[COLOR_NB];
            
            // kingAttackersWeight[color] is the sum of the "weights" of the pieces of the
            // given color which attack a square in the kingRing of the enemy king. The
            // weights of the individual piece types are given by the elements in the
            // KingAttackWeights array.
            int32_t kingAttackersWeight[COLOR_NB];
            
            // kingAdjacentZoneAttacksCount[color] is the number of attacks by the given
            // color to squares directly adjacent to the enemy king. Pieces which attack
            // more than one square are counted multiple times. For instance, if there is
            // a white knight on g5 and black's king is on g8, this white knight adds 2
            // to kingAdjacentZoneAttacksCount[WHITE].
            int32_t kingAdjacentZoneAttacksCount[COLOR_NB];
        };
        
// #define V(v) Value(v)
#define S(mg, eg) make_score(mg, eg)
        
        // MobilityBonus[PieceType-2][attacked] contains bonuses for middle and end game,
        // indexed by piece type and number of attacked squares in the mobility area.
        const Score MobilityBonus[][32] = {
            { S(-75,-76), S(-57,-54), S( -9,-28), S( -2,-10), S(  6,  5), S( 14, 12), // Knights
                S( 22, 26), S( 29, 29), S( 36, 29) },
            { S(-48,-59), S(-20,-23), S( 16, -3), S( 26, 13), S( 38, 24), S( 51, 42), // Bishops
                S( 55, 54), S( 63, 57), S( 63, 65), S( 68, 73), S( 81, 78), S( 81, 86),
                S( 91, 88), S( 98, 97) },
            { S(-58,-76), S(-27,-18), S(-15, 28), S(-10, 55), S( -5, 69), S( -2, 82), // Rooks
                S(  9,112), S( 16,118), S( 30,132), S( 29,142), S( 32,155), S( 38,165),
                S( 46,166), S( 48,169), S( 58,171) },
            { S(-39,-36), S(-21,-15), S(  3,  8), S(  3, 18), S( 14, 34), S( 22, 54), // Queens
                S( 28, 61), S( 41, 73), S( 43, 79), S( 48, 92), S( 56, 94), S( 60,104),
                S( 60,113), S( 66,120), S( 67,123), S( 70,126), S( 71,133), S( 73,136),
                S( 79,140), S( 88,143), S( 88,148), S( 99,166), S(102,170), S(102,175),
                S(106,184), S(109,191), S(113,206), S(116,212) }
        };
        
        // Outpost[knight/bishop][supported by pawn] contains bonuses for minor
        // pieces if they can reach an outpost square, bigger if that square is
        // supported by a pawn. If the minor piece occupies an outpost square
        // then score is doubled.
        const Score Outpost[][2] = {
            { S(22, 6), S(36,12) }, // Knight
            { S( 9, 2), S(15, 5) }  // Bishop
        };
        
        // RookOnFile[semiopen/open] contains bonuses for each rook when there is no
        // friendly pawn on the rook file.
        const Score RookOnFile[] = { S(20, 7), S(45, 20) };
        
        // ThreatByMinor/ByRook[attacked PieceType] contains bonuses according to
        // which piece type attacks which one. Attacks on lesser pieces which are
        // pawn-defended are not considered.
        const Score ThreatByMinor[PIECE_TYPE_NB] = {
            S(0, 0), S(0, 33), S(45, 43), S(46, 47), S(72, 107), S(48, 118)
        };
        
        const Score ThreatByRook[PIECE_TYPE_NB] = {
            S(0, 0), S(0, 25), S(40, 62), S(40, 59), S(0, 34), S(35, 48)
        };
        
        // ThreatByKing[on one/on many] contains bonuses for king attacks on
        // pawns or pieces which are not pawn-defended.
        const Score ThreatByKing[] = { S(3, 62), S(9, 138) };
        
        // Passed[mg/eg][Rank] contains midgame and endgame bonuses for passed pawns.
        // We don't use a Score because we process the two components independently.
        const Value Passed[][RANK_NB] = {
            { V(5), V( 5), V(31), V(73), V(166), V(252) },
            { V(7), V(14), V(38), V(73), V(166), V(252) }
        };
        
        // PassedFile[File] contains a bonus according to the file of a passed pawn
        const Score PassedFile[FILE_NB] = {
            S(  9, 10), S( 2, 10), S( 1, -8), S(-20,-12),
            S(-20,-12), S( 1, -8), S( 2, 10), S(  9, 10)
        };
        
        // KingProtector[PieceType-2] contains a bonus according to distance from king
        const Score KingProtector[] = { S(-3, -5), S(-4, -3), S(-3, 0), S(-1, 1) };
        
        // Assorted bonuses and penalties used by evaluation
        const Score MinorBehindPawn       = S( 16,  0);
        const Score BishopPawns           = S(  8, 12);
        const Score LongRangedBishop      = S( 22,  0);
        const Score RookOnPawn            = S(  8, 24);
        const Score TrappedRook           = S( 92,  0);
        const Score WeakQueen             = S( 50, 10);
        const Score CloseEnemies          = S(  7,  0);
        const Score PawnlessFlank         = S( 20, 80);
        const Score ThreatBySafePawn      = S(192,175);
        const Score ThreatByRank          = S( 16,  3);
        const Score Hanging               = S( 48, 27);
        const Score WeakUnopposedPawn     = S(  5, 25);
        const Score ThreatByPawnPush      = S( 38, 22);
        const Score ThreatByAttackOnQueen = S( 38, 22);
        const Score HinderPassedPawn      = S(  7,  0);
        const Score TrappedBishopA1H1     = S( 50, 50);
        
#undef S
#undef V
        
        // KingAttackWeights[PieceType] contains king attack weights by piece type
        const int32_t KingAttackWeights[PIECE_TYPE_NB] = { 0, 0, 78, 56, 45, 11 };
        
        // Penalties for enemy's safe checks
        const int32_t QueenSafeCheck  = 780;
        const int32_t RookSafeCheck   = 880;
        const int32_t BishopSafeCheck = 435;
        const int32_t KnightSafeCheck = 790;
        
        // Threshold for lazy and space evaluation
        const Value LazyThreshold  = Value(1500);
        const Value SpaceThreshold = Value(12222);
        
        
        // initialize() computes king and pawn attacks, and the king ring bitboard
        // for a given color. This is done at the beginning of the evaluation.
        
        template<Tracing T> template<Color Us> void Evaluation<T>::initialize() {
            
            const Color     Them = (Us == WHITE ? BLACK : WHITE);
            const Direction Up   = (Us == WHITE ? NORTH : SOUTH);
            const Direction Down = (Us == WHITE ? SOUTH : NORTH);
            const Bitboard LowRanks = (Us == WHITE ? Rank2BB | Rank3BB: Rank7BB | Rank6BB);
            
            // Find our pawns on the first two ranks, and those which are blocked
            Bitboard b = pos.pieces(Us, PAWN) & (shift<Down>(pos.pieces()) | LowRanks);
            
            // Squares occupied by those pawns, by our king, or controlled by enemy pawns
            // are excluded from the mobility area.
            mobilityArea[Us] = ~(b | pos.square<KING>(Us) | pe->pawn_attacks(Them));
            
            // Initialise the attack bitboards with the king and pawn information
            b = attackedBy[Us][KING] = pos.attacks_from<KING>(pos.square<KING>(Us));
            attackedBy[Us][PAWN] = pe->pawn_attacks(Us);
            
            attackedBy2[Us]            = b & attackedBy[Us][PAWN];
            attackedBy[Us][ALL_PIECES] = b | attackedBy[Us][PAWN];
            
            // Init our king safety tables only if we are going to use them
            if (pos.non_pawn_material(Them) >= RookValueMg + KnightValueMg) {
                kingRing[Us] = b;
                if (relative_rank(Us, pos.square<KING>(Us)) == RANK_1)
                    kingRing[Us] |= shift<Up>(b);
                
                kingAttackersCount[Them] = popcount(b & pe->pawn_attacks(Them));
                kingAdjacentZoneAttacksCount[Them] = kingAttackersWeight[Them] = 0;
            } else
                kingRing[Us] = kingAttackersCount[Them] = 0;
        }
        
        
        // evaluate_pieces() assigns bonuses and penalties to the pieces of a given
        // color and type.
        
        template<Tracing T>  template<Color Us, PieceType Pt> Score Evaluation<T>::evaluate_pieces() {
            
            const Color Them = (Us == WHITE ? BLACK : WHITE);
            const Bitboard OutpostRanks = (Us == WHITE ? Rank4BB | Rank5BB | Rank6BB
                                           : Rank5BB | Rank4BB | Rank3BB);
            const Square* pl = pos.squares<Pt>(Us);
            
            Bitboard b, bb;
            Square s;
            Score score = SCORE_ZERO;
            
            attackedBy[Us][Pt] = 0;
            
            if (Pt == QUEEN)
                attackedBy[Us][QUEEN_DIAGONAL] = 0;
            
            while ((s = *pl++) != SQ_NONE) {
                // Find attacked squares, including x-ray attacks for bishops and rooks
                b = Pt == BISHOP ? attacks_bb<BISHOP>(s, pos.pieces() ^ pos.pieces(QUEEN))
                : Pt ==   ROOK ? attacks_bb<  ROOK>(s, pos.pieces() ^ pos.pieces(QUEEN) ^ pos.pieces(Us, ROOK))
                : pos.attacks_from<Pt>(s);
                
                if (pos.pinned_pieces(Us) & s)
                    b &= LineBB[pos.square<KING>(Us)][s];
                
                attackedBy2[Us] |= attackedBy[Us][ALL_PIECES] & b;
                attackedBy[Us][ALL_PIECES] |= attackedBy[Us][Pt] |= b;
                
                if (Pt == QUEEN)
                    attackedBy[Us][QUEEN_DIAGONAL] |= b & PseudoAttacks[BISHOP][s];
                
                if (b & kingRing[Them]) {
                    kingAttackersCount[Us]++;
                    kingAttackersWeight[Us] += KingAttackWeights[Pt];
                    kingAdjacentZoneAttacksCount[Us] += popcount(b & attackedBy[Them][KING]);
                }

                int32_t mob = popcount(b & mobilityArea[Us]);
                
                mobility[Us] += MobilityBonus[Pt - 2][mob];
                
                // Bonus for this piece as a king protector
                score += KingProtector[Pt - 2] * distance(s, pos.square<KING>(Us));
                
                if (Pt == BISHOP || Pt == KNIGHT) {
                    // Bonus for outpost squares
                    bb = OutpostRanks & ~pe->pawn_attacks_span(Them);
                    if (bb & s)
                        score += Outpost[Pt == BISHOP][bool(attackedBy[Us][PAWN] & s)] * 2;
                    else {
                        bb &= b & ~pos.pieces(Us);
                        if (bb)
                            score += Outpost[Pt == BISHOP][bool(attackedBy[Us][PAWN] & bb)];
                    }
                    
                    // Bonus when behind a pawn
                    if (    relative_rank(Us, s) < RANK_5
                        && (pos.pieces(PAWN) & (s + pawn_push(Us))))
                        score += MinorBehindPawn;
                    
                    if (Pt == BISHOP) {
                        // Penalty for pawns on the same color square as the bishop
                        score -= BishopPawns * pe->pawns_on_same_color_squares(Us, s);
                        
                        // Bonus for bishop on a long diagonal which can "see" both center squares
                        if (more_than_one(Center & (attacks_bb<BISHOP>(s, pos.pieces(PAWN)) | s)))
                            score += LongRangedBishop;
                    }
                    
                    // An important Chess960 pattern: A cornered bishop blocked by a friendly
                    // pawn diagonally in front of it is a very serious problem, especially
                    // when that pawn is also blocked.
                    if (   Pt == BISHOP
                        && pos.is_chess960()
                        && (s == relative_square(Us, SQ_A1) || s == relative_square(Us, SQ_H1))) {
                        Direction d = pawn_push(Us) + (file_of(s) == FILE_A ? EAST : WEST);
                        if (pos.piece_on(s + d) == make_piece(Us, PAWN))
                            score -= !pos.empty(s + d + pawn_push(Us)) ? TrappedBishopA1H1 * 4 : pos.piece_on(s + d + d) == make_piece(Us, PAWN) ? TrappedBishopA1H1 * 2 : TrappedBishopA1H1;
                    }
                }
                
                if (Pt == ROOK) {
                    // Bonus for aligning with enemy pawns on the same rank/file
                    if (relative_rank(Us, s) >= RANK_5)
                        score += RookOnPawn * popcount(pos.pieces(Them, PAWN) & PseudoAttacks[ROOK][s]);
                    
                    // Bonus when on an open or semi-open file
                    if (pe->semiopen_file(Us, file_of(s)))
                        score += RookOnFile[bool(pe->semiopen_file(Them, file_of(s)))];
                    
                    // Penalty when trapped by the king, even more if the king cannot castle
                    else if (mob <= 3) {
                        Square ksq = pos.square<KING>(Us);
                        
                        if (   ((file_of(ksq) < FILE_E) == (file_of(s) < file_of(ksq)))
                            && !pe->semiopen_side(Us, file_of(ksq), file_of(s) < file_of(ksq)))
                            score -= (TrappedRook - make_score(mob * 22, 0)) * (1 + !pos.can_castle(Us));
                    }
                }
                
                if (Pt == QUEEN) {
                    // Penalty if any relative pin or discovered attack against the queen
                    Bitboard pinners;
                    if (pos.slider_blockers(pos.pieces(Them, ROOK, BISHOP), s, pinners))
                        score -= WeakQueen;
                }
            }
            
            if (T)
                Trace::add(Pt, Us, score);
            
            return score;
        }
        
        
        // evaluate_king() assigns bonuses and penalties to a king of a given color
        
        template<Tracing T> template<Color Us> Score Evaluation<T>::evaluate_king() {
            
            const Color     Them = (Us == WHITE ? BLACK : WHITE);
            const Bitboard  Camp = (Us == WHITE ? AllSquares ^ Rank6BB ^ Rank7BB ^ Rank8BB
                                    : AllSquares ^ Rank1BB ^ Rank2BB ^ Rank3BB);
            
            const Square ksq = pos.square<KING>(Us);
            Bitboard weak, b, b1, b2, safe, unsafeChecks;
            
            // King shelter and enemy pawns storm
            Score score = pe->king_safety<Us>(pos, ksq);
            
            // Main king safety evaluation
            if (kingAttackersCount[Them] > (1 - pos.count<QUEEN>(Them))) {
                // Attacked squares defended at most once by our queen or king
                weak =  attackedBy[Them][ALL_PIECES]
                & ~attackedBy2[Us]
                & (attackedBy[Us][KING] | attackedBy[Us][QUEEN] | ~attackedBy[Us][ALL_PIECES]);

                int32_t kingDanger = unsafeChecks = 0;
                
                // Analyse the safe enemy's checks which are possible on next move
                safe  = ~pos.pieces(Them);
                safe &= ~attackedBy[Us][ALL_PIECES] | (weak & attackedBy2[Them]);
                
                b1 = attacks_bb<ROOK  >(ksq, pos.pieces() ^ pos.pieces(Us, QUEEN));
                b2 = attacks_bb<BISHOP>(ksq, pos.pieces() ^ pos.pieces(Us, QUEEN));
                
                // Enemy queen safe checks
                if ((b1 | b2) & attackedBy[Them][QUEEN] & safe & ~attackedBy[Us][QUEEN])
                    kingDanger += QueenSafeCheck;
                
                b1 &= attackedBy[Them][ROOK];
                b2 &= attackedBy[Them][BISHOP];
                
                // Enemy rooks checks
                if (b1 & safe)
                    kingDanger += RookSafeCheck;
                else
                    unsafeChecks |= b1;
                
                // Enemy bishops checks
                if (b2 & safe)
                    kingDanger += BishopSafeCheck;
                else
                    unsafeChecks |= b2;
                
                // Enemy knights checks
                b = pos.attacks_from<KNIGHT>(ksq) & attackedBy[Them][KNIGHT];
                if (b & safe)
                    kingDanger += KnightSafeCheck;
                else
                    unsafeChecks |= b;
                
                // Unsafe or occupied checking squares will also be considered, as long as
                // the square is in the attacker's mobility area.
                unsafeChecks &= mobilityArea[Them];
                
                kingDanger +=        kingAttackersCount[Them] * kingAttackersWeight[Them]
                + 102 * kingAdjacentZoneAttacksCount[Them]
                + 191 * popcount(kingRing[Us] & weak)
                + 143 * popcount(pos.pinned_pieces(Us) | unsafeChecks)
                - 848 * !pos.count<QUEEN>(Them)
                -   9 * mg_value(score) / 8
                +  40;
                
                // Transform the kingDanger units into a Score, and substract it from the evaluation
                if (kingDanger > 0)
                    score -= make_score(kingDanger * kingDanger / 4096, kingDanger / 16);
            }
            
            // King tropism: firstly, find squares that opponent attacks in our king flank
            File kf = file_of(ksq);
            b = attackedBy[Them][ALL_PIECES] & KingFlank[kf] & Camp;
            
            // assert(((Us == WHITE ? b << 4 : b >> 4) & b) == 0);
            if(!(((Us == WHITE ? b << 4 : b >> 4) & b) == 0)){
                printf("error, assert(((Us == WHITE ? b << 4 : b >> 4) & b) == 0)\n");
            }
            // assert(popcount(Us == WHITE ? b << 4 : b >> 4) == popcount(b));
            if(!(popcount(Us == WHITE ? b << 4 : b >> 4) == popcount(b))){
                printf("error, assert(popcount(Us == WHITE ? b << 4 : b >> 4) == popcount(b))\n");
            }
            
            // Secondly, add the squares which are attacked twice in that flank and
            // which are not defended by our pawns.
            b =  (Us == WHITE ? b << 4 : b >> 4)
            | (b & attackedBy2[Them] & ~attackedBy[Us][PAWN]);
            
            score -= CloseEnemies * popcount(b);
            
            // Penalty when our king is on a pawnless flank
            if (!(pos.pieces(PAWN) & KingFlank[kf]))
                score -= PawnlessFlank;
            
            if (T)
                Trace::add(KING, Us, score);
            
            return score;
        }
        
        
        // evaluate_threats() assigns bonuses according to the types of the attacking
        // and the attacked pieces.
        
        template<Tracing T>  template<Color Us> Score Evaluation<T>::evaluate_threats() {
            
            const Color     Them     = (Us == WHITE ? BLACK      : WHITE);
            const Direction Up       = (Us == WHITE ? NORTH      : SOUTH);
            const Direction Left     = (Us == WHITE ? NORTH_WEST : SOUTH_EAST);
            const Direction Right    = (Us == WHITE ? NORTH_EAST : SOUTH_WEST);
            const Bitboard  TRank3BB = (Us == WHITE ? Rank3BB    : Rank6BB);
            
            Bitboard b, weak, defended, stronglyProtected, safeThreats;
            Score score = SCORE_ZERO;
            
            // Non-pawn enemies attacked by a pawn
            weak = (pos.pieces(Them) ^ pos.pieces(Them, PAWN)) & attackedBy[Us][PAWN];
            
            if (weak) {
                b = pos.pieces(Us, PAWN) & ( ~attackedBy[Them][ALL_PIECES]
                                            | attackedBy[Us][ALL_PIECES]);
                
                safeThreats = (shift<Right>(b) | shift<Left>(b)) & weak;
                
                score += ThreatBySafePawn * popcount(safeThreats);
            }
            
            // Squares strongly protected by the opponent, either because they attack the
            // square with a pawn, or because they attack the square twice and we don't.
            stronglyProtected =  attackedBy[Them][PAWN]
            | (attackedBy2[Them] & ~attackedBy2[Us]);
            
            // Non-pawn enemies, strongly protected
            defended =  (pos.pieces(Them) ^ pos.pieces(Them, PAWN))
            & stronglyProtected;
            
            // Enemies not strongly protected and under our attack
            weak =   pos.pieces(Them)
            & ~stronglyProtected
            &  attackedBy[Us][ALL_PIECES];
            
            // Add a bonus according to the kind of attacking pieces
            if (defended | weak) {
                b = (defended | weak) & (attackedBy[Us][KNIGHT] | attackedBy[Us][BISHOP]);
                while (b) {
                    Square s = pop_lsb(&b);
                    score += ThreatByMinor[type_of(pos.piece_on(s))];
                    if (type_of(pos.piece_on(s)) != PAWN)
                        score += ThreatByRank * (int)relative_rank(Them, s);
                }
                
                b = (pos.pieces(Them, QUEEN) | weak) & attackedBy[Us][ROOK];
                while (b) {
                    Square s = pop_lsb(&b);
                    score += ThreatByRook[type_of(pos.piece_on(s))];
                    if (type_of(pos.piece_on(s)) != PAWN)
                        score += ThreatByRank * (int)relative_rank(Them, s);
                }
                
                score += Hanging * popcount(weak & ~attackedBy[Them][ALL_PIECES]);
                
                b = weak & attackedBy[Us][KING];
                if (b)
                    score += ThreatByKing[more_than_one(b)];
            }
            
            // Bonus for opponent unopposed weak pawns
            if (pos.pieces(Us, ROOK, QUEEN))
                score += WeakUnopposedPawn * pe->weak_unopposed(Them);
            
            // Find squares where our pawns can push on the next move
            b  = shift<Up>(pos.pieces(Us, PAWN)) & ~pos.pieces();
            b |= shift<Up>(b & TRank3BB) & ~pos.pieces();
            
            // Keep only the squares which are not completely unsafe
            b &= ~attackedBy[Them][PAWN]
            & (attackedBy[Us][ALL_PIECES] | ~attackedBy[Them][ALL_PIECES]);
            
            // Add a bonus for each new pawn threats from those squares
            b =  (shift<Left>(b) | shift<Right>(b))
            &  pos.pieces(Them)
            & ~attackedBy[Us][PAWN];
            
            score += ThreatByPawnPush * popcount(b);
            
            // Add a bonus for safe slider attack threats on opponent queen
            safeThreats = ~pos.pieces(Us) & ~attackedBy2[Them] & attackedBy2[Us];
            b =  (attackedBy[Us][BISHOP] & attackedBy[Them][QUEEN_DIAGONAL])
            | (attackedBy[Us][ROOK  ] & attackedBy[Them][QUEEN] & ~attackedBy[Them][QUEEN_DIAGONAL]);
            
            score += ThreatByAttackOnQueen * popcount(b & safeThreats);
            
            if (T)
                Trace::add(THREAT, Us, score);
            
            return score;
        }
        
        
        // evaluate_passed_pawns() evaluates the passed pawns and candidate passed
        // pawns of the given color.
        
        template<Tracing T> template<Color Us> Score Evaluation<T>::evaluate_passed_pawns() {
            
            const Color     Them = (Us == WHITE ? BLACK : WHITE);
            const Direction Up   = (Us == WHITE ? NORTH : SOUTH);
            
            Bitboard b, bb, squaresToQueen, defendedSquares, unsafeSquares;
            Score score = SCORE_ZERO;
            
            b = pe->passed_pawns(Us);
            
            while (b) {
                Square s = pop_lsb(&b);
                
                // assert(!(pos.pieces(Them, PAWN) & forward_file_bb(Us, s + Up)));
                if((pos.pieces(Them, PAWN) & forward_file_bb(Us, s + Up))){
                    printf("error, assert(!(pos.pieces(Them, PAWN) & forward_file_bb(Us, s + Up)))\n");
                }
                
                bb = forward_file_bb(Us, s) & (attackedBy[Them][ALL_PIECES] | pos.pieces(Them));
                score -= HinderPassedPawn * popcount(bb);

                int32_t r = relative_rank(Us, s) - RANK_2;
                int32_t rr = r * (r - 1);
                
                Value mbonus = Passed[MG][r], ebonus = Passed[EG][r];
                
                if (rr) {
                    Square blockSq = s + Up;
                    
                    // Adjust bonus based on the king's proximity
                    ebonus +=  distance(pos.square<KING>(Them), blockSq) * 5 * rr
                    - distance(pos.square<KING>(  Us), blockSq) * 2 * rr;
                    
                    // If blockSq is not the queening square then consider also a second push
                    if (relative_rank(Us, blockSq) != RANK_8)
                        ebonus -= distance(pos.square<KING>(Us), blockSq + Up) * rr;
                    
                    // If the pawn is free to advance, then increase the bonus
                    if (pos.empty(blockSq)) {
                        // If there is a rook or queen attacking/defending the pawn from behind,
                        // consider all the squaresToQueen. Otherwise consider only the squares
                        // in the pawn's path attacked or occupied by the enemy.
                        defendedSquares = unsafeSquares = squaresToQueen = forward_file_bb(Us, s);
                        
                        bb = forward_file_bb(Them, s) & pos.pieces(ROOK, QUEEN) & pos.attacks_from<ROOK>(s);
                        
                        if (!(pos.pieces(Us) & bb))
                            defendedSquares &= attackedBy[Us][ALL_PIECES];
                        
                        if (!(pos.pieces(Them) & bb))
                            unsafeSquares &= attackedBy[Them][ALL_PIECES] | pos.pieces(Them);
                        
                        // If there aren't any enemy attacks, assign a big bonus. Otherwise
                        // assign a smaller bonus if the block square isn't attacked.
                        int32_t k = !unsafeSquares ? 18 : !(unsafeSquares & blockSq) ? 8 : 0;
                        
                        // If the path to the queen is fully defended, assign a big bonus.
                        // Otherwise assign a smaller bonus if the block square is defended.
                        if (defendedSquares == squaresToQueen)
                            k += 6;
                        
                        else if (defendedSquares & blockSq)
                            k += 4;
                        
                        mbonus += k * rr, ebonus += k * rr;
                    } else if (pos.pieces(Us) & blockSq)
                        mbonus += rr + r * 2, ebonus += rr + r * 2;
                } // rr != 0
                
                // Scale down bonus for candidate passers which need more than one
                // pawn push to become passed or have a pawn in front of them.
                if (!pos.pawn_passed(Us, s + Up) || (pos.pieces(PAWN) & forward_file_bb(Us, s)))
                    mbonus /= 2, ebonus /= 2;
                
                score += make_score(mbonus, ebonus) + PassedFile[file_of(s)];
            }
            
            if (T)
                Trace::add(PASSED, Us, score);
            
            return score;
        }
        
        
        // evaluate_space() computes the space evaluation for a given side. The
        // space evaluation is a simple bonus based on the number of safe squares
        // available for minor pieces on the central four files on ranks 2--4. Safe
        // squares one, two or three squares behind a friendly pawn are counted
        // twice. Finally, the space bonus is multiplied by a weight. The aim is to
        // improve play on game opening.
        
        template<Tracing T> template<Color Us> Score Evaluation<T>::evaluate_space() {
            
            const Color Them = (Us == WHITE ? BLACK : WHITE);
            const Bitboard SpaceMask = Us == WHITE ? CenterFiles & (Rank2BB | Rank3BB | Rank4BB)
            : CenterFiles & (Rank7BB | Rank6BB | Rank5BB);
            
            // Find the safe squares for our pieces inside the area defined by
            // SpaceMask. A square is unsafe if it is attacked by an enemy
            // pawn, or if it is undefended and attacked by an enemy piece.
            Bitboard safe =   SpaceMask
            & ~pos.pieces(Us, PAWN)
            & ~attackedBy[Them][PAWN]
            & (attackedBy[Us][ALL_PIECES] | ~attackedBy[Them][ALL_PIECES]);
            
            // Find all squares which are at most three squares behind some friendly pawn
            Bitboard behind = pos.pieces(Us, PAWN);
            behind |= (Us == WHITE ? behind >>  8 : behind <<  8);
            behind |= (Us == WHITE ? behind >> 16 : behind << 16);
            
            // Since SpaceMask[Us] is fully on our half of the board...
            // assert(unsigned(safe >> (Us == WHITE ? 32 : 0)) == 0);
            if(!(unsigned(safe >> (Us == WHITE ? 32 : 0)) == 0)){
                printf("error, assert(unsigned(safe >> (Us == WHITE ? 32 : 0)) == 0)\n");
            }
            
            // ...count safe + (behind & safe) with a single popcount.
            int32_t bonus = popcount((Us == WHITE ? safe << 32 : safe >> 32) | (behind & safe));
            int32_t weight = pos.count<ALL_PIECES>(Us) - 2 * pe->open_files();
            
            return make_score(bonus * weight * weight / 16, 0);
        }
        
        
        // evaluate_initiative() computes the initiative correction value for the
        // position, i.e., second order bonus/malus based on the known attacking/defending
        // status of the players.
        
        template<Tracing T> Score Evaluation<T>::evaluate_initiative(Value eg) {

            int32_t kingDistance =  distanceT<File>(pos.square<KING>(WHITE), pos.square<KING>(BLACK))
            - distanceT<Rank>(pos.square<KING>(WHITE), pos.square<KING>(BLACK));
            bool bothFlanks = (pos.pieces(PAWN) & QueenSide) && (pos.pieces(PAWN) & KingSide);
            
            // Compute the initiative bonus for the attacking side
            int32_t initiative = 8 * (pe->pawn_asymmetry() + kingDistance - 17) + 12 * pos.count<PAWN>() + 16 * bothFlanks;
            
            // Now apply the bonus: note that we find the attacking side by extracting
            // the sign of the endgame value, and that we carefully cap the bonus so
            // that the endgame score will never change sign after the bonus.
            int32_t v = ((eg > 0) - (eg < 0)) * max(initiative, -abs(eg));
            
            if (T)
                Trace::add(INITIATIVE, make_score(0, v));
            
            return make_score(0, v);
        }
        
        
        // evaluate_scale_factor() computes the scale factor for the winning side
        
        template<Tracing T> ScaleFactor Evaluation<T>::evaluate_scale_factor(Value eg) {
            
            Color strongSide = eg > VALUE_DRAW ? WHITE : BLACK;
            ScaleFactor sf = me->scale_factor(pos, strongSide);
            
            // If we don't already have an unusual scale factor, check for certain
            // types of endgames, and use a lower scale for those.
            if (sf == SCALE_FACTOR_NORMAL || sf == SCALE_FACTOR_ONEPAWN) {
                if (pos.opposite_bishops()) {
                    // Endgame with opposite-colored bishops and no other pieces (ignoring pawns)
                    // is almost a draw, in case of KBP vs KB, it is even more a draw.
                    if (   pos.non_pawn_material(WHITE) == BishopValueMg
                        && pos.non_pawn_material(BLACK) == BishopValueMg)
                        return more_than_one(pos.pieces(PAWN)) ? ScaleFactor(31) : ScaleFactor(9);
                    
                    // Endgame with opposite-colored bishops, but also other pieces. Still
                    // a bit drawish, but not as drawish as with only the two bishops.
                    return ScaleFactor(46);
                }
                // Endings where weaker side can place his king in front of the opponent's
                // pawns are drawish.
                else if (    abs(eg) <= BishopValueEg
                         &&  pos.count<PAWN>(strongSide) <= 2
                         && !pos.pawn_passed(~strongSide, pos.square<KING>(~strongSide)))
                    return ScaleFactor(37 + 7 * pos.count<PAWN>(strongSide));
            }
            
            return sf;
        }
        
        
        // value() is the main function of the class. It computes the various parts of
        // the evaluation and returns the value of the position from the point of view
        // of the side to move.
        
        template<Tracing T> Value Evaluation<T>::value() {
            
            // neu chieu thi kong evaluate
            // assert(!pos.checkers());
            if(pos.checkers()){
                printf("error, assert(!pos.checkers())\n");
            }
            
            // Probe the material hash table
            me = Material::probe(pos);
            
            // If we have a specialized evaluation function for the current material
            // configuration, call it and return.
            if (me->specialized_eval_exists())
                return me->evaluate(pos);
            
            // Initialize score by reading the incrementally updated scores included in
            // the position object (material + piece square tables) and the material
            // imbalance. Score is computed internally from the white point of view.
            Score score = pos.psq_score() + me->imbalance() + Eval::Contempt;
            
            // Probe the pawn hash table
            pe = Pawns::probe(pos);
            score += pe->pawns_score();
            
            // Early exit if score is high
            Value v = (mg_value(score) + eg_value(score)) / 2;
            if (abs(v) > LazyThreshold)
                return pos.side_to_move() == WHITE ? v : -v;
            
            // Main evaluation begins here
            
            initialize<WHITE>();
            initialize<BLACK>();
            
            score += evaluate_pieces<WHITE, KNIGHT>() - evaluate_pieces<BLACK, KNIGHT>();
            score += evaluate_pieces<WHITE, BISHOP>() - evaluate_pieces<BLACK, BISHOP>();
            score += evaluate_pieces<WHITE, ROOK  >() - evaluate_pieces<BLACK, ROOK  >();
            score += evaluate_pieces<WHITE, QUEEN >() - evaluate_pieces<BLACK, QUEEN >();
            
            score += mobility[WHITE] - mobility[BLACK];
            
            score +=  evaluate_king<WHITE>()
            - evaluate_king<BLACK>();
            
            score +=  evaluate_threats<WHITE>()
            - evaluate_threats<BLACK>();
            
            score +=  evaluate_passed_pawns<WHITE>()
            - evaluate_passed_pawns<BLACK>();
            
            if (pos.non_pawn_material() >= SpaceThreshold)
                score +=  evaluate_space<WHITE>()
                - evaluate_space<BLACK>();
            
            score += evaluate_initiative(eg_value(score));
            
            // Interpolate between a middlegame and a (scaled by 'sf') endgame score
            ScaleFactor sf = evaluate_scale_factor(eg_value(score));
            v =  mg_value(score) * int(me->game_phase())
            + eg_value(score) * int(PHASE_MIDGAME - me->game_phase()) * sf / SCALE_FACTOR_NORMAL;
            
            v /= int(PHASE_MIDGAME);
            
            // In case of tracing add all remaining individual evaluation terms
            if (T) {
                Trace::add(MATERIAL, pos.psq_score());
                Trace::add(IMBALANCE, me->imbalance());
                Trace::add(PAWN, pe->pawns_score());
                Trace::add(MOBILITY, mobility[WHITE], mobility[BLACK]);
                if (pos.non_pawn_material() >= SpaceThreshold)
                    Trace::add(SPACE, evaluate_space<WHITE>()
                               , evaluate_space<BLACK>());
                Trace::add(TOTAL, score);
            }
            
            return pos.side_to_move() == WHITE ? v : -v; // Side to move point of view
        }
        
    } // namespace
    
    Score Eval::Contempt = SCORE_ZERO;
    
    /// evaluate() is the evaluator for the outer world. It returns a static evaluation
    /// of the position from the point of view of the side to move.
    
    Value Eval::evaluate(const Position& pos)
    {
        return Evaluation<>(pos).value() + Eval::Tempo;
    }
    
    /// trace() is like evaluate(), but instead of returning a value, it returns
    /// a string (suitable for outputting to stdout) that contains the detailed
    /// descriptions and values of each evaluation term. Useful for debugging.
    
    std::string Eval::trace(const Position& pos) {
        
        std::memset(scores, 0, sizeof(scores));
        
        Value v = Evaluation<TRACE>(pos).value() + Eval::Tempo;
        v = pos.side_to_move() == WHITE ? v : -v; // White's point of view
        
        std::stringstream ss;
        ss << std::showpoint << std::noshowpos << std::fixed << std::setprecision(2)
        << "      Eval term |    White    |    Black    |    Total    \n"
        << "                |   MG    EG  |   MG    EG  |   MG    EG  \n"
        << "----------------+-------------+-------------+-------------\n"
        << "       Material | " << Term(MATERIAL)
        << "      Imbalance | " << Term(IMBALANCE)
        << "          Pawns | " << Term(PAWN)
        << "        Knights | " << Term(KNIGHT)
        << "        Bishops | " << Term(BISHOP)
        << "          Rooks | " << Term(ROOK)
        << "         Queens | " << Term(QUEEN)
        << "       Mobility | " << Term(MOBILITY)
        << "    King safety | " << Term(KING)
        << "        Threats | " << Term(THREAT)
        << "   Passed pawns | " << Term(PASSED)
        << "          Space | " << Term(SPACE)
        << "     Initiative | " << Term(INITIATIVE)
        << "----------------+-------------+-------------+-------------\n"
        << "          Total | " << Term(TOTAL);
        
        ss << "\nTotal Evaluation: " << to_cp(v) << " (white side)\n";
        printf("Total Evaluation: %f  (white side)\n", to_cp(v));
        
        return ss.str();
    }
}

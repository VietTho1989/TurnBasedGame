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
#include <cstddef> // For offsetof()
#include <cstring> // For std::memset, std::memcmp
#include <iomanip>
#include <sstream>

#include "fairy_chess_bitboard.hpp"
#include "fairy_chess_misc.hpp"
#include "fairy_chess_movegen.hpp"
#include "fairy_chess_position.hpp"
#include "fairy_chess_thread.hpp"
#include "fairy_chess_tt.hpp"
#include "fairy_chess_uci.hpp"
#include "syzygy/fairy_chess_tbprobe.hpp"
#include "fairy_chess_jni.hpp"

using std::string;
using namespace std;

namespace FairyChess
{
    namespace PSQT {
        extern Score psq[PIECE_NB][SQUARE_NB + 1];
    }
    
    namespace Zobrist {
        
        Key psq[PIECE_NB][SQUARE_NB];
        Key enpassant[FILE_NB];
        Key castling[CASTLING_RIGHT_NB];
        Key side, noPawns;
        Key inHand[PIECE_NB][17];
        Key checks[COLOR_NB][CHECKS_NB];
    }
    
    namespace {
        
        // min_attacker() is a helper function used by see_ge() to locate the least
        // valuable attacker for the side to move, remove the attacker we just found
        // from the bitboards and scan for new X-ray attacks behind it.
        
        template<int32_t Pt>
        PieceType min_attacker(const Bitboard* byTypeBB, Square to, Bitboard stmAttackers,
                               Bitboard& occupied, Bitboard& attackers) {
            
            Bitboard b = stmAttackers & byTypeBB[Pt];
            if (!b)
                return min_attacker<Pt + 1>(byTypeBB, to, stmAttackers, occupied, attackers);
            
            occupied ^= lsb(b); // Remove the attacker from occupied
            
            // Add any X-ray attack behind the just removed piece. For instance with
            // rooks in a8 and a7 attacking a1, after removing a7 we add rook in a8.
            // Note that new added attackers can be of any color.
            if (Pt == PAWN || Pt == BISHOP || Pt == QUEEN)
                attackers |= attacks_bb<BISHOP>(to, occupied) & (byTypeBB[BISHOP] | byTypeBB[QUEEN]);
            
            if (Pt == ROOK || Pt == QUEEN)
                attackers |= attacks_bb<ROOK>(to, occupied) & (byTypeBB[ROOK] | byTypeBB[QUEEN]);
            
            // X-ray may add already processed pieces because byTypeBB[] is constant: in
            // the rook example, now attackers contains _again_ rook in a7, so remove it.
            attackers &= occupied;
            return (PieceType)Pt;
        }
        
        template<>
        PieceType min_attacker<KING>(const Bitboard*, Square, Bitboard, Bitboard&, Bitboard&) {
            return KING; // No need to update bitboards: it is the last cycle
        }
        
    } // namespace
    
    
    /// operator<<(Position) returns an ASCII representation of the position
    
    std::ostream& operator<<(std::ostream& os, const Position& pos) {
        
        os << "\n +---+---+---+---+---+---+---+---+\n";
        
        for (Rank r = RANK_8; r >= RANK_1; --r)
        {
            for (File f = FILE_A; f <= FILE_H; ++f)
                os << " | " << pos.piece_to_char()[pos.piece_on(make_square(f, r))];
            
            os << " |\n +---+---+---+---+---+---+---+---+\n";
        }
        
        os << "\nFen: " << pos.fen() << "\nKey: " << std::hex << std::uppercase
        << std::setfill('0') << std::setw(16) << pos.key()
        << std::setfill(' ') << std::dec << "\nCheckers: ";
        
        for (Bitboard b = pos.checkers(); b; )
            os << UCI::square(pop_lsb(&b)) << " ";
        
        if (    int(Tablebases::MaxCardinality) >= popcount(pos.pieces())
            && !pos.can_castle(ANY_CASTLING))
        {
            StateInfo st;
            Position p;
            p.set(pos.variant(), pos.fen(), pos.is_chess960(), &st, pos.this_thread());
            Tablebases::ProbeState s1, s2;
            Tablebases::WDLScore wdl = Tablebases::probe_wdl(&p, &s1);
            int32_t dtz = Tablebases::probe_dtz(&p, &s2);
            os << "\nTablebases WDL: " << std::setw(4) << wdl << " (" << s1 << ")"
            << "\nTablebases DTZ: " << std::setw(4) << dtz << " (" << s2 << ")";
        }
        
        return os;
    }
    
    void printPos(char* ret, const Position& pos)
    {
        ret[0] = 0;
        {
            char strVariant[100];
            {
                getStrVariant(strVariant, pos.var);
            }
            sprintf(ret, "%sVariant: %s\n", ret, strVariant);
        }
        
        sprintf(ret, "%s\n +---+---+---+---+---+---+---+---+\n", ret);
        for (Rank r = RANK_8; r >= RANK_1; --r)
        {
            for (File f = FILE_A; f <= FILE_H; ++f) {
                sprintf(ret, "%s | %c", ret, pos.piece_to_char()[pos.piece_on(make_square(f, r))]);
            }
            
            sprintf(ret, "%s |\n +---+---+---+---+---+---+---+---+\n", ret);
        }
        
        /*os << "\nFen: " << pos.fen() << "\nKey: " << std::hex << std::uppercase
        << std::setfill('0') << std::setw(16) << pos.key()
        << std::setfill(' ') << std::dec << "\nCheckers: ";*/
        {
            char strFen[120];
            {
                pos.myFen(strFen);
            }
            sprintf(ret, "%s\nFen: %s\nKey: %llu\nCheckers: ", ret, strFen, pos.key());
        }
        
        for (Bitboard b = pos.checkers(); b; ){
            char strSquare[10];
            UCI::square(strSquare, pop_lsb(&b));
            sprintf(ret, "%s%s ", ret, strSquare);
        }
        
        /*if (    int(Tablebases::MaxCardinality) >= popcount(pos.pieces())
            && !pos.can_castle(ANY_CASTLING))
        {
            StateInfo st;
            Position p;
            p.set(pos.variant(), pos.fen(), pos.is_chess960(), &st, pos.this_thread());
            Tablebases::ProbeState s1, s2;
            Tablebases::WDLScore wdl = Tablebases::probe_wdl(p, &s1);
            int32_t dtz = Tablebases::probe_dtz(p, &s2);
            os << "\nTablebases WDL: " << std::setw(4) << wdl << " (" << s1 << ")"
            << "\nTablebases DTZ: " << std::setw(4) << dtz << " (" << s2 << ")";
        }*/
    }
    
    
    // Marcel van Kervinck's cuckoo algorithm for fast detection of "upcoming repetition"
    // situations. Description of the algorithm in the following paper:
    // https://marcelk.net/2013-04-06/paper/upcoming-rep-v2.pdf
    
    // First and second hash functions for indexing the cuckoo tables
    inline int32_t H1(Key h) { return h & 0x1fff; }
    inline int32_t H2(Key h) { return (h >> 16) & 0x1fff; }
    
    // Cuckoo tables with Zobrist hashes of valid reversible moves, and the moves themselves
    Key cuckoo[8192];
    Move cuckooMove[8192];
    
    
    /// Position::init() initializes at startup the various arrays used to compute
    /// hash keys.
    
    void Position::init() {
        
        PRNG rng(1070372);
        
        for (Color c = WHITE; c <= BLACK; ++c)
            for (PieceType pt = PAWN; pt <= KING; ++pt)
                for (Square s = SQ_A1; s <= SQ_H8; ++s)
                    Zobrist::psq[make_piece(c, pt)][s] = rng.rand<Key>();
        
        for (File f = FILE_A; f <= FILE_H; ++f)
            Zobrist::enpassant[f] = rng.rand<Key>();
        
        for (int32_t cr = NO_CASTLING; cr <= ANY_CASTLING; ++cr)
        {
            Zobrist::castling[cr] = 0;
            Bitboard b = cr;
            while (b)
            {
                Key k = Zobrist::castling[1ULL << pop_lsb(&b)];
                Zobrist::castling[cr] ^= k ? k : rng.rand<Key>();
            }
        }
        
        Zobrist::side = rng.rand<Key>();
        Zobrist::noPawns = rng.rand<Key>();
        
        for (Color c = WHITE; c <= BLACK; ++c)
            for (int32_t n = 0; n < CHECKS_NB; ++n)
                Zobrist::checks[c][n] = rng.rand<Key>();
        
        for (Color c = WHITE; c <= BLACK; ++c)
            for (PieceType pt = KNIGHT; pt <= KING; ++pt)
                for (int32_t n = 0; n < 17; ++n)
                    Zobrist::inHand[make_piece(c, pt)][n] = rng.rand<Key>();
        
        // Prepare the cuckoo tables
        int32_t count = 0;
        for (Color c = WHITE; c <= BLACK; ++c)
            for (PieceType pt = KNIGHT; pt <= QUEEN || pt == KING; pt != QUEEN ? ++pt : pt = KING)
            {
                Piece pc = make_piece(c, pt);
                for (Square s1 = SQ_A1; s1 <= SQ_H8; ++s1)
                    for (Square s2 = Square(s1 + 1); s2 <= SQ_H8; ++s2)
                        if (PseudoAttacks[WHITE][type_of(pc)][s1] & s2)
                        {
                            Move move = make_move(s1, s2);
                            Key key = Zobrist::psq[pc][s1] ^ Zobrist::psq[pc][s2] ^ Zobrist::side;
                            int32_t i = H1(key);
                            while (true)
                            {
                                std::swap(cuckoo[i], key);
                                std::swap(cuckooMove[i], move);
                                if (move == 0)   // Arrived at empty slot ?
                                    break;
                                i = (i == H1(key)) ? H2(key) : H1(key); // Push victim to alternative slot
                            }
                            count++;
                        }
            }
        // assert(count == 3668);
        if(count!=3668){
            printf("error, assert(count == 3668)\n");
        }
    }
    
    
    /// Position::set() initializes the position object with the given FEN string.
    /// This function is not very robust - make sure that input FENs are correct,
    /// this is assumed to be the responsibility of the GUI.
    
    Position& Position::set(const Variant* v, const string& fenStr, bool isChess960, StateInfo* si, Thread* th) {
        /*
         A FEN string defines a particular position using only the ASCII character set.
         
         A FEN string contains six fields separated by a space. The fields are:
         
         1) Piece placement (from white's perspective). Each rank is described, starting
         with rank 8 and ending with rank 1. Within each rank, the contents of each
         square are described from file A through file H. Following the Standard
         Algebraic Notation (SAN), each piece is identified by a single letter taken
         from the standard English names. White pieces are designated using upper-case
         letters ("PNBRQK") whilst Black uses lowercase ("pnbrqk"). Blank squares are
         noted using digits 1 through 8 (the number of blank squares), and "/"
         separates ranks.
         
         2) Active color. "w" means white moves next, "b" means black.
         
         3) Castling availability. If neither side can castle, this is "-". Otherwise,
         this has one or more letters: "K" (White can castle kingside), "Q" (White
         can castle queenside), "k" (Black can castle kingside), and/or "q" (Black
         can castle queenside).
         
         4) En passant target square (in algebraic notation). If there's no en passant
         target square, this is "-". If a pawn has just made a 2-square move, this
         is the position "behind" the pawn. This is recorded only if there is a pawn
         in position to make an en passant capture, and if there really is a pawn
         that might have advanced two squares.
         
         5) Halfmove clock. This is the number of halfmoves since the last pawn advance
         or capture. This is used to determine if a draw can be claimed under the
         fifty-move rule.
         
         6) Fullmove number. The number of the full move. It starts at 1, and is
         incremented after Black's move.
         */
        unsigned char col, row, token;
        size_t idx;
        std::istringstream ss(fenStr);
        
        std::memset(this, 0, sizeof(Position));
        std::memset(si, 0, sizeof(StateInfo));
        std::fill_n(&pieceList[0][0], sizeof(pieceList) / sizeof(Square), SQ_NONE);
        var = v;
        st = si;
        
        ss >> std::noskipws;
        
        Square sq = SQ_A8 + (RANK_8 - max_rank()) * SOUTH;
        // 1. Piece placement
        while ((ss >> token) && !isspace(token))
        {
            if (isdigit(token)) {
                sq += (token - '0') * EAST; // Advance the given number of files
            }
            else if (token == '/') {
                sq += 2 * SOUTH + (FILE_H - max_file()) * EAST;
            }
            else if ((idx = piece_to_char().find(token)) != string::npos)
            {
                put_piece(Piece(idx), sq);
                ++sq;
            }
            // Promoted shogi pieces
            else if (token == '+')
            {
                ss >> token;
                idx = piece_to_char().find(token);
                if(sq>=0 && sq<SQUARE_NB){
                    unpromotedBoard[sq] = Piece(idx);
                    promotedPieces |= SquareBB[sq];
                }else{
                    printf("error, sq error: %d\n", sq);
                    break;
                }
                put_piece(make_piece(color_of(Piece(idx)), promoted_piece_type(type_of(Piece(idx)))), sq);
                ++sq;
            }
            // Set flag for promoted pieces
            else if (captures_to_hand() && !drop_loop() && token == '~') {
                if(sq-1>=0 && sq-1<SQUARE_NB){
                    promotedPieces |= SquareBB[sq - 1];
                }else{
                    printf("error, sq-1 error: %d\n", sq);
                }
            }
            // Stop before pieces in hand
            else if (token == '[') {
                break;
            }
        }
        // Pieces in hand
        if (!isspace(token)) {
            while ((ss >> token) && !isspace(token))
            {
                if (token == ']')
                    continue;
                else if ((idx = piece_to_char().find(token)) != string::npos)
                    add_to_hand(color_of(Piece(idx)), type_of(Piece(idx)));
            }
        }
        
        // 2. Active color
        ss >> token;
        sideToMove = (token == 'w' ? WHITE : BLACK);
        ss >> token;
        
        // 3-4. Skip parsing castling and en passant flags if not present
        st->epSquare = SQ_NONE;
        if (!isdigit(ss.peek()))
        {
            // 3. Castling availability. Compatible with 3 standards: Normal FEN standard,
            // Shredder-FEN that uses the letters of the columns on which the rooks began
            // the game instead of KQkq and also X-FEN standard that, in case of Chess960,
            // if an inner rook is associated with the castling right, the castling tag is
            // replaced by the file letter of the involved rook, as for the Shredder-FEN.
            while ((ss >> token) && !isspace(token))
            {
                Square rsq;
                Color c = islower(token) ? BLACK : WHITE;
                Piece rook = make_piece(c, ROOK);
                
                token = char(toupper(token));
                
                if (token == 'K')
                    for (rsq = relative_square(c, SQ_H1); piece_on(rsq) != rook; --rsq) {}
                
                else if (token == 'Q')
                    for (rsq = relative_square(c, SQ_A1); piece_on(rsq) != rook; ++rsq) {}
                
                else if (token >= 'A' && token <= 'H')
                    rsq = make_square(File(token - 'A'), relative_rank(c, RANK_1));
                
                else
                    continue;
                
                set_castling_right(c, rsq);
            }
            
            // 4. En passant square. Ignore if no pawn capture is possible
            if (   ((ss >> col) && (col >= 'a' && col <= 'h'))
                && ((ss >> row) && (row == '3' || row == '6')))
            {
                st->epSquare = make_square(File(col - 'a'), Rank(row - '1'));
                
                if (   !(attackers_to(st->epSquare) & pieces(sideToMove, PAWN))
                    || !(pieces(~sideToMove, PAWN) & (st->epSquare + pawn_push(~sideToMove))))
                    st->epSquare = SQ_NONE;
            }
        }
        
        // Check counter for nCheck
        ss >> std::skipws >> token;
        
        if (max_check_count() && ss.peek() == '+')
        {
            st->checksGiven[WHITE] = CheckCount(max(max_check_count() - max(token - '0', 0), 0));
            ss >> token >> token;
            st->checksGiven[BLACK] = CheckCount(max(max_check_count() - max(token - '0', 0), 0));
        }
        else
            ss.putback(token);
        
        // 5-6. Halfmove clock and fullmove number
        ss >> std::skipws >> st->rule50 >> gamePly;
        
        // Convert from fullmove starting from 1 to gamePly starting from 0,
        // handle also common incorrect FEN with fullmove = 0.
        gamePly = max(2 * (gamePly - 1), 0) + (sideToMove == BLACK);
        
        chess960 = isChess960;
        thisThread = th;
        set_state(st);
        
        // assert(pos_is_ok());
        if(!pos_is_ok()){
            printf("error, assert(pos_is_ok())\n");
        }
        
        return *this;
    }
    
    
    /// Position::set_castling_right() is a helper function used to set castling
    /// rights given the corresponding color and the rook starting square.
    
    void Position::set_castling_right(Color c, Square rfrom) {
        
        Square kfrom = count<KING>(c) ? square<KING>(c) : make_square(FILE_E, c == WHITE ? RANK_1 : RANK_8);
        CastlingSide cs = kfrom < rfrom ? KING_SIDE : QUEEN_SIDE;
        CastlingRight cr = (c | cs);
        
        st->castlingRights |= cr;
        castlingRightsMask[kfrom] |= cr;
        castlingRightsMask[rfrom] |= cr;
        castlingRookSquare[cr] = rfrom;
        
        Square kto = relative_square(c, cs == KING_SIDE ? SQ_G1 : SQ_C1);
        Square rto = relative_square(c, cs == KING_SIDE ? SQ_F1 : SQ_D1);
        
        for (Square s = min(rfrom, rto); s <= max(rfrom, rto); ++s)
            if (s != kfrom && s != rfrom)
                castlingPath[cr] |= s;
        
        for (Square s = min(kfrom, kto); s <= max(kfrom, kto); ++s)
            if (s != kfrom && s != rfrom)
                castlingPath[cr] |= s;
    }
    
    
    /// Position::set_check_info() sets king attacks to detect if a move gives check
    
    void Position::set_check_info(StateInfo* si) const {
        
        si->blockersForKing[WHITE] = slider_blockers(pieces(BLACK), count<KING>(WHITE) ? square<KING>(WHITE) : SQ_NONE, si->pinners[BLACK]);
        si->blockersForKing[BLACK] = slider_blockers(pieces(WHITE), count<KING>(BLACK) ? square<KING>(BLACK) : SQ_NONE, si->pinners[WHITE]);
        
        Square ksq = count<KING>(~sideToMove) ? square<KING>(~sideToMove) : SQ_NONE;
        
        for (PieceType pt = PAWN; pt < KING; ++pt)
            si->checkSquares[pt] = ksq != SQ_NONE ? attacks_from(~sideToMove, pt, ksq) : 0;
        si->checkSquares[KING]   = 0;
    }
    
    
    /// Position::set_state() computes the hash keys of the position, and other
    /// data that once computed is updated incrementally as moves are made.
    /// The function is only used when a new position is set up, and to verify
    /// the correctness of the StateInfo data when running in debug mode.
    
    void Position::set_state(StateInfo* si) const {
        
        si->key = si->materialKey = 0;
        si->pawnKey = Zobrist::noPawns;
        si->nonPawnMaterial[WHITE] = si->nonPawnMaterial[BLACK] = VALUE_ZERO;
        si->psq = SCORE_ZERO;
        si->checkersBB = count<KING>(sideToMove) ? attackers_to(square<KING>(sideToMove)) & pieces(~sideToMove) : 0;
        
        set_check_info(si);
        
        for (Bitboard b = pieces(); b; )
        {
            Square s = pop_lsb(&b);
            Piece pc = piece_on(s);
            si->key ^= Zobrist::psq[pc][s];
            si->psq += PSQT::psq[pc][s];
        }
        // pieces in hand
        if (piece_drops())
        {
            for (Color c = WHITE; c <= BLACK; ++c)
                for (PieceType pt = PAWN; pt <= KING; ++pt)
                {
                    Piece pc = make_piece(c, pt);
                    si->psq += PSQT::psq[pc][SQ_NONE] * pieceCountInHand[color_of(pc)][type_of(pc)];
                }
        }
        
        if (si->epSquare != SQ_NONE)
            si->key ^= Zobrist::enpassant[file_of(si->epSquare)];
        
        if (sideToMove == BLACK)
            si->key ^= Zobrist::side;
        
        si->key ^= Zobrist::castling[si->castlingRights];
        
        for (Bitboard b = pieces(PAWN); b; )
        {
            Square s = pop_lsb(&b);
            si->pawnKey ^= Zobrist::psq[piece_on(s)][s];
        }
        
        for (Color c = WHITE; c <= BLACK; ++c)
            for (PieceType pt = PAWN; pt <= KING; ++pt)
            {
                Piece pc = make_piece(c, pt);
                if (pt != PAWN && pt != KING)
                    si->nonPawnMaterial[c] += pieceCount[pc] * PieceValue[MG][pc];
                
                for (int32_t cnt = 0; cnt < pieceCount[pc]; ++cnt)
                    si->materialKey ^= Zobrist::psq[pc][cnt];
                
                if (piece_drops())
                {
                    if (type_of(pc) != PAWN && type_of(pc) != KING)
                        si->nonPawnMaterial[color_of(pc)] += pieceCountInHand[color_of(pc)][type_of(pc)] * PieceValue[MG][pc];
                    si->key ^= Zobrist::inHand[pc][pieceCountInHand[color_of(pc)][type_of(pc)]];
                }
            }
        
        if (max_check_count())
            for (Color c = WHITE; c <= BLACK; ++c)
                si->key ^= Zobrist::checks[c][si->checksGiven[c]];
    }
    
    
    /// Position::set() is an overload to initialize the position object with
    /// the given endgame code string like "KBPKN". It is mainly a helper to
    /// get the material key out of an endgame code.
    
    Position& Position::set(const string& code, Color c, StateInfo* si) {
        
        // assert(code.length() > 0 && code.length() < 8);
        if(!(code.length() > 0 && code.length() < 8)){
            printf("error, assert(code.length() > 0 && code.length() < 8)\n");
        }
        // assert(code[0] == 'K');
        if(code[0] != 'K'){
            printf("error, assert(code[0] == 'K')\n");
        }
        
        string sides[] = { code.substr(code.find('K', 1)),      // Weak
            code.substr(0, code.find('K', 1)) }; // Strong
        
        std::transform(sides[c].begin(), sides[c].end(), sides[c].begin(), ::tolower);
        
        string fenStr = "8/" + sides[0] + char(8 - sides[0].length() + '0') + "/8/8/8/8/"
        + sides[1] + char(8 - sides[1].length() + '0') + "/8 w - - 0 10";
        
        return set(variants.find("chess")->second, fenStr, false, si, nullptr);
    }
    
    
    /// Position::fen() returns a FEN representation of the position. In case of
    /// Chess960 the Shredder-FEN notation is used. This is mainly a debugging function.
    
    const string Position::fen() const {

        int32_t emptyCnt;
        std::ostringstream ss;
        
        for (Rank r = max_rank(); r >= RANK_1; --r)
        {
            for (File f = FILE_A; f <= max_file(); ++f)
            {
                for (emptyCnt = 0; f <= max_file() && empty(make_square(f, r)); ++f)
                    ++emptyCnt;
                
                if (emptyCnt)
                    ss << emptyCnt;
                
                if (f <= max_file())
                {
                    if (unpromoted_piece_on(make_square(f, r)))
                        // Promoted shogi pieces, e.g., +r for dragon
                        ss << "+" << piece_to_char()[unpromoted_piece_on(make_square(f, r))];
                    else
                    {
                        ss << piece_to_char()[piece_on(make_square(f, r))];
                        
                        // Set promoted pieces
                        if (captures_to_hand() && is_promoted(make_square(f, r)))
                            ss << "~";
                    }
                }
            }
            
            if (r > RANK_1)
                ss << '/';
        }
        
        // pieces in hand
        if (piece_drops())
        {
            ss << '[';
            for (Color c = WHITE; c <= BLACK; ++c)
                for (PieceType pt = PieceType(KING - 1); pt >= PAWN; --pt)
                    ss << std::string(pieceCountInHand[c][pt], piece_to_char()[make_piece(c, pt)]);
            ss << ']';
        }
        
        ss << (sideToMove == WHITE ? " w " : " b ");
        
        if (can_castle(WHITE_OO))
            ss << (chess960 ? char('A' + file_of(castling_rook_square(WHITE |  KING_SIDE))) : 'K');
        
        if (can_castle(WHITE_OOO))
            ss << (chess960 ? char('A' + file_of(castling_rook_square(WHITE | QUEEN_SIDE))) : 'Q');
        
        if (can_castle(BLACK_OO))
            ss << (chess960 ? char('a' + file_of(castling_rook_square(BLACK |  KING_SIDE))) : 'k');
        
        if (can_castle(BLACK_OOO))
            ss << (chess960 ? char('a' + file_of(castling_rook_square(BLACK | QUEEN_SIDE))) : 'q');
        
        if (!can_castle(WHITE) && !can_castle(BLACK))
            ss << '-';
        
        // check count
        if (max_check_count())
            ss << " " << (max_check_count() - st->checksGiven[WHITE]) << "+" << (max_check_count() - st->checksGiven[BLACK]);
        
        ss << (ep_square() == SQ_NONE ? " - " : " " + UCI::square(ep_square()) + " ")
        << st->rule50 << " " << 1 + (gamePly - (sideToMove == BLACK)) / 2;
        
        return ss.str();
    }
    
    void Position::myFen(char* ss) const
    {
        int32_t emptyCnt;
        ss[0] = 0;
        
        for (Rank r = max_rank(); r >= RANK_1; --r)
        {
            for (File f = FILE_A; f <= max_file(); ++f)
            {
                for (emptyCnt = 0; f <= max_file() && empty(make_square(f, r)); ++f) {
                    ++emptyCnt;
                }
                
                if (emptyCnt) {
                    sprintf(ss, "%s%d", ss, emptyCnt);
                }
                
                if (f <= max_file())
                {
                    if (unpromoted_piece_on(make_square(f, r))) {
                        // Promoted shogi pieces, e.g., +r for dragon
                        sprintf(ss, "%s+%c", ss, piece_to_char()[unpromoted_piece_on(make_square(f, r))]);
                    }
                    else
                    {
                        // ss << piece_to_char()[piece_on(make_square(f, r))];
                        sprintf(ss, "%s%c", ss, piece_to_char()[piece_on(make_square(f, r))]);
                        
                        // Set promoted pieces
                        if (captures_to_hand() && is_promoted(make_square(f, r))) {
                            // ss << "~";
                            sprintf(ss, "%s~", ss);
                        }
                    }
                }
            }
            
            if (r > RANK_1) {
                // ss << '/';
                sprintf(ss, "%s/", ss);
            }
        }
        
        // pieces in hand
        if (piece_drops())
        {
            // ss << '[';
            sprintf(ss, "%s[", ss);
            for (Color c = WHITE; c <= BLACK; ++c)
                for (PieceType pt = PieceType(KING - 1); pt >= PAWN; --pt) {
                    // ss << std::string(pieceCountInHand[c][pt], piece_to_char()[make_piece(c, pt)]);
                    for(int32_t i=0; i<pieceCountInHand[c][pt]; i++){
                        sprintf(ss, "%s%c", ss, piece_to_char()[make_piece(c, pt)]);
                    }
                }
            // ss << ']';
            sprintf(ss, "%s]", ss);
        }
        
        // ss << (sideToMove == WHITE ? " w " : " b ");
        sprintf(ss, "%s%s", ss, (sideToMove == WHITE ? " w " : " b "));
        
        if (can_castle(WHITE_OO)) {
            // ss << (chess960 ? char('A' + file_of(castling_rook_square(WHITE |  KING_SIDE))) : 'K');
            sprintf(ss, "%s%c", ss, (chess960 ? char('A' + file_of(castling_rook_square(WHITE |  KING_SIDE))) : 'K'));
        }
        
        if (can_castle(WHITE_OOO)) {
            // ss << (chess960 ? char('A' + file_of(castling_rook_square(WHITE | QUEEN_SIDE))) : 'Q');
            sprintf(ss, "%s%c", ss, (chess960 ? char('A' + file_of(castling_rook_square(WHITE | QUEEN_SIDE))) : 'Q'));
        }
        
        if (can_castle(BLACK_OO)) {
            // ss << (chess960 ? char('a' + file_of(castling_rook_square(BLACK |  KING_SIDE))) : 'k');
            sprintf(ss, "%s%c", ss, (chess960 ? char('a' + file_of(castling_rook_square(BLACK |  KING_SIDE))) : 'k'));
        }
        
        if (can_castle(BLACK_OOO)) {
            // ss << (chess960 ? char('a' + file_of(castling_rook_square(BLACK | QUEEN_SIDE))) : 'q');
            sprintf(ss, "%s%c", ss, (chess960 ? char('a' + file_of(castling_rook_square(BLACK | QUEEN_SIDE))) : 'q'));
        }
        
        if (!can_castle(WHITE) && !can_castle(BLACK)) {
            // ss << '-';
            sprintf(ss, "%s-", ss);
        }
        
        // check count
        if (max_check_count()) {
            //ss << " " << (max_check_count() - st->checksGiven[WHITE]) << "+" << (max_check_count() - st->checksGiven[BLACK]);
            sprintf(ss, "%s %d+%d", ss, (max_check_count() - st->checksGiven[WHITE]), (max_check_count() - st->checksGiven[BLACK]));
        }
        
        // ss << (ep_square() == SQ_NONE ? " - " : " " + UCI::square(ep_square()) + " ") << st->rule50 << " " << 1 + (gamePly - (sideToMove == BLACK)) / 2;
        {
            char strSquare[20];
            {
                strSquare[0] = 0;
                if(ep_square() == SQ_NONE){
                    sprintf(strSquare, "%s - ", strSquare);
                } else {
                    char sq[20];
                    {
                        sq[0] = 0;
                        UCI::square(sq, ep_square());
                    }
                    sprintf(strSquare, "%s %s ", strSquare, sq);
                }
            }
            sprintf(ss, "%s%s%d %d", ss, strSquare, st->rule50, 1 + (gamePly - (sideToMove == BLACK)) / 2);
        }
    }
    
    /// Position::slider_blockers() returns a bitboard of all the pieces (both colors)
    /// that are blocking attacks on the square 's' from 'sliders'. A piece blocks a
    /// slider if removing that piece from the board would result in a position where
    /// square 's' is attacked. For example, a king-attack blocking piece can be either
    /// a pinned or a discovered check piece, according if its color is the opposite
    /// or the same of the color of the slider.
    
    Bitboard Position::slider_blockers(Bitboard sliders, Square s, Bitboard& pinners) const {
        
        Bitboard blockers = 0;
        pinners = 0;
        
        if (s == SQ_NONE)
            return blockers;
        
        // Snipers are sliders that attack 's' when a piece is removed
        Bitboard snipers =   sliders
        &  attackers_to(s, 0)
        & ~attackers_to(s);
        
        while (snipers)
        {
            Square sniperSq = pop_lsb(&snipers);
            Bitboard b = between_bb(s, sniperSq) & pieces();
            
            if (b && !more_than_one(b))
            {
                blockers |= b;
                if (b & pieces(color_of(piece_on(s))))
                    pinners |= sniperSq;
            }
        }
        return blockers;
    }
    
    
    /// Position::attackers_to() computes a bitboard of all pieces which attack a
    /// given square. Slider attacks use the occupied bitboard to indicate occupancy.
    
    Bitboard Position::attackers_to(Square s, Bitboard occupied) const {
        
        Bitboard b = 0;
        for (Color c = WHITE; c <= BLACK; ++c)
            for (PieceType pt = PAWN; pt <= KING; ++pt)
                b |= attacks_bb(~c, pt, s, occupied) & pieces(c, pt);
        return b;
    }
    
    
    /// Position::legal() tests whether a pseudo-legal move is legal
    
    bool Position::legal(Move m) const {
        // assert(is_ok(m));
        // printf("legal: %d\n", this->game_ply());
        if(!is_ok(m)){
            printf("error, assert(is_ok(m))\n");
        }
        // assert(type_of(m) != DROP || piece_drops());
        if(!(type_of(m) != DROP || piece_drops())){
            printf("error, assert(type_of(m) != DROP || piece_drops())\n");
        }
        
        Color us = sideToMove;
        Square from = from_sq(m);
        Square to = to_sq(m);
        Square ksq = count<KING>(us) ? square<KING>(us) : SQ_NONE;
        
        // assert(color_of(moved_piece(m)) == us);
        if(color_of(moved_piece(m)) != us){
            printf("error, assert(color_of(moved_piece(m)) == us)\n");
        }
        // assert(!count<KING>(us) || piece_on(square<KING>(us)) == make_piece(us, KING));
        if(!(!count<KING>(us) || piece_on(square<KING>(us)) == make_piece(us, KING))){
            printf("error, assert(!count<KING>(us) || piece_on(square<KING>(us)) == make_piece(us, KING))\n");
        }
        
        // illegal moves to squares outside of board
        if (!(board_bb() & to))
            return false;
        
        // illegal checks
        if (!checking_permitted() && gives_check(m))
            return false;
        
        // illegal quiet moves
        if (must_capture() && !capture(m))
        {
            if (checkers())
            {
                for (const auto& mevasion : MoveList<EVASIONS>((Position*)this))
                    if (capture(mevasion) && legal(mevasion))
                        return false;
            }
            else
            {
                for (const auto& mcap : MoveList<CAPTURES>((Position*)this))
                    if (capture(mcap) && legal(mcap))
                        return false;
            }
        }
        
        // no legal moves from target square
        if ((type_of(m) == DROP || type_of(m) == NORMAL) && !(moves_bb(us, type_of(moved_piece(m)), to, 0) & board_bb()))
            return false;
        
        // illegal drops
        if (piece_drops() && type_of(m) == DROP)
            return pieceCountInHand[us][type_of(moved_piece(m))] && empty(to_sq(m));
        
        // game end
        if (is_variant_end())
            return false;
        
        // En passant captures are a tricky special case. Because they are rather
        // uncommon, we do it simply by testing whether the king is attacked after
        // the move is made.
        if (type_of(m) == ENPASSANT)
        {
            Square capsq = to - pawn_push(us);
            Bitboard occupied = (pieces() ^ from ^ capsq) | to;
            
            // assert(to == ep_square());
            if(to != ep_square()){
                printf("error, assert(to == ep_square())\n");
            }
            // assert(moved_piece(m) == make_piece(us, PAWN));
            if(moved_piece(m) != make_piece(us, PAWN)){
                printf("error, assert(moved_piece(m) == make_piece(us, PAWN))\n");
            }
            // assert(piece_on(capsq) == make_piece(~us, PAWN));
            if(piece_on(capsq) != make_piece(~us, PAWN)){
                printf("error, assert(piece_on(capsq) == make_piece(~us, PAWN))\n");
            }
            // assert(piece_on(to) == NO_PIECE);
            if(piece_on(to) != NO_PIECE){
                printf("error, assert(piece_on(to) == NO_PIECE)\n");
            }
            
            return !count<KING>(us) || !(attackers_to(ksq, occupied) & pieces(~us) & occupied);
        }
        
        // If the moving piece is a king, check whether the destination
        // square is attacked by the opponent. Castling moves are checked
        // for legality during move generation.
        if (type_of(moved_piece(m)) == KING)
            return type_of(m) == CASTLING || !(attackers_to(to) & pieces(~us));
        
        // A non-king move is legal if the king is not under attack after the move.
        return !count<KING>(us) || !(  attackers_to(ksq, (type_of(m) != DROP ? pieces() ^ from : pieces()) | to)
                                     & pieces(~us) & ~SquareBB[to]);
    }
    
    
    /// Position::pseudo_legal() takes a random move and tests whether the move is
    /// pseudo legal. It is used to validate moves from TT that can be corrupted
    /// due to SMP concurrent access or hash position key aliasing.
    
    bool Position::pseudo_legal(const Move m) const {
        
        Color us = sideToMove;
        Square from = from_sq(m);
        Square to = to_sq(m);
        Piece pc = moved_piece(m);
        
        // Use a slower but simpler function for uncommon cases
        if (type_of(m) != NORMAL)
            return MoveList<LEGAL>((Position*)this).contains(m);
        
        // Is not a promotion, so promotion piece must be empty
        if (promotion_type(m) != NO_PIECE_TYPE)
            return false;
        
        // If the 'from' square is not occupied by a piece belonging to the side to
        // move, the move is obviously not legal.
        if (pc == NO_PIECE || color_of(pc) != us)
            return false;
        
        // The destination square cannot be occupied by a friendly piece
        if (pieces(us) & to)
            return false;
        
        // Handle the special case of a pawn move
        if (type_of(pc) == PAWN)
        {
            // We have already handled promotion moves, so destination
            // cannot be on the 8th/1st rank.
            if (rank_of(to) == relative_rank(us, promotion_rank(), max_rank()))
                return false;
            
            if (   !(attacks_from<PAWN>(us, from) & pieces(~us) & to) // Not a capture
                && !((from + pawn_push(us) == to) && empty(to))       // Not a single push
                && !(   (from + 2 * pawn_push(us) == to)              // Not a double push
                     && (rank_of(from) == relative_rank(us, RANK_2))
                     && empty(to)
                     && empty(to - pawn_push(us))
                     && double_step_enabled()))
                return false;
        }
        else if (!(attacks_from(us, type_of(pc), from) & to))
            return false;
        
        // Evasions generator already takes care to avoid some kind of illegal moves
        // and legal() relies on this. We therefore have to take care that the same
        // kind of moves are filtered out here.
        if (checkers())
        {
            if (type_of(pc) != KING)
            {
                // Double check? In this case a king move is required
                if (more_than_one(checkers()))
                    return false;
                
                // Our move must be a blocking evasion or a capture of the checking piece
                Square checksq = lsb(checkers());
                if (  !((between_bb(checksq, square<KING>(us)) | checkers()) & to)
                    || (LeaperAttacks[~us][type_of(piece_on(checksq))][checksq] & square<KING>(us)))
                    return false;
            }
            // In case of king moves under check we have to remove king so as to catch
            // invalid moves like b1a1 when opposite queen is on c1.
            else if (attackers_to(to, pieces() ^ from) & pieces(~us))
                return false;
        }
        
        return true;
    }
    
    
    /// Position::gives_check() tests whether a pseudo-legal move gives a check
    
    bool Position::gives_check(Move m) const {
        
        // assert(is_ok(m));
        if(!is_ok(m)){
            printf("error, assert(is_ok(m))\n");
        }
        // assert(color_of(moved_piece(m)) == sideToMove);
        if(color_of(moved_piece(m)) != sideToMove){
            printf("error, assert(color_of(moved_piece(m)) == sideToMove)\n");
        }
        
        Square from = from_sq(m);
        Square to = to_sq(m);
        
        // No check possible without king
        if (!count<KING>(~sideToMove))
            return false;
        
        // Is there a direct check?
        if (type_of(m) != PROMOTION && type_of(m) != PIECE_PROMOTION && (st->checkSquares[type_of(moved_piece(m))] & to))
            return true;
        
        // Is there a discovered check?
        if (   type_of(m) != DROP
            && (st->blockersForKing[~sideToMove] & from)
            && (  !aligned(from, to, square<KING>(~sideToMove))
                || (attackers_to(square<KING>(~sideToMove), (pieces() ^ from) | to) & pieces(sideToMove))))
            return true;
        
        switch (type_of(m))
        {
            case NORMAL:
            case DROP:
                return false;
                
            case PROMOTION:
                return attacks_bb(sideToMove, promotion_type(m), to, pieces() ^ from) & square<KING>(~sideToMove);
                
            case PIECE_PROMOTION:
                return attacks_bb(sideToMove, promoted_piece_type(type_of(moved_piece(m))), to, pieces() ^ from) & square<KING>(~sideToMove);
                
                // En passant capture with check? We have already handled the case
                // of direct checks and ordinary discovered check, so the only case we
                // need to handle is the unusual case of a discovered check through
                // the captured pawn.
            case ENPASSANT:
            {
                Square capsq = make_square(file_of(to), rank_of(from));
                Bitboard b = (pieces() ^ from ^ capsq) | to;
                
                return attackers_to(square<KING>(~sideToMove), b) & pieces(sideToMove) & b;
            }
            case CASTLING:
            {
                Square kfrom = from;
                Square rfrom = to; // Castling is encoded as 'King captures the rook'
                Square kto = relative_square(sideToMove, rfrom > kfrom ? SQ_G1 : SQ_C1);
                Square rto = relative_square(sideToMove, rfrom > kfrom ? SQ_F1 : SQ_D1);
                
                return   (PseudoAttacks[sideToMove][ROOK][rto] & square<KING>(~sideToMove))
                && (attacks_bb<ROOK>(rto, (pieces() ^ kfrom ^ rfrom) | rto | kto) & square<KING>(~sideToMove));
            }
            default:
                // assert(false);
                printf("error, assert(false)\n");
                return false;
        }
    }
    
    
    /// Position::do_move() makes a move, and saves all information necessary
    /// to a StateInfo object. The move is assumed to be legal. Pseudo-legal
    /// moves should be filtered out before this function is called.
    
    void Position::do_move(Move m, StateInfo& newSt, bool givesCheck) {
        
        // assert(is_ok(m));
        if(!is_ok(m)){
            printf("error, assert(is_ok(m))\n");
        }
        // assert(&newSt != st);
        if(&newSt == st){
            printf("error, assert(&newSt != st)\n");
        }
        
        if(thisThread!=NULL){
            thisThread->nodes.fetch_add(1, std::memory_order_relaxed);
        } else {
            // printf("thisThread null\n");
        }
        Key k = st->key ^ Zobrist::side;
        
        // Copy some fields of the old state to our new StateInfo object except the
        // ones which are going to be recalculated from scratch anyway and then switch
        // our state pointer to point to the new (ready to be updated) state.
        std::memcpy(&newSt, st, offsetof(StateInfo, key));
        newSt.previous = st;
        st = &newSt;
        
        // Increment ply counters. In particular, rule50 will be reset to zero later on
        // in case of a capture or a pawn move.
        ++gamePly;
        ++st->rule50;
        ++st->pliesFromNull;
        
        Color us = sideToMove;
        Color them = ~us;
        Square from = from_sq(m);
        Square to = to_sq(m);
        Piece pc = moved_piece(m);
        Piece captured = type_of(m) == ENPASSANT ? make_piece(them, PAWN) : piece_on(to);
        Piece unpromotedCaptured = unpromoted_piece_on(to);
        
        // assert(color_of(pc) == us);
        if(color_of(pc) != us){
            printf("error, assert(color_of(pc) == us)\n");
        }
        // assert(captured == NO_PIECE || color_of(captured) == (type_of(m) != CASTLING ? them : us));
        if(!(captured == NO_PIECE || color_of(captured) == (type_of(m) != CASTLING ? them : us))){
            printf("error, assert(captured == NO_PIECE || color_of(captured) == (type_of(m) != CASTLING ? them : us))\n");
        }
        // assert(type_of(captured) != KING);
        if(type_of(captured) == KING){
            printf("error, assert(type_of(captured) != KING)\n");
        }
        
        if (max_check_count() && givesCheck)
            k ^= Zobrist::checks[us][st->checksGiven[us]] ^ Zobrist::checks[us][++(st->checksGiven[us])];
        
        if (type_of(m) == CASTLING)
        {
            // assert(type_of(pc) != NO_PIECE_TYPE);
            if(type_of(pc) == NO_PIECE_TYPE){
                printf("error, assert(type_of(pc) != NO_PIECE_TYPE)\n");
            }
            // assert(captured == make_piece(us, ROOK));
            if(captured != make_piece(us, ROOK)){
                printf("error, assert(captured == make_piece(us, ROOK))\n");
            }
            
            Square rfrom, rto;
            do_castling<true>(us, from, to, rfrom, rto);
            
            st->psq += PSQT::psq[captured][rto] - PSQT::psq[captured][rfrom];
            k ^= Zobrist::psq[captured][rfrom] ^ Zobrist::psq[captured][rto];
            captured = NO_PIECE;
        }
        
        if (captured)
        {
            Square capsq = to;
            
            // If the captured piece is a pawn, update pawn hash key, otherwise
            // update non-pawn material.
            if (type_of(captured) == PAWN)
            {
                if (type_of(m) == ENPASSANT)
                {
                    capsq -= pawn_push(us);
                    
                    // assert(pc == make_piece(us, PAWN));
                    if(pc != make_piece(us, PAWN)){
                        printf("error, assert(pc == make_piece(us, PAWN))\n");
                    }
                    // assert(to == st->epSquare);
                    if(to != st->epSquare){
                        printf("error, assert(to == st->epSquare)\n");
                    }
                    // assert(relative_rank(us, to) == RANK_6);
                    if(relative_rank(us, to) != RANK_6){
                        printf("error, assert(relative_rank(us, to) == RANK_6)\n");
                    }
                    // assert(piece_on(to) == NO_PIECE);
                    if(piece_on(to) != NO_PIECE){
                        printf("error, assert(piece_on(to) == NO_PIECE)\n");
                    }
                    // assert(piece_on(capsq) == make_piece(them, PAWN));
                    if(piece_on(capsq) != make_piece(them, PAWN)){
                        printf("error, assert(piece_on(capsq) == make_piece(them, PAWN))\n");
                    }
                    
                    board[capsq] = NO_PIECE; // Not done by remove_piece()
                }
                
                st->pawnKey ^= Zobrist::psq[captured][capsq];
            }
            else
            {
                st->nonPawnMaterial[them] -= PieceValue[MG][captured];
                if (captures_to_hand() && !is_promoted(to))
                    st->nonPawnMaterial[us] += PieceValue[MG][captured];
            }
            
            // Update board and piece lists
            remove_piece(captured, capsq);
            if (captures_to_hand())
            {
                st->capturedpromoted = is_promoted(to);
                Piece pieceToHand =  !is_promoted(to)   ? ~captured
                : unpromotedCaptured ? ~unpromotedCaptured
                : make_piece(~color_of(captured), PAWN);
                add_to_hand(color_of(pieceToHand), type_of(pieceToHand));
                st->psq += PSQT::psq[pieceToHand][SQ_NONE];
                k ^=  Zobrist::inHand[pieceToHand][pieceCountInHand[color_of(pieceToHand)][type_of(pieceToHand)] - 1]
                ^ Zobrist::inHand[pieceToHand][pieceCountInHand[color_of(pieceToHand)][type_of(pieceToHand)]];
                promotedPieces -= to;
            }
            unpromotedBoard[to] = NO_PIECE;
            
            // Update material hash key and prefetch access to materialTable
            k ^= Zobrist::psq[captured][capsq];
            st->materialKey ^= Zobrist::psq[captured][pieceCount[captured]];
            if(thisThread!=NULL) {
                prefetch((*(thisThread->materialTable))[st->materialKey]);
            } else {
                // printf("thisThread null\n");
            }
            
            // Update incremental scores
            st->psq -= PSQT::psq[captured][capsq];
            
            // Reset rule 50 counter
            st->rule50 = 0;
        }
        
        // Update hash key
        if (type_of(m) == DROP)
            k ^=  Zobrist::psq[pc][to]
            ^ Zobrist::inHand[pc][pieceCountInHand[color_of(pc)][type_of(pc)] - 1]
            ^ Zobrist::inHand[pc][pieceCountInHand[color_of(pc)][type_of(pc)]];
        else
            k ^= Zobrist::psq[pc][from] ^ Zobrist::psq[pc][to];
        
        // Reset en passant square
        if (st->epSquare != SQ_NONE)
        {
            k ^= Zobrist::enpassant[file_of(st->epSquare)];
            st->epSquare = SQ_NONE;
        }
        
        // Update castling rights if needed
        if (type_of(m) != DROP && st->castlingRights && (castlingRightsMask[from] | castlingRightsMask[to]))
        {
            int32_t cr = castlingRightsMask[from] | castlingRightsMask[to];
            k ^= Zobrist::castling[st->castlingRights & cr];
            st->castlingRights &= ~cr;
        }
        
        // Move the piece. The tricky Chess960 castling is handled earlier
        if (type_of(m) == DROP)
        {
            drop_piece(pc, to);
            st->materialKey ^= Zobrist::psq[pc][pieceCount[pc]-1];
        }
        else if (type_of(m) != CASTLING)
            move_piece(pc, from, to);
        
        // If the moving piece is a pawn do some special extra work
        if (type_of(pc) == PAWN)
        {
            // Set en-passant square if the moved pawn can be captured
            if (   (int(to) ^ int(from)) == 16
                && (attacks_from<PAWN>(us, to - pawn_push(us)) & pieces(them, PAWN)))
            {
                st->epSquare = to - pawn_push(us);
                k ^= Zobrist::enpassant[file_of(st->epSquare)];
            }
            
            else if (type_of(m) == PROMOTION)
            {
                Piece promotion = make_piece(us, promotion_type(m));
                
                // assert(relative_rank(us, to, max_rank()) == promotion_rank());
                if(relative_rank(us, to, max_rank()) != promotion_rank()){
                    printf("error, assert(relative_rank(us, to, max_rank()) == promotion_rank())\n");
                }
                // assert(type_of(promotion) >= KNIGHT && type_of(promotion) < KING);
                if(!(type_of(promotion) >= KNIGHT && type_of(promotion) < KING)){
                    printf("error, assert(type_of(promotion) >= KNIGHT && type_of(promotion) < KING)\n");
                }
                
                remove_piece(pc, to);
                put_piece(promotion, to);
                if (captures_to_hand() && !drop_loop())
                    promotedPieces = promotedPieces | to;
                
                // Update hash keys
                k ^= Zobrist::psq[pc][to] ^ Zobrist::psq[promotion][to];
                st->pawnKey ^= Zobrist::psq[pc][to];
                st->materialKey ^=  Zobrist::psq[promotion][pieceCount[promotion]-1]
                ^ Zobrist::psq[pc][pieceCount[pc]];
                
                // Update incremental score
                st->psq += PSQT::psq[promotion][to] - PSQT::psq[pc][to];
                
                // Update material
                st->nonPawnMaterial[us] += PieceValue[MG][promotion];
            }
            
            // Update pawn hash key and prefetch access to pawnsTable
            if (type_of(m) == DROP)
                st->pawnKey ^= Zobrist::psq[pc][to];
            else
                st->pawnKey ^= Zobrist::psq[pc][from] ^ Zobrist::psq[pc][to];
            if(thisThread!=NULL){
                prefetch2((*(thisThread->pawnsTable))[st->pawnKey]);
            }else{
                // printf("thisThread null\n");
            }
            
            // Reset rule 50 draw counter
            st->rule50 = 0;
        }
        else if (type_of(m) == PIECE_PROMOTION)
        {
            Piece promotion = make_piece(us, promoted_piece_type(type_of(pc)));
            
            remove_piece(pc, to);
            put_piece(promotion, to);
            promotedPieces |= to;
            unpromotedBoard[to] = pc;
            
            // Update hash keys
            k ^= Zobrist::psq[pc][to] ^ Zobrist::psq[promotion][to];
            st->materialKey ^=  Zobrist::psq[promotion][pieceCount[promotion]-1]
            ^ Zobrist::psq[pc][pieceCount[pc]];
            
            // Update incremental score
            st->psq += PSQT::psq[promotion][to] - PSQT::psq[pc][to];
            
            // Update material
            st->nonPawnMaterial[us] += PieceValue[MG][promotion] - PieceValue[MG][pc];
        }
        
        // Update incremental scores
        st->psq += PSQT::psq[pc][to] - PSQT::psq[pc][from];
        
        // Set capture piece
        st->capturedPiece = captured;
        st->unpromotedCapturedPiece = captured ? unpromotedCaptured : NO_PIECE;
        if (captures_to_hand() && !captured)
            st->capturedpromoted = false;
        
        // Update the key with the final value
        st->key = k;
        
        // Calculate checkers bitboard (if move gives check)
        st->checkersBB = givesCheck ? attackers_to(square<KING>(them)) & pieces(us) : 0;
        
        // Update information about promoted pieces
        if (type_of(m) != DROP && is_promoted(from))
            promotedPieces = (promotedPieces - from) | to;
        
        if (type_of(m) != DROP && unpromoted_piece_on(from))
        {
            unpromotedBoard[to] = unpromotedBoard[from];
            unpromotedBoard[from] = NO_PIECE;
        }
        
        sideToMove = ~sideToMove;
        
        // Update king attacks used for fast check detection
        set_check_info(st);
        
        // assert(pos_is_ok());
        if(!pos_is_ok()){
            printf("error, assert(pos_is_ok())\n");
        }
    }
    
    
    /// Position::undo_move() unmakes a move. When it returns, the position should
    /// be restored to exactly the same state as before the move was made.
    
    void Position::undo_move(Move m) {
        
        // assert(is_ok(m));
        if(!is_ok(m)){
            printf("error, assert(is_ok(m))\n");
        }
        
        sideToMove = ~sideToMove;
        
        Color us = sideToMove;
        Square from = from_sq(m);
        Square to = to_sq(m);
        Piece pc = piece_on(to);
        
        // assert(type_of(m) == DROP || empty(from) || type_of(m) == CASTLING);
        if(!(type_of(m) == DROP || empty(from) || type_of(m) == CASTLING)){
            printf("error, assert(type_of(m) == DROP || empty(from) || type_of(m) == CASTLING)\n");
        }
        // assert(type_of(st->capturedPiece) != KING);
        if(!(type_of(st->capturedPiece) != KING)){
            printf("error, assert(type_of(st->capturedPiece) != KING)\n");
        }
        
        if (type_of(m) == PROMOTION)
        {
            // assert(relative_rank(us, to, max_rank()) == promotion_rank());
            if(relative_rank(us, to, max_rank()) != promotion_rank()){
                printf("error, assert(relative_rank(us, to, max_rank()) == promotion_rank())\n");
            }
            // assert(type_of(pc) == promotion_type(m));
            if(type_of(pc) != promotion_type(m)){
                printf("error, assert(type_of(pc) == promotion_type(m))\n");
            }
            // assert(type_of(pc) >= KNIGHT && type_of(pc) < KING);
            if(!(type_of(pc) >= KNIGHT && type_of(pc) < KING)){
                printf("error, assert(type_of(pc) >= KNIGHT && type_of(pc) < KING)\n");
            }
            
            remove_piece(pc, to);
            pc = make_piece(us, PAWN);
            put_piece(pc, to);
            if (captures_to_hand() && !drop_loop())
                promotedPieces -= to;
        }
        else if (type_of(m) == PIECE_PROMOTION)
        {
            remove_piece(pc, to);
            pc = unpromoted_piece_on(to);
            put_piece(pc, to);
            unpromotedBoard[to] = NO_PIECE;
            promotedPieces -= to;
        }
        
        if (type_of(m) == CASTLING)
        {
            Square rfrom, rto;
            do_castling<false>(us, from, to, rfrom, rto);
        }
        else
        {
            if (type_of(m) == DROP)
                undrop_piece(pc, to); // Remove the dropped piece
            else
                move_piece(pc, to, from); // Put the piece back at the source square
            if (captures_to_hand() && !drop_loop() && is_promoted(to))
                promotedPieces = (promotedPieces - to) | from;
            if (unpromoted_piece_on(to))
            {
                unpromotedBoard[from] = unpromotedBoard[to];
                unpromotedBoard[to] = NO_PIECE;
            }
            
            if (st->capturedPiece)
            {
                Square capsq = to;
                
                if (type_of(m) == ENPASSANT)
                {
                    capsq -= pawn_push(us);
                    
                    // assert(type_of(pc) == PAWN);
                    if(type_of(pc) != PAWN){
                        printf("error, assert(type_of(pc) == PAWN)\n");
                    }
                    // assert(to == st->previous->epSquare);
                    if(to != st->previous->epSquare){
                        printf("error, assert(to == st->previous->epSquare)\n");
                    }
                    // assert(relative_rank(us, to) == RANK_6);
                    if(relative_rank(us, to) != RANK_6){
                        printf("error, assert(relative_rank(us, to) == RANK_6)\n");
                    }
                    // assert(piece_on(capsq) == NO_PIECE);
                    if(piece_on(capsq) != NO_PIECE){
                        printf("error, assert(piece_on(capsq) == NO_PIECE)\n");
                    }
                    // assert(st->capturedPiece == make_piece(~us, PAWN));
                    if(st->capturedPiece != make_piece(~us, PAWN)){
                        printf("error, assert(st->capturedPiece == make_piece(~us, PAWN))\n");
                    }
                }
                
                put_piece(st->capturedPiece, capsq); // Restore the captured piece
                if (captures_to_hand())
                {
                    remove_from_hand(~color_of(st->capturedPiece),
                                     !drop_loop() && st->capturedpromoted ? (st->unpromotedCapturedPiece ? type_of(st->unpromotedCapturedPiece)
                                                                             : PAWN)
                                     : type_of(st->capturedPiece));
                    if (!drop_loop() && st->capturedpromoted)
                        promotedPieces |= to;
                }
                if (st->unpromotedCapturedPiece)
                    unpromotedBoard[to] = st->unpromotedCapturedPiece;
            }
        }
        
        // Finally point our state pointer back to the previous state
        st = st->previous;
        --gamePly;
        
        // assert(pos_is_ok());
        if(!pos_is_ok()){
            printf("error, position not ok\n");
        }
    }
    
    
    /// Position::do_castling() is a helper used to do/undo a castling move. This
    /// is a bit tricky in Chess960 where from/to squares can overlap.
    template<bool Do>
    void Position::do_castling(Color us, Square from, Square& to, Square& rfrom, Square& rto) {
        
        bool kingSide = to > from;
        rfrom = to; // Castling is encoded as "king captures friendly rook"
        rto = relative_square(us, kingSide ? SQ_F1 : SQ_D1);
        to = relative_square(us, kingSide ? SQ_G1 : SQ_C1);
        
        // Remove both pieces first since squares could overlap in Chess960
        Piece castling_piece = piece_on(Do ? from : to);
        remove_piece(castling_piece, Do ? from : to);
        remove_piece(make_piece(us, ROOK), Do ? rfrom : rto);
        board[Do ? from : to] = board[Do ? rfrom : rto] = NO_PIECE; // Since remove_piece doesn't do it for us
        put_piece(castling_piece, Do ? to : from);
        put_piece(make_piece(us, ROOK), Do ? rto : rfrom);
    }
    
    
    /// Position::do(undo)_null_move() is used to do(undo) a "null move": It flips
    /// the side to move without executing any move on the board.
    
    void Position::do_null_move(StateInfo& newSt) {
        
        // assert(!checkers());
        if(checkers()){
            printf("error, assert(!checkers())\n");
        }
        // assert(&newSt != st);
        if(&newSt == st){
            printf("error, assert(&newSt != st)\n");
        }
        
        std::memcpy(&newSt, st, sizeof(StateInfo));
        newSt.previous = st;
        st = &newSt;
        
        if (st->epSquare != SQ_NONE)
        {
            st->key ^= Zobrist::enpassant[file_of(st->epSquare)];
            st->epSquare = SQ_NONE;
        }
        
        st->key ^= Zobrist::side;
        if(thisThread!=NULL){
            prefetch(thisThread->TT->first_entry(st->key));
        } else {
            printf("error, thisThread null\n");
        }
        
        ++st->rule50;
        st->pliesFromNull = 0;
        
        sideToMove = ~sideToMove;
        
        set_check_info(st);
        
        // assert(pos_is_ok());
        if(!pos_is_ok()){
            printf("error, assert(pos_is_ok())\n");
        }
    }
    
    void Position::undo_null_move() {
        
        // assert(!checkers());
        if(checkers()){
            printf("error, assert(!checkers())\n");
        }
        
        st = st->previous;
        sideToMove = ~sideToMove;
    }
    
    
    /// Position::key_after() computes the new hash key after the given move. Needed
    /// for speculative prefetch. It doesn't recognize special moves like castling,
    /// en-passant and promotions.
    
    Key Position::key_after(Move m) const {
        
        Square from = from_sq(m);
        Square to = to_sq(m);
        Piece pc = moved_piece(m);
        Piece captured = piece_on(to);
        Key k = st->key ^ Zobrist::side;
        
        if (captured)
        {
            k ^= Zobrist::psq[captured][to];
            if (captures_to_hand())
            {
                Piece removeFromHand = !drop_loop() && is_promoted(to) ? make_piece(~color_of(captured), PAWN) : ~captured;
                k ^= Zobrist::inHand[removeFromHand][pieceCountInHand[color_of(removeFromHand)][type_of(removeFromHand)] + 1]
                ^ Zobrist::inHand[removeFromHand][pieceCountInHand[color_of(removeFromHand)][type_of(removeFromHand)]];
            }
        }
        if (type_of(m) == DROP)
            return k ^ Zobrist::psq[pc][to] ^ Zobrist::inHand[pc][pieceCountInHand[color_of(pc)][type_of(pc)]]
            ^ Zobrist::inHand[pc][pieceCountInHand[color_of(pc)][type_of(pc)] - 1];
        
        return k ^ Zobrist::psq[pc][to] ^ Zobrist::psq[pc][from];
    }
    
    
    /// Position::see_ge (Static Exchange Evaluation Greater or Equal) tests if the
    /// SEE value of move is greater or equal to the given threshold. We'll use an
    /// algorithm similar to alpha-beta pruning with a null window.
    
    bool Position::see_ge(Move m, Value threshold) const {
        
        // assert(is_ok(m));
        if(!is_ok(m)){
            printf("error, assert(is_ok(m))\n");
        }
        
        // Only deal with normal moves, assume others pass a simple see
        if (type_of(m) != NORMAL)
            return VALUE_ZERO >= threshold;
        
        Bitboard stmAttackers;
        Square from = from_sq(m), to = to_sq(m);
        PieceType nextVictim = type_of(piece_on(from));
        Color us = color_of(piece_on(from));
        Color stm = ~us; // First consider opponent's move
        Value balance;   // Values of the pieces taken by us minus opponent's ones
        
        
        // nCheck
        if (max_check_count() && color_of(moved_piece(m)) == sideToMove && gives_check(m))
            return true;
        
        // Extinction
        if (   extinction_value() != VALUE_NONE
            && piece_on(to)
            && (   (   extinction_piece_types().find(type_of(piece_on(to))) != extinction_piece_types().end()
                    && pieceCount[piece_on(to)] == 1)
                || (   extinction_piece_types().find(ALL_PIECES) != extinction_piece_types().end()
                    && count<ALL_PIECES>(~sideToMove) == 1)))
            return extinction_value() < VALUE_ZERO;
        
        // The opponent may be able to recapture so this is the best result
        // we can hope for.
        balance = PieceValue[MG][piece_on(to)] - threshold;
        
        if (balance < VALUE_ZERO)
            return false;
        
        // Now assume the worst possible result: that the opponent can
        // capture our piece for free.
        balance -= PieceValue[MG][nextVictim];
        
        // If it is enough (like in PxQ) then return immediately. Note that
        // in case nextVictim == KING we always return here, this is ok
        // if the given move is legal.
        if (balance >= VALUE_ZERO)
            return true;
        
        // Find all attackers to the destination square, with the moving piece
        // removed, but possibly an X-ray attacker added behind it.
        Bitboard occupied = pieces() ^ from ^ to;
        Bitboard attackers = attackers_to(to, occupied) & occupied;
        
        while (true)
        {
            stmAttackers = attackers & pieces(stm);
            
            // Don't allow pinned pieces to attack (except the king) as long as
            // all pinners are on their original square.
            if (!(st->pinners[~stm] & ~occupied))
                stmAttackers &= ~st->blockersForKing[stm];
            
            // If stm has no more attackers then give up: stm loses
            if (!stmAttackers)
                break;
            
            // Locate and remove the next least valuable attacker, and add to
            // the bitboard 'attackers' the possibly X-ray attackers behind it.
            nextVictim = min_attacker<PAWN>(byTypeBB, to, stmAttackers, occupied, attackers);
            
            stm = ~stm; // Switch side to move
            
            // Negamax the balance with alpha = balance, beta = balance+1 and
            // add nextVictim's value.
            //
            //      (balance, balance+1) -> (-balance-1, -balance)
            //
            // assert(balance < VALUE_ZERO);
            if(balance >= VALUE_ZERO){
                printf("error, assert(balance < VALUE_ZERO)\n");
            }
            
            balance = -balance - 1 - PieceValue[MG][nextVictim];
            
            // If balance is still non-negative after giving away nextVictim then we
            // win. The only thing to be careful about it is that we should revert
            // stm if we captured with the king when the opponent still has attackers.
            if (balance >= VALUE_ZERO)
            {
                if (nextVictim == KING && (attackers & pieces(stm)))
                    stm = ~stm;
                break;
            }
            // assert(nextVictim != KING);
            if(nextVictim == KING){
                printf("error, assert(nextVictim != KING)\n");
            }
        }
        return us != stm; // We break the above loop when stm loses
    }
    
    
    /// Position::is_draw() tests whether the position is drawn by 50-move rule
    /// or by repetition. It does not detect stalemates.
    
    bool Position::is_draw(int32_t ply) const {
        // printf("is_draw: %p\n", st);
        if (st->rule50 > 99 && (!checkers() || MoveList<LEGAL>((Position*)this).size()))
            return true;

        int32_t end = captures_to_hand() ? st->pliesFromNull : min(st->rule50, st->pliesFromNull);
        
        if (end < 4)
            return false;
        
        StateInfo* stp = st->previous->previous;
        int32_t cnt = 0;
        
        for (int32_t i = 4; i <= end; i += 2)
        {
            stp = stp->previous->previous;
            
            // Return a draw score if a position repeats once earlier but strictly
            // after the root, or repeats twice before or at the root.
            if (   stp->key == st->key
                && ++cnt + (ply > i) == 2)
                return true;
        }
        
        return false;
    }
    
    
    // Position::has_repeated() tests whether there has been at least one repetition
    // of positions since the last capture or pawn move.
    
    bool Position::has_repeated() const {
        
        StateInfo* stc = st;
        while (true)
        {
            int32_t i = 4, end = min(stc->rule50, stc->pliesFromNull);
            
            if (end < i)
                return false;
            
            StateInfo* stp = stc->previous->previous;
            
            do {
                stp = stp->previous->previous;
                
                if (stp->key == stc->key)
                    return true;
                
                i += 2;
            } while (i <= end);
            
            stc = stc->previous;
        }
    }
    
    
    /// Position::has_game_cycle() tests if the position has a move which draws by repetition,
    /// or an earlier position has a move that directly reaches the current position.
    
    bool Position::has_game_cycle(int32_t ply) const {

        int32_t j;

        int32_t end = min(st->rule50, st->pliesFromNull);
        
        if (end < 3)
            return false;
        
        Key originalKey = st->key;
        StateInfo* stp = st->previous;
        
        for (int32_t i = 3; i <= end; i += 2)
        {
            stp = stp->previous->previous;
            
            Key moveKey = originalKey ^ stp->key;
            if (   (j = H1(moveKey), cuckoo[j] == moveKey)
                || (j = H2(moveKey), cuckoo[j] == moveKey))
            {
                Move move = cuckooMove[j];
                Square s1 = from_sq(move);
                Square s2 = to_sq(move);
                
                if (!(between_bb(s1, s2) & pieces()))
                {
                    // In the cuckoo table, both moves Rc1c5 and Rc5c1 are stored in the same
                    // location. We select the legal one by reversing the move variable if necessary.
                    if (empty(s1))
                        move = make_move(s2, s1);
                    
                    if (ply > i)
                        return true;
                    
                    // For repetitions before or at the root, require one more
                    StateInfo* next_stp = stp;
                    for (int32_t k = i + 2; k <= end; k += 2)
                    {
                        next_stp = next_stp->previous->previous;
                        if (next_stp->key == stp->key)
                            return true;
                    }
                }
            }
        }
        return false;
    }
    
    
    /// Position::flip() flips position with the white and black sides reversed. This
    /// is only useful for debugging e.g. for finding evaluation symmetry bugs.
    
    void Position::flip() {
        
        string f, token;
        std::stringstream ss(fen());
        
        for (Rank r = RANK_8; r >= RANK_1; --r) // Piece placement
        {
            std::getline(ss, token, r > RANK_1 ? '/' : ' ');
            f.insert(0, token + (f.empty() ? " " : "/"));
        }
        
        ss >> token; // Active color
        f += (token == "w" ? "B " : "W "); // Will be lowercased later
        
        ss >> token; // Castling availability
        f += token + " ";
        
        std::transform(f.begin(), f.end(), f.begin(),
                       [](char c) { return char(islower(c) ? toupper(c) : tolower(c)); });
        
        ss >> token; // En passant square
        f += (token == "-" ? token : token.replace(1, 1, token[1] == '3' ? "6" : "3"));
        
        std::getline(ss, token); // Half and full moves
        f += token;
        
        set(variant(), f, is_chess960(), st, this_thread());
        
        // assert(pos_is_ok());
        if(!pos_is_ok()){
            printf("error, assert(pos_is_ok())\n");
        }
    }
    
    
    /// Position::pos_is_ok() performs some consistency checks for the
    /// position object and raises an asserts if something wrong is detected.
    /// This is meant to be helpful when debugging.
    
    bool Position::pos_is_ok() const {
        
        constexpr bool Fast = true; // Quick (default) or full check?
        
        if (   (sideToMove != WHITE && sideToMove != BLACK)
            || (count<KING>(WHITE) && piece_on(square<KING>(WHITE)) != make_piece(WHITE, KING))
            || (count<KING>(BLACK) && piece_on(square<KING>(BLACK)) != make_piece(BLACK, KING))
            || (   ep_square() != SQ_NONE
                && relative_rank(sideToMove, ep_square()) != RANK_6)) {
                // assert(0 && "pos_is_ok: Default");
                printf("pos_is_ok: Default\n");
                return false;
            }
        
        if (Fast)
            return true;
        
        if (   pieceCount[make_piece(~sideToMove, KING)]
            && (attackers_to(square<KING>(~sideToMove)) & pieces(sideToMove))) {
            // assert(0 && "pos_is_ok: Kings");
            printf("pos_is_ok: Kings\n");
            return false;
        }
        
        if (   (pieces(PAWN) & Rank8BB)
            || pieceCount[make_piece(WHITE, PAWN)] > 16
            || pieceCount[make_piece(BLACK, PAWN)] > 16) {
            // assert(0 && "pos_is_ok: Pawns");
            printf("pos_is_ok: Pawns\n");
            return false;
        }
        
        if (   (pieces(WHITE) & pieces(BLACK))
            || (pieces(WHITE) | pieces(BLACK)) != pieces()
            || popcount(pieces(WHITE)) > 32
            || popcount(pieces(BLACK)) > 32) {
            // assert(0 && "pos_is_ok: Bitboards");
            printf("pos_is_ok: Bitboards\n");
            return false;
        }
        
        for (PieceType p1 = PAWN; p1 <= KING; ++p1)
            for (PieceType p2 = PAWN; p2 <= KING; ++p2)
                if (p1 != p2 && (pieces(p1) & pieces(p2))) {
                    // assert(0 && "pos_is_ok: Bitboards");
                    printf("pos_is_ok: Bitboards\n");
                    return false;
                }
        
        StateInfo si = *st;
        set_state(&si);
        if (std::memcmp(&si, st, sizeof(StateInfo))) {
            // assert(0 && "pos_is_ok: State");
            printf("pos_is_ok: State\n");
            return false;
        }
        
        for (Color c = WHITE; c <= BLACK; ++c)
            for (PieceType pt = PAWN; pt <= KING; ++pt)
            {
                Piece pc = make_piece(c, pt);
                if (   pieceCount[pc] != popcount(pieces(c, pt))
                    || pieceCount[pc] != std::count(board, board + SQUARE_NB, pc)) {
                    // assert(0 && "pos_is_ok: Pieces");
                    printf("pos_is_ok: Pieces\n");
                    return false;
                }
                
                for (int32_t i = 0; i < pieceCount[pc]; ++i)
                    if (board[pieceList[pc][i]] != pc || index[pieceList[pc][i]] != i) {
                        // assert(0 && "pos_is_ok: Index");
                        printf("pos_is_ok: Index\n");
                        return false;
                    }
            }
        
        for (Color c = WHITE; c <= BLACK; ++c)
            for (CastlingSide s = KING_SIDE; s <= QUEEN_SIDE; s = CastlingSide(s + 1))
            {
                if (!can_castle(c | s))
                    continue;
                
                if (   piece_on(castlingRookSquare[c | s]) != make_piece(c, ROOK)
                    || castlingRightsMask[castlingRookSquare[c | s]] != (c | s)
                    || (castlingRightsMask[square<KING>(c)] & (c | s)) != (c | s)) {
                    // assert(0 && "pos_is_ok: Castling");
                    printf("pos_is_ok: Castling\n");
                    return false;
                }
            }
        
        return true;
    }
    
    bool Position::myPosIsOk()
    {
        constexpr bool Fast = true; // Quick (default) or full check?
        
        if (   (sideToMove != WHITE && sideToMove != BLACK)
            || (count<KING>(WHITE) && piece_on(square<KING>(WHITE)) != make_piece(WHITE, KING))
            || (count<KING>(BLACK) && piece_on(square<KING>(BLACK)) != make_piece(BLACK, KING))
            || (   ep_square() != SQ_NONE
                && relative_rank(sideToMove, ep_square()) != RANK_6)) {
                // assert(0 && "pos_is_ok: Default");
                printf("pos_is_ok: Default\n");
                return false;
            }
        
        if (Fast)
            return true;
        
        if (   pieceCount[make_piece(~sideToMove, KING)]
            && (attackers_to(square<KING>(~sideToMove)) & pieces(sideToMove))) {
            // assert(0 && "pos_is_ok: Kings");
            printf("pos_is_ok: Kings\n");
            return false;
        }
        
        if (   (pieces(PAWN) & Rank8BB)
            || pieceCount[make_piece(WHITE, PAWN)] > 16
            || pieceCount[make_piece(BLACK, PAWN)] > 16) {
            // assert(0 && "pos_is_ok: Pawns");
            printf("pos_is_ok: Pawns\n");
            return false;
        }
        
        if (   (pieces(WHITE) & pieces(BLACK))
            || (pieces(WHITE) | pieces(BLACK)) != pieces()
            || popcount(pieces(WHITE)) > 32
            || popcount(pieces(BLACK)) > 32) {
            // assert(0 && "pos_is_ok: Bitboards");
            printf("pos_is_ok: Bitboards\n");
            return false;
        }
        
        for (PieceType p1 = PAWN; p1 <= KING; ++p1)
            for (PieceType p2 = PAWN; p2 <= KING; ++p2)
                if (p1 != p2 && (pieces(p1) & pieces(p2))) {
                    // assert(0 && "pos_is_ok: Bitboards");
                    printf("pos_is_ok: Bitboards\n");
                    return false;
                }
        
        StateInfo si = *st;
        set_state(&si);
        if (std::memcmp(&si, st, sizeof(StateInfo))) {
            // assert(0 && "pos_is_ok: State");
            printf("pos_is_ok: State\n");
            return false;
        }
        
        for (Color c = WHITE; c <= BLACK; ++c)
            for (PieceType pt = PAWN; pt <= KING; ++pt)
            {
                Piece pc = make_piece(c, pt);
                if (   pieceCount[pc] != popcount(pieces(c, pt))
                    || pieceCount[pc] != std::count(board, board + SQUARE_NB, pc)) {
                    // assert(0 && "pos_is_ok: Pieces");
                    printf("pos_is_ok: Pieces\n");
                    return false;
                }
                
                for (int32_t i = 0; i < pieceCount[pc]; ++i)
                    if (board[pieceList[pc][i]] != pc || index[pieceList[pc][i]] != i) {
                        // assert(0 && "pos_is_ok: Index");
                        printf("pos_is_ok: Index\n");
                        return false;
                    }
            }
        
        for (Color c = WHITE; c <= BLACK; ++c)
            for (CastlingSide s = KING_SIDE; s <= QUEEN_SIDE; s = CastlingSide(s + 1))
            {
                if (!can_castle(c | s))
                    continue;
                
                if (   piece_on(castlingRookSquare[c | s]) != make_piece(c, ROOK)
                    || castlingRightsMask[castlingRookSquare[c | s]] != (c | s)
                    || (castlingRightsMask[square<KING>(c)] & (c | s)) != (c | s)) {
                    // assert(0 && "pos_is_ok: Castling");
                    printf("pos_is_ok: Castling\n");
                    return false;
                }
            }
        
        return true;
    }
    
    /////////////////////////////////////////////////////////////////////////////////////
    //////////////////// Convert ///////////////////
    /////////////////////////////////////////////////////////////////////////////////////
    
    int32_t Position::getByteSize()
    {
        // get stateInfoSize
        int32_t stateInfoSize = 0;
        {
            // Key    pawnKey; public VP<ulong> pawnKey;
            stateInfoSize+=sizeof(uint64_t);
            // Key    materialKey;  public VP<ulong> materialKey;
            stateInfoSize+=sizeof(uint64_t);
            // Value  nonPawnMaterial[COLOR_NB]; public LP<int32_t> nonPawnMaterial;
            stateInfoSize+=sizeof(int32_t)*COLOR_NB;
            // int32_t    castlingRights; public VP<int32_t> castlingRights;
            stateInfoSize+=sizeof(int32_t);
            // int32_t    rule50; public VP<int32_t> rule50;
            stateInfoSize+=sizeof(int32_t);
            // int32_t    pliesFromNull;  public VP<int32_t> pliesFromNull;
            stateInfoSize+=sizeof(int32_t);
            // CheckCount checksGiven[COLOR_NB];
            stateInfoSize+=sizeof(int32_t)*COLOR_NB;
            // Score  psq;  public VP<int> psq;
            stateInfoSize+=sizeof(int32_t);
            // public VP<int> epSquare;
            stateInfoSize+=sizeof(int32_t);
            // Key        key; public VP<ulong> key;
            stateInfoSize+=sizeof(uint64_t);
            // Bitboard   checkersBB; public VP<ulong> checkersBB;
            stateInfoSize+=sizeof(uint64_t);
            // Piece      capturedPiece; public VP<int> capturedPiece;
            stateInfoSize+=sizeof(int32_t);
            // Piece      unpromotedCapturedPiece;
            stateInfoSize+=sizeof(int32_t);
            // Bitboard   blockersForKing[COLOR_NB]; public LP<ulong> blockersForKing;
            stateInfoSize+=sizeof(uint64_t)*COLOR_NB;
            //  Bitboard   pinners[COLOR_NB]; public LP<ulong> pinnersForKing;
            stateInfoSize+=sizeof(uint64_t)*COLOR_NB;
            // Bitboard   checkSquares[PIECE_TYPE_NB];*/
            stateInfoSize+=sizeof(uint64_t)*PIECE_TYPE_NB;
            // bool       capturedpromoted;
            stateInfoSize+=sizeof(bool);
            // print
            // printf("stateInfoSize: %d\n", stateInfoSize);
        }
        // get stateInfo count
        int32_t stateInfoCount = 0;
        {
            // find
            {
                StateInfo* st = this->st;
                while (st!=NULL) {
                    stateInfoCount++;
                    st = st->previous;
                }
            }
            
            // print
            // printf("stateInfoCount: %d\n", stateInfoCount);
        }
        // get other property size
        int32_t otherPropertySize = 0;
        {
            // Piece board[SQUARE_NB]; public LP<int> board;
            otherPropertySize+=sizeof(int32_t)*SQUARE_NB;
            // Piece unpromotedBoard[SQUARE_NB];
            otherPropertySize+=sizeof(int32_t)*SQUARE_NB;
            // Bitboard byTypeBB[PIECE_TYPE_NB]; public LP<ulong> byTypeBB;
            otherPropertySize+=sizeof(uint64_t)*PIECE_TYPE_NB;
            // Bitboard byColorBB[COLOR_NB]; public LP<ulong> byColorBB;
            otherPropertySize+=sizeof(uint64_t)*COLOR_NB;
            // int32_t pieceCount[PIECE_NB]; public LP<int32_t> pieceCount;
            otherPropertySize+=sizeof(int32_t)*PIECE_NB;
            // Square pieceList[PIECE_NB][16]; public LP<int> pieceList;
            otherPropertySize+=sizeof(int32_t)*PIECE_NB*16;
            // int32_t index[SQUARE_NB]; public LP<int32_t> index;
            otherPropertySize+=sizeof(int32_t)*SQUARE_NB;
            // int32_t castlingRightsMask[SQUARE_NB]; public LP<int32_t> castlingRightsMask;
            otherPropertySize+=sizeof(int32_t)*SQUARE_NB;
            // Square castlingRookSquare[CASTLING_RIGHT_NB]; public LP<int> castlingRookSquare;
            otherPropertySize+=sizeof(int32_t)*CASTLING_RIGHT_NB;
            // Bitboard castlingPath[CASTLING_RIGHT_NB]; public LP<ulong> castlingPath;
            otherPropertySize+=sizeof(uint64_t)*CASTLING_RIGHT_NB;
            // int32_t gamePly; public VP<int32_t> gamePly;
            otherPropertySize+=sizeof(int32_t);
            // Color sideToMove; public VP<int> sideToMove;
            otherPropertySize+=sizeof(int32_t);
            // VariantType variantType = asean;
            otherPropertySize+=sizeof(int32_t);
            // bool chess960; public VP<bool> chess960; int
            otherPropertySize+=sizeof(bool);
            // int32_t pieceCountInHand[COLOR_NB][PIECE_TYPE_NB];
            otherPropertySize+=sizeof(int32_t)*COLOR_NB*PIECE_TYPE_NB;
            // Bitboard promotedPieces;
            otherPropertySize+=sizeof(uint64_t);
            
            // print
            // printf("otherPropertySize: %d\n", otherPropertySize);
        }
        return otherPropertySize+(sizeof(int32_t)+stateInfoCount*stateInfoSize);
    }
    
    int32_t Position::convertToByteArray(Position* position, uint8_t* &byteArray)
    {
        // find length of return
        int32_t length = position->getByteSize();
        uint8_t* ret = (uint8_t*)calloc(length, sizeof(uint8_t));
        {
            int32_t pointerIndex = 0;
            // Piece board[SQUARE_NB]; public LP<int32_t> board;
            {
                int32_t size = SQUARE_NB*sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->board, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // Piece unpromotedBoard[SQUARE_NB];
            {
                int32_t size = SQUARE_NB*sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->unpromotedBoard, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // Bitboard byTypeBB[PIECE_TYPE_NB]; public LP<ulong> byTypeBB;
            {
                int32_t size = PIECE_TYPE_NB*sizeof(uint64_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->byTypeBB, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // Bitboard byColorBB[COLOR_NB]; public LP<ulong> byColorBB;
            {
                int32_t size = COLOR_NB*sizeof(uint64_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->byColorBB, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // int32_t pieceCount[PIECE_NB]; public LP<int32_t> pieceCount;
            {
                int32_t size = PIECE_NB*sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->pieceCount, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // Square pieceList[PIECE_NB][16]; public LP<int> pieceList;
            {
                int32_t size = PIECE_NB*16*sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->pieceList, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // int32_t index[SQUARE_NB]; public LP<int32_t> index;
            {
                int32_t size = SQUARE_NB*sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->index, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // int32_t castlingRightsMask[SQUARE_NB]; public LP<int32_t> castlingRightsMask;
            {
                int32_t size = SQUARE_NB*sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->castlingRightsMask, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // Square castlingRookSquare[CASTLING_RIGHT_NB]; public LP<int32_t> castlingRookSquare;
            {
                int32_t size = CASTLING_RIGHT_NB*sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->castlingRookSquare, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // Bitboard castlingPath[CASTLING_RIGHT_NB]; public LP<ulong> castlingPath;
            {
                int32_t size = CASTLING_RIGHT_NB*sizeof(uint64_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->castlingPath, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // int32_t gamePly; public VP<int32_t> gamePly;
            {
                int32_t size = sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &position->gamePly, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // Color sideToMove; public VP<int32_t> sideToMove;
            {
                int32_t size = sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &position->sideToMove, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // VariantType variantType = asean;
            {
                VariantType variantType = getVariantTypeByVar(position->var);
                int32_t size = sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &variantType, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // StateInfo* st; public LP<StateInfo> st;
            {
                // get list of state info
                std::vector<StateInfo*> sts;
                {
                    StateInfo* st = position->st;
                    while (st!=NULL) {
                        sts.push_back(st);
                        st = st->previous;
                    }
                }
                // write stateInfo count
                {
                    int32_t stateInfoCount = (int32_t)sts.size();
                    // write
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(ret + pointerIndex, &stateInfoCount, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                    }
                }
                // write all stateInfo: tu turn thap den turn cao
                {
                    for(int64_t i= sts.size()-1; i>=0; i--){
                        StateInfo* st = sts[i];
                        // write
                        {
                            // public VP<uint64_t> pawnKey;
                            {
                                int32_t size = sizeof(uint64_t);
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, &st->pawnKey, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                            // public VP<uint64_t> materialKey;
                            {
                                int32_t size = sizeof(uint64_t);
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, &st->materialKey, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                            // public LP<int32_t> nonPawnMaterial; // [COLOR_NB]
                            {
                                int32_t size = COLOR_NB*sizeof(int32_t);
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, st->nonPawnMaterial, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                            // public VP<int32_t> castlingRights;
                            {
                                int32_t size = sizeof(int32_t);
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, &st->castlingRights, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                            // public VP<int32_t> rule50;
                            {
                                int32_t size = sizeof(int32_t);
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, &st->rule50, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                            // public VP<int32_t> pliesFromNull;
                            {
                                int32_t size = sizeof(int32_t);
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, &st->pliesFromNull, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                            // CheckCount checksGiven[COLOR_NB];
                            {
                                int32_t size = COLOR_NB*sizeof(int32_t);
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, st->checksGiven, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                            // public VP<int32_t> psq;
                            {
                                int32_t size = sizeof(int32_t);
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, &st->psq, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                            // public VP<int32_t> epSquare;
                            {
                                int32_t size = sizeof(int32_t);
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, &st->epSquare, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                            // public VP<ulong> key;
                            {
                                int32_t size = sizeof(uint64_t);
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, &st->key, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                            // public VP<ulong> checkersBB;
                            {
                                int32_t size = sizeof(uint64_t);
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, &st->checkersBB, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                            // public VP<int> capturedPiece;
                            {
                                int32_t size = sizeof(int32_t);
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, &st->capturedPiece, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                            // Piece      unpromotedCapturedPiece;
                            {
                                int32_t size = sizeof(int32_t);
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, &st->unpromotedCapturedPiece, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                            // public LP<ulong> blockersForKing;// [COLOR_NB]
                            {
                                int32_t size = sizeof(uint64_t)*COLOR_NB;
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, st->blockersForKing, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                            // Bitboard   pinners[COLOR_NB];
                            {
                                int32_t size = sizeof(uint64_t)*COLOR_NB;
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, st->pinners, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                            // public LP<ulong> checkSquares;// [PIECE_TYPE_NB]
                            {
                                int32_t size = sizeof(uint64_t)*PIECE_TYPE_NB;
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, st->checkSquares, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                            // bool capturedpromoted
                            {
                                int32_t size = sizeof(bool);
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, &st->capturedpromoted, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                        }
                    }
                }
            }
            // bool chess960; public VP<bool> chess960;
            {
                int32_t size = sizeof(bool);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &position->chess960, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: chess960: %d, %d\n", pointerIndex, length);
                }
            }
            // int32_t pieceCountInHand[COLOR_NB][PIECE_TYPE_NB];
            {
                int32_t size = sizeof(int)*COLOR_NB*PIECE_TYPE_NB;
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &position->pieceCountInHand, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: pieceCountInHand: %d, %d\n", pointerIndex, length);
                }
            }
            // Bitboard promotedPieces;
            {
                int32_t size = sizeof(uint64_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, &position->promotedPieces, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: promotedPieces: %d, %d\n", pointerIndex, length);
                }
            }
            // printf("convert position to array: return value: %d; %d\n", pointerIndex, length);
        }
        byteArray = ret;
        return length;
    }
    
    int32_t Position::parseByteArray(Position* position, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect)
    {
        int32_t pointerIndex = start;
        int32_t index = 0;
        bool isParseCorrect = true;
        while (pointerIndex < length) {
            bool alreadyPassAll = false;
            switch (index) {
                case 0:
                {
                    // Piece board[SQUARE_NB]; public LP<int> board;
                    int32_t size = sizeof(int32_t)*SQUARE_NB;
                    if(pointerIndex+size<=length){
                        memcpy(position->board, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 1:
                {
                    // Piece unpromotedBoard[SQUARE_NB];
                    int32_t size = sizeof(int32_t)*SQUARE_NB;
                    if(pointerIndex+size<=length){
                        memcpy(position->unpromotedBoard, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                    
                case 2:
                {
                    // Bitboard byTypeBB[PIECE_TYPE_NB]; public LP<ulong> byTypeBB;
                    int32_t size = sizeof(uint64_t)*PIECE_TYPE_NB;
                    if(pointerIndex+size<=length){
                        memcpy(position->byTypeBB, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 3:
                {
                    // Bitboard byColorBB[COLOR_NB]; public LP<ulong> byColorBB;
                    int32_t size = sizeof(uint64_t)*COLOR_NB;
                    if(pointerIndex+size<=length){
                        memcpy(position->byColorBB, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 4:
                {
                    // int32_t pieceCount[PIECE_NB]; public LP<int32_t> pieceCount;
                    int32_t size = sizeof(int32_t)*PIECE_NB;
                    if(pointerIndex+size<=length){
                        memcpy(position->pieceCount, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 5:
                {
                    // Square pieceList[PIECE_NB][16]; public LP<int32_t> pieceList;
                    int32_t size = sizeof(int32_t)*PIECE_NB*16;
                    if(pointerIndex+size<=length){
                        memcpy(position->pieceList, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 6:
                {
                    // int32_t index[SQUARE_NB]; public LP<int32_t> index;
                    int32_t size = sizeof(int32_t)*SQUARE_NB;
                    if(pointerIndex+size<=length){
                        memcpy(position->index, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 7:
                {
                    // int32_t castlingRightsMask[SQUARE_NB]; public LP<int32_t> castlingRightsMask;*/
                    int32_t size = sizeof(int32_t)*SQUARE_NB;
                    if(pointerIndex+size<=length){
                        memcpy(position->castlingRightsMask, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 8:
                {
                    // Square castlingRookSquare[CASTLING_RIGHT_NB]; public LP<int32_t> castlingRookSquare;
                    int32_t size = sizeof(int32_t)*CASTLING_RIGHT_NB;
                    if(pointerIndex+size<=length){
                        memcpy(position->castlingRookSquare, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 9:
                {
                    // Bitboard castlingPath[CASTLING_RIGHT_NB]; public LP<ulong> castlingPath;
                    int32_t size = sizeof(uint64_t)*CASTLING_RIGHT_NB;
                    if(pointerIndex+size<=length){
                        memcpy(position->castlingPath, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 10:
                {
                    // int32_t gamePly; public VP<int32_t> gamePly;
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->gamePly, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 11:
                {
                    // Color sideToMove; public VP<int32_t> sideToMove;
                    int32_t size = sizeof(int32_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->sideToMove, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 12:
                {
                    // VariantType variantType = asean;
                    VariantType variantType = asean;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&variantType, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                    // Set Variant
                    {
                        // printf("setVariant: %d\n", variantType);
                        position->var = getVariantByType(variantType);
                    }
                }
                    break;
                case 13:
                {
                    // StateInfo* st; public LP<StateInfo> st;
                    // find stateInfoNumber
                    int32_t stateInfoNumber = 0;
                    {
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&stateInfoNumber, bytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                    // parse
                    {
                        std::vector<StateInfo*> sts;
                        // parse
                        {
                            for (int32_t i = 0; i < stateInfoNumber; i++) {
                                StateInfo* st = (StateInfo*)calloc(1, sizeof(StateInfo));;
                                {
                                    position->pushStateInfo(st);
                                }
                                int32_t stateInfoByteLength = StateInfo::parse (st, bytes, length, pointerIndex);
                                if (stateInfoByteLength > 0) {
                                    // add to chess
                                    sts.push_back(st);
                                    pointerIndex+= stateInfoByteLength;
                                } else {
                                    printf("cannot parse\n");
                                    break;
                                }
                            }
                        }
                        // Dat stateInfo vao vi tri cua position
                        {
                            // vector theo thu tu tu turn be den turn cao
                            for(int32_t i=0; i<sts.size(); i++){
                                // lay turn cuoi dat vao position
                                if(i==sts.size()-1){
                                    position->st = sts[i];
                                }
                                if(i!=0){
                                    sts[i]->previous = sts[i-1];
                                }else{
                                    sts[i]->previous = NULL;
                                }
                            }
                        }
                    }
                }
                    break;
                case 14:
                {
                    // bool chess960; public VP<bool> chess960;
                    int32_t size = sizeof(bool);
                    if(pointerIndex+size<=length){
                        memcpy(&position->chess960, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 15:
                {
                    // int32_t pieceCountInHand[COLOR_NB][PIECE_TYPE_NB];
                    int32_t size = sizeof(int32_t)*COLOR_NB*PIECE_TYPE_NB;
                    if(pointerIndex+size<=length){
                        memcpy(position->pieceCountInHand, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 16:
                {
                    int32_t size = sizeof(uint64_t);
                    if(pointerIndex+size<=length){
                        memcpy(&position->promotedPieces, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                default:
                {
                    // printf("unknown index: %d\n", index);
                    alreadyPassAll = true;
                }
                    break;
            }
            // printf("convert byte array to position: count: %d; %d; %d\n", pointerIndex, index, length);
            index++;
            if (!isParseCorrect) {
                printf("not parse correct\n");
                break;
            }
            if (alreadyPassAll) {
                break;
            }
        }
        // return
        if (!isParseCorrect) {
            printf("parse fail\n");
        } else {
            // printf("parse success");
        }
        // check position ok: if not, correct it
        if(canCorrect){
            // TODO test
            /*{
             // delete st_
             {
             // get list
             position->st = NULL;
             
             // Make new stateInfo
             {
             StateInfo* st = new StateInfo;
             {
             st->previous = NULL;
             }
             position->st = st;
             }
             }
             }*/
            
            if(!position->myPosIsOk()){
                // find fen
                char fen[200];
                position->myFen(fen);
                printf("convertPositionToByteArray: correct: fen: %s\n", fen);
                // find correct positionBytes
                uint8_t* correctPositionBytes;
                bool chess960 = position->chess960;
                int32_t correctLength = fairy_chess_makePositionByFen(getVariantTypeByVar(position->var), fen, chess960, correctPositionBytes);
                // convert again
                Position::parseByteArray(position, correctPositionBytes, correctLength, 0, false);
                free(correctPositionBytes);
            }
        }
        // return
        if (!isParseCorrect) {
            printf("error parse fail: %d; %d; %d\n", pointerIndex, length, start);
            return -1;
        } else {
            // printf("parse success: %d; %d; %d %d\n", pointerIndex, length, start, (pointerIndex - start));
            return (pointerIndex - start);
        }
    }
    
}

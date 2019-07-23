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

#include "seirawan_bitboard.hpp"
#include "seirawan_misc.hpp"
#include "seirawan_movegen.hpp"
#include "seirawan_position.hpp"
#include "seirawan_thread.hpp"
#include "seirawan_tt.hpp"
#include "seirawan_uci.hpp"
#include "syzygy/seirawan_tbprobe.hpp"
#include "seirawan_jni.hpp"

using std::string;
using namespace std;

namespace Seirawan
{
    
    namespace PSQT {
        extern Score psq[PIECE_NB][SQUARE_NB];
    }
    
    namespace Zobrist {
        
        Key psq[PIECE_NB][SQUARE_NB];
        Key inhand[PIECE_NB];
        Key enpassant[FILE_NB];
        Key gate[SQUARE_NB];
        Key castling[CASTLING_RIGHT_NB];
        Key side, noPawns;
    }
    
    namespace {
        
        const string PieceToChar(" PNBRHEQK pnbrheqk");
        
        const Piece Pieces[] = { W_PAWN, W_KNIGHT, W_BISHOP, W_ROOK, W_HAWK, W_ELEPHANT, W_QUEEN, W_KING,
            B_PAWN, B_KNIGHT, B_BISHOP, B_ROOK, B_HAWK, B_ELEPHANT, B_QUEEN, B_KING };
        
        // min_attacker() is a helper function used by see_ge() to locate the least
        // valuable attacker for the side to move, remove the attacker we just found
        // from the bitboards and scan for new X-ray attacks behind it.
        
        template<int32_t Pt>
        PieceType min_attacker(const Bitboard* bb, Square to, Bitboard stmAttackers,
                               Bitboard& occupied, Bitboard& attackers) {
            
            Bitboard b = stmAttackers & bb[Pt];
            if (!b)
                return min_attacker<Pt + 1>(bb, to, stmAttackers, occupied, attackers);
            
            occupied ^= b & ~(b - 1);
            
            if (Pt == PAWN || Pt == BISHOP || Pt == HAWK || Pt == QUEEN)
                attackers |= attacks_bb<BISHOP>(to, occupied) & (bb[BISHOP] | bb[HAWK] | bb[QUEEN]);
            
            if (Pt == ROOK || Pt == ELEPHANT || Pt == QUEEN)
                attackers |= attacks_bb<ROOK>(to, occupied) & (bb[ROOK] | bb[ELEPHANT] | bb[QUEEN]);
            
            attackers &= occupied; // After X-ray that may add already processed pieces
            return (PieceType)Pt;
        }
        
        template<>
        PieceType min_attacker<KING>(const Bitboard*, Square, Bitboard, Bitboard&, Bitboard&) {
            return KING; // No need to update bitboards: it is the last cycle
        }
        
    } // namespace
    
    
    /// operator<<(Position) returns an ASCII representation of the position
    
    /*std::ostream& operator<<(std::ostream& os, const Position& pos) {
        
        os << "\n +---+---+---+---+---+---+---+---+\n";
        
        for (Rank r = RANK_8; r >= RANK_1; --r)
        {
            for (File f = FILE_A; f <= FILE_H; ++f)
                os << " | " << PieceToChar[pos.piece_on(make_square(f, r))];
            
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
            p.set(pos.fen(), pos.is_chess960(), &st, pos.this_thread());
            Tablebases::ProbeState s1, s2;
            Tablebases::WDLScore wdl = Tablebases::probe_wdl(p, &s1);
            int32_t dtz = Tablebases::probe_dtz(p, &s2);
            os << "\nTablebases WDL: " << std::setw(4) << wdl << " (" << s1 << ")"
            << "\nTablebases DTZ: " << std::setw(4) << dtz << " (" << s2 << ")";
        }
        
        return os;
    }*/
    
    void printPos(char* ret, const Position& pos)
    {
        ret[0] = 0;
        sprintf(ret, "%s\n +---+---+---+---+---+---+---+---+\n", ret);
        for (Rank r = RANK_8; r >= RANK_1; --r) {
            for (File f = FILE_A; f <= FILE_H; ++f){
                sprintf(ret, "%s | %c", ret, PieceToChar[pos.piece_on(make_square(f, r))]);
            }
            sprintf(ret, "%s |\n +---+---+---+---+---+---+---+---+\n", ret);
        }
        // fen
        {
            char fen[300];
            {
                pos.myFen(fen);
            }
            sprintf(ret, "%sFen: %s\n", ret, fen);
        }
        sprintf(ret, "%sKey: %llu\n", ret, pos.key());
        {
            sprintf(ret, "%sCheckers: ", ret);
            for (Bitboard b = pos.checkers(); b; ) {
                char strSquare[100];
                {
                    UCI::square(strSquare, pop_lsb(&b));
                }
                sprintf(ret, "%s%s ", ret, strSquare);
            }
        }
    }
    
    
    /// Position::init() initializes at startup the various arrays used to compute
    /// hash keys.
    
    void Position::init() {
        
        PRNG rng(1070372);
        
        for (Piece pc : Pieces)
        {
            for (Square s = SQ_A1; s < SQUARE_NB; ++s)
                Zobrist::psq[pc][s] = rng.rand<Key>();
            Zobrist::inhand[pc] = rng.rand<Key>();
        }
        
        for (File f = FILE_A; f <= FILE_H; ++f)
            Zobrist::enpassant[f] = rng.rand<Key>();
        
        for (Square s = SQ_A1; s < SQUARE_NB; ++s)
            Zobrist::gate[s] = rng.rand<Key>();
        
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
    }
    
    
    /// Position::set() initializes the position object with the given FEN string.
    /// This function is not very robust - make sure that input FENs are correct,
    /// this is assumed to be the responsibility of the GUI.
    
    Position& Position::set(const string& fenStr, bool isChess960, StateInfo* si, Thread* th) {
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
        Square sq = SQ_A8;
        std::istringstream ss(fenStr);
        
        std::memset(this, 0, sizeof(Position));
        std::memset(si, 0, sizeof(StateInfo));
        std::fill_n(&pieceList[0][0], sizeof(pieceList) / sizeof(Square), SQ_NONE);
        st = si;
        
        ss >> std::noskipws;
        
        // 1. Piece placement
        while ((ss >> token) && !isspace(token))
        {
            if (isdigit(token))
                sq += (token - '0') * EAST; // Advance the given number of files
            
            else if (token == '/')
                sq += 2 * SOUTH;
            
            else if ((idx = PieceToChar.find(token)) != string::npos)
            {
                put_piece(Piece(idx), sq);
                ++sq;
            }
            else if (token == '[')
            {
                // Pieces in hand
                while ((ss >> token) && !isspace(token))
                {
                    if (token == ']')
                        continue;
                    else if ((idx = PieceToChar.find(token)) != string::npos)
                        add_to_hand(color_of(Piece(idx)), type_of(Piece(idx)));
                }
                break;
            }
        }
        
        // 2. Active color
        ss >> token;
        sideToMove = (token == 'w' ? WHITE : BLACK);
        ss >> token;
        
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
            {
                for (rsq = relative_square(c, SQ_H1); piece_on(rsq) != rook; --rsq) {}
                st->gatesBB |= rsq;
                st->gatesBB |= square<KING>(c);
                set_castling_right(c, rsq);
            }
            
            else if (token == 'Q')
            {
                for (rsq = relative_square(c, SQ_A1); piece_on(rsq) != rook; ++rsq) {}
                st->gatesBB |= rsq;
                st->gatesBB |= square<KING>(c);
                set_castling_right(c, rsq);
            }
            
            else if (token >= 'A' && token <= 'H')
            {
                rsq = make_square(File(token - 'A'), relative_rank(c, RANK_1));
                st->gatesBB |= rsq;
                
                // Maintain compatibility with Chess960 FENs where an unmoved
                // king is not mentioned if castling is available.
                if (empty_hand(c))
                    set_castling_right(c, rsq);
            }
        }
        
        // In Chess960 give castling rights if king and rook are unmoved
        for (Color c = WHITE; c <= BLACK; ++c)
            if (isChess960 && (gates(c) & pieces(KING)))
            {
                Bitboard castling_rooks = gates(c) & pieces(ROOK);
                while (castling_rooks)
                    set_castling_right(c, pop_lsb(&castling_rooks));
            }
        
        // Remove bogus gate squares. Should only happen with incorrect FENs.
        st->gatesBB &= pieces() & (Rank1BB | Rank8BB);
        
        // Remove any possible gating squares if no pieces in hand
        for (Color c = WHITE; c <= BLACK; ++c)
            if (empty_hand(c))
                st->gatesBB ^= gates(c);
        
        // 4. En passant square. Ignore if no pawn capture is possible
        if (   ((ss >> col) && (col >= 'a' && col <= 'h'))
            && ((ss >> row) && (row == '3' || row == '6')))
        {
            st->epSquare = make_square(File(col - 'a'), Rank(row - '1'));
            
            if (   !(attackers_to(st->epSquare) & pieces(sideToMove, PAWN))
                || !(pieces(~sideToMove, PAWN) & (st->epSquare + pawn_push(~sideToMove))))
                st->epSquare = SQ_NONE;
        }
        else
            st->epSquare = SQ_NONE;
        
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
        
        Square kfrom = square<KING>(c);
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
        
        si->blockersForKing[WHITE] = slider_blockers(pieces(BLACK), square<KING>(WHITE), si->pinnersForKing[WHITE]);
        si->blockersForKing[BLACK] = slider_blockers(pieces(WHITE), square<KING>(BLACK), si->pinnersForKing[BLACK]);
        
        Square ksq = square<KING>(~sideToMove);
        
        si->checkSquares[PAWN]      = attacks_from<PAWN>(ksq, ~sideToMove);
        si->checkSquares[KNIGHT]    = attacks_from<KNIGHT>(ksq);
        si->checkSquares[BISHOP]    = attacks_from<BISHOP>(ksq);
        si->checkSquares[ROOK]      = attacks_from<ROOK>(ksq);
        si->checkSquares[HAWK]      = si->checkSquares[KNIGHT] | si->checkSquares[BISHOP];
        si->checkSquares[ELEPHANT]  = si->checkSquares[KNIGHT] | si->checkSquares[ROOK];
        si->checkSquares[QUEEN]     = si->checkSquares[BISHOP] | si->checkSquares[ROOK];
        si->checkSquares[KING]      = 0;
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
        si->checkersBB = attackers_to(square<KING>(sideToMove)) & pieces(~sideToMove);
        
        set_check_info(si);
        
        for (Bitboard b = pieces(); b; )
        {
            Square s = pop_lsb(&b);
            Piece pc = piece_on(s);
            si->key ^= Zobrist::psq[pc][s];
            si->psq += PSQT::psq[pc][s];
        }
        
        for (Bitboard b = si->gatesBB; b; )
            si->key ^= Zobrist::gate[pop_lsb(&b)];
        
        for (Color c = WHITE; c <= BLACK; ++c)
            for (PieceType pt : {HAWK, ELEPHANT, QUEEN})
                if (in_hand(c, pt))
                    si->key ^= Zobrist::inhand[make_piece(c, pt)];
        
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
        
        for (Piece pc : Pieces)
        {
            if (type_of(pc) != PAWN && type_of(pc) != KING)
                si->nonPawnMaterial[color_of(pc)] += pieceCount[pc] * PieceValue[MG][pc];
            
            for (int32_t cnt = 0; cnt < pieceCount[pc]; ++cnt)
                si->materialKey ^= Zobrist::psq[pc][cnt];
        }
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
        
        return set(fenStr, false, si, nullptr);
    }
    
    
    /// Position::fen() returns a FEN representation of the position. In case of
    /// Chess960 the Shredder-FEN notation is used. This is mainly a debugging function.
    
    const string Position::fen() const {

        int32_t emptyCnt;
        std::ostringstream ss;
        
        for (Rank r = RANK_8; r >= RANK_1; --r)
        {
            for (File f = FILE_A; f <= FILE_H; ++f)
            {
                for (emptyCnt = 0; f <= FILE_H && empty(make_square(f, r)); ++f)
                    ++emptyCnt;
                
                if (emptyCnt)
                    ss << emptyCnt;
                
                if (f <= FILE_H)
                    ss << PieceToChar[piece_on(make_square(f, r))];
            }
            
            if (r > RANK_1)
                ss << '/';
        }
        
        if (!empty_hand(WHITE) || !empty_hand(BLACK))
        {
            ss << '[';
            for (Color c = WHITE; c <= BLACK; ++c)
                for (PieceType pt = HAWK; pt <= QUEEN; ++pt)
                    ss << std::string(in_hand(c, pt), PieceToChar[make_piece(c, pt)]);
            ss << ']';
        }
        
        ss << (sideToMove == WHITE ? " w " : " b ");
        
        for (Color c = WHITE; c <= BLACK; ++c)
        {
            char A = c == WHITE ? 'A' : 'a';
            char K = c == WHITE ? 'K' : 'k';
            char Q = c == WHITE ? 'Q' : 'q';
            
            if (empty_hand(c))
            {
                if (can_castle(c | KING_SIDE))
                    ss << (chess960 ? char(A + file_of(castling_rook_square(c |  KING_SIDE))) : K);
                
                if (can_castle(c | QUEEN_SIDE))
                    ss << (chess960 ? char(A + file_of(castling_rook_square(c | QUEEN_SIDE))) : Q);
            }
            else
            {
                Bitboard castlers = 0;
                
                if (!chess960)
                {
                    if (can_castle(c | KING_SIDE))
                    {
                        ss << K;
                        castlers |= square<KING>(c);
                        castlers |= castling_rook_square(c | KING_SIDE);
                    }
                    
                    if (can_castle(c | QUEEN_SIDE))
                    {
                        ss << Q;
                        castlers |= square<KING>(c);
                        castlers |= castling_rook_square(c | QUEEN_SIDE);
                    }
                }
                
                for (File f = FILE_A; f <= FILE_H; ++f)
                    if (gates(c) & ~castlers & file_bb(f))
                        ss << char(A + f);
            }
        }
        
        if (!can_castle(WHITE) && !can_castle(BLACK) && !gates(WHITE) && !gates(BLACK))
            ss << '-';
        
        ss << (ep_square() == SQ_NONE ? " - " : " " + UCI::square(ep_square()) + " ")
        << st->rule50 << " " << 1 + (gamePly - (sideToMove == BLACK)) / 2;
        
        return ss.str();
    }
    
    void Position::myFen(char* ss) const
    {
        int32_t emptyCnt;
        ss[0] = 0;
        
        for (Rank r = RANK_8; r >= RANK_1; --r)
        {
            for (File f = FILE_A; f <= FILE_H; ++f)
            {
                for (emptyCnt = 0; f <= FILE_H && empty(make_square(f, r)); ++f) {
                    ++emptyCnt;
                }
                
                if (emptyCnt) {
                    sprintf(ss, "%s%d", ss, emptyCnt);
                }
                
                if (f <= FILE_H) {
                    sprintf(ss, "%s%c", ss, PieceToChar[piece_on(make_square(f, r))]);
                }
            }
            
            if (r > RANK_1) {
                sprintf(ss, "%s/", ss);
            }
        }
        
        if (!empty_hand(WHITE) || !empty_hand(BLACK))
        {
            sprintf(ss, "%s[", ss);
            for (Color c = WHITE; c <= BLACK; ++c)
                for (PieceType pt = HAWK; pt <= QUEEN; ++pt) {
                    // ss << std::string(in_hand(c, pt), PieceToChar[make_piece(c, pt)]);
                    if(in_hand(c, pt)){
                        sprintf(ss, "%s%c",ss, PieceToChar[make_piece(c, pt)]);
                    }
                }
            sprintf(ss, "%s]", ss);
        }
        
        sprintf(ss, "%s%s", ss, (sideToMove == WHITE ? " w " : " b "));
        
        for (Color c = WHITE; c <= BLACK; ++c)
        {
            char A = c == WHITE ? 'A' : 'a';
            char K = c == WHITE ? 'K' : 'k';
            char Q = c == WHITE ? 'Q' : 'q';
            
            if (empty_hand(c))
            {
                if (can_castle(c | KING_SIDE)) {
                    sprintf(ss, "%s%c", ss, (chess960 ? char(A + file_of(castling_rook_square(c |  KING_SIDE))) : K));
                }
                
                if (can_castle(c | QUEEN_SIDE)) {
                    sprintf(ss, "%s%c", ss, (chess960 ? char(A + file_of(castling_rook_square(c | QUEEN_SIDE))) : Q));
                }
            }
            else
            {
                Bitboard castlers = 0;
                
                if (!chess960)
                {
                    if (can_castle(c | KING_SIDE))
                    {
                        sprintf(ss, "%s%c", ss, K);
                        castlers |= square<KING>(c);
                        castlers |= castling_rook_square(c | KING_SIDE);
                    }
                    
                    if (can_castle(c | QUEEN_SIDE))
                    {
                        sprintf(ss, "%s%c", ss, Q);
                        castlers |= square<KING>(c);
                        castlers |= castling_rook_square(c | QUEEN_SIDE);
                    }
                }
                
                for (File f = FILE_A; f <= FILE_H; ++f)
                    if (gates(c) & ~castlers & file_bb(f)) {
                        sprintf(ss, "%s%c", ss, char(A + f));
                    }
            }
        }
        
        if (!can_castle(WHITE) && !can_castle(BLACK) && !gates(WHITE) && !gates(BLACK)) {
            sprintf(ss, "%s-", ss);
        }
        
        //ss << (ep_square() == SQ_NONE ? " - " : " " + UCI::square(ep_square()) + " ") << st->rule50 << " " << 1 + (gamePly - (sideToMove == BLACK)) / 2;
        // sprintf(ss, "%s", ss);
        {
            if(ep_square() == SQ_NONE){
                sprintf(ss, "%s - ", ss);
            } else {
                char strSquare[20];
                {
                    UCI::square(strSquare, ep_square());
                }
                sprintf(ss, "%s %s ", ss, strSquare);
            }
        }
        sprintf(ss, "%s%d %d", ss, st->rule50, 1 + (gamePly - (sideToMove == BLACK)) / 2);
        
    }
    
    
    /// Position::slider_blockers() returns a bitboard of all the pieces (both colors)
    /// that are blocking attacks on the square 's' from 'sliders'. A piece blocks a
    /// slider if removing that piece from the board would result in a position where
    /// square 's' is attacked. For example, a king-attack blocking piece can be either
    /// a pinned or a discovered check piece, according if its color is the opposite
    /// or the same of the color of the slider.
    
    Bitboard Position::slider_blockers(Bitboard sliders, Square s, Bitboard& pinners) const {
        
        Bitboard result = 0;
        pinners = 0;
        
        // Snipers are sliders that attack 's' when a piece is removed
        Bitboard snipers = (  (PseudoAttacks[  ROOK][s] & pieces(QUEEN, ROOK, ELEPHANT))
                            | (PseudoAttacks[BISHOP][s] & pieces(QUEEN, BISHOP, HAWK))) & sliders;
        
        while (snipers)
        {
            Square sniperSq = pop_lsb(&snipers);
            Bitboard b = between_bb(s, sniperSq) & pieces();
            
            if (!more_than_one(b))
            {
                result |= b;
                if (b & pieces(color_of(piece_on(s))))
                    pinners |= sniperSq;
            }
        }
        return result;
    }
    
    
    /// Position::attackers_to() computes a bitboard of all pieces which attack a
    /// given square. Slider attacks use the occupied bitboard to indicate occupancy.
    
    Bitboard Position::attackers_to(Square s, Bitboard occupied) const {
        
        return  (attacks_from<PAWN>(s, BLACK)    & pieces(WHITE, PAWN))
        | (attacks_from<PAWN>(s, WHITE)    & pieces(BLACK, PAWN))
        | (attacks_from<KNIGHT>(s)         & pieces(KNIGHT, HAWK, ELEPHANT))
        | (attacks_bb<  ROOK>(s, occupied) & pieces(ROOK, ELEPHANT, QUEEN))
        | (attacks_bb<BISHOP>(s, occupied) & pieces(BISHOP, HAWK, QUEEN))
        | (attacks_from<KING>(s)           & pieces(KING));
    }
    
    
    /// Position::legal() tests whether a pseudo-legal move is legal
    
    bool Position::legal(Move m) const {
        
        // assert(is_ok(m));
        if(!is_ok(m)){
            printf("error, assert(is_ok(m))\n");
        }
        
        Color us = sideToMove;
        Square from = from_sq(m);
        
        // assert(color_of(moved_piece(m)) == us);
        if(color_of(moved_piece(m)) != us){
            printf("error, assert(color_of(moved_piece(m)) == us)\n");
        }
        // assert(piece_on(square<KING>(us)) == make_piece(us, KING));
        if(piece_on(square<KING>(us)) != make_piece(us, KING)){
            printf("error, assert(piece_on(square<KING>(us)) == make_piece(us, KING))\n");
        }
        
        // En passant captures are a tricky special case. Because they are rather
        // uncommon, we do it simply by testing whether the king is attacked after
        // the move is made.
        if (type_of(m) == ENPASSANT)
        {
            Square ksq = square<KING>(us);
            Square to = to_sq(m);
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
            
            return   !(attacks_bb<  ROOK>(ksq, occupied) & pieces(~us, QUEEN, ROOK, ELEPHANT))
            && !(attacks_bb<BISHOP>(ksq, occupied) & pieces(~us, QUEEN, BISHOP, HAWK));
        }
        
        // If the moving piece is a king, check whether the destination
        // square is attacked by the opponent. Castling moves are checked
        // for legality during move generation.
        if (type_of(piece_on(from)) == KING)
            return type_of(m) == CASTLING || !(attackers_to(to_sq(m)) & pieces(~us));
        
        // A non-king move is legal if and only if it is not pinned or it
        // is moving along the ray towards or away from the king.
        return   !(pinned_pieces(us) & from)
        ||  aligned(from, to_sq(m), square<KING>(us));
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
            return MoveList<LEGAL>(*this).contains(m);
        
        // If the move gates a piece make sure we have that piece in hand
        // and that we are allowed to gate on the from square.
        if (gating_type(m) != NO_GATE_TYPE && !(in_hand(us, gating_type(m)) && (gates(us) & from)))
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
            if (rank_of(to) == relative_rank(us, RANK_8))
                return false;
            
            if (   !(attacks_from<PAWN>(from, us) & pieces(~us) & to) // Not a capture
                && !((from + pawn_push(us) == to) && empty(to))       // Not a single push
                && !(   (from + 2 * pawn_push(us) == to)              // Not a double push
                     && (rank_of(from) == relative_rank(us, RANK_2))
                     && empty(to)
                     && empty(to - pawn_push(us))))
                return false;
        }
        else if (!(attacks_from(type_of(pc), from) & to))
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
                if (!((between_bb(lsb(checkers()), square<KING>(us)) | checkers()) & to))
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
        
        // Is there a direct check?
        if (st->checkSquares[type_of(piece_on(from))] & to)
            return true;
        
        // Is there a discovered check?
        if (   (discovered_check_candidates() & from)
            && !aligned(from, to, square<KING>(~sideToMove)))
            return true;
        
        // Is there a check by gated pieces?
        if (    is_gating(m)
            && (st->checkSquares[gating_type(m)] & (gating_on_to_sq(m) ? to_sq(m) : from_sq(m)))
            && !aligned(from, to, square<KING>(~sideToMove)))
            return true;
        
        switch (type_of(m))
        {
            case NORMAL:
                return false;
                
            case PROMOTION:
                return attacks_bb(promotion_type(m), to, pieces() ^ from) & square<KING>(~sideToMove);
                
                // En passant capture with check? We have already handled the case
                // of direct checks and ordinary discovered check, so the only case we
                // need to handle is the unusual case of a discovered check through
                // the captured pawn.
            case ENPASSANT:
            {
                Square capsq = make_square(file_of(to), rank_of(from));
                Bitboard b = (pieces() ^ from ^ capsq) | to;
                
                return  (attacks_bb<  ROOK>(square<KING>(~sideToMove), b) & pieces(sideToMove, QUEEN, ROOK, ELEPHANT))
                | (attacks_bb<BISHOP>(square<KING>(~sideToMove), b) & pieces(sideToMove, QUEEN, BISHOP, HAWK));
            }
            case CASTLING:
            {
                Square kfrom = from;
                Square rfrom = to; // Castling is encoded as 'King captures the rook'
                Square kto = relative_square(sideToMove, rfrom > kfrom ? SQ_G1 : SQ_C1);
                Square rto = relative_square(sideToMove, rfrom > kfrom ? SQ_F1 : SQ_D1);
                
                return   (PseudoAttacks[ROOK][rto] & square<KING>(~sideToMove))
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
        if(!(&newSt != st)){
            printf("error, assert(&newSt != st)\n");
        }
        
        if(thisThread){
            thisThread->nodes.fetch_add(1, std::memory_order_relaxed);
        } else {
            // printf("error, thread null1\n");
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
        Piece pc = piece_on(from);
        Piece captured = type_of(m) == ENPASSANT ? make_piece(them, PAWN) : piece_on(to);
        
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
        
        // Remove gates. When castling, 'to' will soon be modified, so do this now.
        Bitboard lostGates = st->gatesBB & (SquareBB[from] | SquareBB[to]);
        
        if (type_of(m) == CASTLING)
        {
            // assert(pc == make_piece(us, KING));
            if(pc != make_piece(us, KING)){
                printf("error, assert(pc == make_piece(us, KING))\n");
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
                st->nonPawnMaterial[them] -= PieceValue[MG][captured];
            
            // Update board and piece lists
            remove_piece(captured, capsq);
            
            // Update material hash key and prefetch access to materialTable
            k ^= Zobrist::psq[captured][capsq];
            st->materialKey ^= Zobrist::psq[captured][pieceCount[captured]];
            if(thisThread!=NULL) {
                prefetch(thisThread->materialTable[st->materialKey]);
            } else {
                // printf("error, thisThread null\n");
            }
            
            // Update incremental scores
            st->psq -= PSQT::psq[captured][capsq];
            
            // Reset rule 50 counter
            st->rule50 = 0;
        }
        
        // Update hash key
        k ^= Zobrist::psq[pc][from] ^ Zobrist::psq[pc][to];
        
        // Reset en passant square
        if (st->epSquare != SQ_NONE)
        {
            k ^= Zobrist::enpassant[file_of(st->epSquare)];
            st->epSquare = SQ_NONE;
        }
        
        // Update castling rights if needed
        if (st->castlingRights && (castlingRightsMask[from] | castlingRightsMask[to]))
        {
            int32_t cr = castlingRightsMask[from] | castlingRightsMask[to];
            k ^= Zobrist::castling[st->castlingRights & cr];
            st->castlingRights &= ~cr;
        }
        
        // Move the piece. The tricky Chess960 castling is handled earlier
        if (type_of(m) != CASTLING)
            move_piece(pc, from, to);
        
        // If the moving piece is a pawn do some special extra work
        if (type_of(pc) == PAWN)
        {
            // Set en-passant square if the moved pawn can be captured
            if (   (int(to) ^ int(from)) == 16
                && (attacks_from<PAWN>(to - pawn_push(us), us) & pieces(them, PAWN)))
            {
                st->epSquare = to - pawn_push(us);
                k ^= Zobrist::enpassant[file_of(st->epSquare)];
            }
            
            else if (type_of(m) == PROMOTION)
            {
                Piece promotion = make_piece(us, promotion_type(m));
                
                // assert(relative_rank(us, to) == RANK_8);
                if(relative_rank(us, to) != RANK_8){
                    printf("error, assert(relative_rank(us, to) == RANK_8)\n");
                }
                // assert(type_of(promotion) >= KNIGHT && type_of(promotion) <= QUEEN);
                if(!(type_of(promotion) >= KNIGHT && type_of(promotion) <= QUEEN)){
                    printf("error, assert(type_of(promotion) >= KNIGHT && type_of(promotion) <= QUEEN)\n");
                }
                
                remove_piece(pc, to);
                put_piece(promotion, to);
                
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
            st->pawnKey ^= Zobrist::psq[pc][from] ^ Zobrist::psq[pc][to];
            if(thisThread){
                prefetch2(thisThread->pawnsTable[st->pawnKey]);
            } else {
                // printf("error, thisThread null\n");
            }
            
            // Reset rule 50 draw counter
            st->rule50 = 0;
        }
        
        else if (gating_type(m) != NO_GATE_TYPE) // Safe because m is not a pawn move
        {
            // assert(gating_type(m) >= HAWK && gating_type(m) <= QUEEN);
            if(!(gating_type(m) >= HAWK && gating_type(m) <= QUEEN)){
                printf("error, assert(gating_type(m) >= HAWK && gating_type(m) <= QUEEN)\n");
            }
            
            Square gating_square = gating_on_to_sq(m) ? to_sq(m) : from_sq(m);
            Piece gating_piece = make_piece(sideToMove, gating_type(m));
            put_piece(gating_piece, gating_square);
            remove_from_hand(sideToMove, gating_type(m));
            st->psq += PSQT::psq[gating_piece][gating_square];
            k ^= Zobrist::psq[gating_piece][gating_square] ^ Zobrist::inhand[gating_piece];
            st->materialKey ^= Zobrist::psq[gating_piece][pieceCount[gating_piece]-1];
            st->nonPawnMaterial[us] += PieceValue[MG][gating_piece];
            if (empty_hand(us))
                lostGates |= gates(us);
        }
        
        // Update gates
        if (lostGates)
        {
            st->gatesBB ^= lostGates;
            while (lostGates)
                k ^= Zobrist::gate[pop_lsb(&lostGates)];
        }
        
        // Update incremental scores
        st->psq += PSQT::psq[pc][to] - PSQT::psq[pc][from];
        
        // Set capture piece
        st->capturedPiece = captured;
        
        // Update the key with the final value
        st->key = k;
        
        // Calculate checkers bitboard (if move gives check)
        st->checkersBB = givesCheck ? attackers_to(square<KING>(them)) & pieces(us) : 0;
        
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
        
        // assert(empty(from) || type_of(m) == CASTLING || is_gating(m));
        if(!(empty(from) || type_of(m) == CASTLING || is_gating(m))){
            printf("error, assert(empty(from) || type_of(m) == CASTLING || is_gating(m))\n");
        }
        // assert(type_of(st->capturedPiece) != KING);
        if(type_of(st->capturedPiece) == KING){
            printf("error, assert(type_of(st->capturedPiece) != KING)\n");
        }
        
        // Remove gated piece
        if (is_gating(m))
        {
            Square gating_square = gating_on_to_sq(m) ? to_sq(m) : from_sq(m);
            Piece gating_piece = make_piece(sideToMove, gating_type(m));
            remove_piece(gating_piece, gating_square);
            add_to_hand(sideToMove, gating_type(m));
        }
        
        if (type_of(m) == PROMOTION)
        {
            // assert(relative_rank(us, to) == RANK_8);
            if(relative_rank(us, to) != RANK_8){
                printf("error, assert(relative_rank(us, to) == RANK_8)\n");
            }
            // assert(type_of(pc) == promotion_type(m));
            if(type_of(pc) != promotion_type(m)){
                printf("error, assert(type_of(pc) == promotion_type(m))\n");
            }
            // assert(type_of(pc) >= KNIGHT && type_of(pc) <= QUEEN);
            if(!(type_of(pc) >= KNIGHT && type_of(pc) <= QUEEN)){
                printf("error, assert(type_of(pc) >= KNIGHT && type_of(pc) <= QUEEN)\n");
            }
            
            remove_piece(pc, to);
            pc = make_piece(us, PAWN);
            put_piece(pc, to);
        }
        
        if (type_of(m) == CASTLING)
        {
            Square rfrom, rto;
            do_castling<false>(us, from, to, rfrom, rto);
        }
        else
        {
            move_piece(pc, to, from); // Put the piece back at the source square
            
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
            }
        }
        
        // Finally point our state pointer back to the previous state
        st = st->previous;
        --gamePly;
        
        // assert(pos_is_ok());
        if(!pos_is_ok()){
            printf("error, assert(pos_is_ok())\n");
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
        remove_piece(make_piece(us, KING), Do ? from : to);
        remove_piece(make_piece(us, ROOK), Do ? rfrom : rto);
        board[Do ? from : to] = board[Do ? rfrom : rto] = NO_PIECE; // Since remove_piece doesn't do it for us
        put_piece(make_piece(us, KING), Do ? to : from);
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
        if(thisThread!=NULL) {
            prefetch(thisThread->TT.first_entry(st->key));
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
        Piece pc = piece_on(from);
        Piece captured = piece_on(to);
        Key k = st->key ^ Zobrist::side;
        
        if (captured)
            k ^= Zobrist::psq[captured][to];
        
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
        
        Square from = from_sq(m), to = to_sq(m);
        PieceType nextVictim = type_of(piece_on(from));
        Color stm = ~color_of(piece_on(from)); // First consider opponent's move
        Value balance; // Values of the pieces taken by us minus opponent's ones
        Bitboard occupied, stmAttackers, tmpPiecesBB[PIECE_TYPE_NB];
        const Bitboard *piecesBB = byTypeBB;
        
        // The opponent may be able to recapture so this is the best result
        // we can hope for.
        balance = PieceValue[MG][piece_on(to)] - threshold;
        
        if (balance < VALUE_ZERO)
            return false;
        
        // Now assume the worst possible result: that the opponent can
        // capture our piece for free.
        balance -= PieceValue[MG][nextVictim];
        
        if (balance >= VALUE_ZERO) // Always true if nextVictim == KING
            return true;
        
        bool opponentToMove = true;
        occupied = pieces() ^ from ^ to;
        
        // Re-occpuy the from square if we are gating a piece
        if (gating_type(m) != NO_GATE_TYPE)
            occupied ^= from;
        
        // Find all attackers to the destination square including X-ray attacks
        // if the move was not a gating move.
        Bitboard attackers = attackers_to(to, occupied) & occupied;
        
        if (gating_type(m) != NO_GATE_TYPE)
        {
            // At this point 'attackers' always contains the 'from' square
            // because the 'from' square is set in 'occupied' and the call
            // to attackers_to believed the moving piece was still present.
            // If the gated piece does not attack the 'to' square then make
            // a correction.
            if (!(PseudoAttacks[gating_type(m)][from] & to))
                attackers ^= from;
            
            // Copy the piece bitboards array and put the gated piece in
            // place of the original.
            std::memcpy(tmpPiecesBB, byTypeBB, sizeof(byTypeBB));
            tmpPiecesBB[gating_type(m)] ^= from;
            tmpPiecesBB[nextVictim] ^= from;
            piecesBB = tmpPiecesBB;
        }
        
        while (true)
        {
            // The balance is negative only because we assumed we could win
            // the last piece for free. We are truly winning only if we can
            // win the last piece _cheaply enough_. Test if we can actually
            // do this otherwise "give up".
            // assert(balance < VALUE_ZERO);
            if(!(balance < VALUE_ZERO)){
                printf("error, assert(balance < VALUE_ZERO)\n");
            }
            
            stmAttackers = attackers & pieces(stm);
            
            // Don't allow pinned pieces to attack pieces except the king as long all
            // pinners are on their original square.
            if (!(st->pinnersForKing[stm] & ~occupied))
                stmAttackers &= ~st->blockersForKing[stm];
            
            // If we have no more attackers we must give up
            if (!stmAttackers)
                break;
            
            // Locate and remove the next least valuable attacker
            nextVictim = min_attacker<PAWN>(piecesBB, to, stmAttackers, occupied, attackers);
            
            if (nextVictim == KING)
            {
                // Our only attacker is the king. If the opponent still has
                // attackers we must give up. Otherwise we make the move and
                // (having no more attackers) the opponent must give up.
                if (!(attackers & pieces(~stm)))
                    opponentToMove = !opponentToMove;
                break;
            }
            
            // Assume the opponent can win the next piece for free and switch sides
            balance += PieceValue[MG][nextVictim];
            opponentToMove = !opponentToMove;
            
            // If balance is negative after receiving a free piece then give up
            if (balance < VALUE_ZERO)
                break;
            
            // Complete the process of switching sides. The first line swaps
            // all negative numbers with non-negative numbers. The compiler
            // probably knows that it is just the bitwise negation ~balance.
            balance = -balance-1;
            stm = ~stm;
        }
        
        // If the opponent gave up we win, otherwise we lose.
        return opponentToMove;
    }
    
    
    /// Position::is_draw() tests whether the position is drawn by 50-move rule
    /// or by repetition. It does not detect stalemates.
    
    bool Position::is_draw(int32_t ply) const {
        if(st==NULL){
            printf("error, why st null\n");
            return false;
        }
        if (st->rule50 > 99 && (!checkers() || MoveList<LEGAL>(*this).size()))
            return true;

        int32_t end = min(st->rule50, st->pliesFromNull);
        
        if (end < 4)
            return false;
        
        StateInfo* stp = st->previous->previous;
        if(stp==NULL){
            printf("error, why stp NULL\n");
            return false;
        }
        int32_t cnt = 0;
        
        for (int32_t i = 4; i <= end; i += 2)
        {
            stp = stp->previous->previous;
            if(stp==NULL){
                printf("error, why stp NULL\n");
                return false;
            }
            
            // Return a draw score if a position repeats once earlier but strictly
            // after the root, or repeats twice before or at the root.
            if (   stp->key == st->key
                && ++cnt + (ply > i) == 2)
                return true;
        }
        
        return false;
    }
    
    bool Position::myIsDraw()
    {
        if(!is_draw(0)){
            // Check material sufficient to draw
            bool isMaterialSufficient = true;
            {
                // King vs King
                if(isMaterialSufficient){
                    // check only have king
                    bool onlyHaveKing = true;
                    // search
                    for (Piece pc : Pieces) {
                        if(pc!=W_KING && pc!=B_KING && pieceCount[pc]!=0){
                            onlyHaveKing = false;
                            break;
                        }
                    }
                    // process
                    if(onlyHaveKing){
                        isMaterialSufficient = false;
                    }
                }
                // King + m * Bishops m > 0 bishops (if more) stand on the same color vs King
                // hoac
                // King + m * Bishops ; m > 0 ; bishops (if more) stand on the same color
                // King + n * Bishops ; n > 0 ; bishop (or bishops if more) stand on the same color as bishop or bishops on the other side
                if(isMaterialSufficient){
                    // check have other piece
                    bool haveOtherPiece = false;
                    // check white and black have same color
                    int32_t wWhitePosBishop = 0;
                    int32_t wBlackPosBishop = 0;
                    int32_t bWhitePosBishop = 0;
                    int32_t bBlackPosBishop = 0;
                    {
                        for(int32_t i=0; i<SQUARE_NB; i++){
                            // check is white pos
                            bool isWhitePos = (((i/8)%2)==((i%8)%2));
                            switch (board[i]) {
                                case W_BISHOP:
                                {
                                    if(isWhitePos){
                                        wWhitePosBishop++;
                                    }else{
                                        wBlackPosBishop++;
                                    }
                                }
                                    break;
                                case B_BISHOP:
                                {
                                    if(isWhitePos){
                                        bWhitePosBishop++;
                                    }else{
                                        bBlackPosBishop++;
                                    }
                                }
                                    break;
                                case W_KING:
                                case B_KING:
                                case NO_PIECE:
                                    break;
                                default:
                                    haveOtherPiece = true;
                                    break;
                            }
                        }
                    }
                    // process
                    if(!haveOtherPiece){
                        if(wWhitePosBishop>0 && wBlackPosBishop==0 && bBlackPosBishop==0){
                            isMaterialSufficient = false;
                        }else if(wBlackPosBishop>0 && wWhitePosBishop==0 && bWhitePosBishop==0){
                            isMaterialSufficient = false;
                        }else if(bWhitePosBishop>0 && bBlackPosBishop==0 && wBlackPosBishop==0){
                            isMaterialSufficient = false;
                        }else if(bBlackPosBishop>0 && bWhitePosBishop==0 && wWhitePosBishop==0){
                            isMaterialSufficient = false;
                        }
                    }
                }
                // King + Knight vs King
                if(isMaterialSufficient){
                    // check
                    bool haveOtherPiece = false;
                    int32_t whiteKnight = 0;
                    int32_t blackKnight = 0;
                    {
                        for (Piece pc : Pieces) {
                            switch (pc) {
                                case W_KNIGHT:
                                {
                                    whiteKnight = pieceCount[pc];
                                }
                                    break;
                                case B_KNIGHT:
                                {
                                    blackKnight = pieceCount[pc];
                                }
                                    break;
                                case W_KING:
                                case B_KING:
                                case NO_PIECE:
                                {
                                    
                                }
                                    break;
                                default:
                                    if(pieceCount[pc]!=0){
                                        haveOtherPiece = true;
                                    }
                                    break;
                            }
                        }
                    }
                    // process
                    if(!haveOtherPiece){
                        if((whiteKnight==1 && blackKnight==0) || (whiteKnight==0 && blackKnight==1)){
                            isMaterialSufficient = false;
                        }
                    }
                }
            }
            // Check material sufficient
            if(isMaterialSufficient){
                return false;
            }else{
                return true;
            }
        }else{
            return true;
        }
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
        
        set(f, is_chess960(), st, this_thread());
        
        // assert(pos_is_ok());
        if(!pos_is_ok()){
            printf("error, assert(pos_is_ok())\n");
        }
    }
    
    
    /// Position::pos_is_ok() performs some consistency checks for the
    /// position object and raises an asserts if something wrong is detected.
    /// This is meant to be helpful when debugging.
    
    bool Position::pos_is_ok() const {
        
        const bool Fast = true; // Quick (default) or full check?
        
        if (   (sideToMove != WHITE && sideToMove != BLACK)
            || piece_on(square<KING>(WHITE)) != W_KING
            || piece_on(square<KING>(BLACK)) != B_KING
            || (   ep_square() != SQ_NONE
                && relative_rank(sideToMove, ep_square()) != RANK_6)) {
                // assert(0 && "pos_is_ok: Default");
                printf("pos_is_ok: Default\n");
                return false;
            }
        
        if (Fast)
            return true;
        
        if (   pieceCount[W_KING] != 1
            || pieceCount[B_KING] != 1
            || attackers_to(square<KING>(~sideToMove)) & pieces(sideToMove)) {
            // assert(0 && "pos_is_ok: Kings");
            printf("pos_is_ok: Kings\n");
            return false;
        }
        
        if (   (pieces(PAWN) & (Rank1BB | Rank8BB))
            || pieceCount[W_PAWN] > 8
            || pieceCount[B_PAWN] > 8) {
            // assert(0 && "pos_is_ok: Pawns");
            printf("pos_is_ok: Pawns\n");
            return false;
        }
        
        if (   (pieces(WHITE) & pieces(BLACK))
            || (pieces(WHITE) | pieces(BLACK)) != pieces()
            || popcount(pieces(WHITE)) > 18
            || popcount(pieces(BLACK)) > 18) {
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
        
        for (Piece pc : Pieces)
        {
            if (   pieceCount[pc] != popcount(pieces(color_of(pc), type_of(pc)))
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
                    printf("pos_is_ok: Castling");
                    return false;
                }
            }
        
        return true;
    }
    
    bool Position::myPosIsOk()
    {
        const bool Fast = false; // Quick (default) or full check?
        
        if(this->st==NULL){
            return false;
        }
        
        if (   (sideToMove != WHITE && sideToMove != BLACK)
            || piece_on(square<KING>(WHITE)) != W_KING
            || piece_on(square<KING>(BLACK)) != B_KING
            || (   ep_square() != SQ_NONE
                && relative_rank(sideToMove, ep_square()) != RANK_6)) {
                // assert(0 && "pos_is_ok: Default");
                printf("pos_is_ok: Default\n");
                return false;
        }
        
        if (Fast)
            return true;
        
        if (   pieceCount[W_KING] != 1
            || pieceCount[B_KING] != 1
            || attackers_to(square<KING>(~sideToMove)) & pieces(sideToMove)) {
                // assert(0 && "pos_is_ok: Kings");
            printf("pos_is_ok: Kings\n");
            return false;
        }
        
        if (   (pieces(PAWN) & (Rank1BB | Rank8BB))
            || pieceCount[W_PAWN] > 8
            || pieceCount[B_PAWN] > 8) {
            // assert(0 && "pos_is_ok: Pawns");
            printf("pos_is_ok: Pawns\n");
            return false;
        }
        
        if (   (pieces(WHITE) & pieces(BLACK))
            || (pieces(WHITE) | pieces(BLACK)) != pieces()
            || popcount(pieces(WHITE)) > 18
            || popcount(pieces(BLACK)) > 18) {
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
        
        for (Piece pc : Pieces)
        {
            if (   pieceCount[pc] != popcount(pieces(color_of(pc), type_of(pc)))
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
            // Key    pawnKey
            stateInfoSize+=sizeof(uint64_t);
            // Key    materialKey;
            stateInfoSize+=sizeof(uint64_t);
            //  Value  nonPawnMaterial[COLOR_NB];
            stateInfoSize+=sizeof(int32_t)*(int32_t)COLOR_NB;
            // int32_t    castlingRights;
            stateInfoSize+=sizeof(int32_t);
            // int32_t    rule50;
            stateInfoSize+=sizeof(int32_t);
            // int32_t    pliesFromNull;
            stateInfoSize+=sizeof(int32_t);
            // Score  psq;
            stateInfoSize+=sizeof(int32_t);
            // Square epSquare;
            stateInfoSize+=sizeof(int32_t);
            // Bitboard gatesBB;
            stateInfoSize+=sizeof(uint64_t);
            // Key        key; public VP<uint64_t> key;
            stateInfoSize+=sizeof(uint64_t);
            // Bitboard   checkersBB; public VP<uint64_t> checkersBB;
            stateInfoSize+=sizeof(uint64_t);
            // Piece      capturedPiece; public VP<int> capturedPiece;
            stateInfoSize+=sizeof(int32_t);
            // Bitboard   blockersForKing[COLOR_NB]; public LP<uint64_t> blockersForKing;
            stateInfoSize+=sizeof(uint64_t)*(int32_t)COLOR_NB;
            //  Bitboard   pinnersForKing[COLOR_NB]; public LP<uint64_t> pinnersForKing;
            stateInfoSize+=sizeof(uint64_t)*(int32_t)COLOR_NB;
            // Bitboard   checkSquares[PIECE_TYPE_NB];*/
            stateInfoSize+=sizeof(uint64_t)*(int32_t)PIECE_TYPE_NB;
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
            otherPropertySize+=sizeof(int32_t)*(int32_t)SQUARE_NB;
            // Bitboard byTypeBB[PIECE_TYPE_NB];
            otherPropertySize+=sizeof(uint64_t)*(int32_t)PIECE_TYPE_NB;
            // Bitboard byColorBB[COLOR_NB];
            otherPropertySize+=sizeof(uint64_t)*(int32_t)COLOR_NB;
            // bool inHand[PIECE_NB];
            otherPropertySize+=sizeof(bool)*(int32_t)PIECE_NB;
            // Score handScore[COLOR_NB];
            otherPropertySize+=sizeof(int32_t)*(int32_t)COLOR_NB;
            // int32_t pieceCount[PIECE_NB]; public LP<int32_t> pieceCount;
            otherPropertySize+=sizeof(int32_t)*(int32_t)PIECE_NB;
            // Square pieceList[PIECE_NB][16]; public LP<int> pieceList;
            otherPropertySize+=sizeof(int32_t)*(int32_t)PIECE_NB*16;
            // int32_t index[SQUARE_NB]; public LP<int32_t> index;
            otherPropertySize+=sizeof(int32_t)*(int32_t)SQUARE_NB;
            // int32_t castlingRightsMask[SQUARE_NB];
            otherPropertySize+=sizeof(int32_t)*(int32_t)SQUARE_NB;
            // Square castlingRookSquare[CASTLING_RIGHT_NB];
            otherPropertySize+=sizeof(int32_t)*(int32_t)CASTLING_RIGHT_NB;
            // Bitboard castlingPath[CASTLING_RIGHT_NB];
            otherPropertySize+=sizeof(uint64_t)*(int32_t)CASTLING_RIGHT_NB;
            // int32_t gamePly; public VP<int32_t> gamePly;
            otherPropertySize+=sizeof(int32_t);
            // Color sideToMove; public VP<int> sideToMove;
            otherPropertySize+=sizeof(int32_t);
            // bool chess960; public VP<bool> chess960; int
            otherPropertySize+=sizeof(bool);
            
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
                int32_t size = (int32_t)SQUARE_NB*sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->board, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // Bitboard byTypeBB[PIECE_TYPE_NB]; public LP<ulong> byTypeBB;
            {
                int32_t size = (int32_t)PIECE_TYPE_NB*sizeof(uint64_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->byTypeBB, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // Bitboard byColorBB[COLOR_NB]; public LP<ulong> byColorBB;
            {
                int32_t size = (int32_t)COLOR_NB*sizeof(uint64_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->byColorBB, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // bool inHand[PIECE_NB];
            {
                int32_t size = (int32_t)PIECE_NB*sizeof(bool);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->inHand, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // Score handScore[COLOR_NB];
            {
                int32_t size = (int32_t)COLOR_NB*sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->handScore, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // int32_t pieceCount[PIECE_NB]; public LP<int32_t> pieceCount;
            {
                int32_t size = (int32_t)PIECE_NB*sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->pieceCount, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // Square pieceList[PIECE_NB][16]; public LP<int> pieceList;
            {
                int32_t size = (int32_t)PIECE_NB*16*sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->pieceList, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // int32_t index[SQUARE_NB]; public LP<int32_t> index;
            {
                int32_t size = (int32_t)SQUARE_NB*sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->index, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // int32_t castlingRightsMask[SQUARE_NB];
            {
                int32_t size = (int32_t)SQUARE_NB*sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->castlingRightsMask, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // Square castlingRookSquare[CASTLING_RIGHT_NB];
            {
                int32_t size = (int32_t)CASTLING_RIGHT_NB*sizeof(int32_t);
                if(pointerIndex+size<=length){
                    memcpy(ret + pointerIndex, position->castlingRookSquare, size);
                    pointerIndex+=size;
                }else{
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // Bitboard castlingPath[CASTLING_RIGHT_NB];
            {
                int32_t size = (int32_t)CASTLING_RIGHT_NB*sizeof(uint64_t);
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
                                int32_t size = (int32_t)COLOR_NB*sizeof(int32_t);
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, st->nonPawnMaterial, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                            // int32_t castlingRights;
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
                            // Square epSquare;
                            {
                                int32_t size = sizeof(int32_t);
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, &st->epSquare, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                            // Bitboard gatesBB;
                            {
                                int32_t size = sizeof(uint64_t);
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, &st->gatesBB, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                            // public VP<uint64_t> key;
                            {
                                int32_t size = sizeof(uint64_t);
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, &st->key, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                            // public VP<uint64_t> checkersBB;
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
                            // public LP<uint64_t> blockersForKing;// [COLOR_NB]
                            {
                                int32_t size = sizeof(uint64_t)*(int32_t)COLOR_NB;
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, st->blockersForKing, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                            // public LP<uint64_t> pinnersForKing; // [COLOR_NB]
                            {
                                int32_t size = sizeof(uint64_t)*(int32_t)COLOR_NB;
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, st->pinnersForKing, size);
                                    pointerIndex+=size;
                                }else{
                                    printf("length error: %d, %d\n", pointerIndex, length);
                                }
                            }
                            // public LP<uint64_t> checkSquares;// [PIECE_TYPE_NB]
                            {
                                int32_t size = sizeof(uint64_t)*(int32_t)PIECE_TYPE_NB;
                                if(pointerIndex+size<=length){
                                    memcpy(ret + pointerIndex, st->checkSquares, size);
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
                    printf("length error: %d, %d\n", pointerIndex, length);
                }
            }
            // printf("convert position to array: return value: %d; %d\n", pointerIndex, length);
        }
        byteArray = ret;
        printf("convert to byte array: length: %d\n", length);
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
                    int32_t size = sizeof(int32_t)*(int32_t)SQUARE_NB;
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
                    // Bitboard byTypeBB[PIECE_TYPE_NB]; public LP<uint64_t> byTypeBB;
                    int32_t size = sizeof(uint64_t)*(int32_t)PIECE_TYPE_NB;
                    if(pointerIndex+size<=length){
                        memcpy(position->byTypeBB, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 2:
                {
                    // Bitboard byColorBB[COLOR_NB]; public LP<uint64_t> byColorBB;
                    int32_t size = sizeof(uint64_t)*(int32_t)COLOR_NB;
                    if(pointerIndex+size<=length){
                        memcpy(position->byColorBB, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 3:
                {
                    // bool inHand[PIECE_NB];
                    int32_t size = sizeof(bool)*(int32_t)PIECE_NB;
                    if(pointerIndex+size<=length){
                        memcpy(position->inHand, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 4:
                {
                    // Score handScore[COLOR_NB];
                    int32_t size = sizeof(int32_t)*(int32_t)COLOR_NB;
                    if(pointerIndex+size<=length){
                        memcpy(position->handScore, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 5:
                {
                    // int32_t pieceCount[PIECE_NB]; public LP<int32_t> pieceCount;
                    int32_t size = sizeof(int32_t)*(int32_t)PIECE_NB;
                    if(pointerIndex+size<=length){
                        memcpy(position->pieceCount, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 6:
                {
                    // Square pieceList[PIECE_NB][16]; public LP<int32_t> pieceList;
                    int32_t size = sizeof(int32_t)*(int32_t)PIECE_NB*16;
                    if(pointerIndex+size<=length){
                        memcpy(position->pieceList, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 7:
                {
                    // int32_t index[SQUARE_NB]; public LP<int32_t> index;
                    int32_t size = sizeof(int32_t)*(int32_t)SQUARE_NB;
                    if(pointerIndex+size<=length){
                        memcpy(position->index, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 8:
                {
                    // int32_t castlingRightsMask[SQUARE_NB];
                    int32_t size = sizeof(int32_t)*(int32_t)SQUARE_NB;
                    if(pointerIndex+size<=length){
                        memcpy(position->castlingRightsMask, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 9:
                {
                    // Square castlingRookSquare[CASTLING_RIGHT_NB];
                    int32_t size = sizeof(int32_t)*(int32_t)CASTLING_RIGHT_NB;
                    if(pointerIndex+size<=length){
                        memcpy(position->castlingRookSquare, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 10:
                {
                    // Bitboard castlingPath[CASTLING_RIGHT_NB];
                    int32_t size = sizeof(uint64_t)*(int32_t)CASTLING_RIGHT_NB;
                    if(pointerIndex+size<=length){
                        memcpy(position->castlingPath, bytes + pointerIndex, size);
                        pointerIndex+=size;
                    }else{
                        printf("length error: %d, %d\n", pointerIndex, length);
                        isParseCorrect = false;
                    }
                }
                    break;
                case 11:
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
                case 12:
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
                                StateInfo* st = (StateInfo*)calloc(1, sizeof(StateInfo));
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
                printf("error, not parse correct\n");
                break;
            }
            if (alreadyPassAll) {
                break;
            }
        }
        // return
        if (!isParseCorrect) {
            printf("error, parse fail\n");
        } else {
            // printf("parse success\n");
        }
        // check position ok: if not, correct it
        if(canCorrect){
            // TODO test
            /*{
             // delete st_
             {
             // get list
             freePos(position);
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
                char fen[300];
                {
                    position->myFen(fen);
                }
                printf("convertPositionToByteArray: correct: fen: %s\n", fen);
                // find correct positionBytes
                uint8_t* correctPositionBytes;
                bool chess960 = position->chess960;
                int32_t correctLength = seirawan_makePositionByFen(fen, chess960, correctPositionBytes);
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

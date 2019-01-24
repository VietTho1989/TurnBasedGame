//
//  position.cpp
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "shatranj_position.hpp"
#include <algorithm>
#include <cassert>
#include <cstddef> // For offsetof()
#include <cstring> // For std::memset, std::memcmp
#include <iomanip>
#include <sstream>

#include "shatranj_bitboard.hpp"
#include "shatranj_misc.hpp"
#include "shatranj_movegen.hpp"
#include "shatranj_thread.hpp"
#include "shatranj_tt.hpp"
#include "shatranj_uci.hpp"
#include "shatranj_tbprobe.hpp"
#include "shatranj_types.hpp"
#include "shatranj_jni.hpp"

using std::string;
using namespace std;

namespace Shatranj
{
    namespace PSQT {
        extern Score psq[PIECE_NB][SQUARE_NB];
    }
    
    namespace Zobrist {
        
        Key psq[PIECE_NB][SQUARE_NB];
        Key side, noPawns;
    }
    
    namespace {
        
        const string PieceToChar(" PBQNRK  pbqnrk");
        
        const Piece Pieces[] = { W_PAWN, W_BISHOP, W_QUEEN, W_KNIGHT, W_ROOK, W_KING,
            B_PAWN, B_BISHOP, B_QUEEN, B_KNIGHT, B_ROOK, B_KING };
        
        // min_attacker() is a helper function used by see_ge() to locate the least
        // valuable attacker for the side to move, remove the attacker we just found
        // from the bitboards and scan for new X-ray attacks behind it.
        
        template<int32_t Pt> PieceType min_attacker(const Bitboard* bb, Square to, Bitboard stmAttackers, Bitboard& occupied, Bitboard& attackers) {
            
            Bitboard b = stmAttackers & bb[Pt];
            if (!b)
                return min_attacker<Pt + 1>(bb, to, stmAttackers, occupied, attackers);
            
            occupied ^= b & ~(b - 1);
            
            if (Pt == ROOK)
                attackers |= attacks_bb<ROOK>(to, occupied) & bb[ROOK];
            
            attackers &= occupied; // After X-ray that may add already processed pieces
            return (PieceType)Pt;
        }
        
        template<> PieceType min_attacker<KING>(const Bitboard*, Square, Bitboard, Bitboard&, Bitboard&) {
            return KING; // No need to update bitboards: it is the last cycle
        }
        
    } // namespace
    
    
    /// operator<<(Position) returns an ASCII representation of the position
    
    std::ostream& operator<<(std::ostream& os, const Position& pos) {
        
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
        
        if (int(Tablebases::MaxCardinality) >= popcount(pos.pieces()))
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
    }
    
    // TODO ham tu them vao
    void printPos(const Position& pos)
    {
        char ret[1000];
        {
            ret[0] = 0;
            sprintf(ret, "%s\n +---+---+---+---+---+---+---+---+\n", ret);
            for (Rank r = RANK_8; r >= RANK_1; --r) {
                for (File f = FILE_A; f <= FILE_H; ++f){
                    sprintf(ret, "%s | %c", ret, PieceToChar[pos.piece_on(make_square(f, r))]);
                }
                sprintf(ret, "%s |\n +---+---+---+---+---+---+---+---+\n", ret);
            }
            
            // os << "\nFen: " << pos.fen() << "\nKey: " << std::hex << std::uppercase
            // << std::setfill('0') << std::setw(16) << pos.key()
            // << std::setfill(' ') << std::dec << "\nCheckers: ";
            {
                char strFen[120];
                {
                    pos.myFen(strFen);
                }
                sprintf(ret, "%s\nFen: %s\nKey: %llu\nCheckers: ", ret, strFen, pos.key());
            }
            
            // printf("makePrintPos: checker: %llu\n", pos.checkers());
            for (Bitboard b = pos.checkers(); b; ){
                char strSquare[10];
                UCI::square(strSquare, pop_lsb(&b));
                sprintf(ret, "%s%s ", ret, strSquare);
            }
        }
        printf("%s\n", ret);
    }
    
    
    /// Position::init() initializes at startup the various arrays used to compute
    /// hash keys.
    
    void Position::init() {
        
        PRNG rng(1070372);
        
        for (Piece pc : Pieces)
            for (Square s = SQ_A1; s <= SQ_H8; ++s)
                Zobrist::psq[pc][s] = rng.rand<Key>();
        
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
         3) -
         4) -
         5) Halfmove clock. This is the number of halfmoves since the last pawn advance
         or capture. This is used to determine if a draw can be claimed under the
         fifty-move rule.
         6) Fullmove number. The number of the full move. It starts at 1, and is
         incremented after Black's move.
         */
        
        unsigned char token;
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
                sq += Square(token - '0'); // Advance the given number of files
            
            else if (token == '/')
                sq -= Square(16);
            
            else if ((idx = PieceToChar.find(token)) != string::npos)
            {
                put_piece(Piece(idx), sq);
                ++sq;
            }
        }
        
        // 2. Active color
        ss >> token;
        sideToMove = (token == 'w' ? WHITE : BLACK);
        ss >> token;
        
        // 3-4. Skip castling and en passant flags if present
        if (!isdigit(ss.peek()))
        {
            while ((ss >> token) && !isspace(token)) {}
            while ((ss >> token) && !isspace(token)) {}
        }
        
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
    
    
    /// Position::set_check_info() sets king attacks to detect if a move gives check
    
    void Position::set_check_info(StateInfo* si) const {
        
        si->blockersForKing[WHITE] = slider_blockers(pieces(BLACK), square<KING>(WHITE), si->pinnersForKing[WHITE]);
        si->blockersForKing[BLACK] = slider_blockers(pieces(WHITE), square<KING>(BLACK), si->pinnersForKing[BLACK]);
        
        Square ksq = square<KING>(~sideToMove);
        
        si->checkSquares[PAWN]   = attacks_from<PAWN>(ksq, ~sideToMove);
        si->checkSquares[BISHOP] = attacks_from<BISHOP>(ksq);
        si->checkSquares[QUEEN]  = attacks_from<QUEEN>(ksq);
        si->checkSquares[KNIGHT] = attacks_from<KNIGHT>(ksq);
        si->checkSquares[ROOK]   = attacks_from<ROOK>(ksq);
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
        si->checkersBB = attackers_to(square<KING>(sideToMove)) & pieces(~sideToMove);
        
        set_check_info(si);
        
        for (Bitboard b = pieces(); b; )
        {
            Square s = pop_lsb(&b);
            Piece pc = piece_on(s);
            si->key ^= Zobrist::psq[pc][s];
            si->psq += PSQT::psq[pc][s];
        }
        
        if (sideToMove == BLACK)
            si->key ^= Zobrist::side;
        
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
        if(!(code[0] == 'K')){
            printf("error, assert(code[0] == 'K')\n");
        }
        
        string sides[] = { code.substr(code.find('K', 1)),      // Weak
            code.substr(0, code.find('K', 1)) }; // Strong
        
        std::transform(sides[c].begin(), sides[c].end(), sides[c].begin(), ::tolower);
        
        string fenStr = "8/" + sides[0] + char(8 - sides[0].length() + '0') + "/8/8/8/8/"
        + sides[1] + char(8 - sides[1].length() + '0') + "/8 w 0 10";
        
        return set(fenStr, false, si, nullptr);
    }
    
    
    /// Position::fen() returns a FEN representation of the position. In case of
    /// Chess960 the Shredder-FEN notation is used. This is mainly a debugging function.
    
    const string Position::fen() const
    {

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
        
        ss << (sideToMove == WHITE ? " w " : " b ");
        
        ss << st->rule50 << " " << 1 + (gamePly - (sideToMove == BLACK)) / 2;
        
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
        
        sprintf(ss, "%s%s", ss, (sideToMove == WHITE ? " w " : " b "));
        
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
        Bitboard snipers = PseudoAttacks[ROOK][s] & pieces(ROOK) & sliders;
        
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
        | (attacks_from<BISHOP>(s)         & pieces(BISHOP))
        | (attacks_from<QUEEN>(s)          & pieces(QUEEN))
        | (attacks_from<KNIGHT>(s)         & pieces(KNIGHT))
        | (attacks_bb<  ROOK>(s, occupied) & pieces(ROOK))
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
        if(!(color_of(moved_piece(m)) == us)){
            printf("error, assert(color_of(moved_piece(m)) == us)\n");
        }
        // assert(piece_on(square<KING>(us)) == make_piece(us, KING));
        if(!(piece_on(square<KING>(us)) == make_piece(us, KING))){
            printf("error, assert(piece_on(square<KING>(us)) == make_piece(us, KING))\n");
        }
        
        if (   count<ALL_PIECES>(us) == 1
            && (count<ALL_PIECES>(~us) > 2 || !capture(m)))
            return false;
        
        // If the moving piece is a king, check whether the destination
        // square is attacked by the opponent.
        if (type_of(piece_on(from)) == KING)
            return !(attackers_to(to_sq(m)) & pieces(~us));
        
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
        
        // Is not a promotion, so promotion piece must be empty
        if (promotion_type(m) - BISHOP != NO_PIECE_TYPE)
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
                && !((from + pawn_push(us) == to) && empty(to)))      // Not a single push
                
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
        if(!(color_of(moved_piece(m)) == sideToMove)){
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
        
        switch (type_of(m))
        {
            case NORMAL:
                return false;
                
            case PROMOTION:
                return attacks_bb(promotion_type(m), to, pieces() ^ from) & square<KING>(~sideToMove);
                
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
        Piece captured = piece_on(to);
        
        // assert(color_of(pc) == us);
        if(!(color_of(pc) == us)){
            printf("error, assert(color_of(pc) == us)\n");
        }
        // assert(captured == NO_PIECE || color_of(captured) == them);
        if(!(captured == NO_PIECE || color_of(captured) == them)){
            printf("error, assert(captured == NO_PIECE || color_of(captured) == them)\n");
        }
        // assert(type_of(captured) != KING);
        if(!(type_of(captured) != KING)){
            printf("error, assert(type_of(captured) != KING)\n");
        }
        
        if (captured)
        {
            Square capsq = to;
            
            // If the captured piece is a pawn, update pawn hash key, otherwise
            // update non-pawn material.
            if (type_of(captured) == PAWN)
                st->pawnKey ^= Zobrist::psq[captured][capsq];
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
                // printf("error, thread null\n");
            }
            
            // Update incremental scores
            st->psq -= PSQT::psq[captured][capsq];
            
            // Reset rule 50 counter
            st->rule50 = 0;
        }
        
        // Update hash key
        k ^= Zobrist::psq[pc][from] ^ Zobrist::psq[pc][to];
        
        move_piece(pc, from, to);
        
        // If the moving piece is a pawn do some special extra work
        if (type_of(pc) == PAWN)
        {
            if (type_of(m) == PROMOTION)
            {
                Piece promotion = make_piece(us, promotion_type(m));
                
                // assert(relative_rank(us, to) == RANK_8);
                if(!(relative_rank(us, to) == RANK_8)){
                    printf("error, assert(relative_rank(us, to) == RANK_8)\n");
                }
                // assert(type_of(promotion) == QUEEN);
                if(!(type_of(promotion) == QUEEN)){
                    printf("error, assert(type_of(promotion) == QUEEN)\n");
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
            // printf("pawnKey: %llu\n", st->pawnKey);
            if(thisThread!=NULL) {
                prefetch2(thisThread->pawnsTable[st->pawnKey]);
            } else {
                // printf("error, thread null2\n");
            }
            
            // Reset rule 50 draw counter
            st->rule50 = 0;
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
        
        // assert(empty(from));
        if(!empty(from)){
            printf("error, assert(empty(from))\n");
        }
        // assert(type_of(st->capturedPiece) != KING);
        if(!(type_of(st->capturedPiece) != KING)){
            printf("error, assert(type_of(st->capturedPiece) != KING)\n");
        }
        
        if (type_of(m) == PROMOTION)
        {
            // assert(relative_rank(us, to) == RANK_8);
            if(!(relative_rank(us, to) == RANK_8)){
                printf("error, assert(relative_rank(us, to) == RANK_8)\n");
            }
            // assert(type_of(pc) == promotion_type(m));
            if(!(type_of(pc) == promotion_type(m))){
                printf("error, assert(type_of(pc) == promotion_type(m))\n");
            }
            // assert(type_of(pc) == QUEEN);
            if(!(type_of(pc) == QUEEN)){
                printf("error, assert(type_of(pc) == QUEEN)\n");
            }
            
            remove_piece(pc, to);
            pc = make_piece(us, PAWN);
            put_piece(pc, to);
        }
        
        move_piece(pc, to, from); // Put the piece back at the source square
        
        if (st->capturedPiece)
        {
            Square capsq = to;
            put_piece(st->capturedPiece, capsq); // Restore the captured piece
        }
        
        // Finally point our state pointer back to the previous state
        st = st->previous;
        --gamePly;
        
        // assert(pos_is_ok());
        if(!pos_is_ok()){
            printf("error, assert(pos_is_ok())\n");
        }
    }
    
    
    /// Position::do(undo)_null_move() is used to do(undo) a "null move": It flips
    /// the side to move without executing any move on the board.
    
    void Position::do_null_move(StateInfo& newSt) {
        
        // assert(!checkers());
        if(checkers()){
            printf("error, assert(!checkers())\n");
        }
        // assert(&newSt != st);
        if(!(&newSt != st)){
            printf("error, assert(&newSt != st)\n");
        }
        
        std::memcpy(&newSt, st, sizeof(StateInfo));
        newSt.previous = st;
        st = &newSt;
        
        st->key ^= Zobrist::side;
        prefetch(thisThread->TT.first_entry(st->key));
        
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
    /// for speculative prefetch.
    
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
        Bitboard occupied, stmAttackers;
        
        balance = PieceValue[MG][piece_on(to)];
        
        if (balance < threshold)
            return false;
        
        balance -= PieceValue[MG][nextVictim];
        
        if (balance >= threshold) // Always true if nextVictim == KING
            return true;
        
        bool relativeStm = true; // True if the opponent is to move
        occupied = pieces() ^ from ^ to;
        
        // Find all attackers to the destination square, with the moving piece removed,
        // but possibly an X-ray attacker added behind it.
        Bitboard attackers = attackers_to(to, occupied) & occupied;
        
        while (true)
        {
            stmAttackers = attackers & pieces(stm);
            
            // Don't allow pinned pieces to attack pieces except the king as long all
            // pinners are on their original square.
            if (!(st->pinnersForKing[stm] & ~occupied))
                stmAttackers &= ~st->blockersForKing[stm];
            
            if (!stmAttackers)
                return relativeStm;
            
            // Locate and remove the next least valuable attacker
            nextVictim = min_attacker<PAWN>(byTypeBB, to, stmAttackers, occupied, attackers);
            
            if (nextVictim == KING)
                return relativeStm == bool(attackers & pieces(~stm));
            
            balance += relativeStm ?  PieceValue[MG][nextVictim]
            : -PieceValue[MG][nextVictim];
            
            relativeStm = !relativeStm;
            
            if (relativeStm == (balance >= threshold))
                return relativeStm;
            
            stm = ~stm;
        }
    }
    
    
    /// Position::is_draw() tests whether the position is drawn by 50-move rule
    /// or by repetition. It does not detect stalemates.
    
    bool Position::is_draw(int32_t ply) const {
        
        if (st->rule50 > 139 && (!checkers() || MoveList<LEGAL>(*this).size()))
            return true;

        int32_t end = min(st->rule50, st->pliesFromNull);
        
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
    
    bool Position::myIsDraw()
    {
        return is_draw(0);
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
        
        std::transform(f.begin(), f.end(), f.begin(),
                       [](char c) { return char(islower(c) ? toupper(c) : tolower(c)); });
        
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
            || piece_on(square<KING>(BLACK)) != B_KING) {
            // assert(0 && "pos_is_ok: Default");
            printf("error, pos_is_ok: Default");
            return false;
        }
        
        if (Fast)
            return true;
        
        if (   pieceCount[W_KING] != 1
            || pieceCount[B_KING] != 1
            || attackers_to(square<KING>(~sideToMove)) & pieces(sideToMove)) {
            // assert(0 && "pos_is_ok: Kings");
            printf("error, pos_is_ok: Kings\n");
            return false;
        }
        
        if (   (pieces(PAWN) & (Rank1BB | Rank8BB))
            || pieceCount[W_PAWN] > 8
            || pieceCount[B_PAWN] > 8) {
            // assert(0 && "pos_is_ok: Pawns");
            printf("error, pos_is_ok: Pawns\n");
            return false;
        }
        
        if (   (pieces(WHITE) & pieces(BLACK))
            || (pieces(WHITE) | pieces(BLACK)) != pieces()
            || popcount(pieces(WHITE)) > 16
            || popcount(pieces(BLACK)) > 16) {
            // assert(0 && "pos_is_ok: Bitboards");
            printf("error, pos_is_ok: Bitboards\n");
            return false;
        }
        
        for (PieceType p1 = PAWN; p1 <= KING; ++p1)
            for (PieceType p2 = PAWN; p2 <= KING; ++p2)
                if (p1 != p2 && (pieces(p1) & pieces(p2))) {
                    // assert(0 && "pos_is_ok: Bitboards");
                    printf("error, pos_is_ok: Bitboards\n");
                }
        
        StateInfo si = *st;
        set_state(&si);
        if (std::memcmp(&si, st, sizeof(StateInfo))) {
            // assert(0 && "pos_is_ok: State");
            printf("error, pos_is_ok: State\n");
        }
        
        for (Piece pc : Pieces)
        {
            if (   pieceCount[pc] != popcount(pieces(color_of(pc), type_of(pc)))
                || pieceCount[pc] != std::count(board, board + SQUARE_NB, pc)) {
                // assert(0 && "pos_is_ok: Pieces");
                printf("error, pos_is_ok: Pieces\n");
                return false;
            }
            
            for (int32_t i = 0; i < pieceCount[pc]; ++i)
                if (board[pieceList[pc][i]] != pc || index[pieceList[pc][i]] != i) {
                    // assert(0 && "pos_is_ok: Index");
                    printf("error, pos_is_ok: Index\n");
                    return false;
                }
        }
        
        return true;
    }
    
    bool Position::myPosIsOk()
    {
        const bool Fast = false; // Quick (default) or full check?
        
        if(this->st==NULL){
#ifdef Android
            __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "myPosIsOk: st null");
#endif
            return false;
        }
        
        if (   (sideToMove != WHITE && sideToMove != BLACK)
            || piece_on(square<KING>(WHITE)) != W_KING
            || piece_on(square<KING>(BLACK)) != B_KING) {
            // assert(0 && "pos_is_ok: Default");
            return false;
        }
        
        if (Fast)
            return true;
        
        if (   pieceCount[W_KING] != 1
            || pieceCount[B_KING] != 1
            || attackers_to(square<KING>(~sideToMove)) & pieces(sideToMove)) {
            // assert(0 && "pos_is_ok: Kings");
            return false;
        }
        
        if (   (pieces(PAWN) & (Rank1BB | Rank8BB))
            || pieceCount[W_PAWN] > 8
            || pieceCount[B_PAWN] > 8) {
            // assert(0 && "pos_is_ok: Pawns");
            return false;
        }
        
        if (   (pieces(WHITE) & pieces(BLACK))
            || (pieces(WHITE) | pieces(BLACK)) != pieces()
            || popcount(pieces(WHITE)) > 16
            || popcount(pieces(BLACK)) > 16) {
            // assert(0 && "pos_is_ok: Bitboards");
            return false;
        }
        
        for (PieceType p1 = PAWN; p1 <= KING; ++p1)
            for (PieceType p2 = PAWN; p2 <= KING; ++p2)
                if (p1 != p2 && (pieces(p1) & pieces(p2))) {
                    // assert(0 && "pos_is_ok: Bitboards");
                    return false;
                }
        
        StateInfo si = *st;
        set_state(&si);
        if (std::memcmp(&si, st, sizeof(StateInfo))) {
            // assert(0 && "pos_is_ok: State");
            return false;
        }
        
        for (Piece pc : Pieces)
        {
            if (   pieceCount[pc] != popcount(pieces(color_of(pc), type_of(pc)))
                || pieceCount[pc] != std::count(board, board + SQUARE_NB, pc)) {
                // assert(0 && "pos_is_ok: Pieces");
                return false;
            }
            
            for (int32_t i = 0; i < pieceCount[pc]; ++i)
                if (board[pieceList[pc][i]] != pc || index[pieceList[pc][i]] != i) {
                    // assert(0 && "pos_is_ok: Index");
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
            // int32_t    rule50;
            stateInfoSize+=sizeof(int32_t);
            // int32_t    pliesFromNull;
            stateInfoSize+=sizeof(int32_t);
            // Score  psq;
            stateInfoSize+=sizeof(int32_t);
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
            // int32_t pieceCount[PIECE_NB]; public LP<int32_t> pieceCount;
            otherPropertySize+=sizeof(int32_t)*(int32_t)PIECE_NB;
            // Square pieceList[PIECE_NB][16]; public LP<int> pieceList;
            otherPropertySize+=sizeof(int32_t)*(int32_t)PIECE_NB*16;
            // int32_t index[SQUARE_NB]; public LP<int32_t> index;
            otherPropertySize+=sizeof(int32_t)*(int32_t)SQUARE_NB;
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
                case 4:
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
                case 5:
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
                case 6:
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
                case 7:
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
                case 8:
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
                                    delete st;
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
                case 9:
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
#ifdef Android
                __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "Position not ok, need correct");
#endif
                // find fen
                char fen[200];
                position->myFen(fen);
                printf("convertPositionToByteArray: correct: fen: %s\n", fen);
                // find correct positionBytes
                uint8_t* correctPositionBytes;
                bool chess960 = position->chess960;
                int32_t correctLength = shatranj_makePositionByFen(fen, chess960, correctPositionBytes);
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

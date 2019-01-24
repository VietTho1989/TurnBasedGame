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

#ifndef CHESS_STOCK_FISH_POSITION_H_INCLUDED
#define CHESS_STOCK_FISH_POSITION_H_INCLUDED

#include <cassert>
#include <deque>
#include <memory> // For std::unique_ptr
#include <string>
#include <vector>
#include <list>

#include "chess_stock_fish_bitboard.hpp"
#include "chess_stock_fish_types.hpp"

namespace StockFishChess
{
    /// StateInfo struct stores information needed to restore a Position object to
    /// its previous state when we retract a move. Whenever a move is made on the
    /// board (by calling Position::do_move), a StateInfo object must be passed.
    
    struct StateInfo {
        
        // TODO Bitboard la uint64
        // TODO key cung la uint64
        
        // Copied when making a move
        Key    pawnKey;
        Key    materialKey;
        Value  nonPawnMaterial[COLOR_NB];
        int32_t    castlingRights;
        int32_t    rule50;
        int32_t    pliesFromNull;
        Score  psq;
        Square epSquare;
        
        // Not copied when making a move (will be recomputed anyhow)
        Key        key;
        Bitboard   checkersBB;
        Piece      capturedPiece;
        StateInfo* previous;
        Bitboard   blockersForKing[COLOR_NB];
        Bitboard   pinnersForKing[COLOR_NB];
        Bitboard   checkSquares[PIECE_TYPE_NB];
        
        static int32_t parse(StateInfo* st, uint8_t* stateInfoBytes, int32_t length, int32_t start)
        {
            // TODO co the LittleEdian va BigEndian khac nhau se co loi
            int32_t pointerIndex = start;
            int32_t index = 0;
            bool isParseCorrect = true;
            while (pointerIndex < length) {
                bool alreadyPassAll = false;
                // int32_t lastPointerIndex = pointerIndex;
                switch (index) {
                    case 0:
                    {
                        // public VP<ulong> pawnKey;
                        int32_t size = sizeof(uint64_t);
                        if(pointerIndex+size<=length){
                            memcpy(&st->pawnKey, stateInfoBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 1:
                    {
                        // public VP<ulong> materialKey;
                        int32_t size = sizeof(uint64_t);
                        if(pointerIndex+size<=length){
                            memcpy(&st->materialKey, stateInfoBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 2:
                    {
                        // public LP<int> nonPawnMaterial; // [COLOR_NB]
                        int32_t size = sizeof(int32_t)*COLOR_NB;
                        if(pointerIndex+size<=length){
                            memcpy(st->nonPawnMaterial, stateInfoBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 3:
                    {
                        // public VP<int32_t> castlingRights;
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&st->castlingRights, stateInfoBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 4:
                    {
                        // public VP<int32_t> rule50;
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&st->rule50, stateInfoBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 5:
                    {
                        // public VP<int32_t> pliesFromNull;
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&st->pliesFromNull, stateInfoBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 6:
                    {
                        // public VP<int32_t> psq;
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&st->psq, stateInfoBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 7:
                    {
                        // public VP<int32_t> epSquare;
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&st->epSquare, stateInfoBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 8:
                    {
                        // public VP<ulong> key;
                        int32_t size = sizeof(uint64_t);
                        if(pointerIndex+size<=length){
                            memcpy(&st->key, stateInfoBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 9:
                    {
                        // public VP<ulong> checkersBB;
                        int32_t size = sizeof(uint64_t);
                        if(pointerIndex+size<=length){
                            memcpy(&st->checkersBB, stateInfoBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 10:
                    {
                        // public VP<int32_t> capturedPiece;
                        int32_t size = sizeof(int32_t);
                        if(pointerIndex+size<=length){
                            memcpy(&st->capturedPiece, stateInfoBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 11:
                    {
                        // public LP<ulong> blockersForKing;// [COLOR_NB]
                        int32_t size = sizeof(uint64_t)*COLOR_NB;
                        if(pointerIndex+size<=length){
                            memcpy(st->blockersForKing, stateInfoBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 12:
                    {
                        // public LP<ulong> pinnersForKing; // [COLOR_NB]
                        int32_t size = sizeof(uint64_t)*COLOR_NB;
                        if(pointerIndex+size<=length){
                            memcpy(st->pinnersForKing, stateInfoBytes + pointerIndex, size);
                            pointerIndex+=size;
                        }else{
                            printf("length error: %d, %d\n", pointerIndex, length);
                            isParseCorrect = false;
                        }
                    }
                        break;
                    case 13:
                    {
                        // public LP<ulong> checkSquares;// [PIECE_TYPE_NB]
                        int32_t size = sizeof(uint64_t)*PIECE_TYPE_NB;
                        if(pointerIndex+size<=length){
                            memcpy(st->checkSquares, stateInfoBytes + pointerIndex, size);
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
                //printf("parse stateInfo count: %d; %d; %d; %d\n", pointerIndex, index, lastPointerIndex, (pointerIndex-lastPointerIndex));
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
                // printf("parse stateInfo fail: %d; %d; %d\n", pointerIndex, length, start);
                return -1;
            } else {
                // printf("parse stateInfo success: %d; %d; %d\n", pointerIndex, length, start);
                return (pointerIndex - start);
            }
        }
    };
    
    /// A list to keep track of the position states along the setup moves (from the
    /// start position to the position just before the search starts). Needed by
    /// 'draw by repetition' detection. Use a std::deque because pointers to
    /// elements are not invalidated upon list resizing.
    typedef std::unique_ptr<std::deque<StateInfo>> StateListPtr;
    
    
    /// Position class stores information regarding the board representation as
    /// pieces, side to move, hash keys, castling info, etc. Important methods are
    /// do_move() and undo_move(), used by the search to update node info when
    /// traversing the search tree.
    class Thread;
    
    class Position {
    public:
        static void init();
        
        Position() = default;
        Position(const Position&) = delete;
        Position& operator=(const Position&) = delete;
        
        //////////////////////////////////////////////////////////
        ////////////////////// Destructor ////////////////////////
        //////////////////////////////////////////////////////////
        
        std::vector<StateInfo*>* sts = NULL;// new std::vector<StateInfo*>;
        
        void pushStateInfo(StateInfo* st)
        {
            if(sts!=NULL){
                sts->push_back(st);
            } else {
                printf("error, sts NULL\n");
            }
        }
        
        void freeData()
        {
            if(sts!=NULL){
                for(int i=0; i<sts->size(); i++){
                    free(sts->at(i));
                }
                sts->clear();
                delete sts;
                sts = NULL;
            } else {
                printf("error, sts NULL\n");
            }
        }
        
        //////////////////////////////////////////////////////////
        ////////////////////// End Destructor ////////////////////
        //////////////////////////////////////////////////////////
        
        // FEN string input/output
        Position& set(const std::string& fenStr, bool isChess960, StateInfo* si, Thread* th);
        Position& set(const std::string& code, Color c, StateInfo* si);
        const std::string fen() const;
        
        void myFen(char* ss) const;
        
        void printFen(char* ss) const;
        
        // Position representation
        Bitboard pieces() const;
        Bitboard pieces(PieceType pt) const;
        Bitboard pieces(PieceType pt1, PieceType pt2) const;
        Bitboard pieces(Color c) const;
        Bitboard pieces(Color c, PieceType pt) const;
        Bitboard pieces(Color c, PieceType pt1, PieceType pt2) const;
        Piece piece_on(Square s) const;
        Square ep_square() const;
        bool empty(Square s) const;
        template<PieceType Pt> int32_t count(Color c) const;
        template<PieceType Pt> int32_t count() const;
        template<PieceType Pt> const Square* squares(Color c) const;
        template<PieceType Pt> Square square(Color c) const;
        
        // Castling
        int32_t can_castle(Color c) const;
        int32_t can_castle(CastlingRight cr) const;
        bool castling_impeded(CastlingRight cr) const;
        Square castling_rook_square(CastlingRight cr) const;
        
        // Checking
        Bitboard checkers() const;
        Bitboard discovered_check_candidates() const;
        Bitboard pinned_pieces(Color c) const;
        Bitboard check_squares(PieceType pt) const;
        
        // Attacks to/from a given square
        Bitboard attackers_to(Square s) const;
        Bitboard attackers_to(Square s, Bitboard occupied) const;
        Bitboard attacks_from(PieceType pt, Square s) const;
        template<PieceType> Bitboard attacks_from(Square s) const;
        template<PieceType> Bitboard attacks_from(Square s, Color c) const;
        Bitboard slider_blockers(Bitboard sliders, Square s, Bitboard& pinners) const;
        
        // Properties of moves
        bool legal(Move m) const;
        bool pseudo_legal(const Move m) const;
        bool capture(Move m) const;
        bool capture_or_promotion(Move m) const;
        bool gives_check(Move m) const;
        bool advanced_pawn_push(Move m) const;
        Piece moved_piece(Move m) const;
        Piece captured_piece() const;
        
        // Piece specific
        bool pawn_passed(Color c, Square s) const;
        bool opposite_bishops() const;
        
        // Doing and undoing moves
        void do_move(Move m, StateInfo& newSt);
        void do_move(Move m, StateInfo& newSt, bool givesCheck);
        void undo_move(Move m);
        void do_null_move(StateInfo& newSt);
        void undo_null_move();
        
        // Static Exchange Evaluation
        bool see_ge(Move m, Value threshold = VALUE_ZERO) const;
        
        // Accessing hash keys
        Key key() const;
        Key key_after(Move m) const;
        Key material_key() const;
        Key pawn_key() const;
        
        // Other properties of the position
        Color side_to_move() const;
        int32_t game_ply() const;
        bool is_chess960() const;
        Thread* this_thread() const;
        
        bool myIsDraw();
        bool is_draw(int32_t ply) const;

        int32_t rule50_count() const;
        Score psq_score() const;
        Value non_pawn_material(Color c) const;
        Value non_pawn_material() const;
        
        // Position consistency check, for debugging
        bool pos_is_ok() const;
        
        bool myPosIsOk();
        
        void flip();
        
        // TODO private:
    public:
        // Initialization helpers (used while setting up a position)
        void set_castling_right(Color c, Square rfrom);
        void set_state(StateInfo* si) const;
        void set_check_info(StateInfo* si) const;
        
        // Other helpers
        void put_piece(Piece pc, Square s);
        void remove_piece(Piece pc, Square s);
        void move_piece(Piece pc, Square from, Square to);
        template<bool Do> void do_castling(Color us, Square from, Square& to, Square& rfrom, Square& rto);
        
        // Data members
        Piece board[SQUARE_NB];
        Bitboard byTypeBB[PIECE_TYPE_NB];
        Bitboard byColorBB[COLOR_NB];
        int32_t pieceCount[PIECE_NB];
        // TODO Square co ve nhu la vi tri quan co tren ban co: vi du: A1
        Square pieceList[PIECE_NB][16];
        int32_t index[SQUARE_NB];
        int32_t castlingRightsMask[SQUARE_NB];
        Square castlingRookSquare[CASTLING_RIGHT_NB];
        Bitboard castlingPath[CASTLING_RIGHT_NB];
        int32_t gamePly;
        Color sideToMove;
        Thread* thisThread = NULL;
        StateInfo* st = NULL;
        bool chess960;
        
        /////////////////////////////////////////////////////////////////////////////////////
        //////////////////// Convert ///////////////////
        /////////////////////////////////////////////////////////////////////////////////////
        
        int32_t getByteSize();
        
        static int32_t convertToByteArray(Position* position, uint8_t* &byteArray);
        
        static int32_t parseByteArray(Position* position, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect);
    };
    
    extern std::ostream& operator<<(std::ostream& os, const Position& pos);
    
    void printPos(const Position& pos);
    
    inline Color Position::side_to_move() const {
        return sideToMove;
    }
    
    inline bool Position::empty(Square s) const {
        return board[s] == NO_PIECE;
    }
    
    inline Piece Position::piece_on(Square s) const {
        return board[s];
    }
    
    inline Piece Position::moved_piece(Move m) const {
        return board[from_sq(m)];
    }
    
    inline Bitboard Position::pieces() const {
        return byTypeBB[ALL_PIECES];
    }
    
    inline Bitboard Position::pieces(PieceType pt) const {
        return byTypeBB[pt];
    }
    
    inline Bitboard Position::pieces(PieceType pt1, PieceType pt2) const {
        return byTypeBB[pt1] | byTypeBB[pt2];
    }
    
    inline Bitboard Position::pieces(Color c) const {
        return byColorBB[c];
    }
    
    inline Bitboard Position::pieces(Color c, PieceType pt) const {
        return byColorBB[c] & byTypeBB[pt];
    }
    
    inline Bitboard Position::pieces(Color c, PieceType pt1, PieceType pt2) const {
        return byColorBB[c] & (byTypeBB[pt1] | byTypeBB[pt2]);
    }
    
    template<PieceType Pt> inline int32_t Position::count(Color c) const {
        return pieceCount[make_piece(c, Pt)];
    }
    
    template<PieceType Pt> inline int32_t Position::count() const {
        return pieceCount[make_piece(WHITE, Pt)] + pieceCount[make_piece(BLACK, Pt)];
    }
    
    template<PieceType Pt> inline const Square* Position::squares(Color c) const {
        return pieceList[make_piece(c, Pt)];
    }
    
    template<PieceType Pt> inline Square Position::square(Color c) const {
        // assert(pieceCount[make_piece(c, Pt)] == 1);
        if(!(pieceCount[make_piece(c, Pt)] == 1)){
            printf("error, assert(pieceCount[make_piece(c, Pt)] == 1)\n");
            return SQ_A1;
        }
        return pieceList[make_piece(c, Pt)][0];
    }
    
    inline Square Position::ep_square() const {
        if(st==NULL){
            printf("state info null: Square\n");
            return  SQUARE_NB;
        }
        return st->epSquare;
    }
    
    inline int32_t Position::can_castle(CastlingRight cr) const {
        if(st==NULL){
            printf("error, stateInfo null\n");
            return 0;
        }
        return st->castlingRights & cr;
    }
    
    inline int32_t Position::can_castle(Color c) const {
        if(st==NULL){
            printf("can_castle: color\n");
            return 0;
        }
        return st->castlingRights & ((WHITE_OO | WHITE_OOO) << (2 * c));
    }
    
    inline bool Position::castling_impeded(CastlingRight cr) const {
        return byTypeBB[ALL_PIECES] & castlingPath[cr];
    }
    
    inline Square Position::castling_rook_square(CastlingRight cr) const {
        return castlingRookSquare[cr];
    }
    
    template<PieceType Pt> inline Bitboard Position::attacks_from(Square s) const {
        // assert(Pt != PAWN);
        if(!(Pt != PAWN)){
            printf("error, assert(Pt != PAWN)\n");
        }
        return  Pt == BISHOP || Pt == ROOK ? attacks_bb<Pt>(s, byTypeBB[ALL_PIECES])
        : Pt == QUEEN  ? attacks_from<ROOK>(s) | attacks_from<BISHOP>(s)
        : PseudoAttacks[Pt][s];
    }
    
    template<> inline Bitboard Position::attacks_from<PAWN>(Square s, Color c) const {
        return PawnAttacks[c][s];
    }
    
    inline Bitboard Position::attacks_from(PieceType pt, Square s) const {
        return attacks_bb(pt, s, byTypeBB[ALL_PIECES]);
    }
    
    inline Bitboard Position::attackers_to(Square s) const {
        return attackers_to(s, byTypeBB[ALL_PIECES]);
    }
    
    inline Bitboard Position::checkers() const {
        return st->checkersBB;
    }
    
    inline Bitboard Position::discovered_check_candidates() const {
        return st->blockersForKing[~sideToMove] & pieces(sideToMove);
    }
    
    inline Bitboard Position::pinned_pieces(Color c) const {
        return st->blockersForKing[c] & pieces(c);
    }
    
    inline Bitboard Position::check_squares(PieceType pt) const {
        return st->checkSquares[pt];
    }
    
    inline bool Position::pawn_passed(Color c, Square s) const {
        return !(pieces(~c, PAWN) & passed_pawn_mask(c, s));
    }
    
    inline bool Position::advanced_pawn_push(Move m) const {
        return   type_of(moved_piece(m)) == PAWN
        && relative_rank(sideToMove, from_sq(m)) > RANK_4;
    }
    
    inline Key Position::key() const {
        return st->key;
    }
    
    inline Key Position::pawn_key() const {
        return st->pawnKey;
    }
    
    inline Key Position::material_key() const {
        return st->materialKey;
    }
    
    inline Score Position::psq_score() const {
        return st->psq;
    }
    
    inline Value Position::non_pawn_material(Color c) const {
        return st->nonPawnMaterial[c];
    }
    
    inline Value Position::non_pawn_material() const {
        return st->nonPawnMaterial[WHITE] + st->nonPawnMaterial[BLACK];
    }
    
    inline int32_t Position::game_ply() const {
        return gamePly;
    }
    
    inline int32_t Position::rule50_count() const {
        if(st==NULL){
            printf("stateInfo null: rule50\n");
            return 0;
        }
        return st->rule50;
    }
    
    inline bool Position::opposite_bishops() const {
        return   pieceCount[W_BISHOP] == 1
        && pieceCount[B_BISHOP] == 1
        && opposite_colors(square<BISHOP>(WHITE), square<BISHOP>(BLACK));
    }
    
    inline bool Position::is_chess960() const {
        return chess960;
    }
    
    inline bool Position::capture_or_promotion(Move m) const {
        // assert(is_ok(m));
        if(!is_ok(m)){
            printf("error, assert(is_ok(m))\n");
        }
        return type_of(m) != NORMAL ? type_of(m) != CASTLING : !empty(to_sq(m));
    }
    
    inline bool Position::capture(Move m) const {
        // assert(is_ok(m));
        if(!is_ok(m)){
            printf("error, assert(is_ok(m))\n");
        }
        // Castling is encoded as "king captures rook"
        return (!empty(to_sq(m)) && type_of(m) != CASTLING) || type_of(m) == ENPASSANT;
    }
    
    inline Piece Position::captured_piece() const {
        return st->capturedPiece;
    }
    
    inline Thread* Position::this_thread() const {
        return thisThread;
    }
    
    inline void Position::put_piece(Piece pc, Square s) {
        
        board[s] = pc;
        byTypeBB[ALL_PIECES] |= s;
        byTypeBB[type_of(pc)] |= s;
        byColorBB[color_of(pc)] |= s;
        index[s] = pieceCount[pc]++;
        pieceList[pc][index[s]] = s;
        pieceCount[make_piece(color_of(pc), ALL_PIECES)]++;
    }
    
    inline void Position::remove_piece(Piece pc, Square s) {
        
        // WARNING: This is not a reversible operation. If we remove a piece in
        // do_move() and then replace it in undo_move() we will put it at the end of
        // the list and not in its original place, it means index[] and pieceList[]
        // are not invariant to a do_move() + undo_move() sequence.
        byTypeBB[ALL_PIECES] ^= s;
        byTypeBB[type_of(pc)] ^= s;
        byColorBB[color_of(pc)] ^= s;
        /* board[s] = NO_PIECE;  Not needed, overwritten by the capturing one */
        Square lastSquare = pieceList[pc][--pieceCount[pc]];
        index[lastSquare] = index[s];
        pieceList[pc][index[lastSquare]] = lastSquare;
        pieceList[pc][pieceCount[pc]] = SQ_NONE;
        pieceCount[make_piece(color_of(pc), ALL_PIECES)]--;
    }
    
    inline void Position::move_piece(Piece pc, Square from, Square to) {
        
        // index[from] is not updated and becomes stale. This works as long as index[]
        // is accessed just by known occupied squares.
        Bitboard from_to_bb = SquareBB[from] ^ SquareBB[to];
        byTypeBB[ALL_PIECES] ^= from_to_bb;
        byTypeBB[type_of(pc)] ^= from_to_bb;
        byColorBB[color_of(pc)] ^= from_to_bb;
        board[from] = NO_PIECE;
        board[to] = pc;
        index[to] = index[from];
        pieceList[pc][index[to]] = to;
    }
    
    // TODO cai ham do_move co ve nhu co van de ve thu tu cac stateInfo
    inline void Position::do_move(Move m, StateInfo& newSt) {
        do_move(m, newSt, gives_check(m));
    }
}

#endif // #ifndef POSITION_H_INCLUDED

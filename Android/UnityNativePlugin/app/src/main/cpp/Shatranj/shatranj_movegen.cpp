//
//  movegen.cpp
//  Shatranj
//
//  Created by Viet Tho on 7/7/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include "shatranj_movegen.hpp"
#include <cassert>

#include "shatranj_position.hpp"

namespace Shatranj
{
    namespace {
        
        template<GenType Type, Square D> ExtMove* make_promotions(ExtMove* moveList, Square to) {
            
            if (Type == CAPTURES || Type == EVASIONS || Type == NON_EVASIONS)
                *moveList++ = make<PROMOTION>(to - D, to, QUEEN);
            
            return moveList;
        }
        
        
        template<Color Us, GenType Type> ExtMove* generate_pawn_moves(const Position& pos, ExtMove* moveList, Bitboard target) {
            
            // Compute our parametrized parameters at compile time, named according to
            // the point of view of white side.
            const Color    Them     = (Us == WHITE ? BLACK      : WHITE);
            const Bitboard TRank8BB = (Us == WHITE ? Rank8BB    : Rank1BB);
            const Bitboard TRank7BB = (Us == WHITE ? Rank7BB    : Rank2BB);
            const Square   Up       = (Us == WHITE ? NORTH      : SOUTH);
            const Square   Right    = (Us == WHITE ? NORTH_EAST : SOUTH_WEST);
            const Square   Left     = (Us == WHITE ? NORTH_WEST : SOUTH_EAST);
            
            Bitboard emptySquares;
            
            Bitboard pawnsOn7    = pos.pieces(Us, PAWN) &  TRank7BB;
            Bitboard pawnsNotOn7 = pos.pieces(Us, PAWN) & ~TRank7BB;
            
            Bitboard enemies = (Type == EVASIONS ? pos.pieces(Them) & target:
                                Type == CAPTURES ? target : pos.pieces(Them));
            
            // Single and double pawn pushes, no promotions
            if (Type != CAPTURES)
            {
                emptySquares = (Type == QUIETS || Type == QUIET_CHECKS ? target : ~pos.pieces());
                
                Bitboard b1 = shift<Up>(pawnsNotOn7)   & emptySquares;
                
                if (Type == EVASIONS) // Consider only blocking squares
                    b1 &= target;
                
                if (Type == QUIET_CHECKS)
                {
                    Square ksq = pos.square<KING>(Them);
                    
                    b1 &= pos.attacks_from<PAWN>(ksq, Them);
                    
                    // Add pawn pushes which give discovered check. This is possible only
                    // if the pawn is not on the same file as the enemy king, because we
                    // don't generate captures. Note that a possible discovery check
                    // promotion has been already generated amongst the captures.
                    Bitboard dcCandidates = pos.discovered_check_candidates();
                    if (pawnsNotOn7 & dcCandidates)
                    {
                        Bitboard dc1 = shift<Up>(pawnsNotOn7 & dcCandidates) & emptySquares & ~file_bb(ksq);
                        
                        b1 |= dc1;
                    }
                }
                
                while (b1)
                {
                    Square to = pop_lsb(&b1);
                    *moveList++ = make_move(to - Up, to);
                }
            }
            
            // Promotions and underpromotions
            if (pawnsOn7 && (Type != EVASIONS || (target & TRank8BB)))
            {
                if (Type == CAPTURES)
                    emptySquares = ~pos.pieces();
                
                if (Type == EVASIONS)
                    emptySquares &= target;
                
                Bitboard b1 = shift<Right>(pawnsOn7) & enemies;
                Bitboard b2 = shift<Left >(pawnsOn7) & enemies;
                Bitboard b3 = shift<Up   >(pawnsOn7) & emptySquares;
                
                while (b1)
                    moveList = make_promotions<Type, Right>(moveList, pop_lsb(&b1));
                
                while (b2)
                    moveList = make_promotions<Type, Left >(moveList, pop_lsb(&b2));
                
                while (b3)
                    moveList = make_promotions<Type, Up   >(moveList, pop_lsb(&b3));
            }
            
            // Standard captures
            if (Type == CAPTURES || Type == EVASIONS || Type == NON_EVASIONS)
            {
                Bitboard b1 = shift<Right>(pawnsNotOn7) & enemies;
                Bitboard b2 = shift<Left >(pawnsNotOn7) & enemies;
                
                while (b1)
                {
                    Square to = pop_lsb(&b1);
                    *moveList++ = make_move(to - Right, to);
                }
                
                while (b2)
                {
                    Square to = pop_lsb(&b2);
                    *moveList++ = make_move(to - Left, to);
                }
            }
            
            return moveList;
        }
        
        
        template<PieceType Pt, bool Checks> ExtMove* generate_moves(const Position& pos, ExtMove* moveList, Color us, Bitboard target) {
            
            // assert(Pt != KING && Pt != PAWN);
            if(!(Pt != KING && Pt != PAWN)){
                printf("error, assert(Pt != KING && Pt != PAWN)\n");
            }
            
            const Square* pl = pos.squares<Pt>(us);
            
            for (Square from = *pl; from != SQ_NONE; from = *++pl)
            {
                if (Checks)
                {
                    if (     Pt == ROOK
                        && !(PseudoAttacks[Pt][from] & target & pos.check_squares(Pt)))
                        continue;
                    
                    if (pos.discovered_check_candidates() & from)
                        continue;
                }
                
                Bitboard b = pos.attacks_from<Pt>(from) & target;
                
                if (Checks)
                    b &= pos.check_squares(Pt);
                
                while (b)
                    *moveList++ = make_move(from, pop_lsb(&b));
            }
            
            return moveList;
        }
        
        
        template<Color Us, GenType Type> ExtMove* generate_all(const Position& pos, ExtMove* moveList, Bitboard target) {
            
            const bool Checks = Type == QUIET_CHECKS;
            
            moveList = generate_pawn_moves<Us, Type>(pos, moveList, target);
            moveList = generate_moves<BISHOP, Checks>(pos, moveList, Us, target);
            moveList = generate_moves< QUEEN, Checks>(pos, moveList, Us, target);
            moveList = generate_moves<KNIGHT, Checks>(pos, moveList, Us, target);
            moveList = generate_moves<  ROOK, Checks>(pos, moveList, Us, target);
            
            if (Type != QUIET_CHECKS && Type != EVASIONS)
            {
                Square ksq = pos.square<KING>(Us);
                Bitboard b = pos.attacks_from<KING>(ksq) & target;
                while (b)
                    *moveList++ = make_move(ksq, pop_lsb(&b));
            }
            
            return moveList;
        }
        
    } // namespace
    
    
    /// generate<CAPTURES> generates all pseudo-legal captures and queen
    /// promotions. Returns a pointer to the end of the move list.
    ///
    /// generate<QUIETS> generates all pseudo-legal non-captures and
    /// underpromotions. Returns a pointer to the end of the move list.
    ///
    /// generate<NON_EVASIONS> generates all pseudo-legal captures and
    /// non-captures. Returns a pointer to the end of the move list.
    
    template<GenType Type> ExtMove* generate(const Position& pos, ExtMove* moveList) {
        
        // assert(Type == CAPTURES || Type == QUIETS || Type == NON_EVASIONS);
        if(!(Type == CAPTURES || Type == QUIETS || Type == NON_EVASIONS)){
            printf("error, assert(Type == CAPTURES || Type == QUIETS || Type == NON_EVASIONS)\n");
        }
        // assert(!pos.checkers());
        if(pos.checkers()){
            printf("error, assert(!pos.checkers())\n");
        }
        
        Color us = pos.side_to_move();
        
        Bitboard target =  Type == CAPTURES     ?  pos.pieces(~us)
        : Type == QUIETS       ? ~pos.pieces()
        : Type == NON_EVASIONS ? ~pos.pieces(us) : 0;
        
        return us == WHITE ? generate_all<WHITE, Type>(pos, moveList, target)
        : generate_all<BLACK, Type>(pos, moveList, target);
    }
    
    // Explicit template instantiations
    template ExtMove* generate<CAPTURES>(const Position&, ExtMove*);
    template ExtMove* generate<QUIETS>(const Position&, ExtMove*);
    template ExtMove* generate<NON_EVASIONS>(const Position&, ExtMove*);
    
    
    /// generate<QUIET_CHECKS> generates all pseudo-legal non-captures and knight
    /// underpromotions that give check. Returns a pointer to the end of the move list.
    template<> ExtMove* generate<QUIET_CHECKS>(const Position& pos, ExtMove* moveList) {
        
        // assert(!pos.checkers());
        if(pos.checkers()){
            printf("error, assert(!pos.checkers())\n");
        }
        
        Color us = pos.side_to_move();
        Bitboard dc = pos.discovered_check_candidates();
        
        while (dc)
        {
            Square from = pop_lsb(&dc);
            PieceType pt = type_of(pos.piece_on(from));
            
            if (pt == PAWN)
                continue; // Will be generated together with direct checks
            
            Bitboard b = pos.attacks_from(pt, from) & ~pos.pieces();
            
            if (pt == KING)
                b &= ~PseudoAttacks[ROOK][pos.square<KING>(~us)];
            
            while (b)
                *moveList++ = make_move(from, pop_lsb(&b));
        }
        
        return us == WHITE ? generate_all<WHITE, QUIET_CHECKS>(pos, moveList, ~pos.pieces())
        : generate_all<BLACK, QUIET_CHECKS>(pos, moveList, ~pos.pieces());
    }
    
    
    /// generate<EVASIONS> generates all pseudo-legal check evasions when the side
    /// to move is in check. Returns a pointer to the end of the move list.
    template<> ExtMove* generate<EVASIONS>(const Position& pos, ExtMove* moveList) {
        
        // assert(pos.checkers());
        if(!pos.checkers()){
            printf("error, assert(pos.checkers())\n");
        }
        
        Color us = pos.side_to_move();
        Square ksq = pos.square<KING>(us);
        Bitboard sliderAttacks = 0;
        Bitboard sliders = pos.checkers() & pos.pieces(ROOK);
        
        // Find all the squares attacked by slider checkers. We will remove them from
        // the king evasions in order to skip known illegal moves, which avoids any
        // useless legality checks later on.
        while (sliders)
        {
            Square checksq = pop_lsb(&sliders);
            sliderAttacks |= LineBB[checksq][ksq] ^ checksq;
        }
        
        // Generate evasions for king, capture and non capture moves
        Bitboard b = pos.attacks_from<KING>(ksq) & ~pos.pieces(us) & ~sliderAttacks;
        while (b)
            *moveList++ = make_move(ksq, pop_lsb(&b));
        
        if (more_than_one(pos.checkers()))
            return moveList; // Double check, only a king move can save the day
        
        // Generate blocking evasions or captures of the checking piece
        Square checksq = lsb(pos.checkers());
        Bitboard target = between_bb(checksq, ksq) | checksq;
        
        return us == WHITE ? generate_all<WHITE, EVASIONS>(pos, moveList, target)
        : generate_all<BLACK, EVASIONS>(pos, moveList, target);
    }
    
    
    /// generate<LEGAL> generates all the legal moves in the given position
    
    template<> ExtMove* generate<LEGAL>(const Position& pos, ExtMove* moveList) {
        
        Bitboard pinned = pos.pinned_pieces(pos.side_to_move());
        Square ksq = pos.square<KING>(pos.side_to_move());
        ExtMove* cur = moveList;
        
        moveList = pos.checkers() ? generate<EVASIONS    >(pos, moveList)
        : generate<NON_EVASIONS>(pos, moveList);
        while (cur != moveList)
            if (   (pinned || from_sq(*cur) == ksq)
                && !pos.legal(*cur))
                *cur = (--moveList)->move;
            else
                ++cur;
        
        return moveList;
    }
}

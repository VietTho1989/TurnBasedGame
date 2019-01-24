/*
* Copyright (C) 2015 Sergio Nunes da Silva Junior 
*
* C++ Nine Men's Morris Agent using alpha-beta prunning algorithm
* Assignment of Artificial Intelligence Course - 2/2015
*
* This program is free software; you can redistribute it and/or modify it
* under the terms of the GNU General Public License as published by the Free
* Software Foundation; either version 2 of the License.
*
* This program is distributed in the hope that it will be useful, but WITHOUT
* ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
* FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for
* more details.
*
* author: Sergio Nunes da Silva Junior
* contact: sergio.nunes@dcc.ufmg.com.br
* Universidade Federal de Minas Gerais (UFMG) - Brazil
*/

#ifndef NMMAGENT_H
#define NMMAGENT_H

#include <fstream>
#include <climits>
#include <vector>
#include <cfloat>
#include "nmm_board.hpp"
#include "nmm_state.hpp"
#include "nmm_evaluator.hpp"

namespace NMM
{
    class NMMAgent
    {
    public:
        int32_t MaxNormal = 3;//7;
        int32_t MaxPositioning = 3;// 5;
        int32_t MaxBlackAndWhite3 = 3;// 4;
        int32_t MaxBlackOrWhite3 = 3;// 5;
        
    public:
        NMMAgent(void);
        ~NMMAgent(void);
        
        void set_color_pieces(bool i_am_white) { this->i_am_white = i_am_white; }
        bool get_color_pieces() { return i_am_white; }
        
        void set_game_phase(GamePhase p) { phase = p; }
        GamePhase get_game_phase() { return phase; }
        
        void play(const SmrtState &root);
        SmrtState decide(const SmrtState &root);
        std::vector<SmrtState> expand(const SmrtState &root, const bool &white_turn);
        std::vector<SmrtState> sucessor(const SmrtBoard &board, const bool & white_turn);
        
        void set_evaluator_weights(int positioning[6], int playing[7], int flying[4]);
        
        // board utility function
        float evaluate(Board &board, const bool &white_turn, const bool &mill);
        
        void set_last_play(std::string from, std::string to) {last_from = from; last_to = to;}
        
    public:
        // Evaluator funciont
        Evaluator* eval;
        // Current gamephase ( placement, playing, flying)
        GamePhase phase;
        // flag for the player color pieces
        bool i_am_white;
        // debug purposes
        // ofstream out;
        
        // save last movement to avoid draw.
        std::string last_from;
        std::string last_to;
        
        // generate sucessor states for positioning phase
        std::vector<SmrtState> sucessor_positioning(const SmrtBoard &board, const bool & white_turn);
        // generate sucessor states for playing phase
        std::vector<SmrtState> sucessor_playing(const SmrtBoard &board, const bool & white_turn);
        // generate sucessor states for flying phase
        std::vector<SmrtState> sucessor_playing_flying(const SmrtBoard &board, const bool & white_turn);
        // generate sucessor states which a piece is removed, it is used to expand state when there is a morris.
        // force flag allows to remove any piece even if it is within a morris
        std::vector<SmrtState> sucessor_removing(const SmrtBoard &board, const bool & white_turn, NMMAction a, int piece, int to = 0, bool force = false);
        // binary search to insert new state in a sorted way
        int binarysrc(float &utility, int b, int e,  std::vector<SmrtState> &l);
        // make a decision using minimax algorithm
        SmrtState minimax_decision(const SmrtState &root, int max_level);
        
        // return best play for max player using alpha-beta prunning
        float max_value_pab(const SmrtState &root, int level, SmrtState &move, float alpha = -FLT_MAX, float beta = FLT_MAX, bool first_call = false);
        // return best play for min player using alpha-beta prunning
        float min_value_pab(const SmrtState &root, int level, SmrtState &move, float alpha = -FLT_MAX, float beta = FLT_MAX);
        // return best play for max player using regular minimax
        float max_value(const SmrtState &root, int level, SmrtState &move);
        // return best play for min player using regular minimax
        float min_value(const SmrtState &root, int level, SmrtState &move);
        // write down the chosen movement
        inline void write_play(SmrtState state);
        // verify whether chosen movement is repetead
        inline bool repeated_play(SmrtState state);
    };
}

#endif

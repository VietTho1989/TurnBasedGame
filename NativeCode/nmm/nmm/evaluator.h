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

#ifndef EVALUATOR_H
#define EVALUATOR_H

#include "board.h"

class Evaluator
{
public:
    int pickBestMove = 40;
    
public:
	Evaluator(void);
	~Evaluator(void);

	void set_evaluation_weight(int positioning[6], int playing[7], int flying[4]);

	// função de utilidade do tabuleiro no estado de posicionamento
	float evaluate_position(const Board &board, const bool &white_turn, const bool &mill);
	// função de utilidade do tabuleiro no estado de jogando
	float evaluate_playing(const Board &board, const bool &white_turn, const bool &mill);
	// função de utilidade do tabuleiro no estado de voando
	float evaluate_flying(const Board &board, const bool &white_turn, const bool &mill);
	// retorna se tabuleiro é vitória
	int is_winning_state(const Board &board, const SpotStatus &ss);
private:
	int w_pos[6];
	int w_play[7];
	int w_fly[4];
	int* adjacency;
	
	// retorna o número de morrises no jogo
	inline int morrises_number(const Board &board, const SpotStatus &ss);
	// retorna o numero de peças bloqueadas do oponente
	inline int blocked_opp_pieces(const Board &board, const SpotStatus &ss);
	// retorna a diferença de peças na fase de posicionamento
	inline int difference_pieces_positioning(const Board &b, const bool &white_turn); 
	// retorna a diferença de peças na fase de jogando
	inline int difference_pieces(const Board &b, const bool &white_turn);
	// retorna o numero de configurações 2 peças
	inline int number_2pieces(const Board &board, const SpotStatus &ss);
	// retorna o numero de configurações 3 peças
	inline int number_3pieces(const Board &board, const SpotStatus &ss);
	// retorna o numero de morrises abertos
	inline int opened_morris(const Board &b, const SpotStatus &ss);
	// retorna o numero de morrises duplo 
	inline int double_morris(const Board &b, const SpotStatus &ss);
	
	// verifica se a peça participa de um mill
	inline bool is_closed_morris(Spot* p1, Spot* p2, Spot* p3, const SpotStatus &ss);
	// verifica se a peça participa de um mill na vertical
	inline bool is_closed_morris_v(Spot* p, const SpotStatus &ss); 
	// verifica se a peça participa de um mill na horizontal
	inline bool is_closed_morris_h(Spot* p, const SpotStatus &ss);
	// verifica se a peça está bloqueada
	inline bool is_blocked(Spot* p);
	// verificar se é configuração 2 peças 1 espaço
	inline bool is_2pieces(Spot* p1, Spot* p2, Spot* p3, const SpotStatus &ss);
	// verifica se é configuração 2 peças 1 espaço na vertical
	inline bool is_2pieces_v(Spot* p, const SpotStatus &ss);
	// verifica se é configuração 2 peças 1 espaço na horizontal
	inline bool is_2pieces_h(Spot* p, const SpotStatus &ss);
	// retorna a abertura de uma conf 2 peças, se não houver, retorna null.
	inline Spot* is_open(Spot* p1, Spot* p2, Spot* p3, const SpotStatus &ss);
	// verifica se é configuração 2 peças 1 espaço na vertical
	inline bool is_open_v(Spot* p, const SpotStatus &ss);
	// verifica se é configuração 2 peças 1 espaço na horizontal
	inline bool is_open_h(Spot* p, const SpotStatus &ss);
	
};

#endif

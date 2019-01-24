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

#include "evaluator.h"

/*  ________________________________________________________
*	|__Positioning______|__Playing__________|__Flying_______|
*	|0 Closed morris	|0 Closed morris	|0 conf 2 pieces|
*	|1 Morrises number	|1 Morrises number	|1 conf 3 pieces|
*	|2 Blocked opp pcs	|2 Blocked opp pcs	|2 Closed morris|
*	|3 Pieces number	|3 Pieces number	|3 Winning conf |
*	|4 conf 2 pieces	|4 Opened morris	|				|
*   |5 conf 3 pieces	|5 Double morris	|				|
*   |					|6 Winning conf		|				|
*	|___________________|___________________|_______________|
*/

static const int ADJACENCY[24] = {	1,			2,			1,
										1,		3,		1,
											 1, 2, 1,
									2,  3,   2,	   2,   3,	2,
											 1, 2, 1,
										1,		3,		1,
									1,			2,			1};

Evaluator::Evaluator(void){}

Evaluator::~Evaluator(void){}

void Evaluator::set_evaluation_weight(int positioning[6], int playing[7], int flying[4])
{
	for(int i = 0; i < 4; i++)
	{
		w_pos[i] = positioning[i];
		w_play[i] = playing[i];
		w_fly[i] = flying[i];
	}
	w_pos[4] = positioning[4];	w_pos[5] = positioning[5];
	w_play[4] = playing[4];	w_play[5] = playing[5];	w_play[6] = playing[6];
}

float Evaluator::evaluate_position(const Board &board, const bool &white_turn, const bool &mill)
{
	float score = 0;

	SpotStatus me = white_turn ? SS_White : SS_Black;
	SpotStatus opp = white_turn ? SS_Black : SS_White;

	// closed morris - se houve mill nessa jogada
	score += w_pos[0] * (mill ? 1 : 0);
	// morrises number - quantidade de morris formado
	score += w_pos[1] * (morrises_number(board, me) - morrises_number(board, opp));
	// blocked opp number - número de peças bloqueadas do oponente
	score += w_pos[2] * blocked_opp_pieces(board, opp);
	// pieces number - número de peças em jogo, a posição no tabuleiro conta pontos.
	score += w_pos[3] * difference_pieces_positioning(board, white_turn);
	// number of 2 pieces configuration - numero de linhas que possuem
	// 2 peças e um espaço vazio, chance de mill
	score += w_pos[4] * (number_2pieces(board, me) - number_2pieces(board, opp));
	// number of 3 pieces configuration - numero de 2 linhas que possuem
	// conf 2 pieces e é inevitável fazer mill na próxima jogada
	score += w_pos[5] * (number_3pieces(board, me) - number_3pieces(board, opp));

    // printf("evaluate_position: score: %d\n", score);
    if(pickBestMove>=0 && pickBestMove<100){
        float random = rand() % (100-pickBestMove);
        float newScore = score*(100-random)/100;
        // printf("random: %f, %f, %f\n", score, newScore, random);
        return newScore;
    }else {
        return score;
    }
}

float Evaluator::evaluate_playing(const Board &board, const bool &white_turn, const bool &mill)
{
	float score = 0;
	SpotStatus me = white_turn ? SS_White : SS_Black;
	SpotStatus opp = white_turn ? SS_Black : SS_White;

	// closed morris - se houve mill nessa jogada
	score += w_play[0] * (mill ? 1 : 0);
	// morrises number - quantidade de morris formado
	score += w_play[1] * (morrises_number(board, me) - morrises_number(board, opp));
	// blocked opp number - número de peças bloqueadas do oponente
	score += w_play[2] * blocked_opp_pieces(board, opp);
	// pieces number - número de peças em jogo
	score += w_play[3] * difference_pieces(board, white_turn);
	// number of opened morris - numero de linhas que possuem
	// 2 peças e um espaço vazio, e adjacente ao espaço vazio, uma peça. chance de mill
	score += w_play[4] * (opened_morris(board, me) - opened_morris(board, opp));
	// number of 3 pieces configuration - numero de 2 linhas que possuem
	// conf 2 pieces e é inevitável fazer mill na próxima jogada
	score += w_play[5] * (double_morris(board, me) - double_morris(board, opp));
	// winning configuration - verifica se tabuleiro configura uma vitória
	score += w_play[6] * is_winning_state(board, me);

    // printf("evaluate_playing: score: %d\n", score);
    if(pickBestMove>=0 && pickBestMove<100){
        float random = rand() % (100-pickBestMove);
        float newScore = score*(100-random)/100;
        // printf("random: %d, %d, %d\n", score, newScore, random);
        return newScore;
    }else {
        return score;
    }
}

float Evaluator::evaluate_flying(const Board &board, const bool &white_turn, const bool &mill)
{
	float score = 0;
	SpotStatus me = white_turn ? SS_White : SS_Black;
	SpotStatus opp = white_turn ? SS_Black : SS_White;
	// number of opened morris - numero de linhas que possuem
	// 2 peças e um espaço vazio, chance de mill
	score += w_fly[0] * (number_2pieces(board, me) - number_2pieces(board, opp));
	// number of 3 pieces configuration - numero de 2 linhas que possuem
	// conf 2 pieces e é inevitável fazer mill na próxima jogada
	score += w_fly[1] * (number_3pieces(board, me) - number_3pieces(board, opp));
	// closed morris - se houve mill nessa jogada
	score += w_fly[2] * (mill ? 1 : 0);
	// winning configuration - verifica se tabuleiro configura uma vitória
	score += w_fly[3] * is_winning_state(board, me);
    
    // printf("evaluate_flying: score: %d\n", score);
    if(pickBestMove>=0 && pickBestMove<100){
        float random = rand() % (100-pickBestMove);
        float newScore = score*(100-random)/100;
        // printf("random: %d, %d, %d\n", score, newScore, random);
        return newScore;
    }else {
        return score;
    }
}

int Evaluator::morrises_number(const Board &b, const SpotStatus &ss)
{
	int num_morris = 0;

	for(int i = 0; i < BOARD_SPOT; i++)
	{
		// verifica se forma uma conf 2 na horizontal
		if(is_closed_morris_h(b.spot[i], ss))
			num_morris++;
		// verifica se forma uma conf 2 na vertical
		if(is_closed_morris_v(b.spot[i], ss))
			num_morris++;
	}
	// divide por 3, porque para cada conf 2, as 3 posição participantes recebem +1.
	return num_morris/3;
}

int Evaluator::blocked_opp_pieces(const Board &b, const SpotStatus &ss)
{
	int blocked = 0;
	for(int i = 0; i < BOARD_SPOT; i++)
		if(b.spot[i]->status == ss && is_blocked(b.spot[i]))
			blocked++;
	return blocked;
}

int Evaluator::difference_pieces_positioning(const Board &b, const bool &white_turn)
{
	int my_pieces = 0;
	int opp_pieces = 0;

	SpotStatus my = white_turn ? SS_White : SS_Black;
	SpotStatus opp = white_turn ? SS_Black : SS_White;

	for(int i = 0; i < BOARD_SPOT; i++)
	{
		if(b.spot[i]->status == my)
			my_pieces += ADJACENCY[i];
		else if(b.spot[i]->status == opp)
			opp_pieces += ADJACENCY[i];
	}
	return my_pieces - opp_pieces;
}

int Evaluator::difference_pieces(const Board &b, const bool &white_turn)
{
	int my_pieces = white_turn ? b.num_white_pieces : b.num_black_pieces;
	int opp_pieces = white_turn ? b.num_black_pieces : b.num_white_pieces;

	return my_pieces - opp_pieces;
}

int Evaluator::number_2pieces(const Board &b, const SpotStatus &ss)
{
	int conf_2pieces = 0;
	for(int i = 0; i < BOARD_SPOT; i++)
	{
		// verifica se forma uma conf 2 na horizontal
		if(is_2pieces_h(b.spot[i], ss))
			conf_2pieces++;
		// verifica se forma uma conf 2 na vertical
		if(is_2pieces_v(b.spot[i], ss))
			conf_2pieces++;
	}
	// divide por 3, porque para cada conf 2, as 3 posição participantes recebem +1.
	return conf_2pieces/3;
}

int Evaluator::number_3pieces(const Board &b, const SpotStatus &ss)
{
	// não tem como ter configuração de 3 peças com menos de 4.
	if((ss == SS_White && b.num_white_pieces < 4) || (ss == SS_Black && b.num_black_pieces < 4))
		return 0;

	int conf_3pieces = 0;
	for(int i = 0; i < BOARD_SPOT; i++)
		// se a posição participa de conf 2 peças na vertical e horizontal, logo é conf 3 peças
		if(is_2pieces_h(b.spot[i], ss) && is_2pieces_v(b.spot[i], ss))
			conf_3pieces++;

	return conf_3pieces;
}

int Evaluator::opened_morris(const Board &b, const SpotStatus &ss)
{
	int open = 0;
	for(int i = 0; i < BOARD_SPOT; i++)
	{
		// verifica se forma uma conf 2 na horizontal
		if(is_open_h(b.spot[i], ss))
			open++;
		// verifica se forma uma conf 2 na vertical
		if(is_open_v(b.spot[i], ss))
			open++;
	}
	return open/3;
}

int Evaluator::double_morris(const Board &b, const SpotStatus &ss)
{
	// não tem como ter double morris com menos de 5 peças
	if((ss == SS_White && b.num_white_pieces < 5) || (ss == SS_Black && b.num_black_pieces < 5))
		return 0;

	int doubled = 0;
	for(int i = 0; i < BOARD_SPOT; i++)
	{
		Spot *s = b.spot[i];
		// verifica se peça participa de mill na vertical
		if(is_closed_morris_v(s, ss))
		{
			// verifica se vizinho esquerdo é vazio e participa de um open morris na vertical, ex:
			//	o--o
			//	_--o
			//	o--o
			if(s->lf && s->lf->status == SS_Empty && is_open_v(s->lf, ss))
				doubled++;

			// verifica se vizinho direito é vazio e participa de um open morris na vertical, ex:
			//	o--o
			//	o--_
			//	o--o
			if(s->rt && s->rt->status == SS_Empty && is_open_v(s->rt, ss))
				doubled++;
		}
		// verifica se peça participa de mill na horizontal
		if(is_closed_morris_h(s, ss))
		{
			// verifica se vizinho abaixo é vazio e participa de um open morris na horizontal, ex:
			//	o--o--o
			//	o--_--o
			if(s->dn && s->dn->status == SS_Empty && is_open_h(s->dn, ss))
				doubled++;

			// verifica se vizinho acima é vazio e participa de um open morris na horizontal, ex:
			//	o--_--o
			//	o--o--o
			if(s->up && s->up->status == SS_Empty && is_open_h(s->up, ss))
				doubled++;
		}
	}
	return doubled;
}

bool Evaluator::is_closed_morris(Spot* p1, Spot* p2, Spot* p3, const SpotStatus &ss)
{
	bool closed_morris = false;
	if(p1->status == ss && p2->status == ss && p3->status == ss)
		closed_morris = true;
	return closed_morris;
}

bool Evaluator::is_closed_morris_v(Spot* p, const SpotStatus &ss)
{
	bool closed = false;
	// x
	// o
	// o
	if(p->dn && p->dn->dn && is_closed_morris(p, p->dn, p->dn->dn, ss))
		closed = true;
	// o
	// x
	// o
	else if(p->dn && p->up && is_closed_morris(p->dn, p, p->up, ss))
		closed = true;
	// o
	// o
	// x
	else if(p->up && p->up->up && is_closed_morris(p->up->up, p->up, p, ss))
		closed = true;

	return closed;
}

bool Evaluator::is_closed_morris_h(Spot* p, const SpotStatus &ss)
{
	bool closed = false;
	// x o o
	if(p->rt && p->rt->rt && is_closed_morris(p, p->rt, p->rt->rt, ss))
		closed = true;
	// o x o
	else if(p->lf && p->rt && is_closed_morris(p->lf, p, p->rt, ss))
		closed = true;
	// o o x
	else if(p->lf && p->lf->lf && is_closed_morris(p->lf->lf, p->lf, p, ss))
		closed = true;

	return closed;
}

bool Evaluator::is_blocked(Spot* p)
{
	bool blocked = true;
	if( (p->lf && p->lf->status == SS_Empty) ||
		(p->rt && p->rt->status == SS_Empty) ||
		(p->dn && p->dn->status == SS_Empty) ||
		(p->up && p->up->status == SS_Empty))
		blocked = false;
	return blocked;
}

bool Evaluator::is_2pieces(Spot* p1, Spot* p2, Spot* p3, const SpotStatus &ss)
{
	bool two_pieces = false;
	if( (p1->status == ss && p2->status == ss && p3->status == SS_Empty) ||
		(p1->status == ss && p2->status == SS_Empty && p3->status == ss) ||
		(p1->status == SS_Empty && p2->status == ss && p3->status == ss))
		two_pieces = true;
	return two_pieces;
}

bool Evaluator::is_2pieces_v(Spot* p, const SpotStatus &ss)
{
	bool two_pieces = false;
	// x
	// o
	// o
	if(p->dn && p->dn->dn)
		two_pieces = is_2pieces(p, p->dn, p->dn->dn, ss);
	// o
	// x
	// o
	else if(p->dn && p->up)
		two_pieces = is_2pieces(p->dn, p, p->up, ss);
	// o
	// o
	// x
	else if(p->up && p->up->up)
		two_pieces = is_2pieces(p->up->up, p->up, p, ss);
	return two_pieces;
}

bool Evaluator::is_2pieces_h(Spot* p, const SpotStatus &ss)
{
	bool two_pieces = false;
	// x o o
	if(p->rt && p->rt->rt)
		two_pieces = is_2pieces(p, p->rt, p->rt->rt, ss);
	// o x o
	else if(p->lf && p->rt)
		two_pieces = is_2pieces(p->lf, p, p->rt, ss);
	// o o x
	else if(p->lf && p->lf->lf)
		two_pieces = is_2pieces(p->lf->lf, p->lf, p, ss);
	return two_pieces;
}

int Evaluator::is_winning_state(const Board &b, const SpotStatus &ss)
{
	SpotStatus opp = ss == SS_White ? SS_Black : SS_White;
	bool all_blocked = true;
	for(int i = 0; i < BOARD_SPOT; i++)
	{
		if(b.spot[i]->status == opp && !is_blocked(b.spot[i]))
			all_blocked = false;
	}

	int win = 0;
	//verifica se ganhou por numero de peças ou se bloqueou todo o oponente
	if((ss == SS_White && b.num_black_pieces < 3) || (ss == SS_Black && b.num_white_pieces < 3) || all_blocked)
		win = 1;
	return win;
}

Spot* Evaluator::is_open(Spot* p1, Spot* p2, Spot* p3, const SpotStatus &ss)
{
	if(p1->status == ss && p2->status == ss && p3->status == SS_Empty)
		return p3;
	if (p1->status == ss && p2->status == SS_Empty && p3->status == ss)
		return p2;
	if(p1->status == SS_Empty && p2->status == ss && p3->status == ss)
		return p1;
	return NULL;
}

bool Evaluator::is_open_v(Spot* p, const SpotStatus &ss)
{
	bool open = false;
	// x
	// o
	// o
	if(p->dn && p->dn->dn)
	{
		// se tem conf 2
		Spot* empty = is_open(p, p->dn, p->dn->dn, ss);
		if(empty)
		{
			// verifica se adjacente tem peça para fechar morris
			if(empty->lf && empty->lf->status == ss)
				open = true;
			else if(empty->rt && empty->rt->status == ss)
				open = true;
		}
	}
	// o
	// x
	// o
	else if(p->dn && p->up)
	{
		// se tem conf 2
		Spot* empty = is_open(p->dn, p, p->up, ss);
		if(empty)
		{
			// verifica se adjacente tem peça para fechar morris
			if(empty->lf && empty->lf->status == ss)
				open = true;
			else if(empty->rt && empty->rt->status == ss)
				open = true;
		}
	}
	// o
	// o
	// x
	else if(p->up && p->up->up)
	{
		// se tem conf 2
		Spot* empty = is_open(p->up->up, p->up, p, ss);
		if(empty)
		{
			// verifica se adjacente tem peça para fechar morris
			if(empty->lf && empty->lf->status == ss)
				open = true;
			else if(empty->rt && empty->rt->status == ss)
				open = true;
		}
	}
	return open;
}

bool Evaluator::is_open_h(Spot* p, const SpotStatus &ss)
{
	bool open = false;
	// x o o
	if(p->rt && p->rt->rt)
	{
		// se tem conf 2
		Spot* empty = is_open(p, p->rt, p->rt->rt, ss);
		if(empty)
		{
			// verifica se adjacente tem peça para fechar morris
			if(empty->up && empty->up->status == ss)
				open = true;
			else if(empty->dn && empty->dn->status == ss)
				open = true;
		}
	}
	// o x o
	else if(p->lf && p->rt)
	{
		// se tem conf 2
		Spot* empty = is_open(p->lf, p, p->rt, ss);
		if(empty)
		{
			// verifica se adjacente tem peça para fechar morris
			if(empty->up && empty->up->status == ss)
				open = true;
			else if(empty->dn && empty->dn->status == ss)
				open = true;
		}
	}
	// o o x
	else if(p->lf && p->lf->lf)
	{
		Spot* empty = is_open(p->lf->lf, p->lf, p, ss);
		if(empty)
		{
			// verifica se adjacente tem peça para fechar morris
			if(empty->up && empty->up->status == ss)
				open = true;
			else if(empty->dn && empty->dn->status == ss)
				open = true;
		}
	}
	return open;
}

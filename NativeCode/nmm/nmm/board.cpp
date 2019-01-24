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

#include "board.h"
#include "evaluator.h"


Board::Board(void)
	: num_white_pieces(0), num_black_pieces(0)
{

	for(int i = 0; i < BOARD_SPOT; i++)
		spot[i] = new Spot();

	//board link
	spot[A0]->pos = A0;
	spot[A0]->id = "A0";
	spot[A0]->setDown(spot[A3]);
	spot[A0]->setRight(spot[D0]);
	spot[D0]->pos = D0;
	spot[D0]->id = "D0";
	spot[D0]->setDown(spot[D1]);
	spot[D0]->setRight(spot[G0]);
	spot[G0]->pos = G0;
	spot[G0]->id = "G0";
	spot[G0]->setDown(spot[G3]);
	spot[B1]->pos = B1;
	spot[B1]->id = "B1";
	spot[B1]->setDown(spot[B3]);
	spot[B1]->setRight(spot[D1]);
	spot[D1]->pos = D1;
	spot[D1]->id = "D1";
	spot[D1]->setDown(spot[D2]);
	spot[D1]->setRight(spot[F1]);
	spot[F1]->pos = F1;
	spot[F1]->id = "F1";
	spot[F1]->setDown(spot[F3]);
	spot[C2]->pos = C2;
	spot[C2]->id = "C2";
	spot[C2]->setDown(spot[C3]);
	spot[C2]->setRight(spot[D2]);
	spot[D2]->pos = D2;
	spot[D2]->id = "D2";
	spot[D2]->setRight(spot[E2]);
	spot[E2]->pos = E2;
	spot[E2]->id = "E2";
	spot[E2]->setDown(spot[E3]);
	spot[A3]->pos = A3;
	spot[A3]->id = "A3";
	spot[A3]->setDown(spot[A6]);
	spot[A3]->setRight(spot[B3]);
	spot[B3]->pos = B3;
	spot[B3]->id = "B3";
	spot[B3]->setDown(spot[B5]);
	spot[B3]->setRight(spot[C3]);
	spot[C3]->pos = C3;
	spot[C3]->id = "C3";
	spot[C3]->setDown(spot[C4]);
	spot[E3]->pos = E3;
	spot[E3]->id = "E3";
	spot[E3]->setDown(spot[E4]);
	spot[E3]->setRight(spot[F3]);
	spot[F3]->pos = F3;
	spot[F3]->id = "F3";
	spot[F3]->setDown(spot[F5]);
	spot[F3]->setRight(spot[G3]);
	spot[G3]->pos = G3;
	spot[G3]->id = "G3";
	spot[G3]->setDown(spot[G6]);
	spot[C4]->pos = C4;
	spot[C4]->id = "C4";
	spot[C4]->setRight(spot[D4]);
	spot[D4]->pos = D4;
	spot[D4]->id = "D4";
	spot[D4]->setDown(spot[D5]);
	spot[D4]->setRight(spot[E4]);
	spot[E4]->pos = E4;
	spot[E4]->id = "E4";
	spot[B5]->pos = B5;
	spot[B5]->id = "B5";
	spot[B5]->setRight(spot[D5]);
	spot[D5]->pos = D5;
	spot[D5]->id = "D5";
	spot[D5]->setDown(spot[D6]);
	spot[D5]->setRight(spot[F5]);
	spot[F5]->pos = F5;
	spot[F5]->id = "F5";
	spot[A6]->pos = A6;
	spot[A6]->id = "A6";
	spot[A6]->setRight(spot[D6]);
	spot[D6]->pos = D6;
	spot[D6]->id = "D6";
	spot[D6]->setRight(spot[G6]);
	spot[G6]->pos = G6;
	spot[G6]->id = "G6";
}

Board::~Board(void)
{
	for(int i = 0; i < BOARD_SPOT; i++)
		delete spot[i];
}

std::shared_ptr<Board> Board::copy()
{
	std::shared_ptr<Board> nb (new Board);
	for( int i = 0; i < BOARD_SPOT; i++)
		 this->spot[i]->copy(nb->spot[i]);
	nb->num_black_pieces = this->num_black_pieces;
	nb->num_white_pieces = this->num_white_pieces;
	return nb;
}

bool Board::is_placeable(const int &pos, const bool &white_piece, bool &mill)
{
	mill = false;
	if(pos < 0 || pos >= BOARD_SPOT) return false;

	bool can_place = false;
	// verifica se posição vazia
	if(spot[pos]->status == SS_Empty)
	{
		can_place = true;
		// verifica se colocar peça ali, gera mill
		if(in_mill(pos, white_piece ? SS_White : SS_Black) > 0)
			mill = true;
	}
	return can_place;
}

bool Board::is_movable(const int &pos, const SpotStatus &ss, const NMMAction &action, bool &mill, bool &finish, bool &white_win)
{
	mill = finish = white_win = false;
	if(pos < 0 || pos >= BOARD_SPOT) return false;
	if(spot[pos]->status != ss) return false;

	bool can_move = true;
	Spot* s = spot[pos];
	switch (action)
	{
	case Mv_Up:
		if(s->up == NULL || s->up->status != SS_Empty)
		{
			can_move = false;
		}
		// na movimentação up, só verifica mill horizontal
		else if(in_mill_h(s->up->pos, s->status) > 0)
		{
			mill = true;
			removing_finishes(s->status == SS_Black, finish, white_win);
		}
		break;
	case Mv_Down:
		if(s->dn == NULL || s->dn->status != SS_Empty)
		{
			can_move = false;
		}
		// na movimentação down, só verifica mill horizontal
		else if(in_mill_h(s->dn->pos, s->status) > 0)
		{
			mill = true;
			removing_finishes(s->status == SS_Black, finish, white_win);
		}
		break;
	case Mv_Left:
		if(s->lf == NULL || s->lf->status != SS_Empty)
		{
			can_move = false;
		}
		// na movimentação left, só verifica mill vertical
		else if(in_mill_v(s->lf->pos, s->status) > 0)
		{
			mill = true;
			removing_finishes(s->status == SS_Black, finish, white_win);
		}
		break;
	case Mv_Right:
		if(s->rt == NULL || s->rt->status != SS_Empty)
		{
			can_move = false;
		}
		// na movimentação right, só verifica mill vertical
		else if(in_mill_v(s->rt->pos, s->status) > 0)
		{
			mill = true;
			removing_finishes(s->status == SS_Black, finish, white_win);
		}
		break;
	}
	return can_move;
}

bool Board::is_flyable(const int &from, const int &to, const SpotStatus &ss, bool &mill, bool &finish, bool &white_win)
{
	mill = finish = white_win = false;
	if(from < 0 || from >= BOARD_SPOT || to < 0 || to >= BOARD_SPOT) return false;
	if(spot[from]->status != ss) return false;

	bool can_swap = true;
	if(spot[to]->status != SS_Empty)
	{
		can_swap = false;
	}
	else
	{
		// simulando peça em outra posição
		SpotStatus bk = spot[from]->status;
		spot[from]->status = SS_Empty;
		// verificar se peça naquela posição gera um morris
		if(in_mill(to, bk) > 0)
		{
			mill = true;
			removing_finishes(spot[from]->status == SS_Black, finish, white_win);
		}
		spot[from]->status = bk;
	}
	//finish = finish || is_opp_blocked(spot[from]->status == SS_White ? SS_Black : SS_White);
	return can_swap;
}

bool Board::is_removable(const int &pos, const SpotStatus &ss, bool &finish, bool &white_win, const bool allmill)
{
	finish = white_win = false;
	if(pos < 0 || pos >= BOARD_SPOT) return false;
	if(spot[pos]->status == ss) return false;

	bool can_remove = true;
	// pega a quantidade de peças no tabuleiro, se for 3, mesmo com mill, pode se comer
	int pieces_left = spot[pos]->status == SS_White ? num_white_pieces : num_black_pieces;
	// só não pode remover se peça em mill(e não tem só mill) e mais de 3 peças em campo
	if((!allmill && in_mill(pos, spot[pos]->status) > 0 && pieces_left > 3) || spot[pos]->status == SS_Empty)
	{
		can_remove = false;
	}
	else
	{
		removing_finishes(spot[pos]->status == SS_White, finish, white_win);
	}
	return can_remove;
}

void Board::place_spot(const int &pos, const bool &white_piece)
{
	if(pos < 0 || pos >= BOARD_SPOT)
	{
		printf("grab spot: out of range (%i)\n", pos);
		return;
	}

	if(spot[pos]->status != SS_Empty)
	{
		printf("grab spot: spot is not empty (%s)\n", spot[pos]->id.c_str());
		return;
	}
	if(white_piece)
	{
		spot[pos]->status = SS_White;
		num_white_pieces++;
	}
	else
	{
		spot[pos]->status = SS_Black;
		num_black_pieces++;
	}
}

int Board::move_spot(const int &pos, const NMMAction &action)
{
    int new_pos = 0;
	Spot* s = spot[pos];
	switch (action)
	{
	case Mv_Up:
		if(s->up == NULL || s->up->status != SS_Empty)
		{
			printf("move spot: invalid movement! (%s -> %s)\n", spot[pos]->id.c_str(), gAction2Str[action].c_str());
			return 0;
		}
		else
		{
			s->up->status = s->status;
			s->status = SS_Empty;
			new_pos = s->up->pos;
		}
		break;
	case Mv_Down:
		if(s->dn == NULL || s->dn->status != SS_Empty)
		{
			printf("move spot: invalid movement! (%s -> %s)\n", spot[pos]->id.c_str(), gAction2Str[action].c_str());
			return 0;
		}
		else
		{
			s->dn->status = s->status;
			s->status = SS_Empty;
			new_pos = s->dn->pos;
		}
		break;
	case Mv_Left:
		if(s->lf == NULL || s->lf->status != SS_Empty)
		{
			printf("move spot: invalid movement! (%s -> %s)\n", spot[pos]->id.c_str(), gAction2Str[action].c_str());
			return 0;
		}
		else
		{
			s->lf->status = s->status;
			s->status = SS_Empty;
			new_pos = s->lf->pos;
		}
		break;
	case Mv_Right:
		if(s->rt == NULL || s->rt->status != SS_Empty)
		{
			printf("move spot: invalid movement! (%s -> %s)\n", spot[pos]->id.c_str(), gAction2Str[action].c_str());
			return 0;
		}
		else
		{
			s->rt->status = s->status;
			s->status = SS_Empty;
			new_pos = s->rt->pos;
		}
		break;
	}
	return new_pos;
}

void Board::fly_spot(const int &from, const int &to)
{
	if(from < 0 || from >= BOARD_SPOT || to < 0 || to >= BOARD_SPOT)
	{
		printf("swap spot: out of range (%i, %i)\n", from, to);
		return;
	}

	if(spot[to]->status != SS_Empty)
	{
		printf("swap spot: invalid movement! (%i, %i)\n", from, to);
		return;
	}

	spot[to]->status = spot[from]->status;
	spot[from]->status = SS_Empty;
}

void Board::remove_spot(const int &pos)
{
	if(pos < 0 || pos >= BOARD_SPOT)
	{
		printf("remove spot: out of range (%i)\n", pos);
		exit(1);
	}
	Spot* s = spot[pos];

	if(s->status == SS_White)
		num_white_pieces--;
	else if(s->status == SS_Black)
		num_black_pieces--;
	s->status = SS_Empty;
}

Spot* Board::get_spot(const int &pos)
{
	if(pos < 0 || pos >= BOARD_SPOT)
	{
		printf("get spot: out of range (%i)\n", pos);
		exit(1);
	}
	return spot[pos];
}

int Board::in_mill(const int &pos, const int &sts)
{
	return in_mill_v(pos, sts) + in_mill_h(pos, sts);
}

int Board::in_mill_v(const int &pos, const int &sts)
{
	// se estado verificado é vazio, então não tem mill
	if(sts == SS_Empty)
		return 0;

	Spot* s = spot[pos];
	int in = 0;

	// x
	// o
	// o
	if( s->dn && s->dn->status == sts && s->dn->dn && s->dn->dn->status == sts)
		in++;
	// o
	// x
	// o
	if( s->up && s->up->status == sts && s->dn && s->dn->status == sts)
		in++;

	// o
	// o
	// x
	if( s->up && s->up->status == sts && s->up->up && s->up->up->status == sts)
		in++;
	return in;
}

int Board::in_mill_h(const int &pos, const int &sts)
{
	// se estado verificado é vazio, então não tem mill
	if(sts == SS_Empty)
		return 0;

	Spot* s = spot[pos];
	int in = 0;

	// x - o - o
	if( s->rt && s->rt->status == sts && s->rt->rt && s->rt->rt->status == sts)
		in++;
	// o - x - o
	if( s->lf && s->lf->status == sts && s->rt && s->rt->status == sts)
		in++;
	// o - o - x
	if( s->lf && s->lf->status == sts && s->lf->lf && s->lf->lf->status == sts)
		in++;
	return in;
}

void Board::removing_finishes(const bool &white_removal, bool &finish, bool &white_win)
{
	if(white_removal && num_white_pieces == 3)
	{
		finish = true;
		white_win = false;
	}
	else if(!white_removal && num_black_pieces == 3)
	{
		finish = true;
		white_win = true;
	}
}

bool Board::is_opp_blocked(SpotStatus opp)
{
	bool all_blocked = true;
	for(int i = 0; i < BOARD_SPOT; i++)
	{
		if(spot[i]->status == opp && !is_blocked(spot[i]))
			all_blocked = false;
	}
	return all_blocked;
}

bool Board::is_blocked(Spot* p)
{
	bool blocked = true;
	if( (p->lf && p->lf->status == SS_Empty) ||
		(p->rt && p->rt->status == SS_Empty) ||
		(p->dn && p->dn->status == SS_Empty) ||
		(p->up && p->up->status == SS_Empty))
		blocked = false;
	return blocked;
}

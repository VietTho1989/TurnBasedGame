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


#ifndef BOARD_H
#define BOARD_H

#include <memory>
#include <iostream>
#include <string>
#include "spot.h"

#define BOARD_SPOT 24
#define A0 0
#define D0 1
#define G0 2
#define B1 3
#define D1 4
#define F1 5
#define C2 6
#define D2 7
#define E2 8
#define A3 9
#define B3 10
#define C3 11
#define E3 12
#define F3 13
#define G3 14
#define C4 15
#define D4 16
#define E4 17
#define B5 18
#define D5 19
#define F5 20
#define A6 21
#define D6 22
#define G6 23

/*
*
*	(A0)-------------(D0)---------------(G0)
*	 |                 |                  |
*    |     (B1)------(D1)---------(F1)    |
*    |      |          |            |     |
*    |      |   (C2)--(D2)--(E2)    |     |
*    |      |     |           |     |     |
*   (A3)--(B3)--(C3)        (E3)--(F3)--(G3)
*    |      |     |           |     |     |
*    |      |   (C4)--(D4)--(E4)    |     |
*    |      |          |            |     |
*    |     (B5)------(D5)---------(F5)    |
*    |                 |                  |
*   (A6)-------------(D6)---------------(G6)
*
*/

enum GamePhase
{
	Positioning,
	Playing
};

enum NMMAction
{
	Place,
	Mv_Down,
	Mv_Up,
	Mv_Right,
	Mv_Left,
	Fly
};

static std::string gAction2Str[] = {"Place", "Mv_Down", "Mv_Up", "Mv_Right", "Mv_Left", "Fly" };
static std::string gPos2Id[] = {"A0", "D0", "G0", "B1", "D1", "F1", "C2", "D2", "E2", "A3", "B3", "C3",
								"E3", "F3", "G3", "C4", "D4", "E4", "B5", "D5", "F5", "A6", "D6", "G6"};
static std::string gPos2Coord[] = {"0 0", "0 3", "0 6", "1 1", "1 3", "1 5", "2 2", "2 3", "2 4", "3 0", "3 1", "3 2",
								"3 4", "3 5", "3 6", "4 2", "4 3", "4 4", "5 1", "5 3", "5 5", "6 0", "6 3", "6 6"};

class Board
{
private:
	Spot* spot[BOARD_SPOT];
	int num_white_pieces;
	int num_black_pieces;

public:
	Board();
	~Board();
	std::shared_ptr<Board> copy();

	int get_num_white_pieces() { return num_white_pieces; }
	int get_num_black_pieces() { return num_black_pieces; }

	// verifica se a posição aceita colocar uma peça
	bool is_placeable(const int &pos, const bool &white_piece, bool &mill);
	// verifica se a peça pode mover dada direção e a consequência de se fazer isso.
	bool is_movable(const int &pos, const SpotStatus &ss, const NMMAction &action, bool &mill, bool &finish, bool &white_win);
	// verifica se a peça pode voar até dada direção e a consequência disso.
	bool is_flyable(const int &from, const int &to, const SpotStatus &ss, bool &mill, bool &finish, bool &white_win);
	// verifica se a peça é removível, se allmill ativado, pode-se remover peças em morris
	bool is_removable(const int &pos, const SpotStatus &ss, bool &finish, bool &white_win, const bool allmill = false);

	// coloca uma peça na posição pos
	void place_spot(const int &pos, const bool &white_piece);
	// move a peça para a posição dado a ação, retorna a nova posição
	int move_spot(const int &pos, const NMMAction &action);
	// verifica se pode voar até to
	void fly_spot(const int &from, const int &to);
	// remove a peça da pos
	void remove_spot(const int &pos);
	// retorna a posição pos
	Spot* get_spot(const int &pos);

	// verifica se todas as peças do oponente está  bloqueada
	bool is_opp_blocked(SpotStatus oppsts);

	friend class Evaluator;
	friend std::ostream& operator<<(std::ostream& out, Board *b)
	{
		out << *b;
		return out;
	}

	friend std::ostream& operator<<(std::ostream& out, Board &b)
	{
		out << b.spot[A0] << "----------" << b.spot[D0] << "----------" << b.spot[G0]<< "\n";
		out << "|          |          |\n";
		out << "|   " << b.spot[B1] <<"------" << b.spot[D1] << "------" << b.spot[F1] <<"   |\n";
		out << "|   |      |      |   |\n";
		out << "|   |   " <<  b.spot[C2] << "--" << b.spot[D2] << "--" << b.spot[E2] <<"   |   |\n";
		out << "|   |   |     |   |   |\n";
		out << b.spot[A3] << "---" << b.spot[B3] << "---" << b.spot[C3] <<"     "<<
				b.spot[E3] << "---" << b.spot[F3] << "---" << b.spot[G3] << "\n";
		out << "|   |   |     |   |   |\n";
		out << "|   |   " <<  b.spot[C4] << "--" << b.spot[D4] << "--" << b.spot[E4] <<"   |   |\n";
		out << "|   |      |      |   |\n";
		out << "|   " << b.spot[B5] <<"------" << b.spot[D5] << "------" << b.spot[F5] <<"   |\n";
		out << "|          |          |\n";
		out << b.spot[A6] << "----------"<< b.spot[D6] <<"----------" << b.spot[G6]<< "\n";
		return out;
	}
//B--------- B----------B
//|          |          |
//|   B------B------B   |
//|   |      |      |   |
//|   |   B--B--B   |   |
//|   |   |     |   |   |
//B---B---B     B---B---B
//|   |   |     |   |   |
//|   |   B--B--B   |   |
//|   |      |      |   |
//|   B------D------F   |
//|          |          |
//B----------B----------B

private:
	// retorna em quantos mills a peça pos participa
	inline int in_mill(const int &pos, const int &sts);
	// retorna em quantos mills a peça pos participa na vertical
	inline int in_mill_v(const int &pos, const int &sts);
	// retorna em quantos mills a peça pos participa na horizontal
	inline int in_mill_h(const int &pos, const int &sts);
	// verifica se retirar essa peça, o jogo acaba.
	inline void removing_finishes(const bool &white_removal, bool &finish, bool &white_win);
	// verifica se a peça p está bloqueada
	inline bool is_blocked(Spot* p);
};

#define SmrtBoard std::shared_ptr<Board>

#endif


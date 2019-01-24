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

#ifndef STATE_H
#define STATE_H

#include <stdio.h>
#include <memory>
#include "board.h"


using namespace std;

class State
{
public:
	State(){}
	/*
		Construtor do State
		@param board, guarda o estado do jogo.
		@param piece, a posição inicial da peça jogada.
		@param a, a ação tomada pela peça naquele turno
		@param utility, a utilidade calculada para aquele estado do tablueiro
		@param finish, diz se naquele estado o jogo acabou.
		@param white_win, diz se o branco ganhou, valor atrelado ao finish
		@param mill, diz se formou um mill nesse estado
		@param removed, se houver um mill a posição da peça removida
	*/
	State(shared_ptr<Board> b, int piece, NMMAction a, float utility, bool finish, bool white_win, bool mill = false, int removed = -1)
		: board(b), moved(piece), action(a), mill(mill), terminal(finish), white_win(white_win), removed(removed), utility(utility){
        }

	~State()
	{
		std::get_deleter<SmrtBoard>(board);
	}

	shared_ptr<Board> board;
	int moved;
	int moved_to;
	NMMAction action;
	bool mill;
	bool terminal;
	bool white_win;
	int removed;
	float utility;

	friend std::ostream& operator<<(std::ostream& out, State *n)
	{
		out << *n;
		return out;
	}

	friend std::ostream& operator<<(std::ostream& out, State &n)
	{
		std:: string ended = n.terminal ? "true" : "false";

		char* c = new char[10];
#if WIN32
		itoa(n.removed,c , 10);
#else
		snprintf(c, 10, "%d", n.removed);
#endif
		std:: string mill = n.mill ? " MILL(" + std::string(c) + ")" : "";
		out <<  mill << " piece: " << gPos2Id[n.moved]  << " action: "<< gAction2Str[n.action] << " utility: " << n.utility << " terminal: "
			<< ended;
		return out;
	}

};
#define SmrtState std::shared_ptr<State>

#endif

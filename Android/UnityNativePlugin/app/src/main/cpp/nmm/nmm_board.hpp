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


#ifndef NMM_BOARD_H
#define NMM_BOARD_H

#include <memory>
#include <iostream>
#include <string>
#include "nmm_spot.hpp"

namespace NMM
{
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
        int32_t num_white_pieces;
        int32_t num_black_pieces;
        
    public:
        Board();
        ~Board();
        std::shared_ptr<Board> copy();
        
        int32_t get_num_white_pieces() { return num_white_pieces; }
        int32_t get_num_black_pieces() { return num_black_pieces; }
        
        // verifica se a posição aceita colocar uma peça
        bool is_placeable(const int32_t &pos, const bool &white_piece, bool &mill);
        // verifica se a peça pode mover dada direção e a consequência de se fazer isso.
        bool is_movable(const int32_t &pos, const SpotStatus &ss, const NMMAction &action, bool &mill, bool &finish, bool &white_win);
        // verifica se a peça pode voar até dada direção e a consequência disso.
        bool is_flyable(const int32_t &from, const int32_t &to, const SpotStatus &ss, bool &mill, bool &finish, bool &white_win);
        // verifica se a peça é removível, se allmill ativado, pode-se remover peças em morris
        bool is_removable(const int32_t &pos, const SpotStatus &ss, bool &finish, bool &white_win, const bool allmill = false);
        
        // coloca uma peça na posição pos
        void place_spot(const int32_t &pos, const bool &white_piece);
        // move a peça para a posição dado a ação, retorna a nova posição
        int32_t move_spot(const int32_t &pos, const NMMAction &action);
        // verifica se pode voar até to
        void fly_spot(const int32_t &from, const int32_t &to);
        // remove a peça da pos
        void remove_spot(const int32_t &pos);
        // retorna a posição pos
        Spot* get_spot(const int32_t &pos);
        
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
        
        void print(char* strBoard)
        {
            strBoard[0] = 0;
            // get str spot
            char strA0[10];
            char strD0[10];
            char strG0[10];
            char strB1[10];
            char strD1[10];
            char strF1[10];
            char strC2[10];
            char strD2[10];
            char strE2[10];
            char strA3[10];
            char strB3[10];
            char strC3[10];
            char strE3[10];
            char strF3[10];
            char strG3[10];
            char strC4[10];
            char strD4[10];
            char strE4[10];
            char strB5[10];
            char strD5[10];
            char strF5[10];
            char strA6[10];
            char strD6[10];
            char strG6[10];
            {
                this->spot[A0]->print(strA0);
                this->spot[D0]->print(strD0);
                this->spot[G0]->print(strG0);
                this->spot[B1]->print(strB1);
                this->spot[D1]->print(strD1);
                this->spot[F1]->print(strF1);
                this->spot[C2]->print(strC2);
                this->spot[D2]->print(strD2);
                this->spot[E2]->print(strE2);
                this->spot[A3]->print(strA3);
                this->spot[B3]->print(strB3);
                this->spot[C3]->print(strC3);
                this->spot[E3]->print(strE3);
                this->spot[F3]->print(strF3);
                this->spot[G3]->print(strG3);
                this->spot[C4]->print(strC4);
                this->spot[D4]->print(strD4);
                this->spot[E4]->print(strE4);
                this->spot[B5]->print(strB5);
                this->spot[D5]->print(strD5);
                this->spot[F5]->print(strF5);
                this->spot[A6]->print(strA6);
                this->spot[D6]->print(strD6);
                this->spot[G6]->print(strG6);
            }
            
            sprintf(strBoard, "%s%s----------%s----------%s\n", strBoard, strA0, strD0, strG0);
            sprintf(strBoard, "%s|          |          |\n", strBoard);
            sprintf(strBoard, "%s|   %s------%s------%s   |\n", strBoard, strB1, strD1, strF1);
            sprintf(strBoard, "%s|   |      |      |   |\n", strBoard);
            sprintf(strBoard, "%s|   |   %s--%s--%s   |   |\n", strBoard, strC2, strD2, strE2);
            sprintf(strBoard, "%s|   |   |     |   |   |\n", strBoard);
            sprintf(strBoard, "%s%s---%s---%s     %s---%s---%s\n", strBoard, strA3, strB3, strC3, strE3, strF3, strG3);
            sprintf(strBoard, "%s|   |   |     |   |   |\n", strBoard);
            sprintf(strBoard, "%s|   |   %s--%s--%s   |   |\n", strBoard, strC4, strD4, strE4);
            sprintf(strBoard, "%s|   |      |      |   |\n", strBoard);
            sprintf(strBoard, "%s|   %s------%s------%s   |\n", strBoard, strB5, strD5, strF5);
            sprintf(strBoard, "%s|          |          |\n", strBoard);
            sprintf(strBoard, "%s%s----------%s----------%s\n", strBoard, strA6, strD6, strG6);
        }
        
        void print()
        {
            char strBoard[500];
            print(strBoard);
            printf("%s", strBoard);
        }
        
    private:
        // retorna em quantos mills a peça pos participa
        inline int32_t in_mill(const int32_t &pos, const int32_t &sts);
        // retorna em quantos mills a peça pos participa na vertical
        inline int32_t in_mill_v(const int32_t &pos, const int32_t &sts);
        // retorna em quantos mills a peça pos participa na horizontal
        inline int32_t in_mill_h(const int32_t &pos, const int32_t &sts);
        // verifica se retirar essa peça, o jogo acaba.
        inline void removing_finishes(const bool &white_removal, bool &finish, bool &white_win);
        // verifica se a peça p está bloqueada
        inline bool is_blocked(Spot* p);
        
        /////////////////////////////////////////////////////////////////////////////////////
        //////////////////// Convert ///////////////////
        /////////////////////////////////////////////////////////////////////////////////////
        
    public:
        static int32_t getByteSize();
        
        static int32_t convertToByteArray(Board* board, uint8_t* &byteArray);
        
        static int32_t parseByteArray(Board* board, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect);
        
    };
    
    #define SmrtBoard std::shared_ptr<Board>
}

#endif

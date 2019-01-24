#ifndef MINE_SWEEPER_BOARD_HPP
#define MINE_SWEEPER_BOARD_HPP

#include<iostream>
#include<vector>
#include<string>
#include<cstdlib>
#include<stdio.h>
#include<ctime>
#include <math.h>
using namespace std;

namespace MineSweeper
{
    
#define MAX_DIMENSION 100
    
    typedef std::vector<std::vector<int32_t>> Matrix;
    
    typedef std::vector<std::vector<int8_t>> ByteMatrix;
    
    //typedef std::vector<std::vector<double > > DoubleMatrix;
    
    struct Point {
        /** x la cot doc*/
        int8_t x;
        /** y la cot ngang*/
        int8_t y;
    };
    
    struct Neb {
        vector<Point> interior;
        vector<Point> fringe;
        vector<Point> boundary;
        
        /////////////////////////////////////////////////////////////////////////////////////
        //////////////////// Convert ///////////////////
        /////////////////////////////////////////////////////////////////////////////////////
        
        int32_t getByteSize();
        
        static int32_t convertToByteArray(Neb* neb, uint8_t* &byteArray);
        
        static int32_t parseByteArray(Neb* neb, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect);
        
    };
    
    typedef vector<Neb> NebSet;
    
    
    class Board {
    public:
        int32_t N;
        int32_t M;
        int32_t K;
        
        ByteMatrix bombs;
        bool booom;
        //DoubleMatrix flags;//default is 0, -1 for mine, 1 for unpicked safe, 2 for picked safe
        ByteMatrix flags;
        ByteMatrix board;//-1 for unknown; non-neg for safe
        int32_t minesFound;
        bool init = false;
        NebSet neb;
        
    private:
        
        void nebOf(Point p , Neb &f);
        void initialBombs(int32_t x, int32_t y);
        int32_t bombsNearby(Point &p);
        
    public:
        Board();
        
        Board(int32_t a, int32_t b, int32_t c);//a*b matrix with c bombs
        
        void print();//print the board
        
        void print(char* ret);
        
        void printBomb();//print the arrange of mines
        
        void printFlags();
        
        bool isEOG();//end of game
        
        void pick(int8_t x, int8_t y);//try to select the2
        
        int32_t winOrLoss();//1=win -1=loss 0=in game
        
        NebSet getNeb();//get the neighbour sets
        
        ByteMatrix getBoard();//get the board
        
        /////////////////////////////////////////////////////////////////////////////////////
        //////////////////// Convert ///////////////////
        /////////////////////////////////////////////////////////////////////////////////////
        
        int32_t getByteSize();
        
        static int32_t convertToByteArray(Board* position, uint8_t* &byteArray);
        
        static int32_t parseByteArray(Board* position, uint8_t* bytes, int32_t length, int32_t start, bool canCorrect);
    };
}

#endif

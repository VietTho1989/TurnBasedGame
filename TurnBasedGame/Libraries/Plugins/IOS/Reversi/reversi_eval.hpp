#ifndef __reversi_EVAL_H__
#define __reversi_EVAL_H__

#include <string>
#include "reversi_board.hpp"

namespace Reversi
{
    const int32_t TSPLITS = 4;
    const int32_t IOFFSET = 5;
    const int32_t TURNSPERDIV = 15;
    
    extern std::string bookPath;
    
    class Eval {
    private:
        int32_t **edgeTable;
        int32_t **p24Table;
        int32_t **pE2XTable;
        int32_t **p33TableABCD;
        int32_t **line3Table;
        int32_t **line4Table;
        int32_t **diag8Table;
        int32_t *s44Table;

        int32_t boardToEPV(Board &b, int32_t turn);
        int32_t boardTo24PV(Board &b, int32_t turn);
        int32_t boardToE2XPV(Board &b, int32_t turn);
        int32_t boardTo33PV(Board &b, int32_t turn);
        int32_t boardToLine3PV(Board &b, int32_t turn);
        int32_t boardToLine4PV(Board &b, int32_t turn);
        int32_t boardToDiag8PV(Board &b, int32_t turn);
        int32_t boardTo44SV(Board &b, int32_t s);
        int32_t bitsToPI(int32_t b, int32_t w);
        
        void readTable(std::string fileName, int32_t lines, int32_t **tableArray);
        void readStability44Table();
        
    public:
        Eval();
        ~Eval();

        int32_t heuristic(Board &b, int32_t s);
        int32_t heuristic2(Board &b, int32_t s);
        int32_t end_heuristic(Board &b);
        int32_t stability(Board &b, int32_t s);
    };
}

#endif

#ifndef __COMMS_HANDLER_H__
#define __COMMS_HANDLER_H__

#include "Calculator.h"
#include "TranspositionTable.h"
#include <string>

// This class processes incoming messages.
class CommsHandler
{
public:
    ~CommsHandler();
    bool Process(const std::string&);

public:
    // The standard opening configurations for the game.
    const std::string Standard =
        "x33a3ka3p22/2p37/3P46/p11P31s1s21p21P4/p21P41S2S11p11P3/6p23/7P12/2P4A1KA13X1 0";

    const std::string Dynasty =
        "x33p3a3p23/5k4/p13p3a3s23/p21s11P41P23/3p41p21S11P4/3S2A1P13P3/4K5/3P4A1P13X1 0";

    const std::string Imhotep =
        "x33a3ka3s22//3P42p13/p1P32P2s22p2P4/p2P42S2p42p1P3/3P32p23//2S2A1KA13X1 0";

    Calculator _calculator;
    TT _table;
    Board* _board = nullptr;

    void ClearBoard();
    Board* CreatePosition(const std::vector<std::string>&) const;
    SearchParams* CreateSearchParameters(const std::vector<std::string>&) const;
};

#endif // __COMMS_HANDLER_H__

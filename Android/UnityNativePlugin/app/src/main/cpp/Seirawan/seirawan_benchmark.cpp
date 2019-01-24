/*
  Stockfish, a UCI chess playing engine derived from Glaurung 2.1
  Copyright (C) 2004-2008 Tord Romstad (Glaurung author)
  Copyright (C) 2008-2015 Marco Costalba, Joona Kiiski, Tord Romstad
  Copyright (C) 2015-2018 Marco Costalba, Joona Kiiski, Gary Linscott, Tord Romstad

  Stockfish is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  Stockfish is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

#include <fstream>
#include <iostream>
#include <istream>
#include <vector>

#include "seirawan_position.hpp"

using namespace std;

namespace Seirawan
{
    namespace {
        
        const vector<string> Defaults = {
            "setoption name UCI_Chess960 value false",
            "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR[HEhe] w KGFDCBQkgfdcbq - 0 1",
            "r1bqk2r/ppp2ppp/2n5/3p4/1P1P1P2/2NB1N2/1P3PPP/R2QK1HR[Ehe] b KFDCBQkqgfdcba - 1 1",
            "r1bqerk1/ppp3pp/2np4/4Pp2/1P1P1P2/2NB1N2/1P3PPP/R2QK1HR[Eh] w KFDCBQhgfdcba f6 1 1",
            "r1bqerk1/ppp2ppp/2n5/3p4/1P1P1P2/2NB1N2/1P3PPP/R2QK1HR[Eh] w KQBCDFabcdfgh - 1 11",
            "r2qkb1r/pppb1ppp/2e1p3/3pP3/5P2/2P1PH2/P1P3PP/R1BQKB1R[Eh] w KFDCQkfdq - 1 10",
            "8/1ke5/8/6E1/p7/8/6K1/7H[] w - - 0 1"
        };
        
    } // namespace
    
}

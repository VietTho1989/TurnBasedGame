#include <iostream>
#include <cstdlib>
#include <cstring>
#include <sstream>
#include "reversi_player.hpp"
using namespace std;

namespace Reversi
{
    int32_t main6(int32_t argc, char *argv[]) {
        // Read in side the player is on.
        if (argc < 2)  {
            cerr << "usage: " << argv[0] << " side [startpos]" << endl;
            exit(-1);
        }
        Side side = (!strcmp(argv[1], "black")) ? BLACK : WHITE;
        
        // Initialize player.
        Player *player = new Player(side);
        
        // If an opening position is given:
        if (argc == 4) {
            bitbrd takenBits, blackBits;
            std::stringstream ss;
            ss << std::hex << argv[2];
            ss >> takenBits;
            ss.str("");
            ss.clear();
            ss << std::hex << argv[3];
            ss >> blackBits;
            player->setPosition(takenBits, blackBits);
        }
        
        // Send ready signal
        std::string rstr;
        while (true) {
            cin >> rstr;
            if (rstr.compare("isready") == 0) {
                cout << "ready" << endl;
                cout.flush();
                break;
            }
        }

        int32_t moveX, moveY, msLeft;
        
        // Get opponent's move and time left for player each turn.
        while (cin >> moveX >> moveY >> msLeft) {
            Move *opponentsMove = NULL;
            if (moveX >= 0 && moveY >= 0) {
                opponentsMove = new Move(moveX, moveY);
            }
            
            // Get player's move and output to java wrapper.
            Move *playersMove = player->doMove(opponentsMove, msLeft);
            if (playersMove != NULL) {
                cout << playersMove->x << " " << playersMove->y << " "
                << player->game.count(CBLACK) << " " << player->game.count(CWHITE) << endl;
            } else {
                cout << "-1 -1 " << player->game.count(CBLACK) << " " << player->game.count(CWHITE) << endl;
            }
            cout.flush();
            cerr.flush();
            
            // Delete move objects.
            if (opponentsMove != NULL) delete opponentsMove;
            if (playersMove != NULL) delete playersMove;
        }
        
        return 0;
    }
}

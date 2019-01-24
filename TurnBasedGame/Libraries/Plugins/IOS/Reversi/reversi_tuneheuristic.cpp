#include <fstream>
#include <iostream>
#include <string>
#include <vector>
#include "reversi_player.hpp"
#include "reversi_board.hpp"
#include "reversi_endgame.hpp"
#include "reversi_common.hpp"
#include "reversi_patternbuilder.hpp"

using namespace std;

namespace Reversi
{
    const int32_t PERFT6 = 8200;
    const int32_t sortDepth = 2;
    const int32_t minDepth = 4;
    const int32_t maxDepth = 6;
    const int32_t endgameDepth = 22;
    
    thor_game *savedGames[2*PERFT6];
    vector<string*> positions;
    int32_t wins;
    int32_t losses;
    int32_t draws;
    
    bool readFile();
    void writeFile1();
    void freemem1();
    
    void play(string position, int32_t saveIndex) {
        thor_game *result1 = new thor_game();
        thor_game *result2 = new thor_game();
        
        std::string::size_type sz = 0;
        uint64_t takenBits = std::stoull(position, &sz, 0);
        position = position.substr(sz);
        uint64_t blackBits = std::stoull(position, &sz, 0);
        position = position.substr(sz);
        Board b(takenBits^blackBits, blackBits);

        int32_t movenum = 0;
        for(movenum = 0; movenum < 6; movenum++) {
            result1->moves[movenum] = std::stoi(position, &sz, 0);
            result2->moves[movenum] = std::stoi(position, &sz, 0);
            position = position.substr(sz);
        }
        
        // Run game on one side
        Player black(BLACK);
        Player white(WHITE);
        black.setDepths(sortDepth, minDepth, 10, endgameDepth);
        white.setDepths(sortDepth, minDepth, maxDepth, endgameDepth);
        black.otherHeuristic = true;
        black.game = b;
        white.game = b;
        
        Move *m = NULL;
        bool passed = false;
        while(true) {
            m = black.doMove(m, -1);
            // two passes in a row is end of game
            if (m == NULL) {
                if (passed)
                    break;
                passed = true;
            }
            else {
                result1->moves[movenum] = m->getX() + 8*m->getY();
                movenum++;
                passed = false;
            }
            
            m = white.doMove(m, -1);
            if (m == NULL) {
                if (passed)
                    break;
                passed = true;
            }
            else {
                result1->moves[movenum] = m->getX() + 8*m->getY();
                movenum++;
                passed = false;
            }
        }

        int32_t bf = black.game.count(CBLACK);
        int32_t wf = black.game.count(CWHITE);
        cout << bf << " " << wf << endl;
        if(bf > wf)
            wins++;
        else if (wf > bf)
            losses++;
        else
            draws++;
        result1->final = (bf - wf + 64) / 2;
        savedGames[2*saveIndex] = result1;
        
        // Run game on the other side
        Player black2(BLACK);
        Player white2(WHITE);
        black2.setDepths(sortDepth, minDepth, maxDepth, endgameDepth);
        white2.setDepths(sortDepth, minDepth, 10, endgameDepth);
        white2.otherHeuristic = true;
        black2.game = b;
        white2.game = b;
        
        m = NULL;
        passed = false;
        movenum = 6;
        while(true) {
            m = black2.doMove(m, -1);
            // two passes in a row is end of game
            if (m == NULL) {
                if (passed)
                    break;
                passed = true;
            }
            else {
                result2->moves[movenum] = m->getX() + 8*m->getY();
                movenum++;
                passed = false;
            }
            
            m = white2.doMove(m, -1);
            if (m == NULL) {
                if (passed)
                    break;
                passed = true;
            }
            else {
                result2->moves[movenum] = m->getX() + 8*m->getY();
                movenum++;
                passed = false;
            }
        }
        
        bf = black2.game.count(CBLACK);
        wf = black2.game.count(CWHITE);
        cout << bf << " " << wf << endl;
        if(bf > wf)
            losses++;
        else if (wf > bf)
            wins++;
        else
            draws++;
        result2->final = (bf - wf + 64) / 2;
        savedGames[2*saveIndex+1] = result2;
        cout << "" << wins << "-" << losses << "-" << draws << endl;
    }

    int32_t main2(int32_t argc, char **argv) {
        readFile();
        cout << "Files read" << endl;
        
        wins = 0;
        losses = 0;
        draws = 0;
        cout << "Score from other heuristic POV" << endl;
        
        for(int32_t i = 0; i < PERFT6; i++) {
            string *pos = positions[i];
            play(*pos, i);
        }
        
        cout << "Final result: " << wins << "-" << losses << "-" << draws << endl;
        
        writeFile1();
        freemem1();
        
        return 0;
    }
    
    bool readFile() {
        std::string line;
        std::ifstream cfile("perft6.txt");
        
        if(cfile.is_open()) {
            while(getline(cfile, line)) {
                positions.push_back(new string(line));        
            }
            cfile.close();
        }
        else return false;
        
        return true;
    }
    
    void writeFile1() {
        ofstream out;
        
        out.open("tuneoutput.txt");
        for(int32_t i = 0; i < 2*PERFT6; i++) {
            thor_game *a = savedGames[i];
            out << a->final;
            for(int32_t j = 0; j < 60; j++)
                out << " " << a->moves[j];
            
            out << endl;
        }
    }
    
    void freemem1() {
        while(positions.size() > 0) {
            string *temp = positions[0];
            positions.erase(positions.begin());
            delete temp;
        }
        
        for (int32_t i = 0; i < 2*PERFT6; i++)
            delete savedGames[i];
    }
}

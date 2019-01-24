#include <fstream>
#include <iostream>
#include "reversi_board.hpp"
#include "reversi_common.hpp"
#include "reversi_patternbuilder.hpp"

using namespace std;

namespace Reversi
{
    void checkGames(uint32_t totalSize, thor_game **games) {
        cout << "Checking game validity: " << totalSize << " games." << endl;
        int32_t errors = 0;
        for(uint32_t i = 0; i < totalSize; i++) {
            thor_game *game = games[i];
            
            Board tracker;
            int32_t side = CBLACK;
            
            for(int32_t j = 0; j < 55; j++) {
                if(!tracker.checkMove(game->moves[j], side)) {
                    // If one side must pass it is not indicated in the database?
                    side = side^1;
                    if(!tracker.checkMove(game->moves[j], side)) {
                        errors++;
                        games[i] = NULL;
                        break;
                    }
                }
                tracker.doMove(game->moves[j], side);
                side = side^1;
            }
        }
        cout << errors << " errors." << endl;
    }
    
    void readThorGame(string file, uint32_t &totalSize, thor_game **games) {
        uint32_t prevSize = totalSize;
        
        // Thor games are stored as a binary stream
        std::ifstream is (file, std::ifstream::binary);
        if(is) {
            // 16 byte header for each file, then each game record is 68 bytes
            char *header = new char[16];
            char *buffer = new char[68];
            
            is.read(header, 16);
            
            //cout << "Century: " << (unsigned)(header[0]) << endl;
            //cout << "Year: " << (unsigned)(header[1]) << endl;
            
            // We are only interested in the number of games, which is stored as a
            // longint (4 bytes), starting at header[7] or header[1] as an int array
            totalSize = ((uint32_t *)(header))[1];
            
            cout << "Reading " << totalSize << " games." << endl;
            
            totalSize += prevSize;
            
            for(uint32_t i = prevSize; i < totalSize; i++) {
                is.read(buffer, 68);
                thor_game *temp = new thor_game();
                temp->final = (unsigned char) buffer[6];
                for(int32_t j = 0; j < 60; j++) {
                    int32_t movetoparse = (unsigned char) buffer[8+j];
                    int32_t x = movetoparse % 10;
                    int32_t y = movetoparse / 10;
                    temp->moves[j] = (x-1) + 8*(y-1);
                    if (temp->moves[j] == -9)
                        temp->moves[j] = MOVE_NULL;
                }
                games[i] = temp;
            }
            
            delete[] header;
            delete[] buffer;
        }
    }
}

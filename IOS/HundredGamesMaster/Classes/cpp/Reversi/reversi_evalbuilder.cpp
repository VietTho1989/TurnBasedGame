#include <cstdlib>
#include <fstream>
#include <iostream>
#include "reversi_board.hpp"
#include "reversi_common.hpp"
#include "reversi_endgame.hpp"
#include "reversi_patternbuilder.hpp"
using namespace std;

namespace Reversi
{
#define DIVS 4
#define IOFFSET 10
#define TURNSPERDIV 13
    
    thor_game **games;
    uint32_t totalSize;
    
    pv* pvTable2x4[DIVS][6561];
    pv* edgeTable[DIVS][6561];
    pv* e2xTable[DIVS][59049];
    pv* p33TableTest[DIVS][19683];
    pv* line3Table[DIVS][6561];
    pv* line4Table[DIVS][6561];
    pv* diag8Table[DIVS][6561];
    int32_t used[DIVS][6561];
    int32_t eused[DIVS][6561];
    int32_t exused[DIVS][59049];
    int32_t p33used[DIVS][19683];
    int32_t line3used[DIVS][6561];
    int32_t line4used[DIVS][6561];
    int32_t diag8used[DIVS][6561];
    
    // TODO Eval evaluater;
    
    void readGame(string file, uint32_t n);
    void writeFile();
    void freemem();
    void resetgames();
    void boardToEPV(Board *b, int32_t score, int32_t turn);
    void boardTo24PV(Board *b, int32_t score, int32_t turn);
    void boardToE2XPV(Board *b, int32_t score, int32_t turn);
    void boardTo33PV(Board *b, int32_t score, int32_t turn);
    void boardToLine3PV(Board *b, int32_t score, int32_t turn);
    void boardToLine4PV(Board *b, int32_t score, int32_t turn);
    void boardToDiag8PV(Board *b, int32_t score, int32_t turn);
    int32_t bitsToPI(int32_t b, int32_t w);
    
    /*void replaceEnd() {
     for(uint32_t i = 0; i < totalSize - 4*16400; i++) {
     cerr << "Replacing end: " << i << endl;
     
     thor_game *game = games[i];
     if(game == NULL)
     continue;
     
     Board tracker;
     int32_t side = CBLACK;
     // play opening moves
     for(int32_t j = 0; j < 44; j++) {
     // If one side must pass it is not indicated in the database?
     if(!tracker.checkMove(game->moves[j], side)) {
     side = side^1;
     }
     tracker.doMove(game->moves[j], side);
     side = side^1;
     }
     
     Endgame e;
     if(tracker.countEmpty() > 21) {
     games[i] = NULL;
     continue;
     }
     
     MoveList lm = tracker.getLegalMoves(side);
     if (lm.size == 0) {
     games[i] = NULL;
     continue;
     }
     
     int32_t score = 0;
     e.solveEndgame(tracker, lm, false, side, tracker.countEmpty(), 10000000,
     &evaluater, &score);
     // We want everything from black's POV
     if (side == CWHITE)
     score = -score;
     //if (score < -64 || score > 64) {
     //    cerr << score << endl;
     //    exit(1);
     //}
     game->final = (score + 64) / 2;
     }
     }*/
    
    void searchFeatures() {
        cout << "Searching features." << endl;
        for(uint32_t i = 0; i < totalSize; i++) {
            for(int32_t n = 0; n < DIVS; n++) {
                for(int32_t j = 0; j < 6561; j++) {
                    used[n][j] = 0;
                    eused[n][j] = 0;
                    line3used[n][j] = 0;
                    line4used[n][j] = 0;
                    diag8used[n][j] = 0;
                }
                for(int32_t j = 0; j < 59049; j++) {
                    exused[n][j] = 0;
                }
                for(int32_t j = 0; j < 19683; j++) {
                    p33used[n][j] = 0;
                }
            }
            thor_game *game = games[i];
            if(game == NULL)
                continue;

            int32_t score = 2*game->final - 64;
            Board tracker;
            int32_t side = CBLACK;
            // play opening moves
            for(int32_t j = 0; j < 8; j++) {
                // If one side must pass it is not indicated in the database?
                if(!tracker.checkMove(game->moves[j], side)) {
                    side = side^1;
                }
                tracker.doMove(game->moves[j], side);
                side = side^1;
            }
            
            // starting recording statistics
            for(int32_t j = 8; j < 58; j++) {
                // If one side must pass it is not indicated in the database?
                if(!tracker.checkMove(game->moves[j], side)) {
                    side = side^1;
                }
                tracker.doMove(game->moves[j], side);
                boardTo24PV(&tracker, score, j+4);
                boardToEPV(&tracker, score, j+4);
                boardToE2XPV(&tracker, score, j+4);
                boardTo33PV(&tracker, score, j+4);
                boardToLine3PV(&tracker, score, j+4);
                boardToLine4PV(&tracker, score, j+4);
                boardToDiag8PV(&tracker, score, j+4);
                side = side^1;
            }
        }
    }
    
    /*int32_t main3(int32_t argc, char **argv) {
     totalSize = 0;
     games = new thor_game*[217000];
     for(int32_t n = 0; n < DIVS; n++) {
     for(int32_t i = 0; i < 6561; i++) {
     pvTable2x4[n][i] = new pv();
     }
     for(int32_t i = 0; i < 6561; i++) {
     edgeTable[n][i] = new pv();
     }
     for(int32_t i = 0; i < 59049; i++) {
     e2xTable[n][i] = new pv();
     }
     for(int32_t i = 0; i < 19683; i++) {
     p33TableTest[n][i] = new pv();
     }
     for(int32_t i = 0; i < 6561; i++) {
     line3Table[n][i] = new pv();
     }
     for(int32_t i = 0; i < 6561; i++) {
     line4Table[n][i] = new pv();
     }
     for(int32_t i = 0; i < 6561; i++) {
     diag8Table[n][i] = new pv();
     }
     }
     
     readThorGame("WTH_7708/Logistello_book_1999.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_2013.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_2012.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_2011.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_2010.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_2009.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_2008.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_2007.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_2006.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_2005.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_2004.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_2003.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_2002.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_2001.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_2000.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_1999.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_1998.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_1997.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_1996.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_1995.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_1994.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_1993.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_1992.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_1991.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_1990.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_1989.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_1988.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_1987.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_1986.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_1985.wtb", totalSize, games);
     readThorGame("WTH_7708/WTH_1984.wtb", totalSize, games);
     readGame("WTH_7708/tuneoutput-8-19-15.txt", 16400);
     readGame("WTH_7708/tuneoutput-8-24-15.txt", 16400);
     readGame("WTH_7708/tuneoutput-1-25-16.txt", 16400);
     readGame("WTH_7708/tuneoutput-2-3-16.txt", 16400);
     
     checkGames(totalSize, games);
     replaceEnd();
     searchFeatures();
     
     writeFile();
     
     freemem();
     return 0;
     }*/
    
    void readGame(string file, uint32_t n) {
        cout << "Reading " << n << " games." << endl;
        
        std::ifstream db(file);
        std::string line;
        
        uint32_t prevSize = totalSize;
        totalSize += n;
        
        for(uint32_t i = prevSize; i < totalSize; i++) {
            std::string::size_type sz = 0;
            thor_game *temp = new thor_game();
            getline(db, line);
            
            temp->final = std::stoi(line, &sz, 0);
            line = line.substr(sz);
            
            for(int32_t j = 0; j < 60; j++) {
                temp->moves[j] = std::stoi(line, &sz, 0);
                line = line.substr(sz);
            }
            
            games[i] = temp;
        }
    }
    
    void writeFile() {
        ofstream out;
        out.open("Flippy_Resources/new/p24table.txt");
        for(int32_t n = 0; n < DIVS; n++) {
            for(uint32_t i = 0; i < 6561; i++) {
                pv *a = pvTable2x4[n][i];
                if(a->instances != 0) {
                    double to = ((double)(a->sum))/((double)(a->instances));
                    if(a->instances < 2) to /= 6;
                    else if(a->instances < 3) to /= 3;
                    else if(a->instances < 6) to /= 2;
                    out << to << " " << a->sum << " " << a->instances << endl;
                }
                else
                    out << 0 << " " << a->sum << " " << a->instances << endl;
            }
        }
        out.close();
        
        out.open("Flippy_Resources/new/edgetable.txt");
        for(int32_t n = 0; n < DIVS; n++) {
            for(uint32_t i = 0; i < 6561; i++) {
                pv *a = edgeTable[n][i];
                if(a->instances != 0) {
                    double to = ((double)(a->sum))/((double)(a->instances));
                    if(a->instances < 2) to /= 6;
                    else if(a->instances < 3) to /= 3;
                    else if(a->instances < 6) to /= 2;
                    out << to << " ";
                }
                else out << 0 << " ";
                
                if(i%9 == 8) out << endl;
            }
        }
        out.close();
        
        out.open("Flippy_Resources/new/pE2Xtable.txt");
        for(int32_t n = 0; n < DIVS; n++) {
            for(uint32_t i = 0; i < 59049; i++) {
                pv *a = e2xTable[n][i];
                if(a->instances != 0) {
                    double to = ((double)(a->sum))/((double)(a->instances));
                    if(a->instances < 2) to /= 6;
                    else if(a->instances < 3) to /= 3;
                    else if(a->instances < 6) to /= 2;
                    out << to << " ";
                }
                else out << 0 << " ";
                
                if(i % 9 == 8) out << endl;
            }
        }
        out.close();
        
        out.open("Flippy_Resources/new/p33table.txt");
        for(int32_t n = 0; n < DIVS; n++) {
            for(uint32_t i = 0; i < 19683; i++) {
                pv *a = p33TableTest[n][i];
                if(a->instances != 0) {
                    double to = ((double)(a->sum))/((double)(a->instances));
                    if(a->instances < 2) to /= 6;
                    else if(a->instances < 3) to /= 3;
                    else if(a->instances < 6) to /= 2;
                    out << to << " ";
                }
                else out << 0 << " ";
                
                if(i % 9 == 8) out << endl;
            }
        }
        out.close();
        
        out.open("Flippy_Resources/new/line3table.txt");
        for(int32_t n = 0; n < DIVS; n++) {
            for(uint32_t i = 0; i < 6561; i++) {
                pv *a = line3Table[n][i];
                if(a->instances != 0) {
                    double to = ((double)(a->sum))/((double)(a->instances));
                    if(a->instances < 2) to /= 6;
                    else if(a->instances < 3) to /= 3;
                    else if(a->instances < 6) to /= 2;
                    out << to << " ";
                }
                else out << 0 << " ";
                
                if(i%9 == 8) out << endl;
            }
        }
        out.close();
        
        out.open("Flippy_Resources/new/line4table.txt");
        for(int32_t n = 0; n < DIVS; n++) {
            for(uint32_t i = 0; i < 6561; i++) {
                pv *a = line4Table[n][i];
                if(a->instances != 0) {
                    double to = ((double)(a->sum))/((double)(a->instances));
                    if(a->instances < 2) to /= 6;
                    else if(a->instances < 3) to /= 3;
                    else if(a->instances < 6) to /= 2;
                    out << to << " ";
                }
                else out << 0 << " ";
                
                if(i%9 == 8) out << endl;
            }
        }
        out.close();
        
        out.open("Flippy_Resources/new/diag8table.txt");
        for(int32_t n = 0; n < DIVS; n++) {
            for(uint32_t i = 0; i < 6561; i++) {
                pv *a = diag8Table[n][i];
                if(a->instances != 0) {
                    double to = ((double)(a->sum))/((double)(a->instances));
                    if(a->instances < 2) to /= 6;
                    else if(a->instances < 3) to /= 3;
                    else if(a->instances < 6) to /= 2;
                    out << to << " ";
                }
                else out << 0 << " ";
                
                if(i%9 == 8) out << endl;
            }
        }
        out.close();
    }
    
    void boardToEPV(Board *b, int32_t score, int32_t turn) {
        int32_t index = (turn - IOFFSET) / TURNSPERDIV;
        bitbrd black = b->getBits(CBLACK);
        bitbrd white = b->getBits(CWHITE);
        int32_t r2 = bitsToPI( (int32_t)((black >> 8) & 0xFF), (int)((white >> 8) & 0xFF) );
        int32_t r7 = bitsToPI( (int32_t)((black >> 48) & 0xFF), (int)((white >> 48) & 0xFF) );
        int32_t c2 = bitsToPI(
                          (int32_t)((((black>>1) & 0x0101010101010101ULL) * 0x0102040810204080ULL) >> 56),
                          (int32_t)((((white>>1) & 0x0101010101010101ULL) * 0x0102040810204080ULL) >> 56) );
        int32_t c7 = bitsToPI(
                          (int32_t)((((black<<1) & 0x8080808080808080ULL) * 0x8040201008040201ULL) >> 56),
                          (int32_t)((((white<<1) & 0x8080808080808080ULL) * 0x8040201008040201ULL) >> 56) );
        
        if(!eused[index][r2]) {
            edgeTable[index][r2]->sum += score;
            edgeTable[index][r2]->instances++;
        }
        if(!eused[index][r7]) {
            edgeTable[index][r7]->sum += score;
            edgeTable[index][r7]->instances++;
        }
        if(!eused[index][c2]) {
            edgeTable[index][c2]->sum += score;
            edgeTable[index][c2]->instances++;
        }
        if(!eused[index][c7]) {
            edgeTable[index][c7]->sum += score;
            edgeTable[index][c7]->instances++;
        }
        
        eused[index][r2] = 1;
        eused[index][r7] = 1;
        eused[index][c2] = 1;
        eused[index][c7] = 1;
    }
    
    void boardTo24PV(Board *b, int32_t score, int32_t turn) {
        int32_t index = (turn - IOFFSET) / TURNSPERDIV;
        bitbrd black = b->getBits(CBLACK);
        bitbrd white = b->getBits(CWHITE);
        int32_t ulb = (int32_t) ((black&0xF) + ((black>>4)&0xF0));
        int32_t ulw = (int32_t) ((white&0xF) + ((white>>4)&0xF0));
        int32_t ul = bitsToPI(ulb, ulw);
        
        bitbrd rvb = reflectVertical(black);
        bitbrd rvw = reflectVertical(white);
        int32_t llb = (int32_t) ((rvb&0xF) + ((rvb>>4)&0xF0));
        int32_t llw = (int32_t) ((rvw&0xF) + ((rvw>>4)&0xF0));
        int32_t ll = bitsToPI(llb, llw);
        
        bitbrd rhb = reflectHorizontal(black);
        bitbrd rhw = reflectHorizontal(white);
        int32_t urb = (int32_t) ((rhb&0xF) + ((rhb>>4)&0xF0));
        int32_t urw = (int32_t) ((rhw&0xF) + ((rhw>>4)&0xF0));
        int32_t ur = bitsToPI(urb, urw);
        
        bitbrd rbb = reflectVertical(rhb);
        bitbrd rbw = reflectVertical(rhw);
        int32_t lrb = (int32_t) ((rbb&0xF) + ((rbb>>4)&0xF0));
        int32_t lrw = (int32_t) ((rbw&0xF) + ((rbw>>4)&0xF0));
        int32_t lr = bitsToPI(lrb, lrw);
        
        bitbrd rotb = reflectDiag(black);
        bitbrd rotw = reflectDiag(white);
        int32_t rulb = (int32_t) ((rotb&0xF) + ((rotb>>4)&0xF0));
        int32_t rulw = (int32_t) ((rotw&0xF) + ((rotw>>4)&0xF0));
        int32_t rul = bitsToPI(rulb, rulw);
        
        bitbrd rotvb = reflectVertical(rotb);
        bitbrd rotvw = reflectVertical(rotw);
        int32_t rllb = (int32_t) ((rotvb&0xF) + ((rotvb>>4)&0xF0));
        int32_t rllw = (int32_t) ((rotvw&0xF) + ((rotvw>>4)&0xF0));
        int32_t rll = bitsToPI(rllb, rllw);
        
        bitbrd rothb = reflectHorizontal(rotb);
        bitbrd rothw = reflectHorizontal(rotw);
        int32_t rurb = (int32_t) ((rothb&0xF) + ((rothb>>4)&0xF0));
        int32_t rurw = (int32_t) ((rothw&0xF) + ((rothw>>4)&0xF0));
        int32_t rur = bitsToPI(rurb, rurw);
        
        bitbrd rotbb = reflectVertical(rothb);
        bitbrd rotbw = reflectVertical(rothw);
        int32_t rlrb = (int32_t) ((rotbb&0xF) + ((rotbb>>4)&0xF0));
        int32_t rlrw = (int32_t) ((rotbw&0xF) + ((rotbw>>4)&0xF0));
        int32_t rlr = bitsToPI(rlrb, rlrw);
        
        // TODO record values
        if(!used[index][ul]) {
            pvTable2x4[index][ul]->sum += score;
            pvTable2x4[index][ul]->instances++;
        }
        if(!used[index][ll]) {
            pvTable2x4[index][ll]->sum += score;
            pvTable2x4[index][ll]->instances++;
        }
        if(!used[index][ur]) {
            pvTable2x4[index][ur]->sum += score;
            pvTable2x4[index][ur]->instances++;
        }
        if(!used[index][lr]) {
            pvTable2x4[index][lr]->sum += score;
            pvTable2x4[index][lr]->instances++;
        }
        if(!used[index][rul]) {
            pvTable2x4[index][rul]->sum += score;
            pvTable2x4[index][rul]->instances++;
        }
        if(!used[index][rll]) {
            pvTable2x4[index][rll]->sum += score;
            pvTable2x4[index][rll]->instances++;
        }
        if(!used[index][rur]) {
            pvTable2x4[index][rur]->sum += score;
            pvTable2x4[index][rur]->instances++;
        }
        if(!used[index][rlr]) {
            pvTable2x4[index][rlr]->sum += score;
            pvTable2x4[index][rlr]->instances++;
        }
        
        used[index][ul] = 1;
        used[index][ll] = 1;
        used[index][ur] = 1;
        used[index][lr] = 1;
        used[index][rul] = 1;
        used[index][rll] = 1;
        used[index][rur] = 1;
        used[index][rlr] = 1;
    }
    
    void boardToE2XPV(Board *b, int32_t score, int32_t turn) {
        int32_t index = (turn - IOFFSET) / TURNSPERDIV;
        bitbrd black = b->getBits(CBLACK);
        bitbrd white = b->getBits(CWHITE);
        int32_t r1b = (int32_t) ( (black & 0xFF) +
                         ((black & 0x200) >> 1) + ((black & 0x4000) >> 5) );
        int32_t r1w = (int32_t) ( (white & 0xFF) +
                         ((white & 0x200) >> 1) + ((white & 0x4000) >> 5) );
        int32_t r1 = bitsToPI(r1b, r1w);

        int32_t r8b = (int32_t) ( (black>>56) + ((black & 0x2000000000000) >> 41) +
                         ((black & 0x40000000000000) >> 45) );
        int32_t r8w = (int32_t) ( (white>>56) + ((white & 0x2000000000000) >> 41) +
                         ((white & 0x40000000000000) >> 45) );
        int32_t r8 = bitsToPI(r8b, r8w);

        int32_t c1b = (int32_t) (
                         (((black & 0x0101010101010101ULL) * 0x0102040810204080ULL) >> 56) +
                         ((black & 0x200) >> 1) + ((black & 0x2000000000000) >> 40) );
        int32_t c1w = (int32_t) (
                         (((white & 0x0101010101010101ULL) * 0x0102040810204080ULL) >> 56) +
                         ((white & 0x200) >> 1) + ((white & 0x2000000000000) >> 40) );
        int32_t c1 = bitsToPI(c1b, c1w);

        int32_t c8b = (int32_t) (
                         (((black & 0x8080808080808080ULL) * 0x0002040810204081ULL) >> 56) +
                         ((black & 0x4000) >> 6) + ((black & 0x40000000000000) >> 45) );
        int32_t c8w = (int32_t) (
                         (((white & 0x8080808080808080ULL) * 0x0002040810204081ULL) >> 56) +
                         ((white & 0x4000) >> 6) + ((white & 0x40000000000000) >> 45) );
        int32_t c8 = bitsToPI(c8b, c8w);
        
        
        if(!exused[index][r1]) {
            e2xTable[index][r1]->sum += score;
            e2xTable[index][r1]->instances++;
        }
        if(!exused[index][r8]) {
            e2xTable[index][r8]->sum += score;
            e2xTable[index][r8]->instances++;
        }
        if(!exused[index][c1]) {
            e2xTable[index][c1]->sum += score;
            e2xTable[index][c1]->instances++;
        }
        if(!exused[index][c8]) {
            e2xTable[index][c8]->sum += score;
            e2xTable[index][c8]->instances++;
        }
        
        exused[index][r1] = 1;
        exused[index][r8] = 1;
        exused[index][c1] = 1;
        exused[index][c8] = 1;
    }
    
    void boardTo33PV(Board *b, int32_t score, int32_t turn) {
        int32_t index = (turn - IOFFSET) / TURNSPERDIV;
        bitbrd black = b->getBits(CBLACK);
        bitbrd white = b->getBits(CWHITE);
        int32_t ulb = (int32_t) ((black&7) + ((black>>5)&0x38) + ((black>>10)&0x1C0));
        int32_t ulw = (int32_t) ((white&7) + ((white>>5)&0x38) + ((white>>10)&0x1C0));
        int32_t ul = bitsToPI(ulb, ulw);
        
        bitbrd rvb = reflectVertical(black);
        bitbrd rvw = reflectVertical(white);
        int32_t llb = (int32_t) ((rvb&7) + ((rvb>>5)&0x38) + ((rvb>>10)&0x1C0));
        int32_t llw = (int32_t) ((rvw&7) + ((rvw>>5)&0x38) + ((rvw>>10)&0x1C0));
        int32_t ll = bitsToPI(llb, llw);
        
        bitbrd rhb = reflectHorizontal(black);
        bitbrd rhw = reflectHorizontal(white);
        int32_t urb = (int32_t) ((rhb&7) + ((rhb>>5)&0x38) + ((rhb>>10)&0x1C0));
        int32_t urw = (int32_t) ((rhw&7) + ((rhw>>5)&0x38) + ((rhw>>10)&0x1C0));
        int32_t ur = bitsToPI(urb, urw);
        
        bitbrd rbb = reflectVertical(rhb);
        bitbrd rbw = reflectVertical(rhw);
        int32_t lrb = (int32_t) ((rbb&7) + ((rbb>>5)&0x38) + ((rbb>>10)&0x1C0));
        int32_t lrw = (int32_t) ((rbw&7) + ((rbw>>5)&0x38) + ((rbw>>10)&0x1C0));
        int32_t lr = bitsToPI(lrb, lrw);
        
        if(!p33used[index][ul]) {
            p33TableTest[index][ul]->sum += score;
            p33TableTest[index][ul]->instances++;
        }
        if(!p33used[index][ur]) {
            p33TableTest[index][ur]->sum += score;
            p33TableTest[index][ur]->instances++;
        }
        if(!p33used[index][ll]) {
            p33TableTest[index][ll]->sum += score;
            p33TableTest[index][ll]->instances++;
        }
        if(!p33used[index][lr]) {
            p33TableTest[index][lr]->sum += score;
            p33TableTest[index][lr]->instances++;
        }
        
        p33used[index][ul] = 1;
        p33used[index][ur] = 1;
        p33used[index][ll] = 1;
        p33used[index][lr] = 1;
    }
    
    void boardToLine3PV(Board *b, int32_t score, int32_t turn) {
        int32_t index = (turn - IOFFSET) / TURNSPERDIV;
        bitbrd black = b->getBits(CBLACK);
        bitbrd white = b->getBits(CWHITE);
        int32_t r2 = bitsToPI( (int32_t)((black >> 16) & 0xFF), (int)((white >> 16) & 0xFF) );
        int32_t r7 = bitsToPI( (int32_t)((black >> 40) & 0xFF), (int)((white >> 40) & 0xFF) );
        int32_t c2 = bitsToPI(
                          (int32_t)((((black>>2) & 0x0101010101010101ULL) * 0x0102040810204080ULL) >> 56),
                          (int32_t)((((white>>2) & 0x0101010101010101ULL) * 0x0102040810204080ULL) >> 56) );
        int32_t c7 = bitsToPI(
                          (int32_t)((((black<<2) & 0x8080808080808080ULL) * 0x8040201008040201ULL) >> 56),
                          (int32_t)((((white<<2) & 0x8080808080808080ULL) * 0x8040201008040201ULL) >> 56) );
        
        if(!line3used[index][r2]) {
            line3Table[index][r2]->sum += score;
            line3Table[index][r2]->instances++;
        }
        if(!line3used[index][r7]) {
            line3Table[index][r7]->sum += score;
            line3Table[index][r7]->instances++;
        }
        if(!line3used[index][c2]) {
            line3Table[index][c2]->sum += score;
            line3Table[index][c2]->instances++;
        }
        if(!line3used[index][c7]) {
            line3Table[index][c7]->sum += score;
            line3Table[index][c7]->instances++;
        }
        
        line3used[index][r2] = 1;
        line3used[index][r7] = 1;
        line3used[index][c2] = 1;
        line3used[index][c7] = 1;
    }
    
    void boardToLine4PV(Board *b, int32_t score, int32_t turn) {
        int32_t index = (turn - IOFFSET) / TURNSPERDIV;
        bitbrd black = b->getBits(CBLACK);
        bitbrd white = b->getBits(CWHITE);
        int32_t r2 = bitsToPI( (int32_t)((black >> 24) & 0xFF), (int32_t)((white >> 24) & 0xFF) );
        int32_t r7 = bitsToPI( (int32_t)((black >> 32) & 0xFF), (int32_t)((white >> 32) & 0xFF) );
        int32_t c2 = bitsToPI(
                          (int32_t)((((black>>3) & 0x0101010101010101ULL) * 0x0102040810204080ULL) >> 56),
                          (int32_t)((((white>>3) & 0x0101010101010101ULL) * 0x0102040810204080ULL) >> 56) );
        int32_t c7 = bitsToPI(
                          (int32_t)((((black<<3) & 0x8080808080808080ULL) * 0x8040201008040201ULL) >> 56),
                          (int32_t)((((white<<3) & 0x8080808080808080ULL) * 0x8040201008040201ULL) >> 56) );
        
        if(!line4used[index][r2]) {
            line4Table[index][r2]->sum += score;
            line4Table[index][r2]->instances++;
        }
        if(!line4used[index][r7]) {
            line4Table[index][r7]->sum += score;
            line4Table[index][r7]->instances++;
        }
        if(!line4used[index][c2]) {
            line4Table[index][c2]->sum += score;
            line4Table[index][c2]->instances++;
        }
        if(!line4used[index][c7]) {
            line4Table[index][c7]->sum += score;
            line4Table[index][c7]->instances++;
        }
        
        line4used[index][r2] = 1;
        line4used[index][r7] = 1;
        line4used[index][c2] = 1;
        line4used[index][c7] = 1;
    }
    
    void boardToDiag8PV(Board *b, int32_t score, int32_t turn) {
        int32_t index = (turn - IOFFSET) / TURNSPERDIV;
        bitbrd black = b->getBits(CBLACK);
        bitbrd white = b->getBits(CWHITE);
        int32_t d8 = bitsToPI( (int32_t)(((black & 0x8040201008040201ULL) * 0x0101010101010101ULL) >> 56),
                          (int32_t)(((white & 0x8040201008040201ULL) * 0x0101010101010101ULL) >> 56) );
        int32_t ad8 = bitsToPI( (int32_t)(((black & 0x0102040810204080ULL) * 0x0101010101010101ULL) >> 56),
                           (int32_t)(((white & 0x0102040810204080ULL) * 0x0101010101010101ULL) >> 56) );
        
        if(!diag8used[index][d8]) {
            diag8Table[index][d8]->sum += score;
            diag8Table[index][d8]->instances++;
        }
        if(!diag8used[index][ad8]) {
            diag8Table[index][ad8]->sum += score;
            diag8Table[index][ad8]->instances++;
        }
        
        diag8used[index][d8] = 1;
        diag8used[index][ad8] = 1;
    }

    int32_t bitsToPI(int32_t b, int32_t w) {
        return PIECES_TO_INDEX[b] + 2*PIECES_TO_INDEX[w];
    }
    
    void resetgames() {
        for(uint32_t i = 0; i < totalSize; i++) {
            delete games[i];
        }
        delete[] games;
    }
    
    void freemem() {
        for(uint32_t i = 0; i < totalSize; i++) {
            delete games[i];
        }
        delete[] games;
        for(int32_t n = 0; n < DIVS; n++) {
            for(int32_t i = 0; i < 6561; i++) {
                delete pvTable2x4[n][i];
                delete edgeTable[n][i];
                delete line3Table[n][i];
                delete line4Table[n][i];
                delete diag8Table[n][i];
            }
            for(int32_t i = 0; i < 59049; i++) {
                delete e2xTable[n][i];
            }
            for(int32_t i = 0; i < 19683; i++) {
                delete p33TableTest[n][i];
            }
        }
    }
}

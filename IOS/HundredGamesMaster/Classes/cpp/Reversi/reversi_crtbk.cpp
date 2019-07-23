#include "reversi_board.hpp"
#include "reversi_openings.hpp"
#include "reversi_player.hpp"
#include <fstream>
#include <iostream>
#include <iomanip>
#include <sstream>
#include <vector>
using namespace std;

namespace Reversi
{
    vector<Node *> openings;
    vector<string *> stringForm;
    
    bool readFile1();
    void writeFile2();
    
    // Checks if a position already exists in the book. If so, it returns the move
    // in the book. Otherwise, it returns -1.
    int32_t contains(bitbrd taken, bitbrd black) {
        for(uint32_t i = 0; i < openings.size(); i++) {
            if((openings[i]->taken == taken) && (openings[i]->black == black)) {
                return openings[i]->move;
            }
        }
        return -1;
    }
    
    // Given a board and the best move for that board, adds it to the book
    void add(Board &b, int32_t move) {
        Node *nnn = new Node();
        nnn->move = move;
        nnn->taken = b.getTaken();
        nnn->black = b.getBits(CBLACK);
        
        std::stringstream stream;
        stream << "0x" << std::setfill('0') << std::setw(16) << std::hex << b.getTaken();
        std::string taken( stream.str() );
        std::stringstream stream2;
        stream2 << "0x" << std::setfill('0') << std::setw(16) << std::hex << b.getBits(CBLACK);
        std::string black( stream2.str() );
        
        std::stringstream t;
        t << taken << " " << black << " " << move;
        std::string result (t.str());
        std::string *stored = new string(result);
        stringForm.push_back(stored);
        openings.push_back(nnn);
        cout << result << endl;
    }
    
    // Recursively builds the book, considering all possible positions to a depth
    // and finding the best move
    void next(Player &p, Board &b, int32_t color, int32_t plies) {
        p.game = b;
        Board temp = b.copy();
        
        // Consider transpositions or previous book
        int32_t exists = contains(b.getTaken(), b.getBits(CBLACK));
        if(exists != -1) {
            std::cout << "already exists. traversing." << std::endl;
            temp.doMove(exists, color);
        }
        // Find a best move for the current position
        else {
            Move *m = p.doMove(NULL, -1);
            int32_t nMove = MOVE_NULL;
            if (m != NULL)
                nMove = m->getX() + 8 * m->getY();
            add(b, nMove);
            temp.doMove(nMove, color);
        }
        
        if(plies <= 0) {
            return;
        }
        
        // for all legal replies
        MoveList legalMoves = temp.getLegalMoves(color^1);
        for(uint32_t i = 0; i < legalMoves.size; i++) {
            Board copy = temp.copy();
            copy.doMove(legalMoves.get(i), color^1);
            
            next(p, copy, color, plies-1);
        }
    }

    int32_t main1(int32_t argc, char **argv) {
        // Read existing book, if any
        readFile1();
        
        Player p(BLACK);
        Player p2(WHITE);
        p.setDepths(2, 4, 14, 30);
        p2.setDepths(2, 4, 14, 30);
        Board b;
        // consider black
        next(p, b, CBLACK, 5);
        // consider white
        MoveList lm = b.getLegalMoves(CBLACK);
        for(int32_t i = 0; i < 4; i++) {
            Board copy = b.copy();
            copy.doMove(lm.get(i), CBLACK);
            
            next(p2, copy, CWHITE, 5);
        }
        
        writeFile2();
        return 0;
    }
    
    bool readFile1() {
        std::string line;
        std::ifstream openingbk("newbook.txt");
        
        if(openingbk.is_open()) {
            // Discard the first line, which contains the size
            getline(openingbk, line);
            int32_t i = 0;
            while(getline(openingbk, line)) {
                stringForm.push_back(new std::string(line));
                std::string::size_type sz = 0;
                Node *temp = new Node();
                temp->taken = std::stoull(line, &sz, 0);
                line = line.substr(sz);
                temp->black = std::stoull(line, &sz, 0);
                line = line.substr(sz);
                int32_t m = std::stoi(line, &sz, 0);
                temp->move = m;
                openings.push_back(temp);
                i++;
            }
            openingbk.close();
            for(uint32_t i = 0; i < stringForm.size(); i++) {
                cout << *stringForm[i] << endl;
            }
        }
        else return false;
        
        return true;
    }
    
    void writeFile2() {
        ofstream out;
        out.open("newbook.txt");
        out << stringForm.size() << endl;
        for(uint32_t i = 0; i < stringForm.size(); i++) {
            out << *stringForm[i] << endl;
        }
        out.close();
    }
}

#include "reversi_openings.hpp"
#include <fstream>
#include <iostream>
#include <string>
#include "reversi_eval.hpp"

#include "../Platform.h"

namespace Reversi
{
    Openings::Openings() {
        if (!readFile()){
            printf("error, opening book not found\n");
        }
    }
    
    Openings::~Openings() {
        for(int32_t i = 0; i < bookSize; i++) {
            delete openings[i];
        }
        delete openings;
    }

    int32_t Openings::get(bitbrd taken, bitbrd black) {
        int32_t index = binarySearch(taken, black);
        if(index == -1) {
            return OPENING_NOT_FOUND;
        }
        else return openings[index]->move;
    }

    int32_t Openings::binarySearch(bitbrd taken, bitbrd black) {
        int32_t min = 0;
        int32_t max = bookSize - 1;
        
        while(max >= min) {
            int32_t mid = min + (max - min) / 2;
            bitbrd ttaken = openings[mid]->taken;
            bitbrd tblack = openings[mid]->black;
            if((ttaken == taken) && (tblack == black))
                return mid;
            else if( (ttaken < taken) || ((ttaken == taken) && (tblack < black)) ) {
                min = mid + 1;
            }
            else {
                max = mid - 1;
            }
        }
        
        return -1;
    }
    
    bool Openings::readFile() {
        printf("read file\n");
#ifdef Android
        std::string line;
        assetistream openingbk(assetManager, bookPath+ "/openings.txt");
        if(openingbk.isOpen()) {
            getline(openingbk, line);
            bookSize = std::stoi(line);
            openings = new Node *[bookSize];
            __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "Opening book read. Contains %d  positions.\n", bookSize);
            int32_t i = 0;
            while(getline(openingbk, line)) {
                std::string::size_type sz = 0;
                Node *temp = new Node();
                temp->taken = std::stoull(line, &sz, 0);
                line = line.substr(sz);
                temp->black = std::stoull(line, &sz, 0);
                line = line.substr(sz);
                int32_t move = std::stoi(line, &sz, 0);
                temp->move = move;
                openings[i] = temp;
                i++;
            }
        }
        else {
            __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "Cannot open book\n");
            return false;
        }
        return true;
#else
        std::string line;
        std::ifstream openingbk(bookPath+ "/openings.txt");

        if(openingbk.is_open()) {
            getline(openingbk, line);
            bookSize = std::stoi(line);
            openings = new Node *[bookSize];
            printf("Opening book read. Contains %d  positions.\n", bookSize);
            int32_t i = 0;
            while(getline(openingbk, line)) {
                std::string::size_type sz = 0;
                Node *temp = new Node();
                temp->taken = std::stoull(line, &sz, 0);
                line = line.substr(sz);
                temp->black = std::stoull(line, &sz, 0);
                line = line.substr(sz);
                int32_t move = std::stoi(line, &sz, 0);
                temp->move = move;
                openings[i] = temp;
                i++;
            }
            openingbk.close();
        }
        else return false;

        return true;
#endif
    }
}

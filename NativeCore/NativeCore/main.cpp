//
//  main.cpp
//  NativeCore
//
//  Created by Viet Tho on 6/25/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <iostream>
#include "Platform.h"

#include "chess_main.hpp"
#include "shatranj_main.hpp"
#include "makruk_main.hpp"
#include "seirawan_main.hpp"
#include "fairy_chess_main.hpp"

#include "english_draught_main.hpp"
#include "international_draught_main.hpp"
#include "russian_draught_main.hpp"

#include "reversi_main.hpp"
#include "shogi_main.hpp"
#include "xiangqi_main.hpp"
#include "weiqi_main.hpp"
#include "gomoku_main.hpp"
#include "mine_sweeper_main.hpp"
#include "hex_main.hpp"
#include "solitaire_main.hpp"
#include "khet_main.hpp"
#include "nmm_main.hpp"
#include "chinese_checkers_main.hpp"

int main(int argc, const char * argv[]) {
    // insert code here...
    std::cout << "Hello, World!\n";
    
    srand(now());
    
    char buf[4096];
    while (fgets(buf, 4096, stdin)) {
        printf("buf: %s\n", buf);
        if(strcmp(buf, "q\n")==0){
            break;
        }
        const std::string ResourcePath = "/Users/viettho/Desktop/NewProject/TurnbasedGame/NativeCore/Resources";
        int matchCount = 10;
        // StockFishChess::chess_main(matchCount, ResourcePath);
        // Shatranj::shatranj_main(matchCount, ResourcePath);
        // Makruk::makruk_main(matchCount, ResourcePath);
        // Seirawan::seirawan_main(matchCount, ResourcePath);
        // FairyChess::fairy_chess_main(matchCount, ResourcePath);
        
        // EnglishDraught::english_draught_main(matchCount, ResourcePath);
        // InternationalDraught::international_draught_main(matchCount, ResourcePath);
        // RussianDraught::russian_draught_main(matchCount, ResourcePath);
        
        // weiqi::weiqi_main(matchCount, ResourcePath);
        // gomoku::gomoku_main(matchCount, ResourcePath);
        // Reversi::reversi_main(matchCount, ResourcePath);
        // Shogi::shogi_main(matchCount, ResourcePath);
        // Xiangqi::xiangqi_main(matchCount, ResourcePath);
        // MineSweeper::mine_sweeper_main(matchCount, ResourcePath);
        // Hex::hex_main(matchCount, ResourcePath);
        // Solitaire::solitaire_main(matchCount, ResourcePath);
        // Khet::khet_main(matchCount, ResourcePath);
        // NMM::nmm_main(matchCount, ResourcePath);
        ChineseCheckers::chinese_checkers_main(matchCount, ResourcePath);
    }
    
    return 0;
}

// 140.8
// 140.8
// 141
// 139.4

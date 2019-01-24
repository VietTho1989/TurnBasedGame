/*
  Apery, a USI shogi playing engine derived from Stockfish, a UCI chess playing engine.
  Copyright (C) 2004-2008 Tord Romstad (Glaurung author)
  Copyright (C) 2008-2015 Marco Costalba, Joona Kiiski, Tord Romstad
  Copyright (C) 2015-2016 Marco Costalba, Joona Kiiski, Gary Linscott, Tord Romstad
  Copyright (C) 2011-2017 Hiraoka Takuya

  Apery is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  Apery is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

#include "../../Platform.h"
#include "shogi_book.hpp"
#include "shogi_position.hpp"
#include "shogi_move.hpp"
#include "shogi_usi.hpp"
#include "shogi_thread.hpp"
#include "shogi_search.hpp"
#include "../shogi_jni.hpp"

#include <algorithm>
using namespace std;

namespace Shogi
{
    
    MT64bit Book::mt64bit_; // 定跡のhash生成用なので、seedは固定でデフォルト値を使う。
    Key Book::ZobPiece[PieceNone][SquareNum];
    Key Book::ZobHand[HandPieceNum][19]; // 持ち駒の同一種類の駒の数ごと
    Key Book::ZobTurn;
    
    void Book::init() {
        for (Piece p = Empty; p < PieceNone; ++p) {
            for (Square sq = SQ11; sq < SquareNum; ++sq)
                ZobPiece[p][sq] = mt64bit_.random();
        }
        for (HandPiece hp = HPawn; hp < HandPieceNum; ++hp) {
            for (int32_t num = 0; num < 19; ++num)
                ZobHand[hp][num] = mt64bit_.random();
        }
        ZobTurn = mt64bit_.random();
    }

#ifdef Android
    bool Book::open(const char* fName) {
        // printf("open book: %s\n", fName);
        fileName_ = "";

        if (isOpen()) {
            close();
        }

        openAsset(fName);

        if (!isOpen()) {
            __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "error, open book not success: %s\n", fName);
            return false;
        }

        size_ = tellg() / sizeof(BookEntry);

        if (!good()) {
            __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "Failed to open book file: %s\n", fName);
            // exit(EXIT_FAILURE);
        }

        fileName_ = fName;
        return true;
    }

    void Book::binary_search(const Key key) {
        size_t low = 0;
        size_t high = size_ - 1;
        size_t mid;
        BookEntry entry;

        while (low < high && good()) {
            mid = (low + high) / 2;

            // TODO assert(mid >= low && mid < high);
            if(!(mid >= low && mid < high)){
                printf("error, Book::binary_search: assert(mid >= low && mid < high)\n");
            }

            // std::ios_base::beg はストリームの開始位置を指す。
            // よって、ファイルの開始位置から mid * sizeof(BookEntry) バイト進んだ位置を指す。
            seekg(mid * sizeof(BookEntry), std::ios_base::beg);
            read(reinterpret_cast<char*>(&entry), sizeof(entry));

            if (key <= entry.key)
                high = mid;
            else
                low = mid + 1;
        }

        // TODO assert(low == high);
        if(!(low == high)){
            printf("error, Book::binary_search: assert(low == high)\n");
        }

        seekg(low * sizeof(BookEntry), std::ios_base::beg);
    }

#else
    bool Book::open(const char* fName) {
        // printf("open book: %s\n", fName);
        fileName_ = "";
        
        if (is_open())
            close();
        
        std::ifstream::open(fName, std::ifstream::in | std::ifstream::binary | std::ios::ate);
        
        if (!is_open()) {
            printf("error, open book not success\n");
            return false;
        }
        
        size_ = tellg() / sizeof(BookEntry);
        
        if (!good()) {
            std::cerr << "Failed to open book file " << fName  << std::endl;
            // exit(EXIT_FAILURE);
        }
        
        fileName_ = fName;
        return true;
    }
    
    void Book::binary_search(const Key key) {
        size_t low = 0;
        size_t high = size_ - 1;
        size_t mid;
        BookEntry entry;
        
        while (low < high && good()) {
            mid = (low + high) / 2;
            
            // TODO assert(mid >= low && mid < high);
            if(!(mid >= low && mid < high)){
                printf("error, Book::binary_search: assert(mid >= low && mid < high)\n");
            }
            
            // std::ios_base::beg はストリームの開始位置を指す。
            // よって、ファイルの開始位置から mid * sizeof(BookEntry) バイト進んだ位置を指す。
            seekg(mid * sizeof(BookEntry), std::ios_base::beg);
            read(reinterpret_cast<char*>(&entry), sizeof(entry));
            
            if (key <= entry.key)
                high = mid;
            else
                low = mid + 1;
        }
        
        // TODO assert(low == high);
        if(!(low == high)){
            printf("error, Book::binary_search: assert(low == high)\n");
        }
        
        seekg(low * sizeof(BookEntry), std::ios_base::beg);
    }

#endif

    Key Book::bookKey(const Position& pos) {
        Key key = 0;
        Bitboard bb = pos.occupiedBB();

        while (bb) {
            const Square sq = bb.firstOneFromSQ11();
            key ^= ZobPiece[pos.piece(sq)][sq];
        }
        const Hand hand = pos.hand(pos.turn());
        for (HandPiece hp = HPawn; hp < HandPieceNum; ++hp)
            key ^= ZobHand[hp][hand.numOf(hp)];
        if (pos.turn() == White)
            key ^= ZobTurn;
        return key;
    }

    std::tuple<Move, Score> Book::probe(const Position& pos, const std::string& fName, const bool pickBest) {
        BookEntry entry;
        u16 best = 0;
        u32 sum = 0;
        Move move = Move::moveNone();
        const Key key = bookKey(pos);
        //const Score min_book_score = static_cast<Score>(static_cast<int>(pos.searcher()->options["Min_Book_Score"]));
        const Score min_book_score = (Score)-180;
        // printf("minBookScore: %d\n", min_book_score);
        Score score = ScoreZero;

        if (fileName_ != fName && !open(fName.c_str())){
            printf("book probe none\n");
            return std::make_tuple(Move::moveNone(), ScoreNone);
        }

        binary_search(key);

        // 現在の局面における定跡手の数だけループする。
        while (read(reinterpret_cast<char*>(&entry), sizeof(entry)), entry.key == key && good()) {
            best = max(best, entry.count);
            sum += entry.count;

            // 指された確率に従って手が選択される。
            // count が大きい順に並んでいる必要はない。
            if (min_book_score <= entry.score
                && ((random_.random() % sum < entry.count)
                    || (pickBest && entry.count == best)))
            {
                const Move tmp = Move(entry.fromToPro);
                const Square to = tmp.to();
                if (tmp.isDrop()) {
                    const PieceType ptDropped = tmp.pieceTypeDropped();
                    move = makeDropMove(ptDropped, to);
                }
                else {
                    const Square from = tmp.from();
                    const PieceType ptFrom = pieceToPieceType(pos.piece(from));
                    const bool promo = tmp.isPromotion();
                    if (promo)
                        move = makeCapturePromoteMove(ptFrom, from, to, pos);
                    else
                        move = makeCaptureMove(ptFrom, from, to, pos);
                }
                score = entry.score;
            }
        }
        return std::make_tuple(move, score);
    }

    inline bool countCompare(const BookEntry& b1, const BookEntry& b2) {
        return b1.count < b2.count;
    }
    
}

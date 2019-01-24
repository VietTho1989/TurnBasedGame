//
//  klondike.h
//  klondike
//
//  Created by Viet Tho on 12/1/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#ifndef klondike_h
#define klondike_h

#include <cassert>
#include <iostream>
#include <sstream>
#include <random>
#include <chrono>
#include <algorithm>
#include <queue>
#include <vector>
#include <functional>
#include <unordered_set>
#include <chrono>

namespace std {
    
    template <typename T> constexpr typename std::underlying_type<T>::type enum_value(T val) {
        return static_cast<typename std::underlying_type<T>::type>(val);
    }
    
    template <class T> void reverse(T* cArray, size_t n) {
        T* last = cArray + sizeof(T) * n;
        while((cArray != last) && (cArray != --last)) {
            std::swap(*cArray, *last);
            ++cArray;
        }
    }
}

// #include "astar.h"

enum class Color : bool {
    BLACK = 1,
    RED   = 0
};
    
enum class Suit : uint8_t {
    HEARTS   = 0,
    SPADES   = 1,
    DIAMONDS = 2,
    CLUBS    = 3
};
    
enum class CardValue : uint8_t {
    UNKNOWN = 0,
    ACE = 1,
    TWO = 2,
    THREE = 3,
    FOUR = 4,
    FIVE = 5,
    SIX = 6,
    SEVEN = 7,
    EIGHT = 8,
    NINE = 9,
    TEN = 10,
    JACK = 11,
    QUEEN = 12,
    KING = 13,
    EMPTY = 14
};
    
    class Card {
    private:
        uint8_t rawCard;
        Card(uint8_t raw) : rawCard(raw) {}
    public:
        Card() : rawCard(0) {}
        Card(CardValue value, Suit suit) : rawCard((std::enum_value(value) << 2) | std::enum_value(suit)) {}
        Card(const Card& copy) : rawCard(copy.rawCard) {}
        inline Suit getSuit() const {
            return static_cast<Suit>(rawCard & 0b00000011);
        }
        inline CardValue getValue() const {
            return static_cast<CardValue>(rawCard >> 2);
        }
        inline Color getColor() const {
            return static_cast<Color>((std::enum_value(getSuit()) % 2) == 0);
        }
        Card& operator=(const Card& copy) {
            rawCard = copy.rawCard;
            return *this;
        }
        inline Card operator+(size_t offset) const {
            return Card(rawCard + (offset << 2));
        }
        inline bool isKnown() const { return getValue() != CardValue::UNKNOWN && getValue() != CardValue::EMPTY; }
        static Card UNKNOWN;
        static Card EMPTY;
        inline bool operator==(const Card& other) const {
            return getValue() == other.getValue() && (!isKnown() || getSuit() == other.getSuit());
        }
        inline bool operator!=(const Card& other) const { return !(*this == other); }
    };
    
    Card Card::UNKNOWN;
    Card Card::EMPTY(CardValue::EMPTY, Suit::SPADES);
    
    std::ostream& operator<<(std::ostream& stream, const Card& card) {
        switch(card.getValue()) {
            case CardValue::ACE:
                stream << "A";
                break;
            case CardValue::KING:
                stream << "K";
                break;
            case CardValue::QUEEN:
                stream << "Q";
                break;
            case CardValue::JACK:
                stream << "J";
                break;
            case CardValue::TEN:
                stream << "T";
                break;
            case CardValue::UNKNOWN:
                stream << "[]";
                break;
            case CardValue::EMPTY:
                stream << "--";
                break;
            default:
                stream << static_cast<unsigned>(std::enum_value(card.getValue()));
        }
        if(card.isKnown()) {
            switch(card.getSuit()) {
                case Suit::SPADES:
                    stream << "S";//"\u2664";
                    break;
                case Suit::HEARTS:
                    stream << "H";//"\u2661";
                    break;
                case Suit::DIAMONDS:
                    stream << "D";//"\u2662";
                    break;
                case Suit::CLUBS:
                    stream << "C";//"\u2667";
                    break;
            }
        }
        return stream;
    }
    
    class Deck {
    private:
        std::vector<Card> cards;
        unsigned seed;
    public:
        Deck(unsigned seed) : seed(seed) {
            auto rand = std::default_random_engine(seed);
            for(Suit suit : { Suit::SPADES, Suit::HEARTS, Suit::DIAMONDS, Suit::CLUBS }) {
                for(CardValue value : { CardValue::ACE, CardValue::TWO, CardValue::THREE, CardValue::FOUR, CardValue::FIVE, CardValue::SIX, CardValue::SEVEN, CardValue::EIGHT, CardValue::NINE, CardValue::TEN, CardValue::JACK, CardValue::QUEEN, CardValue::KING }) {
                    cards.emplace_back(value, suit);
                }
            }
            std::shuffle(cards.begin(), cards.end(), rand);
        }
        Deck() : Deck(std::chrono::system_clock::now().time_since_epoch().count()) {}
        inline const Card& operator[](size_t index) const {
            return cards[index];
        }
        typedef std::vector<Card>::const_iterator const_iterator;
        inline const_iterator begin() const {
            return cards.begin();
        }
        inline const_iterator end() const {
            return cards.end();
        }
        inline unsigned getSeed() const {
            return seed;
        }
    };
    
    class CardPile {
    protected:
        uint8_t internalSize;
        uint8_t numHidden;
        Card* pile;
    public:
        CardPile() : internalSize(0), numHidden(0), pile(nullptr) {}
        CardPile(uint_fast8_t numCards, uint_fast8_t numHidden) : internalSize(numCards), numHidden(numHidden), pile(new Card[internalSize]) {
            if(numHidden > internalSize) {
                numHidden = internalSize;
            }
        };
        CardPile(const CardPile& copy) : CardPile(copy.internalSize, copy.numHidden) {
            memcpy(pile, copy.pile, sizeof(Card) * internalSize);
        }
        CardPile(CardPile&& move) : internalSize(move.internalSize), numHidden(move.numHidden), pile(move.pile) {
            move.pile = nullptr;
            move.internalSize = 0;
            move.numHidden = 0;
        }
        virtual ~CardPile() {
            if(pile) {
                delete pile;
            }
        }
        virtual CardPile& operator=(const CardPile& copy) {
            delete pile;
            internalSize = copy.internalSize;
            numHidden = copy.numHidden;
            pile = new Card[internalSize];
            memcpy(pile, copy.pile, sizeof(Card) * internalSize);
            return *this;
        }
        virtual CardPile& operator=(CardPile&& move) {
            delete pile;
            internalSize = move.internalSize;
            numHidden = move.numHidden;
            pile = move.pile;
            move.pile = nullptr;
            move.internalSize = 0;
            move.numHidden = 0;
            return *this;
        }
        virtual bool operator==(const CardPile& other) const {
            if(size() != other.size() || getNumHidden() != other.getNumHidden()) {
                return false;
            }
            for(size_t i=0; i<internalSize; ++i) {
                if(pile[i] != other.pile[i]) {
                    return false;
                }
            }
            return true;
        }
        inline bool operator!=(const CardPile& other) const { return !(*this == other); }
        inline size_t size() const { return internalSize; }
        inline bool empty() const { return size() == 0; }
        inline size_t getNumHidden() const { return numHidden; }
        inline Card operator[](size_t index) const {
            if(index < numHidden) {
                return Card();
            } else if(index >= internalSize) {
                return Card::EMPTY;
            } else {
                return pile[index];
            }
        }
        void set(size_t index, const Card& card) {
            pile[index] = card;
        }
        CardPile addTop(Card newCard) const {
            assert(newCard.isKnown());
            CardPile ret(internalSize + 1, numHidden);
            memcpy(ret.pile, pile, sizeof(Card) * internalSize);
            ret.pile[internalSize] = newCard;
            return ret;
        }
        CardPile addTop(const CardPile& copyFrom, signed numCards = -1) const {
            if(numCards < 0 || (size_t)numCards > copyFrom.size()) {
                numCards = copyFrom.size();
            }
#ifndef NDEBUG
            for(signed i=1; i<=numCards; ++i) {
                assert(copyFrom[copyFrom.size()-i].isKnown());
            }
#endif
            CardPile ret(internalSize + numCards, numHidden);
            memcpy(ret.pile, pile, sizeof(Card) * internalSize);
            if(numCards > 0) {
                memcpy(&ret.pile[internalSize], &copyFrom.pile[copyFrom.size() - numCards], sizeof(Card) * numCards);
            }
            return ret;
        }
        CardPile removeTop(size_t numToRemove = 1) const {
            if(numToRemove > size()) {
                numToRemove = size();
            }
            CardPile ret(internalSize - numToRemove, numHidden);
            memcpy(ret.pile, pile, sizeof(Card) * (internalSize - numToRemove));
            if(ret.numHidden > ret.size()) {
                ret.numHidden = ret.size();
            }
            return ret;
        }
        CardPile flip() const {
            CardPile ret(internalSize, 0);
            memcpy(ret.pile, pile, sizeof(Card) * internalSize);
            std::reverse(ret.pile, internalSize);
            return ret;
        }
        inline Card top() const {
            if(empty()) {
                return Card::EMPTY;
            } else {
                return (*this)[internalSize - 1];
            }
        }
        inline Card revealTop() const {
            return pile[internalSize - 1];
        }
        inline Card revealTop() {
            if(empty()) {
                return Card();
            } else if(numHidden == internalSize) {
                --numHidden;
            }
            return pile[internalSize - 1];
        }
        inline Card bottom() const {
            if(empty()) {
                return Card::EMPTY;
            } else {
                return (*this)[0];
            }
        }
        virtual inline size_t hash() const {
            size_t h = 0;
            for(size_t i=0; i<internalSize; ++i) {
                /* shift left six bits (with looparound) and XOR with the next card: */
                h = ((h >> 6) | (h << (CHAR_BIT * sizeof(h) - 6))) ^ ((std::enum_value(pile[i].getValue()) << 4) | std::enum_value(pile[i].getSuit()));
            }
            return h;
        }
    };
    
    class TableauPile : public CardPile {
    public:
        TableauPile() : CardPile() {}
        TableauPile(uint_fast8_t numCards, uint_fast8_t numHidden) : CardPile(numCards, numHidden) {}
        TableauPile(const CardPile& copy) : CardPile(copy) {}
        TableauPile(CardPile&& move) : CardPile(move) {}
        virtual TableauPile& operator=(const CardPile& copy) {
            return static_cast<TableauPile&>(CardPile::operator=(copy));
        }
        virtual TableauPile& operator=(CardPile&& move) {
            return static_cast<TableauPile&>(CardPile::operator=(move));
        }
        virtual bool operator==(const TableauPile& other) const {
            if(size() != other.size() || getNumHidden() != other.getNumHidden()) {
                return false;
            }
            return empty() || (pile[0].getColor() == other.pile[0].getColor() && pile[0].getValue() == other.pile[0].getValue());
        }
        virtual inline size_t hash() const {
            size_t h = empty() ? 0 : std::enum_value(pile[0].getValue()) << 4 | std::enum_value(pile[0].getSuit());
            h |= size() << 6;
            h ^= getNumHidden();
            return h;
        }
    };
    
    namespace std {
        template <> struct hash<CardPile> {
            size_t operator()(const CardPile& pile) const {
                return pile.hash();
            }
        };
        template <> struct hash<TableauPile> {
            size_t operator()(const TableauPile& pile) const {
                return pile.hash();
            }
        };
    }
    
    enum class MoveType : uint8_t {
        DEAL,
        MOVE_TO_WASTE,
        MAKE_NEW_STOCK,
        WASTE_TO_FOUNDATION,
        WASTE_TO_TABLEAU,
        TABLEAU_TO_FOUNDATION,
        TABLEAU_TO_TABLEAU
    };
    
    typedef union {
        uint8_t foundation;
        uint8_t tableau;
        struct {
            uint8_t source;
            uint8_t numCards;
            uint8_t destination;
        } tableauMove;
    } MoveData;
    
    class Move {
    public:
        MoveType type;
        MoveData data;
        Move(MoveType type, MoveData data) : type(type), data(data) {}
        Move(const Move& copy) : type(copy.type), data(copy.data) {}
        Move() : Move(MoveType::DEAL, {0}) {}
    };
    
    class MoveToWaste : public Move {
    public:
        MoveToWaste() : Move(MoveType::MOVE_TO_WASTE, { 0 }) {}
    };
    
    class MakeNewStock : public Move {
    public:
        MakeNewStock() : Move(MoveType::MAKE_NEW_STOCK, { 0 }) {}
    };
    
    class WasteToFoundation : public Move {
    public:
        WasteToFoundation(uint_fast8_t foundation) : Move(MoveType::WASTE_TO_FOUNDATION, { .foundation = foundation }) {}
        inline operator size_t() const { return data.foundation; }
    };
    
    class WasteToTableau : public Move {
    public:
        WasteToTableau(uint_fast8_t tableau) : Move(MoveType::WASTE_TO_TABLEAU, { .tableau = tableau }) {}
        inline operator size_t() const { return data.tableau; }
    };
    
    class TableauToFoundation : public Move {
    public:
        TableauToFoundation(uint_fast8_t tableau) : Move(MoveType::TABLEAU_TO_FOUNDATION, { .tableau = tableau }) {}
        inline operator size_t() const { return data.tableau; }
    };
    
    class TableauToTableau : public Move {
    public:
        TableauToTableau(uint_fast8_t source, uint_fast8_t numCards, uint_fast8_t destination) : Move(MoveType::TABLEAU_TO_TABLEAU, { .tableauMove = { .source = source, .numCards = numCards, .destination = destination} }) {}
        inline uint_fast8_t getSource() const { return data.tableauMove.source; }
        inline uint_fast8_t getNumCards() const { return data.tableauMove.numCards; }
        inline uint_fast8_t getDestination() const { return data.tableauMove.destination; }
    };
    
    class GameState {
    private:
        CardPile stockPile;
        CardPile waste;
        TableauPile tableaus[7];
        CardPile foundations[4];
        Move lastMove;
    public:
        GameState(const Deck& deck) : stockPile(23, 23), waste(1, 0), lastMove(MoveType::DEAL, { 0 }) {
            size_t deckOffset = 0;
            for(size_t i=0; i<std::extent<decltype(tableaus)>::value; ++i) {
                tableaus[i] = TableauPile(i + 1, i);
                for(size_t j=0; j<=i; ++j) {
                    tableaus[i].set(j, deck[deckOffset++]);
                }
            }
            waste.set(0, deck[deckOffset++]);
            for(size_t i=0; i<stockPile.size(); ++i) {
                stockPile.set(i, deck[deckOffset++]);
            }
        }
        GameState(const GameState& copy) : stockPile(copy.stockPile), waste(copy.waste), lastMove(copy.lastMove) {
            for(size_t i=0; i<std::extent<decltype(tableaus)>::value; ++i) {
                tableaus[i] = copy.tableaus[i];
            }
            for(size_t i=0; i<std::extent<decltype(foundations)>::value; ++i) {
                foundations[i] = copy.foundations[i];
            }
        }
        GameState(const GameState& copy, const MoveToWaste& move) : stockPile(std::move(copy.stockPile.removeTop())), waste(std::move(copy.waste.addTop(copy.stockPile.revealTop()))), lastMove(move) {
            assert(!copy.stockPile.empty());
            assert(stockPile.size() == copy.stockPile.size() - 1);
            assert(waste.size() == copy.waste.size() + 1);
            assert(waste.top() == copy.stockPile.revealTop());
            for(size_t i=0; i<std::extent<decltype(tableaus)>::value; ++i) {
                tableaus[i] = copy.tableaus[i];
            }
            for(size_t i=0; i<std::extent<decltype(foundations)>::value; ++i) {
                foundations[i] = copy.foundations[i];
            }
        }
        GameState(const GameState& copy, const MakeNewStock& move) : stockPile(copy.getWaste().flip().removeTop()), waste(1, 0), lastMove(move) {
            assert(copy.stockPile.empty() && copy.waste.size() > 1);
            waste.set(0, copy.getWaste().bottom());
            for(size_t i=0; i<std::extent<decltype(tableaus)>::value; ++i) {
                tableaus[i] = copy.tableaus[i];
            }
            for(size_t i=0; i<std::extent<decltype(foundations)>::value; ++i) {
                foundations[i] = copy.foundations[i];
            }
        }
        GameState(const GameState& copy, const WasteToFoundation& move) : stockPile(copy.getStockPile()), waste(copy.waste.removeTop()), lastMove(move) {
            assert(!copy.waste.empty());
            assert((copy.foundations[move].empty() && copy.waste.top().getValue() == CardValue::ACE) || (!copy.foundations[move].empty() && copy.waste.top() == copy.foundations[move].top() + 1));
            assert(std::enum_value(copy.waste.top().getSuit()) == move);
            for(size_t i=0; i<std::extent<decltype(tableaus)>::value; ++i) {
                tableaus[i] = copy.tableaus[i];
            }
            for(size_t i=0; i<std::extent<decltype(foundations)>::value; ++i) {
                if(i == move) {
                    foundations[i] = copy.foundations[i].addTop(copy.waste.top());
                } else {
                    foundations[i] = copy.foundations[i];
                }
            }
        }
        GameState(const GameState& copy, const WasteToTableau& move) : stockPile(copy.getStockPile()), waste(copy.waste.removeTop()), lastMove(move) {
            assert(!copy.waste.empty());
            assert((copy.tableaus[move].empty() && copy.waste.top().getValue() == CardValue::KING) || (!copy.tableaus[move].empty() && (copy.waste.top() + 1).getValue() == copy.tableaus[move].top().getValue() && copy.waste.top().getColor() != copy.tableaus[move].top().getColor()));
            for(size_t i=0; i<std::extent<decltype(tableaus)>::value; ++i) {
                if(i == move) {
                    tableaus[i] = copy.tableaus[i].addTop(copy.waste.top());
                } else {
                    tableaus[i] = copy.tableaus[i];
                }
            }
            for(size_t i=0; i<std::extent<decltype(foundations)>::value; ++i) {
                foundations[i] = copy.foundations[i];
            }
        }
        GameState(const GameState& copy, const TableauToFoundation& move) : stockPile(copy.getStockPile()), waste(copy.getWaste()), lastMove(move) {
            assert(!copy.tableaus[move].empty());
            Card cardToMove = copy.tableaus[move].top();
            size_t foundationId = std::enum_value(cardToMove.getSuit());
            assert((copy.foundations[foundationId].empty() && cardToMove.getValue() == CardValue::ACE) || (!copy.foundations[foundationId].empty() && cardToMove == (copy.foundations[foundationId].top() + 1)));
            for(size_t i=0; i<std::extent<decltype(tableaus)>::value; ++i) {
                if(i == move) {
                    tableaus[i] = copy.tableaus[i].removeTop();
                } else {
                    tableaus[i] = copy.tableaus[i];
                }
            }
            /* flip the next card, if there is one: */
            tableaus[move].revealTop();
            for(size_t i=0; i<std::extent<decltype(foundations)>::value; ++i) {
                if(i == foundationId) {
                    foundations[i] = copy.foundations[i].addTop(cardToMove);
                } else {
                    foundations[i] = copy.foundations[i];
                }
            }
        }
        GameState(const GameState& copy, const TableauToTableau& move) : stockPile(copy.getStockPile()), waste(copy.getWaste()), lastMove(move) {
            assert(copy.tableaus[move.getSource()].size() >= move.getNumCards());
            assert(move.getSource() != move.getDestination());
            for(size_t i=0; i<std::extent<decltype(tableaus)>::value; ++i) {
                if(i == move.getSource()) {
                    tableaus[i] = copy.tableaus[i].removeTop(move.getNumCards());
                } else if(i == move.getDestination()) {
                    tableaus[i] = copy.tableaus[i].addTop(copy.tableaus[move.getSource()], move.getNumCards());
                } else {
                    tableaus[i] = copy.tableaus[i];
                }
            }
            /* flip the next card, if there is one: */
            tableaus[move.getSource()].revealTop();
            for(size_t i=0; i<std::extent<decltype(foundations)>::value; ++i) {
                foundations[i] = copy.foundations[i];
            }
        }
        /* TODO: Implement this move constructor when/if needed.
         GameState(GameState&& move) : stockPile(std::move(move.stockPile)), waste(std::move(move.waste)) {
         }
         */
        GameState applyMove(const Move& move) const {
            switch(move.type) {
                case MoveType::DEAL:
                    return GameState(Deck());
                case MoveType::MOVE_TO_WASTE:
                    return GameState(*this, MoveToWaste());
                case MoveType::MAKE_NEW_STOCK:
                    return GameState(*this, MakeNewStock());
                case MoveType::WASTE_TO_FOUNDATION:
                    return GameState(*this, WasteToFoundation(move.data.foundation));
                case MoveType::WASTE_TO_TABLEAU:
                    return GameState(*this, WasteToTableau(move.data.tableau));
                case MoveType::TABLEAU_TO_FOUNDATION:
                    return GameState(*this, TableauToFoundation(move.data.tableau));
                case MoveType::TABLEAU_TO_TABLEAU:
                    return GameState(*this, TableauToTableau(move.data.tableauMove.source, move.data.tableauMove.numCards, move.data.tableauMove.destination));
            }
        }
        inline const CardPile& getStockPile() const { return stockPile; }
        inline const CardPile& getWaste() const { return waste; }
        inline const TableauPile& getTableau(uint_fast8_t index) const { return tableaus[index]; }
        inline const CardPile& getFoundation(uint_fast8_t index) const { return foundations[index]; }
        inline const CardPile& getFoundation(Suit suit) const { return foundations[std::enum_value(suit)]; }
        inline Move getLastMove() const { return lastMove; }
        inline bool isWin() const { return foundations[0].size() == 13 && foundations[1].size() == 13 && foundations[2].size() == 13 && foundations[3].size() == 13; }
        
        std::vector<GameState> successors() const {
            std::vector<GameState> succ;
            if(!stockPile.empty()) {
                /* move one card from the stock pile into the waste */
                succ.emplace_back(*this, MoveToWaste());
            } else if(waste.size() > 1) {
                /* flip the waste back over to the empty stock pile, removing the top card back to the waste */
                succ.emplace_back(*this, MakeNewStock());
            }
            if(!waste.empty()) {
                Card wasteTop = waste.top();
                size_t foundationId = std::enum_value(wasteTop.getSuit());
                if((foundations[foundationId].empty() && wasteTop.getValue() == CardValue::ACE) || (!foundations[foundationId].empty() && wasteTop == foundations[foundationId].top() + 1)) {
                    /* we can move the top of the waste directly to a foundation */
                    succ.emplace_back(*this, WasteToFoundation(foundationId));
                }
                for(size_t tableau=0; tableau < std::extent<decltype(tableaus)>::value; ++tableau) {
                    if((tableaus[tableau].empty() && wasteTop.getValue() == CardValue::KING) || (!tableaus[tableau].empty() && (wasteTop + 1).getValue() == tableaus[tableau].top().getValue() && wasteTop.getColor() != tableaus[tableau].top().getColor())) {
                        succ.emplace_back(*this, WasteToTableau(tableau));
                    }
                }
            }
            for(size_t tableau=0; tableau < std::extent<decltype(tableaus)>::value; ++tableau) {
                if(!tableaus[tableau].empty()) {
                    Card cardToMove = tableaus[tableau].top();
                    size_t foundationId = std::enum_value(cardToMove.getSuit());
                    /* first, see if we can move the top card of this tableau to the top of a foundation: */
                    if((foundations[foundationId].empty() && cardToMove.getValue() == CardValue::ACE) || (!foundations[foundationId].empty() && cardToMove == (foundations[foundationId].top() + 1))) {
                        succ.emplace_back(*this, TableauToFoundation(tableau));
                    }
                    /* next, see if we can move any subset of the cards in this tableau to another tableau: */
                    for(size_t numCards = 1; numCards <= tableaus[tableau].size(); ++numCards) {
                        Card topCard = tableaus[tableau][tableaus[tableau].size() - numCards];
                        if(!topCard.isKnown()) {
                            break; /* we've reached the first unknown (face-down) card */
                        }
                        for(size_t destinationTableau = 0; destinationTableau < std::extent<decltype(tableaus)>::value; ++destinationTableau) {
                            if(destinationTableau == tableau) {
                                continue; /* we can't move cards to the same tableau! */
                            }
                            if((tableaus[destinationTableau].empty() && topCard.getValue() == CardValue::KING) || (!tableaus[destinationTableau].empty() && (topCard + 1).getValue() == tableaus[destinationTableau].top().getValue() && topCard.getColor() != tableaus[destinationTableau].top().getColor())) {
                                succ.emplace_back(*this, TableauToTableau(tableau, numCards, destinationTableau));
                            }
                        }
                    }
                }
            }
            return succ;
        }
        
        bool operator==(const GameState& other) const {
            for(size_t i=0; i<std::extent<decltype(foundations)>::value; ++i) {
                if(foundations[i] != other.foundations[i]) {
                    return false;
                }
            }
            std::unordered_set<TableauPile> myTableau;
            std::unordered_set<TableauPile> otherTableau;
            for(size_t i=0; i<std::extent<decltype(tableaus)>::value; ++i) {
                myTableau.insert(tableaus[i]);
                otherTableau.insert(tableaus[i]);
                /*if(tableaus[i] != other.tableaus[i]) {
                 return false;
                 }*/
            }
            if(myTableau != otherTableau) {
                return false;
            }
            return stockPile == other.stockPile && waste == other.waste;
        }
    };
    
    namespace std {
        template <> struct hash<GameState> {
            size_t operator()(const GameState& state) const {
                size_t h = 0;
                h ^= state.getStockPile().hash();
                h ^= state.getWaste().hash();
                for(size_t i=0; i<4; ++i) {
                    h ^= state.getFoundation(i).hash();
                }
                for(size_t i=0; i<7; ++i) {
                    h ^= state.getTableau(i).hash();
                }
                return h;
            }
        };
    }
    
    std::ostream& operator<<(std::ostream& stream, const GameState& state) {
        stream << (state.getStockPile().empty() ? "--" : "[]") << " " << state.getWaste().top() << "   ";
        for(size_t i=0; i<4; ++i) {
            stream << " " << state.getFoundation(i).top();
        }
        stream << std::endl << std::endl;
        bool allEmpty = false;
        for(size_t row=0; !allEmpty; ++row) {
            std::stringstream ss;
            allEmpty = true;
            for(size_t i=0; i<7; ++i) {
                Card c = state.getTableau(i)[row];
                if(i > 0) {
                    ss << " ";
                }
                if(c == Card::EMPTY) {
                    ss << "  ";
                } else {
                    allEmpty = false;
                    ss << c;
                }
            }
            if(!allEmpty) {
                stream << ss.str() << std::endl;
            }
        }
        
        return stream;
    }
    
    unsigned naiveHeuristic(const GameState& state) {
        unsigned unknownTableauCards = 0;
        unsigned numTableausWithUnknown = 0;
        for(size_t i=0; i<7; ++i) {
            unknownTableauCards += state.getTableau(i).getNumHidden();
            if(state.getTableau(i).getNumHidden()) {
                ++numTableausWithUnknown;
            }
        }
#if 1
        unsigned cardsRemaining = 52 - (state.getFoundation(0).size() + state.getFoundation(1).size() + state.getFoundation(2).size() + state.getFoundation(3).size());
        return cardsRemaining;// + unknownTableauCards + numTableausWithUnknown;
#else
        return unknownTableauCards + state.getStockPile().size() + numTableausWithUnknown + state.getWaste().size();
#endif
    }

#endif /* klondike_h */

//
//  main.cpp
//  KlondikeSolver
//
//  Created by Viet Tho on 12/1/18.
//  Copyright © 2018 Viet Tho. All rights reserved.
//

#include <iostream>

#include <stdio.h>
#include <time.h>
#include <sys/timeb.h>

const char RANKS[] = {"A23456789TJQK"};
const char SUITS[] = {"CDSH"};

enum Piles {
    WASTE = 0,
    TABLEAU1,
    TABLEAU2,
    TABLEAU3,
    TABLEAU4,
    TABLEAU5,
    TABLEAU6,
    TABLEAU7,
    STOCK,
    FOUNDATION1,
    FOUNDATION2,
    FOUNDATION3,
    FOUNDATION4
};

//Key value pair used in HashMap
struct Pair {
    int value, hash;
    char* key;
    Pair* next;
    
    Pair() {
        key = NULL;
        value = -1;
        hash = -1;
        next = NULL;
    }
    Pair(char* key, int value, int hash, Pair* next) {
        this->key = key;
        this->value = value;
        this->next = next;
        this->hash = hash;
    }
};

class HashMap {
private:
    Pair* table;
    int capacity, shift, spacesUsed;
    
    static int equals(char* key1, char* key2) {
        while(*key1 != 0 && *key2 != 0 && *key1++ == *key2++) {}
        return *key1 == 0 && *key2 == 0;
    }
    void resize(int newShift) {
        shift = newShift;
        Pair* old = table;
        Pair* temp = table;
        table = new Pair[1 << shift];
        int oldCap = capacity;
        capacity = (1 << shift) - 1;
        count = 0;
        spacesUsed = 0;
        
        for (int j = 0; j <= oldCap; ++j, ++temp) {
            if (temp->key != NULL) {
                Pair* next = temp;
                while(next != NULL) {
                    addGet(next->key,next->value);
                    next = next->next;
                }
            }
        }
        
        clear(old, oldCap, false);
        delete[] old;
    }
    void clear(Pair* oldTable, int oldCap, bool del) {
        Pair* temp = oldTable + oldCap;
        Pair* next, *tmp;
        
        while(temp >= oldTable) {
            if (temp->key != NULL) {
                tmp = temp->next;
                
                while (tmp != NULL) {
                    if (del) { delete []tmp->key; }
                    next = tmp->next;
                    delete tmp;
                    tmp = next;
                }
                
                if (del) { delete []temp->key; }
                temp->key = NULL;
                temp->next = NULL;
            }
            --temp;
        }
    }
public:
    int count;
    
    HashMap(int shft) {
        count = 0;
        shift = shft;
        spacesUsed = 0;
        capacity = (1 << shift) - 1;
        table = new Pair[capacity + 1];
    }
    ~HashMap() {
        clear(table, capacity, true);
        delete []table;
    }
    
    int size() {
        return count;
    }
    void clear() {
        clear(table, capacity, true);
    }
    Pair* addGet(char* key, int value) {
        int hash = 0x55555555;
        int sft = 0;
        char* temp = key;
        
        while ((*temp) != 0) {
            hash ^= ((*temp) << sft) ^ sft;
            
            if ((++sft) >= shift) {
                sft = 0;
            }
            
            ++temp;
        }
        
        int i = hash & capacity;
        Pair* e = table + i;
        
        while (e != NULL && e->key != NULL) {
            if (e->hash == hash && equals(e->key, key)) {
                delete []key;
                return e;
            }
            e = e->next;
        }
        ++count;
        e = table + i;
        e->next = e->key != NULL ? new Pair(e->key, e->value, e->hash, e->next) : NULL;
        if (e->next == NULL) { ++spacesUsed; }
        e->value = value;
        e->hash = hash;
        e->key = key;
        
        if (spacesUsed > (capacity >> 1) && (count >> 1) > spacesUsed) {
            resize(shift + 1);
        }
        return NULL;
    }
};

//very fast random number generator I created
//randomness tested very well at http://www.cacert.at/random/
class Random {
private:
    int value, mix, twist;
    
    void CalculateNext() {
        int y = value ^ twist - mix ^ value;
        y ^= twist ^ value ^ mix;
        mix ^= twist ^ value;
        value ^= twist - mix;
        twist ^= value ^ y;
        value ^= (twist << 7) ^ (mix >> 16) ^ (y << 8);
    }
public:
    Random() {
        setSeed(101);
    }
    Random(int seed) {
        setSeed(seed);
    }
    
    void setSeed(int seed) {
        mix = 51651237;
        twist = 895213268;
        value = seed;
        
        for (int i = 0; i < 50; ++i) {
            CalculateNext();
        }
        
        seed ^= (seed >> 15);
        value = 0x9417B3AF ^ seed;
        
        for (int i = 0; i < 950; ++i) {
            CalculateNext();
        }
    }
    int next() {
        CalculateNext();
        return(value & 0x7fffffff);
    }
};

struct Card {
    int rank, suit, clr, odd, value, up;
    
    Card() {
        value = -1;
        rank = -1;
        suit = -1;
        up = 1;
        clr = 0;
        odd = 0;
    }
    Card(int hash) {
        value = hash;
        rank = hash % 13;
        suit = hash / 13;
        up = 0;
        clr = suit & 1;
        odd = rank & 1;
    }
    void set(int hash) {
        value = hash;
        rank = hash % 13;
        suit = hash / 13;
        up = 0;
        clr = suit & 1;
        odd = rank & 1;
    }
    void print() const {
        printf("%c%c%c", (up ? '+' : '-'), (rank >= 0 ? RANKS[rank] : 'X'), (suit >= 0 ? SUITS[suit] : 'X'));
        fflush(stdout);
    }
    char Rank() {
        return (rank >= 0 ? RANKS[rank] : 'X');
    }
    char Suit() {
        return (suit >= 0 ? SUITS[suit] : 'X');
    }
};

class Pile {
public:
    Card* cards[24];
    int size, top;//top represents index of bottom most faceup card. ie) if all cards are faceup it would be 0
    Pile() {
        size = 0;
        top = -1;
        
        for (int i = 0; i < 24; ++i) {
            cards[i] = NULL;
        }
    }
    void add(Card* card) {
        cards[size++] = card;
        card->up = 0;
    }
    void flip() {
        Card* temp = cards[size - 1];
        
        if ((temp->up = !temp->up)) {
            top = size - 1;
            return;
        }
        
        top = -1;
    }
    int highValue() {
        return size > 0 ? cards[0]->value : -1;
    }
    bool topIsNotUp() {
        return size > 0 && !cards[size - 1]->up;
    }
    Card* highCard() {
        return top >= 0 ? cards[top] : NULL;
    }
    Card* cardFrom(int card) {
        return cards[size - card];
    }
    int topRank() {
        return size > 0 ? cards[size - 1]->rank : -1;
    }
    int highRank() {
        return top >= 0 ? cards[top]->rank : -1;
    }
    int faceUpCount() {
        return top >= 0 ? size - top : 0;
    }
    void remove(Pile* to) {
        if (to->top < 0) {
            to->top = to->size;
        }
        
        to->cards[to->size++] = cards[--size];
        
        if (top == size) {
            top = -1;
        }
    }
    void remove(Pile* to, int count) {
        if (to->top < 0) {
            to->top = to->size;
        }
        
        for (int i = size - count; i < size; ++i) {
            to->cards[to->size++] = cards[i];
        }
        
        size -= count;
        
        if (top >= size) {
            top = -1;
        }
    }
    //used for the talon
    bool removeTop(Pile* to, int count, bool thru) {
        if (size > count || (size == count && !thru)) {
            int i = size - count;
            
            do {
                --size;
                cards[size]->up = !cards[size]->up;
                to->cards[to->size++] = cards[size];
            } while (size > i);
            
            return false;
        }
        
        count = to->size + size - count;
        
        do {
            --to->size;
            --count;
            to->cards[to->size]->up = !to->cards[to->size]->up;
            cards[size++] = to->cards[to->size];
        } while (count > 0);
        
        return true;
    }
    void clear() {
        size = 0;
        top = -1;
    }
    void print() const {
        for (int i = size - 1; i >= 0; --i) {
            cards[i]->print();
        }
    }
};

struct Move {
    char from, to, cards;
    int val; //right now is used for multiple purposes. might need to name better.
    Move* next, *prev;
    
    Move() {
        from = -1;
        to = -1;
        cards = -1;
        val = 0;
        next = NULL;
        prev = NULL;
    }
    Move(char f, char t, char c, int v) {
        from = f;
        to = t;
        cards = c;
        val = v;
        next = NULL;
        prev = NULL;
    }
    ~Move() {
        next = NULL;
        prev = NULL;
    }
    void print() const {
        printf("[%i %i %i %i]", from, to, cards, val);
        fflush(stdout);
    }
};

//simple linked list
class MoveList {
public:
    Move* first, *last, *extra;
    int size;
    
    MoveList() {
        size = 0;
        first = NULL;
        last = NULL;
        extra = NULL;
    }
    ~MoveList() {
        Move* next, *temp = first;
        
        while (temp != NULL) {
            next = temp->next;
            delete temp;
            temp = next;
        }
        
        trim();
    }
    
    Move* get(int pos) {
        Move* ret = first;
        
        while ((--pos) >= 0) {
            ret = ret->next;
        }
        
        return ret;
    }
    void clear() {
        if (first != NULL) {
            last->next = extra;
            
            if (extra != NULL) {
                extra->prev = last;
            }
            
            extra = first;
        }
        
        size = 0;
        first = NULL;
        last = NULL;
    }
    void trim() {
        Move* next, *temp = extra;
        
        while (temp != NULL) {
            next = temp->next;
            delete temp;
            temp = next;
        }
    }
    void addLast(char fromPile, char toPile, char cardsMoved, int value) {
        ++size;
        Move* temp;
        
        if (extra != NULL) {
            extra->from = fromPile;
            extra->to = toPile;
            extra->cards = cardsMoved;
            extra->val = value;
            temp = extra;
            extra = extra->next;
        } else {
            temp = new Move(fromPile, toPile, cardsMoved, value);
        }
        
        if (last != NULL) {
            last->next = temp;
            temp->prev = last;
            temp->next = NULL;
            last = temp;
            return;
        }
        
        first = temp;
        temp->prev = NULL;
        temp->next = NULL;
        last = first;
        return;
    }
    void addFirst(char fromPile, char toPile, char cardsMoved, int value) {
        ++size;
        Move* temp;
        
        if (extra != NULL) {
            extra->from = fromPile;
            extra->to = toPile;
            extra->cards = cardsMoved;
            extra->val = value;
            temp = extra;
            extra = extra->next;
        } else {
            temp = new Move(fromPile, toPile, cardsMoved, value);
        }
        
        if (first != NULL) {
            temp->next = first;
            temp->prev = NULL;
            first->prev = temp;
            first = temp;
            return;
        }
        
        temp->prev = NULL;
        temp->next = NULL;
        first = temp;
        last = first;
        return;
    }
    void print() const {
        Move* temp = first;
        
        while (temp != NULL) {
            temp->print();
            temp = temp->next;
        }
    }
    void printPretty() {
        Move* tmp = first;
        int ss = 24;
        int ws = 0;
        
        while (tmp != NULL) {
            int val = tmp->val;
            
            while ((--val) >= 0) {
                if (ss == 0) {
                    printf("[NewRound]");
                    ss = ws;
                    ws = 0;
                }
                
                printf("[Draw]");
                --ss;
                ++ws;
            }
            
            int f = tmp->from;
            int t = tmp->to;
            int c = tmp->cards;
            
            if (f == WASTE) {
                --ws;
            }
            
            if (t == f) {
                printf("[Flip Tab%i]", t);
            } else if (t > STOCK) {
                printf("[%s%c ToFnd]", f == WASTE? "Wast" : "Tab", f == WASTE? 'e' : f + 0x30);
            } else if (c == 1) {
                printf("[%s%c To Tab%i]", f == WASTE? "Wast" : (f > STOCK? "Fnd" : "Tab"), f == WASTE? 'e' : (f > STOCK? f - STOCK + 0x31 : f + 0x30), t);
            } else {
                printf("[%s%c To Tab%i With %i]", f == WASTE? "Wast" : (f > STOCK? "Fnd" : "Tab"), f == WASTE? 'e' : (f > STOCK? f - STOCK + 0x31 : f + 0x30), t, c);
            }
            tmp = tmp->next;
        }
    }
    //this function is used to integrate into my java gui so I can visualize solutions
    void printPacked() const {
        Move* tmp = first;
        int f = 0, t;
        int ss = 24;
        int ws = 0;
        int val;
        
        while (tmp != NULL) {
            val = tmp->val;
            
            while ((--val) >= 0) {
                if (ss == 0) {
                    ++f;
                    ss = ws;
                    ws = 0;
                }
                
                --ss;
                ++ws;
            }
            
            if (tmp->from == WASTE) {
                --ws;
            }
            
            f += 1 + tmp->val;
            tmp = tmp->next;
        }
        
        printf("%c%c", f / 24 + 0x30, f % 24 + 0x30);
        fflush(stdout);
        tmp = first;
        ss = 24;
        ws = 0;
        
        while (tmp != NULL) {
            val = tmp->val;
            
            while ((--val) >= 0) {
                if (ss == 0) {
                    printf("%c%c%c", 0x31, 0x30, ws + 0x30);
                    fflush(stdout);
                    ss = ws;
                    ws = 0;
                }
                
                printf("%c%c%c", 0x30, 0x31, 0x31);
                fflush(stdout);
                --ss;
                ++ws;
            }
            
            f = tmp->from;
            
            if (f == WASTE) {
                --ws;
            }
            
            t = tmp->to;
            f = (f <= TABLEAU7 && f >= TABLEAU1) ? f + 1 : (f == STOCK ? WASTE : (f == WASTE ? TABLEAU1 : f));
            t = (t <= TABLEAU7 && t >= TABLEAU1) ? t + 1 : (t == STOCK ? WASTE : (t == WASTE ? TABLEAU1 : t));
            printf("%c%c%c", f + 0x30, t + 0x30, tmp->cards + 0x30);
            fflush(stdout);
            tmp = tmp->next;
        }
    }
};

enum MoveMasks {
    MOVE_USED = 0x10000000,
    MOVE_REQ = 0x20000000,
    MOVE_LAST = 0x40000000,
    MOVE_VALUE = 0x00ffffff
};

class MoveArray {
private:
    Move* store, *first, *last;
    MoveArray* lists;
    int capacity, open;
    
    MoveArray() {
        size = 0;
        open = 0;
        top = 0;
        capacity = 0;
        first = NULL;
        last = NULL;
        store = NULL;
        lists = NULL;
    }
    
    //used in sorting
    void addExisting(Move* move) {
        ++size;
        
        if (last != NULL) {
            last->next = move;
            move->next = NULL;
            last = move;
            return;
        }
        
        first = move;
        move->next = NULL;
        last = first;
        return;
    }
public:
    int size, top;
    
    MoveArray(int length) {
        size = 0;
        open = 0;
        top = 0;
        capacity = length;
        first = NULL;
        last = NULL;
        lists = new MoveArray[65536];
        store = NULL;
        resize(capacity);
    }
    ~MoveArray() {
        delete []store;
    }
    
    void clear() {
        size = 0;
        top = 0;
        open = 0;
        first = NULL;
        last = NULL;
    }
    Move* get(int pos) {
        return store + pos;
    }
    //radix sort implementation
    void sort(bool descending) {
        if (size < 2) {
            return;
        }
        
        int desc = descending ? 0 : 65535;
        
        for (MoveArray* ma = lists + 65535; ma >= lists; --ma) {
            ma->clear();
        }
        
        Move* temp, *next;
        
        for (int i = 0; i < 32; i += 16) {
            temp = first;
            
            while (temp != NULL) {
                int bucket = ((temp->val >> i) & 65535) - desc;
                
                if (bucket < 0) {
                    bucket = -bucket;
                }
                
                next = temp->next;
                lists[bucket].addExisting(temp);
                temp = next;
            }
            
            first = NULL;
            last = NULL;
            size = 0;
            
            for (MoveArray* ma = lists + 65535; ma >= lists; --ma) {
                if (ma->size > 0) {
                    temp = ma->first;
                    
                    while (temp != NULL) {
                        next = temp->next;
                        addExisting(temp);
                        temp = next;
                    }
                    
                    ma->first = NULL;
                    ma->last = NULL;
                }
            }
        }
    }
    //Remove any moves not needed. Reopen top level moves.
    void prune() {
        Move* prev, *temp;
        temp = first;
        
        while (temp != NULL) {
            if ((temp->val & MOVE_USED) == 0) {
                temp->val &= MOVE_VALUE;
                temp->val |= MOVE_REQ;
                prev = temp->prev;
                
                while (prev != NULL && (prev->val & MOVE_REQ) == 0) {
                    prev->val |= MOVE_REQ;
                    prev = prev->prev;
                }
                
                ++top;
            }
            
            temp = temp->next;
        }
        
        temp = first;
        prev = NULL;
        
        while (temp != NULL) {
            if ((temp->val & MOVE_REQ) == 0) {
                if (temp == first) {
                    if (first - store < open) {
                        open = (int)(first - store);
                    }
                    
                    first = temp->next;
                    temp->next = NULL;
                    temp->prev = NULL;
                    temp = first;
                    
                    if (temp == NULL) {
                        last = NULL;
                    }
                } else {
                    if (temp - store < open) {
                        open = (int)(temp - store);
                    }
                    
                    last = temp->next;
                    temp->next = NULL;
                    temp->prev = NULL;
                    temp = last;
                    prev->next = temp;
                }
                
                --size;
            } else {
                prev = temp;
                temp->val &= ~MOVE_REQ;
                temp = temp->next;
            }
        }
        
        last = prev;
        sort(false);
    }
    //resize array if we ran out of room
    void resize(int length) {
        capacity = length;
        Move* newStack = new Move[capacity];
        
        if (store != NULL) {
            Move* temp = newStack;
            Move* itr = store;
            int amt = size;
            
            while (amt > 0) {
                temp->from = itr->from;
                temp->to = itr->to;
                temp->cards = itr->cards;
                temp->val = itr->val;
                temp->next = itr->next != NULL ? newStack + (itr->next - store) : NULL;
                temp->prev = itr->prev != NULL ? newStack + (itr->prev - store) : NULL;
                ++temp;
                ++itr;
                --amt;
            }
            
            if (size > 0) {
                first = newStack + (first - store);
                last = newStack + (last - store);
            }
            
            delete []store;
        }
        
        store = newStack;
    }
    int moveFirstToLast() {
        if (last != first) {
            last->next = first;
            first = first->next;
            last = last->next;
            last->next = NULL;
        }
        
        last->val |= MOVE_LAST;
        --top;
        return (int)(last - store);
    }
    void setUsed(int pos) {
        store[pos].val |= MOVE_USED;
    }
    //add move to list and sort first few moves ascending
    int add(char fromPile, char toPile, char cardsMoved, int val, int pos = -1) {
        if (size + 1 > capacity) {
            resize(capacity * 1.5);
        }
        
        ++top;
        ++size;
        Move* temp = store + (open++);
        
        //fill in gaps
        Move* chk = temp + 1;
        while (chk->next != NULL || last == chk) {
            ++open; ++chk;
        }
        
        temp->from = fromPile;
        temp->to = toPile;
        temp->cards = cardsMoved;
        temp->val = val;
        temp->prev = pos < 0 ? NULL : store + pos;
        
        if (first != NULL) {
            temp->next = first;
            first = temp;
            
            return size - 1;
        }
        
        temp->next = NULL;
        first = temp;
        last = first;
        return size - 1;
    }
};

class Solitaire {
private:
    int order[7]; //used for pile sorting
    Random random;
    Card cards[52];
    Pile piles[13];
    MoveList moves; //list of moves currently available in the current state
    int redMin, blackMin; //minimum rank in foundation for red/black
    int rounds; //times through deck/talon
    int foundationCount; //cards in foundation
    int drawCount;
public:
    Solitaire(int drawCount) {
        random = Random();
        moves = MoveList();
        this->drawCount = drawCount;
        
        for (int i = 0; i < 52; ++i) {
            cards[i].set(i);
        }
        
        reset();
    }
    
    //put the game back to its initial state
    void reset() {
        redMin = -1;
        blackMin = -1;
        rounds = 0;
        foundationCount = 0;
        
        for (int i = 0; i < 13; ++i) {
            piles[i].clear();
        }
        
        for (int j = TABLEAU1, i = 0; j <= TABLEAU7; ++j) {
            for (int k = j; k <= TABLEAU7; ++k, ++i) {
                piles[k].add(cards + i);
            }
        }
        
        for (int i = 51; i >= 28; --i) {
            piles[STOCK].add(cards + i);
        }
        
        for (int i = TABLEAU1; i <= TABLEAU7; ++i) {
            piles[i].flip();
        }
    }
    //generate an array of characters that represent the state of the game
    char* key() {
        order[0] = TABLEAU1;
        order[1] = TABLEAU2;
        order[2] = TABLEAU3;
        order[3] = TABLEAU4;
        order[4] = TABLEAU5;
        order[5] = TABLEAU6;
        order[6] = TABLEAU7;
        int cur = 1;
        int fuc = piles[cur].size;
        //sort the piles
        while (cur < 7) {
            int curT = cur;
            
            do {
                if (piles[order[curT - 1]].highValue() <= piles[order[curT]].highValue()) {
                    break;
                }
                
                int temp = order[curT - 1];
                order[curT - 1] = order[curT];
                order[curT--] = temp;
            } while (curT > 0);
            
            ++cur;
            fuc += piles[cur].faceUpCount();
        }
        
        char* comp = new char[4 + fuc];
        int z = 0;
        comp[z++] = (piles[WASTE].size + 1);
        comp[z++] = (piles[FOUNDATION1].size << 4) | (piles[FOUNDATION2].size + 1);
        comp[z++] = (piles[FOUNDATION3].size << 4) | (piles[FOUNDATION4].size + 1);
        Pile* pile;
        
        for (int i = 0; i < 7; ++i) {
            pile = piles + order[i];
            
            if (pile->top >= 0) {
                for (int i = pile->top; i < pile->size; ++i) {
                    comp[z++] = pile->cards[i]->value + 1;
                }
                comp[z - 1] |= 128;
            }
        }
        
        comp[z] = 0;
        return comp;
    }
    //make a series of moves
    void makeMove(Move* move) {
        do {
            makeMove(move->from, move->to, move->cards, move->val);
            move = move->next;
        } while (move != NULL);
    }
    //make a single move
    bool makeMove(int from, int to, int cardsMoved, int val) {
        bool thru = false;
        
        if (from != to) {
            if (val > 0) {
                if (piles[STOCK].removeTop(piles + WASTE, val, false)) {
                    ++rounds;
                    thru = true;
                }
            }
            
            if (cardsMoved == 1) {
                piles[from].remove(piles + to);
                
                if (to >= FOUNDATION1) {
                    ++foundationCount;
                    setFoundationMin();
                } else if (from >= FOUNDATION1) {
                    --foundationCount;
                    setFoundationMin();
                }
            } else {
                piles[from].remove(piles + to, cardsMoved);
            }
        } else {
            piles[from].flip();
        }
        
        return thru;
    }
    //undo a single move. thru is set to true if we made a move that increased the number of rounds.
    void undoMove(int from, int to, int cardsMoved, int val, bool thru) {
        if (from != to) {
            if (cardsMoved == 1) {
                piles[to].remove(piles + from);
                
                if (to >= FOUNDATION1) {
                    --foundationCount;
                    setFoundationMin();
                } else if (from >= FOUNDATION1) {
                    ++foundationCount;
                    setFoundationMin();
                }
            } else {
                piles[to].remove(piles + from, cardsMoved);
            }
            
            if (val > 0) {
                if (piles[WASTE].removeTop(piles + STOCK, val, thru)) {
                    --rounds;
                }
            }
        } else {
            piles[to].flip();
        }
    }
    //determine available moves.
    void updateMoves(MoveList* mvs) {
        mvs->clear();
        //Check flip of tableau pile
        //Check tableau to foundation
        //Check tableau to tableau
        Pile* pile1 = piles + TABLEAU1;
        Card* card1;
        
        for (int i = TABLEAU1; i <= TABLEAU7; ++i, ++pile1) {
            int pile1Size = pile1->size;
            
            if (pile1Size == 0) {
                continue;
            }
            
            if (!pile1->cards[pile1Size - 1]->up) {
                mvs->addLast(i, i, 0, 0);
                return;
            }
        }
        
        int wasteSize = piles[WASTE].size;
        int stockSize = piles[STOCK].size;
        pile1 = piles + TABLEAU1;
        Pile* pile2;
        
        for (int i = TABLEAU1; i <= TABLEAU7; ++i, ++pile1) {
            int pile1Size = pile1->size;
            
            if (pile1Size == 0) {
                continue;
            }
            
            card1 = pile1->cards[pile1Size - 1];
            int cardFoundation = 9 + card1->suit;
            
            if (card1->rank - piles[cardFoundation].topRank() == 1) {
                //logic used to tell if we can safely move a card to its foundation
                //this logic should only be used here and not on the talon unless we are only drawing 1 card
                int min = (card1->clr == 0 ? redMin : blackMin) + 2;
                
                if (card1->rank <= min) {
                    mvs->clear();
                    mvs->addLast(i, cardFoundation, 1, 0);
                    return;
                }
                
                mvs->addLast(i, cardFoundation, 1, 0);
            }
            
            Card* card2 = pile1->cards[pile1->top];
            int pile1Length = (card2->rank - card1->rank + 1);
            bool kingMoved = false;
            pile2 = piles + TABLEAU1;
            
            for (int j = TABLEAU1; j <= TABLEAU7; ++j, ++pile2) {
                if (i == j) {
                    continue;
                }
                
                int pile2Size = pile2->size;
                
                if (pile2Size == 0) {
                    if (card2->rank != 12 || pile1Size == pile1Length || kingMoved) {
                        continue;
                    }
                    
                    mvs->addLast(i, j, pile1Length, 0);
                    //only create one move for a blank spot
                    kingMoved = true;
                    continue;
                }
                
                Card* card3 = pile2->cards[pile2Size - 1];
                
                //logic used to determine if a pile of cards can be moved ontop of another pile of cards
                if (card1->rank >= card3->rank || card2->rank + 1 < card3->rank || ((card3->clr ^ card1->clr) ^ (card3->odd ^ card1->odd)) != 0) {
                    continue;
                }
                
                int pile1Moved = (card3->rank - card1->rank);
                
                if (pile1Moved == pile1Length) {//we are moving all face up cards
                    mvs->addLast(i, j, pile1Moved, 0);
                    continue;
                }
                
                //look to see if we are covering a card that can be moved to the foundation
                card3 = pile1->cards[pile1Size - pile1Moved - 1];
                
                if (card3->rank - piles[card3->suit + 9].topRank() == 1) {
                    mvs->addLast(i, j, pile1Moved, 0);
                    continue;
                }
            }
        }
        
        //Check waste to foundation
        //Check waste to tableau
        if (wasteSize > 0) {
            card1 = piles[WASTE].cards[wasteSize - 1];
            int wasteFoundation = 9 + card1->suit;
            
            if (card1->rank - piles[wasteFoundation].topRank() == 1) {
                //should always add here if draw count is greater than 1
                int min = (card1->clr == 0 ? redMin : blackMin) + 2;
                
                if (card1->rank <= min) {
                    mvs->clear();
                    mvs->addLast(WASTE, wasteFoundation, 1, 0);
                    return;
                }
                
                mvs->addLast(WASTE, wasteFoundation, 1, 0);
            }
            
            pile1 = piles + TABLEAU1;
            
            for (int i = TABLEAU1; i <= TABLEAU7; ++i, ++pile1) {
                int size = pile1->size;
                
                if (size != 0) {
                    Card* card = pile1->cards[size - 1];
                    
                    if (!card->up || card->rank - card1->rank != 1 || card->clr == card1->clr) {
                        continue;
                    }
                    
                    mvs->addLast(WASTE, i, 1, 0);
                    continue;
                }
                
                if (card1->rank != 12) {
                    continue;
                }
                
                mvs->addLast(WASTE, i, 1, 0);
                break;
            }
        }
        
        //check foundation to tableau
        //very rarely needed to solve optimally
        pile1 = piles + FOUNDATION1;
        
        for (int i = FOUNDATION1; i <= FOUNDATION4; ++i, ++pile1) {
            int foundationSize = pile1->size;
            
            if (foundationSize == 0) {
                continue;
            }
            
            card1 = pile1->cards[foundationSize - 1];
            int min = (card1->clr == 0 ? redMin : blackMin) + 2;
            
            if (card1->rank <= min) {
                continue;
            }
            
            pile2 = piles + TABLEAU1;
            
            for (int j = TABLEAU1; j <= TABLEAU7; ++j, ++pile2) {
                int size = pile2->size;
                
                if (size != 0) {
                    Card* card = pile2->cards[size - 1];
                    
                    if (!card->up || card->rank - card1->rank != 1 || card->clr == card1->clr) {
                        continue;
                    }
                    
                    mvs->addLast(i, j, 1, 0);
                    continue;
                }
                
                if (card1->rank != 12) {
                    continue;
                }
                
                mvs->addLast(i, j, 1, 0);
                break;
            }
        }
        
        //check cards waiting to be turned over from stock
        pile1 = piles + STOCK;
        
        for (int j = stockSize - 1; j >= 0; --j) {
            card1 = pile1->cards[j];
            int stockFoundation = 9 + card1->suit;
            
            if (card1->rank - piles[stockFoundation].topRank() == 1) {
                int min = (card1->clr == 0 ? redMin : blackMin) + 2;
                
                if (card1->rank <= min) {
                    mvs->addLast(WASTE, stockFoundation, 1, stockSize - j);
                    return;
                }
                
                mvs->addLast(WASTE, stockFoundation, 1, stockSize - j);
            }
            
            pile2 = piles + TABLEAU1;
            
            for (int i = TABLEAU1; i <= TABLEAU7; ++i, ++pile2) {
                int size = pile2->size;
                
                if (size != 0) {
                    Card* card = pile2->cards[size - 1];
                    
                    if (!card->up || card->rank - card1->rank != 1 || card->clr == card1->clr) {
                        continue;
                    }
                    
                    mvs->addLast(WASTE, i, 1, stockSize - j);
                    continue;
                }
                
                if (card1->rank != 12) {
                    continue;
                }
                
                mvs->addLast(WASTE, i, 1, stockSize - j);
                break;
            }
        }
        
        //check cards already turned over in the waste
        //meaning we have to "redeal" the deck to get to it
        pile1 = piles + WASTE;
        --wasteSize;
        
        for (int j = 0; j < wasteSize; ++j) {
            card1 = pile1->cards[j];
            int stockFoundation = 9 + card1->suit;
            
            if (card1->rank - piles[stockFoundation].topRank() == 1) {
                int min = (card1->clr == 0 ? redMin : blackMin) + 2;
                
                if (card1->rank <= min) {
                    mvs->addLast(WASTE, stockFoundation, 1, stockSize + j + 1);
                    return;
                }
                
                mvs->addLast(WASTE, stockFoundation, 1, stockSize + j + 1);
            }
            
            pile2 = piles + TABLEAU1;
            
            for (int i = TABLEAU1; i <= TABLEAU7; ++i, ++pile2) {
                int size = pile2->size;
                
                if (size != 0) {
                    Card* card = pile2->cards[size - 1];
                    
                    if (!card->up || card->rank - card1->rank != 1 || card->clr == card1->clr) {
                        continue;
                    }
                    
                    mvs->addLast(WASTE, i, 1, stockSize + j + 1);
                    continue;
                }
                
                if (card1->rank != 12) {
                    continue;
                }
                
                mvs->addLast(WASTE, i, 1, stockSize + j + 1);
                break;
            }
        }
    }
    //set minimum ranks in foundation
    void setFoundationMin() {
        int one = piles[FOUNDATION2].topRank();
        int two = piles[FOUNDATION4].topRank();
        redMin = one <= two ? one : two;
        one = piles[FOUNDATION1].topRank();
        two = piles[FOUNDATION3].topRank();
        blackMin = one <= two ? one : two;
    }
    //heuristic function used to determine lower bound of moves needed
    int minWinAt() {
        int win = (piles[STOCK].size << 1) + piles[WASTE].size; //needs to modified slightly for draw counts greater than 1
        Card* ctmp1, *ctmp2;
        Pile* p = piles + WASTE;
        
        for (int i = p->size - 1; i >= 0; --i) {
            ctmp1 = p->cards[i];
            
            for (int j = i - 1; j >= 0; --j) {
                ctmp2 = p->cards[j];
                
                if (ctmp1->suit == ctmp2->suit && ctmp1->rank > ctmp2->rank) {
                    ++win;
                    break;
                }
            }
        }
        
        p = piles + TABLEAU1;
        
        for (int i = TABLEAU1; i <= TABLEAU7; ++i, ++p) {
            int temp = p->size;
            int top = p->top < 0 ? temp : p->top;
            win += temp + top;
            
            while ((--temp) >= 0) {
                ctmp1 = p->cards[temp];
                
                for (int j = (top < temp ? top - 1 : temp - 1); j >= 0; --j) {
                    ctmp2 = p->cards[j];
                    
                    if (ctmp1->suit == ctmp2->suit && ctmp1->rank > ctmp2->rank) {
                        ++win;
                        
                        if (top < temp) {
                            temp = top;
                        }
                        
                        break;
                    }
                }
            }
        }
        
        return win;
    }
    int shuffle(int seed = -1) {
        if (seed != -1) {
            random.setSeed(seed);
        } else {
            seed = random.next();
            random.setSeed(seed);
        }
        
        int temp;
        
        for (int x = 0; x < 250; ++x) {
            int k = random.next() % 52;
            int j = random.next() % 52;
            temp = cards[k].value;
            cards[k].set(cards[j].value);
            cards[j].set(temp);
        }
        
        reset();
        return seed;
    }
    bool load(char* cardSet) {
        for (int i = 0; i < 52; i++) {
            int suit = (cardSet[i * 3 + 2] ^ 0x30) - 1;
            
            if (suit < 0 || suit > 3) {
                return false;
            }
            
            if (suit >= 2) {
                suit = (suit == 2) ? 3 : 2;
            }
            
            int rank = (cardSet[i * 3] ^ 0x30) * 10 + (cardSet[i * 3 + 1] ^ 0x30) - 1;
            
            if (rank < 0 || rank > 12) {
                return false;
            }
            
            cards[i].set(suit * 13 + rank);
        }
        
        reset();
        return true;
    }
    void print() {
        for (int i = 0; i < 13; i++) {
            printf("%2i: ", i);
            piles[i].print();
            printf("\n");
            fflush(stdout);
        }
        
        moves.print();
        printf("\nMinWinAt: %i\n", minWinAt());
        fflush(stdout);
    }
    //IDA* implementation to solve specified deal
    int solve(int* max, bool show = false) {
        int bestF = 0, mm = *max;
        HashMap closed = HashMap(23);
        reset();
        int wa = minWinAt(), added = 0;
        closed.addGet(key(), wa);
        MoveList mList = MoveList();
        MoveList mList2 = MoveList();
        MoveArray open = MoveArray(1 << 23);
        open.add(-1, -1, -1, wa << 12);
        
        while (open.top > 0) {
            //grab first move and move it to the end so it can be cleaned up later.
            int parent = open.moveFirstToLast();
            Move* temp = open.get(parent);
            reset();
            mList.clear();
            wa = 0;
            
            //generate move list
            while (temp->cards >= 0) {
                mList.addFirst(temp->from, temp->to, temp->cards, temp->val & 31);
                wa += (temp->val & 31) + 1;
                temp = temp->prev;
            }
            
            //make all moves
            if (mList.first != NULL) {
                makeMove(mList.first);
            }
            
            //check and see if the game is won
            if (foundationCount > bestF || (foundationCount == 52 && wa <= mm)) {
                bestF = foundationCount;
                
                if (bestF == 52 && wa <= mm) {
                    if (show) {
                        mList.printPacked();
                        printf("\n");
                        mList.printPretty();
                        printf("\n");
                        fflush(stdout);
                    }
                    *max = wa;
                    return 52;
                }
            }
            
            //update list of available moves
            updateMoves(&moves);
            //check each of the available moves to see if it has been evaluated already or not
            temp = moves.first;
            added = 0;
            int flipped;
            while (temp != NULL) {
                mList2.clear();
                bool thru = makeMove(temp->from, temp->to, temp->cards, temp->val);
                flipped = 1;
                /*bool easy = true;
                 while (easy) {
                 updateMoves(&mList3, false);
                 easy = mList3.size == 1;
                 if (easy) {
                 ++flipped;
                 makeMove(mList3.first->from, mList3.first->to, mList3.first->cards, 0);
                 mList2.addFirst(mList3.first->from, mList3.first->to, mList3.first->cards, 0);
                 }
                 }*/
                
                bool easy = true;
                while (easy) {
                    easy = false;
                    
                    Pile* pile = piles + WASTE;
                    int wasteSize = pile->size;
                    if (wasteSize > 0) {
                        Card* card = pile->cards[wasteSize - 1];
                        int wasteFoundation = 9 + card->suit;
                        
                        if (card->rank - piles[wasteFoundation].topRank() == 1) {
                            int min = (card->clr == 0 ? redMin : blackMin) + 2;
                            
                            if (card->rank <= min) {
                                ++flipped;
                                makeMove(WASTE, wasteFoundation, 1, 0);
                                mList2.addFirst(WASTE, wasteFoundation, 1, 0);
                                easy = true;
                            }
                        }
                    }
                    
                    pile = piles + TABLEAU1;
                    for (int i = TABLEAU1; i <= TABLEAU7; ++i, ++pile) {
                        int pile1Size = pile->size;
                        
                        if (pile1Size == 0) {
                            continue;
                        }
                        
                        Card* card = pile->cards[pile1Size - 1];
                        
                        if (!card->up) {
                            ++flipped;
                            makeMove(i, i, 0, 0);
                            mList2.addFirst(i, i, 0, 0);
                            easy = true;
                            break;
                        }
                        
                        int cardFoundation = 9 + card->suit;
                        
                        if (card->rank - piles[cardFoundation].topRank() == 1) {
                            int min = (card->clr == 0 ? redMin : blackMin) + 2;
                            
                            if (card->rank <= min) {
                                ++flipped;
                                makeMove(i, cardFoundation, 1, 0);
                                mList2.addFirst(i, cardFoundation, 1, 0);
                                easy = true;
                                break;
                            }
                        }
                    }
                }
                int mvs = wa + temp->val + flipped;// + minWinAt();
                
                //only add moves with length less than current iteration depth
                if (mvs + minWinAt() <= mm) {
                    Pair* p = closed.addGet(key(), mvs);
                    ++added;
                    
                    //only add new moves or moves with fewer total moves (should just reupdate the existing move's parent, but havent got to it)
                    if (p == NULL || p->value > mvs) {
                        open.add(temp->from, temp->to, temp->cards, ((52 - foundationCount + rounds) << 5) | temp->val, parent);
                        
                        if (flipped > 1) {
                            Move* mv = mList2.last;
                            while (mv != NULL) {
                                open.add(mv->from, mv->to, mv->cards, ((52 - foundationCount + rounds) << 5), open.moveFirstToLast());
                                mv = mv->prev;
                            }
                        }
                        
                        if (p != NULL) {
                            p->value = mvs;
                        }
                    }
                }
                
                if (flipped > 1) {
                    Move* mv = mList2.first;
                    while (mv != NULL) {
                        undoMove(mv->from, mv->to, mv->cards, 0, false);
                        mv = mv->next;
                    }
                }
                undoMove(temp->from, temp->to, temp->cards, temp->val, thru);
                temp = temp->next;
            }
            
            //if all branches from this parent have been added mark this move as no longer needed if we reopen the search
            if (added == moves.size) {
                open.setUsed(parent);
            }
            
            //reopen the search if we have not found a solution for the next higher depth
            if (open.top == 0 && bestF < 52) {
                if ((++mm) > 256) {
                    return bestF;
                }
                
                *max = mm;
                int prevSize = open.size;
                open.prune();
                
                if (show) {
                    printf("Trying: %i OPS: %i OS-OT: %i-%i CS: %i F: %i\n", mm, prevSize, open.size, open.top, closed.size(), bestF);
                    fflush(stdout);
                }
            }
        }
        
        if (show) {
            printf("Failed. OS-OT: %i-%i CS: %i F: %i\n", open.size, open.top, closed.size(), bestF);
            fflush(stdout);
        }
        
        return bestF;
    }
};

int main(int argc, const char * argv[])
{
    Solitaire s = Solitaire(1);
    s.shuffle();
    
    int i = 0;
 s.load("092132014012091083053052082131102051021033122084062111094071081013103064041112093042113044104024124023074011054032133072031123134114043073063101121034022061");
    
    s.print();
    timeb startTime;
    ftime(&startTime);
    //for(int j = 0; j < 50; ++j) {
    //s.shuffle();
    i = s.minWinAt();
    printf("Trying %i\n", i);
    int x = s.solve(&i, true);
    printf("Found: %i %i\n", i, x);
    //}
    timeb endTime;
    ftime(&endTime);
    i = (endTime.time - startTime.time) * 1000L + (endTime.millitm - startTime.millitm);
    printf("Done %i\n", i);
    /*
     * Pressing a key to terminate a program is obnoxious and non-UNIXy.
     */
#if 0
    getchar();
#endif
    return 0;
}

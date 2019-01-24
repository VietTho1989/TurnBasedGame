//
//  action.h
//
//  Created by pilhoon on 1/18/16.
//

#ifndef action_h
#define action_h

class Action{
public:
    Pos prev;
    Pos next;

    Action(){};
    Action(Pos p, Pos n) {prev = p; next = n;};
    Action(int fx, int fy, int tx, int ty) { prev = Pos(fx, fy); next = Pos(tx, ty); }; //for debug
    bool IsPrev(int x, int y) {
        return x == prev.x && y == prev.y;
    };
    void Print() {
        printf("%d,%d->%d,%d\n", prev.x, prev.y, next.x, next.y);
    };
    bool operator== (Action a) {
        return prev == a.prev && next == a.next;
    }
};

#endif /* action_h */


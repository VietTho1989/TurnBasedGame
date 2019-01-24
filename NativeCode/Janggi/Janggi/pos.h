//
//  pos.h
//
//  Created by pilhoon on 1/18/16.
//

#ifndef pos_h
#define pos_h

class Pos{
public:
    int x, y;
    Pos() {
        x = y = -1; // TODO. -1 is a magic number. undesirable.
    }
    Pos(int x, int y);
    float DistWith(int fx, int fy);
    bool operator== (Pos& p) {
        return x == p.x && y == p.y;
    };
    bool operator!= (Pos& p) {
        return ! operator==(p);
    };
};

#endif /* pos_h */


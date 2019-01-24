//
// pos.cpp
//
// Created by pilhoon on 1/18/16
//

#include <cmath>
#include "defines.h"
#include "pos.h"

Pos::Pos(int x, int y) {
    //if (x < 0 || x >= kStageWidth || y < 0 || y >= kStageHeight) // validation on create.
    //    throw;
    this->x = x;
    this->y=y;
}

float Pos::DistWith(int fx, int fy) {
	return hypot(x-fx, y-fy);
}


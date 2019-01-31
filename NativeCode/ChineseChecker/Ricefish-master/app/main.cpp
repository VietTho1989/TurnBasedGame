//
//  main.cpp
//  chinese-checkers
//
//  Created by Bendik Samseth on 13/02/2018.
//  Copyright © 2018 Bendik Samseth. All rights reserved.
//
#include <iostream>
#include "ricefish.hpp"

using namespace std;

int main() {
    std::unique_ptr<ricefish::Ricefish> fish(new ricefish::Ricefish());
    fish->run();
    return 0;
}

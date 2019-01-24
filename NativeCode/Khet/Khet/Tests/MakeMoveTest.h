#ifndef __MAKE_MOVE_TEST_H__
#define __MAKE_MOVE_TEST_H__

#include "TestBase.h"
#include "../Board.h"
#include "../MoveGenerator.h"
#include <cassert>
#include <iostream>
#include <string>

class MakeMoveTest : public TestBase
{
public:
    std::string TestFileName() const
    {
        return "MakeMoveTests.suite";
    }

    bool Run(const std::vector<std::string>& testCase)
    {
        assert(testCase.size() == 1);
        return RunForPlayer(testCase[0], Player::Silver) &&
               RunForPlayer(testCase[0], Player::Red);
    }

private:
    // Run the test case for the specified player.
    bool RunForPlayer(const std::string& khetPos, Player player)
    {
        std::string khetPosFull = khetPos + " " + std::to_string((int)player);
        return MakeUnmake(Board(khetPosFull));
    }

    // Make/unmake every move and check that the move was reverted correctly.
    bool MakeUnmake(Board board)
    {
        MoveGenerator gen(board);
        int cmp = 0;
        Move move = NoMove;
        while (cmp == 0 && (move = gen.Next()) != NoMove)
        {
            Board original(board);
            board.MakeMove(move);
            board.UndoMove();
            cmp = board.Compare(original);
        }

        if (cmp != 0)
        {
            std::cout << "Make/Unmake failed: " << cmp << std::endl;
        }

        return cmp == 0;
    }
};

#endif // __MAKE_MOVE_TEST_H__

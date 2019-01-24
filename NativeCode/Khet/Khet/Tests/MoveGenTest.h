#ifndef __MOVE_GEN_TEST_H__
#define __MOVE_GEN_TEST_H__

#include "TestBase.h"
#include "../Board.h"
#include "../MoveGenerator.h"
#include "../MoveHelpers.h"
#include "../Types.h"
#include <cassert>
#include <iostream>
#include <string>

class MoveGenTest : public TestBase
{
public:
    std::string TestFileName() const
    {
        return "MoveGenTests.suite";
    }

    // For move generation tests the test case consists of a Khet position string (minus player)
    // followed by the number of moves that the silver and red players have.
    bool Run(const std::vector<std::string>& testCase)
    {
        assert(testCase.size() == 3);
        return RunForPlayer(testCase[0], Player::Silver, std::stoi(testCase[1])) &&
               RunForPlayer(testCase[0], Player::Red, std::stoi(testCase[2]));
    }

private:
    // Run the test case for the specified player.
    bool RunForPlayer(const std::string& khetPos, Player player, int expectedMoves)
    {
        std::string khetPosFull = khetPos + " " + std::to_string((int)player);
        Board board(khetPosFull);
        int numMoves = CountMoves(board);
        std::cout << "Expected: " << expectedMoves << ", Got: " << numMoves << std::endl;

        if (numMoves != expectedMoves)
        {
            std::cout << board.ToString() << std::endl;
        }

        return numMoves == expectedMoves;
    }

    // Count the number of moves available in the position.
    int CountMoves(const Board& board)
    {
        MoveGenerator gen(board);
        int count = 0;
        Move move = NoMove;
        while ((move = gen.Next()) != NoMove) 
        {
            std::cout << GetStart(move) << " " << GetEnd(move) << " " << GetRotation(move) << std::endl;
            ++count;
        }

        return count;
    }
};

#endif // __MOVE_GEN_TEST_H__

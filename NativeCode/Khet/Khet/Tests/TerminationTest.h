#ifndef __TERMINATION_TEST_H__
#define __TERMINATION_TEST_H__

#include "TestBase.h"
#include "../Board.h"
#include "../EvalParams.h"
#include "../Evaluator.h"
#include "../Globals.h"
#include "../MoveGenerator.h"
#include <cassert>
#include <cstdlib>
#include <ctime>
#include <iostream>
#include <string>

// Termination tests test the ability to detected terminal positions i.e. checkmate and draws.
class TerminationTest : public TestBase
{
public:
    TerminationTest()
    {
        srand(time(0));
    }

    std::string TestFileName() const
    {
        return "TerminationTests.suite";
    }

    bool Run(const std::vector<std::string>& testCase)
    {
        assert(testCase.size() == 2);
        std::string khetPos = testCase[0] + " " + testCase[1];
        return RunTerminationTest(khetPos);
    }

private:
    // A termination test consists of playing multiple games with randomly selected moves and
    // ensuring that each game terminates as expected.
    bool RunTerminationTest(const std::string& khetPos)
    {
        EvalParams params;
        Evaluator eval(params);

        bool success = true;
        const int NumTests = 1000;
        Move move = NoMove;
        int j, playoutLengthTotal = 0, numDraws = 0;
        for (int i = 0; success && i < NumTests; i++)
        {
            Board board(khetPos);
            for (j = 0; j < MaxGameLength; j++)
            {
                if ((move = GetRandomMove(board)) != NoMove)
                {
                    // Make the move.
                    board.MakeMove(move);
                }
                else
                {
                    break;
                }
            }

            if (j < MaxGameLength)
            {
                // Playout terminates successfully.
                playoutLengthTotal += j;

                // Check that the correct terminal evaluation is given.
                int e = eval(board);
                bool isDraw = board.IsDraw();
                if (isDraw)
                {
                    ++numDraws;
                    success = e == 0;
                }
                else
                {
                    success = std::abs(e) == params.CheckmateVal();
                }

                if (!success)
                {
                    std::cout << "The wrong evaluation was given!" << std::endl;
                    std::cout << "Game was drawn: " << isDraw << std::endl;
                    std::cout << "Evaluation: " << e << std::endl;
                }
            }
            else
            {
                std::cout << "Playout failed to terminate!" << std::endl;
                std::cout << board.ToString() << std::endl;
                success = false;
            }
        }

        if (success)
        {
            // Print some statistics.
            std::cout << "Average playout length: " << (double)playoutLengthTotal / NumTests << std::endl;
            std::cout << "Draw ratio: " << (double)numDraws / NumTests << std::endl;
        }

        return success;
    }

    Move GetRandomMove(const Board& board)
    {
        // Get all of the moves.
        Move move = NoMove;
        MoveGenerator gen(board);
        std::vector<Move> moves;
        while ((move = gen.Next()) != NoMove)
        {
            moves.push_back(move);
        }

        if (moves.size() > 0)
        {
            // Select a move randomly.
            move = moves[rand() % moves.size()];
        }

        return move;
    }
};

#endif // __TERMINATION_TEST_H__

using UnityEngine;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Banqi
{
    public class TestBanqi
    {

        private const int NULL_SCORE = 122324;

        class Work
        {
            public void DoWork()
            {
                DefaultBanqi defaultBanqi = new DefaultBanqi();
                Banqi startBanqi = defaultBanqi.makeDefaultGameType() as Banqi;
                // Make a match
                {
                    int turn = 0;
                    Banqi banqi = startBanqi;
                    do
                    {
                        Debug.Log("before letComputerThink: " + turn);
                        Debug.Log("positionToString: " + turn + "\n" + banqi.print());

                        // TODO cai nay de phong
                        // Debug.LogError("positionToFen: \n"+Core.unityPositionToFen(positionBytes));
                        GameType.Result gameFinish = banqi.isGameFinish();
                        if (!gameFinish.isGameFinish)
                        {
                            BanqiMove move = banqi.getAIMove(new BanqiAI(), false) as BanqiMove;
                            if (move != null)
                            {
                                InputData inputData = new InputData();
                                {
                                    inputData.gameMove.v = move;
                                }
                                if (banqi.checkLegalMove(inputData))
                                {
                                    banqi.processGameMove(move);
                                }
                                else
                                {
                                    Debug.LogError("not legal move");
                                    break;
                                }
                            }
                            else
                            {
                                Debug.LogError("move null");
                                break;
                            }
                            turn++;
                        }
                        else
                        {
                            Debug.LogWarning("game finish in turn: " + turn + "; " + gameFinish + "; positionToString: \n" + banqi.print());
                            break;
                        }
                        System.Threading.Thread.Sleep(1000);
                    } while (!Test.stop);
                }
            }

            public void DoWork1()
            {
                List<int> blackScores = new List<int>();
                List<int> redScores = new List<int>();

                Game game = new Game();

                AI ai = new AI(game, Token.Ecolor.RED);

                string state = game.getBoard().saveBoard();
                {
                    string strBoard = ai.printBoard("State:\n" + state);
                    Debug.LogError(strBoard + "\n\n");
                }

                int moveCounter = 0;
                while (state.Split(new string[] { " . " }, StringSplitOptions.None)[0].Contains("R") && state.Split(new string[] { " . " }, StringSplitOptions.None)[0].Contains("B"))
                {
                    Debug.LogError("while state split");
                    int[] chosenMove = ai.negamax(state, 4);
                    Debug.LogError("chosen move: " + chosenMove);
                    int depthLimit = 5;
                    while (chosenMove[0] == 0 && chosenMove[1] == 0 && chosenMove[2] == 0 && chosenMove[3] == 0)
                    {
                        Debug.LogError("Now trying with a depth limit of " + depthLimit + " for player " + ai.getColor());
                        chosenMove = ai.negamax(state, depthLimit);
                        depthLimit++;
                    }

                    Debug.LogError("Chosen move:\n" + chosenMove);

                    state = ai.makeMove(chosenMove, state);
                    // print board
                    {
                        string strBoard = ai.printBoard("State:\n" + state);
                        Debug.LogError(strBoard + "\n\n");
                    }
                    // Debug.LogError("Value for Red: " + ai.calculateScore(Token.Ecolor.RED, state));
                    redScores.Add(ai.calculateScore(Token.Ecolor.RED, state));
                    // Debug.LogError("Value for Black: " + ai.calculateScore(Token.Ecolor.BLACK, state));
                    blackScores.Add(ai.calculateScore(Token.Ecolor.BLACK, state));

                    moveCounter++;

                    // Debug.LogError("\n\n");

                    if (ai.getColor() == Token.Ecolor.RED)
                    {
                        ai.setColor(Token.Ecolor.BLACK);
                    }
                    else
                    {
                        ai.setColor(Token.Ecolor.RED);
                    }
                }

                string victor = "black";
                if (state.Split(new string[] { " . " }, StringSplitOptions.None)[0].Contains("R"))
                {
                    victor = "red";
                }

                Debug.LogError("With " + moveCounter + " moves, " + victor + " is the victor!");

                List<int> newRedScores = new List<int>(redScores);
                int lastScore = NULL_SCORE;
                foreach (int score in redScores)
                {
                    if (lastScore == NULL_SCORE)
                    {
                        lastScore = score;
                        continue;
                    }
                    else
                    {
                        if (lastScore == score)
                        {
                            newRedScores.Remove(lastScore);
                        }
                        lastScore = score;
                    }
                }

                List<int> newBlackScores = new List<int>(blackScores);
                lastScore = NULL_SCORE;
                foreach (int score in blackScores)
                {
                    if (lastScore == NULL_SCORE)
                    {
                        lastScore = score;
                        continue;
                    }
                    else
                    {
                        if (lastScore == score)
                        {
                            newBlackScores.Remove(lastScore);
                        }
                        lastScore = score;
                    }
                }

                Debug.LogError("Red Scores:   " + newRedScores.ToString());
                Debug.LogError("Black Scores: " + newBlackScores.ToString());
            }


        }

        public static void startTestMatch(int matchCount)
        {
            for (int i = 0; i < matchCount; i++)
            {
                Work w = new Work();
                {
                    // w.DoWork ();
                    // startThread
                    ThreadStart threadDelegate = new ThreadStart(w.DoWork);
                    Thread newThread = new Thread(threadDelegate, 1048576);
                    newThread.Start();
                }
            }
        }

    }
}
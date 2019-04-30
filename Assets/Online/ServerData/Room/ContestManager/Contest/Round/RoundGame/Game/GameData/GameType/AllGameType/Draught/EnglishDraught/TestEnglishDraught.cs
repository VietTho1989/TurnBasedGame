using UnityEngine;
using System.Threading;

namespace EnglishDraught
{
    public class TestEnglishDraught
    {

        private class Work
        {
            public void DoWork()
            {
                EnglishDraught startEnglishDraught = null;
                {
                    int maxPly = 150;
                    startEnglishDraught = Core.unityMakeDefaultPosition(EnglishDraught.StartFen, maxPly);
                }
                EnglishDraughtMove lastMove = new EnglishDraughtMove();
                // Make a match
                {
                    int turn = 0;
                    EnglishDraught englishDraught = startEnglishDraught;
                    do
                    {
                        Debug.LogError(string.Format("before letComputerThink: {0}", turn));
                        Debug.LogError(Common.printPosition(englishDraught, lastMove));
                        int gameFinish = Core.unityIsGameFinish(englishDraught, true);
                        Debug.LogError("gameFinish: " + gameFinish);
                        if (gameFinish == 0)
                        {
                            // letComputerThink
                            bool threeMoveRandom = true;
                            float fMaxSeconds = 10.0f;
                            int g_MaxDepth = 12;
                            int pickBestMove = 90;
                            EnglishDraughtMove move = Core.unityLetComputerThink(englishDraught, true, threeMoveRandom, fMaxSeconds, g_MaxDepth, pickBestMove);
                            // print move to string
                            Debug.LogError("find ai move: " + Common.printMove(move));
                            lastMove = move;
                            {
                                // check legal move
                                if (Core.unityIsLegalMove(englishDraught, true, move))
                                {
                                    // do move
                                    EnglishDraught newEnglishDraught = Core.unityDoMove(englishDraught, true, move);
                                    // set new position bytes
                                    if (newEnglishDraught != null)
                                    {
                                        englishDraught = newEnglishDraught;
                                    }
                                    else
                                    {
                                        Debug.LogError("error, do move");
                                        break;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("error: why not legal move: " + move);
                                    break;
                                }
                            }
                            turn++;
                        }
                        else
                        {
                            Debug.LogWarning("game finish in turn: " + turn);
                            Debug.LogWarning(Common.printPosition(englishDraught, lastMove));
                            switch (gameFinish)
                            {
                                case 1:
                                    Debug.LogWarning("black win: " + turn);
                                    break;
                                case 2:
                                    Debug.LogWarning("white win: " + turn);
                                    break;
                                case 3:
                                    Debug.LogWarning("the game is draw: " + turn);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        }
                        System.Threading.Thread.Sleep(1000);
                    } while (!Test.stop);
                }
            }
        }

        public static void startTestMatch(int matchCount)
        {
            for (int i = 0; i < matchCount; i++)
            {
                Work w = new Work();
                {
                    // startThread
                    ThreadStart threadDelegate = new ThreadStart(w.DoWork);
                    Thread newThread = new Thread(threadDelegate);
                    newThread.Start();
                }
            }
        }

    }
}
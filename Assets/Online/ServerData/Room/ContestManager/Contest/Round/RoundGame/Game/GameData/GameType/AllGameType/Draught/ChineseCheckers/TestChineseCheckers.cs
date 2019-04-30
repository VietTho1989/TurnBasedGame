using UnityEngine;
using System.Threading;

namespace ChineseCheckers
{
    public class TestChineseCheckers
    {

        class Work
        {
            public void DoWork()
            {
                ChineseCheckers startChineseCheckers = null;
                {
                    startChineseCheckers = Core.unityMakePositionByFen(ChineseCheckers.INITIAL_POSITION);
                }
                // Make a match
                {
                    int turn = 0;
                    ChineseCheckers chineseCheckers = startChineseCheckers;
                    do
                    {
                        Debug.LogError(string.Format("before letComputerThink: {0}", turn));
                        // get legalMove
                        {
                            Core.unityGetLegalMoves(chineseCheckers, Core.CanCorrect);
                            Debug.Log(Core.unityGetStrPosition(chineseCheckers, Core.CanCorrect));
                        }
                        int gameFinish = Core.unityIsGameFinish(chineseCheckers, Core.CanCorrect);
                        Debug.LogError("gameFinish: " + gameFinish);
                        if (gameFinish == 0)
                        {
                            // letComputerThink
                            ChineseCheckersMove move = Core.unityLetComputerThink(chineseCheckers, Core.CanCorrect, 1, 5, 5000, 1000, 90);
                            // print move to string
                            // Debug.Log ("find ai move: " + Core.unityGetStrMove (move, Core.CanCorrect));
                            {
                                // check legal move
                                if (move != null && Core.unityIsLegalMove(chineseCheckers, Core.CanCorrect, move))
                                {
                                    // do move
                                    ChineseCheckers newChineseCheckers = Core.unityDoMove(chineseCheckers, Core.CanCorrect, move);
                                    // set new position bytes
                                    if (newChineseCheckers != null)
                                    {
                                        chineseCheckers = newChineseCheckers;
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
                            Debug.LogWarning(Core.unityGetStrPosition(chineseCheckers, Core.CanCorrect));
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
                    Thread newThread = new Thread(threadDelegate, Global.ThreadSize);
                    newThread.Start();
                }
            }
        }

    }
}
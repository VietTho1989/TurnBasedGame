using UnityEngine;
using System.Threading;

namespace Xiangqi
{
    public class TestXiangqi
    {

        private class Work
        {
            public void DoWork()
            {
                Xiangqi startXiangqi = Core.unityMakePositionByFen(Xiangqi.StartFen);
                // Make a match
                {
                    int turn = 0;
                    Xiangqi xiangqi = startXiangqi;
                    do
                    {
                        Debug.Log("before letComputerThink: " + turn);
                        Debug.Log("positionToString: " + turn + "\n" + Common.printPosition(xiangqi));
                        Debug.Log("positionToFen: " + Common.printPositionFen(xiangqi));
                        int gameFinish = Core.unityIsGameFinish(xiangqi, true);
                        Debug.Log("gameFinish: " + gameFinish);
                        if (gameFinish == 0)
                        {
                            int depth = 1;
                            int lngLimitTime = 2000;
                            bool useBook = true;
                            int pickBestMove = 90;
                            uint move = Core.unityLetComputerThink(xiangqi, true, depth, lngLimitTime, useBook, pickBestMove);
                            if (move != 0)
                            {
                                Debug.Log("test find ai move: " + turn + "; " + move + "; " + Common.printMove(move));
                                // check legal move
                                if (Core.unityIsLegalMove(xiangqi, true, move))
                                {
                                    Xiangqi newXiangqi = Core.unityDoMove(xiangqi, true, move);
                                    // update
                                    DataUtils.copyData(xiangqi, newXiangqi);
                                }
                                else
                                {
                                    Debug.LogError("why not legal move: " + move);
                                    break;
                                }
                            }
                            else
                            {
                                Debug.Log("why don't find any move, break");
                            }
                            turn++;
                        }
                        else
                        {
                            Debug.LogWarning("game finish in turn: " + turn);
                            Debug.LogWarning("positionToString: \n" + Common.printPosition(xiangqi));
                            switch (gameFinish)
                            {
                                case 1:
                                    Debug.LogWarning("red win");
                                    break;
                                case 2:
                                    Debug.LogWarning("black win");
                                    break;
                                case 3:
                                    Debug.LogWarning("the game is draw");
                                    break;
                                default:
                                    Debug.LogError("unknown gameFinish: " + gameFinish);
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
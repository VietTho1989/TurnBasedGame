using UnityEngine;
using System.Threading;

namespace HEX
{
    public class TestHex
    {

        private class Work
        {
            public void DoWork()
            {
                Hex startHex = null;
                {
                    System.UInt16 boardSize = Hex.MAX_BOARD_SIZE;
                    startHex = Core.unityMakeDefaultPosition(boardSize);
                }
                // Make a match
                {
                    int turn = 0;
                    Hex hex = startHex;
                    do
                    {
                        Debug.LogError(string.Format("before letComputerThink: {0}", turn));
                        // get legalMove
                        /*{
							Core.unityGetLegalMoves (russianDraught, Core.CanCorrect);
							Debug.Log (Core.unityGetStrPosition (russianDraught, Core.CanCorrect));
						}*/
                        // print pos
                        {
                            Debug.Log(Core.unityGetStrPosition(hex, Core.CanCorrect));
                        }
                        int gameFinish = Core.unityIsGameFinish(hex, Core.CanCorrect);
                        if (gameFinish == 0)
                        {
                            // letComputerThink
                            int limitTime = Hex.MAX_LIMIT_TIME;
                            bool firstMoveCenter = false;
                            System.UInt16 move = Core.unityLetComputerThink(hex, Core.CanCorrect, limitTime, firstMoveCenter);
                            // print move to string
                            Debug.Log("find ai move: " + move);
                            {
                                // check legal move
                                if (Core.unityIsLegalMove(hex, Core.CanCorrect, move))
                                {
                                    // do move
                                    Hex newHex = Core.unityDoMove(hex, Core.CanCorrect, move);
                                    // set new position bytes
                                    if (newHex != null)
                                    {
                                        hex = newHex;
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
                            Debug.LogWarning(Core.unityGetStrPosition(hex, Core.CanCorrect));
                            switch (gameFinish)
                            {
                                case 1:
                                    Debug.LogWarning("you win: " + turn);
                                    break;
                                case 2:
                                    Debug.LogWarning("you lose: " + turn);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        }
                        System.Threading.Thread.Sleep(500);
                    } while (!Test.stop);
                }
            }
        }

        static void DoWork(object work)
        {
            if (work is Work)
            {
                ((Work)work).DoWork();
            }
            else
            {
                Debug.LogError("why not work: " + work);
            }
        }

        public static void startTestMatch(int matchCount)
        {
            for (int i = 0; i < matchCount; i++)
            {
                Work w = new Work();
                {
                    // startThread
                    /*ThreadStart threadDelegate = new ThreadStart(w.DoWork);
                    Thread newThread = new Thread(threadDelegate);
                    newThread.Start();*/
                    ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork), w);
                }
            }
        }

    }
}
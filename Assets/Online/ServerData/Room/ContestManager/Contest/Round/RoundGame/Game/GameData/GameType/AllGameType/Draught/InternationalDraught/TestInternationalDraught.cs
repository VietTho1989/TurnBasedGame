using UnityEngine;
using System.Threading;

namespace InternationalDraught
{
    public class TestInternationalDraught
    {

        private class Work
        {
            public void DoWork()
            {
                System.Random rnd = new System.Random();
                InternationalDraught startInternationalDraught = null;
                {
                    int variantType = (int)Common.Variant_Type.Normal;
                    {
                        variantType = rnd.Next(3);
                    }
                    startInternationalDraught = Core.unityMakeDefaultPosition(variantType, InternationalDraught.StartFen);
                }
                // Make a match
                {
                    int turn = 0;
                    InternationalDraught internationalDraught = startInternationalDraught;
                    do
                    {
                        Debug.Log(string.Format("before letComputerThink: {0}", turn));
                        Debug.Log(Common.printPosition(internationalDraught));
                        int gameFinish = Core.unityIsGameFinish(internationalDraught, true);
                        Debug.Log("gameFinish: " + gameFinish);
                        if (gameFinish == 0)
                        {
                            // letComputerThink
                            bool bMove = true;
                            bool book = true;
                            int depth = 12;
                            float time = 10;
                            bool input = true;
                            bool useEndGameDatabase = true;
                            int pickBestMove = 90;
                            {
                                if (turn % 2 == 0)
                                {
                                    pickBestMove = 100;
                                }
                                else
                                {
                                    pickBestMove = 0;
                                }
                            }
                            System.UInt64 move = Core.unityLetComputerThink(internationalDraught, true, bMove, book, depth, time, input, useEndGameDatabase, pickBestMove);
                            // print move to string
                            Debug.Log("find ai move: " + move + "; " + Common.printMove(move));
                            {
                                // check legal move
                                if (Core.unityIsLegalMove(internationalDraught, true, move))
                                {
                                    // do move
                                    InternationalDraught newInternationalDraught = Core.unityDoMove(internationalDraught, true, move);
                                    // set new position bytes
                                    if (newInternationalDraught != null)
                                    {
                                        DataUtils.copyData(internationalDraught, newInternationalDraught);

                                        // TODO Test
                                        {
                                            if (internationalDraught.node.vs.Count != newInternationalDraught.node.vs.Count)
                                            {
                                                Debug.LogWarning("node count error: " + internationalDraught.node.vs.Count + "; " + newInternationalDraught.node.vs.Count);
                                            }
                                        }
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
                            Debug.LogWarning(Common.printPosition(internationalDraught));
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
using UnityEngine;
using System.Threading;

namespace FairyChess
{
    public class TestFairyChess
    {

        class Work
        {
            private System.Random rnd = new System.Random();

            public Work(System.Random rnd)
            {
                this.rnd = rnd;
            }

            public void DoWork()
            {
                bool chess960 = false;
                Common.VariantType variantType = Common.VariantType.minishogi;
                {
                    variantType = (Common.VariantType)rnd.Next(28);
                    Debug.Log("random variantType: " + variantType);
                }
                string startFen = VariantMap.GetStartFen(variantType);
                FairyChess startFairyChess = Core.unityMakePositionByFen(variantType, startFen, chess960);
                // Make a match
                {
                    int turn = 0;
                    FairyChess fairyChess = startFairyChess;
                    do
                    {
                        Debug.Log("before letComputerThink: " + turn);
                        Debug.Log("positionToString: " + turn + "\n" + Core.unityGetStrPosition(fairyChess, Core.CanCorrect));

                        // TODO cai nay de phong
                        // Debug.LogError("positionToFen: \n"+Core.unityPositionToFen(positionBytes));
                        int gameFinish = Core.unityIsGameFinish(fairyChess, true);
                        if (gameFinish == 0)
                        {
                            int move = Core.unityLetComputerThink(fairyChess, true, 10, 19, 6000);
                            if (move != 0)
                            {
                                Debug.Log("test find ai move: " + turn + "; " + move + "; " + Core.unityGetStrMove(fairyChess, Core.CanCorrect, move));
                                // check legal move
                                if (Core.unityIsLegalMove(fairyChess, true, move))
                                {
                                    FairyChess newFairyChess = Core.unityDoMove(fairyChess, true, move);
                                    // set new position bytes
                                    DataUtils.copyData(fairyChess, newFairyChess);
                                }
                                else
                                {
                                    Debug.LogError("why not legal move: " + move);
                                    break;
                                }
                            }
                            else
                            {
                                Debug.LogError("why don't find any move, break");
                            }
                            turn++;
                        }
                        else
                        {
                            Debug.LogWarning("game finish in turn: " + turn + "; " + gameFinish + "; positionToString: \n" + Core.unityGetStrPosition(fairyChess, Core.CanCorrect));
                            switch (gameFinish)
                            {
                                case 1:
                                    Debug.LogWarning("white win");
                                    break;
                                case 2:
                                    Debug.LogWarning("black win");
                                    break;
                                case 3:
                                    Debug.LogWarning("the game is draw");
                                    break;
                                default:
                                    Debug.LogWarning("unknown gameFinish: " + gameFinish);
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
            System.Random rnd = new System.Random();
            for (int i = 0; i < matchCount; i++)
            {
                Work w = new Work(rnd);
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
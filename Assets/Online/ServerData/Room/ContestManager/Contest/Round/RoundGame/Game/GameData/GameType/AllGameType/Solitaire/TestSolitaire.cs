using UnityEngine;
using System.Threading;

namespace Solitaire
{
    public class TestSolitaire
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
                rnd.Next(10);
                int drawCount = 1;// rnd.Next (10);
                Solitaire startSolitaire = Core.unityMakeDefaultPosition(drawCount);
                {
                    Debug.Log("start Solitaire: \n" + Core.unityPrintPosition(startSolitaire, Core.CanCorrect));
                }
                // Make a match
                {
                    int turn = 0;
                    Solitaire solitaire = startSolitaire;
                    // think
                    int multiThreaded = 1;
                    int maxClosedCount = 0;
                    bool fastMode = true;
                    SolitaireSolved solved = Core.unityLetComputerThink(solitaire, Core.CanCorrect, multiThreaded, maxClosedCount, fastMode);
                    do
                    {
                        Debug.Log("before letComputerThink: " + turn);
                        Debug.Log("positionToString: " + turn + "\n" + Core.unityPrintPosition(solitaire, Core.CanCorrect));
                        // check finish
                        int gameFinish = Core.unityIsGameFinish(solitaire, true);
                        if (gameFinish == 0)
                        {
                            // find move
                            SolitaireMove solitaireMove = null;
                            {
                                if (turn >= 0 && turn < solved.moves.vs.Count)
                                {
                                    solitaireMove = solved.moves.vs[turn];
                                }
                            }
                            // process
                            if (solitaireMove != null)
                            {
                                Debug.Log("doMove: " + Core.unityPrintMove(solitaire, Core.CanCorrect, solitaireMove)); Solitaire newSolitaire = Core.unityDoMove(solitaire, Core.CanCorrect, solitaireMove);
                                // set new position bytes
                                DataUtils.copyData(solitaire, newSolitaire, Solitaire.AllowNames);
                                turn++;
                            }
                            else
                            {
                                Debug.LogError("solitaireMove null");
                                break;
                            }
                        }
                        else
                        {
                            Debug.LogWarning("game finish in turn: " + turn + "; " + gameFinish + "; positionToString: \n" + Core.unityPrintPosition(solitaire, Core.CanCorrect));
                            switch (gameFinish)
                            {
                                case 1:
                                    Debug.LogWarning("you win");
                                    break;
                                case 2:
                                    Debug.LogWarning("you lose");
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


        public static void startTestMatch(int matchCount)
        {
            System.Random rnd = new System.Random();
            for (int i = 0; i < matchCount; i++)
            {
                Work w = new Work(rnd);
                {
                    // startThread
                    ThreadStart threadDelegate = new ThreadStart(w.DoWork);
                    Thread newThread = new Thread(threadDelegate, 1048576);
                    newThread.Start();
                }
            }
        }

    }
}
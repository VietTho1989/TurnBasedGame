using UnityEngine;
using System.Threading;

namespace NineMenMorris
{
    public class TestNineMenMorris
	{

		private class Work 
		{
			public void DoWork()
			{
				NineMenMorris startNineMenMorris = null;
				{
					startNineMenMorris = Core.unityMakeDefaultPosition ();
				}
				// Make a match
				{
					int turn = 0;
					NineMenMorris nineMenMorris = startNineMenMorris;
					do {
						Debug.LogError (string.Format ("before letComputerThink: {0}", turn));
						// get legalMove
						{
							Core.unityGetLegalMoves (nineMenMorris, Core.CanCorrect);
							Debug.Log (Core.unityGetStrPosition (nineMenMorris, Core.CanCorrect));
						}
						int gameFinish = Core.unityIsGameFinish (nineMenMorris, Core.CanCorrect);
						Debug.LogError ("gameFinish: " + gameFinish);
						if (gameFinish == 0) {
							// letComputerThink
							NineMenMorrisMove move = Core.unityLetComputerThink (nineMenMorris, Core.CanCorrect, 3, 3, 3, 3, 90);
							// print move to string
							// Debug.Log ("find ai move: " + Core.unityGetStrMove (move, Core.CanCorrect));
							{
								// check legal move
								if (move!=null && Core.unityIsLegalMove (nineMenMorris, Core.CanCorrect, move)) {
									// do move
									NineMenMorris newNineMenMorris = Core.unityDoMove (nineMenMorris, Core.CanCorrect, move);
									// set new position bytes
									if (newNineMenMorris != null) {
										nineMenMorris = newNineMenMorris;
									} else {
										Debug.LogError ("error, do move");
										break;
									}
								} else {
									Debug.LogError ("error: why not legal move: " + move);
									break;
								}
							}
							turn++;
						} else {
							Debug.LogWarning ("game finish in turn: " + turn);
							Debug.LogWarning (Core.unityGetStrPosition (nineMenMorris, Core.CanCorrect));
							switch (gameFinish) {
							case 1:
								Debug.LogWarning ("black win: " + turn);
								break;
							case 2:
								Debug.LogWarning ("white win: " + turn);
								break;
							case 3:
								Debug.LogWarning ("the game is draw: " + turn);
								break;
							default:
								break;
							}
							break;
						}
						System.Threading.Thread.Sleep (1000);
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
			for (int i = 0; i < matchCount; i++) {
				Work w = new Work ();
				{
                    // startThread
                    /*ThreadStart threadDelegate = new ThreadStart (w.DoWork);
					Thread newThread = new Thread (threadDelegate, Global.ThreadSize);
					newThread.Start ();*/
                    ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork), w);
                }
			}
		}

	}
}
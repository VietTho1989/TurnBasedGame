using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Foundation.Tasks;

namespace RussianDraught
{
	public class TestRussianDraught
	{

		class Work 
		{
			public void DoWork()
			{
				RussianDraught startRussianDraught = null;
				{
					startRussianDraught = Core.unityMakePositionByFen (RussianDraught.StartFen);
				}
				// Make a match
				{
					int turn = 0;
					RussianDraught russianDraught = startRussianDraught;
					do {
						Debug.LogError (string.Format ("before letComputerThink: {0}", turn));
						// get legalMove
						{
							Core.unityGetLegalMoves (russianDraught, Core.CanCorrect);
							Debug.Log (Core.unityGetStrPosition (russianDraught, Core.CanCorrect));
						}
						int gameFinish = Core.unityIsGameFinish (russianDraught, Core.CanCorrect);
						Debug.LogError ("gameFinish: " + gameFinish);
						if (gameFinish == 0) {
							// letComputerThink
							int timeLimit = 5000;
							int pickBestMove = 90;
							RussianDraughtMove move = Core.unityLetComputerThink (russianDraught, Core.CanCorrect, timeLimit, pickBestMove);
							// print move to string
							Debug.Log ("find ai move: " + Core.unityGetStrMove (move, Core.CanCorrect));
							{
								// check legal move
								if (move!=null && Core.unityIsLegalMove (russianDraught, Core.CanCorrect, move)) {
									// do move
									RussianDraught newRussianDraught = Core.unityDoMove (russianDraught, Core.CanCorrect, move);
									// set new position bytes
									if (newRussianDraught != null) {
										russianDraught = newRussianDraught;
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
							Debug.LogWarning (Core.unityGetStrPosition (russianDraught, Core.CanCorrect));
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

		public static void startTestMatch(int matchCount)
		{
			for (int i = 0; i < matchCount; i++) {
				Work w = new Work ();
				{
					// startThread
					ThreadStart threadDelegate = new ThreadStart (w.DoWork);
					Thread newThread = new Thread (threadDelegate, Global.ThreadSize);
					newThread.Start ();
				}
			}
		}

	}
}
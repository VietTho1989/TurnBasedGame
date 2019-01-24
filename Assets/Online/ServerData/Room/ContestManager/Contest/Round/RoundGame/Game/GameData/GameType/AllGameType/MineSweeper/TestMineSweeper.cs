using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Foundation.Tasks;

namespace MineSweeper
{
	public class TestMineSweeper
	{

		class Work 
		{
			public void DoWork()
			{
				MineSweeper startMineSweeper = null;
				{
					int N = 10;
					int M = 10;
					int K = 10;
					startMineSweeper = Core.unityMakeDefaultPosition (N, M, K);
				}
				// Make a match
				{
					int turn = 0;
					MineSweeper mineSweeper = startMineSweeper;
					do {
						Debug.LogError (string.Format ("before letComputerThink: {0}", turn));
						// get legalMove
						/*{
							Core.unityGetLegalMoves (russianDraught, Core.CanCorrect);
							Debug.Log (Core.unityGetStrPosition (russianDraught, Core.CanCorrect));
						}*/
						// print pos
						{
							Debug.Log(Core.unityGetStrPosition (mineSweeper, Core.CanCorrect));
						}
						int gameFinish = Core.unityIsGameFinish (mineSweeper, Core.CanCorrect);
						if (gameFinish == 0) {
							// letComputerThink
							int firstMoveType = 0;
							int move = Core.unityLetComputerThink (mineSweeper, Core.CanCorrect, firstMoveType);
							// print move to string
							Debug.Log ("find ai move: " + move);
							{
								// check legal move
								if (Core.unityIsLegalMove (mineSweeper, Core.CanCorrect, move)) {
									// do move
									MineSweeper newMineSweeper = Core.unityDoMove (mineSweeper, Core.CanCorrect, move);
									// set new position bytes
									if (newMineSweeper != null) {
										mineSweeper = newMineSweeper;
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
							Debug.LogWarning (Core.unityGetStrPosition (mineSweeper, Core.CanCorrect));
							switch (gameFinish) {
							case 1:
								Debug.LogWarning ("you win: " + turn);
								break;
							case 2:
								Debug.LogWarning ("you lose: " + turn);
								break;
							default:
								break;
							}
							break;
						}
						System.Threading.Thread.Sleep (500);
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
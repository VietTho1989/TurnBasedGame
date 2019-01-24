using UnityEngine;
using System.IO;
using System.Collections;
using System.Threading;
using Foundation.Tasks;

namespace Janggi
{
	public class TestJanggi
	{

		class Work 
		{

			public Work()
			{
				
			}

			public void DoWork() 
			{
				// DevelopmentTest developmentTest = new DevelopmentTest ();
				// Debug.LogError ("developmentTest finish: " + developmentTest);
				// make start
				Janggi startJanggi = Core.makeDefaultPosition ();
				// Make a match
				{
					int turn = 0;
					Janggi janggi = startJanggi;
					do{
						Debug.Log("before letComputerThink: "+turn);
						Debug.Log("positionToString: "+turn+"\n"+Core.getStrPosition(janggi));

						// TODO cai nay de phong
						// Debug.LogError("positionToFen: \n"+Core.unityPositionToFen(positionBytes));
						int gameFinish = Core.isGameFinish(janggi);
						if(gameFinish==0){
							JanggiMove move = Core.letComputerThink(janggi, 50000);
							if(move.fromX.v!=0 || move.fromY.v!=0 || move.toX.v!=0 || move.toY.v!=0){
								if(Core.isLegalMove(janggi, move)){
									Janggi newJanggi = Core.doMove(janggi, move);
									// set new position bytes
									DataUtils.copyData(janggi, newJanggi);
								}else{
									Debug.LogError("why not legal move: "+ move);
									break;
								}
							}else{
								Debug.LogError("why don't find any move, break");
							}
							turn++;
						}else{
							Debug.LogWarning("game finish in turn: "+ turn+"; "+gameFinish+ "; positionToString: \n"+Core.getStrPosition(janggi));
							switch (gameFinish) {
							case 1:
								Debug.LogWarning("silver win");
								break;
							case 2:
								Debug.LogWarning("red win");
								break;
							case 3:
								Debug.LogWarning("the game is draw");
								break;
							default:
								Debug.LogWarning("unknown gameFinish: "+gameFinish);
								break;
							}
							break;
						}
						System.Threading.Thread.Sleep(1000);
					}while (!Test.stop);
				}
			}

		}

		public static void startTestMatch(int matchCount)
		{
			for (int i = 0; i < matchCount; i++) {
				Work w = new Work();
				{
					// startThread
					ThreadStart threadDelegate = new ThreadStart (w.DoWork);
					Thread newThread = new Thread (threadDelegate, 1048576);
					newThread.Start ();
				}
			}
		}

	}
}
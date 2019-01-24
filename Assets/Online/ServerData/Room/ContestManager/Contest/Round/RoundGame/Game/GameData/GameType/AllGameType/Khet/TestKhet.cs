using UnityEngine;
using System.IO;
using System.Collections;
using System.Threading;
using Foundation.Tasks;

namespace Khet
{
	public class TestKhet
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
				// get startFen
				string startFen = Khet.Standard;
				{
					switch (rnd.Next (3)) {
					case 0:
						startFen = Khet.Standard;
						break;
					case 1:
						startFen = Khet.Dynasty;
						break;
					case 2:
						startFen = Khet.Imhotep;
						break;
					default:
						Debug.LogError ("unknown random");
						break;
					}
				}
				// make start
				Khet startKhet = Core.unityMakePositionByFen (startFen);
				// Make a match
				{
					int turn = 0;
					Khet khet = startKhet;
					do{
						Debug.Log("before letComputerThink: "+turn);
						Debug.Log("positionToString: "+turn+"\n"+Core.unityGetStrPosition(khet, Core.CanCorrect));

						// TODO cai nay de phong
						// Debug.LogError("positionToFen: \n"+Core.unityPositionToFen(positionBytes));
						int gameFinish = Core.unityIsGameFinish(khet, true);
						if(gameFinish==0){
							uint move = Core.unityLetComputerThink(khet, true, false, 10000, 0, 90);
							if(move!=0){
								Debug.Log("test find ai move: "+turn+"; "+ move+"; "+ Core.unityGetStrMove(move));								// check legal move
								if(Core.unityIsLegalMove(khet, true, move)){
									Khet newKhet = Core.unityDoMove(khet, true, move);
									// set new position bytes
									DataUtils.copyData(khet, newKhet);
								}else{
									Debug.LogError("why not legal move: "+ move);
									break;
								}
							}else{
								Debug.LogError("why don't find any move, break");
							}
							turn++;
						}else{
							Debug.LogWarning("game finish in turn: "+ turn+"; "+gameFinish+ "; positionToString: \n"+Core.unityGetStrPosition(khet, Core.CanCorrect));
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
			System.Random rnd = new System.Random ();
			for (int i = 0; i < matchCount; i++) {
				Work w = new Work(rnd);
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

/*
p..*********
...**x...aka
...**..p....
p.P**...P...
p.P**p.P.ss.
...**p.P.SS.
P..**......p
..X**.......
*****..PAKA.
************

1..*********
...**2...202
...**..2....
1.3**...3...
0.2**0.2.01.
...**1.3.10.
0..**......1
..0**.......
*****..3000.
************
*/
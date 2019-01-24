using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using Foundation.Tasks;

namespace Shogi
{
	public class TestShogi
	{

		public static void startTestMatch(int matchCount)
		{
			for (int i = 0; i < matchCount; i++) {
				UnityTask.Run (() => { 
					Shogi startShogi = Core.unityMakePositionByFen (Shogi.DefaultStartPositionSFEN);
					// Make a match
					{
						int turn = 0;
						Shogi shogi = startShogi;
						do{
							Debug.Log("before letComputerThink: "+turn);
							Debug.Log("positionToString: "+turn+"\n"+ Common.printPosition(shogi));

							Debug.Log("positionToFen: \n"+Common.positionToFen(shogi));
							int gameFinish = Core.unityIsGameFinish(shogi, true);
							// Debug.LogError("gameFinish: "+gameFinish);
							if(gameFinish==0){
								uint move = Core.unityLetComputerThink(shogi, true, 19, 18, 0, 3000, true);
								if(move!=0){
									Debug.Log("test find ai move: "+turn+"; "+ move+"; "+Common.printMove(move));
									// check legal move
									if(Core.unityIsLegalMove(shogi, true, move)){
										Shogi newShogi = Core.unityDoMove(shogi, true, move);
										DataUtils.copyData(shogi, newShogi);
									}else{
										Debug.LogError("why not legal move: "+ move);
										break;
									}
								}else{
									Debug.LogError("why don't find any move, break");
								}
								turn++;
							}else{
								Debug.LogWarning("game finish in turn: "+ turn);
								Debug.LogWarning("positionToString: \n"+Common.printPosition(shogi));
								switch (gameFinish) {
								case 1:
									Debug.LogWarning("black win");
									break;
								case 2:
									Debug.LogWarning("white win");
									break;
								case 3:
									Debug.LogWarning("the game is draw");
									break;
								default:
									Debug.LogError("unknown gameFinish: "+gameFinish);
									break;
								}
								break;
							}
							System.Threading.Thread.Sleep(1000);
						}while (!Test.stop);
					}
				});
			}
		}

	}
}
/*
1+SG+L+P+P1+Np/2+S1KP+P+B+P/1+P+P3P+N1/4+r4/5p3/5l3/+n1+p+r+p+p2+s/1+p1+p+b+n+p1k/+pgg+lgs+l1+p b - 1
'  9  8  7  6  5  4  3  2  1
P1 * +NG+KI+NY+TO+TO * +NK-FU
P2 *  * +NG * +OU+FU+TO+UM+TO
P3 * +TO+TO *  *  * +FU+NK * 
P4 *  *  *  * -RY *  *  *  * 
P5 *  *  *  *  * -FU *  *  * 
P6 *  *  *  *  * -KY *  *  * 
P7-NK * -TO-RY-TO-TO *  * -NG
P8 * -TO * -TO-UM-NK-TO * -OU
P9-TO-KI-KI-NY-KI-GI-NY * -TO
+
*/
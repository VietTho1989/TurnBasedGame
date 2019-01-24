using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Foundation.Tasks;

namespace Shatranj
{
	public class TestShatranj
	{

		public static void startTestMatch(int matchCount)
		{
			for (int i = 0; i < matchCount; i++) {
				UnityTask.Run (() => { 
					bool chess960 = false;
					Shatranj startShatranj = Core.unityMakePositionByFen (Shatranj.DefaultFen, chess960);
					// Make a match
					{
						int turn = 0;
						Shatranj shatranj = startShatranj;
						do{
							Debug.Log("before letComputerThink: "+turn);
							Debug.Log("positionToString: "+turn+"\n"+Common.positionToString(shatranj));

							// TODO cai nay de phong
							// Debug.LogError("positionToFen: \n"+Core.unityPositionToFen(positionBytes));
							int gameFinish = Core.unityIsGameFinish(shatranj, true);
							if(gameFinish==0){
								int move = Core.unityLetComputerThink(shatranj, true, 10, 19, 6000);
								if(move!=0){
									Debug.Log("test find ai move: "+turn+"; "+ move+"; "+Common.moveToString(move, chess960));
									// check legal move
									if(Core.unityIsLegalMove(shatranj, true, move)){
										Shatranj newShatranj = Core.unityDoMove(shatranj, true, move);
										// set new position bytes
										DataUtils.copyData(shatranj, newShatranj);
									}else{
										Debug.LogError("why not legal move: "+ move);
										break;
									}
								}else{
									Debug.LogError("why don't find any move, break");
								}
								turn++;
							}else{
								Debug.LogWarning("game finish in turn: "+ turn+"; "+gameFinish+ "; positionToString: \n"+Common.positionToString(shatranj));
								switch (gameFinish) {
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
									Debug.LogWarning("unknown gameFinish: "+gameFinish);
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
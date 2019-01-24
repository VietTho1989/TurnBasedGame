using UnityEngine;
using System.Collections;
using Foundation.Tasks;

namespace Weiqi
{
	public class TestWeiqi
	{

		public static void startTestMatch(int matchCount)
		{
			UnityTask.Run (() => {
				System.Random random = new System.Random();
				while (!Test.stop) {
					System.Threading.Thread.Sleep(120000);
					int r = random.Next(100);
					if(r<90){
						if(r<40){
							Debug.Log("set book file wrong");
							Core.setNewFile("/Users/viettho/Desktop/NewProject/TurnbaseGame/NativeCode/Go/oldweiqi/Resources/spat.txt", "/Users/viettho/Desktop/NewProject/TurnbaseGame/NativeCode/Go/oldweiqi/Resources/prob.txt");
						}else{
							Debug.Log("set book file correct\n");
							Core.setNewFile("/Users/viettho/Desktop/NewProject/TurnbaseGame/Assets/Plugins/Weiqi/Weiqi.bundle/Contents/Resources/patterns.spat", "/Users/viettho/Desktop/NewProject/TurnbaseGame/Assets/Plugins/Weiqi/Weiqi.bundle/Contents/Resources/patterns.prob");
						}
					}
				}
			});

			for (int i = 0; i < matchCount; i++) {
				UnityTask.Run (() => { 
					Weiqi startWeiqi =  null;
					{
						int size = 19;
						float komi = 5.5f;
						int rule = (int)Common.go_ruleset.RULES_JAPANESE;
						int handicap = 0;
						startWeiqi = Core.unityMakeDefaultPosition(size, komi, rule, handicap);
					}
					// Make a match
					{
						int turn = 0;
						Weiqi weiqi = startWeiqi;
						do{
							Debug.LogError(string.Format("before letComputerThink: {0}, {1}", turn, weiqi.b.v.moves.v));
							Debug.LogError(Common.printPosition(weiqi));
							int gameFinish = Core.unityIsGameFinish(weiqi, true);
							Debug.LogError("gameFinish: "+gameFinish);
							if(gameFinish==0){
								// letComputerThink
								bool canResign = true;
								bool useBook = false;
								int time = 300;
								int games = -1;
								int engine = (int)Common.engine_id.E_UCT;
								WeiqiMove move = Core.unityLetComputerThink(weiqi, true, canResign, useBook, time, games, engine);
								// print move to string
								Debug.LogError("find ai move: "+Common.printMove(move));
								{
									// check legal move
									if(Core.unityIsLegalMove(weiqi, true, move)){
										// do move
										Weiqi newWeiqi = Core.unityDoMove(weiqi, true, move, false);
										// set new position bytes
										if(newWeiqi!=null){
											weiqi = newWeiqi;
										}else{
											Debug.LogError("error, do move");
											break;
										}
									}else{
										Debug.LogError("error: why not legal move: "+move);
										break;
									}
								}
								turn++;
							}else{
								Debug.LogWarning("game finish in turn: "+turn);
								Debug.LogWarning(Common.printPosition(weiqi));
								switch (gameFinish) {
								case 1:
									Debug.LogWarning("black win: "+ turn);
									break;
								case 2:
									Debug.LogWarning("white win: "+ turn);
									break;
								case 3:
									Debug.LogWarning("the game is draw: "+turn);
									break;
								default:
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
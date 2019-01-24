using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
	public class GameCheckEndUpdate : UpdateBehavior<Game>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					State state = this.data.state.v;
					if (state != null) {
						switch (state.getType ()) {
						case State.Type.Load:
							break;
						case State.Type.Start:
							break;
						case State.Type.Play:
						case State.Type.End:
							{
								// Find result
								bool alreadyEndGame = false;
								List<Result> results = new List<Result> ();
								{
									// Draw
									if (!alreadyEndGame) {
										RequestDraw requestDraw = this.data.requestDraw.v;
										if (requestDraw != null) {
											if (requestDraw.state.v.getType () == RequestDraw.State.Type.Accept) {
												alreadyEndGame = true;
												foreach(GamePlayer gamePlayer in this.data.gamePlayers.vs) {
													// Make result
													{
														Result result = new Result ();
														{
															result.playerIndex.v = gamePlayer.playerIndex.v;
															result.score.v = 0;
															result.reason.v = Result.Reason.RequestDraw;
														}
														results.Add (result);
													}
												}
											}
										} else {
											Debug.LogError ("requestDraw null: " + this);
										}
									}
									// Surrender
									if (!alreadyEndGame) {
										if (this.data.gamePlayers.vs.Count > 0) {
											// get surrender result
											List<Result> surrenderResults = new List<Result>();
											int surrenderCount = 0;
											{
												foreach(GamePlayer gamePlayer in this.data.gamePlayers.vs) {
													// Make result
													{
														Result result = new Result ();
														{
															result.playerIndex.v = gamePlayer.playerIndex.v;
															if (gamePlayer.state.v.getType () == GamePlayer.State.Type.Surrender) {
																result.score.v = 0;
																result.reason.v = Result.Reason.Surrender;
																surrenderCount++;
															} else {
																result.score.v = 1;
																result.reason.v = Result.Reason.EnemySurrender;
															}
														}
														surrenderResults.Add (result);
													}
												}
											}
											// Process
											if ((surrenderCount == 1 && this.data.gamePlayers.vs.Count == 1) 
												|| (surrenderCount == this.data.gamePlayers.vs.Count - 1 && this.data.gamePlayers.vs.Count >= 2)) {
												alreadyEndGame = true;
												results.AddRange (surrenderResults);
											}
										} else {
											Debug.LogError ("why don't have any gamePlayers");
										}
									}
									// TimeOut
									if (!alreadyEndGame) {
										// Find timeControl
										TimeControl.TimeControl timeControl = null;
										{
											GameData gameData = this.data.gameData.v;
											if (gameData != null) {
												timeControl = gameData.timeControl.v;
											} else {
												Debug.LogError ("gameData null: " + this);
											}
										}
										// Process
										if (timeControl != null) {
											if (timeControl.isEnable.v) {
												bool haveTimeOutPlayer = false;
												List<Result> timeOutResults = new List<Result> ();
												{
													if (timeControl.timeOutPlayers.vs.Count > 0) {
														foreach (GamePlayer gamePlayer in this.data.gamePlayers.vs) {
															// Make result
															Result result = new Result ();
															{
																result.playerIndex.v = gamePlayer.playerIndex.v;
																if (timeControl.timeOutPlayers.vs.Contains (gamePlayer.playerIndex.v)) {
																	haveTimeOutPlayer = true;
																	result.score.v = 0;
																	result.reason.v = Result.Reason.TimeOut;
																} else {
																	result.score.v = 1;
																	result.reason.v = Result.Reason.EnemyTimeOut;
																}
															}
															timeOutResults.Add (result);
														}
													}
												}
												if (haveTimeOutPlayer) {
													alreadyEndGame = true;
													results.AddRange (timeOutResults);
												}
											} else {
												Debug.LogError ("time not enable");
											}
										} else {
											Debug.LogError ("timeControl null: " + this);
										}
									}
									// CheckMate
									if (!alreadyEndGame) {
										GameData gameData = this.data.gameData.v;
										if (gameData != null) {
											if (gameData.state.v is GameDataStateFinish) {
												GameDataStateFinish gameDataStateFinish = gameData.state.v as GameDataStateFinish;
												alreadyEndGame = true;
												// check game is draw?
												bool isGameDraw = false;
												{
													if (gameDataStateFinish.playerResults.vs.Count >= 2) {
														// check have different score
														bool haveDifferentScore = false;
														{
															for (int i = 0; i < gameDataStateFinish.playerResults.vs.Count - 1; i++) {
																if (gameDataStateFinish.playerResults.vs [i].score.v != gameDataStateFinish.playerResults.vs [i + 1].score.v) {
																	haveDifferentScore = true;
																	break;
																}
															}
														}
														// Process
														if (haveDifferentScore) {
															isGameDraw = false;
														} else {
															isGameDraw = true;
														}
													}
												}
												foreach(GamePlayer gamePlayer in this.data.gamePlayers.vs) {
													// Make result
													Result result = new Result();
													{
														result.playerIndex.v = gamePlayer.playerIndex.v;
														// set score
														{
															if (isGameDraw) {
																result.score.v = 0;
																result.reason.v = Result.Reason.GameDraw;
															} else {
																PlayerResult playerResult = gameDataStateFinish.getPlayerResult (gamePlayer.playerIndex.v);
																if (playerResult != null) {
																	result.score.v = playerResult.score.v;
																	result.reason.v = playerResult.score.v == 0 ? Result.Reason.CheckMated : Result.Reason.CheckMate;
																} else {
																	Debug.LogError ("playerResult null: " + this);
																	result.score.v = 0;
																	result.reason.v = Result.Reason.CheckMated;
																}
															}
														}
													}
													results.Add (result);
												}
											}
										} else {
											Debug.LogError ("gameData null: " + this);
										}
									}
								}
								// Process
								if (alreadyEndGame) {
									// Find End
									End end = null;
									{
										if (this.data.state.v is End) {
											end = this.data.state.v as End;
										} else {
											end = new End ();
											{
												end.uid = this.data.state.makeId ();
											}
											this.data.state.v = end;
										}
									}
									// Update Property
									{
										// Get old
										List<Result> oldResults = new List<Result> ();
										{
											oldResults.AddRange (end.results.vs);
										}
										// Update
										{
											foreach (Result result in results) {
												// Update old
												if (oldResults.Count > 0) {
													DataUtils.copyData (oldResults [0], result);
													oldResults.RemoveAt (0);
												}
												// Make new
												else {
													result.uid = end.results.makeId ();
													end.results.add (result);
												}
											}
										}
										// Remove old
										foreach (Result oldResult in oldResults) {
											end.results.remove (oldResult);
										}
									}
								} else {
									// Chuyen sang play
									if (!(this.data.state.v is Play)) {
										Play play = new Play ();
										{
											play.uid = this.data.state.makeId ();
										}
										this.data.state.v = play;
									}
								}
							}
							break;
						default:
							Debug.LogError ("unknown state: " + state.getType () + "; " + this);
							break;
						}
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		public override void onAddCallBack<T> (T data)
		{
			if (data is Game) {
				Game game = data as Game;
				// Child
				{
					game.requestDraw.allAddCallBack (this);
					game.gamePlayers.allAddCallBack (this);
					game.gameData.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is RequestDraw) {
					dirty = true;
					return;
				}
				if (data is GamePlayer) {
					dirty = true;
					return;
				}
				// GameData
				{
					if (data is GameData) {
						GameData gameData = data as GameData;
						// Child
						{
							gameData.timeControl.allAddCallBack (this);
							gameData.state.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is TimeControl.TimeControl) {
							dirty = true;
							return;
						}
						// GameDataState
						{
							if (data is GameData.State) {
								GameData.State state = data as GameData.State;
								// Child
								{
									switch (state.getType ()) {
									case GameData.State.Type.Normal:
										break;
									case GameData.State.Type.Finish:
										{
											GameDataStateFinish finish = state as GameDataStateFinish;
											finish.playerResults.allAddCallBack (this);
										}
										break;
									default:
										Debug.LogError ("unknown type: " + state.getType () + "; " + this);
										break;
									}
								}
								dirty = true;
								return;
							}
							// Child
							if (data is PlayerResult) {
								dirty = true;
								return;
							}
						}
					}
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is Game) {
				Game game = data as Game;
				// Child
				{
					game.requestDraw.allRemoveCallBack (this);
					game.gamePlayers.allRemoveCallBack (this);
					game.gameData.allRemoveCallBack (this);
				}
				this.setDataNull (game);
				return;
			}
			// Child
			{
				if (data is RequestDraw) {
					return;
				}
				if (data is GamePlayer) {
					return;
				}
				// GameData
				{
					if (data is GameData) {
						GameData gameData = data as GameData;
						// Child
						{
							gameData.timeControl.allRemoveCallBack (this);
							gameData.state.allAddCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is TimeControl.TimeControl) {
							return;
						}
						// GameDataState
						{
							if (data is GameData.State) {
								GameData.State state = data as GameData.State;
								// Child
								{
									switch (state.getType ()) {
									case GameData.State.Type.Normal:
										break;
									case GameData.State.Type.Finish:
										{
											GameDataStateFinish finish = state as GameDataStateFinish;
											finish.playerResults.allRemoveCallBack (this);
										}
										break;
									default:
										Debug.LogError ("unknown type: " + state.getType () + "; " + this);
										break;
									}
								}
								return;
							}
							// Child
							if (data is PlayerResult) {
								return;
							}
						}
					}
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is Game) {
				switch ((Game.Property)wrapProperty.n) {
				case Game.Property.gamePlayers:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case Game.Property.requestDraw:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case Game.Property.state:
					break;
				case Game.Property.gameData:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case Game.Property.history:
					break;
				case Game.Property.gameAction:
					break;
				case Game.Property.undoRedoRequest:
					break;
				case Game.Property.chatRoom:
					break;
				case Game.Property.animationData:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			{
				if (wrapProperty.p is RequestDraw) {
					switch ((RequestDraw.Property)wrapProperty.n) {
					case RequestDraw.Property.state:
						dirty = true;
						break;
					case RequestDraw.Property.time:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is GamePlayer) {
					switch ((GamePlayer.Property)wrapProperty.n) {
					case GamePlayer.Property.playerIndex:
						break;
					case GamePlayer.Property.inform:
						break;
					case GamePlayer.Property.state:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// GameData
				{
					if (wrapProperty.p is GameData) {
						switch ((GameData.Property)wrapProperty.n) {
						case GameData.Property.gameType:
							break;
						case GameData.Property.useRule:
							break;
						case GameData.Property.turn:
							break;
						case GameData.Property.timeControl:
							{
								ValueChangeUtils.replaceCallBack(this, syncs);
								dirty = true;
							}
							break;
						case GameData.Property.lastMove:
							break;
						case GameData.Property.state:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					{
						if (wrapProperty.p is TimeControl.TimeControl) {
							switch ((TimeControl.TimeControl.Property)wrapProperty.n) {
							case TimeControl.TimeControl.Property.isEnable:
								dirty = true;
								break;
							case TimeControl.TimeControl.Property.aiCanTimeOut:
								break;
							case TimeControl.TimeControl.Property.timeOutPlayers:
								dirty = true;
								break;
							case TimeControl.TimeControl.Property.sub:
								break;
							case TimeControl.TimeControl.Property.use:
								break;
							case TimeControl.TimeControl.Property.timeReport:
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						// GameDataState
						{
							if (wrapProperty.p is GameData.State) {
								GameData.State state = wrapProperty.p as GameData.State;
								{
									switch (state.getType ()) {
									case GameData.State.Type.Normal:
										break;
									case GameData.State.Type.Finish:
										{
											switch ((GameDataStateFinish.Property)wrapProperty.n) {
											case GameDataStateFinish.Property.playerResults:
												{
													ValueChangeUtils.replaceCallBack (this, syncs);
													dirty = true;
												}
												break;
											default:
												Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
												break;
											}
										}
										break;
									default:
										Debug.LogError ("unknown type: " + state.getType () + "; " + this);
										break;
									}
								}
								return;
							}
							// Child
							if (wrapProperty.p is PlayerResult) {
								switch ((PlayerResult.Property)wrapProperty.n) {
								case PlayerResult.Property.playerIndex:
									dirty = true;
									break;
								case PlayerResult.Property.score:
									dirty = true;
									break;
								default:
									Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
									break;
								}
								return;
							}
						}
					}
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
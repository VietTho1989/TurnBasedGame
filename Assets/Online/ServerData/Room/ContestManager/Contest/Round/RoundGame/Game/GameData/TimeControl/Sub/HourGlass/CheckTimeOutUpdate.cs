using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.HourGlass
{
	public class CheckTimeOutUpdate : UpdateBehavior<TimeControlHourGlass>
	{

		#region update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// Get playerIndex
					int playerIndex = 0;
					{
						// Find Turn
						Turn turn = null;
						{
							GameData gameData = this.data.findDataInParent<GameData> ();
							if (gameData != null) {
								turn = gameData.turn.v;
							} else {
								Debug.LogError ("gameData null: " + this);
							}
						}
						if (turn != null) {
							playerIndex = turn.playerIndex.v;
						} else {
							Debug.LogError ("turn null: " + this);
						}
					}
					// Check timeout
					List<int> playerTimeOuts = new List<int>();
					{
						TimeControl timeControl = this.data.findDataInParent<TimeControl> ();
						if (timeControl != null) {
							// Find serverPerTime
							float serverTurnTime = 0;
							{
								WaitInputAction waitInputAction = null;
								{
									Game game = this.data.findDataInParent<Game> ();
									if (game != null) {
										if (game.gameAction.v != null && game.gameAction.v is WaitInputAction) {
											waitInputAction = game.gameAction.v as WaitInputAction;
										}
									} else {
										Debug.LogError ("game null: " + this);
									}
								}
								if (waitInputAction != null) {
									serverTurnTime = waitInputAction.serverTime.v;
								} else {
									// Debug.LogError ("waitInputAction null: " + this);
								}
							}
							// Process
							switch (timeControl.use.v) {
							case TimeControl.Use.ServerTime:
								{
									foreach (PlayerTime playerTime in this.data.playerTimes.vs) {
										if (playerTime.playerIndex.v == playerIndex) {
											if (playerTime.serverTime.v - serverTurnTime <= 0) {
												Debug.LogError ("serverTimeOut: " + playerTime);
												playerTimeOuts.Add (playerTime.playerIndex.v);
											}
										} else {
											if (playerTime.serverTime.v <= 0) {
												playerTimeOuts.Add (playerTime.playerIndex.v);
											}
										}
									}
								}
								break;
							case TimeControl.Use.ClientTime:
								{
									// Get Report Time
									float reportTime = 0;
									{
										// Find TimeReportClient
										TimeReportClient timeReportClient = null;
										{
											if (timeControl.timeReport.v != null) {
												if (timeControl.timeReport.v is TimeReportClient) {
													timeReportClient = timeControl.timeReport.v as TimeReportClient;
												}
											} else {
												Debug.LogError ("timeReport null: " + this);
											}
										}
										// Process
										if (timeReportClient != null) {
											reportTime = timeReportClient.reportTime.v;
										} else {
											// Debug.LogError ("timeReportClient null: " + this);
										}
									}
									// get lag compensation time
									float lagCompensation = 0;
									{
										PlayerTime playerTime = this.data.getPlayerTime (playerIndex);
										if (playerTime != null) {
											lagCompensation = playerTime.lagCompensation.v;
										} else {
											Debug.LogError ("playerTime null: " + this);
										}
									}
									// get checkTime
									float checkTime = (serverTurnTime >= reportTime + lagCompensation) ? serverTurnTime : reportTime;
									// Check
									foreach (PlayerTime playerTime in this.data.playerTimes.vs) {
										if (playerTime.playerIndex.v == playerIndex) {
											if (playerTime.clientTime.v - checkTime <= 0) {
												Debug.LogError ("clientTimeOut: " + playerTime + "; " + checkTime);
												playerTimeOuts.Add (playerTime.playerIndex.v);
											}
										} else {
											if (playerTime.clientTime.v <= 0) {
												playerTimeOuts.Add (playerTime.playerIndex.v);
											}
										}
									}
								}
								break;
							default:
								Debug.LogError ("unknown use: " + timeControl.use.v + "; " + this);
								break;
							}
						} else {
							Debug.LogError ("timeControl null: " + this);
						}
					}
					// Process
					{
						TimeControl timeControl = this.data.findDataInParent<TimeControl> ();
						if (timeControl != null) {
							// remove ai if ai cannot timeout
							if (!timeControl.aiCanTimeOut.v) {
								Game game = this.data.findDataInParent<Game> ();
								if (game != null) {
									foreach (GamePlayer gamePlayer in game.gamePlayers.vs) {
										if (gamePlayer.inform.v != null && gamePlayer.inform.v.getType () == GamePlayer.Inform.Type.Computer) {
											if (playerTimeOuts.Remove (gamePlayer.playerIndex.v)) {
												Debug.LogError ("remove timeout ai: " + gamePlayer);
											}
										}
									}
								} else {
									Debug.LogError ("duel null: " + this);
								}
							}
							// add
							{
								// remove not in any more
								for (int i = timeControl.timeOutPlayers.vs.Count - 1; i >= 0; i--) {
									int check = timeControl.timeOutPlayers.vs [i];
									if (!playerTimeOuts.Contains (check)) {
										Debug.LogError ("not time out anymore: " + check);
										timeControl.timeOutPlayers.removeAt (i);
									}
								}
								// add new
								foreach (int playerTimeOut in playerTimeOuts) {
									if (!timeControl.timeOutPlayers.vs.Contains (playerTimeOut)) {
										timeControl.timeOutPlayers.add (playerTimeOut);
									}
								}
							}
						} else {
							Debug.LogError ("timeControl null: " + this);
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

		private GameData gameData = null;
		private Game game = null;
		private TimeControl timeControl = null;

		private GameCheckPlayerChange<TimeControlHourGlass> gameCheckPlayerChange = new GameCheckPlayerChange<TimeControlHourGlass>();

		public override void onAddCallBack<T> (T data)
		{
			if (data is TimeControlHourGlass) {
				TimeControlHourGlass timeControlHourGlass = data as TimeControlHourGlass;
				// CheckChange
				{
					gameCheckPlayerChange.addCallBack (this);
					gameCheckPlayerChange.setData (timeControlHourGlass);
				}
				// Parent
				{
					DataUtils.addParentCallBack (timeControlHourGlass, this, ref this.gameData);
					DataUtils.addParentCallBack (timeControlHourGlass, this, ref this.game);
					DataUtils.addParentCallBack (timeControlHourGlass, this, ref this.timeControl);
				}
				// Child
				{
					timeControlHourGlass.playerTimes.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is GameCheckPlayerChange<TimeControlHourGlass>) {
				dirty = true;
				return;
			}
			// Parent
			{
				// GameData
				{
					if (data is GameData) {
						GameData gameData = data as GameData;
						// Child
						{
							gameData.turn.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					if (data is Turn) {
						dirty = true;
						return;
					}
				}
				// Game
				{
					if (data is Game) {
						Game game = data as Game;
						// Child
						{
							game.gameAction.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// GameAction
					if (data is GameAction) {
						dirty = true;
						return;
					}
				}
				// TimeControl
				{
					if (data is TimeControl) {
						TimeControl timeControl = data as TimeControl;
						// Child
						{
							timeControl.timeReport.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					if (data is TimeReport) {
						dirty = true;
						return;
					}
				}
			}
			// Child
			if (data is PlayerTime) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is TimeControlHourGlass) {
				TimeControlHourGlass timeControlHourGlass = data as TimeControlHourGlass;
				// CheckChange
				{
					gameCheckPlayerChange.removeCallBack (this);
					gameCheckPlayerChange.setData (null);
				}
				// Parent
				{
					DataUtils.removeParentCallBack (timeControlHourGlass, this, ref this.gameData);
					DataUtils.removeParentCallBack (timeControlHourGlass, this, ref this.game);
					DataUtils.removeParentCallBack (timeControlHourGlass, this, ref this.timeControl);
				}
				// Child
				{
					timeControlHourGlass.playerTimes.allRemoveCallBack (this);
				}
				this.setDataNull (timeControlHourGlass);
				return;
			}
			// CheckChange
			if (data is GameCheckPlayerChange<TimeControlHourGlass>) {
				return;
			}
			// Parent
			{
				// GameData
				{
					if (data is GameData) {
						GameData gameData = data as GameData;
						// Child
						{
							gameData.turn.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					if (data is Turn) {
						return;
					}
				}
				// Game
				{
					if (data is Game) {
						Game game = data as Game;
						// Child
						{
							game.gameAction.allRemoveCallBack (this);
						}
						return;
					}
					// GameAction
					if (data is GameAction) {
						return;
					}
				}
				// TimeControl
				{
					if (data is TimeControl) {
						TimeControl timeControl = data as TimeControl;
						// Child
						{
							timeControl.timeReport.allRemoveCallBack (this);
						}
						return;
					}
					if (data is TimeReport) {
						return;
					}
				}
			}
			// Child
			if (data is PlayerTime) {
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is TimeControlHourGlass) {
				switch ((TimeControlHourGlass.Property)wrapProperty.n) {
				case TimeControlHourGlass.Property.initTime:
					break;
				case TimeControlHourGlass.Property.lagCompensation:
					break;
				case TimeControlHourGlass.Property.playerTimes:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			if (wrapProperty.p is GameCheckPlayerChange<TimeControlHourGlass>) {
				dirty = true;
				return;
			}
			// Parent
			{
				// GameData
				{
					if (wrapProperty.p is GameData) {
						switch ((GameData.Property)wrapProperty.n) {
						case GameData.Property.gameType:
							break;
						case GameData.Property.useRule:
							break;
						case GameData.Property.turn:
							{
								ValueChangeUtils.replaceCallBack(this, syncs);
								dirty = true;
							}
							break;
						case GameData.Property.timeControl:
							break;
						case GameData.Property.lastMove:
							break;
						case GameData.Property.state:
							break;
						default:
							Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					if (wrapProperty.p is Turn) {
						switch ((Turn.Property)wrapProperty.n) {
						case Turn.Property.turn:
							break;
						case Turn.Property.playerIndex:
							dirty = true;
							break;
						case Turn.Property.gameTurn:
							break;
						default:
							Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
				}
				// Game
				{
					if (wrapProperty.p is Game) {
						switch ((Game.Property)wrapProperty.n) {
						case Game.Property.gameData:
							break;
						case Game.Property.history:
							break;
						case Game.Property.gameAction:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case Game.Property.undoRedoRequest:
							break;
						default:
							Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// GameAction
					if (wrapProperty.p is GameAction) {
						if (wrapProperty.p is WaitInputAction) {
							switch ((WaitInputAction.Property)wrapProperty.n) {
							case WaitInputAction.Property.serverTime:
								dirty = true;
								break;
							case WaitInputAction.Property.clientTime:
								break;
							case WaitInputAction.Property.sub:
								break;
							case WaitInputAction.Property.inputs:
								break;
							case WaitInputAction.Property.clientInput:
								break;
							default:
								Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						return;
					}
				}
				// TimeControl
				{
					if (wrapProperty.p is TimeControl) {
						switch ((TimeControl.Property)wrapProperty.n) {
						case TimeControl.Property.isEnable:
							break;
						case TimeControl.Property.aiCanTimeOut:
							dirty = true;
							break;
						case TimeControl.Property.timeOutPlayers:
							dirty = true;
							break;
						case TimeControl.Property.sub:
							break;
						case TimeControl.Property.use:
							dirty = true;
							break;
						case TimeControl.Property.timeReport:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						default:
							Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					if (wrapProperty.p is TimeReport) {
						if (wrapProperty.p is TimeReportClient) {
							switch ((TimeReportClient.Property)wrapProperty.n) {
							case TimeReportClient.Property.userId:
								break;
							case TimeReportClient.Property.delta:
								break;
							case TimeReportClient.Property.reportTime:
								dirty = true;
								break;
							case TimeReportClient.Property.clientState:
								break;
							default:
								Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						if (wrapProperty.p is TimeReportNone) {
							return;
						}
						return;
					}
				}
			}
			// Child
			if (wrapProperty.p is PlayerTime) {
				switch ((PlayerTime.Property)wrapProperty.n) {
				case PlayerTime.Property.playerIndex:
					dirty = true;
					break;
				case PlayerTime.Property.serverTime:
					dirty = true;
					break;
				case PlayerTime.Property.clientTime:
					dirty = true;
					break;
				case PlayerTime.Property.lagCompensation:
					dirty = true;
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
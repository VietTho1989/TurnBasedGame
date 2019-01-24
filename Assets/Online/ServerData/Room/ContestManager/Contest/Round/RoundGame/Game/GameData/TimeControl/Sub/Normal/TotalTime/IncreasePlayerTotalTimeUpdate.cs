using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
	public class IncreasePlayerTotalTimeUpdate : UpdateBehavior<TimeControlNormal>
	{

		#region update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// Find ProcessMoveAction
					ProcessMoveAction processMoveAction = null;
					{
						Game game = this.data.findDataInParent<Game> ();
						if (game != null) {
							if (game.gameAction.v != null && game.gameAction.v is ProcessMoveAction) {
								processMoveAction = game.gameAction.v as ProcessMoveAction;
							}
						} else {
							Debug.LogError ("game null: " + this);
						}
					}
					// Find PlayerIndex
					int playerIndex = 0;
					{
						GameData gameData = this.data.findDataInParent<GameData> ();
						if (gameData != null) {
							Turn turn = gameData.turn.v;
							if (turn != null) {
								playerIndex = turn.playerIndex.v;
							} else {
								Debug.LogError ("turn null: " + this);
							}
						} else {
							Debug.LogError ("gameData null: " + this);
						}
					}
					// Process
					if (processMoveAction != null) {
						// Find PlayerTotalTime
						PlayerTotalTime playerTotalTime = this.data.getPlayerTotalTime(playerIndex);
						if (playerTotalTime != null) {
							switch (processMoveAction.state.v) {
							case ProcessMoveAction.State.Process:
								break;
							case ProcessMoveAction.State.Processing:
								break;
							case ProcessMoveAction.State.End:
								{
									InputData inputData = processMoveAction.inputData.v;
									if (inputData != null) {
										playerTotalTime.serverTime.v = playerTotalTime.serverTime.v + inputData.serverTime.v;
										playerTotalTime.clientTime.v = playerTotalTime.clientTime.v + inputData.clientTime.v;
									} else {
										Debug.LogError ("inputData null: " + this);
									}
								}
								break;
							default:
								Debug.LogError ("unknown state: " + processMoveAction.state.v + "; " + this);
								break;
							}
						} else {
							Debug.LogError ("playerTotalTime null: " + this);
						}
					} else {
						// Debug.LogError ("processMoveAction null: " + this);
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

		private Game game = null;
		private GameData gameData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is TimeControlNormal) {
				TimeControlNormal timeControlNormal = data as TimeControlNormal;
				// Parent
				{
					DataUtils.addParentCallBack (timeControlNormal, this, ref this.game);
					DataUtils.addParentCallBack (timeControlNormal, this, ref this.gameData);
				}
				// Child
				{
					timeControlNormal.playerTotalTimes.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			{
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
					{
						if (data is GameAction) {
							GameAction gameAction = data as GameAction;
							// Inherit
							{
								if (gameAction is ProcessMoveAction) {
									ProcessMoveAction processMoveAction = gameAction as ProcessMoveAction;
									// Child
									{
										processMoveAction.inputData.allAddCallBack (this);
									}
								}
							}
							dirty = true;
							return;
						}
						if (data is InputData) {
							dirty = true;
							return;
						}
					}
				}
				// GameData
				{
					if (data is GameData) {
						GameData gameData = data as GameData;
						{
							gameData.turn.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					if (data is Turn) {
						dirty = true;
						return;
					}
				}
			}
			// Child
			if (data is PlayerTotalTime) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is TimeControlNormal) {
				TimeControlNormal timeControlNormal = data as TimeControlNormal;
				// Parent
				{
					DataUtils.addParentCallBack (timeControlNormal, this, ref this.game);
					DataUtils.addParentCallBack (timeControlNormal, this, ref this.gameData);
				}
				// Child
				{
					timeControlNormal.playerTotalTimes.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			{
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
					{
						if (data is GameAction) {
							GameAction gameAction = data as GameAction;
							// Inherit
							{
								if (gameAction is ProcessMoveAction) {
									ProcessMoveAction processMoveAction = gameAction as ProcessMoveAction;
									// Child
									{
										processMoveAction.inputData.allAddCallBack (this);
									}
								}
							}
							dirty = true;
							return;
						}
						if (data is InputData) {
							dirty = true;
							return;
						}
					}
				}
				// GameData
				{
					if (data is GameData) {
						GameData gameData = data as GameData;
						{
							gameData.turn.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					if (data is Turn) {
						dirty = true;
						return;
					}
				}
			}
			// Child
			if (data is PlayerTotalTime) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is TimeControlNormal) {
				switch ((TimeControlNormal.Property)wrapProperty.n) {
				case TimeControlNormal.Property.generalInfo:
					break;
				case TimeControlNormal.Property.playerTimeInfos:
					break;
				case TimeControlNormal.Property.playerTotalTimes:
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
			// Parent
			{
				// Game
				{
					if (wrapProperty.p is Game) {
						switch ((Game.Property)wrapProperty.n) {
						case Game.Property.gamePlayers:
							break;
						case Game.Property.requestDraw:
							break;
						case Game.Property.state:
							break;
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
					{
						if (wrapProperty.p is GameAction) {
							if (wrapProperty.p is ProcessMoveAction) {
								switch ((ProcessMoveAction.Property)wrapProperty.n) {
								case ProcessMoveAction.Property.state:
									dirty = true;
									break;
								case ProcessMoveAction.Property.inputData:
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
							return;
						}
						if (wrapProperty.p is InputData) {
							switch ((InputData.Property)wrapProperty.n) {
							case InputData.Property.gameMove:
								break;
							case InputData.Property.userSend:
								break;
							case InputData.Property.serverTime:
								dirty = true;
								break;
							case InputData.Property.clientTime:
								dirty = true;
								break;
							default:
								Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
					}
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
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
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
			}
			// Child
			if (wrapProperty.p is PlayerTotalTime) {
				switch ((PlayerTotalTime.Property)wrapProperty.n) {
				case PlayerTotalTime.Property.playerIndex:
					dirty = true;
					break;
				case PlayerTotalTime.Property.serverTime:
					break;
				case PlayerTotalTime.Property.clientTime:
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
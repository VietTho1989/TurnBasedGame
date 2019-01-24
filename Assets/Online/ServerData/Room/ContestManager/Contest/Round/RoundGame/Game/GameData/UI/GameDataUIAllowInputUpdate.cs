using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameDataUIAllowInputUpdate : UpdateBehavior<GameDataUI.UIData>
{

	#region Refresh

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				bool allowInput = false;
				{
					if (!GameUI.UIData.IsReplay (this.data)) {
						GameData gameData = this.data.gameData.v.data;
						if (gameData != null) {
							if (Game.IsPlaying (gameData)) {
								Game game = gameData.findDataInParent<Game> ();
								if (game != null) {
									bool correctGameAction = false;
									{
										if (game.gameAction.v != null) {
											if (game.gameAction.v is WaitInputAction) {
												WaitInputAction waitInputAction = game.gameAction.v as WaitInputAction;
												if (waitInputAction.sub.v != null) {
													// Check is human input
													if (waitInputAction.sub.v is WaitHumanInput) {
														// Check already send
														bool alreadySend = false;
														{
															ClientInput clientInput = waitInputAction.clientInput.v;
															if (clientInput != null) {
																if (clientInput.sub.v != null) {
																	if (clientInput.sub.v.getType () == ClientInput.Sub.Type.Send) {
																		alreadySend = true;
																	}
																} else {
																	Debug.LogError ("clientInput sub null: " + this);
																}
															} else {
																Debug.LogError ("clientInput null: " + this);
															}
														}
														if (!alreadySend) {
															correctGameAction = true;
														} else {
															Debug.LogError ("already send input: " + this);
														}
													}
												}
											}
										} else {
											Debug.LogError ("gameAction null: " + this);
										}
									}
									// Process
									if (correctGameAction) {
										// Check is your turn
										bool isYourTurn = false;
										{
											// get currentPlayerIndex
											int currentPlayerIndex = 0;
											{
												Turn turn = gameData.turn.v;
												if (turn != null) {
													currentPlayerIndex = turn.playerIndex.v;
												}
											}
											// check
											{
												GamePlayer currentGamePlayer = game.findGamePlayer (currentPlayerIndex);
												if (currentGamePlayer != null) {
													if (currentGamePlayer.inform.v is Human) {
														Human human = currentGamePlayer.inform.v as Human;
														if (human.playerId.v == Server.getProfileUserId (game)) {
															isYourTurn = true;
														}
													}
												} else {
													Debug.LogError ("currentGamePlayer null: " + this);
												}
											}
										}
										// Process
										if (isYourTurn) {
											bool isOnAnimation = false;
											{
												GameDataBoardUI.UIData gameDataBoardUIData = this.data.board.v;
												if (gameDataBoardUIData != null) {
													AnimationManager animationManager = gameDataBoardUIData.animationManager.v;
													if (animationManager != null) {
														isOnAnimation = animationManager.isOnAnimation ();
													} else {
														Debug.LogError ("animationManager null: " + this);
													}
												} else {
													Debug.LogError ("gameDataBoardUIData null: " + this);
												}
											}
											if (!isOnAnimation) {
												allowInput = true;
											}
										} else {
											Debug.LogError ("not your turn");
										}
									} else {
										// Debug.LogError ("not correct gameAction: " + duel.game.property.gameAction.property);		
									}
								} else {
									Debug.LogError ("game isn't playing: " + this);
								}
							} else {
								Debug.LogError ("game null: " + this);
							}
						} else {
							Debug.LogError ("gameData null: " + this);
						}
					} else {
						// Debug.LogError ("this is replay, cannot input: " + this);
					}
				}
				this.data.allowInput.v = allowInput;
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

	private GameIsPlayingChange<GameData> gameIsPlayingChange = new GameIsPlayingChange<GameData> ();
	private GameCheckPlayerChange<GameData> gameCheckPlayerChange = new GameCheckPlayerChange<GameData> ();
	private CheckHaveAnimation<GameDataBoardUI.UIData> checkHaveAnimation = new CheckHaveAnimation<GameDataBoardUI.UIData> ();

	private Game game = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is GameDataUI.UIData) {
			GameDataUI.UIData uiData = data as GameDataUI.UIData;
			// Child
			{
				uiData.gameData.allAddCallBack (this);
				uiData.board.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			// gameData
			{
				if (data is GameData) {
					GameData gameData = data as GameData;
					// CheckChange
					{
						// isPlaying
						{
							gameIsPlayingChange.addCallBack (this);
							gameIsPlayingChange.setData (gameData);
						}
						// change player
						{
							gameCheckPlayerChange.addCallBack (this);
							gameCheckPlayerChange.setData (gameData);
						}
					}
					// Parent
					{
						DataUtils.addParentCallBack (gameData, this, ref this.game); 
					}
					// Child
					{
						gameData.turn.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// CheckChange
				{
					if (data is GameIsPlayingChange<GameData>) {
						dirty = true;
						return;
					}
					if (data is GameCheckPlayerChange<GameData>) {
						dirty = true;
						return;
					}
				}
				// Parent
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
					// Child
					{
						if (data is GameAction) {
							GameAction gameAction = data as GameAction;
							// Child
							{
								if (gameAction is WaitInputAction) {
									WaitInputAction waitInputAction = gameAction as WaitInputAction;
									{
										waitInputAction.clientInput.allAddCallBack (this);
									}
								}
							}
							dirty = true;
							return;
						}
						// Child
						if (data is ClientInput) {
							dirty = true;
							return;
						}
					}
				}
				// Child
				{
					if (data is Turn) {
						dirty = true;
						return;
					}
				}
			}
			// GameDataBoardUI.UIData
			{
				if (data is GameDataBoardUI.UIData) {
					GameDataBoardUI.UIData gameDataBoardUIData = data as GameDataBoardUI.UIData;
					// CheckChange
					{
						checkHaveAnimation.addCallBack (this);
						checkHaveAnimation.setData (gameDataBoardUIData);
					}
					dirty = true;
					return;
				}
				// CheckChange
				if (data is CheckHaveAnimation<GameDataBoardUI.UIData>) {
					dirty = true;
					return;
				}
			}
		}
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is GameDataUI.UIData) {
			GameDataUI.UIData uiData = data as GameDataUI.UIData;
			// Child
			{
				uiData.gameData.allRemoveCallBack (this);
				uiData.board.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			// GameData
			{
				if (data is GameData) {
					GameData gameData = data as GameData;
					// CheckChange
					{
						// isPlaying
						{
							gameIsPlayingChange.removeCallBack (this);
							gameIsPlayingChange.setData (null);
						}
						// change player
						{
							gameCheckPlayerChange.removeCallBack (this);
							gameCheckPlayerChange.setData (null);
						}
					}
					// Parent
					{
						DataUtils.removeParentCallBack (gameData, this, ref this.game); 
					}
					// Child
					{
						gameData.turn.allRemoveCallBack (this);
					}
					return;
				}
				// CheckChange
				{
					if (data is GameIsPlayingChange<GameData>) {
						return;
					}
					if (data is GameCheckPlayerChange<GameData>) {
						return;
					}
				}
				// Parent
				{
					if (data is Game) {
						Game game = data as Game;
						// Child
						{
							game.gameAction.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is GameAction) {
							GameAction gameAction = data as GameAction;
							// Child
							{
								if (gameAction is WaitInputAction) {
									WaitInputAction waitInputAction = gameAction as WaitInputAction;
									{
										waitInputAction.clientInput.allRemoveCallBack (this);
									}
								}
							}
							return;
						}
						// Child
						if (data is ClientInput) {
							return;
						}
					}
				}
				// Child
				{
					if (data is Turn) {
						return;
					}
				}
			}
			// GameDataBoardUI.UIData
			{
				if (data is GameDataBoardUI.UIData) {
					// GameDataBoardUI.UIData gameDataBoardUIData = data as GameDataBoardUI.UIData;
					// CheckChange
					{
						checkHaveAnimation.removeCallBack (this);
						checkHaveAnimation.setData (null);
					}
					return;
				}
				// CheckChange
				if (data is CheckHaveAnimation<GameDataBoardUI.UIData>) {
					return;
				}
			}
		}
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is GameDataUI.UIData) {
			switch ((GameDataUI.UIData.Property)wrapProperty.n) {
			case GameDataUI.UIData.Property.gameData:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case GameDataUI.UIData.Property.board:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case GameDataUI.UIData.Property.allowLastMove:
				break;
			case GameDataUI.UIData.Property.hintUI:
				break;
			case GameDataUI.UIData.Property.allowInput:
				break;
			case GameDataUI.UIData.Property.turn:
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
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
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// CheckChange
				{
					if (wrapProperty.p is GameIsPlayingChange<GameData>) {
						dirty = true;
						return;
					}
					if (wrapProperty.p is GameCheckPlayerChange<GameData>) {
						dirty = true;
						return;
					}
				}
				// Parent
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
						if (wrapProperty.p is GameAction) {
							if (wrapProperty.p is WaitInputAction) {
								switch ((WaitInputAction.Property)wrapProperty.n) {
								case WaitInputAction.Property.serverTime:
									break;
								case WaitInputAction.Property.clientTime:
									break;
								case WaitInputAction.Property.sub:
									dirty = true;
									break;
								case WaitInputAction.Property.inputs:
									dirty = true;
									break;
								case WaitInputAction.Property.clientInput:
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
							return;
						}
						// Child
						if (wrapProperty.p is ClientInput) {
							switch ((ClientInput.Property)wrapProperty.n) {
							case ClientInput.Property.sub:
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
				// Child
				{
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
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
					}
				}
			}
			// GameDataBoardUI.UIData
			{
				if (wrapProperty.p is GameDataBoardUI.UIData) {
					return;
				}
				// CheckChange
				if (wrapProperty.p is CheckHaveAnimation<GameDataBoardUI.UIData>) {
					dirty = true;
					return;
				}
			}
		}
	}

	#endregion

}
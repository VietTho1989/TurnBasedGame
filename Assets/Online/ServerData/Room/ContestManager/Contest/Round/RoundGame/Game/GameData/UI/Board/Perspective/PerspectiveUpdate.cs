using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PerspectiveUpdate : UpdateBehavior<Perspective>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				// Find playerIndex
				int newPlayerIndex = 0;
				{
					// check null
					if (this.data.sub.v == null) {
						PerspectiveAuto auto = new PerspectiveAuto ();
						{
							auto.uid = this.data.sub.makeId ();
						}
						this.data.sub.v = auto;
					}
					// process
					switch (this.data.sub.v.getType ()) {
					case Perspective.Sub.Type.Auto:
						{
							// Find Game
							Game game = null;
							{
								GameDataBoardUI.UIData gameDataBoardUIData = this.data.findDataInParent<GameDataBoardUI.UIData> ();
								if (gameDataBoardUIData != null) {
									GameData gameData = gameDataBoardUIData.gameData.v.data;
									if (gameData != null) {
										game = gameData.findDataInParent<Game> ();
									} else {
										Debug.LogError ("gameData null: " + this);
									}
								} else {
									Debug.LogError ("gameDataBoardUIData null: " + this);
								}
							}
							// Process
							if (game != null) {
								int smallestPlayerIndex = int.MaxValue;
								uint profileId = Server.getProfileUserId (game);
								// get perspectiveCount
								int perspectiveCount = 1;
								{
									GameData gameData = game.gameData.v;
									if (gameData != null) {
										GameType gameType = gameData.gameType.v;
										if (gameType != null) {
											perspectiveCount = gameType.getPerspectiveCount ();
										} else {
											Debug.LogError ("gameType null: " + this);
										}
									} else {
										Debug.LogError ("gameData null: " + this);
									}
								}
								// Process
								for (int i = 0; i < Mathf.Min (game.gamePlayers.vs.Count, perspectiveCount); i++) {
									GamePlayer gamePlayer = game.gamePlayers.vs [i];
									if (gamePlayer.inform.v != null && gamePlayer.inform.v is Human) {
										Human human = gamePlayer.inform.v as Human;
										if (human.playerId.v == profileId) {
											if (gamePlayer.playerIndex.v < smallestPlayerIndex) {
												smallestPlayerIndex = gamePlayer.playerIndex.v;
											}
										}
									}
								}
								if (smallestPlayerIndex != int.MaxValue) {
									newPlayerIndex = smallestPlayerIndex;
								} else {
									newPlayerIndex = 0;
								}
							} else {
								// Debug.LogError ("duel null: " + this);
							}
						}
						break;
					case Perspective.Sub.Type.Force:
						{
							PerspectiveForce force = this.data.sub.v as PerspectiveForce;
							{
								// correct by gamePlayers
								{
									int playerNumber = 2;
									{
										GameDataBoardUI.UIData gameDataBoardUIData = this.data.findDataInParent<GameDataBoardUI.UIData> ();
										if (gameDataBoardUIData != null) {
											GameData gameData = gameDataBoardUIData.gameData.v.data;
											if (gameData != null) {
												Game game = gameData.findDataInParent<Game> ();
												if (game != null) {
													playerNumber = game.gamePlayers.vs.Count;
												} else {
													Debug.LogError ("duel null: " + this);
												}
											} else {
												Debug.LogError ("gameData null: " + this);
											}
										} else {
											Debug.LogError ("gameDataBoardUIData null: " + this);
										}
									}
									if (force.playerIndex.v >= playerNumber) {
										force.playerIndex.v = 0;
									}
								}
								// correct by perspectCount
								{
									int perspectiveCount = 2;
									{
										GameDataBoardUI.UIData gameDataBoardUIData = this.data.findDataInParent<GameDataBoardUI.UIData> ();
										if (gameDataBoardUIData != null) {
											GameData gameData = gameDataBoardUIData.gameData.v.data;
											if (gameData != null) {
												GameType gameType = gameData.gameType.v;
												if (gameType != null) {
													perspectiveCount = gameType.getPerspectiveCount ();
												} else {
													Debug.LogError ("gameType null: " + this);
												}
											} else {
												Debug.LogError ("gameData null: " + this);
											}
										} else {
											Debug.LogError ("gameDataBoardUIData null: " + this);
										}
									}
									if (force.playerIndex.v >= perspectiveCount) {
										force.playerIndex.v = 0;
									}
								}
							}
							newPlayerIndex = force.playerIndex.v;
						}
						break;
					default:
						Debug.LogError ("unknown type: " + this.data.sub.getType () + "; " + this);
						break;
					}
				}
				// Correct playerIndex
				{
					// correct by gamePlayers
					{
						int playerNumber = 2;
						{
							GameDataBoardUI.UIData gameDataBoardUIData = this.data.findDataInParent<GameDataBoardUI.UIData> ();
							if (gameDataBoardUIData != null) {
								GameData gameData = gameDataBoardUIData.gameData.v.data;
								if (gameData != null) {
									Game game = gameData.findDataInParent<Game> ();
									if (game != null) {
										playerNumber = game.gamePlayers.vs.Count;
									} else {
										Debug.LogError ("game null: " + this);
									}
								} else {
									Debug.LogError ("gameData null: " + this);
								}
							} else {
								Debug.LogError ("gameDataBoardUIData null: " + this);
							}
						}
						if (newPlayerIndex >= playerNumber) {
							newPlayerIndex = 0;
						}
					}
					// correct if too small
					if (newPlayerIndex < 0) {
						newPlayerIndex = 0;
					}
				}
				// Set
				this.data.playerView.v = newPlayerIndex;
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

	private GameDataBoardUI.UIData gameDataBoardUIData = null;
	private GameCheckPlayerChange<GameData> gameCheckPlayerChange = new GameCheckPlayerChange<GameData> ();

	public override void onAddCallBack<T> (T data)
	{
		if (data is Perspective) {
			Perspective perspective = data as Perspective;
			// Parent
			{
				DataUtils.addParentCallBack (perspective, this, ref this.gameDataBoardUIData);
			}
			// Child
			{
				perspective.sub.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Parent
		{
			if (data is GameDataBoardUI.UIData) {
				GameDataBoardUI.UIData gameDataBoardUIData = data as GameDataBoardUI.UIData;
				// Child
				{
					gameDataBoardUIData.gameData.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// GameData
			{
				if (data is GameData) {
					GameData gameData = data as GameData;
					// CheckChange
					{
						gameCheckPlayerChange.addCallBack (this);
						gameCheckPlayerChange.setData (gameData);
					}
					dirty = true;
					return;
				}
				if (data is GameCheckPlayerChange<GameData>) {
					dirty = true;
					return;
				}
			}
		}
		// Sub
		if (data is Perspective.Sub) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is Perspective) {
			Perspective perspective = data as Perspective;
			// Parent
			{
				DataUtils.removeParentCallBack (perspective, this, ref this.gameDataBoardUIData);
			}
			// Child
			{
				perspective.sub.allRemoveCallBack (this);
			}
			this.setDataNull (perspective);
			return;
		}
		// Parent
		{
			if (data is GameDataBoardUI.UIData) {
				GameDataBoardUI.UIData gameDataBoardUIData = data as GameDataBoardUI.UIData;
				// Child
				{
					gameDataBoardUIData.gameData.allRemoveCallBack (this);
				}
				return;
			}
			// GameData
			{
				if (data is GameData) {
					// GameData gameData = data as GameData;
					// CheckChange
					{
						gameCheckPlayerChange.removeCallBack (this);
						gameCheckPlayerChange.setData (null);
					}
					return;
				}
				if (data is GameCheckPlayerChange<GameData>) {
					return;
				}
			}
		}
		// Sub
		if (data is Perspective.Sub) {
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is Perspective) {
			switch ((Perspective.Property)wrapProperty.n) {
			case Perspective.Property.playerView:
				dirty = true;
				break;
			case Perspective.Property.sub:
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
			if (wrapProperty.p is GameDataBoardUI.UIData) {
				switch ((GameDataBoardUI.UIData.Property)wrapProperty.n) {
				case GameDataBoardUI.UIData.Property.gameData:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case GameDataBoardUI.UIData.Property.sub:
					break;
				case GameDataBoardUI.UIData.Property.perspective:
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// GameData
			{
				if (wrapProperty.p is GameData) {
					switch ((GameData.Property)wrapProperty.n) {
					case GameData.Property.gameType:
						dirty = true;
						break;
					case GameData.Property.useRule:
						break;
					case GameData.Property.turn:
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
				if (wrapProperty.p is GameCheckPlayerChange<GameData>) {
					dirty = true;
					return;
				}
			}
		}
		// Sub
		if (wrapProperty.p is Perspective.Sub) {
			if (wrapProperty.p is PerspectiveAuto) {
				switch ((PerspectiveAuto.Property)wrapProperty.n) {
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			if (wrapProperty.p is PerspectiveForce) {
				switch ((PerspectiveForce.Property)wrapProperty.n) {
				case PerspectiveForce.Property.playerIndex:
					dirty = true;
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
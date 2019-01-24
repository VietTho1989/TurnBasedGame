using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameCheckPlayerCountUpdate : UpdateBehavior<Game>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				int playerCount = 2;
				{
					GameData gameData = this.data.gameData.v;
					if (gameData != null) {
						GameType gameType = gameData.gameType.v;
						if (gameType != null) {
							playerCount = gameType.getTeamCount ();
						} else {
							Debug.LogError ("gameType null: " + this);
						}
					} else {
						Debug.LogError ("gameData null: " + this);
					}
				}
				// Update
				if (this.data.gamePlayers.vs.Count != playerCount) {
					List<int> playerIndexes = new List<int> ();
					{
						for (int i = 0; i < playerCount; i++) {
							playerIndexes.Add (i);
						}
					}
					// remove already have
					{
						foreach (GamePlayer gamePlayer in this.data.gamePlayers.vs) {
							playerIndexes.Remove (gamePlayer.playerIndex.v);
						}
					}
					// add lack
					{
						// find adminId
						uint adminId = 0;
						{
							RoomUser admin = Room.findAdmin (this.data);
							if (admin != null) {
								Human human = admin.inform.v;
								if (human != null) {
									adminId = human.playerId.v;
								} else {
									Debug.LogError ("human null: " + this);
								}
							} else {
								Debug.LogError ("admin null: " + this);
							}
						}
						// add
						foreach (int playerIndex in playerIndexes) {
							GamePlayer gamePlayer = new GamePlayer ();
							{
								gamePlayer.uid = this.data.gamePlayers.makeId ();
								gamePlayer.playerIndex.v = playerIndex;
								// inform
								{
									Human human = new Human ();
									{
										human.uid = gamePlayer.inform.makeId ();
										human.playerId.v = adminId;
									}
									gamePlayer.inform.v = human;
								}
								// state
							}
							this.data.gamePlayers.add (gamePlayer);
						}
					}
				} else {
					// already correct
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
				game.gameData.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		if (data is GameData) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is Game) {
			Game game = data as Game;
			// Child
			{
				game.gameData.allRemoveCallBack (this);
			}
			this.setDataNull (game);
			return;
		}
		// Child
		if (data is GameData) {
			return;
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
				break;
			case Game.Property.requestDraw:
				break;
			case Game.Property.state:
				break;
			case Game.Property.gameData:
				{
					ValueChangeUtils.replaceCallBack(this, syncs);
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
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
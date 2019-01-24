using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePreventGamePlayerAINull : UpdateBehavior<Game>
{

	#region update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				// Find gameTypeType
				GameType.Type gameTypeType = GameType.Type.Xiangqi;
				{
					GameData gameData = this.data.gameData.v;
					if (gameData != null) {
						GameType gameType = gameData.gameType.v;
						if (gameType != null) {
							gameTypeType = gameType.getType ();
						} else {
							Debug.LogError ("gameType null: " + this);
						}
					} else {
						Debug.LogError ("gameData null: " + this);
					}
				}
				// Prevent null ai in gamePlayers
				foreach (GamePlayer gamePlayer in this.data.gamePlayers.vs) {
					if (gamePlayer.inform.v != null && gamePlayer.inform.v is Computer) {
						Computer computer = gamePlayer.inform.v as Computer;
						// Check need new ai
						bool needNewAI = true;
						{
							if (computer.ai.v != null) {
								if (computer.ai.v.getType () == gameTypeType) {
									needNewAI = false;
								}
							}
						}
						// Process
						if (needNewAI) {
							Computer.AI newAI = Computer.AI.makeDefaultAI (gameTypeType);
							{
								newAI.uid = computer.ai.makeId ();
							}
							computer.ai.v = newAI;
						}
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
				game.gameData.allAddCallBack (this);
				game.gamePlayers.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is GameData) {
				dirty = true;
				return;
			}
			// gamePlayers
			{
				if (data is GamePlayer) {
					GamePlayer gamePlayer = data as GamePlayer;
					// Child
					{
						gamePlayer.inform.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is GamePlayer.Inform) {
						dirty = true;
						return;
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
				game.gameData.allRemoveCallBack (this);
				game.gamePlayers.allRemoveCallBack (this);
			}
			return;
		}
		// Child
		{
			if (data is GameData) {
				return;
			}
			// gamePlayers
			{
				if (data is GamePlayer) {
					GamePlayer gamePlayer = data as GamePlayer;
					// Child
					{
						gamePlayer.inform.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is GamePlayer.Inform) {
						return;
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
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
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
			// gamePlayers
			{
				if (wrapProperty.p is GamePlayer) {
					switch ((GamePlayer.Property)wrapProperty.n) {
					case GamePlayer.Property.playerIndex:
						break;
					case GamePlayer.Property.inform:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case GamePlayer.Property.state:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				{
					if (wrapProperty.p is GamePlayer.Inform) {
						if (wrapProperty.p is Computer) {
							switch ((Computer.Property)wrapProperty.n) {
							case Computer.Property.computerName:
								break;
							case Computer.Property.avatarUrl:
								break;
							case Computer.Property.ai:
								dirty = true;
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						return;
					}
				}
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
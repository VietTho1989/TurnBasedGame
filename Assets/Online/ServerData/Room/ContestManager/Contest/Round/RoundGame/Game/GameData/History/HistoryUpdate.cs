using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class HistoryUpdate : UpdateBehavior<Game>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {

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
				game.history.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is GameData) {
				GameData gameData = data as GameData;
				// reset
				{
					/*if (this.data != null) {
						this.data.history.v.reset ();
					} else {
						Debug.LogError ("data null");
					}*/
				}
				// Update
				{
					UpdateUtils.makeUpdate<HistoryGameDataUpdate, GameData> (gameData, this.transform);
				}
				dirty = true;
				return;
			}
			// History
			{
				if (data is History) {
					History history = data as History;
					// Update
					{
						UpdateUtils.makeUpdate<HumanConnectionCheckInsideRoomUpdate, History> (history, this.transform);
					}
					// Child
					{
						history.humanConnections.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is HumanConnection) {
					HumanConnection humanConnection = data as HumanConnection;
					// Update
					{
						UpdateUtils.makeUpdate<HumanConnectionUpdate, HumanConnection> (humanConnection, this.transform);
					}
					dirty = true;
					return;
				}
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		// Duel
		if (data is Game) {
			Game game = data as Game;
			// Child
			{
				game.gameData.allRemoveCallBack (this);
				game.history.allRemoveCallBack (this);
			}
			this.setDataNull (game);
			return;
		}
		// Child
		{
			if (data is GameData) {
				GameData gameData = data as GameData;
				// Update
				{
					gameData.removeCallBackAndDestroy (typeof(HistoryGameDataUpdate));
				}
				return;
			}
			// History
			{
				if (data is History) {
					History history = data as History;
					// Update
					{
						history.removeCallBackAndDestroy (typeof(HumanConnectionCheckInsideRoomUpdate));
					}
					// Child
					{
						history.humanConnections.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is HumanConnection) {
					HumanConnection humanConnection = data as HumanConnection;
					// Update
					{
						humanConnection.removeCallBackAndDestroy (typeof(HumanConnectionUpdate));
					}
					return;
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
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case Game.Property.gameAction:
				break;
			case Game.Property.undoRedoRequest:
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		{
			if (wrapProperty.p is GameData) {
				return;
			}
			// History
			{
				if (wrapProperty.p is History) {
					switch ((History.Property)wrapProperty.n) {
					case History.Property.isActive:
						break;
					case History.Property.changes:
						break;
					case History.Property.position:
						break;
					case History.Property.changeCount:
						break;
					case History.Property.humanConnections:
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
				if (wrapProperty.p is HumanConnection) {
					return;
				}
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}
		
	#endregion

}
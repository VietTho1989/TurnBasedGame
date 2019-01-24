using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameActionsUpdate : UpdateBehavior<Game>
{
	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
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
			// tree pause
			{
				if (this.transform.childCount >= 2) {
					// Child 1
					{
						GameObject tree1 = this.transform.GetChild (0).gameObject;
						tree1.name = "GameActionsPauseUpdate";
						// Get component
						GameActionsPauseUpdate gameActionsPauseUpdate = tree1.GetComponent<GameActionsPauseUpdate> ();
						{
							if (gameActionsPauseUpdate == null) {
								gameActionsPauseUpdate = tree1.AddComponent<GameActionsPauseUpdate> ();
							} else {
								Debug.LogError ("already have");
							}
						}
						// Set data
						if (gameActionsPauseUpdate != null) {
							gameActionsPauseUpdate.setData (game);
						} else {
							Debug.LogError ("Don't have");
						}
					}
					// Child 2
					{
						GameObject tree2 = this.transform.GetChild (1).gameObject;
						tree2.name = "GameActionsNotPauseUpdate";
						// Get component
						GameActionsNotPauseUpdate gameActionsNotPauseUpdate = tree2.GetComponent<GameActionsNotPauseUpdate> ();
						{
							if (gameActionsNotPauseUpdate == null) {
								gameActionsNotPauseUpdate = tree2.AddComponent<GameActionsNotPauseUpdate> ();
							} else {
								Debug.LogError ("already have: " + this);
							}
						}
						// Set data
						if (gameActionsNotPauseUpdate != null) {
							gameActionsNotPauseUpdate.setData (game);
						} else {
							Debug.LogError ("Don't have: " + this);
						}
					}
				} else {
					Debug.LogError ("Why child count not correct: " + this);
				}
			}
			// Child
			{
				game.gameAction.allAddCallBack (this);
			}
			return;
		}
		if (data is GameAction) {
			GameAction gameAction = data as GameAction;
			makeGameActionUpdate (gameAction);
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is Game) {
			Game game = data as Game;
			{
				if (this.transform.childCount >= 2) {
					// Child 1
					{
						GameObject tree1 = this.transform.GetChild (0).gameObject;
						GameActionsPauseUpdate gameActionsPauseUpdate = tree1.AddComponent<GameActionsPauseUpdate> ();
						// Set data
						if (gameActionsPauseUpdate != null) {
							gameActionsPauseUpdate.setData (null);
						} else {
							Debug.LogError ("Don't have");
						}
					}
					// Child 2
					{
						GameObject tree2 = this.transform.GetChild (1).gameObject;
						// Get component
						GameActionsNotPauseUpdate gameActionsNotPauseUpdate = tree2.AddComponent<GameActionsNotPauseUpdate> ();
						// Set data
						if (gameActionsNotPauseUpdate != null) {
							gameActionsNotPauseUpdate.setData (null);
						} else {
							Debug.LogError ("Don't have");
						}
					}
				} else {
					Debug.LogError ("Why child count not correct");
				}
			}
			// Child
			{
				game.gameAction.allRemoveCallBack (this);
			}
			return;
		}
		if (data is GameAction) {
			GameAction gameAction = data as GameAction;
			gameAction.removeCallBackAndDestroy(typeof(Sub<>));
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
				break;
			case Game.Property.history:
				break;
			case Game.Property.gameAction:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
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
		if (wrapProperty.p is GameAction) {
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	#endregion

	private void makeGameActionUpdate(GameAction gameAction)
	{
		if (this.transform.childCount >= 2) {
			GameObject pause = this.transform.GetChild (0).GetChild (0).gameObject;
			GameObject nonPause = this.transform.GetChild (1).GetChild (0).gameObject;
			// Make action
			{
				switch (gameAction.getType ()) {
				case GameAction.Type.ProcessMove:
					{
						ProcessMoveAction processMoveAction = gameAction as ProcessMoveAction;
						UpdateUtils.makeUpdate<ProcessMoveActionUpdate, ProcessMoveAction> (processMoveAction, pause.transform);
					}
					break;
				case GameAction.Type.StartTurn:
					{
						StartTurnAction startTurnAction = gameAction as StartTurnAction;
						UpdateUtils.makeUpdate<StartTurnActionUpdate, StartTurnAction> (startTurnAction, pause.transform);
					}
					break;
				case GameAction.Type.Non:
					{
						NonAction nonAction = gameAction as NonAction;
						UpdateUtils.makeUpdate<NonActionUpdate, NonAction> (nonAction, pause.transform);
					}
					break;
				case GameAction.Type.UndoRedo:
					{
						UndoRedoAction undoRedoAction = gameAction as UndoRedoAction;
						UpdateUtils.makeUpdate<UndoRedoActionUpdate, UndoRedoAction> (undoRedoAction, nonPause.transform);
					}
					break;
				case GameAction.Type.WaitInput:
					{
						WaitInputAction waitInputAction = gameAction as WaitInputAction;
						UpdateUtils.makeUpdate<WaitInputActionUpdate, WaitInputAction> (waitInputAction, pause.transform);
					}
					break;
				default:
					Debug.LogError ("unknown gameAction type: " + gameAction.getType ());
					break;
				}
			}
		} else {
			Debug.LogError ("Why not enough child count");
		}
	}

	public abstract class Sub<T> : UpdateBehavior<T> where T:GameAction
	{

	}

}
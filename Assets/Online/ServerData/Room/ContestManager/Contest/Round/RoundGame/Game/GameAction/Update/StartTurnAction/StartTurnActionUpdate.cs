using UnityEngine;
using System.Collections;

public class StartTurnActionUpdate : GameActionsUpdate.Sub<StartTurnAction>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				switch (this.data.state.v) {
				case StartTurnAction.State.Start:
					{
						Game game = this.data.findDataInParent<Game> ();
						if (game != null) {
							Turn turn = game.gameData.v.turn.v;
							// turn
							{
								turn.turn.v = turn.turn.v + 1;
							}
							// playerIndex
							{
								// Find GameType
								GameType gameType = game.gameData.v.gameType.v;
								if (gameType != null) {
									int newPlayerIndex = gameType.getPlayerIndex ();
									turn.playerIndex.v = newPlayerIndex;
								} else {
									Debug.LogError ("gameType null");
								}
							}
						} else {
							Debug.LogError ("game null");
						}
						this.data.state.v = StartTurnAction.State.Process;
					}
					break;
				case StartTurnAction.State.Process:
					{
						// Find History
						{
							History history = null;
							{
								Game game = this.data.findDataInParent<Game> ();
								if (game != null) {
									history = game.history.v;
								} else {
									Debug.LogError ("game null: " + this);
								}
							}
							// add
							if (history != null) {
								TurnChange turnChange = new TurnChange ();
								{
									Game game = this.data.findDataInParent<Game> ();
									if (game != null) {
										Turn turn = game.gameData.v.turn.v;
										// Set
										turnChange.turn.v = turn.turn.v;
										turnChange.playerIndex.v = turn.playerIndex.v;
										turnChange.gameTurn.v = turn.gameTurn.v;
									} else {
										Debug.LogError ("game null: " + this);
									}
								}
								// Add to history
								history.addTurnChange(turnChange);
							} else {
								Debug.LogError ("history null: " + this);
							}
						}
						// Change state
						this.data.state.v = StartTurnAction.State.End;
					}
					break;
				case StartTurnAction.State.End:
					{
						Game game = this.data.findDataInParent<Game> ();
						if (game != null) {
							// Chuyen sang waitInputAction
							if (game.gameAction.v == null || !(game.gameAction.v is WaitInputAction)) {
								WaitInputAction waitInputAction = new WaitInputAction ();
								{
									waitInputAction.uid = game.gameAction.makeId ();
								}
								game.gameAction.v = waitInputAction;
							}
						} else {
							Debug.LogError ("game null: " + this);
						}
					}
					break;
				default:
					Debug.LogError ("unknown startTurnAction state: " + this.data.state.v);
					break;
				}
			} else {
				Debug.LogError ("startTurnAction null");
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
		if (data is StartTurnAction) {
			dirty = true;
			return;
		}
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is StartTurnAction) {
			StartTurnAction startTurnAction = data as StartTurnAction;
			// set data null
			this.setDataNull (startTurnAction);
			return;
		}
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, System.Collections.Generic.List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is StartTurnAction) {
			switch ((StartTurnAction.Property)wrapProperty.n) {
			case StartTurnAction.Property.state:
				dirty = true;
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
	}

	#endregion
}
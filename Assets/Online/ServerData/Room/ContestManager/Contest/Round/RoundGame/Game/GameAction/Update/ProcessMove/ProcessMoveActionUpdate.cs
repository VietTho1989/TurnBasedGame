using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class ProcessMoveActionUpdate : GameActionsUpdate.Sub<ProcessMoveAction>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				switch (this.data.state.v) {
				case ProcessMoveAction.State.Process:
					{
						destroyRoutine (waitEnd);
						this.data.state.v = ProcessMoveAction.State.Processing;
					}
					break;
				case ProcessMoveAction.State.Processing:
					{
						destroyRoutine (waitEnd);
						TaskProcess ();
					}
					break;
				case ProcessMoveAction.State.WaitEnd:
					{
						startRoutine(ref this.waitEnd, TaskWaitEnd());
					}
					break;
				case ProcessMoveAction.State.End:
					{
						// end: chuyen sang state turn action
						Game game = this.data.findDataInParent<Game> ();
						if (game != null) {
							if (!(game.gameAction.v is StartTurnAction)) {
								StartTurnAction startTurnAction = new StartTurnAction ();
								{
									startTurnAction.uid = game.gameAction.makeId ();
									startTurnAction.state.v = StartTurnAction.State.Start;
								}
								game.gameAction.v = startTurnAction;
							} else {
								Debug.LogError ("why already startTurnAction: " + this);
							}
						} else {
							Debug.LogError ("gameData null: " + this);
						}
					}
					break;
				default:
					Debug.LogError ("unknown processMoveAction state: " + this.data.state.v);
					break;
				}
			} else {
				Debug.LogError ("processMoveAction null");
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return false;
	}

	public void TaskProcess()
	{
		if (this.data != null) {
			// Find gameData
			GameData gameData = null;
			{
				Game game = this.data.findDataInParent<Game> ();
				if (game != null) {
					gameData = game.gameData.v;
				} else {
					Debug.LogError ("game null: " + this);
				}
			}
			// Update
			if (gameData != null) {
				GameMove gameMove = this.data.inputData.v.gameMove.v;
				// preprocess inputData
				{
					GameType gameType = gameData.gameType.v;
					if (gameType != null) {
						gameMove = gameType.preprocessGameMove (gameMove);
					} else {
						Debug.LogError ("gameType null: " + this);
					}
				}
				// check null
				if (gameMove == null) {
					Debug.LogError ("gameMove null");
					gameMove = new NonMove ();
				}
				// Add inform for move
				{
					GameType gameType = gameData.gameType.v;
					if (gameType != null) {
						gameMove.getInforBeforeProcess (gameType);
					} else {
						Debug.LogError ("gameType null: " + this);
					}
				}
				// Add gameMoveMessage
				{
					// Find gameTopic
					GameTopic gameTopic = null;
					{
						Game game = this.data.findDataInParent<Game> ();
						if (game != null) {
							ChatRoom chatRoom = game.chatRoom.v;
							if (chatRoom != null) {
								gameTopic = chatRoom.topic.v as GameTopic;
							} else {
								Debug.LogError ("chatRoom null: " + this);
							}
						} else {
							Debug.LogError ("game null: " + this);
						}
					}
					if (gameTopic != null) {
						// Find turn
						Turn turn = gameData.turn.v;
						// Process
						if (turn != null) {
							// TODO Co le khong nen them vao gameTopic.addGameMove (turn, gameMove);
						} else {
							Debug.LogError ("turn null: " + this);
						}
					} else {
						Debug.LogError ("gameTopic null: " + this);
					}
				}
				// Make move animation: before process
				MoveAnimation moveAnimation = gameMove.makeAnimation (gameData.gameType.v);
				// Process
				gameData.gameType.v.processGameMove (gameMove);
				// Make move animation: after process
				{
					if (moveAnimation != null) {
						// make
						moveAnimation.updateAfterProcessGameMove(gameData.gameType.v);
						// Add
						{
							// Find animationData
							AnimationData animationData = null;
							{
								Game game = this.data.findDataInParent<Game> ();
								if (game != null) {
									animationData = game.animationData.v;
								} else {
									Debug.LogError ("game null: " + this);
								}
							}
							if (animationData != null) {
								{
									moveAnimation.uid = animationData.moveAnimations.makeId ();
									moveAnimation.initDuration ();
								}
								animationData.moveAnimations.add (moveAnimation);
							} else {
								Debug.LogError ("animationData null: " + this);
							}
						}
					} else {
						// Debug.LogError ("moveAnimation null: " + this);
					}
				}
				// LastMove of gameData
				{
					if (!(gameMove is EndTurn)) {
						LastMove lastMove = gameData.lastMove.v;
						{
							// Turn
							lastMove.turn.v = gameData.turn.v.turn.v;
							// GameMove
							{
								GameMove lastGameMoveMove = (GameMove)DataUtils.cloneData (gameMove);
								{
									lastGameMoveMove.uid = lastMove.gameMove.makeId ();
								}
								lastMove.gameMove.v = lastGameMoveMove;
							}
						}
					} else {
						Debug.Log ("endTurn not is lastMove: " + this);
					}
				}
			} else {
				Debug.LogError ("Why gameData null: " + this);
			}
			this.data.state.v = ProcessMoveAction.State.WaitEnd;
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	#region Task end process move action

	private Routine waitEnd;

	public IEnumerator TaskWaitEnd()
	{
		// wait
		if (this.data != null) {
			float waitTime = 0;
			{
				// Find animationData
				AnimationData animationData = null;
				{
					Game game = this.data.findDataInParent<Game> ();
					if (game != null) {
						animationData = game.animationData.v;
					} else {
						Debug.LogError ("game null: " + this);
					}
				}
				if (animationData != null) {
					if (animationData.moveAnimations.vs.Count > 0) {
						MoveAnimation moveAnimation = animationData.moveAnimations.vs [animationData.moveAnimations.vs.Count - 1];
						waitTime = moveAnimation.getDuration ();
					} else {
						Debug.LogError ("why don't have animation moveAnimation");
					}
				} else {
					Debug.LogError ("animationData null: " + this);
				}
			}
			waitTime += 0.1f;
			if (waitTime > 0 && waitTime < 10) {
				yield return new Wait (waitTime);
			} else {
				Debug.LogError ("waitTime error: " + waitTime);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
		this.data.state.v = ProcessMoveAction.State.End;
	}

	public override List<Routine> getRoutineList ()
	{
		List<Routine> ret = new List<Routine> ();
		{
			ret.Add (waitEnd);
		}
		return ret;
	}

	#endregion

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is ProcessMoveAction) {
			// ProcessMoveAction processMoveAction = data as ProcessMoveAction;
			dirty = true;
			return;
		}
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is ProcessMoveAction) {
			ProcessMoveAction processMoveAction = data as ProcessMoveAction;
			// set data null
			this.setDataNull (processMoveAction);
			return;
		}
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, System.Collections.Generic.List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is ProcessMoveAction) {
			switch ((ProcessMoveAction.Property)wrapProperty.n) {
			case ProcessMoveAction.Property.state:
				dirty = true;
				break;
			case ProcessMoveAction.Property.inputData:
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
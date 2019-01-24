using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UndoRedo
{
	public class RequestLastYourTurn : RequestInform
	{

		public VP<UndoRedoRequest.Operation> operation;

		public VP<uint> userId;

		#region Constructor

		public enum Property
		{
			operation,
			userId
		}

		public RequestLastYourTurn() : base()
		{
			this.operation = new VP<UndoRedoRequest.Operation> (this, (byte)Property.operation, UndoRedoRequest.Operation.Undo);
			this.userId = new VP<uint> (this, (byte)Property.userId, 0);
		}

		#endregion

		public override Type getType ()
		{
			return Type.LastYourTurn;
		}

		public override int getIndex ()
		{
			int index = -1;
			{
				// get current turn
				int currentTurn = -1;
				{
					Game game = this.findDataInParent<Game> ();
					if (game != null) {
						GameData gameData = game.gameData.v;
						if (gameData != null) {
							Turn turn = gameData.turn.v;
							currentTurn = turn.turn.v;
						} else {
							Debug.LogError ("gameData null: " + this);
						}
					} else {
						Debug.LogError ("game null: " + this);
					}
				}
				// get history
				History history = null;
				{
					Game game = this.findDataInParent<Game> ();
					if (game != null) {
						history = game.history.v;
					} else {
						Debug.LogError ("game null: " + this);
					}
				}
				// get index
				if (history != null) {
					int lastTurnIndex = -1;
					int yourLastTurnIndex = -1;
					// get
					{
						// get list of your playerIndex
						List<int> yourPlayerIndexes = new List<int>();
						{
							Game game = this.findDataInParent<Game> ();
							if (game != null) {
								for (int i = 0; i < game.gamePlayers.vs.Count; i++) {
									GamePlayer gamePlayer = game.gamePlayers.vs [i];
									if (gamePlayer.inform.v is Human) {
										Human human = gamePlayer.inform.v as Human;
										if (human.playerId.v == this.userId.v) {
											yourPlayerIndexes.Add (gamePlayer.playerIndex.v);
										}
									}
								}
							} else {
								Debug.LogError ("game null: " + this);
							}
						}
						switch (this.operation.v) {
						case UndoRedoRequest.Operation.Undo:
							{
								if (history.position.v <= history.changes.vs.Count - 1) {
									for (int i = history.position.v - 1; i >= 0; i--) {
										if (history.changes.vs [i] is TurnChange) {
											TurnChange turnChange = history.changes.vs [i] as TurnChange;
											// check correct is your turn
											{
												if (yourPlayerIndexes.Count > 0) {
													if (yourPlayerIndexes.Contains (turnChange.playerIndex.v)) {
														Debug.LogError ("find your last turn index: " + i);
														yourLastTurnIndex = i;
														break;
													}
												} else {
													if (turnChange.turn.v == currentTurn - 1) {
														yourLastTurnIndex = i;
														break;
													}
												}
											}
											// get last turn index
											if (turnChange.turn.v == currentTurn - 1) {
												lastTurnIndex = i;
											}
										}
									}
								} else {
									Debug.LogError ("why position too large");
								}
							}
							break;
						case UndoRedoRequest.Operation.Redo:
							{
								for (int i = history.position.v + 1; i < history.changes.vs.Count; i++) {
									if (history.changes.vs [i] is TurnChange) {
										TurnChange turnChange = history.changes.vs [i] as TurnChange;
										// check correct is your turn
										{
											if (yourPlayerIndexes.Count > 0) {
												if (yourPlayerIndexes.Contains (turnChange.playerIndex.v)) {
													yourLastTurnIndex = i;
													break;
												}
											} else {
												if (turnChange.turn.v == currentTurn + 1) {
													yourLastTurnIndex = i;
													break;
												}
											}
										}
										// get last turn index
										if (turnChange.turn.v == currentTurn + 1) {
											lastTurnIndex = i;
										}
									}
									// TODO luot cuoi ko co new turn change
									if (lastTurnIndex == -1) {
										if (i == history.changes.vs.Count - 1) {
											Debug.LogError ("last turn");
											index = i;
										}
									}
								}
							}
							break;
						default:
							Debug.LogError ("unknown operation: " + operation + "; " + this);
							break;
						}
					}
					// process
					{
						if (yourLastTurnIndex < 0) {
							index = lastTurnIndex;
						} else {
							index = yourLastTurnIndex;
						}
					}
				} else {
					Debug.LogError ("history null: " + this);
				}
			}
			return index;
		}

		public override bool isRequestCorrect (History history)
		{
			bool ret = false;
			if (history != null) {
				switch (this.operation.v) {
				case UndoRedoRequest.Operation.Undo:
					{
						if (history.position.v > 0) {
							ret = true;
						} else {
							Debug.LogError ("cannot undo: " + this);
						}
					}
					break;
				case UndoRedoRequest.Operation.Redo:
					{
						if (history.position.v < history.changes.vs.Count) {
							ret = true;
						} else {
							Debug.LogError ("cannot redo: " + this);
						}
					}
					break;
				default:
					Debug.LogError ("unknown operation: " + operation + "; " + this);
					break;
				}
			} else {
				Debug.LogError ("history null: " + this);
			}
			return ret;
		}

	}
}
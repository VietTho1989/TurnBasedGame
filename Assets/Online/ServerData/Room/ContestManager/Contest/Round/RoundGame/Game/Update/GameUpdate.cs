using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameState;

public class GameUpdate : UpdateBehavior<Game>
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
			// Update
			{
				UpdateUtils.makeTreeUpdate<GameActionsUpdate, Game>(game, this.transform);
				UpdateUtils.makeUpdate<GamePreventGamePlayerAINull, Game> (game, this.transform);
				UpdateUtils.makeUpdate<GameCheckEndUpdate, Game> (game, this.transform);
				UpdateUtils.makeUpdate<GameCheckPlayerCountUpdate, Game> (game, this.transform);
			}
			// child
			{
				game.gamePlayers.allAddCallBack (this);
				game.requestDraw.allAddCallBack (this);
				game.state.allAddCallBack (this);
				game.history.allAddCallBack(this);
				game.gameData.allAddCallBack(this);
				game.undoRedoRequest.allAddCallBack(this);
				game.chatRoom.allAddCallBack (this);
				game.animationData.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is GamePlayer) {
				GamePlayer gamePlayer = data as GamePlayer;
				// Update
				{
					UpdateUtils.makeUpdate<GamePlayerUpdate, GamePlayer> (gamePlayer, this.transform);
				}
				dirty = true;
				return;
			}
			if (data is RequestDraw) {
				RequestDraw requestDraw = data as RequestDraw;
				// Update
				{
					UpdateUtils.makeUpdate<RequestDrawUpdate, RequestDraw> (requestDraw, this.transform);
				}
				dirty = true;
				return;
			}
			if (data is State) {
				State state = data as State;
				// Update
				{
					switch (state.getType ()) {
					case State.Type.Load:
						{
							Load load = state as Load;
							UpdateUtils.makeUpdate<LoadUpdate, Load> (load, this.transform);
						}
						break;
					case State.Type.Start:
						{
							Start start = state as Start;
							UpdateUtils.makeUpdate<StartUpdate, Start> (start, this.transform);
						}
						break;
					case State.Type.Play:
						{
							Play play = state as Play;
							UpdateUtils.makeUpdate<PlayUpdate, Play> (play, this.transform);
						}
						break;
					case State.Type.End:
						{
							End end = state as End;
							UpdateUtils.makeUpdate<EndUpdate, End> (end, this.transform);
						}
						break;
					default:
						Debug.LogError ("unknown state: " + state.getType () + "; " + this);
						break;
					}
				}
				dirty = true;
				return;
			}
			if (data is History) {
				// History history = data as History;
				// Update
				{
					if (this.data != null) {
						UpdateUtils.makeUpdate<HistoryUpdate, Game> (this.data, this.transform);
					} else {
						Debug.LogError ("data null: " + this);
					}
				}
				dirty = true;
				return;
			}
			if (data is GameData) {
				GameData gameData = data as GameData;
				// Update
				{
					UpdateUtils.makeUpdate<GameDataUpdate, GameData> (gameData, this.transform);
				}
				dirty = true;
				return;
			}
			if (data is UndoRedoRequest) {
				UndoRedoRequest undoRedoRequest = data as UndoRedoRequest;
				// Update
				{
					UpdateUtils.makeUpdate<UndoRedoRequestUpdate, UndoRedoRequest> (undoRedoRequest, this.transform);
				}
				dirty = true;
				return;
			}
			if (data is ChatRoom) {
				ChatRoom chatRoom = data as ChatRoom;
				// Update
				{
					UpdateUtils.makeUpdate<ChatRoomUpdate, ChatRoom> (chatRoom, this.transform);
				}
				dirty = true;
				return;
			}
			if (data is AnimationData) {
				AnimationData animationData = data as AnimationData;
				// Update
				{
					UpdateUtils.makeUpdate<AnimationDataUpdate, AnimationData> (animationData, this.transform);
				}
				dirty = true;
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is Game) {
			Game game = data as Game;
			// Update
			{
				game.removeCallBackAndDestroy(typeof(GameActionsUpdate));
				game.removeCallBackAndDestroy (typeof(GamePreventGamePlayerAINull));
				game.removeCallBackAndDestroy (typeof(GameCheckEndUpdate));
				game.removeCallBackAndDestroy (typeof(GameCheckPlayerCountUpdate));
			}
			// child
			{
				game.gamePlayers.allRemoveCallBack (this);
				game.requestDraw.allRemoveCallBack (this);
				game.state.allRemoveCallBack (this);
				game.history.allRemoveCallBack (this);
				game.gameData.allRemoveCallBack (this);
				game.undoRedoRequest.allRemoveCallBack (this);
				game.chatRoom.allRemoveCallBack (this);
				game.animationData.allRemoveCallBack (this);
			}
			// set data null
			this.setDataNull (game);
			return;
		}
		// Child
		{
			if (data is GamePlayer) {
				GamePlayer gamePlayer = data as GamePlayer;
				// Update
				{
					gamePlayer.removeCallBackAndDestroy (typeof(GamePlayerUpdate));
				}
				return;
			}
			if (data is RequestDraw) {
				RequestDraw requestDraw = data as RequestDraw;
				// Update
				{
					requestDraw.removeCallBackAndDestroy (typeof(RequestDrawUpdate));
				}
				return;
			}
			if (data is State) {
				State state = data as State;
				// Update
				{
					switch (state.getType ()) {
					case State.Type.Load:
						{
							Load load = state as Load;
							load.removeCallBackAndDestroy (typeof(LoadUpdate));
						}
						break;
					case State.Type.Start:
						{
							Start start = state as Start;
							start.removeCallBackAndDestroy (typeof(StartUpdate));
						}
						break;
					case State.Type.Play:
						{
							Play play = state as Play;
							play.removeCallBackAndDestroy (typeof(PlayUpdate));
						}
						break;
					case State.Type.End:
						{
							End end = state as End;
							end.removeCallBackAndDestroy (typeof(EndUpdate));
						}
						break;
					default:
						Debug.LogError ("unknown state: " + state.getType () + "; " + this);
						break;
					}
				}
				return;
			}
			if (data is History) {
				// History history = data as History;
				// Update
				{
					if (this.data != null) {
						this.data.removeCallBackAndDestroy (typeof(HistoryUpdate));
					} else {
						Debug.LogError ("data null: " + this);
					}
				}
				return;
			}
			if (data is GameData) {
				GameData gameData = data as GameData;
				// Update
				{
					gameData.removeCallBackAndDestroy (typeof(GameDataUpdate));
				}
				return;
			}
			if (data is UndoRedoRequest) {
				UndoRedoRequest undoRedoRequest = data as UndoRedoRequest;
				// Update
				{
					undoRedoRequest.removeCallBackAndDestroy (typeof(UndoRedoRequestUpdate));
				}
				return;
			}
			if (data is ChatRoom) {
				ChatRoom chatRoom = data as ChatRoom;
				// Update
				{
					chatRoom.removeCallBackAndDestroy (typeof(ChatRoomUpdate));
				}
				return;
			}
			if (data is AnimationData) {
				AnimationData animationData = data as AnimationData;
				// Update
				{
					animationData.removeCallBackAndDestroy (typeof(AnimationDataUpdate));
				}
				return;
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
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case Game.Property.state:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
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
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case Game.Property.chatRoom:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case Game.Property.animationData:
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
		// Child
		{
			if (wrapProperty.p is GamePlayer) {
				return;
			}
			if (wrapProperty.p is RequestDraw) {
				return;
			}
			if (wrapProperty.p is State) {
				return;
			}
			if (wrapProperty.p is History) {
				return;
			}
			if (wrapProperty.p is GameData) {
				return;
			}
			if (wrapProperty.p is UndoRedoRequest) {
				return;
			}
			if (wrapProperty.p is ChatRoom) {
				return;
			}
			if (wrapProperty.p is AnimationData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
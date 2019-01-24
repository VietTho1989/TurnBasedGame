using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RequestDrawUpdate : UpdateBehavior<RequestDraw>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				switch (this.data.state.v.getType ()) {
				case RequestDraw.State.Type.None:
					{

					}
					break;
				case RequestDraw.State.Type.Ask:
					{
						RequestDrawStateAsk ask = this.data.state.v as RequestDrawStateAsk;
						// Who can answer: Remove all who can't answer
						List<uint> whoCanAnswer = this.data.getWhoCanAnswer ();
						{
							// accept
							for (int i = ask.accepts.vs.Count - 1; i >= 0; i--) {
								uint accept = ask.accepts.vs [i];
								if (!whoCanAnswer.Contains (accept)) {
									Debug.LogError ("this cannot accept: " + accept);
									ask.accepts.remove (accept);
								}
							}
							// cancel
							for (int i = ask.refuses.vs.Count - 1; i >= 0; i--) {
								uint refuse = ask.refuses.vs [i];
								if (!whoCanAnswer.Contains (refuse)) {
									Debug.LogError ("this cannot refuse: " + refuse);
									ask.refuses.remove (refuse);
								}
							}
						}
						// answer
						if (ask.refuses.vs.Count > 0) {
							// refuse
							RequestDrawStateCancel cancel = this.data.state.newOrOld<RequestDrawStateCancel>();
							{

							}
							this.data.state.v = cancel;
						} else {
							// accept
							bool allAccept = true;
							{
								for (int i = 0; i < whoCanAnswer.Count; i++) {
									uint needAccept = whoCanAnswer [i];
									if (!ask.accepts.vs.Contains (needAccept)) {
										Debug.LogError ("Don't contain: "+needAccept);
										allAccept = false;
										break;
									}
								}
							}
							if (allAccept) {
								RequestDrawStateAccept accept = this.data.state.newOrOld<RequestDrawStateAccept> ();
								{

								}
								this.data.state.v = accept;
							}
						}
					}
					break;
				case RequestDraw.State.Type.Accept:
					{
						RequestDrawStateAccept stateAccept = this.data.state.v as RequestDrawStateAccept;
						// Who can answer: Remove all who can't answer
						List<uint> whoCanAnswer = this.data.getWhoCanAnswer ();
						{
							// accept
							for (int i = stateAccept.accepts.vs.Count - 1; i >= 0; i--) {
								uint accept = stateAccept.accepts.vs [i];
								if (!whoCanAnswer.Contains (accept)) {
									Debug.LogError ("this cannot accept: " + accept);
									stateAccept.accepts.remove (accept);
								}
							}
							// cancel
							for (int i = stateAccept.refuses.vs.Count - 1; i >= 0; i--) {
								uint refuse = stateAccept.refuses.vs [i];
								if (!whoCanAnswer.Contains (refuse)) {
									Debug.LogError ("this cannot refuse: " + refuse);
									stateAccept.refuses.remove (refuse);
								}
							}
						}
						// answer
						if (stateAccept.refuses.vs.Count > 0) {
							stateAccept.accepts.clear ();
							stateAccept.refuses.clear ();
						} else {
							// accept
							bool allAccept = true;
							{
								for (int i = 0; i < whoCanAnswer.Count; i++) {
									uint needAccept = whoCanAnswer [i];
									if (!stateAccept.accepts.vs.Contains (needAccept)) {
										Debug.LogError ("Don't contain: "+needAccept);
										allAccept = false;
										break;
									}
								}
							}
							if (allAccept) {
								RequestDrawStateNone none = this.data.state.newOrOld<RequestDrawStateNone> ();
								{

								}
								this.data.state.v = none;
							}
						}
					}
					break;
				case RequestDraw.State.Type.Cancel:
					{
						// Chuyen sang none
						RequestDrawStateNone none = this.data.state.newOrOld<RequestDrawStateNone>();
						{

						}
						this.data.state.v = none;
					}
					break;
				default:
					Debug.LogError ("unknown type: " + this.data.state.v.getType ());
					break;
				}
			} else {
				Debug.LogError ("requestDraw null");
			}
		}	
	}

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

	#endregion

	#region implement callBacks

	private Game game = null;
	private Room room = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is RequestDraw) {
			RequestDraw requestDraw = data as RequestDraw;
			// Parent
			{
				DataUtils.addParentCallBack (requestDraw, this, ref this.game);
				DataUtils.addParentCallBack (requestDraw, this, ref this.room);
			}
			// Child
			{
				requestDraw.state.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Game
		{
			if (data is Game) {
				Game game = data as Game;
				// Child
				{
					game.gamePlayers.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// GamePlayer
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
				if (data is GamePlayer.Inform) {
					dirty = true;
					return;
				}
			}
		}
		// Room
		{
			if (data is Room) {
				Room room = data as Room;
				// Child
				{
					room.users.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// RoomUser
			{
				if (data is RoomUser) {
					RoomUser roomUser = data as RoomUser;
					// Child
					{
						roomUser.inform.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				if (data is Human) {
					dirty = true;
					return;
				}
			}
		}
		// State
		if (data is RequestDraw.State) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is RequestDraw) {
			RequestDraw requestDraw = data as RequestDraw;
			// Parent
			{
				DataUtils.removeParentCallBack (requestDraw, this, ref this.game);
				DataUtils.removeParentCallBack (requestDraw, this, ref this.room);
			}
			// Child
			{
				requestDraw.state.allRemoveCallBack (this);
			}
			// set data null
			this.setDataNull (requestDraw);
			return;
		}
		// Duel
		{
			if (data is Game) {
				Game game = data as Game;
				// Child
				{
					game.gamePlayers.allRemoveCallBack (this);
				}
				return;
			}
			// Child
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
				if (data is GamePlayer.Inform) {
					return;
				}
			}
		}
		// Room
		{
			if (data is Room) {
				Room room = data as Room;
				// Child
				{
					room.users.allRemoveCallBack (this);
				}
				return;
			}
			// Child
			{
				if (data is RoomUser) {
					RoomUser roomUser = data as RoomUser;
					// Child
					{
						roomUser.inform.allRemoveCallBack (this);
					}
					return;
				}
				if (data is Human) {
					return;	
				}
			}
		}
		// State
		if (data is RequestDraw.State) {
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is RequestDraw) {
			switch ((RequestDraw.Property)wrapProperty.n) {
			case RequestDraw.Property.state:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case RequestDraw.Property.time:
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Game
		{
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
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
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
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				if (wrapProperty.p is GamePlayer.Inform) {
					if (wrapProperty.p is Human) {
						switch ((Human.Property)wrapProperty.n) {
						case Human.Property.playerId:
							dirty = true;
							break;
						case Human.Property.account:
							break;
						case Human.Property.state:
							break;
						case Human.Property.email:
							break;
						case Human.Property.phoneNumber:
							break;
						case Human.Property.status:
							break;
						case Human.Property.birthday:
							break;
						case Human.Property.sex:
							break;
						case Human.Property.connection:
							break;
						default:
							Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					return;
				}
			}
		}
		// Room
		{
			if (wrapProperty.p is Room) {
				switch ((Room.Property)wrapProperty.n) {
				case Room.Property.name:
					break;
				case Room.Property.password:
					break;
				case Room.Property.users:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case Room.Property.state:
					break;
				case Room.Property.contestManagers:
					break;
				case Room.Property.timeCreated:
					break;
				case Room.Property.chatRoom:
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			if (wrapProperty.p is RoomUser) {
				switch ((RoomUser.Property)wrapProperty.n) {
				case RoomUser.Property.role:
					dirty = true;
					break;
				case RoomUser.Property.inform:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case RoomUser.Property.state:
					dirty = true;
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			if (wrapProperty.p is Human) {
				switch ((Human.Property)wrapProperty.n) {
				case Human.Property.playerId:
					dirty = true;
					break;
				case Human.Property.account:
					break;
				case Human.Property.state:
					break;
				case Human.Property.email:
					break;
				case Human.Property.phoneNumber:
					break;
				case Human.Property.status:
					break;
				case Human.Property.birthday:
					break;
				case Human.Property.sex:
					break;
				case Human.Property.connection:
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
		}
		// State
		if (wrapProperty.p is RequestDraw.State) {
			// None
			if (wrapProperty.p is RequestDrawStateNone) {
				switch ((RequestDrawStateNone.Property)wrapProperty.n) {
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Ask
			if (wrapProperty.p is RequestDrawStateAsk) {
				switch ((RequestDrawStateAsk.Property)wrapProperty.n) {
				case RequestDrawStateAsk.Property.accepts:
					dirty = true;
					break;
				case RequestDrawStateAsk.Property.refuses:
					dirty = true;
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Accept
			if (wrapProperty.p is RequestDrawStateAccept) {
				switch ((RequestDrawStateAccept.Property)wrapProperty.n) {
				case RequestDrawStateAccept.Property.accepts:
					dirty = true;
					break;
				case RequestDrawStateAccept.Property.refuses:
					dirty = true;
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Cancel
			if (wrapProperty.p is RequestDrawStateCancel) {
				switch ((RequestDrawStateCancel.Property)wrapProperty.n) {
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
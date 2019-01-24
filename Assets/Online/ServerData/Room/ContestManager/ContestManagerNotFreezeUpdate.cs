using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ContestManagerNotFreezeUpdate : UpdateBehavior<ContestManager>
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
					game.history.allAddCallBack (this);
					game.gamePlayers.allAddCallBack (this);
					game.chatRoom.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				// history
				{
					if (data is History) {
						History history = data as History;
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
				// gamePlayers
				if (data is GamePlayer) {
					GamePlayer gamePlayer = data as GamePlayer;
					// Child
					{
						gamePlayer.inform.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
			}
			if (data is Human) {
				Human human = data as Human;
				// Update
				{
					UpdateUtils.makeUpdate<HumanUpdate, Human> (human, this.transform);
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
			// Other
			{
				data.addCallBackAllChildren (this);
				return;
			}
			// Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is Game) {
				Game game = data as Game;
				// Child
				{
					game.history.allRemoveCallBack (this);
					game.gamePlayers.allRemoveCallBack (this);
					game.chatRoom.allRemoveCallBack (this);
				}
				this.setDataNull (game);
				return;
			}
			// Child
			{
				// history
				{
					if (data is History) {
						History history = data as History;
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
				// gamePlayers
				if (data is GamePlayer) {
					GamePlayer gamePlayer = data as GamePlayer;
					// Child
					{
						gamePlayer.inform.allRemoveCallBack (this);
					}
					return;
				}
			}
			if (data is Human) {
				Human human = data as Human;
				// Update
				{
					human.removeCallBackAndDestroy (typeof(HumanUpdate));
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
			// Other
			{
				data.removeCallBackAllChildren (this);
				return;
			}
			// Debug.LogError ("Don't process: " + data + "; " + this);
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
				case Game.Property.chatRoom:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
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
			{
				// history
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
					// Child
					if (wrapProperty.p is HumanConnection) {
						return;
					}
				}
				// gamePlayers
				if (wrapProperty.p is GamePlayer) {
					switch ((GamePlayer.Property)wrapProperty.n) {
					case GamePlayer.Property.playerIndex:
						break;
					case GamePlayer.Property.inform:
						{
							ValueChangeUtils.replaceCallBack(this, syncs);
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
			}
			if (wrapProperty.p is Human) {
				return;
			}
			if (wrapProperty.p is ChatRoom) {
				return;
			}
			// Other
			{
				if (Generic.IsAddCallBackInterface<T> ()) {
					ValueChangeUtils.replaceCallBack (this, syncs);
				}
				return;
			}
			// Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
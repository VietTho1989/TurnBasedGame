using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class LobbyPlayerUpdate : UpdateBehavior<LobbyPlayer>
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
			if (data is LobbyPlayer) {
				LobbyPlayer lobbyPlayer = data as LobbyPlayer;
				// Child
				{
					lobbyPlayer.inform.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is GamePlayer.Inform) {
					GamePlayer.Inform inform = data as GamePlayer.Inform;
					// Update
					{
						switch (inform.getType ()) {
						case GamePlayer.Inform.Type.None:
							break;
						case GamePlayer.Inform.Type.Human:
							{
								Human human = inform as Human;
								UpdateUtils.makeUpdate<HumanUpdate, Human> (human, this.transform);
							}
							break;
						case GamePlayer.Inform.Type.Computer:
							{
								Computer computer = inform as Computer;
								UpdateUtils.makeUpdate<ComputerCheckCorrectAIUpdate, Computer> (computer, this.transform);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + inform.getType () + "; " + this);
							break;
						}
					}
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is LobbyPlayer) {
				LobbyPlayer lobbyPlayer = data as LobbyPlayer;
				// Child
				{
					lobbyPlayer.inform.allRemoveCallBack (this);
				}
				this.setDataNull (lobbyPlayer);
				return;
			}
			// Child
			{
				if (data is GamePlayer.Inform) {
					GamePlayer.Inform inform = data as GamePlayer.Inform;
					// Update
					{
						switch (inform.getType ()) {
						case GamePlayer.Inform.Type.None:
							break;
						case GamePlayer.Inform.Type.Human:
							{
								Human human = inform as Human;
								human.removeCallBackAndDestroy (typeof(HumanUpdate));
							}
							break;
						case GamePlayer.Inform.Type.Computer:
							{
								Computer computer = inform as Computer;
								computer.removeCallBackAndDestroy (typeof(ComputerCheckCorrectAIUpdate));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + inform.getType () + "; " + this);
							break;
						}
					}
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if(WrapProperty.checkError(wrapProperty)){
				return;
			}
			if (wrapProperty.p is LobbyPlayer) {
				switch ((LobbyPlayer.Property)wrapProperty.n) {
				case LobbyPlayer.Property.playerIndex:
					break;
				case LobbyPlayer.Property.inform:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case LobbyPlayer.Property.isReady:
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
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
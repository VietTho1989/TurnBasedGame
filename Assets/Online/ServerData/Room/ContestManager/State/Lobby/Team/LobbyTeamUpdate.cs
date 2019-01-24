using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class LobbyTeamUpdate : UpdateBehavior<LobbyTeam>
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
			if (data is LobbyTeam) {
				LobbyTeam lobbyTeam = data as LobbyTeam;
				// Child
				{
					lobbyTeam.players.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is LobbyPlayer) {
					LobbyPlayer lobbyPlayer = data as LobbyPlayer;
					// Update
					{
						UpdateUtils.makeUpdate<LobbyPlayerUpdate, LobbyPlayer> (lobbyPlayer, this.transform);
					}
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is LobbyTeam) {
				LobbyTeam lobbyTeam = data as LobbyTeam;
				// Child
				{
					lobbyTeam.players.allRemoveCallBack (this);
				}
				this.setDataNull (lobbyTeam);
				return;
			}
			// Child
			{
				if (data is LobbyPlayer) {
					LobbyPlayer lobbyPlayer = data as LobbyPlayer;
					// Update
					{
						lobbyPlayer.removeCallBackAndDestroy (typeof(LobbyPlayerUpdate));
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
			if (wrapProperty.p is LobbyTeam) {
				switch ((LobbyTeam.Property)wrapProperty.n) {
				case LobbyTeam.Property.teamIndex:
					break;
				case LobbyTeam.Property.players:
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
			{
				if (wrapProperty.p is LobbyPlayer) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
		}

		#endregion

	}
}
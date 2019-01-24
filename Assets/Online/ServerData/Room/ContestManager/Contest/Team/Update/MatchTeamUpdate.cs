using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class MatchTeamUpdate : UpdateBehavior<MatchTeam>
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
			if (data is MatchTeam) {
				MatchTeam matchTeam = data as MatchTeam;
				// Child
				{
					matchTeam.state.allAddCallBack (this);
					matchTeam.players.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is TeamState) {
					TeamState teamState = data as TeamState;
					// Update
					{
						switch (teamState.getType ()) {
						case TeamState.Type.Normal:
							{
								TeamStateNormal teamStateNormal = teamState as TeamStateNormal;
								UpdateUtils.makeUpdate<TeamStateNormalUpdate, TeamStateNormal> (teamStateNormal, this.transform);
							}
							break;
						case TeamState.Type.Surrender:
							{
								TeamStateSurrender teamStateSurrender = teamState as TeamStateSurrender;
								UpdateUtils.makeUpdate<TeamStateSurrenderUpdate, TeamStateSurrender> (teamStateSurrender, this.transform);
							}
							break;
						default:
							Debug.LogError ("Unknown type: " + teamState.getType () + "; " + this);
							break;
						}
					}
					dirty = true;
					return;
				}
				if (data is TeamPlayer) {
					TeamPlayer teamPlayer = data as TeamPlayer;
					// Update
					{
						UpdateUtils.makeUpdate<TeamPlayerUpdate, TeamPlayer> (teamPlayer, this.transform);
					}
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is MatchTeam) {
				MatchTeam matchTeam = data as MatchTeam;
				// Child
				{
					matchTeam.state.allRemoveCallBack (this);
					matchTeam.players.allRemoveCallBack (this);
				}
				this.setDataNull (matchTeam);
				return;
			}
			// Child
			{
				if (data is TeamState) {
					TeamState teamState = data as TeamState;
					// Update
					{
						switch (teamState.getType ()) {
						case TeamState.Type.Normal:
							{
								TeamStateNormal teamStateNormal = teamState as TeamStateNormal;
								teamStateNormal.removeCallBackAndDestroy (typeof(TeamStateNormalUpdate));
							}
							break;
						case TeamState.Type.Surrender:
							{
								TeamStateSurrender teamStateSurrender = teamState as TeamStateSurrender;
								teamStateSurrender.removeCallBackAndDestroy (typeof(TeamStateSurrenderUpdate));
							}
							break;
						default:
							Debug.LogError ("Unknown type: " + teamState.getType () + "; " + this);
							break;
						}
					}
					return;
				}
				if (data is TeamPlayer) {
					TeamPlayer teamPlayer = data as TeamPlayer;
					// Update
					{
						teamPlayer.removeCallBackAndDestroy (typeof(TeamPlayerUpdate));
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
			if (wrapProperty.p is MatchTeam) {
				switch ((MatchTeam.Property)wrapProperty.n) {
				case MatchTeam.Property.teamIndex:
					break;
				case MatchTeam.Property.state:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case MatchTeam.Property.players:
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
				if (wrapProperty.p is TeamState) {
					return;
				}
				if (wrapProperty.p is TeamPlayer) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
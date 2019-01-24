using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match.RoundRobin;
using GameManager.Match.Elimination;

namespace GameManager.Match
{
	public class ContestManagerStateLobbyUpdate : UpdateBehavior<ContestManagerStateLobby>
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
			if (data is ContestManagerStateLobby) {
				ContestManagerStateLobby contestManagerStateLobby = data as ContestManagerStateLobby;
				// Update
				{
					UpdateUtils.makeUpdate<CheckLobbyPlayerInsideRoomUpdate, ContestManagerStateLobby> (contestManagerStateLobby, this.transform);
					UpdateUtils.makeUpdate<ResetPlayerReadyWhenFactoryChange, ContestManagerStateLobby> (contestManagerStateLobby, this.transform);
				}
				// Child
				{
					contestManagerStateLobby.teams.allAddCallBack (this);
					contestManagerStateLobby.state.allAddCallBack (this);
					contestManagerStateLobby.contentFactory.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is LobbyTeam) {
					LobbyTeam lobbyTeam = data as LobbyTeam;
					// Update
					{
						UpdateUtils.makeUpdate<LobbyTeamUpdate, LobbyTeam> (lobbyTeam, this.transform);
					}
					dirty = true;
					return;
				}
				if (data is ContestManagerStateLobby.State) {
					ContestManagerStateLobby.State state = data as ContestManagerStateLobby.State;
					// Update
					{
						switch (state.getType ()) {
						case ContestManagerStateLobby.State.Type.Normal:
							{
								Lobby.StateNormal stateNormal = state as Lobby.StateNormal;
								UpdateUtils.makeUpdate<Lobby.StateNormalUpdate, Lobby.StateNormal> (stateNormal, this.transform);
							}
							break;
						case ContestManagerStateLobby.State.Type.Start:
							{
								Lobby.StateStart stateStart = state as Lobby.StateStart;
								UpdateUtils.makeUpdate<Lobby.StateStartUpdate, Lobby.StateStart> (stateStart, this.transform);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + state.getType () + "; " + this);
							break;
						}
					}
					dirty = true;
					return;
				}
				if (data is ContestManagerContentFactory) {
					ContestManagerContentFactory contestManagerContentFactory = data as ContestManagerContentFactory;
					// Update
					{
						switch (contestManagerContentFactory.getType ()) {
						case ContestManagerContent.Type.Single:
							{
								SingleContestFactory singleContestFactory = contestManagerContentFactory as SingleContestFactory;
								UpdateUtils.makeUpdate<SingleContestFactoryUpdate, SingleContestFactory> (singleContestFactory, this.transform);
							}
							break;
						case ContestManagerContent.Type.RoundRobin:
							{
								RoundRobinFactory roundRobinFactory = contestManagerContentFactory as RoundRobinFactory;
								UpdateUtils.makeUpdate<RoundRobinFactoryUpdate, RoundRobinFactory> (roundRobinFactory, this.transform);
							}
							break;
						case ContestManagerContent.Type.Elimination:
							{
								EliminationFactory eliminationFactory = contestManagerContentFactory as EliminationFactory;
								UpdateUtils.makeUpdate<EliminationFactoryUpdate, EliminationFactory> (eliminationFactory, this.transform);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + contestManagerContentFactory.getType () + "; " + this);
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
			if (data is ContestManagerStateLobby) {
				ContestManagerStateLobby contestManagerStateLobby = data as ContestManagerStateLobby;
				// Update
				{
					contestManagerStateLobby.removeCallBackAndDestroy (typeof(CheckLobbyPlayerInsideRoomUpdate));
					contestManagerStateLobby.removeCallBackAndDestroy (typeof(ResetPlayerReadyWhenFactoryChange));
				}
				// Child
				{
					contestManagerStateLobby.teams.allRemoveCallBack (this);
					contestManagerStateLobby.state.allRemoveCallBack (this);
					contestManagerStateLobby.contentFactory.allRemoveCallBack (this);
				}
				this.setDataNull (contestManagerStateLobby);
				return;
			}
			// Child
			{
				if (data is LobbyTeam) {
					LobbyTeam lobbyTeam = data as LobbyTeam;
					// Update
					{
						lobbyTeam.removeCallBackAndDestroy (typeof(LobbyTeamUpdate));
					}
					return;
				}
				if (data is ContestManagerStateLobby.State) {
					ContestManagerStateLobby.State state = data as ContestManagerStateLobby.State;
					// Update
					{
						switch (state.getType ()) {
						case ContestManagerStateLobby.State.Type.Normal:
							{
								Lobby.StateNormal stateNormal = state as Lobby.StateNormal;
								stateNormal.removeCallBackAndDestroy (typeof(Lobby.StateNormalUpdate));
							}
							break;
						case ContestManagerStateLobby.State.Type.Start:
							{
								Lobby.StateStart stateStart = state as Lobby.StateStart;
								stateStart.removeCallBackAndDestroy (typeof(Lobby.StateStartUpdate));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + state.getType () + "; " + this);
							break;
						}
					}
					return;
				}
				if (data is ContestManagerContentFactory) {
					ContestManagerContentFactory contestManagerContentFactory = data as ContestManagerContentFactory;
					// Update
					{
						switch (contestManagerContentFactory.getType ()) {
						case ContestManagerContent.Type.Single:
							{
								SingleContestFactory singleContestFactory = contestManagerContentFactory as SingleContestFactory;
								singleContestFactory.removeCallBackAndDestroy (typeof(SingleContestFactoryUpdate));
							}
							break;
						case ContestManagerContent.Type.RoundRobin:
							{
								RoundRobinFactory roundRobinFactory = contestManagerContentFactory as RoundRobinFactory;
								roundRobinFactory.removeCallBackAndDestroy (typeof(RoundRobinFactoryUpdate));
							}
							break;
						case ContestManagerContent.Type.Elimination:
							{
								EliminationFactory eliminationFactory = contestManagerContentFactory as EliminationFactory;
								eliminationFactory.removeCallBackAndDestroy (typeof(EliminationFactoryUpdate));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + contestManagerContentFactory.getType () + "; " + this);
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
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is ContestManagerStateLobby) {
				switch ((ContestManagerStateLobby.Property)wrapProperty.n) {
				case ContestManagerStateLobby.Property.state:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case ContestManagerStateLobby.Property.teams:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case ContestManagerStateLobby.Property.gameType:
					break;
				case ContestManagerStateLobby.Property.randomTeamIndex:
					break;
				case ContestManagerStateLobby.Property.contentFactory:
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
				if (wrapProperty.p is LobbyTeam) {
					return;
				}
				if (wrapProperty.p is ContestManagerStateLobby.State) {
					return;
				}
				if (wrapProperty.p is ContestManagerContentFactory) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
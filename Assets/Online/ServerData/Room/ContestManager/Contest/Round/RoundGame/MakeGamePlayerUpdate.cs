using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class MakeGamePlayerUpdate : UpdateBehavior<RoundGame>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					if (this.data.playerInTeam.vs.Count == this.data.playerInGame.vs.Count) {
						Contest contest = this.data.findDataInParent<Contest> ();
						Game game = this.data.game.v;
						if (contest != null && game!=null) {
							// get old
							List<GamePlayer> oldGamePlayers = new List<GamePlayer> ();
							{
								oldGamePlayers.AddRange (game.gamePlayers.vs);
							}
							// Update
							for (int i = 0; i < this.data.playerInTeam.vs.Count; i++) {
								// find teamPlayerInform
								GamePlayer.Inform teamPlayerInform = null;
								{
									TeamPlayer teamPlayer = contest.findTeamPlayer (i, this.data.playerInTeam.vs [i]);
									if (teamPlayer != null) {
										teamPlayerInform = teamPlayer.inform.v;
									} else {
										Debug.LogError ("teamPlayer null: " + this);
									}
								}
								// Make GamePlayer
								if (teamPlayerInform != null) {
									// find gamePlayer
									GamePlayer gamePlayer = null;
									{
										// find old
										if (oldGamePlayers.Count > 0) {
											gamePlayer = oldGamePlayers [0];
										}
										// make new
										if (gamePlayer == null) {
											gamePlayer = new GamePlayer ();
											{
												gamePlayer.uid = game.gamePlayers.makeId ();
											}
											game.gamePlayers.add (gamePlayer);
										} else {
											oldGamePlayers.Remove (gamePlayer);
										}
									}
									// Update
									{
										// playerIndex
										gamePlayer.playerIndex.v = this.data.playerInGame.vs [i];
										// inform
										{
											switch (teamPlayerInform.getType ()) {
											case GamePlayer.Inform.Type.None:
												break;
											case GamePlayer.Inform.Type.Human:
												{
													Human teamPlayerHuman = teamPlayerInform as Human;
													// Find gamePlayerHuman
													Human gamePlayerHuman = null;
													{
														if (gamePlayer.inform.v != null && gamePlayer.inform.v is Human) {
															// find old
															gamePlayerHuman = gamePlayer.inform.v as Human;
														} else {
															// make new
															gamePlayerHuman = new Human ();
															{
																gamePlayerHuman.uid = gamePlayer.inform.makeId ();
															}
															gamePlayer.inform.v = gamePlayerHuman;
														}
													}
													// Update
													{
														gamePlayerHuman.playerId.v = teamPlayerHuman.playerId.v;
													}
												}
												break;
											case GamePlayer.Inform.Type.Computer:
												{
													Computer teamPlayerComputer = teamPlayerInform as Computer;
													// Find gamePlayerComputer
													Computer gamePlayerComputer = null;
													{
														if (gamePlayer.inform.v != null && gamePlayer.inform.v is Computer) {
															// find old
															gamePlayerComputer = gamePlayer.inform.v as Computer;
														} else {
															// make new
															gamePlayerComputer = new Computer();
															{
																gamePlayerComputer.uid = gamePlayer.inform.makeId ();
															}
															gamePlayer.inform.v = gamePlayerComputer;
														}
													}
													// Update
													{
														DataUtils.copyData (gamePlayerComputer, teamPlayerComputer);
													}
												}
												break;
											default:
												Debug.LogError ("Unknown type: " + teamPlayerInform.getType () + "; " + this);
												break;
											}
										}
										// swapInform: ko can
										// state: ko can
										// score: ko can
									}
								} else {
									Debug.LogError ("teamPlayer null: " + this);
								}
							}
							// remove old
							foreach (GamePlayer oldGamePlayer in oldGamePlayers) {
								game.gamePlayers.remove (oldGamePlayer);
							}
						} else {
							Debug.LogError ("contest, game null: " + this);
						}
					} else {
						Debug.LogError ("why playerInTeam, playerInGame different: " + this.data.playerInTeam.vs.Count
							+ "; " + this.data.playerInGame.vs.Count);
					}
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

		private CheckContestTeamChange<RoundGame> checkContestTeamChange = new CheckContestTeamChange<RoundGame> ();
		private GameCheckPlayerChange<Game> checkGamePlayerChange = new GameCheckPlayerChange<Game> ();

		public override void onAddCallBack<T> (T data)
		{
			if (data is RoundGame) {
				RoundGame roundGame = data as RoundGame;
				// CheckChange
				{
					checkContestTeamChange.addCallBack (this);
					checkContestTeamChange.setData (roundGame);
				}
				// Child
				{
					roundGame.game.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is CheckContestTeamChange<RoundGame>) {
				dirty = true;
				return;
			}
			// Child
			{
				if (data is Game) {
					Game game = data as Game;
					// CheckChange
					{
						checkGamePlayerChange.addCallBack (this);
						checkGamePlayerChange.setData (game);
					}
					dirty = true;
					return;
				}
				// CheckChange
				if (data is GameCheckPlayerChange<Game>) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is RoundGame) {
				RoundGame roundGame = data as RoundGame;
				// CheckChange
				{
					checkContestTeamChange.removeCallBack (this);
					checkContestTeamChange.setData (null);
				}
				// Child
				{
					roundGame.game.allRemoveCallBack (this);
				}
				this.setDataNull (roundGame);
				return;
			}
			// CheckChange
			if (data is CheckContestTeamChange<RoundGame>) {
				return;
			}
			// Child
			{
				if (data is Game) {
					// Game game = data as Game;
					// CheckChange
					{
						checkGamePlayerChange.removeCallBack (this);
						checkGamePlayerChange.setData (null);
					}
					return;
				}
				// CheckChange
				if (data is GameCheckPlayerChange<Game>) {
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
			if (wrapProperty.p is RoundGame) {
				switch ((RoundGame.Property)wrapProperty.n) {
				case RoundGame.Property.index:
					break;
				case RoundGame.Property.playerInTeam:
					dirty = true;
					break;
				case RoundGame.Property.playerInGame:
					dirty = true;
					break;
				case RoundGame.Property.game:
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
			// CheckChange
			if (wrapProperty.p is CheckContestTeamChange<RoundGame>) {
				dirty = true;
				return;
			}
			// Child
			{
				if (wrapProperty.p is Game) {
					return;
				}
				// CheckChange
				if (wrapProperty.p is GameCheckPlayerChange<Game>) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	/**
	 * make round result
	 * */
	public class CheckEndRoundUpdate : UpdateBehavior<Round>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// int newTeamResults
					List<TeamResult> newTeamResults = new List<TeamResult>();
					{
						Contest contest = this.data.findDataInParent<Contest> ();
						if (contest != null) {
							foreach (MatchTeam team in contest.teams.vs) {
								TeamResult newTeamResult = new TeamResult ();
								{
									newTeamResult.teamIndex.v = team.teamIndex.v;
								}
								newTeamResults.Add (newTeamResult);
							}
						} else {
							Debug.LogError ("contest null: " + this);
						}
					}
					// Check all game already finish
					bool allGameFinish = true;
					{
						foreach (RoundGame roundGame in this.data.roundGames.vs) {
							// add score
							foreach (TeamResult newTeamResult in newTeamResults) {
								newTeamResult.score.v = roundGame.getTeamScore (newTeamResult.teamIndex.v);
							}
							// check end
							Game game = roundGame.game.v;
							if (game != null) {
								if (!(game.state.v is GameState.End)) {
									allGameFinish = false;
								}
							} else {
								Debug.LogError ("game null: " + this);
							}
						}
					}
					// Edit score
					{
						if (newTeamResults.Count == 2) {
							CalculateScore calculateScore = this.data.calculateScore.v;
							if (calculateScore != null) {
								switch (calculateScore.getType ()) {
								case CalculateScore.Type.Sum:
									break;
								case CalculateScore.Type.WinLoseDraw:
									{
										CalculateScoreWinLoseDraw winLoseDraw = calculateScore as CalculateScoreWinLoseDraw;
										// win
										if (newTeamResults [0].score.v > newTeamResults [1].score.v) {
											newTeamResults [0].score.v = winLoseDraw.winScore.v;
											newTeamResults [1].score.v = winLoseDraw.loseScore.v;
										}
										// lose
										else if (newTeamResults [0].score.v < newTeamResults [1].score.v) {
											newTeamResults [0].score.v = winLoseDraw.loseScore.v;
											newTeamResults [1].score.v = winLoseDraw.winScore.v;
										}
										// draw
										else {
											newTeamResults [0].score.v = winLoseDraw.drawScore.v;
											newTeamResults [1].score.v = winLoseDraw.drawScore.v;
										}
									}
									break;
								default:
									Debug.LogError ("unknown type: " + calculateScore.getType () + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("calculateScore null: " + this);
							}
						}
					}
					// Process
					if (allGameFinish) {
						// Find roundStateEnd
						RoundStateEnd roundStateEnd = null;
						{
							// get old
							if (this.data.state.v is RoundStateEnd) {
								roundStateEnd = this.data.state.v as RoundStateEnd;
							}
							// make new
							if (roundStateEnd == null) {
								roundStateEnd = new RoundStateEnd ();
								{
									roundStateEnd.uid = this.data.state.makeId ();
								}
								this.data.state.v = roundStateEnd;
							}
						}
						// Update
						{
							// teamResults
							{
								// get old
								List<TeamResult> oldTeamResults = new List<TeamResult>();
								{
									oldTeamResults.AddRange (roundStateEnd.teamResults.vs);
								}
								// Update
								{
									foreach (TeamResult newTeamResult in newTeamResults) {
										// find
										TeamResult teamResult = null;
										{
											// find old
											if (oldTeamResults.Count > 0) {
												teamResult = oldTeamResults [0];
											}
											// make new
											if (teamResult == null) {
												teamResult = new TeamResult ();
												{
													teamResult.uid = roundStateEnd.teamResults.makeId ();
												}
												roundStateEnd.teamResults.add (teamResult);
											} else {
												oldTeamResults.Remove (teamResult);
											}
										}
										// Update
										{
											teamResult.teamIndex.v = newTeamResult.teamIndex.v;
											teamResult.score.v = newTeamResult.score.v;
										}
									}
								}
								// remove old
								foreach (TeamResult oldTeamResult in oldTeamResults) {
									roundStateEnd.teamResults.remove (oldTeamResult);
								}
							}
						}
					} else {
						// Find roundStatePlay
						RoundStatePlay play = null;
						{
							// get old
							if (this.data.state.v is RoundStatePlay) {
								play = this.data.state.v as RoundStatePlay;
							}
							// make new
							if (play == null) {
								play = new RoundStatePlay ();
								{
									play.uid = this.data.state.makeId ();
								}
								this.data.state.v = play;
							}
						}
						// Update
						{

						}
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

		public override void onAddCallBack<T> (T data)
		{
			if (data is Round) {
				Round round = data as Round;
				// Child
				{
					round.roundGames.allAddCallBack (this);
					round.calculateScore.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				// roundGame
				{
					if (data is RoundGame) {
						RoundGame roundGame = data as RoundGame;
						// Child
						{
							roundGame.game.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is Game) {
							Game game = data as Game;
							// Child
							{
								game.state.allAddCallBack (this);
							}
							dirty = true;
							return;
						}
						// Child
						{
							if (data is GameState.State) {
								GameState.State state = data as GameState.State;
								// Child
								{
									switch (state.getType ()) {
									case GameState.State.Type.Load:
										break;
									case GameState.State.Type.Start:
										break;
									case GameState.State.Type.Play:
										break;
									case GameState.State.Type.End:
										{
											GameState.End end = state as GameState.End;
											end.results.allAddCallBack (this);
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
							// Child
							if (data is GameState.Result) {
								dirty = true;
								return;
							}
						}
					}
				}
				if (data is CalculateScore) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is Round) {
				Round round = data as Round;
				// Child
				{
					round.roundGames.allRemoveCallBack (this);
					round.calculateScore.allRemoveCallBack (this);
				}
				this.setDataNull (round);
				return;
			}
			// Child
			{
				// roundGame
				{
					if (data is RoundGame) {
						RoundGame roundGame = data as RoundGame;
						// Child
						{
							roundGame.game.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is Game) {
							Game game = data as Game;
							// Child
							{
								game.state.allRemoveCallBack (this);
							}
							return;
						}
						// Child
						{
							if (data is GameState.State) {
								GameState.State state = data as GameState.State;
								// Child
								{
									switch (state.getType ()) {
									case GameState.State.Type.Load:
										break;
									case GameState.State.Type.Start:
										break;
									case GameState.State.Type.Play:
										break;
									case GameState.State.Type.End:
										{
											GameState.End end = state as GameState.End;
											end.results.allRemoveCallBack (this);
										}
										break;
									default:
										Debug.LogError ("unknown type: " + state.getType () + "; " + this);
										break;
									}
								}
								return;
							}
							// Child
							if (data is GameState.Result) {
								return;
							}
						}
					}
				}
				if (data is CalculateScore) {
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
			if (wrapProperty.p is Round) {
				switch ((Round.Property)wrapProperty.n) {
				case Round.Property.state:
					break;
				case Round.Property.calculateScore:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case Round.Property.index:
					break;
				case Round.Property.roundGames:
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
				// roundGame
				{
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
					// Child
					{
						if (wrapProperty.p is Game) {
							switch ((Game.Property)wrapProperty.n) {
							case Game.Property.gamePlayers:
								break;
							case Game.Property.requestDraw:
								break;
							case Game.Property.state:
								{
									ValueChangeUtils.replaceCallBack (this, syncs);
									dirty = true;
								}
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
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						// Child
						{
							if (wrapProperty.p is GameState.State) {
								GameState.State state = wrapProperty.p as GameState.State;
								// Child
								{
									switch (state.getType ()) {
									case GameState.State.Type.Load:
										break;
									case GameState.State.Type.Start:
										break;
									case GameState.State.Type.Play:
										break;
									case GameState.State.Type.End:
										{
											switch ((GameState.End.Property)wrapProperty.n) {
											case GameState.End.Property.results:
												{
													ValueChangeUtils.replaceCallBack (this, syncs);
													dirty = true;
												}
												break;
											default:
												Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
												break;
											}
										}
										break;
									default:
										Debug.LogError ("unknown type: " + state.getType () + "; " + this);
										break;
									}
								}
								return;
							}
							// Child
							if (wrapProperty.p is GameState.Result) {
								switch ((GameState.Result.Property)wrapProperty.n) {
								case GameState.Result.Property.playerIndex:
									dirty = true;
									break;
								case GameState.Result.Property.score:
									dirty = true;
									break;
								case GameState.Result.Property.reason:
									dirty = true;
									break;
								default:
									Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
									break;
								}
								return;
							}
						}
					}
				}
				if (wrapProperty.p is CalculateScore) {
					CalculateScore calculateScore = wrapProperty.p as CalculateScore;
					switch (calculateScore.getType ()) {
					case CalculateScore.Type.Sum:
						break;
					case CalculateScore.Type.WinLoseDraw:
						{
							switch ((CalculateScoreWinLoseDraw.Property)wrapProperty.n) {
							case CalculateScoreWinLoseDraw.Property.winScore:
								dirty = true;
								break;
							case CalculateScoreWinLoseDraw.Property.loseScore:
								dirty = true;
								break;
							case CalculateScoreWinLoseDraw.Property.drawScore:
								dirty = true;
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
						}
						break;
					default:
						Debug.LogError ("unknown type: " + calculateScore.getType () + "; " + this);
						break;
					}
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
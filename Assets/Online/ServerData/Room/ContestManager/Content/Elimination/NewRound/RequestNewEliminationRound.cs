using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class RequestNewEliminationRound : Data
	{

		#region State

		public abstract class State : Data
		{

			public enum Type
			{
				None,
				Ask,
				Accept
			}

			public abstract Type getType();

		}

		public VP<State> state;

		public static HashSet<uint> WhoCanAsk(Data data)
		{
			HashSet<uint> ret = new HashSet<uint> ();
			{
				if (data != null) {
					EliminationContent eliminationContent = data.findDataInParent<EliminationContent> ();
					if (eliminationContent != null) {
						// find last round
						EliminationRound lastRound = null;
						{
							if (eliminationContent.rounds.vs.Count > 0) {
								lastRound = eliminationContent.rounds.vs [eliminationContent.rounds.vs.Count - 1];
							} else {
								Debug.LogError ("Don't have any round: " + data);
							}
						}
						// Process
						if (lastRound != null) {
							// find teamIndexs left
							List<int> teamIndexs = new List<int> ();
							{
								foreach (Bracket bracket in lastRound.brackets.vs) {
									if (bracket.isActive.v) {
										if (bracket.state.v is BracketStateEnd) {
											BracketStateEnd bracketStateEnd = bracket.state.v as BracketStateEnd;
											// add winIndexs
											teamIndexs.AddRange (bracketStateEnd.winTeamIndexs.vs);
											// add loseIndexs
											{
												// find can add
												bool canAdd = false;
												{
													int nextIndex = bracket.index.v + 1;
													if (nextIndex >= 0 && nextIndex < lastRound.brackets.vs.Count) {
														Bracket nextBracket = lastRound.brackets.vs [bracket.index.v + 1];
														if (nextBracket.isActive.v) {
															canAdd = true;
														}
													}
												}
												// Process
												if (canAdd) {
													teamIndexs.AddRange (bracketStateEnd.loseTeamIndexs.vs);
												}
											}
										}
									}
								}
							}
							// add players
							{
								ContestManagerStatePlay contestManagerStatePlay = data.findDataInParent<ContestManagerStatePlay> ();
								if (contestManagerStatePlay != null) {
									foreach (MatchTeam matchTeam in contestManagerStatePlay.teams.vs) {
										if (teamIndexs.Contains (matchTeam.teamIndex.v)) {
											foreach (TeamPlayer teamPlayer in matchTeam.players.vs) {
												if (teamPlayer.inform.v is Human) {
													Human human = teamPlayer.inform.v as Human;
													ret.Add (human.playerId.v);
												}
											}
										}
									}
								} else {
									Debug.LogError ("contestManagerStatePlay null: " + data);
								}
							}
						} else {
							Debug.LogError ("lastRound null: " + data);
						}
					} else {
						Debug.LogError ("eliminationContent null: " + data);
					}
					// add admin
					if (ret.Count == 0) {
						RoomUser admin = Room.findAdmin (data);
						if (admin != null) {
							Human human = admin.inform.v as Human;
							if (human != null) {
								ret.Add (human.playerId.v);
							} else {
								Debug.LogError ("human null: " + data);
							}
						} else {
							Debug.LogError ("admin null: " + data);
						}
					}
				} else {
					Debug.LogError ("data null");
				}
			}
			Debug.LogError ("requestNewEliminationRound: whoCanAsk: " + ret.Count);
			return ret;
		}

		public static bool IsCanMakeNewRound(Data data)
		{
			if (data != null) {
				EliminationContent eliminationContent = data.findDataInParent<EliminationContent> ();
				if (eliminationContent != null) {
					bool canMake = true;
					{
						foreach (EliminationRound eliminationRound in eliminationContent.rounds.vs) {
							if (eliminationRound.isActive.v) {
								if (eliminationRound.state.v.getType () != EliminationRound.State.Type.End) {
									canMake = false;
									break;
								} else if (eliminationRound.isLastRound ()) {
									canMake = false;
									Debug.LogError ("lastRound: " + eliminationRound + "; " + data);
									break;
								}
							} else {
								Debug.LogError ("have round not active: " + data);
								canMake = false;
								break;
							}
						}
					}
					return canMake;
				} else {
					Debug.LogError ("eliminationContent null: " + data);
				}
			} else {
				Debug.LogError ("data null: " + data);
			}
			return false;
		}

		#endregion

		#region Constructor

		public enum Property
		{
			state
		}

		public RequestNewEliminationRound() : base()
		{
			this.state = new VP<State> (this, (byte)Property.state, new RequestNewEliminationRoundStateNone ());
		}

		#endregion

	}
}
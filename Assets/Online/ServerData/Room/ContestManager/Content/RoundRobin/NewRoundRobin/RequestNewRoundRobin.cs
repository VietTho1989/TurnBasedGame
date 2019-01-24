using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RequestNewRoundRobin : Data
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
					RequestNewRoundRobin requestNewRoundRobin = data.findDataInParent<RequestNewRoundRobin> ();
					if (requestNewRoundRobin != null) {
						// add all team member of contestManagerStatePlay
						{
							ContestManagerStatePlay contestManagerStatePlay = requestNewRoundRobin.findDataInParent<ContestManagerStatePlay> ();
							if (contestManagerStatePlay != null) {
								foreach (MatchTeam team in contestManagerStatePlay.teams.vs) {
									foreach (TeamPlayer teamPlayer in team.players.vs) {
										if (teamPlayer.inform.v is Human) {
											Human human = teamPlayer.inform.v as Human;
											ret.Add (human.playerId.v);
										}
									}
								}
							} else {
								Debug.LogError ("contest null: " + data);
							}
						}
						// add admin
						if (ret.Count == 0) {
							RoomUser admin = Room.findAdmin (requestNewRoundRobin);
							if (admin != null) {
								Human adminHuman = admin.inform.v;
								if (adminHuman != null) {
									ret.Add (adminHuman.playerId.v);
								} else {
									Debug.LogError ("adminHuman null: " + data);
								}
							} else {
								Debug.LogError ("admin null: " + data);
							}
						}
					} else {
						Debug.LogError ("requestNewRound null: " + data);
					}
				} else {
					Debug.LogError ("data null");
				}
			}
			return ret;
		}

		#endregion

		#region Constructor

		public enum Property
		{
			state
		}

		public RequestNewRoundRobin() : base()
		{
			this.state = new VP<State> (this, (byte)Property.state, new RequestNewRoundRobinStateNone ());
		}

		#endregion

		public static bool IsCanMakeNewRound(Data data)
		{
			if (data != null) {
				RequestNewRoundRobin requestNewRoundRobin = data.findDataInParent<RequestNewRoundRobin> ();
				if (requestNewRoundRobin != null) {
					return requestNewRoundRobin.isCanMakeNewRound ();
				} else {
					Debug.LogError ("requestNewRound null: " + data);
				}
			} else {
				Debug.LogError ("data null");
			}
			return false;
		}

		public bool isCanMakeNewRound()
		{
			bool canMake = true;
			{
				// allRoundEnd?
				if (canMake) {
					RoundRobinContent roundRobinContent = this.findDataInParent<RoundRobinContent> ();
					if (roundRobinContent != null) {
						foreach (RoundRobin roundRobin in roundRobinContent.roundRobins.vs) {
							if (roundRobin.state.v.getType () != RoundRobin.State.Type.End) {
								canMake = false;
								break;
							}
						}
					} else {
						Debug.LogError ("roundRobinContent null: " + this);
						canMake = false;
					}
				}
				// already limit round
				if (canMake) {
					RoundRobinContent roundRobinContent = this.findDataInParent<RoundRobinContent> ();
					if (roundRobinContent != null) {
						if (roundRobinContent.roundRobins.vs.Count >= roundRobinContent.getMaxRound ()) {
							canMake = false;
						}
					} else {
						Debug.LogError ("roundRobinContent null: " + this);
						canMake = false;
					}
				}
			}
			return canMake;
		}

	}
}
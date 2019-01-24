using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class SingleContestContent : ContestManagerContent
	{

		public VP<Contest> contest;

		#region Constructor

		public enum Property
		{
			contest
		}

		public SingleContestContent() : base()
		{
			this.contest = new VP<Contest> (this, (byte)Property.contest, new Contest ());
		}

		#endregion

		public override Type getType ()
		{
			return Type.Single;
		}

		public override ContestManagerContentFactory makeContentFactory ()
		{
			SingleContestFactory singleContestFactory = new SingleContestFactory ();
			{
				singleContestFactory.playerPerTeam.v = this.contest.v.playerPerTeam.v;
				// roundFactory
				{
					RoundFactory roundFactory = DataUtils.cloneData (this.contest.v.roundFactory.v) as RoundFactory;
					{
						roundFactory.uid = singleContestFactory.roundFactory.makeId ();
					}
					singleContestFactory.roundFactory.v = roundFactory;
				}
				// newRoundLimit
				{
					RequestNewRound.Limit newRoundLimit = null;
					{
						switch (this.contest.v.requestNewRound.v.limit.v.getType ()) {
						case RequestNewRound.Limit.Type.HaveLimit:
							{
								RequestNewRoundHaveLimit haveLimit = this.contest.v.requestNewRound.v.limit.v as RequestNewRoundHaveLimit;
								newRoundLimit = DataUtils.cloneData (haveLimit) as RequestNewRoundHaveLimit;
							}
							break;
						case RequestNewRound.Limit.Type.NoLimit:
							{
								newRoundLimit = new RequestNewRoundNoLimit ();
							}
							break;
						default:
							Debug.LogError ("unknown type: " + this.contest.v.requestNewRound.v.limit.v.getType () + "; " + this);
							break;
						}
					}
					if (newRoundLimit != null) {
						newRoundLimit.uid = singleContestFactory.newRoundLimit.makeId ();
						singleContestFactory.newRoundLimit.v = newRoundLimit;
					} else {
						Debug.LogError ("limit null: " + this);
					}
				}
			}
			return singleContestFactory;
		}

		public override GameType.Type getGameTypeType ()
		{
			GameType.Type gameTypeType = GameType.Type.CHESS;
			{
				Contest contest = this.contest.v;
				if (contest != null) {
					RoundFactory roundFactory = contest.roundFactory.v;
					if (roundFactory != null) {
						gameTypeType = roundFactory.getGameTypeType ();
					} else {
						Debug.LogError ("roundFactory null: " + this);
					}
				} else {
					Debug.LogError ("contest null: " + this);
				}
			}
			return gameTypeType;
		}

	}
}
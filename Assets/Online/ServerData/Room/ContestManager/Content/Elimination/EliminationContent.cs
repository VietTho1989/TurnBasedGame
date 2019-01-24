using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class EliminationContent : ContestManagerContent
	{

		#region contest factory

		public VP<SingleContestFactory> singleContestFactory;

		#endregion

		public const int MAX_BRACKET = 5;

		public const int MAX_TEAM_PER_BRACKET = 64;

		public LP<uint> initTeamCounts;

		#region round

		public VP<RequestNewEliminationRound> requestNewRound;

		public LP<EliminationRound> rounds;

		#endregion

		#region Constructor

		public enum Property
		{
			singleContestFactory,
			initTeamCounts,
			requestNewRound,
			rounds
		}

		public EliminationContent() : base()
		{
			this.singleContestFactory = new VP<SingleContestFactory> (this, (byte)Property.singleContestFactory, new SingleContestFactory ());
			this.initTeamCounts = new LP<uint> (this, (byte)Property.initTeamCounts);
			this.requestNewRound = new VP<RequestNewEliminationRound> (this, (byte)Property.requestNewRound, new RequestNewEliminationRound ());
			this.rounds = new LP<EliminationRound> (this, (byte)Property.rounds);
		}

		#endregion

		#region implement base

		public override Type getType ()
		{
			return Type.Elimination;
		}

		public override ContestManagerContentFactory makeContentFactory ()
		{
			EliminationFactory eliminationFactory = new EliminationFactory ();
			{
				// singleContestFactory
				{
					SingleContestFactory singleContestFactory = DataUtils.cloneData (this.singleContestFactory.v) as SingleContestFactory;
					{
						singleContestFactory.uid = eliminationFactory.singleContestFactory.makeId ();
					}
					eliminationFactory.singleContestFactory.v = singleContestFactory;
				}
				// initTeamCounts
				eliminationFactory.initTeamCounts.vs.AddRange (this.initTeamCounts.vs);
			}
			return eliminationFactory;
		}

		public override GameType.Type getGameTypeType()
		{
			GameType.Type gameTypeType = GameType.Type.CHESS;
			{
				SingleContestFactory singleContestFactory = this.singleContestFactory.v;
				if (singleContestFactory != null) {
					int teamCountPerContest = 1;
					int playerPerTeam = 1;
					singleContestFactory.getTeamCountAndPlayerPerTeamGameType (out teamCountPerContest, out playerPerTeam, out gameTypeType);
				} else {
					Debug.LogError ("singleContestFactory null: " + this);
				}
			}
			return gameTypeType;
		}

		#endregion

	}
}
using System;

namespace Peregrine.Engine
{
	public class MatchResult
	{
		public readonly int RoundNumber;
		public readonly int MatchNumber;
		public readonly Player Winner;

		public MatchResult(int roundNumber, int matchNumber, Player winner)
		{
			RoundNumber = roundNumber;
			MatchNumber = matchNumber;
			Winner = winner;
		}
		
		public override string ToString()
		{
			return String.Format("{0}-{1}: {2}", RoundNumber, MatchNumber, Winner == null ? "{draw}" : Winner.ToString());
		}
	}
}
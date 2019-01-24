using System;

namespace Peregrine.Engine
{
	public class GameResult
	{
		public readonly Player Winner;

		public GameResult(Player winner)
		{
			Winner = winner;
		}

		public override string ToString()
		{
			return Winner == null ? "{draw}" : Winner.ToString();
		}
	}
}

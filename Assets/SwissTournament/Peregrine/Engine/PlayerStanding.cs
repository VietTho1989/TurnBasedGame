using System;

namespace Peregrine.Engine
{
	public class PlayerStanding
	{
		public readonly Player Player;
		public readonly int Rank;
		public readonly decimal MatchPoints;
		public readonly decimal OpponentsMatchWinPercentage;
		public readonly decimal GameWinPercentage;
		public readonly decimal OpponentsGameWinPercentage;

		public PlayerStanding(Player player, int rank, decimal matchPoints, decimal opponentsMatchWinPercentage, decimal gameWinPercentage, decimal opponentsGameWinPercentage)
		{
			Player = player;
			Rank = rank;
			MatchPoints = matchPoints;
			OpponentsMatchWinPercentage = opponentsMatchWinPercentage;
			GameWinPercentage = gameWinPercentage;
			OpponentsGameWinPercentage = opponentsGameWinPercentage;
		}

		public override string ToString()
		{
			return String.Format("#{0} - {1} - {2} - {3}", Rank, Player, MatchPoints, OpponentsMatchWinPercentage);
		}
	}
}
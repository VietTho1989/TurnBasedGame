
namespace Peregrine.Engine
{
	public class RecordMatchResultsCommand
	{
		public readonly Player Player;
		public readonly int? Wins;
		public readonly int? Losses;
		public readonly int? Draws;

		public RecordMatchResultsCommand(Player player, int? wins, int? losses, int? draws)
		{
			Player = player;
			Wins = wins;
			Losses = losses;
			Draws = draws;
		}
	}
}

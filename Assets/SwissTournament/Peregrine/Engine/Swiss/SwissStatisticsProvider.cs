using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Peregrine.Engine.Swiss
{
	public class SwissStatisticsProvider
	{
		public const int MatchWinPoints = 3;
		public const int MatchDrawPoints = 1;
		public const int MatchLossPoints = 0;
		public const int GameWinPoints = 3;
		public const int GameDrawPoints = 1;
		public const int GameLossPoints = 0;
		//public const decimal MinimumMatchWinPercentage = 1.0m / 3.0m;
		//public const decimal MinimumGameWinPercentage = 1.0m / 3.0m;
		public const decimal MinimumMatchWinPercentage = 0;
		public const decimal MinimumGameWinPercentage = 0;

		public int GetNumberOfRoundsInTournament(SwissTournamentContext context)
		{
			var playerCount = context.Players.Count();
			var roundCount = Math.Ceiling(Math.Log(playerCount, 2));

			// No less than one round
			return (int)Math.Max(1, roundCount);
		}

		public int GetMatchPoints(IEnumerable<Round> rounds, Player player)
		{
			return GetMatchPointsPerRound(rounds, player)
				.Sum();
		}

		public IEnumerable<int> GetMatchPointsPerRound(IEnumerable<Round> rounds, Player player)
		{
			return rounds
				.SelectMany(round => GetMatchPointsPerRound(round, player));
		}

		IEnumerable<int> GetMatchPointsPerRound(Round round, Player player)
		{
			return round
				.Matches
				.Select(match => GetMatchPointsPerRound(match, player))
				.Where(points => points.HasValue)
				.Select(points => points.Value);
		}

		int? GetMatchPointsPerRound(Match match, Player player)
		{
			if(!match.Players.Contains(player))
				return null;

			if(!match.GameResults.Any())
				return null;

			var wins = match
				.GameResults
				.Where(gameResult => gameResult.Winner == player)
				.Count();

			var losses = match
				.GameResults
				.Where(gameResult => gameResult.Winner != player && gameResult.Winner != null)
				.Count();

			/*var draws = match
				.GameResults
				.Where(gameResult => gameResult.Winner == null)
				.Count();*/

			return wins > losses ? MatchWinPoints
				: wins == losses ? MatchDrawPoints
				: MatchLossPoints;
		}

		IEnumerable<int> GetGamePoints(IEnumerable<Round> rounds, Player player)
		{
			return rounds
				.SelectMany(round => GetGamePoints(round, player));
		}

		IEnumerable<int> GetGamePoints(Round round, Player player)
		{
			return round
				.Matches
				.SelectMany(match => GetGamePoints(match, player));
		}

		IEnumerable<int> GetGamePoints(Match match, Player player)
		{
			return match
				.GameResults
				.Where(gameResult => match.Players.Contains(player))
				.Select(gameResult => GetGamePoints(gameResult, player));
		}

		int GetGamePoints(GameResult gameResult, Player player)
		{
			return gameResult.Winner == player ? GameWinPoints
				: gameResult.Winner == null ? GameDrawPoints
				: GameLossPoints;
		}

		decimal GetMatchWinPercentage(IEnumerable<Round> rounds, Player player)
		{
			// Match win percentage is the ratio of matches won out of what could have been won.
			// This only counts rounds played, including byes. After a player drops, their win 
			// percentage remains unchanged.
			var matchWinPercentage = GetMatchPointsPerRound(rounds, player)
				.Select(points => points / (decimal)MatchWinPoints)
				.DefaultIfEmpty(0)
				.Average();

			// To prevent skewing, there is a minimum of 0.33
			return Math.Max(matchWinPercentage, MinimumMatchWinPercentage);
		}

		public decimal GetGameWinPercentage(IEnumerable<Round> rounds, Player player)
		{
			// Game win percentage is the ratio of games won out of what could have been won.
			// This only counts rounds played, including byes. After a player drops, their win 
			// percentage remains unchanged.
			var percentage = GetGamePoints(rounds, player)
				.Select(points => points / (decimal)GameWinPoints)
				.DefaultIfEmpty(0)
				.Average();

			// To prevent skewing, there is a minimum of 0.33
			return Math.Max(percentage, MinimumGameWinPercentage);
		}

		IEnumerable<Player> GetPlayerOpponents(IEnumerable<Round> rounds, Player player)
		{
			return rounds
				.SelectMany(round => GetPlayerOpponents(round, player));
		}

		IEnumerable<Player> GetPlayerOpponents(Round round, Player player)
		{
			return round
				.Matches
				.SelectMany(match => GetPlayerOpponents(match, player));
		}

		IEnumerable<Player> GetPlayerOpponents(Match match, Player player)
		{
			return match
				.Players
				.Where(p => match.Players.Contains(player))
				.Where(p => p != player);
		}

		public decimal GetOpponentsMatchWinPercentage(IEnumerable<Round> rounds, Player player)
		{
			return GetPlayerOpponents(rounds, player)
				.Select(opponent => GetMatchWinPercentage(rounds, opponent))
				.DefaultIfEmpty(0)
				.Average();
		}

		public decimal GetOpponentsGameWinPercentage(IEnumerable<Round> rounds, Player player)
		{
			return GetPlayerOpponents(rounds, player)
				.Select(opponent => GetGameWinPercentage(rounds, opponent))
				.DefaultIfEmpty(0)
				.Average();
		}
	}
}

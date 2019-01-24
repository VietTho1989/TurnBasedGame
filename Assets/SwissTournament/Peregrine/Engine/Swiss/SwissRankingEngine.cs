using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Peregrine.Engine.Swiss
{
	public class SwissRankingEngine : IRankingEngine<SwissTournamentContext>
	{
		readonly SwissStatisticsProvider StatisticsProvider;

		public SwissRankingEngine(SwissStatisticsProvider statisticsProvider)
		{
			StatisticsProvider = statisticsProvider;
		}

		public IEnumerable<Match> GetPairings(SwissTournamentContext context, int? roundNumber = null)
		{
			return BuildRounds(context, roundNumber)
				.Select(round => round.Matches)
				.LastOrDefault();
		}

		public IEnumerable<Round> BuildRounds(SwissTournamentContext context, int? throughRoundNumber = null)
		{
			// Round 1 pairing is completely random.

			// Subsequent rounds have players grouped by match points and randomly
			// ordered within that group. 

			// If there's an uneven number of players, the player with the lowest
			// match points who has not yet had a bye is given a bye.

			// Then, going from the highest match points to the lowest, the topmost 
			// player is paired with the second topmost player. If they've had a match 
			// before, the third topmost player is paired, continuing on until a 
			// player is found that has not had a match with the topmost. Both players 
			// are then removed from the pool of  available players and the process 
			// repeats.

			// We accomplish random pairing in round 1 by all players having zero
			// match points and using the above algorithm.

			// Byes are assigned first, then pairings. I haven't been able to devise
			// a scenario where two players end up getting paired twice because a player 
			// was given a bye, but this system does introduce the potential for it.

			var roundNumber = throughRoundNumber ?? context.ActiveRound ?? 1;
			var roundSeed = context.TournamentSeed ^ roundNumber;
			var roundRng = new System.Random(roundSeed);

			var previousRounds = roundNumber == 1
				? Enumerable.Empty<Round>()
				: BuildRounds(context, roundNumber - 1);

			var pairingPool = context
				.Players
				.Where(player => player.RoundDropped == null || player.RoundDropped > roundNumber)
				.Select(player => new
				{
					Player = player,
					MatchPoints = StatisticsProvider.GetMatchPoints(previousRounds, player),
					Randomizer = roundRng.Next(),
				})
				.OrderByDescending(o => o.MatchPoints)
				.ThenBy(o => o.Randomizer)
				.Select(o => o.Player)
				.ToArray()		// Flatten to ensure the RNG is only called once per player
				.AsEnumerable();

			var roundMatchResults = context
				.MatchResults
				.Where(mr => mr.RoundNumber == roundNumber)
				.ToArray();

			var previousByes = previousRounds
				.SelectMany(round => round.Matches)
				.Where(match => match.Players.Count() == 1)
				.SelectMany(match => match.Players)
				.ToArray();

			var previousPairings = previousRounds
				.SelectMany(round => round.Matches)
				.Select(match => match
					.Players
					.OrderBy(player => player.Identifier))
				.ToArray();

			// Find the first match set that doesn't include a rematch
			var matchSets = GenerateMatchSets(pairingPool, previousByes, roundMatchResults);
			var selectedMatchSet = matchSets
				.Where(matchSet => matchSet
					.Select(match => match
						.Players
						.OrderBy(player => player.Identifier)
					)
					.All(players => !previousPairings
						.Any(previous => previous
							.SequenceEqual(players)
						)
					)
				)
				.FirstOrDefault()
				?? matchSets.First();

			return previousRounds
				.Concat(new Round(
					roundNumber, 
					selectedMatchSet
						.OrderBy(match => match.Number)
						.ToArray()
				))
				.ToArray();
		}

		public IEnumerable<IEnumerable<Match>> GenerateMatchSets(IEnumerable<Player> unpairedPlayers, IEnumerable<Player> previousByes, IEnumerable<MatchResult> roundMatchResults)
		{
			if(unpairedPlayers.Count() % 2 == 1)
				return GenerateByeMatch(unpairedPlayers, previousByes, roundMatchResults, 1);
			else
				return GeneratePairedMatches(unpairedPlayers, roundMatchResults, 1);
		}

		public IEnumerable<IEnumerable<Match>> GenerateByeMatch(IEnumerable<Player> unpairedPlayers, IEnumerable<Player> previousByes, IEnumerable<MatchResult> roundMatchResults, int matchNumber)
		{
			var bye = unpairedPlayers
				.Reverse()
				.SkipWhile(player => previousByes.Contains(player))
				.FirstOrDefault()
				?? unpairedPlayers.Last();		// Fallback in case every player has had a bye
			
			return GeneratePairedMatches(unpairedPlayers.Except(bye), roundMatchResults, matchNumber)
				.Select(subsequentMatchSet => subsequentMatchSet
					.Concat(new Match(
						Math.Max(subsequentMatchSet.Max(mm => mm.Number) + 1, matchNumber),
						new[] { bye },
						new[]					// Byes automatically receive a match win
							{ 
								new GameResult(bye), 
								new GameResult(bye) 
							}
					)));
		}

		public IEnumerable<IEnumerable<Match>> GeneratePairedMatches(IEnumerable<Player> unpairedPlayers, IEnumerable<MatchResult> roundMatchResults, int matchNumber)
		{
			if(!unpairedPlayers.Any())
			{
				yield return Enumerable.Empty<Match>();
				yield break;
			}

			 var remainingPairings = unpairedPlayers.Count() / 2;

			for(var skip = 0; skip < remainingPairings; skip++)
				for(var offset = 0; offset < remainingPairings; offset++)
				{
					var match = new Match(
						number: matchNumber,
						players: new[] 
							{
								unpairedPlayers.Skip(offset).First(), 
								unpairedPlayers.Skip(offset + 1 + skip).First() 
							},
						gameResults: roundMatchResults
							.Where(mr => mr.MatchNumber == matchNumber)
							.Select(mr => new GameResult(mr.Winner))
							.ToArray());

					var subsequentMatches = GeneratePairedMatches(unpairedPlayers.Except(match.Players), roundMatchResults, matchNumber + 1);
					foreach(var subsequentMatch in subsequentMatches)
						yield return new[] { match }.Concat(subsequentMatch);
				}
		}

		public IEnumerable<PlayerStanding> GetStandings(SwissTournamentContext context, int? roundNumber = null)
		{
			var applicableRounds = BuildRounds(context, roundNumber)
				.ToArray();

			return context
				.Players
				.Select(player => new
				{
					Player = player,
					MatchPoints = StatisticsProvider.GetMatchPoints(applicableRounds, player),
					OpponentsMatchWinPercentage = StatisticsProvider.GetOpponentsMatchWinPercentage(applicableRounds, player),
					GameWinPercentage = StatisticsProvider.GetGameWinPercentage(applicableRounds, player),
					OpponentsGameWinPercentage = StatisticsProvider.GetOpponentsGameWinPercentage(applicableRounds, player),
				})
				.OrderByDescending(o => o.MatchPoints)
				.ThenByDescending(o => o.OpponentsMatchWinPercentage)
				.ThenByDescending(o => o.GameWinPercentage)
				.ThenByDescending(o => o.OpponentsGameWinPercentage)
				.Select((o, rank) => new PlayerStanding(
					player: o.Player,
					rank: rank + 1,
					matchPoints: o.MatchPoints,
					opponentsMatchWinPercentage: o.OpponentsMatchWinPercentage,
					gameWinPercentage: o.GameWinPercentage,
					opponentsGameWinPercentage: o.OpponentsGameWinPercentage
				))
				.ToArray();
		}
	}
}
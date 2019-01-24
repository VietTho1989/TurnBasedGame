using System;
using System.Collections.Generic;
using System.Linq;

namespace Peregrine.Engine.Swiss
{
	public class SwissTournamanetContextBuilder : IContextBuilder<SwissTournamentContext>
	{
		readonly SwissStatisticsProvider StatisticsProvider;
		readonly SwissRankingEngine RankingEngine;

		public SwissTournamanetContextBuilder(SwissStatisticsProvider statisticsProvider, SwissRankingEngine rankingEngine)
		{
			StatisticsProvider = statisticsProvider;
			RankingEngine = rankingEngine;
		}

		public CommandResult<SwissTournamentContext> ProcessCommand(SwissTournamentContext context, CreateTournamentCommand command)
		{
			var rng = new Random((int)command.Timestamp.UtcTicks);

			return new CommandAcceptedResult<SwissTournamentContext>(
					new SwissTournamentContext(context, tournamentSeed: rng.Next())
				);
		}

		public CommandResult<SwissTournamentContext> ProcessCommand(SwissTournamentContext context, AddPlayerCommand command)
		{
			// Don't allow the same player to be added twice
			if(context.Players.Contains(command.Player))
				return new CommandRejectedResult<SwissTournamentContext>(context, "Player already in tournament");

			// Update players
			return new CommandAcceptedResult<SwissTournamentContext>(
					new SwissTournamentContext(context, players: context.Players.Concat(command.Player))
				);
		}

		public CommandResult<SwissTournamentContext> ProcessCommand(SwissTournamentContext context, RemovePlayerCommand command)
		{
			// Don't allow a player not in the tournament to drop
			if(!context.Players.Contains(command.Player))
				return new CommandRejectedResult<SwissTournamentContext>(context, "Player not in tournament");

			// Don't allow a player that has already dropped to drop
			if(command.Player.RoundDropped.HasValue)
				return new CommandRejectedResult<SwissTournamentContext>(context, "Player already dropped");

			// If the tournament hasn't started, remove the player from the list of players.
			// Otherwise flag the player as dropped
			if(context.State == TournamentState.TournamentCreated)
				return new CommandAcceptedResult<SwissTournamentContext>(
						new SwissTournamentContext(
								context,
								players: context
									.Players
									.Except(command.Player)
							)
					);
			else
				return new CommandAcceptedResult<SwissTournamentContext>(
						new SwissTournamentContext(
								context,
								players: context
									.Players
									.Replace(command.Player, new Player(command.Player.Identifier, context.ActiveRound))
							)
					);
		}

		public CommandResult<SwissTournamentContext> ProcessCommand(SwissTournamentContext context, RecordMatchResultsCommand command)
		{
			// Don't allow recording match results for a player not in the tournament
			if(!context.Players.Contains(command.Player))
				return new CommandRejectedResult<SwissTournamentContext>(context, "Player not in tournament");

			// Don't allow recording match results for dropped players
			if(command.Player.RoundDropped < context.ActiveRound)
				return new CommandRejectedResult<SwissTournamentContext>(context, "Player dropped before this round");

			// Don't allow recording match results for players not in the current round
			var playersMatchesThisRound = RankingEngine
				.GetPairings(context)
				.Where(match => match
					.Players
					.Contains(command.Player)
				);

			if(!playersMatchesThisRound.Any())
				return new CommandRejectedResult<SwissTournamentContext>(context, "Player does not have a match in this round");

			// Don't allow recording match results for players with a bye
			var playerHasByeThisRound = playersMatchesThisRound
				.Where(match => match.Players.Count() == 1)
				.Any();

			if(playerHasByeThisRound)
				return new CommandRejectedResult<SwissTournamentContext>(context, "Player has a bye this round");

			// Update match results
			var roundNumber = context.ActiveRound ?? 1;
			var matchNumber = playersMatchesThisRound
					.Select(match => match.Number)
					.FirstOrDefault();

			var oldMatchResults = context
				.MatchResults
				.Where(mr => mr.RoundNumber == roundNumber)
				.Where(mr => mr.MatchNumber == matchNumber)
				.ToArray();

			IEnumerable<MatchResult> appliedWins;
			if(command.Wins != null)
				appliedWins = Enumerable
					.Range(0, command.Wins.Value)
					.Select(i => new MatchResult(roundNumber, matchNumber, command.Player));
			else
				appliedWins = oldMatchResults
					.Where(mr => mr.Winner == command.Player);

			IEnumerable<MatchResult> appliedDraws;
			if(command.Draws != null)
				appliedDraws = Enumerable
					.Range(0, command.Draws.Value)
					.Select(i => new MatchResult(roundNumber, matchNumber, null));
			else
				appliedDraws = oldMatchResults
					.Where(mr => mr.Winner == null);

			// Remove all old entries for this round/player and apply a new one.
			// Removes any zeroed out results.
			var updatedMatchResults = context
				.MatchResults
				.Except(oldMatchResults)
				.Concat(appliedWins)
				.Concat(appliedDraws);

			return new CommandAcceptedResult<SwissTournamentContext>(
				new SwissTournamentContext(context, matchResults: updatedMatchResults)
			);
		}

		public CommandResult<SwissTournamentContext, bool> ProcessCommand(SwissTournamentContext context, EndRoundCommand command)
		{
			var nextRoundNumber = (context.ActiveRound ?? 1) + 1;

			// Check the number of rounds
			// If round number + 1 > the number of rounds, tournament is over
			// Otherwise just move to next round
			var allRoundsCompleted = nextRoundNumber > StatisticsProvider.GetNumberOfRoundsInTournament(context);

			if(allRoundsCompleted)
				return new RoundCompletedResult<SwissTournamentContext>(context, allRoundsCompleted);
			else
				return new RoundCompletedResult<SwissTournamentContext>(
					new SwissTournamentContext(context, activeRound: nextRoundNumber),
					allRoundsCompleted
				);
		}
	}
}

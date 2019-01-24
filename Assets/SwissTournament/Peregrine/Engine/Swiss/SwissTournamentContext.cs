using System.Collections.Generic;
using System.Linq;
using Unstated;

namespace Peregrine.Engine.Swiss
{
	public class SwissTournamentContext : IStateMachineContext<SwissTournamentContext, TournamentState>
	{
		public readonly int TournamentSeed;
		public readonly TournamentState State;
		public readonly IEnumerable<Player> Players;
		public readonly IEnumerable<MatchResult> MatchResults;
		public readonly int? ActiveRound;

		public SwissTournamentContext(int tournamentSeed, TournamentState state, IEnumerable<Player> players, IEnumerable<MatchResult> matchResults, int? activeRound)
		{
			TournamentSeed = tournamentSeed;
			State = state;
			Players = players ?? Enumerable.Empty<Player> ();
			MatchResults = matchResults ?? Enumerable.Empty<MatchResult> ();
			ActiveRound = activeRound;
		}

		public SwissTournamentContext(SwissTournamentContext source, int? tournamentSeed = null, TournamentState? state = null, IEnumerable<Player> players = null, IEnumerable<MatchResult> matchResults = null, int? activeRound = null)
		{
			TournamentSeed = tournamentSeed ?? source.TournamentSeed;
			State = state ?? source.State;
			Players = players ?? source.Players;
			MatchResults = matchResults ?? source.MatchResults;
			ActiveRound = activeRound ?? source.ActiveRound;
		}

		TournamentState IStateMachineContext<SwissTournamentContext, TournamentState>.GetState()
		{
			return State;
		}

		SwissTournamentContext IStateMachineContext<SwissTournamentContext, TournamentState>.UpdateState(TournamentState state)
		{
			return new SwissTournamentContext(this, state: state);
		}
	}
}
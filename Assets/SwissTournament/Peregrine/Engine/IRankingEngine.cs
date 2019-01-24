using System.Collections.Generic;

namespace Peregrine.Engine
{
	public interface IRankingEngine<TContext>
	{
		IEnumerable<Match> GetPairings(TContext context, int? roundNumber = null);
		IEnumerable<PlayerStanding> GetStandings(TContext context, int? roundNumber = null);
	}
}
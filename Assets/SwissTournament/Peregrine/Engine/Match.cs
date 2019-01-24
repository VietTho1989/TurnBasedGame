using System;
using System.Collections.Generic;
using System.Linq;

namespace Peregrine.Engine
{
	public class Match
	{
		public readonly int Number;
		public readonly IEnumerable<Player> Players;
		public readonly IEnumerable<GameResult> GameResults;

		public Match(int number, IEnumerable<Player> players, IEnumerable<GameResult> gameResults)
		{
			Number = number;
			Players = players ?? Enumerable.Empty<Player>();
			GameResults = gameResults ?? Enumerable.Empty<GameResult>();
		}
			
		public override string ToString()
		{
			string[] foo = Players.OfType<object> ().Select (o => o.ToString ()).ToArray ();
			return String.Format ("{0}: {1}", Number, String.Join (" vs ", foo));
		}
	}
}
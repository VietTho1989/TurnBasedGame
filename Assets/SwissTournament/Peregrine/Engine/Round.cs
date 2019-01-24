using System;
using System.Collections.Generic;

namespace Peregrine.Engine
{
	public class Round
	{
		public readonly int Number;
		public readonly IEnumerable<Match> Matches;

		public Round(int number, IEnumerable<Match> matches)
		{
			Number = number;
			Matches = matches;
		}

		public override string ToString()
		{
			return String.Format("Round {0}", Number);
		}
	}
}

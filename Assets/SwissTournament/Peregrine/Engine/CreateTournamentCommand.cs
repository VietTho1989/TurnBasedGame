using System;

namespace Peregrine.Engine
{
	public class CreateTournamentCommand
	{
		public readonly DateTimeOffset Timestamp;

		public CreateTournamentCommand(DateTimeOffset timestamp)
		{
			Timestamp = timestamp;
		}
	}
}

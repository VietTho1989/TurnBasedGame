using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Peregrine.Engine;
using Peregrine.Engine.Swiss;
using System.Linq;
using System.Text;
using UnityEngine.Assertions;

public class SwissTournamentTest : MonoBehaviour {

	void Start () {
		/*var generator = new SwissRankingEngine(new SwissStatisticsProvider());

		var players = Enumerable
			.Range(0, 26)
			.Select(number  => new String(new[] { (char)('a' + number) }))
			.Select(name => new Player(name, null));

		// Careful with the playerCount. 12 will take almost a minute to execute.
		{
			int playerCount = 8;
			var matchSets = generator.GeneratePairedMatches(players.Take(playerCount), Enumerable.Empty<MatchResult>(), 1);

			var uniquePairings = matchSets
				.Select(matchSet => matchSet
					.Select(match => match
						.Players
						.OrderBy(player => player.Identifier)
						.Select(player => player.Identifier)
					)
					.Select(playerIdentifiers => String.Join("-", playerIdentifiers.ToArray()))
					.OrderBy(pairing => pairing)
				)
				.Select(playerIdentifiers => String.Join("|", playerIdentifiers.ToArray()))
				.OrderBy(matchSetPairings => matchSetPairings)
				.Distinct()
				.ToArray();

			// Expected number of pairings is (2n - 1)!! where n = playerCount / 2
			// See http://en.wikipedia.org/wiki/Perfect_matching and http://en.wikipedia.org/wiki/Double_factorial for reasoning 
			// See http://mathworld.wolfram.com/DoubleFactorial.html for the definition of (2n - 1)!! used here
			var expectedUniquePairings = (int)(Factorial(playerCount) / (Math.Pow(2, playerCount / 2) * Factorial(playerCount / 2)));
			var actualUniquePairings = uniquePairings.Count();
			// TODO Assert.Equal(expectedUniquePairings, actualUniquePairings);
			// Debug.LogError("Equal: "+(expectedUniquePairings==actualUniquePairings));
			Debug.LogError("uniquePairing: "+String.Join("\n",uniquePairings));
		}*/
		checkWork ();
	}

	public void checkWork()
	{
		// Yay happy path!

		var statisticsProvider = new SwissStatisticsProvider();
		var rankingEngine = new SwissRankingEngine(statisticsProvider);
		var contextBuilder = new SwissTournamanetContextBuilder(statisticsProvider, rankingEngine);
		var commandEventHandler = new CommandEventHandler<SwissTournamentContext>(contextBuilder);

		var context = new SwissTournamentContext(0, TournamentState.None, null, null, null);

		// Create the tournament
		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0, 
				aggregateId: "T1",
				name: TournamentCommand.CreateTournament.ToString(), 
				properties: new Dictionary<string, string>
				{
					{ "Timestamp", new DateTimeOffset(1982, 7, 22, 01, 14, 22, TimeSpan.FromHours(-7)).ToString() }
				})
		);

		// Assert.IsTrue (TournamentState.TournamentCreated == context.State);
		// Assert.IsFalse (0 == context.TournamentSeed);

		// Add players
		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.AddPlayer.ToString(),
				properties: new Dictionary<string, string>
				{
					{ "Player", "A" }
				})
		);

		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.AddPlayer.ToString(),
				properties: new Dictionary<string, string>
				{
					{ "Player", "B" }
				})
		);

		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.AddPlayer.ToString(),
				properties: new Dictionary<string, string>
				{
					{ "Player", "C" }
				})
		);

		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.AddPlayer.ToString(),
				properties: new Dictionary<string, string>
				{
					{ "Player", "D" }
				})
		);

		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.AddPlayer.ToString(),
				properties: new Dictionary<string, string>
				{
					{ "Player", "E" }
				})
		);

		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.AddPlayer.ToString(),
				properties: new Dictionary<string, string>
				{
					{ "Player", "F" }
				})
		);

		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.AddPlayer.ToString(),
				properties: new Dictionary<string, string>
				{
					{ "Player", "G" }
				})
		);

		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.AddPlayer.ToString(),
				properties: new Dictionary<string, string>
				{
					{ "Player", "H" }
				})
		);

		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.AddPlayer.ToString(),
				properties: new Dictionary<string, string>
				{
					{ "Player", "I" }
				})
		);

		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.AddPlayer.ToString(),
				properties: new Dictionary<string, string>
				{
					{ "Player", "J" }
				})
		);

		//Assert.IsTrue (TournamentState.TournamentStarted == context.State);
		//Assert.IsNotNull(context.Players);
		var roundOnePairings = rankingEngine.GetPairings(context, 1);
		{
			string[] foo = roundOnePairings.OfType<object> ().Select (o => o.ToString ()).ToArray ();
			Debug.LogError ("roundOnePairing: \n" + String.Join ("\n", foo));
		}

		// Record match results for round 1
		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.RecordMatchResults.ToString(),
				properties: new Dictionary<string, string>
				{
					{ "Player", "A" },
					{ "Wins", "1" },
				})
		);

		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.RecordMatchResults.ToString(),
				properties: new Dictionary<string, string>
				{
					{ "Player", "B" },
					{ "Wins", "1" },
				})
		);

		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.RecordMatchResults.ToString(),
				properties: new Dictionary<string, string>
				{
					{ "Player", "D" },
					{ "Wins", "1" },
				})
		);

		// End round 1
		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.EndRound.ToString(),
				properties: new Dictionary<string, string>
				{
				})
		);

		// Get standings as of round 1. If we include round 2, we get the bye points immediately.
		Debug.LogError("context");
		var roundOneStandings = rankingEngine.GetStandings(context, 1);
		{
			string[] foo = roundOneStandings.OfType<object> ().Select (o => o.ToString ()).ToArray ();
			Debug.LogError ("finalStandings: " + String.Join ("\n", foo));
		}
		var roundTwoPairings = rankingEngine.GetPairings(context, 2);
		{
			string[] foo = roundTwoPairings.OfType<object> ().Select (o => o.ToString ()).ToArray ();
			Debug.LogError ("roundTwoPairing: \n" + String.Join ("\n", foo));
		}

		// Record match results for round 2
		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.RecordMatchResults.ToString(),
				properties: new Dictionary<string, string>
				{
					{ "Player", "A" },
					{ "Wins", "1" },
				})
		);

		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.RecordMatchResults.ToString(),
				properties: new Dictionary<string, string>
				{
					{ "Player", "C" },
					{ "Wins", "1" },
				})
		);

		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.RecordMatchResults.ToString(),
				properties: new Dictionary<string, string>
				{
					{ "Player", "D" },
					{ "Wins", "1" },
				})
		);

		// End round 2
		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.EndRound.ToString(),
				properties: new Dictionary<string, string>
				{
				})
		);

		var roundTwoStandings = rankingEngine.GetStandings(context, 2);
		{
			string[] foo = roundTwoStandings.OfType<object> ().Select (o => o.ToString ()).ToArray ();
			Debug.LogError ("finalStandings: " + String.Join ("\n", foo));
		}

		// Record match results for round 3
		var roundThreePairings = rankingEngine.GetPairings(context, 3);
		{
			string[] foo = roundThreePairings.OfType<object> ().Select (o => o.ToString ()).ToArray ();
			Debug.LogError ("roundThreePairing: \n" + String.Join ("\n", foo));
		}

		// Record match results for round 3
		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.RecordMatchResults.ToString(),
				properties: new Dictionary<string, string>
				{
					{ "Player", "A" },
					{ "Wins", "1" },
				})
		);

		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.RecordMatchResults.ToString(),
				properties: new Dictionary<string, string>
				{
					{ "Player", "B" },
					{ "Wins", "1" },
				})
		);

		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.RecordMatchResults.ToString(),
				properties: new Dictionary<string, string>
				{
					{ "Player", "E" },
					{ "Wins", "1" },
				})
		);

		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.RecordMatchResults.ToString(),
				properties: new Dictionary<string, string>
				{
					{ "Player", "G" },
					{ "Wins", "1" },
				})
		);

		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.RecordMatchResults.ToString(),
				properties: new Dictionary<string, string>
				{
					{ "Player", "J" },
					{ "Wins", "1" },
				})
		);

		// End round 3 and the tournament
		context = commandEventHandler.ProcessCommand(
			context: context,
			commandEvent: new CommandEvent(
				sequence: 0,
				aggregateId: "T1",
				name: TournamentCommand.EndRound.ToString(),
				properties: new Dictionary<string, string>
				{
				})
		);

		var finalStandings = rankingEngine.GetStandings(context);
		{
			string[] foo = finalStandings.OfType<object> ().Select (o => o.ToString ()).ToArray ();
			Debug.LogError ("finalStandings: " + String.Join ("\n", foo));
		}
	}

	int Factorial(int n)
	{
		if(n == 0)
			return 1;
		else
			return n * Factorial(n - 1);
	}
}

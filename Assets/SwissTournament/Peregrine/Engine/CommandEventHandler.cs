using UnityEngine;
using System;
using Unstated;

namespace Peregrine.Engine
{
	/// <summary>
	/// Takes raw CommandEvents and applies them to a context.
	/// </summary>
	public class CommandEventHandler<TContext>
		where TContext : IStateMachineContext<TContext, TournamentState>
	{
		readonly IContextBuilder<TContext> ContextBuilder;
		readonly StateMachine<TournamentState, TournamentCommand, TContext> StateMachine;

		public CommandEventHandler(IContextBuilder<TContext> contextBuilder)
		{
			ContextBuilder = contextBuilder;
			StateMachine = new StateMachineBuilder()
				.CreateStateMachine<TournamentState, TournamentCommand, TContext>(
					sm => sm.DefineState(TournamentState.None)
						.WithTrigger(TournamentCommand.CreateTournament, TournamentState.TournamentCreated),

					sm => sm.DefineState(TournamentState.TournamentCreated)
						.WithTrigger(TournamentCommand.AddPlayer, TournamentState.TournamentStarted),

					sm => sm.DefineState(TournamentState.TournamentStarted)
						.WithTrigger(TournamentCommand.AddPlayer, TournamentState.TournamentStarted)
						.WithTrigger(TournamentCommand.RemovePlayer, TournamentState.TournamentStarted)
						.WithTrigger(TournamentCommand.RecordMatchResults, TournamentState.RoundStarted),

					sm => sm.DefineState(TournamentState.RoundStarted)
						.WithTrigger(TournamentCommand.RecordMatchResults, TournamentState.RoundStarted)
						.WithTrigger(TournamentCommand.EndRound, (bool allRoundsCompleted) => !allRoundsCompleted, TournamentState.RoundEnded)
						.WithTrigger(TournamentCommand.EndRound, (bool allRoundsCompleted) => allRoundsCompleted, TournamentState.TournamentEnded),

					sm => sm.DefineState(TournamentState.RoundEnded)
						.WithTrigger(TournamentCommand.RemovePlayer, TournamentState.RoundEnded)
						.WithTrigger(TournamentCommand.RecordMatchResults, TournamentState.RoundStarted)
				);
		}

		public TContext ProcessCommand(TContext context, CommandEvent commandEvent)
		{
			// Parse
			TournamentCommand commandName;
			{
				try{
					commandName = (TournamentCommand)System.Enum.Parse (typeof(TournamentCommand), commandEvent.Name);
				} catch(Exception e){
					// Error
					Debug.LogError("Error: "+e);
					throw new Exception (String.Format ("Unknown command name: {0}", commandEvent.Name));
				}
				/*if (!Enum.TryParse<TournamentCommand> (commandEvent.Name, out commandName))
					throw new Exception (String.Format ("Unknown command name: {0}", commandEvent.Name));*/
			}

			// Dispatch
			switch(commandName)
			{
				case TournamentCommand.CreateTournament:
					return CreateTournament(context, commandEvent);

				case TournamentCommand.AddPlayer:
					return AddPlayer(context, commandEvent);

				case TournamentCommand.RemovePlayer:
					return RemovePlayer(context, commandEvent);

				case TournamentCommand.RecordMatchResults:
					return RecordMatchResults(context, commandEvent);

				case TournamentCommand.EndRound:
					return EndRound(context, commandEvent);

				default:
					throw new Exception(String.Format("Unhandled TournamentCommand: {0}", commandName));
			}
		}

		TContext CreateTournament(TContext context, CommandEvent commandEvent)
		{
			var timestamp = DateTimeOffset.Parse(commandEvent.Properties["Timestamp"]);
			var command = new CreateTournamentCommand(timestamp);

			return Fire(
					context,
					TournamentCommand.CreateTournament,
					() => ContextBuilder.ProcessCommand(context, command)
				);
		}

		TContext AddPlayer(TContext context, CommandEvent commandEvent)
		{
			var player = new Player(commandEvent.Properties["Player"], null);
			var command = new AddPlayerCommand(player);

			return Fire(
					context,
					TournamentCommand.AddPlayer,
					() => ContextBuilder.ProcessCommand(context, command)
				);
		}

		TContext RemovePlayer(TContext context, CommandEvent commandEvent)
		{
			var player = new Player(commandEvent.Properties["Player"], null);
			var command = new RemovePlayerCommand(player);

			return Fire(
					context,
					TournamentCommand.RemovePlayer,
					() => ContextBuilder.ProcessCommand(context, command)
				);
		}

		TContext RecordMatchResults(TContext context, CommandEvent commandEvent)
		{
			var player = new Player(commandEvent.Properties["Player"], null);

			int winsValue;
			int? wins = null;
			if(commandEvent.Properties.ContainsKey("Wins") && Int32.TryParse(commandEvent.Properties["Wins"], out winsValue))
				wins = winsValue;

			int lossesValue;
			int? losses = null;
			if(commandEvent.Properties.ContainsKey("Losses") && Int32.TryParse(commandEvent.Properties["Losses"], out lossesValue))
				losses = lossesValue;

			int drawsValue;
			int? draws = null;
			if(commandEvent.Properties.ContainsKey("Draws") && Int32.TryParse(commandEvent.Properties["Draws"], out drawsValue))
				draws = drawsValue;

			var command = new RecordMatchResultsCommand(player, wins, losses, draws);

			return Fire(
					context,
					TournamentCommand.RecordMatchResults,
					() => ContextBuilder.ProcessCommand(context, command)
				);
		}

		TContext EndRound(TContext context, CommandEvent commandEvent)
		{
			var command = new EndRoundCommand();

			return Fire(
					context,
					TournamentCommand.EndRound,
					() => ContextBuilder.ProcessCommand(context, command)
				);
		}

		TContext Fire(TContext context, TournamentCommand command, Func<CommandResult<TContext>> action)
		{
			// Check if the FSM will let us transition
			if (!StateMachine.CanFire (context, command)) {
				throw new InvalidOperationException (command.ToString ());
			}

			// Execute the action
			var result = action();
			if (result.Rejected) {
				Debug.LogError ("result reject: " + command + ", " + result.RejectionReason);
				// TODO throw new InvalidOperationException (result.RejectionReason);
			}

			// Apply the transition
			return StateMachine.Fire(result.Context, command);
		}

		TContext Fire<T0>(TContext context, TournamentCommand command, Func<CommandResult<TContext, T0>> action)
		{
			// Check if the FSM will let us transition
			if(!StateMachine.CanFire(context, command))
				throw new InvalidOperationException(command.ToString());

			// Execute the action
			var result = action();
			if(result.Rejected)
				throw new InvalidOperationException(result.RejectionReason);

			// Apply the transition
			return StateMachine.Fire(result.Context, command, result.ReturnValue);
		}
	}
}
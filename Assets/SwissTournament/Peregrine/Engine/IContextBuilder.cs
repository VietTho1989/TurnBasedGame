
namespace Peregrine.Engine
{
	public interface IContextBuilder<TContext>
	{
		CommandResult<TContext> ProcessCommand(TContext context, CreateTournamentCommand command);
		CommandResult<TContext> ProcessCommand(TContext context, AddPlayerCommand command);
		CommandResult<TContext> ProcessCommand(TContext context, RemovePlayerCommand command);
		CommandResult<TContext> ProcessCommand(TContext context, RecordMatchResultsCommand command);
		CommandResult<TContext, bool> ProcessCommand(TContext context, EndRoundCommand command);
	}
}

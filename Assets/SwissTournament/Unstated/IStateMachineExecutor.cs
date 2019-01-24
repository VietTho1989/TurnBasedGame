
namespace Unstated
{
	public interface IStateMachineExecutor<TState, TTrigger, TContext>
		where TContext : IStateMachineContext<TContext, TState>
	{
		bool CanFire(IStateMachineDefinition<TState, TTrigger> definition, TContext context, TTrigger trigger);
		TContext Fire(IStateMachineDefinition<TState, TTrigger> definition, TContext context, TTrigger trigger);
		TContext Fire<TPredicateArg0>(IStateMachineDefinition<TState, TTrigger> definition, TContext context, TTrigger trigger, TPredicateArg0 predicateArg0);
	}
}

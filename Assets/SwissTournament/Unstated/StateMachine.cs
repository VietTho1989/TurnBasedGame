using System.Collections.Generic;

namespace Unstated
{
	public class StateMachine<TState, TTrigger, TContext>
		where TContext: IStateMachineContext<TContext, TState>
	{
		readonly IStateMachineDefinition<TState, TTrigger> Definition;
		readonly IStateMachineExecutor<TState, TTrigger, TContext> Executor;

		public StateMachine(IStateMachineDefinition<TState, TTrigger> definition, IStateMachineExecutor<TState, TTrigger, TContext> executor = null)
		{
			Definition = definition;
			Executor = executor ?? new StateMachineExecutor<TState, TTrigger, TContext>();
		}

		public bool CanFire(TContext stateMachineContext, TTrigger trigger)
		{
			return Executor.CanFire(Definition, stateMachineContext, trigger);
		}

		public TContext Fire(TContext stateMachineContext, TTrigger trigger)
		{
			return Executor.Fire(Definition, stateMachineContext, trigger);
		}

		public TContext Fire<TPredicateArg0>(TContext stateMachineContext, TTrigger trigger, TPredicateArg0 predicateArg0)
		{
			return Executor.Fire(Definition, stateMachineContext, trigger, predicateArg0);
		}
	}
}

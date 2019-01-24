using System;
using System.Collections.Generic;
using System.Linq;

namespace Unstated
{
	public class StateMachineBuilder
	{
		public StateMachine<TState, TTrigger, TContext> CreateStateMachine<TState, TTrigger, TContext>(params Func<StateMachineBuilderContext<TState, TTrigger, StateMachineBuilderContext.WithNothing>, StateMachineBuilderContext<TState, TTrigger>>[] stateDefiners)
			where TContext: IStateMachineContext<TContext, TState>
		{
			var definition = CreateStateMachineDefinition(stateDefiners);
			return new StateMachine<TState, TTrigger, TContext>(definition);
		}

		public IStateMachineDefinition<TState, TTrigger> CreateStateMachineDefinition<TState, TTrigger>(params Func<StateMachineBuilderContext<TState, TTrigger, StateMachineBuilderContext.WithNothing>, StateMachineBuilderContext<TState, TTrigger>>[] stateDefiners)
		{
			var stateDefinitions = stateDefiners
				.Select(definer => definer(new StateMachineBuilderContext<TState, TTrigger, StateMachineBuilderContext.WithNothing>(null)))
				.Select(context => context.StateDefinition);

			return new StateMachineDefinition<TState, TTrigger>(stateDefinitions);
		}
	}

	public abstract class StateMachineBuilderContext
	{
		public class WithNothing { }
		public class WithState { }
		public class WithTriggers { }
	}

	public abstract class StateMachineBuilderContext<TState, TTrigger>
	{
		internal readonly StateDefinition<TState, TTrigger> StateDefinition;

		internal StateMachineBuilderContext(StateDefinition<TState, TTrigger> stateDefinition)
		{
			StateDefinition = stateDefinition;
		}
	}

	public class StateMachineBuilderContext<TState, TTrigger, TFlag> : StateMachineBuilderContext<TState, TTrigger>
	{
		internal StateMachineBuilderContext(StateDefinition<TState, TTrigger> stateDefinition)
			: base(stateDefinition)
		{ }
	}

	public static class StateMachineBuilderExtensions
	{
		public static StateMachineBuilderContext<TState, TTrigger, StateMachineBuilderContext.WithState> DefineState<TState, TTrigger>(this StateMachineBuilderContext<TState, TTrigger, StateMachineBuilderContext.WithNothing> that, TState state)
		{
			return new StateMachineBuilderContext<TState, TTrigger, StateMachineBuilderContext.WithState>(stateDefinition: new StateDefinition<TState,TTrigger>(state, null));
		}

		public static StateMachineBuilderContext<TState, TTrigger, StateMachineBuilderContext.WithTriggers> WithTrigger<TState, TTrigger>(this StateMachineBuilderContext<TState, TTrigger, StateMachineBuilderContext.WithState> that, TTrigger trigger, TState targetState)
		{
			return new StateMachineBuilderContext<TState, TTrigger, StateMachineBuilderContext.WithTriggers>(new StateDefinition<TState,TTrigger>(that.StateDefinition.State, that.StateDefinition.Triggers.Concat(new[] { new TriggerDefinition<TState, TTrigger>(trigger, targetState) })));
		}

		public static StateMachineBuilderContext<TState, TTrigger, StateMachineBuilderContext.WithTriggers> WithTrigger<TState, TTrigger, TPredicateArg0>(this StateMachineBuilderContext<TState, TTrigger, StateMachineBuilderContext.WithState> that, TTrigger trigger, Func<TPredicateArg0, bool> predicate, TState targetState)
		{
			return new StateMachineBuilderContext<TState, TTrigger, StateMachineBuilderContext.WithTriggers>(new StateDefinition<TState, TTrigger>(that.StateDefinition.State, that.StateDefinition.Triggers.Concat(new[] { new TriggerDefinition<TState, TTrigger, TPredicateArg0>(trigger, predicate, targetState) })));
		}

		public static StateMachineBuilderContext<TState, TTrigger, StateMachineBuilderContext.WithTriggers> WithTrigger<TState, TTrigger>(this StateMachineBuilderContext<TState, TTrigger, StateMachineBuilderContext.WithTriggers> that, TTrigger trigger, TState targetState)
		{
			return new StateMachineBuilderContext<TState, TTrigger, StateMachineBuilderContext.WithTriggers>(new StateDefinition<TState, TTrigger>(that.StateDefinition.State, that.StateDefinition.Triggers.Concat(new[] { new TriggerDefinition<TState, TTrigger>(trigger, targetState) })));
		}

		public static StateMachineBuilderContext<TState, TTrigger, StateMachineBuilderContext.WithTriggers> WithTrigger<TState, TTrigger, TPredicateArg0>(this StateMachineBuilderContext<TState, TTrigger, StateMachineBuilderContext.WithTriggers> that, TTrigger trigger, Func<TPredicateArg0, bool> predicate, TState targetState)
		{
			return new StateMachineBuilderContext<TState, TTrigger, StateMachineBuilderContext.WithTriggers>(new StateDefinition<TState, TTrigger>(that.StateDefinition.State, that.StateDefinition.Triggers.Concat(new[] { new TriggerDefinition<TState, TTrigger, TPredicateArg0>(trigger, predicate, targetState) })));
		}
	}
}

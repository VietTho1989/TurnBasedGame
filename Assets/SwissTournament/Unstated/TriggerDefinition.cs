using System;

namespace Unstated
{
	public abstract class TriggerDefinitionBase<TState, TTrigger>
	{
		public readonly TTrigger Trigger;
		public readonly TState TargetState;

		public TriggerDefinitionBase(TTrigger trigger, TState targetState)
		{
			Trigger = trigger;
			TargetState = targetState;
		}
	}

	public class TriggerDefinition<TState, TTrigger> : TriggerDefinitionBase<TState, TTrigger>
	{
		public TriggerDefinition(TTrigger trigger, TState targetState)
			: base(trigger, targetState)
		{ }
	}

	public class TriggerDefinition<TState, TTrigger, TPredicateArg0> : TriggerDefinitionBase<TState, TTrigger>
	{
		public readonly Func<TPredicateArg0, bool> Predicate;

		public TriggerDefinition(TTrigger trigger, Func<TPredicateArg0, bool> predicate, TState targetState)
			: base(trigger, targetState)
		{
			Predicate = predicate;
		}
	}
}

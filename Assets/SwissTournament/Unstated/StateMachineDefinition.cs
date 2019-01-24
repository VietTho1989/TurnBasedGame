using System.Collections.Generic;
using System.Linq;

namespace Unstated
{
	public class StateMachineDefinition<TState, TTrigger> : IStateMachineDefinition<TState, TTrigger>
	{
		readonly IEnumerable<StateDefinition<TState, TTrigger>> States;
		readonly IEqualityComparer<TState> StateComparer;
		readonly IEqualityComparer<TTrigger> TriggerComparer;

		public StateMachineDefinition(IEnumerable<StateDefinition<TState, TTrigger>> states, IEqualityComparer<TState> stateComparer = null, IEqualityComparer<TTrigger> triggerComparer = null)
		{
			States = states ?? Enumerable.Empty<StateDefinition<TState, TTrigger>>();
			StateComparer = stateComparer ?? EqualityComparer<TState>.Default;
			TriggerComparer = triggerComparer ?? EqualityComparer<TTrigger>.Default;
		}

		public IEnumerable<StateDefinition<TState, TTrigger>> GetStates()
		{
			return States;
		}

		public bool Equals(TState x, TState y)
		{
			return StateComparer.Equals(x, y);
		}

		public bool Equals(TTrigger x, TTrigger y)
		{
			return TriggerComparer.Equals(x, y);
		}
	}
}

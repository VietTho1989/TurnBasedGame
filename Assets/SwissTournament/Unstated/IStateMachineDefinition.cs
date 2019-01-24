using System.Collections.Generic;

namespace Unstated
{
	public interface IStateMachineDefinition<TState, TTrigger>
	{
		IEnumerable<StateDefinition<TState, TTrigger>> GetStates();
		bool Equals(TState x, TState y);
		bool Equals(TTrigger x, TTrigger y);
	}
}

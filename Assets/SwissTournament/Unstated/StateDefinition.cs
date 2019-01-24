using System.Collections.Generic;
using System.Linq;

namespace Unstated
{
	public class StateDefinition<TState, TTrigger>
	{
		public readonly TState State;
		public readonly IEnumerable<TriggerDefinitionBase<TState, TTrigger>> Triggers;

		public StateDefinition(TState state, IEnumerable<TriggerDefinitionBase<TState, TTrigger>> triggers)
		{
			State = state;
			Triggers = triggers ?? Enumerable.Empty<TriggerDefinitionBase<TState, TTrigger>>();
		}
	}
}


namespace Unstated
{
	public class StateMachineContext<TState> : IStateMachineContext<StateMachineContext<TState>, TState>
	{
		public readonly TState State;

		public StateMachineContext(TState state)
		{
			State = state;
		}

		public TState GetState()
		{
			return State;
		}

		public StateMachineContext<TState> UpdateState(TState state)
		{
			return new StateMachineContext<TState>(state);
		}
	}
}

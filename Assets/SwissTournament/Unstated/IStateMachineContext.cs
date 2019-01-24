
namespace Unstated
{
	public interface IStateMachineContext<TContext, TState>
		where TContext: IStateMachineContext<TContext, TState>
	{
		TState GetState();
		TContext UpdateState(TState state);
	}
}

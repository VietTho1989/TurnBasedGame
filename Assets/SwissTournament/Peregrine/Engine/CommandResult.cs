
namespace Peregrine.Engine
{
	/// <summary>
	/// The result of applying a command to a context.
	/// </summary>
	public abstract class CommandResult<TContext>
	{
		public readonly bool Rejected;
		public readonly string RejectionReason;
		public readonly TContext Context;

		public CommandResult(TContext context, bool rejected, string rejectedReason)
		{
			Context = context;
			Rejected = rejected;
			RejectionReason = rejectedReason;
		}
	}

	public abstract class CommandResult<TContext, TReturnValue> : CommandResult<TContext>
	{
		public readonly TReturnValue ReturnValue;

		public CommandResult(TContext context, bool rejected, string rejectedReason, TReturnValue returnValue)
			: base(context, rejected, rejectedReason)
		{
			ReturnValue = returnValue;
		}
	}

	public class CommandAcceptedResult<TContext> : CommandResult<TContext>
	{
		public CommandAcceptedResult(TContext context)
			: base(context, false, null)
		{ }
	}

	public class RoundCompletedResult<TContext> : CommandResult<TContext, bool>
	{
		public RoundCompletedResult(TContext context, bool allRoundsCompleted)
			: base(context, false, null, allRoundsCompleted)
		{ }
	}

	public class CommandRejectedResult<TContext, TReturnValue> : CommandResult<TContext, TReturnValue>
	{
		public CommandRejectedResult(TContext context, string reason, TReturnValue returnValue)
			: base(context, true, reason, returnValue)
		{ }
	}

	public class CommandRejectedResult<TContext> : CommandResult<TContext>
	{
		public CommandRejectedResult(TContext context, string reason)
			: base(context, true, reason)
		{ }
	}
}
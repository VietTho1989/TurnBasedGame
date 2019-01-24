using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unstated
{
	[Serializable]
	public class StateMachineException : Exception
	{
		public StateMachineException() { }
		public StateMachineException(string message) : base(message) { }
		public StateMachineException(string message, Exception inner) : base(message, inner) { }
		protected StateMachineException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context)
			: base(info, context) { }
	}

	[Serializable]
	public class InvalidTriggerException<TState, TTrigger> : StateMachineException
	{
		public readonly TState State;
		public readonly TTrigger Trigger;

		public InvalidTriggerException(TState state, TTrigger trigger, string message = null, Exception inner = null)
			: base(message ?? "Trigger not defined for state", inner)
		{
			State = state;
			Trigger = trigger;
		}

		protected InvalidTriggerException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context)
			: base(info, context) { }
	}
}

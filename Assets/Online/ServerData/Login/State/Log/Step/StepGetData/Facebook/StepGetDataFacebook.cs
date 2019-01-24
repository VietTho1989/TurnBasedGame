using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
	public class StepGetDataFacebook : StepGetData.Sub
	{

		#region State

		public enum State
		{
			Start,
			Get, 
			Wait
		}

		public VP<State> state;

		#endregion

		#region Constructor

		public enum Property
		{
			state
		}

		public StepGetDataFacebook() : base()
		{
			this.state = new VP<State> (this, (byte)Property.state, State.Start);
		}

		#endregion

		public override Account.Type getType ()
		{
			return Account.Type.FACEBOOK;
		}

	}
}
// EAAVV6eXo8l0BAKFOMB9cPpQqZBL6PlnjkzpzDwIqA0zR2jpfexhZCeoJy96LfUt5GCgqSTMsXU8uvfdvuXRq2AJbegV5hWP1aYtvaBnO6c80s5QrAHA5PQBhbqXikZBQ5UUmQ09mniyPRMutFZAJbXBjAXsQXack6QywvkQho3ZAdzL9EhzPPR8r0kqlr2kUZD
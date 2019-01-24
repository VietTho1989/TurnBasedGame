using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
	public class StepLogin : Log.Step
	{

		#region State

		public enum State
		{
			Not,
			Log,
			Wait
		}

		public VP<State> state;

		#endregion

		#region Constructor

		public enum Property
		{
			state
		}

		public StepLogin() : base()
		{
			this.state = new VP<State> (this, (byte)Property.state, State.Not);
		}

		#endregion

		public override Type getType ()
		{
			return Type.Login;
		}

	}
}
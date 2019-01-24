using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
	public class NotConnect : Log.ConnectState
	{

		#region State

		public enum State
		{
			Start,
			Connect,
			Wait
		}

		public VP<State> state;

		#endregion

		#region Constructor

		public enum Property
		{
			state
		}

		public NotConnect() : base()
		{
			this.state = new VP<State> (this, (byte)Property.state, State.Start);
		}

		#endregion

		public override Type getType ()
		{
			return Type.NotConnect;
		}

	}
}
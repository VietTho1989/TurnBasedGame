using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
	public class Log : Login.State
	{

		#region Connect

		public abstract class ConnectState : Data
		{

			public enum Type
			{
				NotConnect,
				HaveConnect
			}

			public abstract Type getType();

		}

		public VP<ConnectState> connectState;

		#endregion

		#region Step

		public abstract class Step : Data
		{

			public enum Type
			{
				Start,
				GetData,
				Login
			}

			public abstract Type getType ();

		}

		public VP<Step> step;

		#endregion

		public VP<float> time;

		public VP<float> timeOut;

		#region Constructor

		public enum Property
		{
			connectState,
			step,
			time,
			timeOut
		}

		public Log() : base()
		{
			this.connectState = new VP<ConnectState> (this, (byte)Property.connectState, new NotConnect ());
			this.step = new VP<Step> (this, (byte)Property.step, new StepStart ());
			this.time = new VP<float> (this, (byte)Property.time, 0);
			this.timeOut = new VP<float> (this, (byte)Property.timeOut, 60 * 5);// 5 minute
		}

		#endregion

		public override Type getType ()
		{
			return Type.Log;
		}

	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
	public class None : Login.State
	{

		public abstract class State : Data
		{
			public enum Type
			{
				Normal,
				Success,
				Fail
			}

			public abstract Type getType ();

		}

		public VP<State> state;

		#region Constructor

		public enum Property
		{
			state
		}

		public None() : base()
		{
			this.state = new VP<State> (this, (byte)Property.state, new StateNormal ());
		}

		#endregion

		public override Type getType ()
		{
			return Type.None;
		}

	}
}
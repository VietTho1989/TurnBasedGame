using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
	public class StateSuccess : None.State
	{

		#region Constructor

		public enum Property
		{

		}

		public StateSuccess() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Success;
		}

	}
}
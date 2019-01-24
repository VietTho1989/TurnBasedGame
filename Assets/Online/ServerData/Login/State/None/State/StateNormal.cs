using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
	public class StateNormal : None.State
	{

		#region Constructor

		public enum Property
		{

		}

		public StateNormal() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Normal;
		}

	}
}
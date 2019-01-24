using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
	public class StepStart : Log.Step
	{

		#region Constructor

		public enum Property
		{

		}

		public StepStart() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Start;
		}

	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
	public class StepGetDataDevice : StepGetData.Sub
	{

		#region Constructor

		public enum Property
		{

		}

		public StepGetDataDevice() : base()
		{

		}

		#endregion

		public override Account.Type getType ()
		{
			return Account.Type.DEVICE;
		}

	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
	public class StepGetDataEmail : StepGetData.Sub
	{

		#region Constructor

		public enum Property
		{

		}

		public StepGetDataEmail() : base()
		{

		}

		#endregion

		public override Account.Type getType ()
		{
			return Account.Type.EMAIL;
		}

	}
}
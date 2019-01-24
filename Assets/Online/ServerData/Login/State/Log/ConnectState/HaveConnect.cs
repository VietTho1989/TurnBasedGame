using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
	public class HaveConnect : Log.ConnectState
	{

		#region Constructor

		public enum Property
		{

		}

		public HaveConnect() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.HaveConnect;
		}

	}
}
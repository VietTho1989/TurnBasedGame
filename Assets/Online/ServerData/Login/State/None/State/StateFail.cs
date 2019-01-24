using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
	public class StateFail : None.State
	{

		public enum Reason
		{
			TimeOut,
			ConnectFail,
			WrongPassword,
			GetFacebookDataFail
		}

		public VP<Reason> reason;

		#region Constructor

		public enum Property
		{
			reason
		}

		public StateFail() : base()
		{
			this.reason = new VP<Reason> (this, (byte)Property.reason, Reason.TimeOut);
		}

		#endregion

		public override Type getType ()
		{
			return Type.Fail;
		}

	}
}
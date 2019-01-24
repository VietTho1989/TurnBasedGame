using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
	public class StepGetData : Log.Step
	{

		#region Sub

		public abstract class Sub : Data
		{

			public abstract Account.Type getType();

		}

		public VP<Sub> sub;

		#endregion

		#region Constructor

		public enum Property
		{
			sub
		}

		public StepGetData() : base()
		{
			this.sub = new VP<Sub> (this, (byte)Property.sub, null);
		}

		#endregion

		public override Type getType ()
		{
			return Type.GetData;
		}

	}
}
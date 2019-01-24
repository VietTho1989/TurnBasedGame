using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Rights
{
	public class NoLimit : Limit
	{

		#region Constructor

		public enum Property
		{

		}

		public NoLimit() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.NoLimit;
		}

		public override bool isOverLimit (int number)
		{
			return false;
		}

	}
}
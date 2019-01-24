using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
	public class Load : State
	{

		#region Constructor

		public enum Property
		{

		}

		public Load() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Load;
		}

	}
}
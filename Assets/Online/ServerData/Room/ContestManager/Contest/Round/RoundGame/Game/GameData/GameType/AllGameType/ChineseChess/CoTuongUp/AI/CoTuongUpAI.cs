using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CoTuongUp
{
	public class CoTuongUpAI : Computer.AI
	{

		#region Constructor

		public enum Property
		{

		}

		public CoTuongUpAI() : base()
		{

		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.CO_TUONG_UP;
		}

	}
}
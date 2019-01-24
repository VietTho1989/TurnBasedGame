using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RussianDraught
{
	public class DefaultRussianDraught : DefaultGameType
	{

		#region Constructor

		public enum Property
		{

		}

		public DefaultRussianDraught() : base()
		{

		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.RussianDraught;
		}

		public override GameType makeDefaultGameType ()
		{
			RussianDraught newRussianDraught = Core.unityMakePositionByFen (RussianDraught.StartFen);
			return newRussianDraught;
		}

	}
}
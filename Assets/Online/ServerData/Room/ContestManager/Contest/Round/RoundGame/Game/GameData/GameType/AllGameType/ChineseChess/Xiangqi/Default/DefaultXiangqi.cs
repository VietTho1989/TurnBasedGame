using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Xiangqi
{
	public class DefaultXiangqi : DefaultGameType
	{

		#region Constructor

		public enum Property
		{

		}

		public DefaultXiangqi() : base()
		{

		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.Xiangqi;
		}

		public override GameType makeDefaultGameType ()
		{
			Xiangqi newXiangqi = Core.unityMakePositionByFen (Xiangqi.StartFen);
			return newXiangqi;
		}

	}
}
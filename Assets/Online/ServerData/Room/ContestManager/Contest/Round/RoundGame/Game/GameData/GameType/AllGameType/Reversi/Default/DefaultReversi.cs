using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Reversi
{
	public class DefaultReversi : DefaultGameType
	{

		#region Constructor

		public enum Property
		{

		}

		public DefaultReversi() : base()
		{

		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.Reversi;
		}

		public override GameType makeDefaultGameType ()
		{
			Reversi newReversi = Core.unityMakeDefaultPosition ();
			return newReversi;
		}

	}
}
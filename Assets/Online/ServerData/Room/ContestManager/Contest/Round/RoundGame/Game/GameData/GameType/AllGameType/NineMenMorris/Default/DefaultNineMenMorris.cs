using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris
{
	public class DefaultNineMenMorris : DefaultGameType
	{

		#region Constructor

		public enum Property
		{

		}

		public DefaultNineMenMorris() : base()
		{

		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.NineMenMorris;
		}

		public override GameType makeDefaultGameType ()
		{
			NineMenMorris newNineMenMorris = Core.unityMakeDefaultPosition ();
			return newNineMenMorris;
		}

	}
}
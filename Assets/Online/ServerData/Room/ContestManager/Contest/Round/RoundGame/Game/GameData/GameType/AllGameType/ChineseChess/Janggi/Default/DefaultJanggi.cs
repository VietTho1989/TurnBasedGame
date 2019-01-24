using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Janggi
{
	public class DefaultJanggi : DefaultGameType
	{

		#region Constructor

		public enum Property
		{

		}

		public DefaultJanggi() : base()
		{

		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.Janggi;
		}

		public override GameType makeDefaultGameType ()
		{
			Janggi newJanggi = Core.makeDefaultPosition ();
			return newJanggi;
		}

	}
}
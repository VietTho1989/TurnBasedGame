using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
	public class Start : State
	{

		#region Sub

		public abstract class Sub : Data
		{
			public enum Type
			{
				Normal,
				RockScissorPaper,
				Dice
			}

			public abstract Type getType ();

		}

		public VP<Sub> sub;

		#endregion

		#region Constructor

		public enum Property
		{
			sub
		}

		public Start() : base()
		{
			this.sub = new VP<Sub> (this, (byte)Property.sub, new StartNormal ());
		}

		#endregion

		public override Type getType ()
		{
			return Type.Start;
		}

	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UndoRedo
{
	public class Start : UndoRedoAction.State
	{

		#region Constructor

		public enum Property
		{

		}

		public Start() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Start;
		}

	}
}
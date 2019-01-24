using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UndoRedo
{
	public class Resolved : UndoRedoAction.State
	{

		#region Constructor

		public enum Property
		{

		}

		public Resolved() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Resolved;
		}

	}
}
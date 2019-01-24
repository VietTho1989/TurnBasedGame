using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UndoRedo
{
	public class Process : UndoRedoAction.State
	{

		public VP<int> index;

		#region Constructor

		public enum Property
		{
			index
		}

		public Process() : base()
		{
			this.index = new VP<int> (this, (byte)Property.index, -1);
		}

		#endregion

		public override Type getType ()
		{
			return Type.Process;
		}

	}
}
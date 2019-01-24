using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public class ActionEditStart : ActionEdit.State
	{

		#region Constructor

		public enum Property
		{

		}

		public ActionEditStart() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Start;
		}

	}
}
using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public class ActionNone : Action
	{

		#region State

		public enum State
		{
			None,
			Cut,
			Copy
		}

		public VP<State> state;

		#endregion

		public LP<FileSystemInfo> selectFiles;

		#region Constructor

		public enum Property
		{
			state,
			selectFiles
		}

		public ActionNone() : base()
		{
			this.state = new VP<State> (this, (byte)Property.state, State.None);
			this.selectFiles = new LP<FileSystemInfo> (this, (byte)Property.selectFiles);
		}

		#endregion

		public override Type getType ()
		{
			return Type.None;
		}

	}
}
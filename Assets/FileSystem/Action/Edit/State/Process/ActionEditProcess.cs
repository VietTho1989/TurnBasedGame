using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public class ActionEditProcess : ActionEdit.State
	{

		#region State

		public enum State
		{
			Process,
			Success,
			Fail
		}

		public VP<State> state;

		#endregion

		public LP<FileSystemInfo> files;

		public LP<FileSystemInfo> successFiles;

		#region Constructor

		public enum Property
		{
			state,
			files,
			successFiles
		}

		public ActionEditProcess() : base()
		{
			this.state = new VP<State> (this, (byte)Property.state, State.Process);
			this.files = new LP<FileSystemInfo> (this, (byte)Property.files);
			this.successFiles = new LP<FileSystemInfo> (this, (byte)Property.successFiles);
		}

		#endregion

		public override Type getType ()
		{
			return Type.Process;
		}

	}
}
using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public class ActionEditFail : ActionEdit.State
	{

		public VP<FileSystemInfo> failFile;

		public LP<FileSystemInfo> successFiles;

		public VP<float> time;

		public VP<float> duration;

		#region Constructor

		public enum Property
		{
			failFile,
			successFiles,
			time,
			duration
		}

		public ActionEditFail() : base()
		{
			this.failFile = new VP<FileSystemInfo> (this, (byte)Property.failFile, null);
			this.successFiles = new LP<FileSystemInfo> (this, (byte)Property.successFiles);
			this.time = new VP<float> (this, (byte)Property.time, 0);
			this.duration = new VP<float> (this, (byte)Property.duration, 3f);
		}

		#endregion

		public override Type getType ()
		{
			return Type.Fail;
		}

	}
}
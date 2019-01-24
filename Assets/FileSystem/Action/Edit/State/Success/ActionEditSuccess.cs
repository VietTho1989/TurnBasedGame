using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public class ActionEditSuccess : ActionEdit.State
	{

		public VP<float> time;

		public VP<float> duration;

		public LP<FileSystemInfo> successFiles;

		#region Constructor

		public enum Property
		{
			time,
			duration,
			successFiles
		}

		public ActionEditSuccess() : base()
		{
			this.time = new VP<float> (this, (byte)Property.time, 0);
			this.duration = new VP<float> (this, (byte)Property.duration, 3f);
			this.successFiles = new LP<FileSystemInfo> (this, (byte)Property.successFiles);
		}

		#endregion

		public override Type getType ()
		{
			return Type.Success;
		}

	}
}
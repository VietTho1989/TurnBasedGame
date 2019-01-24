using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public class ActionEdit : Action
	{

		#region type

		public enum Action
		{
			Copy,
			Cut,
			Delete
		}

		public VP<Action> action;

		#region State

		public abstract class State : Data
		{

			public enum Type
			{
				Start,
				Process,
				Success,
				Fail
			}

			public abstract Type getType ();

		}

		public VP<State> state;

		#endregion

		#endregion

		public LP<FileSystemInfo> files;

		public VP<DirectoryInfo> destDir;

		#region Constructor

		public enum Property
		{
			action,
			state,
			files,
			destDir
		}

		public ActionEdit() : base()
		{
			this.action = new VP<Action> (this, (byte)Property.action, Action.Copy);
			this.state = new VP<State> (this, (byte)Property.state, new ActionEditStart ());
			this.files = new LP<FileSystemInfo> (this, (byte)Property.files);
			this.destDir = new VP<DirectoryInfo> (this, (byte)Property.destDir, null);
		}

		#endregion

		public override Type getType ()
		{
			return Type.Edit;
		}

	}
}
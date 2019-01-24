using UnityEngine;
using System.Collections;

namespace FileSystem
{
	public class SingleShow : Show
	{

		public VP<ShowDirectory> showDirectory;

		#region Constructor

		public enum Property
		{
			showDirectory
		}

		public SingleShow() : base()
		{
			this.showDirectory = new VP<ShowDirectory>(this, (byte)Property.showDirectory, new ShowDirectory());
		}

		#endregion

		public override Type getType ()
		{
			return Type.Single;
		}

	}
}
using UnityEngine;
using System.IO;
using System.Collections;

public class DirectoryChange : Data
{
	public VP<DirectoryInfo> oldDir;
	public VP<DirectoryInfo> newDir;

	public VP<int> position;

	public VP<long> time;

	#region Constructor

	public enum Property
	{
		oldDir,
		newDir,
		position,
		time
	}

	public DirectoryChange() : base()
	{
		this.oldDir = new VP<DirectoryInfo> (this, (byte)Property.oldDir, null);
		this.newDir = new VP<DirectoryInfo> (this, (byte)Property.newDir, null);
		this.position = new VP<int> (this, (byte)Property.position, 0);
		this.time = new VP<long> (this, (byte)Property.time, Constants.UNKNOWN_TIME);
	}

	#endregion

}
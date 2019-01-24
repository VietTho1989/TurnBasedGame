using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using SQLite4Unity3d;

public class SqliteObject
{

	[PrimaryKey]
	public byte[] ids{ get; set; }

	public byte[] content{ get; set;}

	#region Constructor

	public SqliteObject()
	{

	}

	public SqliteObject(Data data)
	{
		this.updateIds (data);
		this.updateContent (data);
	}

	#endregion

	#region make data

	public void updateIds(Data data)
	{
		this.ids = GetIdsBytes (data);
	}

	public static byte[] GetIdsBytes(Data data)
	{
		if (data != null) {
			List<uint> searchInforms = data.makeUIntSearchInforms ();
			using (MemoryStream memStream = new MemoryStream ()) {
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					foreach (uint value in searchInforms) {
						writer.Write (value);
					}
					return memStream.ToArray ();
				}
			}
		} else {
			Debug.LogError ("data null");
		}
		return null;
	}

	public void updateContent(Data data)
	{
		if (data != null) {
			content = Data.MakeSqliteBinary (data);
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	#endregion

	public Data data = null;

}
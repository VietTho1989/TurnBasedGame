using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class SyncAdd<T> : Sync<T>
{

	public int index = 0;

	public List<T> values = new List<T>();

	public override Type getType ()
	{
		return Type.Add;
	}

	#region makeBinary

	public override void makeBinary (BinaryWriter writer)
	{
		writer.Write (index);
		// values
		{
			writer.Write (values.Count);
			foreach (T value in values) {
				DataUtils.writeBinary (writer, value);
			}
		}
	}

	public override void parse (BinaryReader reader)
	{
		this.index = reader.ReadInt32 ();
		{
			int count = reader.ReadInt32 ();
			for (int i = 0; i < count; i++) {
				this.values.Add (DataUtils.readBinary<T> (reader));
			}
		}
	}

	#endregion

}
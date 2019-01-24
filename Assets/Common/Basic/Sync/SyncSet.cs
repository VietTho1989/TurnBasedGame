using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class SyncSet<T> : Sync<T>
{

	public int index;
	
	public List<T> olds = new List<T> ();

	public List<T> news = new List<T> ();

	public override Type getType ()
	{
		return Type.Set;
	}

	#region makeBinary

	public override void makeBinary (BinaryWriter writer)
	{
		writer.Write (index);
		// olds
		{
			writer.Write (olds.Count);
			foreach (T old in olds) {
				DataUtils.writeBinary (writer, old);
			}
		}
		// news
		{
			writer.Write (news.Count);
			foreach (T newValue in news) {
				DataUtils.writeBinary (writer, newValue);
			}
		}
	}

	public override void parse (BinaryReader reader)
	{
		this.index = reader.ReadInt32();
		// olds
		{
			int count = reader.ReadInt32();
			for (int i = 0; i < count; i++) {
				this.olds.Add (DataUtils.readBinary<T> (reader));
			}
		}
		// news
		{
			int count = reader.ReadInt32();
			for (int i = 0; i < count; i++) {
				this.news.Add (DataUtils.readBinary<T> (reader));
			}
		}
	}

	#endregion

}
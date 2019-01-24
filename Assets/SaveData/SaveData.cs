using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class SaveData : Save.Content
{

	public Data data = null;

	public override Type getType ()
	{
		return Type.Data;
	}

	#region makeBinary

	public override void makeBinary (BinaryWriter writer)
	{
		if (data != null) {
			data.makeBinary (writer);
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	public override void parse (BinaryReader reader)
	{
		this.data = Data.parseBinary (reader);
	}

	#endregion

}
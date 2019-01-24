using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class Save
{

	public const string SaveExtension = ".sav";
	public const string FenExtension = ".fen";

	public int version = Global.VersionCode;

	#region Content

	public abstract class Content
	{

		public enum Type
		{
			Data,
			Fen
		}

		public abstract Type getType ();

		public abstract void makeBinary (BinaryWriter writer);

		public abstract void parse(BinaryReader reader);

	}

	public Content content = null;

	#endregion

	#region Constructor

	public Save() : base()
	{

	}

	#endregion

	#region makeBinary

	public void makeBinary(BinaryWriter writer)
	{
		writer.Write (this.version);
		if (this.content != null) {
			writer.Write ((int)this.content.getType ());
			this.content.makeBinary (writer);
		} else {
			Debug.LogError ("content null: " + this);
			writer.Write (int.MinValue);
		}
	}

	public static Save parse(BinaryReader reader)
	{
		Save save = new Save ();
		{
			save.version = reader.ReadInt32 ();
			// content
			{
				int contentType = reader.ReadInt32 ();
				switch (contentType) {
				case (int)Content.Type.Data:
					{
						SaveData saveData = new SaveData ();
						{
							saveData.parse (reader);
						}
						save.content = saveData;
					}
					break;
				case (int)Content.Type.Fen:
					{
						SaveFen saveFen = new SaveFen ();
						{
							saveFen.parse (reader);
						}
						save.content = saveFen;
					}
					break;
				default:
					Debug.LogError ("unknown contentType: " + contentType);
					break;
				}
			}
		}
		return save;
	}

	#endregion

}
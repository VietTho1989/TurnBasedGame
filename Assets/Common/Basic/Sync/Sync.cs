using UnityEngine;
using System.IO;
using System.Collections;

public abstract class Sync<T>
{
	public enum Type
	{
		Set,
		Add,
		Remove
	}

	public abstract Type getType();

	#region makeBinary

	public abstract void makeBinary(BinaryWriter writer);

	public abstract void parse (BinaryReader reader);

	#endregion

}
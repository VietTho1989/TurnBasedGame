using UnityEngine;
using System.Collections;

public abstract class Change<T>
{

	public enum Type
	{
		Set,
		Add,
		Remove
	}

	public abstract Type getType();

}


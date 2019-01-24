using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeSet<T> : Change<T>
{
	public int index;

	public List<T> values = new List<T>();

	public override Type getType ()
	{
		return Type.Set;
	}

}
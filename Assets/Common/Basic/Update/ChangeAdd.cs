using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeAdd<T> : Change<T>
{
	public int index = 0;

	public List<T> values = new List<T>();

	public override Type getType ()
	{
		return Type.Add;
	}
}
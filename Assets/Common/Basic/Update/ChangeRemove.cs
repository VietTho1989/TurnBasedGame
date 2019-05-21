using UnityEngine;
using System.Collections;

public class ChangeRemove<T> : Change<T>
{

	public int index = 0;
	public int number = 0;

	public override Type getType ()
	{
		return Type.Remove;
	}

}
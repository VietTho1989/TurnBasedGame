using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ListShow : Data
{

	public enum Type
	{
		All,
		Limit
	}

	public abstract Type getType ();

	public abstract List<T> getList<T> (List<T> list);

}
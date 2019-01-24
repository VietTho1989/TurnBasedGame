using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ListShowAll : ListShow
{

	public const uint MaxShowAll = 1000;

	#region Constructor

	public enum Property
	{

	}

	public ListShowAll() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.All;
	}

	public override List<T> getList<T> (List<T> list)
	{
		List<T> ret = new List<T> ();
		{
			ret.AddRange (list);
		}
		return ret;
	}

}
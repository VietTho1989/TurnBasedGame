using UnityEngine;
using System.Collections;

public class SortData : Data
{

	public VP<string> filter;

	#region SortType

	public enum SortType
	{
		None,
		Name,
		Kind,
		Date
	}

	public VP<SortType> sortType;

	#endregion

	#region Constructor

	public enum Property
	{
		filter,
		sortType
	}

	public SortData() : base()
	{
		this.filter = new VP<string> (this, (byte)Property.filter, "");
		this.sortType = new VP<SortType> (this, (byte)Property.sortType, SortType.None);
	}

	#endregion

	public void reset()
	{
		this.filter.v = "";
		this.sortType.v = SortType.None;
	}

}
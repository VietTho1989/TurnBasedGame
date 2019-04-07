using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    private static readonly TxtLanguage txtNone = new TxtLanguage("None");
    private static readonly TxtLanguage txtName = new TxtLanguage("Name");
    private static readonly TxtLanguage txtKind = new TxtLanguage("Kind");
    private static readonly TxtLanguage txtDate = new TxtLanguage("Time");

    static SortData()
    {
        txtNone.add(Language.Type.vi, "Không");
        txtName.add(Language.Type.vi, "Tên");
        txtKind.add(Language.Type.vi, "Loại");
        txtDate.add(Language.Type.vi, "Giờ");
    }

    public static List<string> getSortTypeList()
    {
        List<string> ret = new List<string>();
        {
            ret.Add(txtNone.get());
            ret.Add(txtName.get());
            ret.Add(txtKind.get());
            ret.Add(txtDate.get());
        }
        return ret;
    }

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
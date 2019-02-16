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

    private static readonly TxtLanguage txtNone = new TxtLanguage();
    private static readonly TxtLanguage txtName = new TxtLanguage();
    private static readonly TxtLanguage txtKind = new TxtLanguage();
    private static readonly TxtLanguage txtDate = new TxtLanguage();

    static SortData()
    {
        // none
        {
            txtNone.add(Language.Type.vi, "Không");
            txtNone.add(Language.Type.en, "None");
        }
        // name
        {
            txtName.add(Language.Type.vi, "Tên");
            txtName.add(Language.Type.en, "Name");
        }
        // kind
        {
            txtKind.add(Language.Type.vi, "Loại");
            txtKind.add(Language.Type.en, "Kind");
        }
        // date
        {
            txtDate.add(Language.Type.vi, "Giờ");
            txtDate.add(Language.Type.en, "Time");
        }
    }

    public static List<string> getSortTypeList()
    {
        List<string> ret = new List<string>();
        {
            ret.Add(txtNone.get("None"));
            ret.Add(txtName.get("Name"));
            ret.Add(txtKind.get("Kind"));
            ret.Add(txtDate.get("Time"));
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
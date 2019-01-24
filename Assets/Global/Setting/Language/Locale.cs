using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Locale : Data
{

	public VP<Language.Type> type;

	public VP<string> txt;

	#region Constructor

	public enum Property
	{
		type,
		txt
	}

	public Locale() : base()
	{
		this.type = new VP<Language.Type> (this, (byte)Property.type, Language.Type.en);
		this.txt = new VP<string> (this, (byte)Property.txt, "");
	}

	#endregion

}
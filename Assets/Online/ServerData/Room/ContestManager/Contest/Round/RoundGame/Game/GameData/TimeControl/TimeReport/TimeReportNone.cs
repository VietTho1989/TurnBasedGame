using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeReportNone : TimeReport
{

	#region Constructor

	public enum Property
	{

	}

	public TimeReportNone() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.None;
	}

}
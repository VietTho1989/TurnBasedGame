using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChatSubView : Data
{

	public VP<uint> min;

	public VP<uint> max;

	#region Constructor

	public enum Property
	{
		min,
		max
	}

	public ChatSubView() : base()
	{
		this.min = new VP<uint> (this, (byte)Property.min, 0);
		this.max = new VP<uint> (this, (byte)Property.max, 0);
	}

	#endregion

}
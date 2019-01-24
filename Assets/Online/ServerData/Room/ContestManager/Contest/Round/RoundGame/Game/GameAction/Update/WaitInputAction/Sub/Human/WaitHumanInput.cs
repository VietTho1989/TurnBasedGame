using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaitHumanInput : WaitInputAction.Sub
{

	public VP<uint> userId;

	#region Constructor

	public enum Property
	{
		userId
	}

	public WaitHumanInput() : base()
	{
		this.userId = new VP<uint> (this, (byte)Property.userId, 0);
	}

	#endregion

	public override Type getType ()
	{
		return Type.Human;
	}

}
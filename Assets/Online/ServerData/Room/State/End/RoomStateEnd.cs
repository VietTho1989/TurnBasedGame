using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomStateEnd : Room.State
{

	#region Constructor

	public enum Property
	{

	}

	public RoomStateEnd() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.End;
	}

}
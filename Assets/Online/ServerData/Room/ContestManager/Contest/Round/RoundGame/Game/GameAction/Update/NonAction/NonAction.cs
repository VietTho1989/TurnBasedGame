using UnityEngine;
using System.Collections;

public class NonAction : GameAction
{
	public enum Property
	{

	}

	public NonAction() : base()
	{

	}

	public override Type getType ()
	{
		return Type.Non;
	}
}


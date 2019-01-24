using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaitAIInputNone : WaitAIInput.Sub
{

	#region Constructor

	public enum Property
	{

	}

	public WaitAIInputNone() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.None;
	}

}
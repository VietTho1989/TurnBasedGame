using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PerspectiveAuto : Perspective.Sub
{

	#region Constructor

	public enum Property
	{

	}

	public PerspectiveAuto() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.Auto;
	}

}
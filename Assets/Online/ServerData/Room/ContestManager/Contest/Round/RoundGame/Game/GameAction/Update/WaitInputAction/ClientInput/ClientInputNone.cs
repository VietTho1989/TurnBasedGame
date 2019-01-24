using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientInputNone : ClientInput.Sub
{

	#region Constructor

	public enum Property
	{

	}

	public ClientInputNone() : base()
	{

	}

	#endregion

	public override Type getType()
	{
		return Type.None;
	}

}
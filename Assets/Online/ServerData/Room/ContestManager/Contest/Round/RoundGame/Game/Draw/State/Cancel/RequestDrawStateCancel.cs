using UnityEngine;
using System.Collections;

public class RequestDrawStateCancel : RequestDraw.State
{

	#region Constructor

	public enum Property
	{

	}

	public RequestDrawStateCancel() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.Cancel;
	}

}
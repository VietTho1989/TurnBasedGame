using UnityEngine;
using System.Collections;

public class EmptyInform : GamePlayer.Inform
{
	#region Constructor

	public enum Property
	{

	}

	public EmptyInform() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return GamePlayer.Inform.Type.None;
	}

}


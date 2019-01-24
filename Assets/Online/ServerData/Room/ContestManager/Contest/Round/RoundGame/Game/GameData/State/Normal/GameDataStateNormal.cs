using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameDataStateNormal : GameData.State
{

	#region Constructor

	public enum Property
	{

	}

	public GameDataStateNormal() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.Normal;
	}

}
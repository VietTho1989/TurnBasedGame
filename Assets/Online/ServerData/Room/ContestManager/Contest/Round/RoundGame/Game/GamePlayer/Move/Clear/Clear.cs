using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Clear : GameMove
{

	#region Constructor

	public enum Property
	{

	}

	public Clear() : base()
	{

	}

	#endregion

	public override Type getType()
	{
		return Type.Clear;
	}

	public override MoveAnimation makeAnimation (GameType gameType)
	{
		return null;
	}

	public override string print()
	{
		return "clear";
	}

	public override void getInforBeforeProcess (GameType gameType)
	{

	}

}
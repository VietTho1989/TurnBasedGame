using UnityEngine;
using System.Collections;

public class EndTurn : GameMove
{

	#region Constructor

	public enum Property
	{
		
	}

	public EndTurn() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.EndTurn;
	}

	public override string print ()
	{
		return "End Turn";
	}

	public override MoveAnimation makeAnimation (GameType gameType)
	{
		// TODO Can hoan thien
		return null;
	}

	public override void getInforBeforeProcess (GameType gameType)
	{
		
	}

}
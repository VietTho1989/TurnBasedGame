using UnityEngine;
using System.Collections;

public class NonMove : GameMove
{
	#region Constructor

	public enum Property
	{

	}

	public NonMove() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.None;
	}

	public override string print ()
	{
		return "None";
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
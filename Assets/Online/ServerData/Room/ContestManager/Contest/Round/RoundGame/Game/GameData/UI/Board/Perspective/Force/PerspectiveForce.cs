using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PerspectiveForce : Perspective.Sub
{

	public VP<int> playerIndex;

	#region Constructor

	public enum Property
	{
		playerIndex
	}

	public PerspectiveForce() : base()
	{
		this.playerIndex = new VP<int> (this, (byte)Property.playerIndex, 0);
	}

	#endregion

	public override Type getType ()
	{
		return Type.Force;
	}

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResult : Data
{

	public VP<int> playerIndex;

	public VP<float> score;

	#region Constructor

	public enum Property
	{
		playerIndex,
		score
	}

	public PlayerResult() : base()
	{
		this.playerIndex = new VP<int> (this, (byte)Property.playerIndex, -1);
		this.score = new VP<float> (this, (byte)Property.score, 0);
	}

	#endregion

}
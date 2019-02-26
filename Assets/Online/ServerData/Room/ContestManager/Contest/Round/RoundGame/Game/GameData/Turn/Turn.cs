using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : Data
{

	public VP<int> turn;

	public VP<int> playerIndex;

	public VP<int> gameTurn;

	#region Constructor

	public enum Property
	{
		turn,
		playerIndex,
		gameTurn
	}

	public Turn() : base()
	{
		this.turn = new VP<int> (this, (byte)Property.turn, -1);
		this.playerIndex = new VP<int> (this, (byte)Property.playerIndex, -1);
		this.gameTurn = new VP<int> (this, (byte)Property.gameTurn, -1);
	}

	#endregion

}
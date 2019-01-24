using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TurnChange : HistoryChange
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

	public TurnChange() : base()
	{
		this.turn = new VP<int> (this, (byte)Property.turn, 0);
		this.playerIndex = new VP<int> (this, (byte)Property.playerIndex, 0);
		this.gameTurn = new VP<int> (this, (byte)Property.gameTurn, 0);
	}

	#endregion

	public override Type getType ()
	{
		return Type.Turn;
	}

}
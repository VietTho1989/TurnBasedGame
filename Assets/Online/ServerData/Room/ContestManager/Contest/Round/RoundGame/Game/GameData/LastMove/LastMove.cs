using UnityEngine;
using System.Collections;

public class LastMove : Data
{
	#region Turn

	public VP<int> turn;

	#endregion

	public VP<GameMove> gameMove;

	#region Constructor

	public enum Property
	{
		turn,
		gameMove
	}

	public LastMove() : base()
	{
		this.turn = new VP<int> (this, (byte)Property.turn, -1);
		this.gameMove = new VP<GameMove>(this, (byte)Property.gameMove, new NonMove());
	}

	#endregion

}
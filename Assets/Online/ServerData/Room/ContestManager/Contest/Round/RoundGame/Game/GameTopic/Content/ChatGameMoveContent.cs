using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChatGameMoveContent : ChatMessage.Content
{

	public VP<Turn> turn;

	public VP<GameMove> gameMove;

	#region Constructor

	public enum Property
	{
		turn,
		gameMove
	}

	public ChatGameMoveContent() : base()
	{
		this.turn = new VP<Turn> (this, (byte)Property.turn, new Turn());
		this.gameMove = new VP<GameMove> (this, (byte)Property.gameMove, new NonMove ());
	}

	#endregion

	public override Type getType ()
	{
		return Type.GameMove;
	}

}
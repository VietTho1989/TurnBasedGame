using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputData : Data
{

	public VP<GameMove> gameMove;

	public VP<uint> userSend;

	public VP<float> serverTime;

	public VP<float> clientTime;

	#region Constructor

	public enum Property
	{
		gameMove,
		userSend,
		serverTime,
		clientTime
	}

	public InputData() : base()
	{
		this.gameMove = new VP<GameMove> (this, (byte)Property.gameMove, new NonMove ());
		this.userSend = new VP<uint> (this, (byte)Property.userSend, 0);
		this.serverTime = new VP<float> (this, (byte)Property.serverTime, 0);
		this.clientTime = new VP<float> (this, (byte)Property.clientTime, 0);
	}

	#endregion

}
using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class HumanConnection : Data
{

	public VP<uint> playerId;

	public VP<NetworkConnection> connection;

	#region Constructor

	public enum Property
	{
		playerId,
		connection
	}

	public HumanConnection() : base()
	{
		this.playerId = new VP<uint> (this, (byte)Property.playerId, 0);
		this.connection = new VP<NetworkConnection> (this, (byte)Property.connection, null);
	}

	#endregion

}
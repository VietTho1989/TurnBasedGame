using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KickRight : Data
{

	public VP<bool> canKick;

	public VP<bool> canKickPlayer;

	#region Constructor

	public enum Property
	{
		canKick,
		canKickPlayer
	}

	public KickRight() : base()
	{
		this.canKick = new VP<bool> (this, (byte)Property.canKick, true);
		this.canKickPlayer = new VP<bool> (this, (byte)Property.canKickPlayer, false);
	}

	#endregion

}
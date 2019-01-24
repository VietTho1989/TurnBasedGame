using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

public class RoomInform : Data
{

	public VP<Human> creator;

	public VP<uint> userCount;

	public VP<bool> isHavePassword;

	#region contestManager

	public VP<ContestManager.State.Type> contestStateType;

	public VP<GameType.Type> gameType;

	#endregion

	#region Constructor

	public enum Property
	{
		creator,
		userCount,
		isHavePassword,
		contestStateType,
		gameType
	}

	public RoomInform() : base()
	{
		this.creator = new VP<Human> (this, (byte)Property.creator, new Human ());
		this.userCount = new VP<uint> (this, (byte)Property.userCount, 0);
		this.isHavePassword = new VP<bool> (this, (byte)Property.isHavePassword, false);
		// contest
		{
			this.contestStateType = new VP<ContestManager.State.Type> (this, (byte)Property.contestStateType, ContestManager.State.Type.Lobby);
			this.gameType = new VP<GameType.Type> (this, (byte)Property.gameType, GameType.Type.CHESS);
		}
	}

	#endregion

}
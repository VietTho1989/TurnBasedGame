using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateRoom : Data
{

	public VP<GameType.Type> gameType;

	public VP<string> roomName;

	public VP<string> password;

	#region Constructor

	public enum Property
	{
		gameType,
		roomName,
		password
	}

	public CreateRoom() : base()
	{
		this.gameType = new VP<GameType.Type> (this, (byte)Property.gameType, GameType.Type.CHESS);
		this.roomName = new VP<string> (this, (byte)Property.roomName, "");
		this.password = new VP<string> (this, (byte)Property.password, "");
	}

	#endregion

	public CreateRoomMessage makeMessage()
	{
		CreateRoomMessage message = new CreateRoomMessage ();
		{
			message.gameType = this.gameType.v;
			message.roomName = this.roomName.v;
			message.password = this.password.v;
		}
		return message;
	}

}
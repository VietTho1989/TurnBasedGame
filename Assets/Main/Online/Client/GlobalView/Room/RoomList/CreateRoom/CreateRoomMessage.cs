using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CreateRoomMessage : MessageBase
{
	public GameType.Type gameType = GameType.Type.Xiangqi;
	public string roomName = "";
	public string password = "";

	// This method would be generated
	public override void Deserialize(NetworkReader reader)
	{
		gameType = (GameType.Type)reader.ReadInt32 ();
		roomName = reader.ReadString();
		password = reader.ReadString();
	}

	// This method would be generated
	public override void Serialize(NetworkWriter writer)
	{
		writer.Write ((int)gameType);
		writer.Write (roomName);
		writer.Write (password);
	}

	public override string ToString(){
		return "" + gameType + ", " + roomName + ", " + password;
	}

}


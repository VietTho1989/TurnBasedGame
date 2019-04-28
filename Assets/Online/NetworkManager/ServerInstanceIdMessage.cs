using UnityEngine.Networking;

public class ServerInstanceIdMessage : MessageBase
{

	public long instanceId = 0;

	public override void Deserialize(NetworkReader reader)
	{
		instanceId = reader.ReadInt64 ();
	}

	public override void Serialize(NetworkWriter writer)
	{
		writer.Write (instanceId);
	}

}
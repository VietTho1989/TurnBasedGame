using UnityEngine.Networking;

#pragma warning disable CS0618

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
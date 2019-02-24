using UnityEngine;
using System.Collections;

public class ServerConfig : Data
{

	public VP<string> address;

	public VP<int> port;

	#region Constructor

	public enum Property
	{
		address,
		port
	}

	public ServerConfig() : base()
	{
		this.address = new VP<string> (this, (byte)Property.address, Config.serverAddress);
		this.port = new VP<int> (this, (byte)Property.port, Config.serverPort);
	}

	#endregion

}
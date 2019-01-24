using UnityEngine;
using System.Collections;

public class RemoteConfig : Data
{

	public enum State
	{
		NotLoad,
		Load,
		Loading,
		Finish
	}
	public VP<State> state;
	public VP<long> time;

	public VP<string> serverAddress;// = "192.168.31.226";
	public VP<int> serverPort;// = 7777;

	#region Constructor

	private static RemoteConfig instance;

	static RemoteConfig()
	{
		instance = new RemoteConfig ();
	}

	public static RemoteConfig get()
	{
		return instance;
	}

	public enum Property
	{
		state,
		time,
		serverAddress,
		serverPort
	}

	public RemoteConfig() : base()
	{
		this.state = new VP<State> (this, (byte)Property.state, State.NotLoad);
		this.time = new VP<long> (this, (byte)Property.time, 0);
		this.serverAddress = new VP<string> (this, (byte)Property.serverAddress, "192.168.31.226");
		this.serverPort = new VP<int> (this, (byte)Property.serverPort, 7777);
	}

	#endregion

}
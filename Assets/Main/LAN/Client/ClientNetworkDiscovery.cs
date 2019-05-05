using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable CS0618

public class DiscoveredServer : Data
{

	public VP<string> ipAddress;
	public VP<int> port;
	public VP<float> timestamp;

	public VP<int> version;
	public VP<int> player;

	#region Constructor

	public enum Property
	{
		ipAddress,
		port,
		timestamp,
		version,
		player
	}

	public DiscoveredServer() : base()
	{
		this.ipAddress = new VP<string> (this, (byte)Property.ipAddress, "");
		this.port = new VP<int> (this, (byte)Property.port, 0);
		this.timestamp = new VP<float> (this, (byte)Property.timestamp, 0);

		this.version = new VP<int> (this, (byte)Property.version, 1);
		this.player = new VP<int> (this, (byte)Property.player, 1);
	}

	#endregion

    public bool processEvent(Event e)
    {
        bool isProcess = false;
        {
            // shortKey
            if (!isProcess)
            {
                if (Setting.get().useShortKey.v)
                {
                    DiscoveredServerUI discoveredServerUI = this.findCallBack<DiscoveredServerUI>();
                    if (discoveredServerUI != null)
                    {
                        isProcess = discoveredServerUI.useShortKey(e);
                    }
                    else
                    {
                        Debug.LogError("discoveredServerUI null: " + this);
                    }
                }
            }
        }
        return isProcess;
    }

}

public class DiscoveredServers : Data
{

	public LP<DiscoveredServer> servers;

	public DiscoveredServer findByIp(string ipAddress){
		return this.servers.vs.Find (server => server.ipAddress.v == ipAddress);
	}

	#region Constructor

	public enum Property
	{
		servers
	}

	public DiscoveredServers() : base()
	{
		this.servers = new LP<DiscoveredServer> (this, (byte)Property.servers);
	}

	#endregion

}

public class ClientNetworkDiscovery : NetworkDiscovery
{

    public DiscoveredServers discoveredServers = new DiscoveredServers();
    public const float ServerKeepAliveTime = 5.0f;

    void Start()
    {
        // TODO Them vao de khong bi remove
        CleanServerList();

        showGUI = false;
        InvokeRepeating("CleanServerList", 3, 1);
        if (!Initialize())
        {
            Debug.LogError("#CaptainsMess# Network port is unavailable!");
        }
        else
        {
            Debug.LogError("intialize success");
        }

    }

    /*#region Start

	private float time = 0;
	private bool alreadyInit = false;

	void Update()
	{
		if (!alreadyInit) {
			if (time <= 5f) {
				time += Time.deltaTime;
			} else {
				alreadyInit = true;
				Debug.LogError ("startJoining: " + this);
				this.StartJoining ();
			}
		}
	}

	#endregion*/

    public void Reset()
    {
        discoveredServers.servers.clear();
    }

    public void StartJoining()
    {
        // Debug.LogError ("startJoining");
        Reset();
        if (!Initialize())
        {
            Debug.LogError("#CaptainsMess# Network port is unavailable!");
        }
        else
        {
            Debug.LogError("intialize success");
        }
        if (!StartAsClient())
        {
            Debug.LogError("#CaptainsMess# Unable to listen!");
            // Clean up some data that Unity seems not to
            if (hostId != -1)
            {
                NetworkTransport.RemoveHost(hostId);
                hostId = -1;
            }
        }
        else
        {
            Debug.LogError("startClient success");
        }
    }

    [UnityEngine.Scripting.Preserve]
    public void CleanServerList()
    {
        for (int i = discoveredServers.servers.vs.Count - 1; i >= 0; i--)
        {
            DiscoveredServer kvp = discoveredServers.servers.vs[i];
            float timeSinceLastBroadcast = Time.time - kvp.timestamp.v;
            if (timeSinceLastBroadcast > ServerKeepAliveTime)
            {
                discoveredServers.servers.remove(kvp);
            }
        }
    }

    public override void OnReceivedBroadcast(string aFromAddress, string aRawData)
    {
        // Debug.LogError ("onReceivedBroadcast: " + aFromAddress + ", " + aRawData);
        BroadcastData data = new BroadcastData();
        data.FromString(aRawData);

        DiscoveredServer server = discoveredServers.findByIp(aFromAddress);
        // Add
        {
            if (server == null)
            {
                // Debug.LogError ("make new server");
                server = new DiscoveredServer();
                {
                    server.uid = discoveredServers.servers.makeId();
                    server.ipAddress.v = aFromAddress;
                }
                discoveredServers.servers.add(server);
            }
        }
        // Set value
        {
            server.port.v = data.port;
            server.timestamp.v = Time.time;
            server.version.v = data.version;
            server.player.v = data.player;
        }
    }

}
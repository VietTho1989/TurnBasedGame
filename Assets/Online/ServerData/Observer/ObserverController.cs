using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class ObserverController
{
	private const int MAX_CHECK_PER_UPDATE = 400;

	#region Dictionary

	private const int MAX_DATA_SIZE = 10000;

	private const int TIME_WAIT_TO_REMOVE = 5;

	public class ConnectionInfo
	{
		public int dataSize;
		public bool allow;
		public float time;
		public int outPacket;
	}

	public class ConnectionDict
	{
		public Dictionary<NetworkConnection, ConnectionInfo> dict = new Dictionary<NetworkConnection, ConnectionInfo>();

		public int checkPerUpdate = 0;

		public bool allow = true;
	}

	public Dictionary<int, ConnectionDict> dictChannels = new Dictionary<int, ConnectionDict>();

	#endregion

	public bool checkAllow(int networkChannel)
	{
		ConnectionDict connectionDict = null;
		{
			if (dictChannels.TryGetValue (networkChannel, out connectionDict)) {
				// add check count
				if (connectionDict.allow) {
					connectionDict.checkPerUpdate++;
					if (connectionDict.checkPerUpdate >= MAX_CHECK_PER_UPDATE) {
						Debug.LogError ("checkAllow: check too much: " + networkChannel);
						connectionDict.allow = false;
					}
				}
				return connectionDict.allow;
			}
		}
		return true;
	}

	public bool checkAllowAdd(DataIdentity dataIdentity, NetworkConnection connection)
	{
		// Find dictConnections
		ConnectionDict connectionDict = null;
		{
			int networkChannel = dataIdentity.GetNetworkChannel ();
			if (!dictChannels.TryGetValue (networkChannel, out connectionDict)) {
				Debug.LogError ("Don't have channels: " + networkChannel);
				connectionDict = new ConnectionDict();
				dictChannels [networkChannel] = connectionDict;
			}
		}
		// Check
		{
			// Find connectionInfo
			ConnectionInfo connectionInfo = null;
			{
				if (!connectionDict.dict.TryGetValue (connection, out connectionInfo)) {
					// Debug.LogError ("Don't have connection");
					connectionInfo = new ConnectionInfo ();
					{
						connectionInfo.dataSize = 0;
						connectionInfo.allow = true;;
						connectionInfo.time = Time.time;
						{
							byte byteError = 0;
							connectionInfo.outPacket = UnityEngine.Networking.NetworkTransport.GetIncomingPacketCount (connection.hostId, connection.connectionId, out byteError);
						}
					}
					connectionDict.dict [connection] = connectionInfo;
				}
			}
			// Add size
			if (connectionInfo.allow) {
				bool alwaysCanAdd = (connectionInfo.dataSize <= 0);
				// Update data size
				connectionInfo.dataSize += dataIdentity.getDataSize ();
				// Debug.Log ("connectionInfo: dataSize: " + connectionInfo.dataSize + "; " + dataIdentity + "; " + dataIdentity.getDataSize ());
				// Check >=Max_Data_Size
				if (alwaysCanAdd || connectionInfo.dataSize <= MAX_DATA_SIZE) {
					return true;
				} else {
					// Debug.LogError ("MAX_DATA_SIZE: " + connectionInfo.dataSize + dataIdentity + "; " + connection);
					connectionInfo.allow = false;
					return false;
				}
			} else {
				// Debug.LogError ("not allow: " + dataIdentity + "; " + connection);
				return false;
			}
		}
	}

	public void resetPerFrame()
	{
		float currentTime = Time.time;
		// check each channel
		foreach (int channel in dictChannels.Keys) {
			ConnectionDict dictConnections = dictChannels [channel];
			// reset allow
			{
				dictConnections.checkPerUpdate = 0;
				dictConnections.allow = true;
			}
			// check in connectionInfo
			{
				List<NetworkConnection> needRemoves = new List<NetworkConnection> ();
				foreach (NetworkConnection connection in dictConnections.dict.Keys) {
					// reset connectioInfo
					ConnectionInfo connectionInfo = dictConnections.dict [connection];
					{
						if (currentTime - connectionInfo.time >= TIME_WAIT_TO_REMOVE) {
							// Debug.LogError ("need remove connectionInfo because of time: " + connection);
							needRemoves.Add (connection);
						} else {
							// get newOutPacket
							byte byteError = 0;
							if (connection.hostId >= 0 && connection.hostId < 2) {
								int newOutPacket = UnityEngine.Networking.NetworkTransport.GetIncomingPacketCount (connection.hostId, connection.connectionId, out byteError);
								// check already send, if: reset
								if (connectionInfo.dataSize != 0) {
									if (newOutPacket != connectionInfo.outPacket) {
										connectionInfo.dataSize = 0;
										connectionInfo.allow = true;
										connectionInfo.time = currentTime;
										connectionInfo.outPacket = newOutPacket;
									} else {
										Debug.LogError ("haven't send: " + newOutPacket + "; " + connection + "; " + connectionInfo);
									}
								}
							} else {
								Debug.LogError ("hostId error: " + connection.hostId);
							}
						}
					}
				}
				// remove
				foreach (NetworkConnection needRemove in needRemoves) {
					dictConnections.dict.Remove (needRemove);
				}
			}
		}
	}
}


using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.Net;

public class Config 
{

	public const string serverAddress = "192.168.31.226";
    public const int serverPort = 7777;

    /*public static int FreeTcpPort()
    {
        TcpListener l = new TcpListener(IPAddress.Loopback, 0);
        l.Start();
        int port = ((IPEndPoint)l.LocalEndpoint).Port;
        l.Stop();
        return port;
    }*/

}
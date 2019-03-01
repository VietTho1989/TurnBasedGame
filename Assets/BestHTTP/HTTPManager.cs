﻿using System;
using System.Collections.Generic;

using UnityEngine;

#if !BESTHTTP_DISABLE_CACHING && (!UNITY_WEBGL || UNITY_EDITOR)
    using BestHTTP.Caching;
#endif

using BestHTTP.Extensions;
using BestHTTP.Logger;
using BestHTTP.Statistics;

namespace BestHTTP
{
    /// <summary>
    ///
    /// </summary>
    public static class HTTPManager
    {
        // Static constructor. Setup default values
        static HTTPManager()
        {
            MaxConnectionPerServer = 4;
            KeepAliveDefaultValue = true;
            MaxPathLength = 255;
            MaxConnectionIdleTime = TimeSpan.FromSeconds(30);

#if !BESTHTTP_DISABLE_COOKIES && (!UNITY_WEBGL || UNITY_EDITOR)
            IsCookiesEnabled = true;
#endif

            CookieJarSize = 10 * 1024 * 1024;
            EnablePrivateBrowsing = false;
            ConnectTimeout = TimeSpan.FromSeconds(20);
            RequestTimeout = TimeSpan.FromSeconds(60);

            // Set the default logger mechanism
            logger = new BestHTTP.Logger.DefaultLogger();

#if !BESTHTTP_DISABLE_ALTERNATE_SSL && (!UNITY_WEBGL || UNITY_EDITOR)
            DefaultCertificateVerifyer = null;
            UseAlternateSSLDefaultValue = false;
#endif
        }

        #region Global Options

        /// <summary>
        /// The maximum active tcp connections that the client will maintain to a server. Default value is 4. Minimum value is 1.
        /// </summary>
        public static byte MaxConnectionPerServer
        {
            get{ return maxConnectionPerServer; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("MaxConnectionPerServer must be greater than 0!");
                maxConnectionPerServer = value;
            }
        }
        private static byte maxConnectionPerServer;

        /// <summary>
        /// Default value of a http request's IsKeepAlive value. Default value is true. If you make rare request to the server it's should be changed to false.
        /// </summary>
        public static bool KeepAliveDefaultValue { get; set; }

#if !BESTHTTP_DISABLE_CACHING && (!UNITY_WEBGL || UNITY_EDITOR)
        /// <summary>
        /// Set to true, if caching is prohibited.
        /// </summary>
        public static bool IsCachingDisabled { get; set; }
#endif

        /// <summary>
        /// How many time must be passed to destroy that connection after a connection finished it's last request. It's default value is 30 seconds.
        /// </summary>
        public static TimeSpan MaxConnectionIdleTime { get; set; }

#if !BESTHTTP_DISABLE_COOKIES && (!UNITY_WEBGL || UNITY_EDITOR)
        /// <summary>
        /// Set to false to disable all Cookie. It's default value is true.
        /// </summary>
        public static bool IsCookiesEnabled { get; set; }
#endif

        /// <summary>
        /// Size of the Cookie Jar in bytes. It's default value is 10485760 (10 MB).
        /// </summary>
        public static uint CookieJarSize { get; set; }

        /// <summary>
        /// If this property is set to true, then new cookies treated as session cookies and these cookies are not saved to disk. It's default value is false;
        /// </summary>
        public static bool EnablePrivateBrowsing { get; set; }

        /// <summary>
        /// Global, default value of the HTTPRequest's ConnectTimeout property. Default value is 20 seconds.
        /// </summary>
        public static TimeSpan ConnectTimeout { get; set; }

        /// <summary>
        /// Global, default value of the HTTPRequest's Timeout property. Default value is 60 seconds.
        /// </summary>
        public static TimeSpan RequestTimeout { get; set; }

#if !((BESTHTTP_DISABLE_CACHING && BESTHTTP_DISABLE_COOKIES) || (UNITY_WEBGL && !UNITY_EDITOR))
        /// <summary>
        /// By default the plugin will save all cache and cookie data under the path returned by Application.persistentDataPath.
        /// You can assign a function to this delegate to return a custom root path to define a new path.
        /// <remarks>This delegate will be called on a non Unity thread!</remarks>
        /// </summary>
        public static System.Func<string> RootCacheFolderProvider { get; set; }
#endif

#if !BESTHTTP_DISABLE_PROXY
        /// <summary>
        /// The global, default proxy for all HTTPRequests. The HTTPRequest's Proxy still can be changed per-request. Default value is null.
        /// </summary>
        public static HTTPProxy Proxy { get; set; }
#endif

        /// <summary>
        /// Heartbeat manager to use less threads in the plugin. The heartbeat updates are called from the OnUpdate function.
        /// </summary>
        public static HeartbeatManager Heartbeats
        {
            get
            {
                if (heartbeats == null)
                    heartbeats = new HeartbeatManager();
                return heartbeats;
            }
        }
        private static HeartbeatManager heartbeats;

        /// <summary>
        /// A basic BestHTTP.Logger.ILogger implementation to be able to log intelligently additional informations about the plugin's internal mechanism.
        /// </summary>
        public static BestHTTP.Logger.ILogger Logger
        {
            get
            {
                // Make sure that it has a valid logger instance.
                if (logger == null)
                {
                    logger = new DefaultLogger();
                    logger.Level = Loglevels.None;
                }

                return logger;
            }

            set { logger = value; }
        }
        private static BestHTTP.Logger.ILogger logger;

#if !BESTHTTP_DISABLE_ALTERNATE_SSL && (!UNITY_WEBGL || UNITY_EDITOR)
        /// <summary>
        /// The default ICertificateVerifyer implementation that the plugin will use when the request's UseAlternateSSL property is set to true.
        /// </summary>
        public static Org.BouncyCastle.Crypto.Tls.ICertificateVerifyer DefaultCertificateVerifyer { get; set; }

        /// <summary>
        /// The default IClientCredentialsProvider implementation that the plugin will use when the request's UseAlternateSSL property is set to true.
        /// </summary>
        public static Org.BouncyCastle.Crypto.Tls.IClientCredentialsProvider DefaultClientCredentialsProvider { get; set; }

        /// <summary>
        /// The default value for the HTTPRequest's UseAlternateSSL property.
        /// </summary>
        public static bool UseAlternateSSLDefaultValue { get; set; }
#endif

        /// <summary>
        /// On most systems the maximum length of a path is around 255 character. If a cache entity's path is longer than this value it doesn't get cached. There no patform independent API to query the exact value on the current system, but it's
        /// exposed here and can be overridden. It's default value is 255.
        /// </summary>
        internal static int MaxPathLength { get; set; }

        #endregion

        #region Manager variables

        /// <summary>
        /// All connection has a reference in this Dictionary untill it's removed completly.
        /// </summary>
        private static Dictionary<string, List<ConnectionBase>> Connections = new Dictionary<string, List<ConnectionBase>>();

        /// <summary>
        /// Active connections. These connections all has a request to process.
        /// </summary>
        private static List<ConnectionBase> ActiveConnections = new List<ConnectionBase>();

        /// <summary>
        /// Free connections. They can be removed completly after a specified time.
        /// </summary>
        private static List<ConnectionBase> FreeConnections = new List<ConnectionBase>();

        /// <summary>
        /// Connections that recycled in the Update loop. If they are not used in the same loop to process a request, they will be transferred to the FreeConnections list.
        /// </summary>
        private static List<ConnectionBase> RecycledConnections = new List<ConnectionBase>();

        /// <summary>
        /// List of request that have to wait until there is a free connection to the server.
        /// </summary>
        private static List<HTTPRequest> RequestQueue = new List<HTTPRequest>();
        private static bool IsCallingCallbacks;

        internal static System.Object Locker = new System.Object();

        #endregion

        #region Public Interface

        public static void Setup()
        {
            HTTPUpdateDelegator.CheckInstance();

#if !BESTHTTP_DISABLE_CACHING && (!UNITY_WEBGL || UNITY_EDITOR)
            HTTPCacheService.CheckSetup();
#endif

#if !BESTHTTP_DISABLE_COOKIES && (!UNITY_WEBGL || UNITY_EDITOR)
            Cookies.CookieJar.SetupFolder();
#endif
        }

        public static HTTPRequest SendRequest(string url, OnRequestFinishedDelegate callback)
        {
            return SendRequest(new HTTPRequest(new Uri(url), HTTPMethods.Get, callback));
        }

        public static HTTPRequest SendRequest(string url, HTTPMethods methodType, OnRequestFinishedDelegate callback)
        {
            return SendRequest(new HTTPRequest(new Uri(url), methodType, callback));
        }

        public static HTTPRequest SendRequest(string url, HTTPMethods methodType, bool isKeepAlive, OnRequestFinishedDelegate callback)
        {
            return SendRequest(new HTTPRequest(new Uri(url), methodType, isKeepAlive, callback));
        }

        public static HTTPRequest SendRequest(string url, HTTPMethods methodType, bool isKeepAlive, bool disableCache, OnRequestFinishedDelegate callback)
        {
            return SendRequest(new HTTPRequest(new Uri(url), methodType, isKeepAlive, disableCache, callback));
        }

        public static HTTPRequest SendRequest(HTTPRequest request)
        {
            lock (Locker)
            {
                Setup();

                // TODO: itt meg csak adja hozza egy sorhoz, es majd a LateUpdate-ben hivodjon a SendRequestImpl.
                //  Igy ha egy callback-ben kuldenenk ugyanarra a szerverre request-et, akkor feltudjuk hasznalni az elozo connection-t.
                if (IsCallingCallbacks)
                {
                    request.State = HTTPRequestStates.Queued;
                    RequestQueue.Add(request);
                }
                else
                    SendRequestImpl(request);

                return request;
            }
        }

        public static GeneralStatistics GetGeneralStatistics(StatisticsQueryFlags queryFlags)
        {
            GeneralStatistics stat = new GeneralStatistics();

            stat.QueryFlags = queryFlags;

            if ((queryFlags & StatisticsQueryFlags.Connections) != 0)
            {
                int connections = 0;
                foreach(var conn in HTTPManager.Connections)
                {
                    if (conn.Value != null)
                        connections += conn.Value.Count;
                }

#if !BESTHTTP_DISABLE_WEBSOCKET && UNITY_WEBGL && !UNITY_EDITOR
                connections += WebSocket.WebSocket.WebSockets.Count;
#endif

                stat.Connections = connections;
                stat.ActiveConnections = ActiveConnections.Count
#if !BESTHTTP_DISABLE_WEBSOCKET && UNITY_WEBGL && !UNITY_EDITOR
                                         + WebSocket.WebSocket.WebSockets.Count
#endif
                ;
                stat.FreeConnections = FreeConnections.Count;
                stat.RecycledConnections = RecycledConnections.Count;
                stat.RequestsInQueue = RequestQueue.Count;
            }

#if !BESTHTTP_DISABLE_CACHING && (!UNITY_WEBGL || UNITY_EDITOR)
            if ((queryFlags & StatisticsQueryFlags.Cache) != 0)
            {
                stat.CacheEntityCount = HTTPCacheService.GetCacheEntityCount();
                stat.CacheSize = HTTPCacheService.GetCacheSize();
            }
#endif

#if !BESTHTTP_DISABLE_COOKIES && (!UNITY_WEBGL || UNITY_EDITOR)
            if ((queryFlags & StatisticsQueryFlags.Cookies) != 0)
            {
                List<Cookies.Cookie> cookies = Cookies.CookieJar.GetAll();
                stat.CookieCount = cookies.Count;
                uint cookiesSize = 0;
                for (int i = 0; i < cookies.Count; ++i)
                    cookiesSize += cookies[i].GuessSize();
                stat.CookieJarSize = cookiesSize;
            }
#endif

            return stat;
        }

        #endregion

        #region Private Functions

        private static void SendRequestImpl(HTTPRequest request)
        {
            ConnectionBase conn = FindOrCreateFreeConnection(request);

            if (conn != null)
            {
                // found a free connection: put it in the ActiveConnection list(they will be checked periodically in the OnUpdate call)
                if (ActiveConnections.Find((c) => c == conn) == null)
                    ActiveConnections.Add(conn);

                FreeConnections.Remove(conn);

                request.State = HTTPRequestStates.Processing;

                request.Prepare();

                // then start process the request
                conn.Process(request);
            }
            else
            {
                // If no free connection found and creation prohibited, we will put back to the queue
                request.State = HTTPRequestStates.Queued;
                RequestQueue.Add(request);
            }
        }

        private static string GetKeyForRequest(HTTPRequest request)
        {
            if (request.CurrentUri.IsFile)
                return request.CurrentUri.ToString();

            // proxyUri + requestUri
            // HTTP and HTTPS needs different connections.
            return
#if !BESTHTTP_DISABLE_PROXY
                (request.Proxy != null ? new UriBuilder(request.Proxy.Address.Scheme, request.Proxy.Address.Host, request.Proxy.Address.Port).Uri.ToString() : string.Empty) +
#endif
                                            new UriBuilder(request.CurrentUri.Scheme, request.CurrentUri.Host, request.CurrentUri.Port).Uri.ToString();
        }

        /// <summary>
        /// Factory method to create a concrete connection object.
        /// </summary>
        private static ConnectionBase CreateConnection(HTTPRequest request, string serverUrl)
        {
            if (request.CurrentUri.IsFile)
                return new FileConnection(serverUrl);

#if UNITY_WEBGL && !UNITY_EDITOR
            return new WebGLConnection(serverUrl);
#else
            return new HTTPConnection(serverUrl);
#endif
        }

        private static ConnectionBase FindOrCreateFreeConnection(HTTPRequest request)
        {
            ConnectionBase conn = null;
            List<ConnectionBase> connections;

            string serverUrl = GetKeyForRequest(request);

            if (Connections.TryGetValue(serverUrl, out connections))
            {
                // count active connections

                int activeConnections = 0;
                for (int i = 0; i < connections.Count; ++i)
                    if (connections[i].IsActive)
                        activeConnections++;

                if (activeConnections <= MaxConnectionPerServer)
                    // search for a Free connection
                    for (int i = 0; i < connections.Count && conn == null; ++i)
                    {
                        var tmpConn = connections[i];

                        if (tmpConn != null &&
                            tmpConn.IsFree &&
                            (
#if !BESTHTTP_DISABLE_PROXY
                            !tmpConn.HasProxy ||
#endif
                             tmpConn.LastProcessedUri == null ||
                             tmpConn.LastProcessedUri.Host.Equals(request.CurrentUri.Host, StringComparison.OrdinalIgnoreCase)))
                            conn = tmpConn;
                    }
            }
            else
                Connections.Add(serverUrl, connections = new List<ConnectionBase>(MaxConnectionPerServer));

            // No free connection found?
            if (conn == null)
            {
                // Max connection reached?
                if (connections.Count >= MaxConnectionPerServer)
                    return null;

                // if no, create a new one
                connections.Add(conn = CreateConnection(request, serverUrl));
            }

            return conn;
        }

        /// <summary>
        /// Will return with true when there at least one request that can be processed from the RequestQueue.
        /// </summary>
        private  static bool CanProcessFromQueue()
        {
            for (int i = 0; i < RequestQueue.Count; ++i)
                if (FindOrCreateFreeConnection(RequestQueue[i]) != null)
                    return true;

            return false;
        }

        private static void RecycleConnection(ConnectionBase conn)
        {
            conn.Recycle(OnConnectionRecylced);
        }

        private static void OnConnectionRecylced(ConnectionBase conn)
        {
            lock (RecycledConnections)
            {
                RecycledConnections.Add(conn);
            }
        }

        #endregion

        #region Internal Helper Functions

        /// <summary>
        /// Will return the ConnectionBase object that processing the given request.
        /// </summary>
        internal static ConnectionBase GetConnectionWith(HTTPRequest request)
        {
            lock (Locker)
            {
                for (int i = 0; i < ActiveConnections.Count; ++i)
                {
                    var connection = ActiveConnections[i];
                    if (connection.CurrentRequest == request)
                        return connection;
                }

                return null;
            }
        }

        internal static bool RemoveFromQueue(HTTPRequest request)
        {
            return RequestQueue.Remove(request);
        }

#if !((BESTHTTP_DISABLE_CACHING && BESTHTTP_DISABLE_COOKIES) || (UNITY_WEBGL && !UNITY_EDITOR))
        /// <summary>
        /// Will return where the various caches should be saved.
        /// </summary>
        internal static string GetRootCacheFolder()
        {
            try
            {
                if (RootCacheFolderProvider != null)
                    return RootCacheFolderProvider();
            }
            catch(Exception ex)
            {
                HTTPManager.Logger.Exception("HTTPManager", "GetRootCacheFolder", ex);
            }

#if NETFX_CORE
            return Windows.Storage.ApplicationData.Current.LocalFolder.Path;
#else
            return Application.persistentDataPath;
#endif
        }
#endif

        #endregion

        #region MonoBehaviour Events (Called from HTTPUpdateDelegator)

        /// <summary>
        /// Update function that should be called regularly from a Unity event(Update, LateUpdate). Callbacks are dispatched from this function.
        /// </summary>
        public static void OnUpdate()
        {
            lock (Locker)
            {
                IsCallingCallbacks = true;
                try
                {
                    for (int i = 0; i < ActiveConnections.Count; ++i)
                    {
                        ConnectionBase conn = ActiveConnections[i];

                        switch (conn.State)
                        {
                            case HTTPConnectionStates.Processing:
                                conn.HandleProgressCallback();

                                if (conn.CurrentRequest.UseStreaming && conn.CurrentRequest.Response != null && conn.CurrentRequest.Response.HasStreamedFragments())
                                    conn.HandleCallback();

                                if (((!conn.CurrentRequest.UseStreaming && conn.CurrentRequest.UploadStream == null) || conn.CurrentRequest.EnableTimoutForStreaming) &&
                                    DateTime.UtcNow - conn.StartTime > conn.CurrentRequest.Timeout)
                                    conn.Abort(HTTPConnectionStates.TimedOut);

                                break;

                            case HTTPConnectionStates.TimedOut:
                                // The connection is still in TimedOut state, and if we waited enough time, we will dispatch the
                                //  callback and recycle the connection
                                if (DateTime.UtcNow - conn.TimedOutStart > TimeSpan.FromMilliseconds(500))
                                {
                                    HTTPManager.Logger.Information("HTTPManager", "Hard aborting connection becouse of a long waiting TimedOut state");

                                    conn.CurrentRequest.Response = null;
                                    conn.CurrentRequest.State = HTTPRequestStates.TimedOut;
                                    conn.HandleCallback();

                                    // this will set the connection's CurrentRequest to null
                                    RecycleConnection(conn);
                                }
                                break;

                            case HTTPConnectionStates.Redirected:
                                // If the server redirected us, we need to find or create a connection to the new server and send out the request again.
                                SendRequest(conn.CurrentRequest);

                                RecycleConnection(conn);
                                break;

                            case HTTPConnectionStates.WaitForRecycle:
                                // If it's a streamed request, it's finished now
                                conn.CurrentRequest.FinishStreaming();

                                // Call the callback
                                conn.HandleCallback();

                                // Then recycle the connection
                                RecycleConnection(conn);
                                break;

                            case HTTPConnectionStates.Upgraded:
                                // The connection upgraded to an other protocol
                                conn.HandleCallback();
                                break;

                            case HTTPConnectionStates.WaitForProtocolShutdown:
                                var ws = conn.CurrentRequest.Response as IProtocol;
                                if (ws != null)
                                    ws.HandleEvents();

                                if (ws == null || ws.IsClosed)
                                {
                                    conn.HandleCallback();

                                    // After both sending and receiving a Close message, an endpoint considers the WebSocket connection closed and MUST close the underlying TCP connection.
                                    conn.Dispose();
                                    RecycleConnection(conn);
                                }
                                break;

                            case HTTPConnectionStates.AbortRequested:
                                // Corner case: we aborted a WebSocket connection
                                {
                                    ws = conn.CurrentRequest.Response as IProtocol;
                                    if (ws != null)
                                    {
                                        ws.HandleEvents();

                                        if (ws.IsClosed)
                                        {
                                            conn.HandleCallback();
                                            conn.Dispose();

                                            RecycleConnection(conn);
                                        }
                                    }
                                }
                                break;

                            case HTTPConnectionStates.Closed:
                                // If it's a streamed request, it's finished now
                                conn.CurrentRequest.FinishStreaming();

                                // Call the callback
                                conn.HandleCallback();

                                // It will remove from the ActiveConnections
                                RecycleConnection(conn);
                                break;

                            case HTTPConnectionStates.Free:
                                RecycleConnection(conn);
                                break;
                        }
                    }
                }
                finally
                {
                    IsCallingCallbacks = false;
                }

                lock (RecycledConnections)
                {
                    if (RecycledConnections.Count > 0)
                    {
                        for (int i = 0; i < RecycledConnections.Count; ++i)
                        {
                            var connection = RecycledConnections[i];
                            // If in a callback made a request that aquired this connection, then we will not remove it from the
                            //  active connections.
                            if (connection.IsFree)
                            {
                                ActiveConnections.Remove(connection);
                                FreeConnections.Add(connection);
                            }
                        }
                        RecycledConnections.Clear();
                    }
                }

                if (FreeConnections.Count > 0)
                    for (int i = 0; i < FreeConnections.Count; i++)
                    {
                        var connection = FreeConnections[i];

                        if (connection.IsRemovable)
                        {
                            // Remove the connection from the connection reference table
                            List<ConnectionBase> connections = null;
                            if (Connections.TryGetValue(connection.ServerAddress, out connections))
                                connections.Remove(connection);

                            // Dispose the connection
                            connection.Dispose();

                            FreeConnections.RemoveAt(i);
                            i--;
                        }
                    }


                if (CanProcessFromQueue())
                {
                    // Sort the queue by priority, only if we have to
                    if (RequestQueue.Find((req) => req.Priority != 0) != null)
                        RequestQueue.Sort((req1, req2) => req1.Priority - req2.Priority);

                    // Create an array from the queue and clear it. When we call the SendRequest while still no room for new connections, the same queue will be rebuilt.

                    var queue = RequestQueue.ToArray();
                    RequestQueue.Clear();

                    for (int i = 0; i < queue.Length; ++i)
                        SendRequest(queue[i]);
                }
            } // lock(Locker)

            if (heartbeats != null)
                heartbeats.Update();
        }

        public static void OnQuit()
        {
            lock (Locker)
            {
#if !BESTHTTP_DISABLE_CACHING && (!UNITY_WEBGL || UNITY_EDITOR)
                Caching.HTTPCacheService.SaveLibrary();
#endif

                var queue = RequestQueue.ToArray();
                RequestQueue.Clear();
                foreach (var req in queue)
                    req.Abort();

                // Close all tcp connections when the application is terminating.
                foreach (var kvp in Connections)
                {
                    foreach (var conn in kvp.Value)
                    {
                        conn.Abort(HTTPConnectionStates.Closed);
                        conn.Dispose();
                    }
                    kvp.Value.Clear();
                }
                Connections.Clear();

                OnUpdate();
            }
        }

        #endregion
    }
}
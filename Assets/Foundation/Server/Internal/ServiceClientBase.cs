// -------------------------------------
//  Domain		: Avariceonline.com
//  Author		: Nicholas Ventimiglia
//  Product		: Unity3d Foundation
//  Published	: 2015
//  -------------------------------------

using System;
using Foundation.Tasks;
using FullSerializer;
using UnityEngine;

namespace Foundation.Server
{
    /// <summary>
    /// Encapsulates Api Http Communication
    /// </summary>
    /// <remarks>
    /// Inherent to access your own strongly typed server side controllers
    /// </remarks>
    public abstract class ServiceClientBase
    {
        #region Shared

        protected ServerConfig Config
        {
            get { return ServerConfig.Instance; }
        }

        protected AccountService AccountService
        {
            get { return AccountService.Instance; }
        }

        public bool IsAuthenticated
        {
            get { return HttpService.IsAuthenticated; }
        }

        private HttpService _client;
        protected HttpService Client
        {
            get
            {

                if (_client == null)
                {
                    _client = new HttpService();
                }
                return _client;
            }
        }

        public string ControllerName { get; protected set; }

        /// <summary>
        /// Unique Id for this application instance
        /// </summary>
        public static readonly string ClientId = Guid.NewGuid().ToString();

        public ServiceClientBase(string controllerName)
        {
            ControllerName = controllerName;
        }

        #endregion


        #region Public Callback Method

        /// <summary>
        /// Posts a get request against a IQueryable OData data source
        /// </summary>
        /// <typeparam name="T">return type</typeparam>
        /// <param name="query">odata query</param>
        /// <param name="callback">handler for the response</param>
        /// <returns>found entity array of type T</returns>
        public void HttpPostAsync<T>(ODataQuery<T> query, Action<Response<T[]>> callback) where T : class
        {

            if (!Config.IsValid)
            {
                callback(new Response<T[]>(new Exception("Invalid configuration."))); return;
            }

            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                callback(new Response<T[]>(new Exception("Invalid configuration."))); return;
            }

            var action = string.Format("api/{1}/Query/{0}", query, ControllerName);

            var url = Config.Path.EndsWith("/") ? Config.Path + action : Config.Path + "/" + action;

            Client.PostAsync(url, callback);
        }

        /// <summary>
        /// Posts a get request against a IQueryable OData data source
        /// </summary>
        /// <typeparam name="T">return type</typeparam>
        /// <param name="prefix">prefix to odata query</param>
        /// <param name="callback">handler for the response</param>
        /// <param name="query">odata query</param>
        public void HttpPostAsync<T>(string prefix, ODataQuery<T> query, Action<Response<T[]>> callback) where T : class
        {
            if (!Config.IsValid)
            {
                callback(new Response<T[]>(new Exception("Invalid configuration."))); return;
            }

            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                callback(new Response<T[]>(new Exception("Invalid configuration."))); return;
            }

            var action = string.Format("api/{0}/Query/{1}{2}", ControllerName, prefix, query);

            var url = Config.Path.EndsWith("/") ? Config.Path + action : Config.Path + "/" + action;

            Client.PostAsync(url, callback);
        }


        /// <summary>
        /// Posts the HTTP request to the server
        /// </summary>
        /// <typeparam name="T">return type</typeparam>
        /// <param name="callback">handler for the response</param>
        /// <param name="method">controller method to call</param>
        public void HttpPostAsync<T>(string method, Action<Response<T>> callback) where T : class
        {

            if (!Config.IsValid)
            {
                callback(new Response<T>(new Exception("Invalid configuration."))); return;
            }

            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                callback(new Response<T>(new Exception("Invalid configuration."))); return;
            }

            var action = string.Format("api/{0}/{1}", ControllerName, method);

            var url = Config.Path.EndsWith("/") ? Config.Path + action : Config.Path + "/" + action;

            Client.PostAsync(url, callback);
        }

        /// <summary>
        /// Posts the HTTP request to the server
        /// </summary>
        /// <typeparam name="T">return type</typeparam>
        /// <param name="method">controller method to call</param>
        /// <param name="id">id parameter</param>
        /// <param name="callback">handler for the response</param>
        public void HttpPostAsync<T>(string method, string id, Action<Response<T>> callback) where T : class
        {
            if (!Config.IsValid)
            {
                callback(new Response<T>(new Exception("Invalid configuration."))); return;
            }

            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                callback(new Response<T>(new Exception("Invalid configuration."))); return;
            }

            var action = string.Format("api/{0}/{1}/{2}", ControllerName, method, id);

            var url = Config.Path.EndsWith("/") ? Config.Path + action : Config.Path + "/" + action;

            Client.PostAsync(url, callback);
        }

        /// <summary>
        /// Posts the HTTP request to the server
        /// </summary>
        /// <typeparam name="T">return type</typeparam>
        /// <param name="method">controller method to call</param>
        /// <param name="entity">dto</param>
        /// <param name="callback">handler for the response</param>
        public void HttpPostAsync<T>(string method, object entity, Action<Response<T>> callback) where T : class
        {
			Debug.LogError ("HttpPostAsync result: " + JsonSerializer.Serialize (entity));
            if (!Config.IsValid)
            {
                callback(new Response<T>(new Exception("Invalid configuration."))); return;
            }

            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                callback(new Response<T>(new Exception("Invalid configuration."))); return;
            }

            var action = string.Format("api/{0}/{1}", ControllerName, method);

            var url = Config.Path.EndsWith("/") ? Config.Path + action : Config.Path + "/" + action;

            Client.PostAsync(url, JsonSerializer.Serialize(entity), callback);
        }


        /// <summary>
        /// Posts the HTTP request to the server
        /// </summary>
        /// <param name="method">controller method to call</param>
        /// <param name="entity">dto</param>
        /// <param name="callback">handler for the response</param>
        public void HttpPostAsync(string method, object entity, Action<Response> callback)
        {
            if (!Config.IsValid)
            {
                callback(new Response(new Exception("Invalid configuration."))); return;
            }

            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                callback(new Response(new Exception("Invalid configuration."))); return;
            }

            var action = string.Format("api/{0}/{1}", ControllerName, method);

            var url = Config.Path.EndsWith("/") ? Config.Path + action : Config.Path + "/" + action;

            Client.PostAsync(url, JsonSerializer.Serialize(entity), callback);
        }

        /// <summary>
        /// Posts the HTTP request to the server
        /// </summary>
        /// <param name="method">controller method to call</param>
        /// <param name="id">id parameter</param>
        /// <param name="callback">handler for the response</param>
        public void HttpPostAsync(string method, string id, Action<Response> callback)
        {
            if (!Config.IsValid)
            {
                callback(new Response(new Exception("Invalid configuration."))); return;
            }

            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                callback(new Response(new Exception("Invalid configuration."))); return;
            }

            var action = string.Format("api/{0}/{1}/{2}", ControllerName, method, id);

            var url = Config.Path.EndsWith("/") ? Config.Path + action : Config.Path + "/" + action;

            Client.PostAsync(url, callback);
        }

        /// <summary>
        /// Posts the HTTP request to the server
        /// </summary>
        /// <param name="method">controller method to call</param>
        /// <param name="callback">handler for the response</param>
        public void HttpPostAsync(string method, Action<Response> callback)
        {
            if (!Config.IsValid)
            {
                callback(new Response(new Exception("Invalid configuration."))); return;
            }

            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                callback(new Response(new Exception("Invalid configuration."))); return;
            }


            var action = string.Format("api/{0}/{1}", ControllerName, method);

            var url = Config.Path.EndsWith("/") ? Config.Path + action : Config.Path + "/" + action;

            Client.PostAsync(url, callback);
        }

        #endregion

        #region Public Async Method

        /// <summary>
        /// Posts a get request against a IQueryable OData data source
        /// </summary>
        /// <typeparam name="T">return type</typeparam>
        /// <param name="query">odata query</param>
        /// <returns>found entity array of type T</returns>
        public UnityTask<T[]> HttpPostAsync<T>(ODataQuery<T> query) where T : class
        {
            if (!Config.IsValid)
                return UnityTask.FailedTask<T[]>("Invalid configuration.");

            if (Application.internetReachability == NetworkReachability.NotReachable)
                return UnityTask.FailedTask<T[]>("Internet not reachable.");

            var action = string.Format("api/{1}/Query/{0}", query, ControllerName);

            var url = Config.Path.EndsWith("/") ? Config.Path + action : Config.Path + "/" + action;

            return Client.PostAsync<T[]>(url);
        }

        /// <summary>
        /// Posts a get request against a IQueryable OData data source
        /// </summary>
        /// <typeparam name="T">return type</typeparam>
        /// <param name="prefix">prefix to odata query</param>
        /// <param name="query">odata query</param>
        /// <returns>found entity array of type T</returns>
        public UnityTask<T[]> HttpPostAsync<T>(string prefix, ODataQuery<T> query) where T : class
        {
			if (Config == null) {
				Debug.LogError ("Config null");
			}
            if (!Config.IsValid)
                return UnityTask.FailedTask<T[]>("Invalid configuration.");

            if (Application.internetReachability == NetworkReachability.NotReachable)
                return UnityTask.FailedTask<T[]>("Internet not reachable.");

            var action = string.Format("api/{0}/Query/{1}{2}", ControllerName, prefix, query);

            var url = Config.Path.EndsWith("/") ? Config.Path + action : Config.Path + "/" + action;

            return Client.PostAsync<T[]>(url);
        }


        /// <summary>
        /// Posts the HTTP request to the server
        /// </summary>
        /// <typeparam name="T">return type</typeparam>
        /// <param name="method">controller method to call</param>
        /// <returns>response of type T</returns>
        public UnityTask<T> HttpPostAsync<T>(string method) where T : class
        {
            if (!Config.IsValid)
                return UnityTask.FailedTask<T>("Invalid configuration.");

            if (Application.internetReachability == NetworkReachability.NotReachable)
                return UnityTask.FailedTask<T>("Internet not reachable.");

            var action = string.Format("api/{0}/{1}", ControllerName, method);

            var url = Config.Path.EndsWith("/") ? Config.Path + action : Config.Path + "/" + action;

            return Client.PostAsync<T>(url);
        }

        /// <summary>
        /// Posts the HTTP request to the server
        /// </summary>
        /// <typeparam name="T">return type</typeparam>
        /// <param name="method">controller method to call</param>
        /// <param name="id">id paramater</param>
        /// <returns>response of type T</returns>
        public UnityTask<T> HttpPostAsync<T>(string method, string id) where T : class
        {
            if (!Config.IsValid)
                return UnityTask.FailedTask<T>("Invalid configuration.");

            if (Application.internetReachability == NetworkReachability.NotReachable)
                return UnityTask.FailedTask<T>("Internet not reachable.");

            var action = string.Format("api/{0}/{1}/{2}", ControllerName, method, id);

            var url = Config.Path.EndsWith("/") ? Config.Path + action : Config.Path + "/" + action;

            return Client.PostAsync<T>(url);
        }

        /// <summary>
        /// Posts the HTTP request to the server
        /// </summary>
        /// <typeparam name="T">return type</typeparam>
        /// <param name="method">controller method to call</param>
        /// <param name="entity">dto</param>
        /// <returns>response of type T</returns>
        public UnityTask<T> HttpPostAsync<T>(string method, object entity) where T : class
        {
            if (!Config.IsValid)
                return UnityTask.FailedTask<T>("Invalid configuration.");

            if (Application.internetReachability == NetworkReachability.NotReachable)
                return UnityTask.FailedTask<T>("Internet not reachable.");

            var action = string.Format("api/{0}/{1}", ControllerName, method);

            var url = Config.Path.EndsWith("/") ? Config.Path + action : Config.Path + "/" + action;

            return Client.PostAsync<T>(url, JsonSerializer.Serialize(entity));
        }


        /// <summary>
        /// Posts the HTTP request to the server
        /// </summary>
        /// <param name="method">controller method to call</param>
        /// <param name="entity">dto</param>
        /// <returns>Metadata</returns>
        public UnityTask HttpPostAsync(string method, object entity)
        {
            if (!Config.IsValid)
                return UnityTask.FailedTask("Invalid configuration.");

            if (Application.internetReachability == NetworkReachability.NotReachable)
                return UnityTask.FailedTask("Internet not reachable.");

            var action = string.Format("api/{0}/{1}", ControllerName, method);

            var url = Config.Path.EndsWith("/") ? Config.Path + action : Config.Path + "/" + action;

            return Client.PostAsync(url, JsonSerializer.Serialize(entity));
        }

        /// <summary>
        /// Posts the HTTP request to the server
        /// </summary>
        /// <param name="method">controller method to call</param>
        /// <param name="id">id paramater</param>
        /// <returns>Metadata</returns>
        public UnityTask HttpPostAsync(string method, string id)
        {
            if (!Config.IsValid)
                return UnityTask.FailedTask("Invalid configuration.");

            if (Application.internetReachability == NetworkReachability.NotReachable)
                return UnityTask.FailedTask("Internet not reachable.");

            var action = string.Format("api/{0}/{1}/{2}", ControllerName, method, id);

            var url = Config.Path.EndsWith("/") ? Config.Path + action : Config.Path + "/" + action;

            return Client.PostAsync(url);
        }

        /// <summary>
        /// Posts the HTTP request to the server
        /// </summary>
        /// <param name="method">controller method to call</param>
        /// <returns>Metadata</returns>
        public UnityTask HttpPostAsync(string method)
        {
            if (!Config.IsValid)
                return UnityTask.FailedTask("Invalid configuration.");

            if (Application.internetReachability == NetworkReachability.NotReachable)
                return UnityTask.FailedTask("Internet not reachable.");

            var action = string.Format("api/{0}/{1}", ControllerName, method);

            var url = Config.Path.EndsWith("/") ? Config.Path + action : Config.Path + "/" + action;

            return Client.PostAsync(url);
        }

        #endregion
    }
}
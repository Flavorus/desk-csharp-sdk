using System;
using RestSharp;
using RestSharp.Authenticators;

namespace Desk
{
    public class DeskApi : IDeskApi
    {
        private enum AuthenticationType
        {
            Basic,
            OAuth 
        }

        /// <summary>
        /// This constructor is used for Basic Authentication against the Desk API. Use this method when you only require
        /// access to your own account.
        /// Desk documentation: http://bit.ly/1jNfykh
        /// </summary>
        public DeskApi(string apiUrlBase, string username, string password)
        {
            ApiUrlBase = apiUrlBase;

            UserName = username;
            Password = password;

            AuthType = AuthenticationType.Basic;
        }

        public DeskApi(string apiUrlBase, string apiKey, string apiSecret, string apiToken, string apiTokenSecret)
        {
            ApiUrlBase = apiUrlBase;

            ApiKey = apiKey;
            ApiSecret = apiSecret;
            ApiToken = apiToken;
            ApiTokenSecret = apiTokenSecret;

            AuthType = AuthenticationType.OAuth;
        }

        private AuthenticationType AuthType { get; set; }

        protected string UserName { get; private set; }

        protected string Password { get; private set; }

        protected string ApiKey { get; private set; }

        protected string ApiSecret { get; private set; }

        protected string ApiToken { get; private set; }

        protected string ApiTokenSecret { get; private set; }

        protected string ApiUrlBase { get; set; }

        public IRestResponse Call(string resource, Method method)
        {
            var client = GetClient();
            var request = GetRequest(method, resource);

            return client.Execute(request);
        }

        private RestClient GetClient()
        {
            var client = new RestClient();

            switch (AuthType)
            {
                case AuthenticationType.Basic:
                    client.Authenticator = new HttpBasicAuthenticator(UserName, Password);
                    break;
                default:
                    client.Authenticator = OAuth1Authenticator.ForProtectedResource(ApiKey, ApiSecret, ApiToken, ApiTokenSecret);
                    break;
            }

            client.BaseUrl = ApiUrlBase;

            return client;
        }

        private RestRequest GetRequest(Method method, string resource)
        {
            var request = new RestRequest();
            request.Method = method;
            request.Resource = resource;
            request.RequestFormat = DataFormat.Json;

            return request;
        }
    }
}

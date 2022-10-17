using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace FileManager.Web.ServiceClients
{
    public class ServiceClientBase
    {
        private HttpClient _serviceClient;

        public HttpClient InitClient()
        {
            var baseAddress = "http://localhost:56754/api/";

            if (String.IsNullOrEmpty(baseAddress))
                throw new Exception("Service base address is not found.");

            var client = new HttpClient { BaseAddress = new Uri(baseAddress) };


            client.Timeout = TimeSpan.FromMinutes(5);
            return client;
        }

        protected HttpClient ServiceClient
        {
            get { return _serviceClient ?? (_serviceClient = InitClient()); }
        }

    }
}
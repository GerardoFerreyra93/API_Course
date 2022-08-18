using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpNunit.ClientSetUp
{
    public class ClientRestSetUp
    {
        protected RestClient client;
        protected RestRequest request;
        protected RestResponse response;

        private string mainUrl = "http://api.zippopotam.us";

        protected void ExecuteGenericRequest(string url, Method method)
        {
            client = new RestClient(mainUrl);
            request = new RestRequest(url, method);
            response = client.Execute(request);
        }
    }
}

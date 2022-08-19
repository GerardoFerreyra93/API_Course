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
        private string mainUrlPost = "https://reqres.in";

        protected void ExecuteGenericRequest(string url, Method method, object body)
        {
            client = new RestClient(mainUrlPost);
            request = new RestRequest(url, method);
            response = client.Execute(request);

            if (body == null)
            {
                response = client.Execute(request);
            }
            else
            {
                request = request.AddBody(body);
                response = client.Execute(request);
            }
        }
    }
}

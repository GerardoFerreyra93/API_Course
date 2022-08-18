using Newtonsoft.Json;
using RestSharp;
using RestSharpNunit.ClientSetUp;
using RestSharpNunit.JSON.DeserializeJSONResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpNunit.RequestValidations
{
    public class RequestValidationsMethods : ClientRestSetUp
    {
        private PlaceDetailsResponse placeDetailsResponse;

        internal void ValidateResponseIsJSON()
        {
            ExecuteGenericRequest("nl/3825", Method.Get);
            placeDetailsResponse = JsonConvert.DeserializeObject<PlaceDetailsResponse>(response.Content);
            Assert.That(response.ContentType, Is.EqualTo("application/json"));
            
        }

        internal void ValidateResponseIsNetherlands()
        {
            ExecuteGenericRequest("nl/3825", Method.Get);
            placeDetailsResponse = JsonConvert.DeserializeObject<PlaceDetailsResponse>(response.Content);            
            Assert.AreEqual(placeDetailsResponse.country, "Netherlands");
        }
    }
}

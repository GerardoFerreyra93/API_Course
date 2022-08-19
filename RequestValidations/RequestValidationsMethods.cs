using Newtonsoft.Json;
using RestSharp;
using RestSharpNunit.ClientSetUp;
using RestSharpNunit.JSON.DeserializeJSONResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.IO;
using RestSharpNunit.JSON.SerializerJSONBody;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Net;

namespace RestSharpNunit.RequestValidations
{
    public class RequestValidationsMethods : ClientRestSetUp
    {
        private PlaceDetailsResponse placeDetailsResponse;
        private JsonSerializerPost jsonSerializerPost;
        
        internal void ValidateResponseIsJSON()
        {
            //ExecuteGenericRequest("nl/3825", Method.Get);//para correr esta modificar endpoint
            placeDetailsResponse = JsonConvert.DeserializeObject<PlaceDetailsResponse>(response.Content);
            Assert.That(response.ContentType, Is.EqualTo("application/json"));
            
        }

        internal void ValidateResponseIsNetherlands()
        {
            //ExecuteGenericRequest("nl/3825", Method.Get); //para correr esta modificar endpoint
            placeDetailsResponse = JsonConvert.DeserializeObject<PlaceDetailsResponse>(response.Content);            
            Assert.AreEqual(placeDetailsResponse.country, "Netherlands");
        }

        internal void ValidateSerializerPost()
        {

            /*var postValues = new JsonSerializerPost
            {
                name = "gerardo",
                job = "qa"             
            };

            string jsonString = JsonSerializer.Serialize(postValues);
            ExecuteGenericRequest("https://reqres.in/api/users", Method.Post);                  
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));//VALIDACION CODIGO 201 CREATED SUCCESS
            Console.WriteLine(response.Content);//validacion usr creado
            //Console.WriteLine(jsonString);

            jsonSerializerPost = JsonConvert.DeserializeObject<JsonSerializerPost>(jsonString);
            Assert.AreEqual(jsonSerializerPost.name, "gerardo");
            //Console.WriteLine(jsonSerializerPost.name); // validar values post*/

            JsonSerializerPost examplePostBody = new JsonSerializerPost
            {
                name = "Kksdmekasd",
                job = "Obrero"
            };

            ExecuteGenericRequest("/api/users", Method.Post, examplePostBody);

            jsonSerializerPost = JsonConvert.DeserializeObject<JsonSerializerPost>(response.Content);
            Assert.AreEqual("Kksdmekasd", jsonSerializerPost.name);
            Assert.IsTrue(response.IsSuccessful);
        }

    }
}

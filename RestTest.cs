using RestSharp;
using RestSharpNunit.RequestValidations;

namespace RestSharpNunit
{
    public class Tests : RequestValidationsMethods
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void APITest()
        {
            RestClient client = new RestClient("http://api.zippopotam.us");
            RestRequest request = new RestRequest("nl/3825", Method.Get);
            RestResponse response = client.Execute(request);       

            Assert.That(response.ContentType, Is.EqualTo("application/json")); //cuando hay problemas en el codigo para validar
        }

        [Test]
        [Category("ApiTest")]
        public void ValidateJSONResponse()
        {
            ValidateResponseIsJSON();
            ValidateResponseIsNetherlands();
            
        }

        [Test]
        [Category("ApiTest")]
        public void ValidatePostSerializer()
        {

            ValidateSerializerPost();       
                      
        }
    }
}
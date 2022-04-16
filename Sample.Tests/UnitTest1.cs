using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Sample.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GwpAvgTest()
        {
            var client = new HttpClient();
            InputParam input = new InputParam() { Country = "Singapore", Lob = "Finance", FromYear = 2008, ToYear = 2015 };

            var json = JsonConvert.SerializeObject(input);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var hostUrl = "https://localhost:9091/server/gwp/avg";
            var response = client.PostAsync($"{hostUrl}", data).Result;

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var respData = JsonConvert.DeserializeObject<GrossWrittenPremium>(response.Content.ReadAsStringAsync().Result);
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
    }
    public class InputParam
    {
        public string? Country { get; set; }
        public string? Lob { get; set; }
        public int FromYear { get; set; }
        public int ToYear { get; set; }

    }

    public class GrossWrittenPremium
    {
        public string? Transport { get; set; }
        public string? liability { get; set; }
    }
}
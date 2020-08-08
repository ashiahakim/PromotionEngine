using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace PromotionEngine.Test
{
    public class EnsureWebApp : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public EnsureWebApp(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        private async Task<HttpResponseMessage> CallCostCalculatorController(Dictionary<string, int> input)
        {
            var client = _factory.CreateClient();
            var serializedInput = JsonConvert.SerializeObject(input);
            return await client.PostAsync("api/CostCalculator/CalculateCost", new StringContent(serializedInput, Encoding.UTF8, "application/json"));
        }

        [Fact]
        public async Task ThenCorrectResponseReturned()
        {
            var input = new Dictionary<string, int>
                {
                    { "a", 3 },
                    { "b", 5 },
                    { "c", 1 },
                    { "d", 1 }
                };
            var result = await CallCostCalculatorController(input);
            var content = await result.Content.ReadAsStringAsync();
            content.ShouldBe("280");
        }

        [Fact]
        public async Task ThenBadRequestReturned()
        {
            var input = new Dictionary<string, int>
                {
                    { "a", -3 },
                    { "b", 5 },
                    { "c", 1 },
                    { "d", 1 }
                };
            var result = await CallCostCalculatorController(input);
            var content = await result.Content.ReadAsStringAsync();
            content.ShouldBe("Input can't be negative");
        }

    }
}

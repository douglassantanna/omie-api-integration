using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Flurl.Http;
using omie_api_integration.Shared;

namespace omie_poc.Omie.Conta
{
    public class Contas : IContas
    {
        private readonly HttpClient _http;
        public Contas(HttpClient http)
        {
            _http = http;
        }

        public async Task<Result> GetContas(ContaRequest request)
        {
            var response = await _http.BaseAddress
            .WithHeader("Content-type", "application/json")
            .WithHeader("accept", "application/json")
            .SendJsonAsync(HttpMethod.Post, request);

            var responseString = await response.GetStringAsync();

            if (response.StatusCode != 200)
            {
                return new("", false, responseString);
            }
            else
            {
                var conta = JsonSerializer.Deserialize<ContaResponse>(responseString);
                return new("", true, conta);
            }
        }
    }
}
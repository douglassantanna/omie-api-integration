using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Flurl.Http;

namespace omie_poc.Conta
{
    public class Contas : IContas
    {
        private readonly HttpClient _http;
        public Contas(HttpClient http)
        {
            _http = http;
        }

        public async Task<ContaResponse> GetContas(ContaRequest request)
        {
            var response = await _http.BaseAddress
            .WithHeader("Content-type", "application/json")
            .WithHeader("accept", "application/json")
            .SendJsonAsync(HttpMethod.Post, request);

            var responseString = await response.GetStringAsync();
            var conta = JsonSerializer.Deserialize<ContaResponse>(responseString);
            return conta;
        }
    }
}
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.Extensions.Logging;

namespace omie_poc.Conta
{
    public record Mensagem(string Msg);
    public class Contas : IContas
    {
        private readonly HttpClient _http;
        private readonly ILogger<Contas> _logger;
        public Contas(HttpClient http, ILogger<Contas> logger)
        {
            _http = http;
            _logger = logger;
        }

        public async Task<ContaResponse> GetContas(ContaRequest request)
        {
            var response = "https://app.omie.com.br/api/v1/crm/contas/".WithHeader();
            // var opt = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true, WriteIndented = true };
            // var requestString = JsonSerializer.Serialize(request);
            // var requestContent = new StringContent(requestString, Encoding.UTF8, "application/json");

            // var result = await _http.PostAsync(_http.BaseAddress, requestContent);

            // var resultString = await result.Content.ReadAsByteArrayAsync();
            // if (result.IsSuccessStatusCode)
            // {
            //     var response = JsonSerializer.Deserialize<ContaResponse>(resultString, new JsonSerializerOptions()
            //     {
            //         PropertyNameCaseInsensitive = true,
            //         WriteIndented = true
            //     });
            //     return response;
            // }
            // return null;
        }
    }
}
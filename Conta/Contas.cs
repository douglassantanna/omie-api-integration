using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
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

        public async Task<ContaRequest> GetContas(ContaRequest contentRequest)
        {
            var jsonRequest = JsonSerializer.Serialize<ContaRequest>(contentRequest);
            var stringRequest = new StringContent(jsonRequest);
            var stringResponse = await stringRequest.ReadAsStringAsync();
            var response = await GetContasSoap(stringRequest).Result;

            return response;
        }

        private async Task<string> GetContasSoap(string request)
        {
            var content = new StringContent(request, Encoding.UTF8, "text/xml");
            var contentRequest = new HttpRequestMessage(HttpMethod.Post, _http.BaseAddress);
            contentRequest.Headers.Add("SOAPAction", "");
            contentRequest.Content = content;
            var responseRequest = await _http.SendAsync(contentRequest, HttpCompletionOption.ResponseHeadersRead);
            var responseRequestString = await responseRequest.Content.ReadAsStringAsync();
            return responseRequestString;
        }
    }
}
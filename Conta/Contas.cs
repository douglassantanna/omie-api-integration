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
        public async Task<ContaResponse> GetContas(ContaRequest request)
        {
            var opt = new JsonSerializerOptions()
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            };
            //converter em json
            var jsonRequest = JsonSerializer.Serialize<ContaRequest>(request, opt);

            //converter em string
            var stringRequest = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            //chamada post na uri e armazenando em result
            var response = await _http.PostAsync(_http.BaseAddress, stringRequest);

            //o resultado de result é lido como string e armazenado em resultString
            var resultString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = JsonSerializer.Deserialize<ContaResponse>(resultString, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
                _logger.LogInformation("sucesso");
                return stringResponse;
            }
            _logger.LogInformation("falha");
            return null;
        }
    }
}
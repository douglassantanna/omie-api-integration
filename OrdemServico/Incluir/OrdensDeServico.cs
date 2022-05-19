using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using omie_api_integration.OrdemServico.Incluir;

namespace omie_poc.OrdemServico.Incluir
{
    public class OrdensDeServico : IOrdemDeServico
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<OrdemDeServicoResponse> _logger;

        public OrdensDeServico(HttpClient httpClient, ILogger<OrdemDeServicoResponse> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<OrdemDeServicoResponse> IncluirOS(OrdemDeServicoRequest request)
        {
            try
            {
                var response = await _httpClient.BaseAddress
                .WithHeader("Content-type", "application/json")
                .WithHeader("accept", "application/json")
                .SendJsonAsync(HttpMethod.Post, request);

                var responseString = await response.GetStringAsync();
                var ordemDeServico = JsonSerializer.Deserialize<OrdemDeServicoResponse>(responseString);
                return ordemDeServico;
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return null;
            }

        }
    }
}
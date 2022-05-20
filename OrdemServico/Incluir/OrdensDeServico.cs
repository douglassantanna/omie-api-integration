using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using omie_api_integration.OrdemServico.Incluir;
using omie_api_integration.Shared;

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
        public async Task<object> IncluirOS(OrdemDeServicoRequest request)
        {
            var response = await _httpClient.BaseAddress
            .WithHeader("Content-type", "application/json")
            .WithHeader("accept", "application/json")
            .SendJsonAsync(HttpMethod.Post, request);

            var responseString = await response.GetStringAsync();

            if (response.StatusCode != 200)
            {
                return new NotificationResult().Failure().AddMessage($"{responseString}");
            }
            var ordemDeServico = JsonSerializer.Deserialize<OrdemDeServicoResponse>(responseString);
            return new NotificationResult().Ok().ShowObject(ordemDeServico);
        }
    }
}
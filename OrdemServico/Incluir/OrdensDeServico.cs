using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace omie_poc.OrdemServico.Incluir
{
    public class OrdensDeServico
    {
        private HttpClient _httpClient;

        public OrdensDeServico(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OrdemDeServicoResponse> Criar(OrdemDeServicoRequest request)
        {
            var requestContent = new StringContent(
                JsonSerializer.Serialize(request),
                Encoding.UTF8,
                "application/json"
            );

            var result = await _httpClient.PostAsync(_httpClient.BaseAddress, requestContent);
            string resultString = result.Content.ReadAsStringAsync().Result;

            var response = JsonSerializer.Deserialize<OrdemDeServicoResponse>(resultString);
            return response;
        }
    }
}
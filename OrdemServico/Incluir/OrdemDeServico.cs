using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace omie_poc.OrdemServico.Incluir
{
    public class OrdemDeServico
    {
        private HttpClient _httpClient;

        public OrdemDeServico(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OrdemDeServicoRequest> Get(OrdemDeServicoRequest req, string app_key, string app_secret)
        {
            var reqContent = new StringContent(
                JsonSerializer.Serialize(req),
                Encoding.UTF8,
                "application/json"
            );
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(app_key, app_secret);
            var res = await _httpClient.PostAsync(_httpClient.BaseAddress, reqContent);
            string resString = res.Content.ReadAsStringAsync().Result;
            var result = JsonSerializer.Deserialize<OrdemDeServicoRequest>(resString);
            return result;
        }
    }
}
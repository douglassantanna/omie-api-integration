using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Flurl.Http;
using Newtonsoft.Json;
using omie_api_integration.Shared;
using omie_poc.Omie.Conta;
using omie_poc.Omie.Servico;

namespace omie_api_integration.Omie.OrdemServico.Listar
{
    public interface IListarOS
    {
        public Task<Result> ListarOS(ListarOSRequest request);
    }
    public class ListarOSs : IListarOS
    {
        private readonly HttpClient _httpClient;

        public ListarOSs(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Result> ListarOS(ListarOSRequest request)
        {
            var response = await _httpClient.BaseAddress
             .WithHeader("Content-type", "application/json")
             .WithHeader("accept", "application/json")
             .AllowAnyHttpStatus()
             .SendJsonAsync(HttpMethod.Post, request);

            if (response.StatusCode > 300)
            {
                var error = await response.GetJsonAsync<OmieErrorResult>();
                return new("", false, error);
            }
            var responseString = await response.GetStringAsync();
            var responseDeserialized = JsonConvert.DeserializeObject<ListarOSResponse>(responseString);
            return new("", true, responseDeserialized);
        }
    }
}
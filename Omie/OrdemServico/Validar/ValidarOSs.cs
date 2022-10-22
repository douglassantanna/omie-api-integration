using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Flurl.Http;
using Newtonsoft.Json;
using omie_api_integration.Shared;
using omie_poc.Omie.Conta;
using omie_poc.Omie.Servico;

namespace omie_api_integration.Omie.OrdemServico.Validar
{
    public interface IValidarOS
    {
        public Task<Result> ValidarOS(ValidarOSRequest request);
    }
    public class ValidarOSs : IValidarOS
    {
        private readonly HttpClient _httpClient;

        public ValidarOSs(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result> ValidarOS(ValidarOSRequest request)
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
            var responseDeserialized = JsonConvert.DeserializeObject<ValidarOSResponse>(responseString);
            return new("", true, responseDeserialized);
        }

    }
}
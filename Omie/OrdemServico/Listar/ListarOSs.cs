using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Flurl.Http;
using omie_api_integration.Shared;

namespace omie_api_integration.Omie.OrdemServico.Listar
{
    public interface IListarOS
    {
        public Task<NotificationResult> ListarOS(ListarOSRequest request);
    }
    public class ListarOSs : IListarOS
    {
        private readonly HttpClient _httpClient;

        public ListarOSs(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<NotificationResult> ListarOS(ListarOSRequest request)
        {
            var response = await _httpClient.BaseAddress
             .WithHeader("Content-type", "application/json")
             .WithHeader("accept", "application/json")
             .AllowAnyHttpStatus()
             .SendJsonAsync(HttpMethod.Post, request);

            if (response.StatusCode > 300)
            {
                var error = await response.GetJsonAsync<NotificationResult>();
                return new NotificationResult().Failure().AddNotification($"{error.Notifications}");
            }
            var responseString = await response.GetStringAsync();
            return new NotificationResult().Ok().ShowResult(responseString, new JsonSerializerOptions() { WriteIndented = true });
        }
    }
}
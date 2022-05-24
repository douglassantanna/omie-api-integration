using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Flurl.Http;
using omie_api_integration.Shared;

namespace omie_api_integration.OrdemServico.Faturar
{
    public interface IFaturarOS
    {
        public Task<NotificationResult> FaturarOS(FaturarOSRequest request);
    }
    public class FaturarOSs : IFaturarOS
    {
        private readonly HttpClient _httpClient;

        public FaturarOSs(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<NotificationResult> FaturarOS(FaturarOSRequest request)
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
            // var fatura = JsonSerializer.Deserialize<FaturarOSResponse>(responseString, new JsonSerializerOptions() { WriteIndented = true });
            return new NotificationResult().Ok().ShowResult(responseString);
        }
    }
}
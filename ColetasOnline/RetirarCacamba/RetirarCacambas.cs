using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using omie_api_integration.Shared;

namespace omie_api_integration.ColetasOnline.RetirarCacamba
{
    public class RetirarCacambas : IRetirarCacamba
    {
        private readonly HttpClient _httpClient;
        public RetirarCacambas(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<NotificationResult> RetiraCacamba()
        {
            try
            {
                var body = File.ReadAllText("retirar-cacamba.xml");
                var request = await RequestSoap(body);
                return new NotificationResult().Ok().ShowResult(request);
            }
            catch (System.Exception ex)
            {
                return new NotificationResult().Failure().ShowMessage($"{ex.Message}");
            }
        }
        private async Task<string> RequestSoap(string request)
        {
            var content = new StringContent(request, Encoding.UTF8, "text/xml");
            var contentRequest = new HttpRequestMessage(HttpMethod.Post, "http://wscoletas.coletasonline.com.br/WSColetas.asmx");
            contentRequest.Headers.Add("soap+xml", "");
            contentRequest.Content = content;
            var responseRequest = await _httpClient.SendAsync(contentRequest, HttpCompletionOption.ResponseHeadersRead);
            var responseRequestString = await responseRequest.Content.ReadAsStringAsync();
            return responseRequestString;
        }
    }
}
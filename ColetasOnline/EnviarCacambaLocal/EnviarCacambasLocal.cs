using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using omie_api_integration.Shared;

namespace omie_api_integration.ColetasOnline.EnviarCacambaLocal
{
    public class EnviarCacambasLocal : IEnviarCacambaLocal
    {
        private readonly HttpClient _httpClient;
        public EnviarCacambasLocal(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Result> EnviaCacamba()
        {
            try
            {
                var body = File.ReadAllText("enviar-cacamba-obra-local.xml");
                var request = await RequestSoap(body);
                return new("", true, request);
            }
            catch (System.Exception ex)
            {
                throw;
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
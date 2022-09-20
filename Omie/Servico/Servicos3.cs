using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using omie_api_integration.Shared;
using omie_poc.Omie.Compartilhado;

namespace omie_poc.Omie.Servico
{
    public class Servicos : IServicos
    {
        private readonly HttpClient _http;

        public Servicos(HttpClient http)
        {
            _http = http;
        }

        public async Task<NotificationResult> CriarServico(OmieRequest request)
        {
            try
            {
                var httpResult = await "https://app.omie.com.br/api/v1/"
                 .AppendPathSegment("servicos/servico/")
                 .WithHeader("Content-type", "application/json")
                 .WithHeader("accept", "application/json")
                 .PostJsonAsync(request)
                 .ReceiveJson<OmieCriarServicoResult>();

                return new NotificationResult().Ok().ShowServicoResult(httpResult);
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<OmieErrorResult>();
                return new NotificationResult().Failure().ShowResult(errors);
                // return new("Ocorreu um erro na requisicao. Tente novamente.", new OmieCriarCacambaResult(errors), false);

            }
        }
    }
}
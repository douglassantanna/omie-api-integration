using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using omie_api_integration.Shared;
using omie_poc.Omie.Compartilhado;

namespace omie_poc.Omie.Servico
{
    public class Servicos : IOmieServico
    {
        private readonly HttpClient _http;

        public Servicos(HttpClient http)
        {
            _http = http;
        }

        public async Task<Result> CriarServico(OmieRequest request)
        {
            try
            {
                var httpResult = await "https://app.omie.com.br/api/v1/"
                 .AppendPathSegment("servicos/servico/")
                 .WithHeader("Content-type", "application/json")
                 .WithHeader("accept", "application/json")
                 .PostJsonAsync(request)
                 .ReceiveJson<OmieCriarServicoResult>();

                return new("", true, new Xomie(httpResult.cCodIntServ, httpResult.nCodServ));
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<OmieErrorResult>();
                return new("", false, errors);
            }
        }
    }
}
public record Xomie(string cCodIntServ, long nCodServ);
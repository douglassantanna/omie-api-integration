using System.Threading.Tasks;
using omie_api_integration.Shared;
using omie_poc.Omie.Compartilhado;

namespace omie_poc.Omie.Servico
{
    public interface IOmieServico
    {
        Task<Result> CriarServico(OmieRequest request);
    }
}
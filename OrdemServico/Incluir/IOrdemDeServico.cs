using System.Threading.Tasks;
using omie_api_integration.Shared;
using omie_poc.OrdemServico.Incluir;

namespace omie_api_integration.OrdemServico.Incluir
{
    public interface IOrdemDeServico
    {
        Task<NotificationResult> IncluirOS(OrdemDeServicoRequest request);
    }
}
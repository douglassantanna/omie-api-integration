using System.Threading.Tasks;
using omie_api_integration.Shared;

namespace omie_poc.Omie.OrdemServico.Incluir
{
    public interface IOrdemDeServico
    {
        Task<NotificationResult> IncluirOS(OrdemDeServicoRequest request);
    }
}
using System.Threading.Tasks;
using omie_poc.OrdemServico;
using omie_poc.OrdemServico.Incluir;

namespace omie_api_integration.OrdemServico.Incluir
{
    public interface IOrdemDeServico
    {
        Task<object> IncluirOS(OrdemDeServicoRequest request);
    }
}
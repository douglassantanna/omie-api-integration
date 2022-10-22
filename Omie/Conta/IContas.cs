using System.Threading.Tasks;
using omie_api_integration.Shared;

namespace omie_poc.Omie.Conta
{
    public interface IContas
    {
        Task<Result> GetContas(ContaRequest request);
    }
}
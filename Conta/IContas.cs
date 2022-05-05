using System.Threading.Tasks;

namespace omie_poc.Conta
{
    public interface IContas
    {
        Task<ContaResponse> GetContas(ContaRequest request);
    }
}
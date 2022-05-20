using System.Threading.Tasks;

namespace omie_poc.Conta
{
    public interface IContas
    {
        Task<object> GetContas(ContaRequest request);
    }
}
using System.Threading.Tasks;

namespace omie_poc.Omie.Conta
{
    public interface IContas
    {
        Task<object> GetContas(ContaRequest request);
    }
}
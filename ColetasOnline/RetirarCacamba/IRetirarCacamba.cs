using System.Threading.Tasks;
using omie_api_integration.Shared;

namespace omie_api_integration.ColetasOnline.RetirarCacamba
{
    public interface IRetirarCacamba
    {
        Task<Result> RetiraCacamba();
    }
}
using System.Threading.Tasks;
using omie_api_integration.Shared;

namespace omie_api_integration.ColetasOnline.EnviarCacambaLocal
{
    public interface IEnviarCacambaLocal
    {
        Task<Result> EnviaCacamba();
    }
}
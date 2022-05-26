using System.Threading.Tasks;
using omie_api_integration.Shared;

namespace omie_api_integration.Prefeitura
{
    public interface IListarPrefeitura
    {
        Task<NotificationResult> ObterPrefeituras();
    }
}
using System.Threading.Tasks;
using omie_api_integration.Shared;

namespace omie_api_integration.ColetasOnline.Prefeitura
{
    public interface IListarPrefeitura
    {
        Task<NotificationResult> ObterPrefeituras();
    }
}
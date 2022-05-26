using System.Threading.Tasks;
using omie_api_integration.Shared;

namespace omie_api_integration.ColetasOnline.CTR.SolicitarCtr
{
    public interface ISolicitarCTR
    {
        Task<NotificationResult> SolicitaCTR();

    }
}
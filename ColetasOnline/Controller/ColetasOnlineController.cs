using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using omie_api_integration.ColetasOnline.CTR.SolicitarCtr;
using omie_api_integration.ColetasOnline.Prefeitura;

namespace omie_api_integration.ColetasOnline.Controller
{

    [ApiController]
    [Route("coletas-online")]
    public class ColetasOnlineController : ControllerBase
    {
        private readonly IListarPrefeitura _prefeitura;
        private readonly ISolicitarCTR _ctr;

        public ColetasOnlineController(IListarPrefeitura prefeitura, ISolicitarCTR ctr)
        {
            _prefeitura = prefeitura;
            _ctr = ctr;
        }
        [HttpPost("listar-prefeitura")]
        public async Task<IActionResult> ObterPrefeituras()
        {
            var response = await _prefeitura.ObterPrefeituras();
            return Ok(response);
        }
        [HttpPost("solicitar-ctr")]
        public async Task<IActionResult> SolicitarCTR()
        {
            var response = await _ctr.SolicitaCTR();
            return Ok(response);
        }
    }
}
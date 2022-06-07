using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using omie_api_integration.ColetasOnline.CTR.SolicitarCtr;
using omie_api_integration.ColetasOnline.EnviarCacambaLocal;
using omie_api_integration.ColetasOnline.Prefeitura;
using omie_api_integration.ColetasOnline.RetirarCacamba;

namespace omie_api_integration.ColetasOnline.Controller
{

    [ApiController]
    [Route("coletas-online")]
    public class ColetasOnlineController : ControllerBase
    {
        private readonly IListarPrefeitura _prefeitura;
        private readonly ISolicitarCTR _ctr;
        private readonly IEnviarCacambaLocal _cacamba;
        private readonly IRetirarCacamba _retirarCacamba;

        public ColetasOnlineController(IListarPrefeitura prefeitura, ISolicitarCTR ctr, IEnviarCacambaLocal cacamba, IRetirarCacamba retirarCacamba)
        {
            _prefeitura = prefeitura;
            _ctr = ctr;
            _cacamba = cacamba;
            _retirarCacamba = retirarCacamba;
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
        [HttpPost("enviar-cacamba")]
        public async Task<IActionResult> EnviarCacamba()
        {
            var response = await _cacamba.EnviaCacamba();
            return Ok(response);
        }
        [HttpPost("retirar-cacamba")]
        public async Task<IActionResult> RetirarCacamba()
        {
            var response = await _retirarCacamba.RetiraCacamba();
            return Ok(response);
        }
    }
}
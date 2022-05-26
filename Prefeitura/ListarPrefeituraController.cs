using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace omie_api_integration.Prefeitura
{

    [ApiController]
    [Route("coletas-online")]
    public class ListarPrefeituraController : ControllerBase
    {
        private readonly IListarPrefeitura _prefeitura;

        public ListarPrefeituraController(IListarPrefeitura prefeitura)
        {
            _prefeitura = prefeitura;
        }
        [HttpPost("listar-prefeitura")]
        public async Task<IActionResult> Get()
        {
            var response = await _prefeitura.ObterPrefeituras();
            return Ok(response);
        }
    }
}
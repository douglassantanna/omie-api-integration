using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using omie_api_integration.OrdemServico.Incluir;
using omie_poc.OrdemServico.Incluir;

namespace omie_poc.OrdemServico.Controllers
{
    [ApiController]
    [Route("ordem-servico")]
    public class OrdemDeServicoController : ControllerBase
    {
        private readonly IOrdemDeServico _ordem;

        public OrdemDeServicoController(IOrdemDeServico ordemDeServico)
        {
            _ordem = ordemDeServico;
        }
        [HttpPost("incluir-os")]
        public async Task<IActionResult> IncluirOS(OrdemDeServicoRequest request)
        {
            var ordemDeServico = await _ordem.IncluirOS(request);
            return Ok(ordemDeServico);
        }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using omie_api_integration.OrdemServico.Incluir;
using omie_poc.OrdemServico.Incluir;

namespace omie_poc.OrdemServico.Controllers
{
    [Route("ordem-servico")]
    [ApiController]
    public class OrdemDeServicoController : ControllerBase
    {
        private readonly IOrdemDeServico _ordem;

        public OrdemDeServicoController(IOrdemDeServico ordemDeServico)
        {
            _ordem = ordemDeServico;
        }
        [HttpPost]
        public async Task<IActionResult> IncluirOS(OrdemDeServicoRequest request)
        {
            var ordemDeServico = await _ordem.IncluirOS(request);
            return Ok(ordemDeServico);
        }
    }
}
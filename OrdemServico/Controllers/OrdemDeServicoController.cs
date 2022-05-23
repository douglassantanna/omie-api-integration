using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using omie_api_integration.OrdemServico.Incluir;
using omie_api_integration.OrdemServico.Listar;
using omie_poc.OrdemServico.Incluir;

namespace omie_poc.OrdemServico.Controllers
{
    [ApiController]
    [Route("ordem-servico")]
    public class OrdemDeServicoController : ControllerBase
    {
        private readonly IOrdemDeServico _ordem;
        private readonly IListarOS _listar;

        public OrdemDeServicoController(IOrdemDeServico ordemDeServico, IListarOS listar)
        {
            _ordem = ordemDeServico;
            _listar = listar;
        }
        [HttpPost("incluir-os")]
        public async Task<IActionResult> IncluirOS(OrdemDeServicoRequest request)
        {
            var ordemDeServico = await _ordem.IncluirOS(request);
            return Ok(ordemDeServico);
        }
        [HttpPost("listar-os")]
        public async Task<IActionResult> ListarOS(ListarOSRequest request)
        {
            var ordemDeServico = await _listar.ListarOS(request);
            return Ok(ordemDeServico);
        }
    }
}
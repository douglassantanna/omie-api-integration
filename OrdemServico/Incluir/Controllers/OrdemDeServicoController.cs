using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using omie_poc.OrdemServico.Incluir;

namespace omie_poc.OrdemServico.Controllers
{
    [Route("ordem-servico")]
    [ApiController]
    public class OrdemDeServicoController : ControllerBase
    {
        private OrdensDeServico _ordem;

        public OrdemDeServicoController(OrdensDeServico ordemDeServico)
        {
            _ordem = ordemDeServico;
        }
        [HttpPost("incluirOS")]
        public IActionResult CriarOS(OrdemDeServicoRequest request)
        {
            if (request != null)
            {
                var ordemDeServico = _ordem.Criar(request);
                return Ok();
            }
            return BadRequest();

        }
    }
}
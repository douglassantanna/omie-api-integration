using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using omie_poc.OrdemServico.Incluir;

namespace omie_poc.Controllers
{
    [Route("incluirOS")]
    [ApiController]
    public class OmieController : ControllerBase
    {
        private OrdensDeServico _ordem;

        public OmieController(OrdensDeServico ordemDeServico)
        {
            _ordem = ordemDeServico;
        }
        [HttpPost]
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
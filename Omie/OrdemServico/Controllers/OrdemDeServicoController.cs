using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using omie_api_integration.Omie.OrdemServico.Faturar;
using omie_api_integration.Omie.OrdemServico.Listar;
using omie_api_integration.Omie.OrdemServico.Validar;
using omie_poc.Omie.OrdemServico.Incluir;

namespace omie_poc.Omie.OrdemServico.Controllers
{
    [ApiController]
    [Route("ordem-servico")]
    public class OrdemDeServicoController : ControllerBase
    {
        private readonly IOrdemDeServico _ordem;
        private readonly IListarOS _listar;
        private readonly IFaturarOS _faturar;
        private readonly IValidarOS _validar;

        public OrdemDeServicoController(IOrdemDeServico ordemDeServico, IListarOS listar, IFaturarOS faturar)
        {
            _ordem = ordemDeServico;
            _listar = listar;
            _faturar = faturar;
        }
        [HttpPost("incluir-os")]
        public async Task<IActionResult> IncluirOS(OrdemDeServicoRequest request)
        {
            var incluirOS = await _ordem.IncluirOS(request);
            return Ok(incluirOS);
        }
        [HttpPost("listar-os")]
        public async Task<IActionResult> ListarOS(ListarOSRequest request)
        {
            var listarOS = await _listar.ListarOS(request);
            return Ok(listarOS);
        }
        [HttpPost("faturar-os")]
        public async Task<IActionResult> FaturarOS(FaturarOSRequest request)
        {
            var faturarOS = await _faturar.FaturarOS(request);
            return Ok(faturarOS);

        }
        [HttpPost("validar-os")]
        public async Task<IActionResult> ValidarOS(ValidarOSRequest request)
        {
            var validarOS = await _validar.ValidarOS(request);
            return Ok(validarOS);
        }
    }
}
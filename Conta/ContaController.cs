using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace omie_poc.Conta
{
    [Route("conta")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IContas _contas;
        private readonly ILogger<ContaController> _logger;
        public ContaController(IContas contas, ILogger<ContaController> logger)
        {
            _contas = contas;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Get(ContaRequest contaRequest)
        {
            ContaResponse response = await _contas.GetContas(contaRequest);
            return Ok(response);
        }
    }
}
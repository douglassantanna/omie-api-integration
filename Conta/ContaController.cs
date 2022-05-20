using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace omie_poc.Conta
{
    [ApiController]
    [Route("conta")]
    public class ContaController : ControllerBase
    {
        private readonly IContas _contas;
        public ContaController(IContas contas)
        {
            _contas = contas;
        }

        [HttpPost("consultar-contas")]
        public async Task<IActionResult> Get(ContaRequest contaRequest)
        {
            var response = await _contas.GetContas(contaRequest);
            return Ok(response);
        }
    }
}
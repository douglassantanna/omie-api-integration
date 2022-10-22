using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace omie_poc.Omie.Conta
{
    [ApiController]
    [Route("conta")]
    public class ContaController : ControllerBase
    {
        private readonly IContas _contas;
        private readonly IMediator _mediator;
        public ContaController(IContas contas, IMediator mediator)
        {
            _contas = contas;
            _mediator = mediator;
        }

        [HttpPost("consultar-contas")]
        public async Task<IActionResult> Get(ContaRequest contaRequest)
        {
            var response = await _contas.GetContas(contaRequest);
            return Ok(response);
        }
    }
}
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using omie_poc.Omie.Servico;

namespace omie_api_integration.Omie.Servico
{
    [ApiController]
    [Route("servico")]
    public class ServicoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Criar(NovaServicoComando comando)
        {
            var result = await _mediator.Send(comando);
            if (!result.Sucesso)
                return BadRequest(result);
            return Created("", result);
        }
    }
}
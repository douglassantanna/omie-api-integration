using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using omie_api_integration.Shared;

namespace omie_poc.Omie.Servico
{
    public record NovaServicoComando(string Numero, string Volume, decimal Preco) : IRequest<Result>;

    public class NovoServicoHandler : IRequestHandler<NovaServicoComando, Result>
    {
        private readonly IOmieServico _servicos;
        private readonly IMediator _mediator;
        private readonly ILogger<NovoServicoHandler> _logger;


        public NovoServicoHandler(IOmieServico servicos, IMediator mediator, ILogger<NovoServicoHandler> logger)
        {
            _servicos = servicos;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<Result> Handle(NovaServicoComando request, CancellationToken cancellationToken)
        {
            IntIncluir intIncluir = new(request.Numero);
            Cabecalho cabecalho = new(request.Numero, request.Volume);
            OmieCriarServicoRequest criarServico = new(intIncluir, cabecalho);
            var omieResponse = await _mediator.Send(criarServico);
            if (!omieResponse.Sucesso)
            {
                _logger.LogError("erro na requisição");
                return omieResponse;
            }
            return omieResponse;
        }
    }
}
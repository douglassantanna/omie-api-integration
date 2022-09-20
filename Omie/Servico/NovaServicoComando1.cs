using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using omie_api_integration.Shared;

namespace omie_poc.Omie.Servico
{
    public record NovaServicoComando(string Numero, string Volume, decimal Preco) : IRequest<NotificationResult>;

    public class NovoServicoHandler : IRequestHandler<NovaServicoComando, NotificationResult>
    {
        private readonly IServicos _servicos;
        private readonly IMediator _mediator;
        private readonly ILogger<NovoServicoHandler> _logger;


        public NovoServicoHandler(IServicos servicos, IMediator mediator, ILogger<NovoServicoHandler> logger)
        {
            _servicos = servicos;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<NotificationResult> Handle(NovaServicoComando request, CancellationToken cancellationToken)
        {
            IntIncluir intIncluir = new(request.Numero);
            Cabecalho cabecalho = new(request.Numero, request.Volume);
            OmieCriarServicoRequest criarServico = new(intIncluir, cabecalho);
            var omieResponse = await _mediator.Send(criarServico);
            if (!omieResponse.Success)
            {
                _logger.LogError(@"
            **********NovaCacamba: ocorreu um erro na requisicao para a Omie. Erro: {0}**********", new { omieResponse.Object });
                return omieResponse;
            }
            var result = omieResponse.ServicoResult.nCodServ;


            return omieResponse;
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using omie_api_integration.Shared;
using omie_poc.Omie.Compartilhado;

namespace omie_poc.Omie.Servico
{
    public record OmieCriarServicoRequest(IntIncluir intIncluir, Cabecalho cabecalho) : IRequest<NotificationResult>;
    public record IntIncluir(string cCodIntServ);
    public record Cabecalho(string cCodigo, string cDescricao);

    public class OmieCriarServicoHandler : IRequestHandler<OmieCriarServicoRequest, NotificationResult>
    {
        private readonly IServicos _servicos;

        public OmieCriarServicoHandler(IServicos servicos)
        {
            _servicos = servicos;
        }

        public async Task<NotificationResult> Handle(OmieCriarServicoRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
                return new NotificationResult().Failure().ShowMessage("Request não pode ser nulo");
            var body = new OmieRequest(
                call: "IncluirCadastroServico",
                app_key: "2805912860751",
                app_secret: "2232cf7c1b91c4573417b9e630d3f470",
                new() { request });

            var result = await _servicos.CriarServico(body);
            return result;
        }
    }

}
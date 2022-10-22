using System.Threading;
using System.Threading.Tasks;
using MediatR;
using omie_api_integration.Shared;
using omie_poc.Omie.Compartilhado;

namespace omie_poc.Omie.Servico
{
    public record OmieCriarServicoRequest(IntIncluir intIncluir, Cabecalho cabecalho) : IRequest<Result>;
    public record IntIncluir(string cCodIntServ);
    public record Cabecalho(string cCodigo, string cDescricao);

    public class OmieCriarServicoHandler : IRequestHandler<OmieCriarServicoRequest, Result>
    {
        private readonly IOmieServico _servicos;

        public OmieCriarServicoHandler(IOmieServico servicos)
        {
            _servicos = servicos;
        }

        public async Task<Result> Handle(OmieCriarServicoRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
                return new Result("Request não pode ser nulo", false);
            var body = new OmieRequest(
                call: "IncluirCadastroServico",
                app_key: "2894892105105",
                app_secret: "176b83636bb6e913bb3790862b46b7e2",
                new() { request });

            var result = await _servicos.CriarServico(body);
            return result;
        }
    }

}
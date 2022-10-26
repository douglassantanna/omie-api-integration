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
                app_key: "2916619416711",
                app_secret: "04a73d6809eb4d8f7ef57eca63db7455",
                new() { request });

            var result = await _servicos.CriarServico(body);
            return result;
        }
    }

}
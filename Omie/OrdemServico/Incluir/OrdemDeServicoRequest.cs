using System.Collections.Generic;
using omie_poc.Omie.OrdemServico.Domain;

namespace omie_poc.Omie.OrdemServico.Incluir
{
    public class OrdemDeServicoRequest
    {
        public string call { get; set; }
        public string app_key { get; set; }
        public string app_secret { get; set; }
        public List<IncluirOSParam> param { get; set; }
    }
    public class IncluirOSParam
    {
        public Cabecalho Cabecalho { get; set; }
        public Email Email { get; set; }
        public InformacaoAdicional InformacoesAdicionais { get; set; }
        public List<ServicosPrestados> ServicosPrestados { get; set; }
        public List<Departamento> Departamentos { get; set; }
    }
}
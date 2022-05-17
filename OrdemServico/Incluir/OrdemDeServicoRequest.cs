using System.Collections.Generic;

namespace omie_poc.OrdemServico.Incluir
{
    public class OrdemDeServicoRequest
    {
        public string call { get; set; }
        public long app_key { get; set; }
        public string app_secret { get; set; }
        public List<Param> param { get; set; }
    }
    public class Param
    {
        public Cabecalho Cabecalho { get; set; }
        public Email Email { get; set; }
        public InformacoesAdicionais InformacoesAdicionais { get; set; }
        public Impostos Impostos { get; set; }
        public List<ServicosPrestados> ServicosPrestados { get; set; }
        public List<Departamento> Departamento { get; set; }
    }
}
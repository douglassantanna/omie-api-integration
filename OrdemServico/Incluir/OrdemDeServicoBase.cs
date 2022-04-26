using System.Collections.Generic;
using omie_poc.OrdemServico;

namespace omie_poc
{
    public class OrdemDeServicoBase
    {
        public Cabecalho Cabecalho { get; set; }
        public Email Email { get; set; }
        public InformacoesAdicionais InformacoesAdicionais { get; set; }
        public Impostos Impostos { get; set; }
        public List<ServicosPrestados> ServicosPrestados { get; set; }
        public List<Departamento> Departamento { get; set; }
    }
}
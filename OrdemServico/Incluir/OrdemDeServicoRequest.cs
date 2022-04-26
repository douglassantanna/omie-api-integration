using System.Collections.Generic;

namespace omie_poc.OrdemServico.Incluir
{
    public class OrdemDeServicoRequest
    {
        public long App_key { get; set; }
        public string App_secret { get; set; }
        public string Call { get; set; }
        public List<OrdemDeServicoBase> Param { get; set; }

    }
}
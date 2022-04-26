using Newtonsoft.Json;

namespace omie_poc.OrdemServico
{
    public class InformacoesAdicionais
    {
        [JsonProperty("cCidPrestServ")]
        public string CidPrestServ { get; set; }


        [JsonProperty("cCodCateg")]
        public string CodCategoria { get; set; }


        [JsonProperty("cDadosAdicNF")]
        public string DadosAdicNF { get; set; }


        [JsonProperty("nCodCC")]
        public int CodigoCC { get; set; }
    }
}
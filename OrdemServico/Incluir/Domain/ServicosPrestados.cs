using Newtonsoft.Json;

namespace omie_poc.OrdemServico
{
    public class ServicosPrestados
    {
        [JsonProperty("cCodServLC116")]
        public string CodigoServicoLC116 { get; set; }


        [JsonProperty("cCodServMun")]
        public string CodigoServicoMun { get; set; }


        [JsonProperty("cDadosAdicItem")]
        public string CodigoDadosAdicItem { get; set; }


        [JsonProperty("cDescServ")]
        public string CodigoDescricaoServico { get; set; }


        [JsonProperty("cRetemISS")]
        public string cRetemISS { get; set; }


        [JsonProperty("cTribServ")]
        public string CodigoTribServ { get; set; }


        [JsonProperty("nQtde")]
        public int Quantidade { get; set; }


        [JsonProperty("nValUnit")]
        public int ValorUnitario { get; set; }



        [JsonProperty("nCodServico")]
        public int? CodigoServico { get; set; }
        
        public Impostos impostos { get; set; }
    }
}
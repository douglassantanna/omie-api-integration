using Newtonsoft.Json;

namespace omie_poc.OrdemServico
{
    public class Cabecalho
    {
        [JsonProperty("nCodOS")]
        public string CodigoOS { get; set; }


        [JsonProperty("cCodParc")]
        public string CodigoParc { get; set; }


        [JsonProperty("cEtapa")]
        public string CodigoEtapa { get; set; }


        [JsonProperty("dDtPrevisao")]
        public string DataPrevisao { get; set; }


        [JsonProperty("nCodCli")]
        public int CodigoCliente { get; set; }


        [JsonProperty("nQtdeParc")]
        public int QuantidadeParc { get; set; }

    }
}
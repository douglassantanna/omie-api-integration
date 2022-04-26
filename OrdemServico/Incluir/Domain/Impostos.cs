using Newtonsoft.Json;

namespace omie_poc.OrdemServico
{
    public class Impostos
    {
        [JsonProperty("cRetemIRRF")]
        public string cRetemIRRF { get; set; }

        [JsonProperty("cRetemPIS")]
        public string cRetemPIS { get; set; }


        [JsonProperty("nAliqCOFINS")]
        public int AliquotaCOFINS { get; set; }


        [JsonProperty("nAliqCSLL")]
        public int AliquotaCSLL { get; set; }


        [JsonProperty("nAliqIRRF")]
        public int AliquotaIRRF { get; set; }


        [JsonProperty("nAliqISS")]
        public int AliquotaISS { get; set; }


        [JsonProperty("nAliqPIS")]
        public double AliquotaPIS { get; set; }
    }
}
using Newtonsoft.Json;

namespace omie_poc.OrdemServico.Incluir
{
    public class OrdemDeServicoRequest
    {
        [JsonProperty("app_key")]
        public string AppKey { get; set; }

        [JsonProperty("app_secret")]
        public string AppSecret { get; set; }

        [JsonProperty("call")]
        public string Call { get; set; }

        [JsonProperty("param")]
        public OrdemDeServicoBase Param { get; set; }
        
    }
}
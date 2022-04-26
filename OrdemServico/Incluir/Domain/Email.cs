using Newtonsoft.Json;

namespace omie_poc.OrdemServico
{
    public class Email
    {
        [JsonProperty("cEnvBoleto")]
        public string EnvioBoleto { get; set; }


        [JsonProperty("cEnvLink")]
        public string EnviarLink { get; set; }


        [JsonProperty("cEnviarPara")]
        public string EnviarPara { get; set; }
    }
}
using Newtonsoft.Json;

namespace omie_poc.OrdemServico
{
    public class Departamento
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }
    }
}
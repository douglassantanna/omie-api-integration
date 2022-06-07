using System.Collections.Generic;

namespace omie_api_integration.Omie.OrdemServico.Validar
{
    public class ValidarOSRequest
    {

        public string call { get; set; }
        public string app_key { get; set; }
        public string app_secret { get; set; }
        public List<ValidarOSParam> param { get; set; }
    }
    public class ValidarOSParam
    {
        public string cCodIntOS { get; set; }
        public int nCodOS { get; set; }
    }
}
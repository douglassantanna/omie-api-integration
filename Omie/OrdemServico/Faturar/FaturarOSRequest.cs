using System.Collections.Generic;

namespace omie_api_integration.Omie.OrdemServico.Faturar
{
    public class FaturarOSRequest
    {

        public string call { get; set; }
        public string app_key { get; set; }
        public string app_secret { get; set; }
        public List<FaturarOSParam> param { get; set; }
    }
    public class FaturarOSParam
    {
        public string cCodIntOS { get; set; }
        public double nCodOS { get; set; }
    }
}
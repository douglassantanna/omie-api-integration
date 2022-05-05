using System.Collections.Generic;

namespace omie_poc.Conta
{
    public class ContaRequest
    {
        public ContaRequest(string call, string app_key, string app_secret, List<Param> param)
        {
            this.call = call;
            this.app_key = app_key;
            this.app_secret = app_secret;
            this.param = param;
        }

        public string call { get; set; }
        public string app_key { get; set; }
        public string app_secret { get; set; }
        public List<Param> param { get; set; }

    }
    public class Param
    {
        public string cCodInt { get; set; }
    }
}
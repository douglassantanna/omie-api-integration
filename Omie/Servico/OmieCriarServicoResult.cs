namespace omie_poc.Omie.Servico
{
    public class OmieCriarServicoResult
    {
        public string cCodIntServ { get; set; }
        public long nCodServ { get; set; }
        public string cCodStatus { get; set; }
        public string cDescStatus { get; set; }
        public OmieErrorResult Erro { get; set; }

        public OmieCriarServicoResult(OmieErrorResult erro)
        {
            Erro = erro;
        }

    }

    public class OmieErrorResult
    {
        public OmieErrorResult(string faultstring, string faultcode)
        {
            this.faultstring = faultstring;
            this.faultcode = faultcode;
        }

        public string faultstring { get; private set; }
        public string faultcode { get; private set; }
    }
}
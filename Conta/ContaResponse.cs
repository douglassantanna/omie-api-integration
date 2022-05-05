using System.Collections.Generic;

namespace omie_poc.Conta
{

    public class ContaResponse
    {
        public Identificacao identificacao { get; set; }
        public Endereco endereco { get; set; }
        public TelefoneEmail telefone_email { get; set; }
        public InformacoesAdicionais informacoesAdicionais { get; set; }
        public List<object> tags { get; set; }
        public List<object> caracteristicas { get; set; }
    }
    public record Identificacao(string cCodInt, string cDoc, string cNome, string cObs, string dDtReg, string dDtValid, int nCod, int nCodTelemkt, int nCodVend, int nCodVert);
    public record Endereco(string cBairro, string cCEP, string cCidade, string cCompl, string cEndereco, string cPais, string cUF);
    public record TelefoneEmail(string cDDDFax, string cDDDTel, string cEmail, string cNumFax, string cNumTel, string cWebsite);
    public record InformacoesAdicionais(string cCnae, string cRegTrib, string nFaixaFat, int nNumFunc);
    public record Tags(List<object> tags);
    public record Caracteristicas(List<object> caracteristicas);
}
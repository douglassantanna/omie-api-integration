using System.Collections.Generic;
using omie_poc.Conta;
using omie_poc.OrdemServico.Domain;

namespace omie_api_integration.OrdemServico.Listar
{
    public class ListarOSResponse
    {
        public int pagina { get; set; }
        public string total_de_paginas { get; set; }
        public string registros { get; set; }
        public string total_de_registros { get; set; }
        public List<OsCadastro> osCadastro { get; set; }
    }
    public class OsCadastro
    {
        public Cabecalho Cabecalho { get; set; }
        public Email Email { get; set; }
        public InformacaoAdicional InformacoesAdicionais { get; set; }
        public List<ServicosPrestados> ServicosPrestados { get; set; }
        public List<Departamento> Departamentos { get; set; }
    }
}
using System.Collections.Generic;

namespace omie_api_integration.Omie.OrdemServico.Listar
{
    public class ListarOSRequest
    {
        public string call { get; set; }
        public string app_key { get; set; }
        public string app_secret { get; set; }
        public List<ListarOSParam> param { get; set; }
    }
    public class ListarOSParam
    {
        public int pagina { get; set; }
        public int registros_por_pagina { get; set; }
        public string apenas_importado_api { get; set; }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using omie_poc.OrdemServico.Incluir;

namespace omie_poc.Controllers
{
    public class OmieController
    {
        private OrdemDeServico _ordemDeServico;

        public OmieController(OrdemDeServico ordemDeServico)
        {
            _ordemDeServico = ordemDeServico;
        }

        [Route("api/[controller]")]
        [ApiController]
        public class NameController : ControllerBase
        {
            
            // [HttpPost]
            // public async Task PostAsync()
            // {
            //     var ordemServico = _ordemDeServico.Get();
            //     return Ok();
            // }
        }
    }
}
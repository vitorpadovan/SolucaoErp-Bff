using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegistroDePreco.Business.Interfaces;
using SolucaoErpDomain.Controllers.Requests.Pdv;

namespace RegistroDePreco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PdvController : ControllerBase
    {
        private readonly IPdvBusiness _pdvBusiness;

        public PdvController(IPdvBusiness pdvBusiness)
        {
            _pdvBusiness = pdvBusiness;
        }

        [HttpPost]
        [Authorize]
        public IActionResult SalvarPdv(CadastroPdvRequest request)
        {
            return Ok(_pdvBusiness.SalvarPdv(request));
        }

        public IActionResult ListarPdvs()
        {
            return Ok();
        }
    }
}

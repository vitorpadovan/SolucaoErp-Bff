using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegistroDePreco.Business.Interfaces;
using SolucaoErpDomain.Controllers.Requests.RegistroPreco;

namespace RegistroDePreco.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistroPrecoController : ControllerBase
    {
        private readonly IRegistroPrecoBusiness _registroPrecoBusiness;

        public RegistroPrecoController(IRegistroPrecoBusiness registroPrecoBusiness)
        {
            _registroPrecoBusiness = registroPrecoBusiness;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Index(RegistrarPrecoRequest request)
        {
            _registroPrecoBusiness.RegistrarPreco(request);
            return Ok(request);
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegistroDePreco.Business.Interfaces;
using SolucaoErpDomain.Controllers.Requests.Produto;

namespace RegistroDePreco.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoBusiness _business;

        public ProdutoController(IProdutoBusiness business)
        {
            _business = business;
        }

        [HttpPost]
        [Authorize]
        public IActionResult SalvarProduto(SalvarProdutoRequest request)
        {
            return Ok(this._business.SalvarProduto(request));
        }
    }
}

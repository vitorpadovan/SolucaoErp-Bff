using Microsoft.AspNetCore.Mvc;

namespace ProdutoService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public bool Teste() { return true; }
    }
}

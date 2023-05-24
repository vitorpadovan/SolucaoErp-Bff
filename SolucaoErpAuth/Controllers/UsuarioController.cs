using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolucaoErpAuth.Data.Dtos;
using SolucaoErpAuth.Services;

namespace SolucaoErpAuth.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;
        private IHttpContextAccessor httpContextAccessor ;

        public UsuarioController(UsuarioService cadastroService, IHttpContextAccessor httpContextAccessor)
        {
            _usuarioService = cadastroService;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("teste")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public string teste()
        {
            var claim = httpContextAccessor.HttpContext.User.Claims;
            return "asd";
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
        {
            await _usuarioService.CadastraUsuario(dto);
            return Ok("Usuário cadastrado!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUsuarioDto dto)
        {
            var token = await _usuarioService.Login(dto);
            return Ok(token);
        }
    }
}

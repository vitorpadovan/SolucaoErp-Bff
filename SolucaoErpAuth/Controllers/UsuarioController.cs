using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolucaoErpAuth.Data.Dtos;
using SolucaoErpAuth.Services;
using SolucaoErpDomain.GlobalServices.Interfaces;

namespace SolucaoErpAuth.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;
        private IHttpContextAccessor httpContextAccessor;
        private IGlobalApplicationService teste222;


        public UsuarioController(UsuarioService cadastroService, IHttpContextAccessor httpContextAccessor, IGlobalApplicationService teste)
        {
            _usuarioService = cadastroService;
            this.httpContextAccessor = httpContextAccessor;
            this.teste222 = teste;
        }

        [HttpGet("username")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public string GetUsername()
        {
            try
            {
                var claim = httpContextAccessor.HttpContext.User.Claims;
                var userName = claim.FirstOrDefault(c => c.Type == "username");
                return userName.Value;
            }
            catch (Exception)
            {
                return "";
            }
        }

        [HttpGet("session")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public string GetSession()
        {
            return "asdasd";
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

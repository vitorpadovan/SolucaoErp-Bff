using Microsoft.AspNetCore.Http;
using SolucaoErpDomain.Configurations;
using System.Security.Claims;

namespace SolucaoErpDomain.Auth.Context
{
    public class AuthContext : IAuthContext, ITransientDependecy<IAuthContext, AuthContext>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetUsuario()
        {
            var t = Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(k => k.Type == ClaimTypes.Sid).Value);
            return t;
        }
    }
}

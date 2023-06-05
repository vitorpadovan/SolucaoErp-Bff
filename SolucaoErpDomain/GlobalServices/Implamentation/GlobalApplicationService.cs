using Microsoft.AspNetCore.Http;
using SolucaoErpDomain.Configurations;
using SolucaoErpDomain.GlobalServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SolucaoErpDomain.GlobalServices.Implamentation
{
    public class GlobalApplicationService : IGlobalApplicationService, IScopedDependecy<IGlobalApplicationService, GlobalApplicationService>
    {
        public string Teste(IHttpContextAccessor httpContextAccessor)
        {
            try
            {
                var claim = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid);
            }catch (Exception ex)
            {

            }
            return "";
        }
    }
}

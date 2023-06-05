using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucaoErpDomain.GlobalServices.Interfaces
{
    public interface IGlobalApplicationService
    {
        public String Teste(IHttpContextAccessor httpContextAccessor);
    }
}

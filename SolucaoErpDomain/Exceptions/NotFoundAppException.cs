using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucaoErpDomain.Exceptions
{
    public class NotFoundAppException : GenericAppException
    {
        public NotFoundAppException(string message) : base(message)
        {
        }
    }
}

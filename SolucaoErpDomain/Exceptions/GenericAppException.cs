using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucaoErpDomain.Exceptions
{
    public class GenericAppException : Exception
    {
        public GenericAppException(string? message) : base(message)
        {
        }
    }
}

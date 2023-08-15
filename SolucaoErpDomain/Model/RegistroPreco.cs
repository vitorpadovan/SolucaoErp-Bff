using SolucaoErpDomain.Controllers.Requests.RegistroPreco;
using SolucaoErpDomain.Model;

namespace RegistroDePreco.Model
{
    public class RegistroPreco
    {
        public Guid codRegistro { get; set; }
        public Produto produto { get; set; }
        public decimal price { get; set; }
        public Pdv pdv { get; set; }

        public static implicit operator RegistroPreco(RegistrarPrecoRequest registrarPrecoRequest)
        {
            return new RegistroPreco()
            {
                //barCode = registrarPrecoRequest.codBarras.Value,
                produto = new Produto() { CodigoBarras = registrarPrecoRequest.codBarras.ToString() },
                price = registrarPrecoRequest.valor.Value,
                pdv = new Pdv() { Id = registrarPrecoRequest.codLocal.Value }
            };
        }
    }
}

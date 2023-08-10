using SolucaoErpDomain.Controllers.Requests.RegistroPreco;

namespace RegistroDePreco.Model
{
    public class RegistroPreco
    {
        public int codRegistro { get; set; }
        public long barCode { get; set; }
        public decimal price { get; set; }

        public static implicit operator RegistroPreco(RegistrarPrecoRequest registrarPrecoRequest)
        {
            return new RegistroPreco()
            {
                barCode = registrarPrecoRequest.codBarras,
                price = registrarPrecoRequest.valor
            };
        }
    }
}

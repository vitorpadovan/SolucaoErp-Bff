using SolucaoErpDomain.Controllers.Requests.Pdv;

namespace SolucaoErpDomain.Model
{
    public class Pdv
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public static implicit operator Pdv(CadastroPdvRequest request)
        {
            return new Pdv()
            {
                Nome = request.nome
            };
        }
    }
}

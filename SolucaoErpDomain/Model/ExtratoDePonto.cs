using SolucaoErpDomain.Model.Enuns;

namespace SolucaoErpDomain.Model
{
    public class ExtratoDePonto
    {
        public Guid Id { get; set; }
        public Guid Usuario { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public int Pontos { get; set; } = 0;
        public String DescricaoEvento { get; set; }
        public TipoExtrato TipoExtrato { get; set; }

    }
}

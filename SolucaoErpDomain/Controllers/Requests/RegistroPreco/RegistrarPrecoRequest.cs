namespace SolucaoErpDomain.Controllers.Requests.RegistroPreco
{
    public class RegistrarPrecoRequest
    {
        public long codBarras { get; set; }
        public decimal valor { get; set; }
        public GeoCoordenadaRequest geoCoordenadaRequest { get; set; }
    }
}

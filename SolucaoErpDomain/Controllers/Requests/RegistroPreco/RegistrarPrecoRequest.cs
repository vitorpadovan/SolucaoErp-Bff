using System.ComponentModel.DataAnnotations;

namespace SolucaoErpDomain.Controllers.Requests.RegistroPreco
{
    public class RegistrarPrecoRequest
    {
        [Required]
        public long? codBarras { get; set; }
        [Required]
        [Range(0.01, Double.MaxValue)]
        public decimal? valor { get; set; }
        [Required]
        public GeoCoordenadaRequest? geoCoordenadaRequest { get; set; }
        [Required]
        public int? codLocal { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace SolucaoErpDomain.Controllers.Requests.Produto
{
    public class SalvarProdutoRequest
    {
        [Required(ErrorMessage = "Nome do produto é obrigatório")]
        public string? Nome { get; set; }

        public string CodBarras { get; set; }

        [Required(ErrorMessage = "Descrição do produto é obrigatório")]
        public string? Descricao { get; set; }
    }
}

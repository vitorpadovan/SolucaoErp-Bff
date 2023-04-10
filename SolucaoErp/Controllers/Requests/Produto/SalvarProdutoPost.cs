using System.ComponentModel.DataAnnotations;

namespace SolucaoErp.Controllers.Requests.Produto;
public class SalvarProdutoPost
{
    [Required(ErrorMessage = "Necessário informar o nome do produto")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Necessário informar a categoria do produto")]
    public int? Categoria { get; set; }
}
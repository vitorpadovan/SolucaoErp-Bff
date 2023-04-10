using System.ComponentModel.DataAnnotations;

namespace SolucaoErp.Controllers.Requests.Categoria
{
    public class SalvarCategoriaPost
    {
        [Required(ErrorMessage = "Necessário informar o nome da categoria a ser cadastrada")]
        public string Nome { get; set; }
    }
}

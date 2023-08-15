using SolucaoErpDomain.Controllers.Requests.Produto;

namespace SolucaoErpDomain.Model;
public class Produto
{
    public int Id { get; set; }
    public Guid codEvento { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public Categoria? Categoria { get; set; }
    public string? CodigoBarras { get; set; }

    public static implicit operator Produto(SalvarProdutoRequest request)
    {
        return new Produto()
        {
            Nome = request.Nome,
            CodigoBarras = request.CodBarras,
            Descricao = request.Descricao
        };
    }

}
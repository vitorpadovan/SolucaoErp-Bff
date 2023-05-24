using SolucaoErpDomain.Model;

namespace SolucaoErp.Repository.Interfaces;
public interface IProdutoRepository
{
    public IEnumerable<Produto> GetAll();
    public Produto SalveProduto(Produto p);
    public Produto BuscaPorId(int id);
    public Produto BuscarPorCodBarras(string id);
    public Produto BuscaPorNome(string nome);
    public IEnumerable<Produto> GetProdutosPorCategoria(int cod);
    public bool DeleteProduto(Produto produto);
    public bool AtualizarProduto(Produto produto);
}

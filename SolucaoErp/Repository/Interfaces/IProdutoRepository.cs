using SolucaoErp.Model;

namespace SolucaoErp.Repository.Interfaces;
public interface IProdutoRepository
{
    public IEnumerable<Produto> GetAll();
    public Produto SalveProduto(Produto p);
    public Produto BuscaPorId(int id);
    public Produto BuscaPorNome(string nome);
    public bool DeleteProduto(Produto produto);
}

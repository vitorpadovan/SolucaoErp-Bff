using SolucaoErp.Controllers.Requests.Produto;
using SolucaoErp.Model;

namespace SolucaoErp.Business.Interfaces;
public interface IProdutoBusiness
{
    public IEnumerable<Produto> GetProdutos();
    public Produto SalvarProduto(SalvarProdutoPost p);
    public bool DeleteProduto(int id);
    public bool AtualizaProduto(SalvarProdutoPost produto, int id);
    public Produto GetProduto(int id);
}
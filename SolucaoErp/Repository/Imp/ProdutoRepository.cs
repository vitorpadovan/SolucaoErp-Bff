using Microsoft.EntityFrameworkCore;
using SolucaoErp.Model;
using SolucaoErp.Repository.Interfaces;

namespace SolucaoErp.Repository.Imp;
public class ProdutoRepository : IProdutoRepository
{

    private readonly RepositoryContext _repositoryContext;
    private readonly DbSet<Produto> _produtos;

    public ProdutoRepository(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _produtos = repositoryContext.Produto;
    }

    public Produto BuscaPorId(int id) => _produtos.Where(p => p.Id == id).FirstOrDefault();

    public Produto BuscaPorNome(string nome) => _produtos.Where(p => p.Nome == nome).FirstOrDefault();

    public bool DeleteProduto(Produto produto)
    {
        _produtos.Remove(produto);
        _repositoryContext.SaveChanges();
        return true;
    }

    public IEnumerable<Produto> GetAll()
    {
        return _produtos.Include(p=>p.Categoria);
    }

    public Produto SalveProduto(Produto p)
    {
        var r = _produtos.Add(p);
        _repositoryContext.SaveChanges();
        return p;
    }
}

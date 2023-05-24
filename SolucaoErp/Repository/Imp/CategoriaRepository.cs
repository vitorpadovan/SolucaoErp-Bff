using Microsoft.EntityFrameworkCore;
using SolucaoErpDomain.Model;
using SolucaoErp.Repository.Interfaces;
using SolucaoErpDomain.Configurations;

namespace SolucaoErp.Repository.Imp;
public class CategoriaRepository : ICategoriaRepository, IScopedDependecy<ICategoriaRepository, CategoriaRepository>
{
    private readonly RepositoryContext _repositoryContext;
    private readonly DbSet<Categoria> _categoria;

    public CategoriaRepository(RepositoryContext repositoryContext){
        _repositoryContext = repositoryContext;
        _categoria = repositoryContext.Categoria;
    }

    public bool AtualizarCategoria(Categoria categoria, int id)
    {
        _categoria.Update(categoria);
        _repositoryContext.SaveChanges();
        return true;
    }

    public Categoria BuscaPorId(int id) => _categoria.Where(p => p.Id == id).FirstOrDefault();
    public Categoria BuscaPorNome(string nome) => _categoria.Where(p => p.Nome== nome).FirstOrDefault();

    public bool DeletarCategoria(Categoria categoria)
    {
        _categoria.Remove(categoria);
        _repositoryContext.SaveChanges();
        return true;
    }

    public IEnumerable<Categoria> GetCategorias(){
        return _categoria.OrderBy(s=>s.Nome);
    }

    public Categoria Salvar(Categoria cat){
        _categoria.Add(cat);
        _repositoryContext.SaveChanges();
        return cat;
    }
}
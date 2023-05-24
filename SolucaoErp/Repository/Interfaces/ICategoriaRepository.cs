using SolucaoErpDomain.Model;

namespace SolucaoErp.Repository.Interfaces;
public interface ICategoriaRepository
{
    public Categoria Salvar(Categoria cat);
    public Categoria BuscaPorId(int id);
    public Categoria BuscaPorNome(string nome);
    public IEnumerable<Categoria> GetCategorias();
    public bool DeletarCategoria(Categoria categoria);
    public bool AtualizarCategoria(Categoria categoria, int id);
}
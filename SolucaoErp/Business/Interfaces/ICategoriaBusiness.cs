using SolucaoErp.Controllers.Requests.Categoria;
using SolucaoErp.Model;

namespace SolucaoErp.Business.Interfaces;
public interface ICategoriaBusiness
{
    public Categoria Salvar(SalvarCategoriaPost categoria);
    public IEnumerable<Categoria> GetCategorias();
    public bool DeletarCategoria(int id);
    public Categoria GetCategoria(int id);
    public bool AtualizarCategoria(Categoria categoria, int id);
}
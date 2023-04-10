using SolucaoErp.Business.Interfaces;
using SolucaoErp.Configuration.ErrorsApi;
using SolucaoErp.Controllers.Requests.Categoria;
using SolucaoErp.Model;
using SolucaoErp.Repository.Interfaces;

namespace SolucaoErp.Business.Imp;
public class CategoriaBusiness : ICategoriaBusiness
{
    private readonly ICategoriaRepository _categoriaRepository;
    public CategoriaBusiness(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public bool AtualizarCategoria(Categoria categoria, int id)
    {
        var banco = this._categoriaRepository.BuscaPorId(id);
        if (banco == null)
            throw new ApiException($@"Categoria com o código {id} não existe no banco ou já foi deletada");
        var outraCategoria = this._categoriaRepository.BuscaPorNome(categoria.Nome);
        if (outraCategoria != null)
            if (outraCategoria.Id != id)
                throw new ApiException($@"Categoria com o código {outraCategoria.Id} já possui o nome que você está querendo aplicar para a categoria {id}");
        if (categoria.Id != null && categoria.Id != id)
            throw new ApiException("Id da categoria enviada é diferente da categoria a ser alterada");
        _categoriaRepository.Salvar(categoria);
        return true;
    }

    public bool DeletarCategoria(int id)
    {
        var categoria = this._categoriaRepository.BuscaPorId(id);
        if (categoria == null)
            throw new ApiException($@"Categoria com o código {id} não existe no banco ou já foi deletada");
        //TODO implementar a negação de deleção de categorias já associadas
        return this._categoriaRepository.DeletarCategoria(categoria);
    }

    public IEnumerable<Categoria> GetCategorias()
    {
        return _categoriaRepository.GetCategorias();
    }

    public Categoria Salvar(SalvarCategoriaPost categoria)
    {
        var banco = _categoriaRepository.BuscaPorNome(categoria.Nome);
        if (banco != null)
            throw new ApiException("Categoria já existe");
        var cat = new Categoria()
        {
            Nome = categoria.Nome,
        };
        return _categoriaRepository.Salvar(cat);
    }
}
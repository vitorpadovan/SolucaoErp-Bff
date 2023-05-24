using SolucaoErp.Business.Interfaces;
using SolucaoErp.Configuration.ErrorsApi;
using SolucaoErp.Controllers.Requests.Categoria;
using SolucaoErpDomain.Model;
using SolucaoErp.Repository.Interfaces;
using SolucaoErpDomain.Configurations;

namespace SolucaoErp.Business.Imp;
public class CategoriaBusiness : ICategoriaBusiness, IScopedDependecy<ICategoriaBusiness, CategoriaBusiness>
{
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IProdutoRepository _produtoRepository;
    public CategoriaBusiness(ICategoriaRepository categoriaRepository, IProdutoRepository produtoRepository)
    {
        _categoriaRepository = categoriaRepository;
        _produtoRepository = produtoRepository;
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
        banco.Nome = categoria.Nome;
        _categoriaRepository.AtualizarCategoria(banco, id);
        return true;
    }

    public bool DeletarCategoria(int id)
    {
        var categoria = this._categoriaRepository.BuscaPorId(id);
        if (categoria == null)
            throw new ApiException($@"Categoria com o código {id} não existe no banco ou já foi deletada");
        var produtosAssociados = this._produtoRepository.GetProdutosPorCategoria(id);
        if(produtosAssociados != null && produtosAssociados.Count() > 0)
            throw new ApiException($@"Categoria com o código {id} possui {produtosAssociados.Count()} produtos associados e não pode ser deletado");
        return this._categoriaRepository.DeletarCategoria(categoria);
    }

    public Categoria GetCategoria(int id)
    {
        return _categoriaRepository.BuscaPorId(id);
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
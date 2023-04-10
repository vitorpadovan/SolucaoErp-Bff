using SolucaoErp.Business.Interfaces;
using SolucaoErp.Configuration.ErrorsApi;
using SolucaoErp.Controllers.Requests.Produto;
using SolucaoErp.Model;
using SolucaoErp.Repository.Interfaces;

namespace SolucaoErp.Business.Imp;
public class ProdutoBusiness : IProdutoBusiness
{

    private readonly IProdutoRepository _produtoRepository;
    private readonly ICategoriaRepository _categoriaRepository;

    public ProdutoBusiness(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
    {
        _produtoRepository = produtoRepository;
        _categoriaRepository = categoriaRepository;
    }

    public bool DeleteProduto(int id)
    {
        var produto = _produtoRepository.BuscaPorId(id);
        if(produto == null)
            throw new ApiException("Produto não existe na base de dados ou já foi deletado");
        _produtoRepository.DeleteProduto(produto);
        return true;
    }

    public IEnumerable<Produto> GetProdutos()
    {
        return _produtoRepository.GetAll();

    }

    public Produto SalvarProduto(SalvarProdutoPost p)
    {
        var banco = _produtoRepository.BuscaPorNome(p.Nome);
        if (banco != null)
            throw new ApiException("Produto já existe na base");
        var categoria = _categoriaRepository.BuscaPorId(p.Categoria.Value);
        if(categoria == null)
            throw new ApiException("Não foi encontrada categoria para o produto");
        var resultado = new Produto()
        {
            Nome = p.Nome,
            Descricao = p.Nome,
            Categoria = categoria,
        };
        _produtoRepository.SalveProduto(resultado);
        return resultado;
    }
}
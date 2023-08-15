using SolucaoErp.Business.Interfaces;
using SolucaoErp.Controllers.Requests.Produto;
using SolucaoErp.Repository.Interfaces;
using SolucaoErpDomain.Configuration.ErrorsApi;
using SolucaoErpDomain.Configurations;
using SolucaoErpDomain.Exceptions;
using SolucaoErpDomain.Model;

namespace SolucaoErp.Business.Imp;
public class ProdutoBusiness : IProdutoBusiness, IScopedDependecy<IProdutoBusiness, ProdutoBusiness>
{

    private readonly IProdutoRepository _produtoRepository;
    private readonly ICategoriaRepository _categoriaRepository;

    public ProdutoBusiness(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
    {
        _produtoRepository = produtoRepository;
        _categoriaRepository = categoriaRepository;
    }

    public bool AtualizaProduto(SalvarProdutoPost produto, int id)
    {
        var banco = _produtoRepository.BuscaPorId(id);
        if (banco == null)
            throw new ApiException("Produto não encontrado no banco para ser atualizado");
        var outroProduto = _produtoRepository.BuscaPorNome(produto.Nome);
        if (outroProduto != null && outroProduto.Id != id)
            throw new ApiException("Existe outro produto com este mesmo nome");
        var categoriaSelecionada = _categoriaRepository.BuscaPorId(produto.Categoria.Value);
        banco.Nome = produto.Nome;
        banco.Categoria = categoriaSelecionada;
        _produtoRepository.AtualizarProduto(banco);
        return true;
    }

    public bool DeleteProduto(int id)
    {
        var produto = _produtoRepository.BuscaPorId(id);
        if (produto == null)
            throw new NotFoundException("Produto não existe na base de dados ou já foi deletado");
        _produtoRepository.DeleteProduto(produto);
        return true;
    }

    public Produto GetProduto(int id)
    {
        var produto = _produtoRepository.BuscaPorId(id);
        if (produto == null)
            throw new NotFoundException("Produto não existe");
        return produto;
    }

    public Produto GetProdutoPorCodBarras(string id)
    {
        return this.GetProdutoPorCodBarras(id, false);
    }

    public Produto GetProdutoPorCodBarras(string id, bool forcarPesquisa)
    {
        var produto = _produtoRepository.BuscarPorCodBarras(id);
        if (produto != null)
            return produto;
        if (forcarPesquisa)
            EnviarParaCosmosService(id);
        throw new NotFoundAppException("Não foi encontrado");
    }

    private void EnviarParaCosmosService(string codBarras)
    {
        //TODO implementar este cara
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
        if (categoria == null)
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
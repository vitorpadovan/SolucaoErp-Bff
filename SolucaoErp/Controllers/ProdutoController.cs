using Microsoft.AspNetCore.Mvc;
using SolucaoErp.Business.Interfaces;
using SolucaoErp.Controllers.Requests;
using SolucaoErp.Controllers.Requests.Produto;
using SolucaoErp.Model;

namespace SolucaoErp.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController
{
    private readonly IProdutoBusiness _produtoBusiness;

    public ProdutoController(IProdutoBusiness produtoBusiness)
    {
        _produtoBusiness = produtoBusiness;
    }

    [HttpGet]
    public IEnumerable<Produto> GetProdutos()
    {
        return _produtoBusiness.GetProdutos();
    }

    [HttpGet("{id}")]
    public Produto GetProduto(int id)
    {
        return _produtoBusiness.GetProduto(id);
    }

    [HttpPost]
    public Produto SalvarProduto(SalvarProdutoPost produto)
    {
        return _produtoBusiness.SalvarProduto(produto);
    }

    [HttpDelete("{id}")]
    public void DeleteProduto(int id)
    {
        _produtoBusiness.DeleteProduto(id);
    }

    [HttpPut("{id}")]
    public void AtualizaProduto(SalvarProdutoPost produto, int id)
    {
        _produtoBusiness.AtualizaProduto(produto,id);
    }
}
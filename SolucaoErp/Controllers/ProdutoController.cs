using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolucaoErp.Business.Interfaces;
using SolucaoErp.Controllers.Requests;
using SolucaoErp.Controllers.Requests.Produto;
using SolucaoErpDomain.Model;

namespace SolucaoErp.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ProdutoController
{
    private readonly IProdutoBusiness _produtoBusiness;

    public ProdutoController(IProdutoBusiness produtoBusiness)
    {
        _produtoBusiness = produtoBusiness;
    }

    [HttpGet]
    [AllowAnonymous]
    public IEnumerable<Produto> GetProdutos()
    {
        return _produtoBusiness.GetProdutos();
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public Produto GetProduto(int id)
    {
        return _produtoBusiness.GetProduto(id);
    }

    [HttpGet("barcode/{id}")]
    [AllowAnonymous]
    public Produto GetProdutoPorCodBarras(string id)
    {
        return _produtoBusiness.GetProdutoPorCodBarras(id);
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
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

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<Produto> GetProdutos()
    {
        return _produtoBusiness.GetProdutos();
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
}
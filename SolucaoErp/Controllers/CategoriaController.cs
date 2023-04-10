using Microsoft.AspNetCore.Mvc;
using SolucaoErp.Business.Interfaces;
using SolucaoErp.Controllers.Requests.Categoria;
using SolucaoErp.Model;
using SolucaoErp.Repository.Interfaces;
using System.Xml.Serialization;

namespace SolucaoErp.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaBusiness _categoriaBusiness;

    public CategoriaController(ICategoriaBusiness categoriaBusiness)
    {
        _categoriaBusiness = categoriaBusiness;
    }

    [HttpPost]
    public Categoria SalvarCategoria(SalvarCategoriaPost categoria)
    {
        return _categoriaBusiness.Salvar(categoria);
    }

    [HttpGet]
    public IEnumerable<Categoria> GetCategorias()
    {
        return _categoriaBusiness.GetCategorias();
    }
    [HttpGet("{id}")]
    public Categoria GetCategorias(int id)
    {
        return _categoriaBusiness.GetCategoria(id);
    }

    [HttpPut("{id}")]
    public Categoria AtualizarCategoria(Categoria c, int id)
    {
        _categoriaBusiness.AtualizarCategoria(c, id);
        return c;
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _categoriaBusiness.DeletarCategoria(id);
    }
}
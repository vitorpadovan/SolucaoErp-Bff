using Microsoft.AspNetCore.Mvc;
using SolucaoErp.Business.Interfaces;
using SolucaoErp.Controllers.Requests.Categoria;
using SolucaoErpDomain.Model;
using SolucaoErp.Repository.Interfaces;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SolucaoErp.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
    [AllowAnonymous]
    public IEnumerable<Categoria> GetCategorias()
    {
        return _categoriaBusiness.GetCategorias();
    }
    [HttpGet("{id}")]
    [AllowAnonymous]
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
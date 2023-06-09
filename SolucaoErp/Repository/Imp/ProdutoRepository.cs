﻿using Microsoft.EntityFrameworkCore;
using SolucaoErpDomain.Model;
using SolucaoErp.Repository.Interfaces;
using SolucaoErpDomain.Configurations;

namespace SolucaoErp.Repository.Imp;
public class ProdutoRepository : IProdutoRepository, IScopedDependecy<IProdutoRepository, ProdutoRepository>
{
    //: ICategoriaBusiness, IScopedDependecy<ICategoriaBusiness, CategoriaBusiness>

    private readonly RepositoryContext _repositoryContext;
    private readonly DbSet<Produto> _produtos;

    public ProdutoRepository(RepositoryContext repositoryContext){
        _repositoryContext = repositoryContext;
        _produtos = repositoryContext.Produto;
    }

    public bool AtualizarProduto(Produto produto){
        _produtos.Update(produto);
        _repositoryContext.SaveChanges();
        return true;
    }

    public Produto BuscaPorId(int id) => _produtos.Where(p => p.Id == id).Include(p=>p.Categoria).FirstOrDefault();

    public Produto BuscaPorNome(string nome) => _produtos.Where(p => p.Nome == nome).FirstOrDefault();

    public Produto BuscarPorCodBarras(string id) => _produtos.Where(p => p.CodigoBarras == id).FirstOrDefault();

    public bool DeleteProduto(Produto produto)
    {
        _produtos.Remove(produto);
        _repositoryContext.SaveChanges();
        return true;
    }

    public IEnumerable<Produto> GetAll()
    {
        return _produtos.Include(p=>p.Categoria);
    }

    public IEnumerable<Produto> GetProdutosPorCategoria(int cod)
    {
        return _produtos.Where(p => p.Categoria.Id == cod);
    }

    public Produto SalveProduto(Produto p)
    {
        var r = _produtos.Add(p);
        _repositoryContext.SaveChanges();
        return p;
    }
}

using RegistroDePreco.Repository.Interfaces;
using SolucaoErpDomain.Configurations;
using SolucaoErpDomain.Model;
using System.Data.Common;

namespace RegistroDePreco.Repository.Implementation
{
    public class ProdutoRepo : IProdutoRepo, ITransientDependecy<IProdutoRepo, ProdutoRepo>
    {
        private readonly RegistroPrecoContext _dbContext;
        private readonly Func<DbDataReader, Produto> _productExtract = (f) => new Produto()
        {
            Nome = "asdasd"
        };

        public ProdutoRepo(RegistroPrecoContext dbContext)
        {
            _dbContext = dbContext;
        }

        private String GetBaseSelect()
        {
            return "SELECT * FROM Produto";
        }

        public Produto GetProduto(int cod)
        {
            return this._dbContext.ExecutaOneTypedSql<Produto>(GetBaseSelect(), _productExtract);
        }

        public Produto? GetProduto(string barCode)
        {
            return _dbContext.Produto.Where(p => p.CodigoBarras == barCode).SingleOrDefault();
        }

        public Produto SalvarProduto(Produto produto)
        {
            this._dbContext.Produto.Add(produto);
            this._dbContext.SaveChanges();
            return produto;
        }
    }
}

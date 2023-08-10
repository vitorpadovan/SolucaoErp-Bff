using RegistroDePreco.Repository.Interfaces;
using SolucaoErpDomain.Configuration.ErrorsApi;
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
            var resultado = _dbContext.Produto.Where(p => p.CodigoBarras == barCode).SingleOrDefault();
            if (resultado == null)
                throw new NotFoundException($"Produto com o código de barras {barCode} não encontrado");
            return resultado;
        }
    }
}

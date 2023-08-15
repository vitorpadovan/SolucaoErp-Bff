using RegistroDePreco.Business.Interfaces;
using RegistroDePreco.Repository.Interfaces;
using SolucaoErpDomain.Auth.Context;
using SolucaoErpDomain.Configuration.ErrorsApi;
using SolucaoErpDomain.Configurations;
using SolucaoErpDomain.Model;

namespace RegistroDePreco.Business.Implementation
{
    public class ProdutoBusiness : ITransientDependecy<IProdutoBusiness, ProdutoBusiness>, IProdutoBusiness
    {
        private readonly IProdutoRepo _produtoRepo;
        private readonly IAuthContext _authContext;
        private readonly IExtratoPontoRepo _extratoPontoRepo;
        public ProdutoBusiness(IProdutoRepo produtoRepo, IAuthContext authContext, IExtratoPontoRepo extratoPontoRepo)
        {
            _produtoRepo = produtoRepo;
            _authContext = authContext;
            _extratoPontoRepo = extratoPontoRepo;
        }

        public Produto GetProduto(int id)
        {
            var resultado = _produtoRepo.GetProduto(id);
            if (resultado == null)
                throw new NotFoundException($"Produto {id} não encontrado");
            return resultado;
        }

        public Produto GetProduto(string v)
        {
            var resultado = _produtoRepo.GetProduto(v);
            if (resultado == null)
                throw new NotFoundException($"Produto {v} não encontrado");
            return resultado;
        }

        public Produto SalvarProduto(Produto produto)
        {
            var usuario = _authContext.GetUsuario();
            var codEvento = Guid.NewGuid();
            produto.codEvento = codEvento;
            var resultado = _produtoRepo.SalvarProduto(produto);
            _extratoPontoRepo.Salvar(new()
            {
                Id = codEvento,
                Pontos = 2,
                DescricaoEvento = $"Salvando produto com o nome de {produto.Nome} e código de barras {produto.CodigoBarras}",
                Usuario = usuario,
                TipoExtrato = SolucaoErpDomain.Model.Enuns.TipoExtrato.CadastroProduto
            });
            return resultado;
        }
    }
}
